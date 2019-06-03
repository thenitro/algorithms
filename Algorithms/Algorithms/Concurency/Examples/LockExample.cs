using System;
using System.Threading.Tasks;

namespace Algorithms.Concurency.Examples
{
    public class LockExample
    {
        public LockExample()
        {
            var account = new Account(1000);
            var tasks = new Task[100];
            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i] = Task.Run(() => RandomlyUpdate(account));
            }

            Task.WaitAll(tasks);
        }

        static void RandomlyUpdate(Account account)
        {
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                var amount = rnd.Next(1, 100);
                var doCredit = rnd.NextDouble() < 0.5;
                if (doCredit)
                {
                    account.Credit(amount);
                }
                else
                {
                    account.Debit(amount);
                }
            }
        }
    }
}

public class Account
{
    private readonly object _balanceLock = new object();
    private decimal _balance;

    public Account(decimal initialBalance)
    {
        _balance = initialBalance;
    }

    public decimal Debit(decimal amount)
    {
        lock (_balanceLock)
        {
            if (_balance >= amount)
            {
                Console.WriteLine($"Balance before debit :{_balance, 5}");
                Console.WriteLine($"Amount to remove     :{amount, 5}");
                _balance = _balance - amount;
                Console.WriteLine($"Balance after debit  :{_balance, 5}");
                return amount;
            }
            else
            {
                return 0;
            }
        }
    }

    public void Credit(decimal amount)
    {
        lock (_balanceLock)
        {
            Console.WriteLine($"Balance before credit:{_balance, 5}");
            Console.WriteLine($"Amount to add        :{amount, 5}");
            _balance = _balance + amount;
            Console.WriteLine($"Balance after credit :{_balance, 5}");
        }
    }
}