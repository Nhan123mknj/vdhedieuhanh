using System;

class Program
{
    static void Main(string[] args)
    {
        int i, j, n, time, remain, flag = 0, ts;
        int sum_wait = 0, sum_turnaround = 0;
        int[] at = new int[10];
        int[] bt = new int[10];
        int[] rt = new int[10];

        Console.Write("Nhap so tien trinh : ");
        n = int.Parse(Console.ReadLine());
        remain = n;

        for (i = 0; i < n; i++)
        {
            Console.Write("Nhap arrival time va burst time cho tien trinh P{0}:", i + 1);
            at[i] = int.Parse(Console.ReadLine());
            bt[i] = int.Parse(Console.ReadLine());
            rt[i] = bt[i];
        }

        Console.Write("Nhap thoi luong: ");
        ts = int.Parse(Console.ReadLine());

        Console.WriteLine("\n\nProcess\t|Turnaround time|Waiting time\n\n");

        for (time = 0, i = 0; remain != 0;)
        {
            if (rt[i] <= ts && rt[i] > 0)
            {
                time += rt[i];
                rt[i] = 0;
                flag = 1;
            }
            else if (rt[i] > 0)
            {
                rt[i] -= ts;
                time += ts;
            }
            if (rt[i] == 0 && flag == 1)
            {
                remain--;
                Console.WriteLine("P[{0}]\t|\t{1}\t|\t{2}", i + 1, time - at[i], time - at[i] - bt[i]);
                sum_wait += time - at[i] - bt[i];
                sum_turnaround += time - at[i];
                flag = 0;
            }
            if (i == n - 1)
            {
                i = 0;
            }
            else if (at[i + 1] <= time)
            {
                i++;
            }
            else
            {
                i = 0;
            }
        }

        Console.WriteLine("\nTrung binh thoi gian doi = {0}", (double)sum_wait / n);
        Console.WriteLine("Avg sum_turnaround = {0}", (double)sum_turnaround / n);
    }
}