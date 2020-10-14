using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace T2EJ1
{
    class Directivo : Persona,IPastaGansa
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
            return calculo(this.Benefits,3000) * 0.3;
        }

        public static Directivo operator --(Directivo d)
        {
            if (d.benefits > 0)
            {
                d.benefits--;
            }
            return d;
        }

        public override void ShowData()
        {
            base.ShowData();
            Console.WriteLine("This executive is the head of {0} department, has {1} employees and benefits {3}",Depart,Employees,Benefits);
        }

        public override void InputData()
        {
            base.InputData();
            Console.WriteLine("Enter depart name:");
            this.Depart = Console.ReadLine();
            Console.WriteLine("Enter number of employees:");//Se calcula el % de beneficios con el nº de empleados.
            this.Employees = int.Parse(Console.ReadLine());
        }

        public double calculo(double benefits, double dinero)
        {
            if (dinero > 0)
            {
                return dinero * benefits;
            }
            else
            {
                Directivo d = this;
                d--;
                return 0;
            }
        }
    }

    public interface IPastaGansa
    {
        double calculo(double benefits, double dinero);
    }

    class EmpleadoEspecial : Empleado, IPastaGansa
    {

        public override double Hacienda()
        {
            return base.Hacienda()+(calculo(3000f)*0.1);
        }

        public double calculo(double dinero, double benefits = 0.5)
        {
            return benefits * dinero;
        }
    }
}
