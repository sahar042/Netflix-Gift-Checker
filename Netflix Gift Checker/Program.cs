using System.Threading;

namespace Netflix_Gift_Checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Worker threadwork = new Worker();
            Thread thread1 = new Thread(new ThreadStart(threadwork.worker1));
            //Thread thread2 = new Thread(new ThreadStart(threadwork.worker2));
            thread1.Start();
            //thread2.Start();
        }
    }
}
