using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ2
{
    class Aula
    {
        private double[,] notas = new double[12, 4];
        public double[,] Notas
        {
            set
            {
                this.notas = value;
            }

            get
            {
                return notas;
            }
        }

        private string[] names = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L" };

        public string[] Nombres
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
                this.notas[i, j] = value;
            }

            get
            {
                return notas[i, j];
            }
        }

        public Aula()
        {
            for (int i = 0; i < this.Notas.GetLength(0); i++)
            {
                for (int j = 0; j < this.Notas.GetLength(1); j++)
                {
                    int ran = r.Next(0, 100);
                    switch (ran)
                    {
                        case int comp when comp >= 0 && comp <= 4:
                            notas[i, j] = 0;
                            break;
                        case int comp when comp >= 5 && comp <= 9:
                            notas[i, j] = 1;
                            break;
                        case int comp when comp >= 10 && comp <= 14:
                            notas[i, j] = 2;
                            //2
                            break;
                        case int comp when comp >= 15 && comp <= 24:
                            notas[i, j] = 3;
                            //3
                            break;
                        case int comp when comp >= 25 && comp <= 39:
                            notas[i, j] = 4;
                            //4
                            break;
                        case int comp when comp >= 40 && comp <= 54:
                            notas[i, j] = 5;
                            //5
                            break;
                        case int comp when comp >= 55 && comp <= 69:
                            notas[i, j] = 6;
                            //6
                            break;
                        case int comp when comp >= 70 && comp <= 79:
                            notas[i, j] = 7;
                            //7
                            break;
                        case int comp when comp >= 80 && comp <= 89:
                            notas[i, j] = 8;
                            //8
                            break;
                        case int comp when comp >= 90 && comp <= 94:
                            notas[i, j] = 9;
                            //9
                            break;
                        case int comp when comp >= 95 && comp <= 99:
                            notas[i, j] = 10;
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
        
        public double media()
        {
            double res = 0;
            for (int i = 0;i < this.Notas.GetLength(0);i++)
            {
                for (int j = 0;j < this.Notas.GetLength(1);j++)
                {
                    res += this[i,j];
                }
            }

            return res / (this.Notas.GetLength(0) * this.Notas.GetLength(1));
        }

        public double MediaAlumno(int student)
        {
            double res = 0;
            if (student < this.Notas.GetLength(1) && student >= 0)
            {
                for (int i = 0; i < this.Notas.GetLength(1); i++)
                {
                    res += this[student, i];
                }
            }
            else
            {
                return -1;
            }

            return res / this.Notas.GetLength(1);
        }

        public double MediaAsignatura(Subjects subject)
        {
            double res = 0;
            for (int i = 0; i < (int)subject; i++)
            {
                res += this[i, (int)subject];
            }

            return 0;
        }

        public double[] StudentGrades(int student)
        {
            double[] grades = new double[4];
            if (student < this.Notas.GetLength(0) && student >=0)
            {
                for (int i = 0;i < this.Notas.GetLength(1);i++)
                {
                    grades[i] = this[student,i];
                }
            }
            else {
                return new double[4];
            }

            return grades;
        }

        public double[] SubjectGrades(Subjects subject)
        {
            double[] res = new double[12];
            for (int i = 0;i < this.Notas.GetLength(0);i++)
            {
                res[i] = this[i,(int)subject];
            }
            return res;
        }

        public double[] MaxMinStudentGrade(int student)
        {
            double[] res = new double[2];
            double max = 0, min = 0;
            if (student >= 0 && student < this.Notas.GetLength(0))
            {
                for (int i = 0;i < this.Notas.GetLength(1);i++)
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
                return new double[2];
            }
        }

        public string[] PassedStudents()
        {
            int cont = 0;
            string aux = "";
            for (int i = 0;i < this.Notas.GetLength(0);i++)
            {
                for (int j = 0;j < this.Notas.GetLength(1);j++)
                {
                    if (this.Notas[i,j] >= 5)
                    {
                        cont++;
                    }
                }
                if (cont == 4)
                {
                    cont = 0;
                    aux += this.names[i]+"?";
                }
            }
            return aux.Split('?');
        }

    }
}
