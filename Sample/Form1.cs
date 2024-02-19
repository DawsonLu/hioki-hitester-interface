//*******************************************************************************
//System requirements (software)
//  Microsoft Visual Studio Professional 2017
//  Microsoft.NET Framework 4.7
//
//This program interfaces with the HIOKI Battery Hi-Tester and allows the user 
//to see real-time measurements, record and save measurements, and input individual 
//commands into the device.
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
using System.IO;

namespace Interface
{
    public partial class Form1 : Form
    {
        private LAN comm;

        // Threshold for no measurements
        private const double NoMeasurementThreshold = 1_000_000_000;

        // Counter for interval of measurements
        private int counter = 0;

        // Flag for automatic recording
        private bool autoNext = false;

        // Saved last res and vol values to prevent repeated log entries and saving to measurements
        private double prevResistance = 0;
        private double prevVoltage = 0;

        // Storing measurement data
        private List<Measurement> measurements = new List<Measurement> ();

        // Process for form load
        public Form1()
        {
            InitializeComponent();
            // Interface componenets
            connect.Enabled = true;
            disconnect.Enabled = false;
            ipTextbox.Enabled = true;
            portTextbox.Enabled = true;

            // Commands components
            transmitAndRecieve.Enabled = false;
            commandTextbox.Enabled = false;
            timeoutTextbox.Enabled = false;
            consoleTextbox.ReadOnly = true;

            // Record components
            recordLog.ReadOnly = true;
            startRecord.Enabled = false;
            stopRecord.Enabled = false;
            manualNext.Enabled = false;
            manualRadioButton.Enabled = false;
            autoRadioButton.Enabled = false;
            timeIntervalRadioButton.Enabled = false;
            secIntervalNumeric.Enabled = false;

            // Measurements component
            startMeasurement.Enabled = false;
            stopMeasurement.Enabled = false;

            // Measurement timer parameters
            fetchTimer.Interval = 200;
            fetchTimer.Tick += new EventHandler(FetchTimer_Tick);

            // Record timer parameters
            manualRecordTimer.Interval = 500;
            autoRecordTimer.Interval = 500;

            // Save CSV default parameters
            saveFileDialog1.Title = "Save CSV File";
            saveFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.FileName = "Measurements";
        }

        // Events when "Connect" button is clicked
        private void Connect_Click(object sender, EventArgs e)
        {
            // Create a LAN object
            comm = new LAN();

            // Connect
            if (comm.OpenInterface(ipTextbox.Text, portTextbox.Text) == false)
            {
                return;
            }

            // Enable/disable buttons when connected
            connect.Enabled = false;
            disconnect.Enabled = true;
            transmitAndRecieve.Enabled = true;
            ipTextbox.Enabled = false;
            portTextbox.Enabled = false;
            commandTextbox.Enabled = true;
            timeoutTextbox.Enabled = true;
            startMeasurement.Enabled = true;
            manualRadioButton.Enabled = true;
            autoRadioButton.Enabled = true;
            timeIntervalRadioButton.Enabled = true;
        }

        // Events when "Disconnect" button is clicked
        private void Disconnect_Click(object sender, EventArgs e)
        {
            // Disconnect
            comm.CloseInterface();

            // Enable/disable buttons when disconnected
            connect.Enabled = true;
            disconnect.Enabled = false;
            transmitAndRecieve.Enabled = false;
            ipTextbox.Enabled = true;
            portTextbox.Enabled = true;
            commandTextbox.Enabled = false;
            timeoutTextbox.Enabled = false;
            startMeasurement.Enabled = false;
            stopMeasurement.Enabled = false;
            startRecord.Enabled = false;
            stopRecord.Enabled = false;
            manualNext.Enabled = false;
            manualRadioButton.Enabled = false;
            autoRadioButton.Enabled = false;
            timeIntervalRadioButton.Enabled = false;
            secIntervalNumeric.Enabled = false;
        }

        // Events when "Transmit and Receive" button is clicked
        private void TransmitAndRecieve_Click(object sender, EventArgs e)
        {
            transmitAndRecieve.Enabled = false;

            consoleTextbox.AppendText("<< " + commandTextbox.Text + "\r\n");                        // Output logs of transmitting data
            comm.SendQueryMsg(commandTextbox.Text, Convert.ToInt64(timeoutTextbox.Text) * 1000);    // Transmit and receive commands
            if (commandTextbox.Text.Contains("?") == true)                                    // If the command contains "?"
            {
                consoleTextbox.AppendText(">> " + comm.MsgBuf + "\r\n");                      //Output logs of receiving data
            }

            transmitAndRecieve.Enabled = true;
        }

