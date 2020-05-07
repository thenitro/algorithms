using System;
using System.Threading;

namespace Algorithms.Concurency.Examples
{
    public class TimeoutMutexExample
    {
        private static Mutex _mutex = new Mutex();
        private const int _numIterations = 1;
        private const int _numThreads = 3;

        public TimeoutMutexExample()
        {
            for (int i = 0; i < _numThreads; i++)
            {
                var thread = new Thread(new ThreadStart(ThreadProc));
                    thread.Name = string.Format("Thread{0}", i + 1);
                    thread.Start();
            }
        }

        private static void ThreadProc()
        {
            for (int i = 0; i < _numIterations; i++)
            {
                UseResource();
            }
        }

        private static void UseResource()
        {
            Console.WriteLine("{0} is requesting the mutex", Thread.CurrentThread.Name);

            if (_mutex.WaitOne(1000))
            {
                Console.WriteLine("{0} has enterd the protected area", Thread.CurrentThread.Name);
                
                Thread.Sleep(5000);
                
                Console.WriteLine("{0} is leaving the protected area", Thread.CurrentThread.Name);
                
                _mutex.ReleaseMutex();
                
                Console.WriteLine("{0} has release the mutex", Thread.CurrentThread.Name);
            }
            else
            {
                Console.WriteLine("{0} will not acquire the mutex", Thread.CurrentThread.Name);
            }
        }

        ~TimeoutMutexExample()
        {
            _mutex.Dispose();
        }
    }
}