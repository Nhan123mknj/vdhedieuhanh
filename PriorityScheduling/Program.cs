using System;

class Program
{
    static void Main(string[] args)
    {
        int i, j, n, temp;
        int[] bt = new int[20];
        int[] wt = new int[20];
        int[] tat = new int[20];
        int[] p = new int[20];
        int[] pr = new int[20];
        float avgwt = 0, avgtat = 0;

        Console.Write("So processes: ");
        n = int.Parse(Console.ReadLine());

        for (i = 0; i < n; i++)
        {
            Console.Write("Nhap burst time cho tien trinh {0}: ", i + 1);
            bt[i] = int.Parse(Console.ReadLine());
            Console.Write("Nhap priority cho tien trinh {0}: ", i + 1);
            pr[i] = int.Parse(Console.ReadLine());
            p[i] = i + 1;
        }

        for (i = 0; i < n - 1; i++)
        {
            for (j = i + 1; j < n; j++)
            {
                if (pr[i] > pr[j])
                {
                    temp = pr[i];
                    pr[i] = pr[j];
                    pr[j] = temp;

                    temp = bt[i];
                    bt[i] = bt[j];
                    bt[j] = temp;

                    temp = p[i];
                    p[i] = p[j];
                    p[j] = temp;
                }
            }
        }

        wt[0] = 0;

        for (i = 1; i < n; i++)
        {
            wt[i] = 0;

            for (j = 0; j < i; j++)
            {
                wt[i] += bt[j];
            }

            avgwt += wt[i];
        }

        avgwt /= n;
        avgtat = avgwt;

        Console.WriteLine("\nProcess\tBurst Time\tPriority\tWaiting Time\tTurnaround Time");
        for (i = 0; i < n; i++)
        {
            tat[i] = bt[i] + wt[i];
            avgtat += tat[i];
            Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t\t{4}", p[i], bt[i], pr[i], wt[i], tat[i]);
        }

        avgtat /= n;

        Console.WriteLine("\nThoi gian trung binh: {0}", avgwt);
        Console.WriteLine("Average Turnaround Time: {0}", avgtat);
    }
}