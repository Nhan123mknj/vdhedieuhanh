using System;
//First Come First Serve
namespace FCFS
{
    class Program
    {
        struct Process
        {
            public int pid;
            public int arrival_time;
            public int burst_time;
        }

        static void fcfs(Process[] processes, int n)
        {
            int[] waiting_time = new int[n];
            int[] turnaround_time = new int[n];
            int total_waiting_time = 0, total_turnaround_time = 0;
            waiting_time[0] = 0; // first process has 0 waiting time

            // calculate waiting time for each process
            for (int i = 1; i < n; i++)
            {
                waiting_time[i] = waiting_time[i - 1] + processes[i - 1].burst_time - processes[i].arrival_time;
                if (waiting_time[i] < 0) waiting_time[i] = 0; // no negative waiting time
            }

            // calculate turnaround time for each process
            for (int i = 0; i < n; i++)
            {
                turnaround_time[i] = waiting_time[i] + processes[i].burst_time;
            }

            // calculate total waiting time and total turnaround time
            for (int i = 0; i < n; i++)
            {
                total_waiting_time += waiting_time[i];
                total_turnaround_time += turnaround_time[i];
            }

            // print results
            Console.WriteLine("Process\tArrival Time\tBurst Time\tWaiting Time\tTurnaround Time");
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(processes[i].pid + "\t" + processes[i].arrival_time + "\t\t" + processes[i].burst_time + "\t\t" + waiting_time[i] + "\t\t" + turnaround_time[i]);
            }
            Console.WriteLine("Average Waiting Time: " + (float)total_waiting_time / n);
            Console.WriteLine("Average Turnaround Time: " + (float)total_turnaround_time / n);
        }

        static void Main(string[] args)
        {
            Console.Write("Enter number of processes: ");
            int n = int.Parse(Console.ReadLine());

            Process[] processes = new Process[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter arrival time and burst time for process " + (i + 1) + ": ");
                string[] input = Console.ReadLine().Split();
                processes[i].arrival_time = int.Parse(input[0]);
                processes[i].burst_time = int.Parse(input[1]);
                processes[i].pid = i + 1;
            }

            fcfs(processes, n);

            Console.ReadKey();
        }
    }
}