using System;
using System.Text.RegularExpressions;

public abstract class Persona
{

    private string surname = "";
    private int age = 0;
    private string id = "";
    private Regex reg = new Regex("\\d{ 8}[A-HJ-NP-TV-Z]");

    public Persona() : this("a", "a", 0, "a")
    {

    }

    public Persona(string name, string surname, int age, string id)
    {
        this.Age = age;
        this.Surname = surname;
        this.Age = age;
        this.ID = id;
    }

    private string name = "";
    public string Name
    {
        set
        {
            if (value.Length > 0)
            {
                this.name = value;
            }
        }

        get
        {
            return this.name;
        }
    }

    public string Surname
    {
        set
        {
            if (value.Length > 0)
            {
                this.surname = value;
            }
        }

        get
        {
            return this.surname;
        }
    }

    public int Age
    {
        set
        {
            if (value < 0)
            {
                this.age = 0;
            }
            else
            {
                this.age = value;
            }
        }

        get
        {
            return this.age;
        }
    }

    public string ID
    {
        set
        {
            if (value.Length > 0 && reg.IsMatch(value))
            {
                this.id = value;
            }
        }
        get
        {
            return this.id;
        }
    }

    public virtual void ShowData()
    {
        Console.WriteLine("This person is {0} {1} and is {2} years old, also his ID number is: {3}", Name, Surname, Age, ID);
    }

    public virtual void InputData() //ReadLine
    {
        Console.WriteLine("Enter a name:");
        this.Name = Console.ReadLine();
        Console.WriteLine("Enter a Surname:");
        this.Surname = Console.ReadLine();
        Console.WriteLine("Enter age:");
        this.Age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter an id");
        this.ID = Console.ReadLine();
    }

    public abstract double Hacienda();
    public abstract double Hacienda(double dinero);
}
