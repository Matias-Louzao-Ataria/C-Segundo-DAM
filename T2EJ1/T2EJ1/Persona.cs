using System;

public abstract class Persona{
	private string name = "";
	private string surname = "";
	private int age = 0;
	private string id = "";

	public Persona(){
		this("","",0,"");
	}

	public Persona(string name,string,surname,int age,string id){
		this.Age = age;
		this.Surname = surname;
		this.Age = age;
		this.ID = id;
    }

	public string Name{
		set{
            if (value.Length > 0)
            {
				this.name = value;
            }
		}
		get;
	};
	public string Surname{
		set{
			if (value.Length > 0)
			{
				this.surname = value;
			}
		}
		get;
	};

	public int Age{ 
		set{
            if (value < 0)
            {
				this.age = 0;
            }
            else
            {
				this.age = value;
            }
		}
			get;
	};

	public string ID { set; get; };

	public virtual void ShowData(){
		Console.WriteLine("This person is {0} {1} and is {3} years old, also his ID number is: {4}",Name,Surname,Age,ID);
    }

	public virtual void InputData(string name,string surname,int age,string id){
		this.Name = name;
		this.Surname = surname;
		this.Age = age;
		this.ID = id;
    }

	public abstract double Hacienda();
}
