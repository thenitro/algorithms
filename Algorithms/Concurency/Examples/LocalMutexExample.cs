using System;
using System.Threading;

namespace Algorithms.Concurency.Examples
{
    public class LocalMutexExample
    {
        private static Mutex _mutex = new Mutex();
        private const int _numIterations = 1;
        private const int _numThreads = 3;

        public LocalMutexExample()
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
            
            _mutex.WaitOne();
            
            Console.WriteLine("{0} has entered the protected area", Thread.CurrentThread.Name);
            
            Thread.Sleep(500);
            
            Console.WriteLine("{0} is leaving the protected area", Thread.CurrentThread.Name);
            
            _mutex.ReleaseMutex();
            Console.WriteLine("{0} has released the mutex", Thread.CurrentThread.Name);
        }
    }
}