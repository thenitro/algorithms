using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Algorithms.Concurency.Examples
{
    public class MonitorsSyncExample
    {
        public MonitorsSyncExample()
        {
            var tasks = new List<Task>();
            var rnd = new Random();
            var n = 0;
            
            long total = 0;

            for (var taskCtr = 0; taskCtr < 10; taskCtr++)
            {
                tasks.Add(
                    Task.Run(() =>
                    {
                        var values = new int[10000];
                        var taskTotal = 0;
                        var taskN = 0;
                        var ctr = 0;
                        
                        Monitor.Enter(rnd);

                        for (ctr = 0; ctr < 10000; ctr++)
                        {
                            values[ctr] = rnd.Next(0, 1001);
                        }
                        
                        Monitor.Exit(rnd);

                        taskN = ctr;

                        foreach (var value in values)
                        {
                            taskTotal += value;
                        }
                        
                        Console.WriteLine("Mean for task {0,2}: {1:N2} (N={2:N0})", Task.CurrentId, (taskTotal * 1.0) / taskN, taskN);
                        Interlocked.Add(ref n, taskN);
                        Interlocked.Add(ref total, taskTotal);
                    }));
            }

            try
            {
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("\nMean for all tasks {0:N2} (N={1:N0})", (total * 1.0) / n, n);
            }
            catch (AggregateException e)
            {
                foreach (var innerException in e.InnerExceptions)
                {
                    Console.WriteLine("{0}: {1}", innerException.GetType().Name, innerException.Message);
                }
            }
        }
    }
}