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
            double median = 0;
            String aux = "";
            Subjects subs = 0;
            double[] grades = null;
            string[] names;
            while (select != 9)
            {
                Console.WriteLine("1.- Median of the class.\n2.- Student's median.\n3.- Subject's median.\n4.- Student's grades.\n5.- Subject's grades\n6.- Student's highest and lowest grade.\n7.- Passed student's.\n8.- Whole class.\n9.- Exit.");
                select = AskForInteger();
                switch (select)
                {
                    case 1:
                        Console.WriteLine("The median of the class is: {0,-1:.000}",this.a.median());
                        break;
    
                    case 2:
                        Console.WriteLine("Enter the position of the student you'd like to see:");
                        id--;
                        id = AskForInteger();
                        median = this.a.MedianStudent(id);
                        if (median != -1)
                        {
                            Console.WriteLine("{0}'s median is:{1,1:.000}",this.a.Names[id],median);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student!");
                        }
                        break;
    
                    case 3:
                        Console.WriteLine("Enter the name of the subject you'd like to see:");
                        aux = Console.ReadLine();
                        
                        switch (aux)
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
                        median = this.a.MedianSubject(subs);
                        if (median != -1)
                        {
                            Console.WriteLine("{0}'s median is:{1}", subs.ToString(),median);
                        }
                        else
                        {
                            Console.WriteLine("Invalid subject!");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the position of the student you'd like to check:");
                        id = AskForInteger();
                        id--;
                        grades = this.a.StudentGrades(id);
                        if (grades != null)
                        {
                            Console.WriteLine("{0}'s grades are:", this.a.Names[id]);
                            for (int i = 0; i < grades.GetLength(0); i++)
                            {
                                Console.Write(grades[i]);
                                if (i != grades.GetLength(0)-1)
                                {
                                    Console.Write(",");
                                }
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Student!");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter the name of the subject you'd like to check:");
                        aux = Console.ReadLine();
                        subs = 0;
                        switch (aux)
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
                        grades = this.a.SubjectGrades(subs);
                        if (subs != 0)
                        {
                            Console.WriteLine("{0}'s grades are:", subs.ToString());
                            for (int i = 0; i < grades.GetLength(0); i++)
                            {
                                Console.Write(grades[i]);
                                if (i != grades.GetLength(0) - 1)
                                {
                                    Console.Write(",");
                                }
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Subjuect!");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Enter the position of the student you'd like to check:");
                        id = AskForInteger();
                        id--;
                        grades = this.a.MaxMinStudentGrade(id);
                        if (grades != null)
                        {
                            Console.WriteLine("{0}'s highest grade is: {1} and his lowest grade is: {2}.",this.a.Names[id],grades[0],grades[1]);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student!");
                        }
                        break;

                    case 7:
                        names = this.a.PassedStudents();
                        Console.WriteLine("The students that have passed this year are:");
                        foreach (string name in names)
                        {
                            Console.WriteLine(name);
                        }
                        break;

                    case 8:
                        Console.WriteLine("{0,10} {1,2} {2,2} {3,2}",Subjects.Algebra.ToString()[0],Subjects.Mathematics.ToString()[0], Subjects.Physics.ToString()[0], Subjects.Technical_drawing.ToString()[0]);
                        for (int i = 0;i < this.a.Names.GetLength(0);i++)
                        {
                            grades = this.a.StudentGrades(i);
                            Console.WriteLine("{0,2}.- {1}| {2,2} {3,2} {4,2} {5,2}",i+1,this.a.Names[i],this.a[i,0],this.a[i,1],this.a[i,2],this.a[i,3]);
                        }
                        Console.WriteLine();
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
