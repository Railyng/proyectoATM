using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM
{
    class Program
    {
        static int Saldo = 1000;
        static object lockObject = new object();
        static void Main(string[] args)
        {



            Thread Hilo1 = new Thread(RealizarRetiro);
            Hilo1.Start();

            Thread Hilo2 = new Thread(RealizarRetiro);
            Hilo2.Start();


            Thread.Sleep(1000);


            Console.ReadKey();
        }

        static void RealizarRetiro()
        {
            for (int i = 0; i <= 10; i++)
            {
                // Generador de números aleatorios para simular el monto del retiro
                Random random = new Random();
                // Monto aleatorio entre 10 y 100
                int retiro = random.Next(10, 100);
                lock (lockObject)
                {
                    // Verificar si hay suficiente saldo para realizar el retiro
                    if (Saldo >= retiro)
                    {
                        Console.WriteLine($"\n{Thread.CurrentThread.ManagedThreadId} intenta retirar {retiro}");
                        Saldo -= retiro;//resta el valor de retiro al saldo actual

                        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} retiró {retiro:C}. Saldo restante: {Saldo}");

                    }
                    else
                    {
                        Console.WriteLine($"\nFondos insuficientes para {Thread.CurrentThread.ManagedThreadId}. Saldo actual: {Saldo}");
                    }
                }
            }
        }
    }
}