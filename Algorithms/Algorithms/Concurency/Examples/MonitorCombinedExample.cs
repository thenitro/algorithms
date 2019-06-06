using System;
using System.Threading;

namespace Algorithms.Concurency.Examples
{
    public class MonitorCombinedExample
    {
        private int _numOps;
        private AutoResetEvent _opsAreDone = new AutoResetEvent(false);
        private SyncResource _syncResource = new SyncResource();
        private UnSyncResource _unSyncResource = new UnSyncResource();

        public MonitorCombinedExample()
        {
            _numOps = 5;

            for (var ctr = 0; ctr <= 4; ctr++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(SyncUpdateResource));
            }

            _opsAreDone.WaitOne();
            Console.WriteLine("\t\nAll synchronized operations have completed.\n");

            _numOps = 5;

            for (var ctr = 0; ctr <= 4; ctr++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(UnSyncUpdateResource));
            }

            _opsAreDone.WaitOne();
            Console.WriteLine("\t\nAll unsynchronized thread operations have completed.\n");
        }

        private void SyncUpdateResource(Object state)
        {
            _syncResource.Access();

            if (Interlocked.Decrement(ref _numOps) == 0)
            {
                _opsAreDone.Set();
            }
        }
        
        private void UnSyncUpdateResource(Object state)
        {
            _unSyncResource.Access();

            if (Interlocked.Decrement(ref _numOps) == 0)
            {
                _opsAreDone.Set();
            }
        }
    }

    internal class SyncResource
    {
        public void Access()
        {
            lock (this)
            {
                Console.WriteLine("Starting synchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);

                if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                {
                    Thread.Sleep(2000);
                }
                
                Thread.Sleep(200);
                Console.WriteLine("Stopping synchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
    
    internal class UnSyncResource
    {
        public void Access()
        {
            lock (this)
            {
                Console.WriteLine("Starting unsynchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);

                if (Thread.CurrentThread.ManagedThreadId % 2 == 0)
                {
                    Thread.Sleep(2000);
                }
                
                Thread.Sleep(200);
                Console.WriteLine("Stopping unsynchronized resource access on thread #{0}", Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}