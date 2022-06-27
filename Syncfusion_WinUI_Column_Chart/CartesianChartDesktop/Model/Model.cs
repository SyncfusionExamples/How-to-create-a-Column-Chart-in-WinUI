using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartesianChartDesktop
{
    public class Model
    {
        public string Country { get; set; }

        public double Counts { get; set; }

        public Model(string name, double count)
        {
            Country = name;
            Counts = count;
        }
    }
}
