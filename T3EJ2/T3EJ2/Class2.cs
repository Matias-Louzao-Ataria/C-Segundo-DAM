using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3EJ2
{
    class Alumno
    {
        private double[,] notas = new double[4, 1];//4 asignaturas y cada asignatura tiene una nota.
        private Random r = new Random();
        public double[,] Notas{
            get;    
        }
        public Alumno(int nombres){
            for (int i = 0; i < nombres; i++)
            {
                for (int j = 0; j < notas.Length; j++)
                {
                    int ran = r.Next(0, 100);
                    switch (ran)
                    {
                        case int comp when comp >= 0 && comp <= 4:
                            notas[j, 0] = 0;
                            break;
                        case int comp when comp >= 5 && comp <= 9:
                            notas[j, 0] = 1;
                            break;
                        case int comp when comp >= 10 && comp <= 14:
                            notas[j, 0] = 2;
                            //2
                            break;
                        case int comp when comp >= 15 && comp <= 24:
                            notas[j, 0] = 3;
                            //3
                            break;
                        case int comp when comp >= 25 && comp <= 39:
                            notas[j, 0] = 4;
                            //4
                            break;
                        case int comp when comp >= 40 && comp <= 54:
                            notas[j, 0] = 5;
                            //5
                            break;
                        case int comp when comp >= 55 && comp <= 69:
                            notas[j, 0] = 6;
                            //6
                            break;
                        case int comp when comp >= 70 && comp <= 79:
                            notas[j, 0] = 7;
                            //7
                            break;
                        case int comp when comp >= 80 && comp <= 89:
                            notas[j, 0] = 8;
                            //8
                            break;
                        case int comp when comp >= 90 && comp <= 94:
                            notas[j, 0] = 9;
                            //9
                            break;
                        case int comp when comp >= 95 && comp <= 99:
                            notas[j, 0] = 10;
                            //10
                            break;
                    }
                    Console.WriteLine(notas[j, 0]);
                }
            }
        }
    }
}
