using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ServicesT1EJ2_Mejorado_
{
    /*Se desea realizar una versión del taskmanager. El programa planteará un formulario con una textbox
(pon propiedad multiline a true) donde mostrará información , otra textbox sencilla y los siguientes
botones:
• View Processes: Mostrará todos los procesos en ejecución con la siguiente información:
PID ,Nombre y titulo de la ventana principal si lo tiene. Aparecerá en columnas bien alineado.
Al dar formato, si un nombre o título de ventana ocupa más que lo permitido debe
“acortarse” y aparecer con puntos suspensivos. Por ejemplo:
Microsoft.ServiceHub.Controller que aparezca como Microsofts.S... si el nombre lo
tienes limitado a 15 caracteres.
• Process info: En la segunda textbox se puede meter un PID del proceso y se mostrará toda la
información posible (que se haya explicado) sobre el proceso incluyendo subprocesos (su id y
hora de comienzo) y módulos (nombre del módulo y nombre del archivo).
• Close process: Se introduce el PID en el textbox y hace una petición de cierre al programa.
• Kill process: Se introduce el PID y se fuerza el cierre del proceso.
• Run App: A partir de su nombre o path y nombre en el textbox se ejecuta la aplicación
indicada.
(Opcional)
• Setup: Establece la configuración de lo que se puede ver de los procesos en la opción de
visualización, a saber: PID, nombre, prioridad, título del formulario principal, no de hilos,

11

RAMA: Computing CICLO: MAP
MÓDULO Service and processes programming CURSO: 2o
PROTOCOLO: Reading AVAL: DATA:
Autor Francisco Bellas Aláez (Curro)

tiempo total de uso del procesador en segundos, memoria física y memoria virtual usada por
el proceso.
• En el ejercicio anterior usa un componente ListView con varias columnas (una para cada
elemento de información) en lugar del TextBox y usa un Timer para que en el caso de tener
alguna opción de información seleccionada que la actualice cada medio segundo.
• En el ejercicio anterior los métodos de cierre de aplicación, matar proceso y ejecutar
aplicación son muy similares: sacas un formulario de diálogo y si el usuario pulsa el botón
aceptar como respuesta de diálogo ejecutas el código correspondiente. Reorganiza el código
de la siguiente forma:
◦ Realiza un delegado con los parámetros que creas convenientes a partir de la tarea
realizada en el OK de los tres métodos.
◦ Crea una función que cumpla la signatura del delegado y que cierre el proceso, otra que
“mate” el proceso y otra que ejecute una aplicación.
◦ Finalmente sólo existirá un método relacionado con los clicks de los tres botones
anteriores en el cual dependiendo del sender seleccionará la función a ejecutar en el
delegado y finalmente ejecutará el delegado en caso de pulsar OK en el formulario de
diálogo.*/
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
