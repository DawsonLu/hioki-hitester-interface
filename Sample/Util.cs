using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    internal class Util
    {
        public static string ConvertToMetricNotation(double value)
        {
            string[] prefixes = { "p", "n", "μ", "m", "", "k", "M", "G", "T" };
            int exponent = (int)Math.Floor(Math.Log10(Math.Abs(value)) / 3);
            int index = exponent + 4; // Adjust index to match the prefixes array, where "" (no prefix) is for 10^0

            if (index < 0) index = 0;
            if (index >= prefixes.Length) index = prefixes.Length - 1;

            double scaledValue = value / Math.Pow(10, (exponent * 3));

            return string.Format("{0:0.##}{1}", scaledValue, prefixes[index]);
        }
    }

    public class Measurement
    {
        public int Counter { get; set; }
        public double Voltage { get; set; }
        public double Resistance { get; set; }

        public Measurement(int counter, double voltage, double resistance)
        {
            Counter = counter;
            Voltage = voltage;
            Resistance = resistance;
        }
    }
}
