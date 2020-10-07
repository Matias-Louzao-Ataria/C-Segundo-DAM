using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJ4
{
    class Program
    {
        static void Main(string[] args)
        {
            Juegos j = new Juegos();
            int select = 0;
            Boolean stop = true;
            while (select != 5)
            {
                Console.WriteLine("1.- Jugar al juego 1.\n2.- Jugar al juego 2.\n3.- Jugar al juego 3.\n4.- Jugar todos los juegos.\n5.- Salir.");
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1://Ponerle parametro a este.
                        Console.WriteLine("Quieres especificar x?");
                        String select2 = Console.ReadLine();
                        if (select2.Contains("si"))
                        {
                            try
                            {
                                j.juego1(int.Parse(Console.ReadLine()));
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else if(select2.Contains("no"))
                        {
                            j.juego1();
                        }
                        if (stop)
                        {
                            break;
                        }
                        else
                        {
                            goto case 2;
                        }
                    case 2:
                        j.juego2();
                        if (stop)
                        {
                            break;
                        }
                        else
                        {
                            goto case 3;
                        }
                    case 3:
                        j.juego3();
                            break;
                    case 4:
                        stop = false;
                        goto case 1;
                    case 5:
                        Console.WriteLine("Chao!");
                        break;
                    default:
                        Console.WriteLine("Opción no valida");
                        break;
                }
            }
        }
    }

    class Juegos
    {
        public void juego1(int x = 6)
        {
            int num = 0,count = 0,generated = 0;
            Console.WriteLine("Introduce un número del 1 al {0}",x);
            try {
                num = int.Parse(Console.ReadLine());
                Random r = new Random();
                Console.WriteLine("El número introducido es: {0}",num);
                for (int i = 0; i < 10;i++)
                {
                    generated = r.Next(1, x + 1);
                    Console.WriteLine("El resultado del dado nº {0} es {1}",i+1,generated);
                    if (num == generated)
                    {
                        count++;
                    }
                }
                Console.WriteLine("Se han acertado {0} veces",count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void juego2()
        {
            int num = 0, count = 5,generated = 0;
            try
            {
                Random r = new Random();
                generated = r.Next(1,101);
                for (int i = 0; i < count && num != generated; i++)
                {
                    Console.WriteLine("Introduce un número del 1 al 100 para intentar adivinar el número:");
                    try { 
                        num = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.WriteLine("El número introducido es: {0}", num);
                    if (num > generated)
                    {
                        Console.WriteLine("El número introducido es mayor que el número a adivinar.");
                    }
                    else if(num == generated)
                    {
                        Console.WriteLine("Has adivinado el número!");
                    }
                    else
                    {
                        Console.WriteLine("El número introducido es menor que el número a adivinar.");
                    }
                    Console.WriteLine("Quedan {0} intentos!",count-(i+1));    
                }
                if (num != generated) {
                    Console.WriteLine("Has perdido!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void juego3()
        {
            char select = 'a';
            char[] selects = new char[14];
            char[] machine = new char[14];
            for (int i = 0;i < 14;i++)
            {
                Console.WriteLine("Partido {0}",i+1);
                Console.WriteLine("Introduce un 1, una x o un 2 para jugar a la quiniela:");
                try
                {
                    select =char.Parse(Console.ReadLine());
                    select = char.ToLower(select);
                    if (select != '1' && select != '2' && select != 'x')
                    {
                        Console.WriteLine("Introduce un 1, un 2 o una x!");
                        i--;
                    }
                    else
                    {
                        machine[i] = generar();
                        Console.WriteLine("El dato introducido es: {0}", select);
                        Console.WriteLine(select == machine[i] ? "Acertaste" : "No acertaste");
                        selects[i] = select;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("|                PARTIDOS                    |");
            Console.WriteLine("----------------------------------------------");
            for (int i = 0;i < 14 ;i++)
            {
                Console.WriteLine("|Parido:{0,2}| Maquina:{1}                Jugador{2}|",i+1,machine[i],selects[i]);
            }
            Console.WriteLine("----------------------------------------------");

        }

        public char generar()
        {
            Random r = new Random();
            int generated = r.Next(1,101);
            switch (generated)
            {
                case int i when i > 0 && i <= 60:
                    return '1';
                case int i when i > 60 && i <= 85:
                    return 'x';
                case int i when i > 85 && i <= 100:
                    return '2';
            }
            return 'a';
        }
    }
}
