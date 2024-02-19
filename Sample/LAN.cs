using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interface
{
    class LAN
    {
        // (0)Class variable
        private System.Net.Sockets.TcpClient LanSocket;                                 // LAN socket
        public string MsgBuf = "";                                                      // Received Data

        // (1)Connect
        public bool OpenInterface(string ipaddress, string port)
        {
            bool ret = false;
            System.Net.IPAddress ip = new System.Net.IPAddress(0);                      // IP address

            try
            {
                if (System.Net.IPAddress.TryParse(ipaddress, out ip))
                {
                    LanSocket = new System.Net.Sockets.TcpClient();                     // Create a LAN socket object
                    LanSocket.NoDelay = true;                                           
                    LanSocket.Connect(ip, Convert.ToInt32(port));                       // Connect
                    ret = true;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (2)Disconnect
        public bool CloseInterface()
        {
            bool ret = false;

            try
            {
                LanSocket.Close();                                                      // LAN socket close
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (3)Send commands
        public bool SendMsg(string strMsg)
        {
            bool ret = false;
            byte[] SendBuffer = new byte[1024];

            try
            {
                strMsg += "\r\n";                                                       // Add a terminator, CR+LR, to transmitted command
                SendBuffer = System.Text.Encoding.Default.GetBytes(strMsg);             // Convert to byte type
                LanSocket.GetStream().Write(SendBuffer, 0, SendBuffer.Length);          // Write data in the transmit buffer
                ret = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (4)Receive
        public bool ReceiveMsg(long timeout_ms)
        {
            bool ret = false;
            byte[] ary = new byte[65536];
            string rcv;
            int len;
            StringBuilder buf = new StringBuilder();
            Stopwatch sw = new Stopwatch();

            try
            {
                MsgBuf = "";                                                            // Clear received data

                sw.Start();                                                             // Start a stopwatch
                                                                                        // Continue the loop until LF is received
                while (true)
                {
                    if (LanSocket.GetStream().DataAvailable == true)                    
                    {
                        len = LanSocket.GetStream().Read(ary, 0, ary.Length);           // Read data from the receive buffer
                        rcv = Encoding.Default.GetString(ary).Substring(0, len);
                        rcv = rcv.Replace("\r", "");                                    // Delete CR in received data
                        if (rcv.IndexOf("\n") >= 0)                                     // End the loop when LF is received
                        {
                            rcv = rcv.Substring(0, rcv.IndexOf("\n"));                  // Extract data without LF and the following from the original received data
                            buf.Append(rcv);                                            // Save the data
                            MsgBuf = buf.ToString();
                            break;
                        }
                        else
                        {
                            buf.Append(rcv);                                            // Save the data
                        }
                    }
                    // Timeout processing
                    if (sw.ElapsedMilliseconds > timeout_ms)
                    {
                        MsgBuf = "Timeout";
                        MessageBox.Show(MsgBuf);
                        return ret;
                    }
                }
                sw.Stop();                                                              // Stop a stopwatch
                ret = true;
            }
            catch (Exception e)
            {
                MsgBuf = "Error";
                MessageBox.Show(e.Message);
            }

            return ret;
        }

        // (5)Transmit and receive commands
        public bool SendQueryMsg(string strMsg, long timeout_ms)
        {
            bool ret = false;
            byte[] ary = new byte[65536];

            if (LanSocket.GetStream().DataAvailable == true)                            // If exist the data in the receive buffer, read all data.
            {
                LanSocket.GetStream().Read(ary, 0, ary.Length);
            }

            ret = SendMsg(strMsg);                                                      // Transmit commands
            if (ret)
            {
                if (strMsg.Contains("?"))
                {
                    ret = ReceiveMsg(timeout_ms);                                       // Receive response when command transmission is succeeded
                }
            }

            return ret;
        }
    }

}
