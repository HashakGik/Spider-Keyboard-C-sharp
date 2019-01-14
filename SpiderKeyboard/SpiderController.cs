using System;
using System.Threading;
using System.IO.Ports;

using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace SpiderKeyboard
{
    public class SpiderController
    {
        private Thread worker;
        private SerialPort port;
        private bool done;
        private bool shift;
        private bool recordingMacro;
        private string[] macros;
        private int timeouts;

        public delegate void SpiderStatusChange(bool status, string port);
        public delegate void MacroInterrupt();

        /// <summary>
        /// Delegate fired when the SpiderKeyer connects/disconnects.
        /// </summary>
        public SpiderStatusChange OnSpiderStatusChange
        {
            get; set;
        }

        /// <summary>
        /// Delegate fired if paddle is touched while recording a macro.
        /// </summary>
        public MacroInterrupt OnMacroInterrupt
        {
            get; set;
        }

        /// <summary>
        /// Constructor. Creates a worker thread listening for the SpiderKeyer.
        /// </summary>
        public SpiderController()
        {
            this.shift = false;
            this.done = false;
            this.macros = new string[5];

            this.worker = new Thread(Run);
            this.worker.Start();

            this.timeouts = 0;
        }

        /// <summary>
        /// Restarts the worker thread.
        /// </summary>
        public void Restart()
        {
            this.done = false;

            this.worker = new Thread(Run);
            this.worker.Start();
        }
        /// <summary>
        /// Worker thread's main method. Loops the serial ports until a SpiderKeyer is found, then starts listening for commands.
        /// </summary>
        private void Run()
        {
            bool localDone = false;
            bool spiderFound = false;

            while (!(localDone || spiderFound))
            {
                lock (this)
                    localDone = this.done;

                spiderFound = this.FindSpider();
            }
                
            if (spiderFound)
                this.Listen();
        }
        /// <summary>
        /// Looks for a SpiderKeyer connected to the available serial ports. If found, opens a connection and sends the CMD_ECHO's opcode.
        /// </summary>
        /// <returns>True if a SpiderKeyer was found.</returns>
        private bool FindSpider()
        {
            bool ret = false;
            string[] ports;
            string signature;

            try
            {
                 ports = SerialPort.GetPortNames();
            
                for (int i = 0; i < ports.Length && !ret; i++)
                {
                    this.port = new SerialPort(ports[i], 57600);
                    this.port.Open();
                    this.port.ReadTimeout = 2000;

                    // Wait for Arduino to reset itself. TimeoutException if this is too short.
                    Thread.Sleep(5000);

                    this.port.Write("\x11\x00"); // CMD_GET_SIGNATURE

                    signature = "";
                    for (int j = 0; j < 37; j++)
                        signature += Convert.ToChar(this.port.ReadByte());

                    this.port.DiscardInBuffer();

                    if (signature == "Spider Keyer (Arduino Nano) by OK1FIG")
                        ret = true;
                    else if (this.port != null && this.port.IsOpen)
                        this.port.Close();
                }

                if (ret)
                {
                    this.port.Write("\x14\x01"); // CMD_ECHO ON

                    if (this.OnSpiderStatusChange != null)
                        this.OnSpiderStatusChange(true, this.port.PortName);
                }
            }
            catch (Win32Exception)
            {
                // Unable to enumerate system's COM ports.
                ret = false;
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
            catch (InvalidOperationException)
            {
                // Error in Read/Write/Close.
                ret = false;

                if (this.port != null && this.port.IsOpen)
                    this.port.Close();

                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
            catch (UnauthorizedAccessException)
            {
                // Access denied (probably the port is used by another process).
                ret = false;
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
            catch (IOException)
            {
                // Error in Open.
                ret = false;
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }

            return ret;
        }

        /// <summary>
        /// Listens on the open COM port for messages. If it's recording a macro, fires OnMacroInterrupt, otherwise decodes the received strings.
        /// Any communication error forces to retry finding the SpiderKeyer on all ports, every 30 timeouts sends a new CMD_ECHO opcode in case the SpiderKeyer was reset without being disconnected.
        /// </summary>
        private void Listen()
        {
            bool localDone = false;
            bool localRecordingMacro = false;
            string line;

            while (!localDone)
            {
                try
                {
                    line = this.port.ReadLine();

                    lock (this)
                        localRecordingMacro = this.recordingMacro;

                    if (localRecordingMacro)
                    {
                        if (this.OnMacroInterrupt != null)
                            this.OnMacroInterrupt();
                    }
                    else
                        this.Decode(line);
                }
                catch (System.TimeoutException e)
                {
                    // No line received. If this is the 30th time, send a CMD_ECHO ON.
                    this.timeouts = (this.timeouts + 1) % 30;

                    if (this.timeouts == 29)
                        this.port.Write("\x14\x01"); // CMD_ECHO ON
                }
                catch (InvalidOperationException)
                {
                    if (this.OnSpiderStatusChange != null)
                        this.OnSpiderStatusChange(false, "");

                    // Search for the SpiderKeyer.
                    if (this.port != null && this.port.IsOpen)
                        this.port.Close();
                    while (!(localDone || this.FindSpider()))
                        lock (this)
                            localDone = this.done;
                }
                catch (Win32Exception)
                {
                    // Error in SendKeys.SendWait (propagated from Decode).
                }

                lock (this)
                    localDone = this.done;
                // If the thread needs to stop, send a CMD_ECHO opcode before terminating.
                if (localDone)
                {
                    try
                    {
                        this.port.Write("\x14\x00"); // CMD_ECHO OFF
                    }
                    catch (InvalidOperationException)
                    {
                        
                    }
                }
            }
        }

        /// <summary>
        /// Decodes the received symbol and sends the corresponding key to the OS.
        /// </summary>
        /// <param name="line">A string consisting of dots and underscores.</param>
        private void Decode(string line)
        {
            string tmp = "";
            switch (line.Trim('\n'))
            {
                case "._":
                    tmp = "a";
                break;
                case "_...":
                    tmp = "b";
                    break;
                case "_._.":
                    tmp = "c";
                    break;
                case "_..":
                    tmp = "d";
                    break;
                case ".":
                    tmp = "e";
                    break;
                case ".._.":
                    tmp = "f";
                    break;
                case "__.":
                    tmp = "g";
                    break;
                case "....":
                    tmp = "h";
                    break;
                case "..":
                    tmp = "i";
                    break;
                case ".___":
                    tmp = "j";
                    break;
                case "_._":
                    tmp = "k";
                    break;
                case "._..":
                    tmp = "l";
                    break;
                case "__":
                    tmp = "m";
                    break;
                case "_.":
                    tmp = "n";
                    break;
                case "___":
                    tmp = "o";
                    break;
                case ".__.":
                    tmp = "p";
                    break;
                case "__._":
                    tmp = "q";
                    break;
                case "._.":
                    tmp = "r";
                    break;
                case "...":
                    tmp = "s";
                    break;
                case "_":
                    tmp = "t";
                    break;
                case ".._":
                    tmp = "u";
                    break;
                case "..._":
                    tmp = "v";
                    break;
                case ".__":
                    tmp = "w";
                    break;
                case "_.._":
                    tmp = "x";
                    break;
                case "_.__":
                    tmp = "y";
                    break;
                case "__..":
                    tmp = "z";
                    break;
                case "_____":
                    SendKeys.SendWait("0");
                    break;
                case ".____":
                    SendKeys.SendWait("1");
                    break;
                case "..___":
                    SendKeys.SendWait("2");
                    break;
                case "...__":
                    SendKeys.SendWait("3");
                    break;
                case "...._":
                    SendKeys.SendWait("4");
                    break;
                case ".....":
                    SendKeys.SendWait("5");
                    break;
                case "_....":
                    SendKeys.SendWait("6");
                    break;
                case "__...":
                    SendKeys.SendWait("7");
                    break;
                case "___..":
                    SendKeys.SendWait("8");
                    break;
                case "____.":
                    SendKeys.SendWait("9");
                    break;
                case "__..__":
                    SendKeys.SendWait(",");
                    break;
                case "._._._":
                    SendKeys.SendWait(".");
                    break;
                case "_.__.":
                    SendKeys.SendWait("{(}");
                    break;
                case "_.__._":
                    SendKeys.SendWait("{)}");
                    break;
                case "._._.":
                    SendKeys.SendWait("{+}");
                    break;
                case "_...._":
                    SendKeys.SendWait("-");
                    break;
                case "_..._":
                    SendKeys.SendWait("=");
                    break;
                case "..._.._":
                    SendKeys.SendWait("$");
                    break;
                case "_._.__":
                    SendKeys.SendWait("!");
                    break;
                case "..__..":
                    SendKeys.SendWait("?");
                    break;
                case "_.._.":
                    SendKeys.SendWait("/");
                    break;
                case ".__._.":
                    SendKeys.SendWait("@");
                    break;
                case "._...":
                    SendKeys.SendWait("&");
                    break;
                case ".____.":
                    SendKeys.SendWait("'");
                    break;
                case "._.._.":
                    SendKeys.SendWait("\"");
                    break;
                case "___...":
                    SendKeys.SendWait(":");
                    break;
                case "_._._.":
                    SendKeys.SendWait(";");
                    break;


                case "...._.":
                    this.shift = !this.shift; // Toggles CapsLock
                    break;
                case "._._":
                    SendKeys.SendWait("~"); // Enter key
                    break;
                case "..__":
                    SendKeys.SendWait(" ");
                    break;
                case "____":
                    SendKeys.SendWait("{BACKSPACE}");
                    break;

                case "._____":
                    this.ExecuteMacro(0);
                    break;
                case "..____":
                    this.ExecuteMacro(1);
                    break;
                case "...___":
                    this.ExecuteMacro(2);
                    break;
                case "....__":
                    this.ExecuteMacro(3);
                    break;
                case "....._":
                    this.ExecuteMacro(4);
                    break;

                default:
                    break;
            }

            if (this.shift)
                tmp = tmp.ToUpper();

            if (tmp != "")
                SendKeys.SendWait(tmp);
        }

        /// <summary>
        /// Stops the worker thread and closes the serial port.
        /// </summary>
        public void Stop()
        {
            lock(this)
                this.done = true;

            this.worker.Join();
            if (this.port != null && this.port.IsOpen)
                this.port.Close();
        }

        /// <summary>
        /// Notifies the beginning of a macro recording.
        /// </summary>
        public void StartRecording()
        {
            lock (this)
                this.recordingMacro = true;
        }
        /// <summary>
        /// Stores a macro to the given combination.
        /// </summary>
        /// <param name="id">Combination id (0: .-----, 1: ..----, 2: ...---, 3: ....--, 4: .....-).</param>
        /// <param name="macro">Macro to be associated to the id.</param>
        public void SetMacro(int id, string macro)
        {
            if (id >= 0 && id < 5)
                lock (this.macros)
                    this.macros[id] = macro;
        }
        /// <summary>
        /// Notifies the end of a macro recording.
        /// </summary>
        public void StopRecording()
        {
            lock (this)
                this.recordingMacro = false;
        }
        /// <summary>
        /// Returns the macro associated to a given id.
        /// </summary>
        /// <param name="id">Combination id.</param>
        /// <returns>The associated macro.</returns>
        public string GetMacro(int id)
        {
            string ret = "";

            if (id >= 0 && id < 5)
                lock(this.macros)
                    ret = this.macros[id];

            return ret;
        }

        /// <summary>
        /// Executes a macro.
        /// </summary>
        /// <param name="id">Combination id for the macro to be executed.</param>
        private void ExecuteMacro(int id)
        {
            if (id >= 0 && id < 5)
                lock (this.macros)
                    SendKeys.SendWait(this.macros[id]);
        }

        /// <summary>
        /// Sends the CMD_SPEED opcode.
        /// </summary>
        /// <param name="wpm">New speed to be set (between 10 and 40) or -1 if the speed is read from the SpiderKeyer's potentiometer.</param>
        public void SetSpeed(int wpm = -1)
        {
            byte[] cmd = new byte[2];

            cmd[0] = 0x03;

            try
            {
                if (wpm == -1)
                {
                    cmd[1] = 0xff;
                    this.port.Write(cmd, 0, 2);
                }
                    
                else if (wpm >= 10 && wpm <= 40)
                {
                    cmd[1] = (byte)wpm;
                    if (this.port != null && this.port.IsOpen)
                        this.port.Write(cmd, 0, 2);
                }
            }
            catch (InvalidOperationException)
            {
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
        }
        /// <summary>
        /// Sends the CMD_SET_TAIL_TIME opcode.
        /// </summary>
        /// <param name="ms">Tail time to be set (in ms).</param>
        public void SetTailTime(int ms)
        {
            byte[] cmd = new byte[2];

            cmd[0] = 0x05;

            try
            {
                if (ms >= 0)
                {
                    cmd[1] = (byte)(ms / 5);
                    if (this.port != null && this.port.IsOpen)
                        this.port.Write(cmd, 0, 2);
                }
                
            }
            catch (InvalidOperationException)
            {
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
        }
        /// <summary>
        /// Sends the CMD_SET_WEIGHTING opcode.
        /// </summary>
        /// <param name="perc">Weighting percentage to be set.</param>
        public void SetWeighting(int perc)
        {
            byte[] cmd = new byte[2];

            cmd[0] = 0x07;

            try
            {
                if (perc >= 0 && perc <= 100)
                {
                    cmd[1] = (byte)(perc);
                    if (this.port != null && this.port.IsOpen)
                        this.port.Write(cmd, 0, 2);
                }
            }
            catch (InvalidOperationException)
            {
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
        }
        /// <summary>
        /// Sends the CMD_SET_SIDETONE_MANUAL opcode.
        /// </summary>
        /// <param name="hz">Frequency (in Hz) to be set.</param>
        public void SetSidetone(int hz = 0)
        {
            byte[] cmd = new byte[2];

            cmd[0] = 0x0b;

            try
            {
                if (hz >= 0)
                {
                    cmd[1] = (byte)(hz / 10);
                    if (this.port != null && this.port.IsOpen)
                        this.port.Write(cmd, 0, 2);
                }
            }
            catch (InvalidOperationException)
            {
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
        }

        /// <summary>
        /// Sends the CMD_SET_IAMBIC_MODE opcode.
        /// </summary>
        /// <param name="mode">Mode to be set (false: Curtis A, true: Curtis B).</param>
        public void SetIambic(bool mode)
        {
            byte[] cmd = new byte[2];

            cmd[0] = 0x0c;

            if (mode)
                cmd[1] = 0x01;
            else
                cmd[1] = 0x00;

            try
            {
                if (this.port != null && this.port.IsOpen)
                    this.port.Write(cmd, 0, 2);
            }
            catch (InvalidOperationException)
            {
                if (this.OnSpiderStatusChange != null)
                    this.OnSpiderStatusChange(false, "");
            }
        }
    }
}
