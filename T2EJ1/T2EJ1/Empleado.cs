using System;
public class Empleado : Persona
{

    private double salary;
    private double iprf;
    private string phoneNumber;

    public Empleado() : this("a", "a", 0, "a", 0, 0, "a")
    {

    }

    public Empleado(string name, string surname, int age, string id, double salary, double iprf, string phoneNumber) : base(name, surname, age, id)
    {
        this.Salary = salary;
        this.IPRF = iprf;
        this.PhoneNumber = phoneNumber;
    }

    public double Salary
    {
        set
        {
            if (value <= 600)
            {
                iprf = 7;
            }
            else if ( value <= 3000)
            {
                iprf = 15;
            }
            else 
            {
                iprf = 20;
            }
        }

        get
        {
            return this.salary;
        }
    }

    public double IPRF { get; }

    public string PhoneNumber
    {
        set
        {
            if (value.Length > 0)
            {
                this.phoneNumber = value;
            }
        }

        get
        {
            return "+34" + this.phoneNumber;
        }
    }

    public override double Hacienda()
    {
        return (Salary * IPRF) / 100;
    }

    public override void ShowData()
    {
        base.ShowData();
        Console.WriteLine("This person's salary is {0}, his iprf is: {1} and his phone number is {3}", Salary, IPRF, PhoneNumber);
    }

    public void ShowData(int n)
    {
        switch (n)
        {
            case 0:
                Console.WriteLine("Name: " + this.Name);
                break;

            case 1:
                Console.WriteLine("Surname: " + this.Surname);
                break;

            case 2:
                Console.WriteLine("Age: " + this.Age);
                break;

            case 3:
                Console.WriteLine("ID: " + this.ID);
                break;

            case 4:
                Console.WriteLine("Salary: " + this.Salary);
                break;

            case 5:
                Console.WriteLine("IPRF: " + this.IPRF);
                break;

            case 6:
                Console.WriteLine("Phone number: " + this.PhoneNumber);
                break;
            default:
                Console.WriteLine("Orden no programada.");
                break;
        }
    }

}