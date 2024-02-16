//*******************************************************************************
//This program connects to the instrument and sends and receives commands.
//Enter the command and click the [Transmit and Receive] button to send it.
//If the command has a response (command contains "?"), the response is displayed in the textbox.
//
//System requirements (software)
//   Microsoft Visual Studio Professional 2017
//   Microsoft.NET Framework 4.7
//*******************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample
{
    public partial class Form1 : Form
    {
        private LAN comm;

        // Process for form load
        public Form1()
        {
            InitializeComponent();
            // Process for Enable/Disable on the buttons
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
            TextBox5.ReadOnly = true;

            button8.Enabled = false;
            button7.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button9.Enabled = false;

            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;

            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;

            fetchTimer.Interval = 200;
            fetchTimer.Tick += new EventHandler(FetchTimer_Tick);
        }

        // Events when "Connect" button is clicked
        private void Button1_Click(object sender, EventArgs e)
        {
            // Create a LAN object
            comm = new LAN();

            // Connect
            if (comm.OpenInterface(TextBox1.Text, TextBox2.Text) == false)
            {
                return;
            }

            // Process for Enable/Disable on the buttons
            Button1.Enabled = false;
            Button2.Enabled = true;
            Button3.Enabled = true;
            TextBox1.Enabled = false;
            TextBox2.Enabled = false;
            TextBox3.Enabled = true;
            TextBox4.Enabled = true;

            button8.Enabled = true;
        }

        // Events when "Disconnect" button is clicked
        private void Button2_Click(object sender, EventArgs e)
        {
            // Disconnect
            comm.CloseInterface();

            // Process for Enable/Disable on the buttons
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
            TextBox1.Enabled = true;
            TextBox2.Enabled = true;
            TextBox3.Enabled = false;
            TextBox4.Enabled = false;
        }

        // Events when "Transmit and Receive" button is clicked
        private void Button3_Click(object sender, EventArgs e)
        {
            Button3.Enabled = false;

            TextBox5.AppendText("<< " + TextBox3.Text + "\r\n");                        // Output logs of transmitting data
            comm.SendQueryMsg(TextBox3.Text, Convert.ToInt64(TextBox4.Text) * 1000);    // Transmit and receive commands
            if (TextBox3.Text.Contains("?") == true)                                    // If the command contains "?"
            {
                TextBox5.AppendText(">> " + comm.MsgBuf + "\r\n");                      //Output logs of receiving data
            }

            Button3.Enabled = true;
        }

        // Events when "Clear" button is clicked
        private void Button4_Click(object sender, EventArgs e)
        {
            // Clear the textbox
            TextBox5.Clear();
        }

        // Event when measurement "start" button is clicked
        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            button7.Enabled = true;
            fetchTimer.Start();
        }

        // Event when measurement "stop" button is clicked
        private void button7_Click(object sender, EventArgs e)
        {
            fetchTimer.Stop();
            button8.Enabled = true;
            button7.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void label12_Click_1(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click_2(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void FetchTimer_Tick(object sender, EventArgs e)
        {
            // Since this will execute the command repeatedly, ensure it does not disrupt user interface responsiveness
            comm.SendQueryMsg(":FETC?", 200);

            string[] parts = comm.MsgBuf.Split(',');
            double resistance = double.Parse(parts[0].Trim(), System.Globalization.CultureInfo.InvariantCulture);
            double voltage = double.Parse(parts[1].Trim(), System.Globalization.CultureInfo.InvariantCulture);

            string resStr = resistance.ToString("E2", System.Globalization.CultureInfo.InvariantCulture);
            string volStr = voltage.ToString("E2", System.Globalization.CultureInfo.InvariantCulture);

            // Assuming comm.MsgBuf contains the fetched result after executing SendQueryMsg
            label8.Invoke(new Action(() => label8.Text = resStr));
            label9.Invoke(new Action(() => label9.Text = volStr));
        }

    }
}
