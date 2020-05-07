using System;
using System.Threading;

namespace Algorithms.Concurency.Examples
{
    public class SemaphoreExample
    {
        private static Semaphore _pool;
        private static int _padding;

        public SemaphoreExample()
        {
            _pool = new Semaphore(0, 3);

            for (var i = 0; i < 5; i++)
            {
                var thread = new Thread(new ParameterizedThreadStart(Worker));
                    thread.Start(i);
            }
            
            Thread.Sleep(500);
            
            Console.WriteLine("Main thread calls Release(3).");
            _pool.Release(3);
            Console.WriteLine("Main thread exits.");
        }

        private void Worker(object num)
        {
            Console.WriteLine("Thread {0} begins and waits for the semaphore.", num);

            _pool.WaitOne();

            var padding = Interlocked.Add(ref _padding, 100);
            Console.WriteLine("Thread {0} enters the semaphore", num);
            
            Thread.Sleep(1000 + padding);
            
            Console.WriteLine("Thread {0} releases the semaphore.", num);
            Console.WriteLine("Thread {0} previous semaphore count: {1}", num, _pool.Release());
        }
    }
}