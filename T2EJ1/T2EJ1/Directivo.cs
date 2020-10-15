using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace T2EJ1
{
    class Directivo : Persona,IPastaGansa
    {
        private string depart;
        private double benefits;
        private int employees;

        public Directivo() : this("a", "a", 0, "a","",1)
        {

        }

        public Directivo(string name, string surname, int age, string id,string depart,int employees) : base(name,surname,age,id)
        {
            this.Depart = depart;
            this.Employees = employees;
        }
        
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
                    this.benefits = 35;
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

        public override double Hacienda(double dinero)
        {
            return GanarPasta(this.Benefits,dinero) * 0.3;
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
            Console.WriteLine("This executive is the head of {0} department, has {1} employees and benefits {2}",Depart,Employees,Benefits);
        }

        public override void InputData()
        {
            base.InputData();
            Console.WriteLine("Enter depart name:");
            this.Depart = Console.ReadLine();
            Console.WriteLine("Enter number of employees:");//Se calcula el % de beneficios con el nº de empleados.
            this.Employees = int.Parse(Console.ReadLine());
        }

        public static void ShowIncome(IPastaGansa d,double benefits)
        {
            double res = 0, money = 0;
            do
            {
                try
                {
                    Directivo actual = (Directivo)d;
                    Console.WriteLine("Enter company income:");
                    money = double.Parse(Console.ReadLine());
                    res = d.GanarPasta(benefits, money);
                    Console.WriteLine("Ganar pasta: "+res);
                    Console.WriteLine("Hacienda: "+actual.Hacienda(money));
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Enter a valid number!");
                    res = 0;
                }
            } while (res == 0);
        }

        public double GanarPasta(double benefits, double dinero)
        {
            if (dinero > 0)
            {
                return dinero * (benefits/100);
            }
            else
            {
                Directivo d = this;
                d--;
                return 0;
            }
        }

        public override double Hacienda()
        {
            return GanarPasta(this.Benefits, 0) * 0.3;
        }
    }

    public interface IPastaGansa
    {
        double GanarPasta(double benefits, double dinero);
    }

    class EmpleadoEspecial : Empleado, IPastaGansa
    {

        public EmpleadoEspecial() : this("a", "a", 0, "a", 0, "a")
        {

        }

        public EmpleadoEspecial(string name, string surname, int age, string id, double salary, string phoneNumber) : base(name, surname, age, id,salary,phoneNumber)
        {
            
        }

        public static void ShowIncome(IPastaGansa d, double benefits)
        {
            double res = 0,money = 0;
            do
            {
                try
                {
                    EmpleadoEspecial actual = (EmpleadoEspecial)d;
                    Console.WriteLine("Enter company income:");
                    money = double.Parse(Console.ReadLine());
                    res = actual.GanarPasta(money);
                    Console.WriteLine("Ganar pasta: " + res);
                    Console.WriteLine("Hacienda: " + actual.Hacienda(money));
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Enter a valid number!");
                    res = 0;
                }
            } while (res == 0);
        }

        public override double Hacienda(double dinero)
        {
            return base.Hacienda()+(GanarPasta(dinero)*0.1);
        }

        public double GanarPasta(double dinero, double benefits = 0.5)
        {
            return 0.5 * dinero;
        }
    }
}
