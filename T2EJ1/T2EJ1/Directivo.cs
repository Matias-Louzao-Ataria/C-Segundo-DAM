using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace T2EJ1
{
    class Directivo : Persona
    {
        private string depart;
        private double benefits;
        private int employees;

        public string Depart { set; get; }

        public double Benefits
        {
            get
            {
                return this.benefits;
            }
        }

        public int Employees
        {
            set
            {
                if (value >= 0 && value <= 10)
                {
                    this.benefits = 2;
                }
                else if (value <= 50)
                {
                    this.benefits = 3.5;
                }
                else
                {
                    this.benefits = 4;
                }
            }

            get
            {
                return this.employees;
            }
        }

        public override double Hacienda()
        {
            throw new NotImplementedException();
        }

        public static Directivo operator --(Directivo d)
        {
            if (d.benefits > 0)
            {
                d.benefits--;
            }
            return d;
        }
    }
}
