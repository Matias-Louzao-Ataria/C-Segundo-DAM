using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ2
{
    class Aula
    {
        private double[,] grades = new double[12, 4];
        public double[,] Grades
        {
            set
            {
                this.grades = value;
            }

            get
            {
                return grades;
            }
        }

        private string[] names = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };

        public string[] Names
        {
            get
            {
                return this.names;
            }
        }

        private Random r = new Random();

        public double this[int i,int j]
        {
            set
            {
                this.grades[i, j] = value;
            }

            get
            {
                return grades[i, j];
            }
        }

        public Aula()
        {
            for (int i = 0; i < this.Grades.GetLength(0); i++)
            {
                for (int j = 0; j < this.Grades.GetLength(1); j++)
                {
                    int ran = r.Next(0, 100);
                    switch (ran)
                    {
                        case int comp when comp >= 0 && comp <= 4:
                            grades[i, j] = 0;
                            break;
                        case int comp when comp >= 5 && comp <= 9:
                            grades[i, j] = 1;
                            break;
                        case int comp when comp >= 10 && comp <= 14:
                            grades[i, j] = 2;
                            //2
                            break;
                        case int comp when comp >= 15 && comp <= 24:
                            grades[i, j] = 3;
                            //3
                            break;
                        case int comp when comp >= 25 && comp <= 39:
                            grades[i, j] = 4;
                            //4
                            break;
                        case int comp when comp >= 40 && comp <= 54:
                            grades[i, j] = 5;
                            //5
                            break;
                        case int comp when comp >= 55 && comp <= 69:
                            grades[i, j] = 6;
                            //6
                            break;
                        case int comp when comp >= 70 && comp <= 79:
                            grades[i, j] = 7;
                            //7
                            break;
                        case int comp when comp >= 80 && comp <= 89:
                            grades[i, j] = 8;
                            //8
                            break;
                        case int comp when comp >= 90 && comp <= 94:
                            grades[i, j] = 9;
                            //9
                            break;
                        case int comp when comp >= 95 && comp <= 99:
                            grades[i, j] = 10;
                            //10
                            break;
                    }
                }
            }
        }

        public void asign(int student,Subjects subject,int value)
        {
            this[student, (int)subject] = value;
        }
        
        public double median()
        {
            double res = 0;
            for (int i = 0;i < this.Grades.GetLength(0);i++)
            {
                for (int j = 0;j < this.Grades.GetLength(1);j++)
                {
                    res += this[i,j];
                }
            }

            return res / (this.Grades.Length);
        }

        public double MedianStudent(int student)
        {
            double res = 0;
            if (student < this.Grades.GetLength(0) && student >= 0)
            {
                for (int i = 0; i < this.Grades.GetLength(1); i++)
                {
                    res += this[student, i];
                }
            }
            else
            {
                return -1;
            }

            return res / this.Grades.GetLength(1);
        }

        public double MedianSubject(Subjects subject)
        {
            double res = 0;
            Console.WriteLine((int)subject);
            if ((int)subject >= 0 && (int)subject <= 4)
            {
                for (int i = 0; i < this.Grades.GetLength(0); i++)
                {
                    res += this[i, (int)subject-1];
                }
            }
            else
            {
                return -1;
            }

            return res/this.Grades.GetLength(0);
        }

        public double[] StudentGrades(int student)
        {
            double[] grades = new double[4];
            if (student < this.Grades.GetLength(0) && student >=0)
            {
                for (int i = 0;i < this.Grades.GetLength(1);i++)
                {
                    grades[i] = this[student,i];
                }
            }
            else {
                return null;
            }

            return grades;
        }

        public double[] SubjectGrades(Subjects subject)
        {
            double[] res = new double[12];
            if ((int)subject >= 0 && (int)subject <= 4)
            {
                for (int i = 0; i < this.Grades.GetLength(0); i++)
                {
                    res[i] = this[i, (int)subject-1];
                }
            }
            else
            {
                return null;
            }
            return res;
        }

        public double[] MaxMinStudentGrade(int student)
        {
            double[] res = new double[2];
            double max = 0, min = 99;
            if (student >= 0 && student < this.Grades.GetLength(0))
            {
                for (int i = 0;i < this.Grades.GetLength(1);i++)
                {
                    if (this[student,i] > max)
                    {
                        max = this[student,i];
                    }
                    if (this[student,i] < min)
                    {
                        min = this[student,i];
                    }
                }
                res[0] = max;
                res[1] = min;
                return res;
            }
            else {
                return null;
            }
        }

        public string[] PassedStudents()//Devolver estructura única con notas y nombres.
        {
            int cont = 0;
            string aux = "";
            for (int i = 0;i < this.Grades.GetLength(0);i++)
            {
                for (int j = 0;j < this.Grades.GetLength(1);j++)
                {
                    if (this[i,j] >= 5)
                    {
                        cont++;
                    }
                }
                if (cont >= 4)
                {
                    aux += this.names[i]+" ";
                }
                    cont = 0;
            }
            return aux.Split(' ');
        }

    }
}
