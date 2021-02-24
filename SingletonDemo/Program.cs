using System;
using System.Threading.Tasks;

namespace SingletonDemo
{
    public sealed class Singleton
    {
        public static int counter = 0;
        private static readonly object obj = new object();
        private static Singleton instance = null;
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null )              // this is known as double check locking so that we can avoid unnecessasry checking of locks
                {
                    lock (obj)
                    {
                        if (instance == null)                // lazy initialiZation
                            instance = new Singleton();
                    }
                }
                return instance;
                
            }
        }
        private Singleton()
        {
            counter++;
            Console.WriteLine(counter);
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Parallel.Invoke(
           ()=> PrintStudentDetails(), ()=> PrintEmployeeDetails());

        }

        private static void PrintEmployeeDetails()
        {
            Singleton p = Singleton.GetInstance;
            p.PrintDetails("hi");
        }

        private static void PrintStudentDetails()
        {
            Singleton s = Singleton.GetInstance;
            s.PrintDetails("hello");
        }
    }
}
