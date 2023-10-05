using System;
//Shortes Job First
namespace SJF
{
    class Program
    {
        struct Process
        {
            public int pid;
            public int arrival_time;
            public int burst_time;
        }

        static void sjf(Process[] processes, int n)
        {
            int[] waiting_time = new int[n];
            int[] turnaround_time = new int[n];
            bool[] completed = new bool[n];
            int total_waiting_time = 0, total_turnaround_time = 0, current_time = 0;
            int shortest_job_index, shortest_job_burst_time;

            // mark all processes as incomplete
            for (int i = 0; i < n; i++)
            {
                completed[i] = false;
            }

            // calculate waiting time and turnaround time for each process
            while (true)
            {
                shortest_job_burst_time = int.MaxValue;
                shortest_job_index = n;

                // find the shortest remaining time job at current time
                for (int i = 0; i < n; i++)
                {
                    if (processes[i].arrival_time <= current_time && completed[i] == false && processes[i].burst_time < shortest_job_burst_time)
                    {
                        shortest_job_burst_time = processes[i].burst_time;
                        shortest_job_index = i;
                    }
                }

                // if no job found, exit the loop
                if (shortest_job_index == n) break;

                // mark the job as completed
                completed[shortest_job_index] = true;

                // calculate waiting time and turnaround time for the completed job
                waiting_time[shortest_job_index] = current_time - processes[shortest_job_index].arrival_time;
                turnaround_time[shortest_job_index] = waiting_time[shortest_job_index] + processes[shortest_job_index].burst_time;

                // update the current time and total waiting/turnaround time
                current_time += processes[shortest_job_index].burst_time;
                total_waiting_time += waiting_time[shortest_job_index];
                total_turnaround_time += turnaround_time[shortest_job_index];
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

            sjf(processes, n);

            Console.ReadKey();
        }
    }
}
