using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ2
{
    class InterfazDeUsuario
    {
        private Aula a = new Aula();
        public void menu()
        {
            int select = 0,id = 0;
            while (select != 9)
            {
                Console.WriteLine("1.- Median of the class.\n2.- Student's median.\n3.- Subject's median.\n4.- Student's grades.\n5.- Subject's grades\n6.- Student's highest and lowest grade.\n7.- Passed student's.\n8.- Whole class.\n9.- Exit.");
                select = AskForInteger();
                switch (select)
                {
                    case 1:
                        Console.WriteLine("The median of the class is: {0,-1:.000}",a.median());
                        break;
    
                    case 2:
                        Console.WriteLine("Enter the position of the student you'd like to see:");
                        id = AskForInteger();
                        double c = a.MedianStudent(id);
                        if (c != -1)
                        {
                            Console.WriteLine("{0}'s median is:{1,1:.000}",this.a.Names[id],c);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student!");
                        }
                        break;
    
                    case 3:
                        Console.WriteLine("Enter the name of the subject you'd like to see:");
                        String s = Console.ReadLine();
                        Subjects subs = 0;
                        double d;
                        switch (s)
                        {
                            case String sub when sub.ToLower().Contains("alg"):
                                subs = Subjects.Algebra;
                                break;

                            case String sub when sub.ToLower().Contains("math"):
                                subs = Subjects.Mathematics;
                                break;

                            case String sub when sub.ToLower().Contains("phys"):
                                subs = Subjects.Physics;
                                break;

                            case String sub when sub.ToLower().Contains("tec"):
                                subs = Subjects.Technical_drawing;
                                break;
                        }
                        d = a.MedianSubject(subs);
                        if (d != -1)
                        {
                            Console.WriteLine("{0}'s median is:{1}", subs.ToString(),d);
                        }
                        else
                        {
                            Console.WriteLine("Invalid subject!");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the position of the student you'd like to see:");
                        id = AskForInteger();
                        double[] grades = a.StudentGrades(id);
                        if (grades.GetLength(0) > 2)
                        {
                            Console.WriteLine("{0}'s grades are:", this.a.Names[id]);
                            for (int i = 0; i < grades.GetLength(0); i++)
                            {
                                Console.WriteLine(grades[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Student!");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter the name of the subject you'd like to see:");
                        s = Console.ReadLine();
                        subs = 0;
                        switch (s)
                        {
                            case String sub when sub.ToLower().Contains("alg"):
                                subs = Subjects.Algebra;
                                break;

                            case String sub when sub.ToLower().Contains("math"):
                                subs = Subjects.Mathematics;
                                break;

                            case String sub when sub.ToLower().Contains("phys"):
                                subs = Subjects.Physics;
                                break;

                            case String sub when sub.ToLower().Contains("tec"):
                                subs = Subjects.Technical_drawing;
                                break;
                        }
                        grades = a.SubjectGrades(subs);
                        if (subs != 0)
                        {
                            Console.WriteLine("{0}'s grades are:", subs.ToString());
                            for (int i = 0; i < grades.GetLength(0); i++)
                            {
                                Console.WriteLine(grades[i]);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Subjuect!");
                        }
                        break;

                    case 6:
                        break;

                    case 7:
                        break;

                    case 8:
                        break;

                    case 9:
                        Console.WriteLine("Chao!");
                        break;

                    default:
                        Console.WriteLine("Action not recognised");
                        break;
                }
            }
        }

        public int AskForInteger()
        {
            int res = 0;
            while (res == 0)
            {
                try
                {
                    res = int.Parse(Console.ReadLine());
                }catch(Exception e) when (e is FormatException || e is OverflowException)
                {
                    Console.WriteLine("Invalid number!");
                    res = 0;
                }
            }
            return res;
        }
    }
}
