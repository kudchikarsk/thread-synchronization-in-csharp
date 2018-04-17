using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _05_Monitor_Class_Usage
{
    class Program
    {
        private static int sum;
        private static object _lock = new object();

        static void Main(string[] args)
        {

            //create thread t1 using anonymous method
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 10000000; i++)
                {
                    //acquire lock ownership
                    Monitor.Enter(_lock);

                    //increment sum value
                    sum++;

                    //release lock ownership
                    Monitor.Exit(_lock);
                }
            });

            //create thread t2 using anonymous method
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 10000000; i++)
                {
                    //acquire lock ownership
                    Monitor.Enter(_lock);

                    //increment sum value
                    sum++;

                    //release lock ownership
                    Monitor.Exit(_lock);
                }
            });


            //start thread t1 and t2
            t1.Start();
            t2.Start();

            //wait for thread t1 and t2 to finish their execution
            t1.Join();
            t2.Join();

            //write final sum on screen
            Console.WriteLine("sum: " + sum);

            Console.WriteLine("Press enter to terminate!");
            Console.ReadLine();
        }
    }
}
