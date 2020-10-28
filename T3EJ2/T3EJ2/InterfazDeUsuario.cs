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
            int select = 0,id = 0,aux = 0;
            double median = 0,max = 0,min = 99;
            double[] grades = null;
            string[] names;
            while (select != 9)
            {
                Console.WriteLine("1.- Median of the class.\n2.- Student's median.\n3.- Subject's median.\n4.- Student's grades.\n5.- Subject's grades\n6.- Student's highest and lowest grade.\n7.- Passed student's.\n8.- Whole table.\n9.- Exit.");
                select = AskForInteger(true);
                switch (select)
                {
                    case 1:
                        Console.WriteLine("The median of the class is: {0,-1:.000}",this.a.median());
                        break;
    
                    case 2:
                        students();
                        Console.WriteLine("Enter the position of the student you'd like to see:");
                        id = AskForInteger(false);
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
                        subjects();
                        Console.WriteLine("Enter the id of the subject you'd like to see:");
                        aux = AskForInteger(true);
                        
                        median = this.a.MedianSubject((Subjects)aux);
                        if (median != -1)
                        {
                            Console.WriteLine("{0}'s median is:{1}", ((Subjects)aux).ToString(),median);
                        }
                        else
                        {
                            Console.WriteLine("Invalid subject!");
                        }
                        break;

                    case 4:
                        students();
                        Console.WriteLine("Enter the position of the student you'd like to check:");
                        id = AskForInteger(false);
                        grades = this.a.StudentGrades(id);
                        if (grades != null)
                        {
                            Console.WriteLine("{0}'s grades are:", this.a.Names[id]);
                            for (int i = 0; i < grades.GetLength(0); i++)
                            {
                                Console.WriteLine("{0}: {1}",((Subjects)(i+1)).ToString(), grades[i]);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Student!");
                        }
                        break;

                    case 5:
                        subjects();
                        Console.WriteLine("Enter the id of the subject you'd like to check:");
                        aux = AskForInteger(true);
                        grades = this.a.SubjectGrades((Subjects)aux);
                        if (grades != null)
                        {
                            Console.WriteLine("{0}'s grades are:", ((Subjects)aux).ToString());
                            for (int i = 0; i < grades.GetLength(0); i++)
                            {
                                Console.WriteLine("{0}:{1}",this.a.Names[i],grades[i]);
                            }
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("Invalid Subjuect!");
                        }
                        break;

                    case 6:
                        students();
                        Console.WriteLine("Enter the position of the student you'd like to check:");
                        id = AskForInteger(false);
                        this.a.MaxMinStudentGrade(id,ref max,ref min);
                        if (grades != null)
                        {
                            Console.WriteLine("{0}'s highest grade is: {1} and his lowest grade is: {2}.",this.a.Names[id],max,min);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student!");
                        }
                        max = 0;
                        min = 99;
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
                        Console.WriteLine("{0,15} {1,2} {2,2} {3,2}",Subjects.Mathematics.ToString(), Subjects.Physics.ToString(), Subjects.Technical_drawing.ToString(), Subjects.Algebra.ToString());
                        for (int i = 0;i < this.a.Names.GetLength(0);i++)
                        {
                            grades = this.a.StudentGrades(i);
                            Console.WriteLine("{0,2}.- {1}| {2,7} {3,11} {4,7} {5,17}",i+1,this.a.Names[i],this.a[i,0],this.a[i,1],this.a[i,2],this.a[i,3]);
                        }
                        Console.WriteLine();
                        break;

                    case 9:
                        Console.WriteLine("See ya!");
                        break;

                    default:
                        Console.WriteLine("Action not recognised");
                        break;
                }
            }
        }

        public int AskForInteger(bool menu)
        {
            bool error = true;
            int res = 0;
            while (error)
            {
                try
                {
                    res = int.Parse(Console.ReadLine());
                    if (menu && res == 0)
                    {
                        throw new OverflowException();
                    }
                    error = false;
                }catch(Exception e) when (e is FormatException || e is OverflowException)
                {
                    Console.WriteLine("Invalid number!");
                    error = true;
                }
            }
            if (!menu)
            {
                res--;
            }
            return res;
        }

        public void students()
        {
            for (int i = 0;i < this.a.Names.GetLength(0);i++)
            {
                Console.WriteLine("{0,2}.- {1}",(i+1),this.a.Names[i]);
            }
        }

        public void subjects()
        {
            for (int i = 1;i < this.a.Grades.GetLength(1)+1;i++)
            {
                Console.WriteLine("{0}.- {1}",(i),((Subjects)(i)).ToString());
            }
        }
    }
}
