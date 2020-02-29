using System;

namespace Algorithms.DynamicProgramming
{
    public class BooleanParenthesizationProblem
    {
        public BooleanParenthesizationProblem()
        {
            Console.WriteLine(4 == Solution(new []{ 'T', 'T', 'F', 'T' }, new []{ '|', '&', '^' }));
        }

        private int Solution(char[] symbols, char[] operations)
        {
            var N = symbols.Length;

            var F = new int[N, N];
            var T = new int[N, N];

            for (var i = 0; i < N; i++)
            {
                F[i, i] = symbols[i] == 'F' ? 1 : 0;
                T[i, i] = symbols[i] == 'T' ? 1 : 0;
            }

            for (var gap = 1; gap < N; gap++)
            {
                for (int i = 0, j = gap; j < N; j++, i++)
                {
                    T[i, j] = F[i, j] = 0;

                    for (var g = 0; g < gap; g++)
                    {
                        var k = i + g;

                        var tik = T[i, k] + F[i, k];
                        var tkj = T[k + 1, j] + F[k + 1, j];

                        if (operations[k] == '&')
                        {
                            T[i, j] += T[i, k] * T[k + 1, j];
                            F[i, j] += tik * tkj - T[i, k] * T[k + 1, j];
                        }

                        if (operations[k] == '|')
                        {
                            F[i, j] += F[i, k] * F[k + 1, j];
                            T[i, j] += tik * tkj - F[i, k] * F[k + 1, j];
                        }

                        if (operations[k] == '^')
                        {
                            T[i, j] += F[i, k] * T[k + 1, j] + T[i, k] * F[k + 1, j];
                            F[i, j] += T[i, k] * T[k + 1, j] + F[i, k] * F[k + 1, j];
                        }
                    }
                }
            }

            return T[0, N - 1];
        }
    }
}