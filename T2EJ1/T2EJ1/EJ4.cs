using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2EJ1
{
    class EJ4
    {
        private Directivo boss;
        private Empleado minion;
        private EmpleadoEspecial eliteMinion;
        

        public EJ4()
        {
            boss = new Directivo("AAAA", "BBBBB", 45, "CCCCCC", "DDDDDDDD", 10);
            minion = new Empleado("EEEEEE", "FFFFFFFFFFFF", 35, "GGGGGG", 3500, "111111111");
            eliteMinion = new EmpleadoEspecial("HHHHHH", "IIIIIIII", 32, "JJJJJJJJJJJ", 4500, "222222222");
        }

        public void Menu(int select)
        {
            /* 1.- Visualizar los datos del Directivo
             * 2.- Visualizar datos Empleado
             * 3.- Visualizar datos EmpleadoEspecial.*/
            switch (select)
            {
             case 1:
                    boss.ShowData();
                    Directivo.ShowIncome(this.boss,this.boss.Benefits);
                    break;

             case 2:
                    minion.ShowData();
                    EmpleadoEspecial.ShowIncome(this.eliteMinion,0.5);
                    break;

             case 3:
                    eliteMinion.ShowData();
                    break;
            }
            Console.ReadLine();
        }
    }
}
