using System;
//Shortest remaining time first
namespace SRTF
{
    class Program
    {
        struct Process
        {
            public int pid;
            public int arrival_time;
            public int burst_time;
            public int remaining_time; // remaining time for the process
        }

        static void srtf(Process[] processes, int n)
        {
            int[] waiting_time = new int[n];
            int[] turnaround_time = new int[n];
            int total_waiting_time = 0, total_turnaround_time = 0;
            int time = 0;
            bool[] completed = new bool[n];

            while (true)
            {
                int min_remaining_time = int.MaxValue;
                int shortest_process_index = -1;

                // find the process with the shortest remaining time
                for (int i = 0; i < n; i++)
                {
                    if (processes[i].arrival_time <= time && !completed[i])
                    {
                        if (processes[i].remaining_time < min_remaining_time)
                        {
                            min_remaining_time = processes[i].remaining_time;
                            shortest_process_index = i;
                        }
                    }
                }

                if (shortest_process_index == -1) break; // no processes to execute

                processes[shortest_process_index].remaining_time--;

                if (processes[shortest_process_index].remaining_time == 0)
                {
                    completed[shortest_process_index] = true;

                    // calculate waiting time and turnaround time for the completed process
                    waiting_time[shortest_process_index] = time - processes[shortest_process_index].arrival_time - processes[shortest_process_index].burst_time;
                    if (waiting_time[shortest_process_index] < 0) waiting_time[shortest_process_index] = 0; // no negative waiting time
                    turnaround_time[shortest_process_index] = time - processes[shortest_process_index].arrival_time;

                    // update total waiting time and total turnaround time
                    total_waiting_time += waiting_time[shortest_process_index];
                    total_turnaround_time += turnaround_time[shortest_process_index];
                }

                time++;
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
                processes[i].remaining_time = processes[i].burst_time;
            }

            srtf(processes, n);

            Console.ReadKey();
        }
    }
}


