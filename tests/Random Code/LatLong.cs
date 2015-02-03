using System;
using System.Diagnostics;
using System.Linq;

namespace tests
{
    class LatLong
    {


        private double _longitudeDecimal;
        private double _latitudeDecimal;

        private string _longitudeString;
        private string _latitudeString;

        public double LongitudeDecimal
        {
            get { return _longitudeDecimal; }
            set
            {
                _longitudeDecimal = value;
                _longitudeString = ConvertToString(value);
            }
        }

        public double LatitudeDecimal
        {
            get { return _latitudeDecimal; }
            set
            {
                _latitudeDecimal = value;
                _latitudeString = ConvertToString(value);
            }
        }

        public string LongitudeString
        {
            get { return _longitudeString; }
            set
            {
                _longitudeString = value;
                _longitudeDecimal = ConvertToDecimal(value);
            }
        }

        public string LatitudeString
        {
            get { return _latitudeString; }
            set
            {
                _latitudeString = value;
                _latitudeDecimal = ConvertToDecimal(value);
            }
        }

        public LatLong(double longDecimal, double latDecimal)
        {
            LongitudeDecimal = longDecimal;
            LatitudeDecimal = latDecimal;
        }

        public LatLong(string longString, string latString)
        {
            LongitudeString = longString;
            LatitudeString = latString;
        }


        private string ConvertToString(double value)
        {
            var degrees = Math.Truncate(value);
            var temp = (value - degrees) * 60;
            var minutes = Math.Truncate(temp);
            var seconds = (temp - minutes) * 60;

            return String.Format("{0}° {1}' {2:##.000}\"", degrees, minutes, seconds);

        }

        private double ConvertToDecimal(string value)
        {
            var data = value.Split(new[] { '\'', '’', '″', '\"', '°' }, StringSplitOptions.RemoveEmptyEntries);
            var parsedData = data.Select(double.Parse).ToArray();
            Debug.Assert(data.Count() == 3);
            return parsedData[0] + parsedData[1] / 60 + parsedData[2] / 3600;
        }
    }

    internal class TestLatLong
    {
        public void Test()
        {
            var x = new LatLong(42.1361, 42.1361);


            Console.WriteLine("Expected: {0}", "42° 8' 9.9594\"");
            Console.WriteLine("Obtained: {0}", x.LongitudeString);

            const string strLatLong = @"89° 8’ 6″";

            var y = new LatLong(strLatLong, strLatLong);
            Console.WriteLine("Expected: {0}", "89.135");
            Console.WriteLine("Obtained: {0}", y.LatitudeDecimal);
        }
    }
}