        // Events when "Clear" button is clicked
        private void Clear_Click(object sender, EventArgs e)
        {
            // Clear the textbox
            consoleTextbox.Clear();
        }

        // Event when measurement "start" button is clicked
        private void StartMeasurement_Click(object sender, EventArgs e)
        {
            startMeasurement.Enabled = false;
            stopMeasurement.Enabled = true;

            fetchTimer.Start();
        }

        // Event when measurement "stop" button is clicked
        private void StopMeasurement_Click(object sender, EventArgs e)
        {
            fetchTimer.Stop();

            startMeasurement.Enabled = true;
            stopMeasurement.Enabled = false;

            resistance_measurement.Text = "_.____";
            voltage_measurement.Text = "_.____";
        }

        // Event when "Manual" Radio Button is clicked
        private void ManualRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            startRecord.Enabled = true;
            secIntervalNumeric.Enabled = false;
        }

        // Event when "Automatic" Radio Button is clicked
        private void AutoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            startRecord.Enabled = true;
            secIntervalNumeric.Enabled = false;
        }

        // Event when "Interval" Radio Button is clicked
        private void TimeIntervalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            startRecord.Enabled = true;
            secIntervalNumeric.Enabled = true;
        }

        // Event when "Start" record is clicked
        private void StartRecord_Click(object sender, EventArgs e)
        {
            // Enable/disable buttons when start recording
            stopRecord.Enabled = true;
            startRecord.Enabled = false;
            manualRadioButton.Enabled = false;
            autoRadioButton.Enabled = false;
            timeIntervalRadioButton.Enabled = false;
            secIntervalNumeric.Enabled = false;
            disconnect.Enabled = false;
            transmitAndRecieve.Enabled = false;
            commandTextbox.Enabled = false;
            timeoutTextbox.Enabled = false;

            // Reset measurement var
            counter = 0;
            prevResistance = NoMeasurementThreshold;
            prevVoltage = NoMeasurementThreshold;

            // Clear measurements object
            measurements.Clear();
            
            // Output first measurement
            recordLog.AppendText($"New Measurement No. {counter}\r\n");
            
            if (manualRadioButton.Checked)
            {
                manualNext.Enabled = true;
                manualRecordTimer.Start();
                Console.Beep(800, 900);
            }
            else if (autoRadioButton.Checked)
            {
                autoNext = false;
                autoRecordTimer.Start();
                Console.Beep(800, 900);
            }
            else if (timeIntervalRadioButton.Checked)
            {
                intervalRecordTimer.Interval = (int)Math.Floor(secIntervalNumeric.Value * 1000);
                manualRecordTimer.Start();
                intervalRecordTimer.Start();
                Console.Beep(800, 900);
            }
        }

        // Event when "Stop" record is clicked
        private void StopRecord_Click(object sender, EventArgs e)
        {
            // Enable/disable components when stop recording
            startRecord.Enabled = true;
            stopRecord.Enabled = false;
            manualNext.Enabled = false;
            manualRadioButton.Enabled = true;
            autoRadioButton.Enabled = true;
            timeIntervalRadioButton.Enabled = true; 
            disconnect.Enabled = true;
            transmitAndRecieve.Enabled = true;
            commandTextbox.Enabled = true;
            timeoutTextbox.Enabled = true;

            // Add last measurement to measurements
            measurements.Add(new Measurement(counter, prevVoltage, prevResistance));

            // Stop various timers
            if (manualRadioButton.Checked)
            {
                manualRecordTimer.Stop();
            }
            else if (autoRadioButton.Checked)
            {
                autoRecordTimer.Stop();
            }
            else if (timeIntervalRadioButton.Checked)
            {
                intervalRecordTimer.Stop();
                secIntervalNumeric.Enabled = true;
            }

            // Save to CSV
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StringBuilder csv = new StringBuilder();

                csv.AppendLine("Measurement No.,Resistance,Voltage");

                foreach (var measurement in measurements)
                {
                    csv.AppendLine($"{measurement.Counter},{measurement.Resistance},{measurement.Voltage}");
                }

                File.WriteAllText(saveFileDialog1.FileName, csv.ToString());
            }
        }

        // Timer for taking continuous measurements
        private void FetchTimer_Tick(object sender, EventArgs e)
        {
            comm.SendQueryMsg(":FETC?", 200);

            // Convert msg to doubles and handle weird '-' output from device
            string[] parts = comm.MsgBuf.Split(',');
            string resistanceStr = parts[0].Trim().Replace("- ", "-");
            double resistance = double.Parse(resistanceStr, System.Globalization.CultureInfo.InvariantCulture);
            string voltageStr = parts[1].Trim().Replace("- ", "-");
            double voltage = double.Parse(voltageStr, System.Globalization.CultureInfo.InvariantCulture);

            // Format resistance and voltage
            string resStr = Util.ConvertToMetricNotation(resistance) + "Ω";
            string volStr = Util.ConvertToMetricNotation(voltage) + "V";

            if (resistance >= NoMeasurementThreshold)
            {
                resStr = "No Measurement";
            }

            if (voltage >= NoMeasurementThreshold)
            {
                volStr = "No Measurement";
            }

            resistance_measurement.Invoke(new Action(() => resistance_measurement.Text = resStr));
            voltage_measurement.Invoke(new Action(() => voltage_measurement.Text = volStr));
        }

        // Timer for manual and interval measurements
        private void ManualRecordTimer_Tick(object sender, EventArgs e)
        {
            comm.SendQueryMsg(":FETC?", 200);

            // Convert msg to doubles and handle weird '-' output from device
            string[] parts = comm.MsgBuf.Split(',');
            string resistanceStr = parts[0].Trim().Replace("- ", "-");
            double resistance = double.Parse(resistanceStr, System.Globalization.CultureInfo.InvariantCulture);
            string voltageStr = parts[1].Trim().Replace("- ", "-");
            double voltage = double.Parse(voltageStr, System.Globalization.CultureInfo.InvariantCulture);

            // Check for valid measurements and none repeating measurements
            if (resistance < NoMeasurementThreshold && voltage < NoMeasurementThreshold && resistance != prevResistance && voltage != prevVoltage)
            {
                recordLog.AppendText($"res = {resistance}, vol = {voltage}\r\n");
                
                prevResistance = resistance;
                prevVoltage = voltage;

                Console.Beep();
            }
        }

        // Timer for automatic measurements
        private void AutoRecordTimer_Tick(object sender, EventArgs e)
        {
            comm.SendQueryMsg(":FETC?", 200);

            // Convert msg to doubles and handle weird '-' output from device
            string[] parts = comm.MsgBuf.Split(',');
            string resistanceStr = parts[0].Trim().Replace("- ", "-");
            double resistance = double.Parse(resistanceStr, System.Globalization.CultureInfo.InvariantCulture);
            string voltageStr = parts[1].Trim().Replace("- ", "-");
            double voltage = double.Parse(voltageStr, System.Globalization.CultureInfo.InvariantCulture);

            // Check if counter should be incremented for a new measurement
            if (autoNext && (resistance >= NoMeasurementThreshold || voltage >= NoMeasurementThreshold))
            {
                measurements.Add(new Measurement(counter, prevVoltage, prevResistance));
                recordLog.AppendText($"\r\nNew Measurement No. {++counter}\r\n");

                autoNext = false;
                prevResistance = NoMeasurementThreshold;
                prevVoltage = NoMeasurementThreshold;

                Console.Beep(800, 900);
            }

            // Check for valid measurements, none repeating measurements and reset auto flag
            if (resistance < NoMeasurementThreshold && voltage < NoMeasurementThreshold && resistance != prevResistance && voltage != prevVoltage)
            {
                recordLog.AppendText($"res = {resistance}, vol = {voltage}\r\n");

                autoNext = true;
                prevResistance = resistance;
                prevVoltage = voltage;

                Console.Beep();
            }
        }

        // Timer for incrementing counter/interval based on timer
        private void IntervalRecordTimer_Tick(object sender, EventArgs e)
        {
            measurements.Add(new Measurement(counter, prevVoltage, prevResistance));
            recordLog.AppendText($"\r\nNew Measurement No. {++counter}\r\n");

            Console.Beep(800, 900);

            prevResistance = NoMeasurementThreshold;
            prevVoltage = NoMeasurementThreshold;
        }

        // Event when "Clear" record is clicked
        private void clearRecord_Click(object sender, EventArgs e)
        {
            recordLog.Clear();
        }

        // Event when "Next" is clicked for manual recording
        private void manualNext_Click(object sender, EventArgs e)
        {
            measurements.Add(new Measurement(counter, prevVoltage, prevResistance));
            recordLog.AppendText($"\r\nNew Measurement No. {++counter}\r\n");

            Console.Beep(800, 900);

            prevResistance = NoMeasurementThreshold;
            prevVoltage = NoMeasurementThreshold;
        }
    }
}
