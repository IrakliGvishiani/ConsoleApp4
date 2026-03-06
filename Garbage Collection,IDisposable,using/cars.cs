using System;
using System.Collections.Generic;
using System.Text;

namespace Garbage_Collection_IDisposable_using
{
    public class Cars
    {

        public string Make { get; set; }
        public string Model { get; set; }
        public byte Cylinder { get; set; }
        public float Engine { get; set; }
        public string Drive { get; set; }
        public string Transmission { get; set; }
        public byte City { get; set; }
        public byte Combined { get; set; }
        public byte Highway { get; set; }


        public static Cars Parsee(string input)
        {
            string[] parts = input.Split(',');

            Cars result = new Cars();
            result.Make = parts[0];

            result.Model = parts[1];

            byte.TryParse(parts[2], out byte cylinder);
            result.Cylinder = cylinder;

            float.TryParse(parts[3], out float engine);
            result.Engine = engine;

            result.Drive = parts[4];

            result.Transmission = parts[5];

            byte.TryParse(parts[6], out byte city);
            result.City = city;

            byte.TryParse(parts[7], out byte combined);
            result.Combined = combined;

            byte.TryParse(parts[8], out byte highway);
            result.Highway = highway;



            return result;

        }
    }
}
