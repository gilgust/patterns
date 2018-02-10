using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace process_viewer
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Process myProcess = null;
            while (true)
            {
                Console.Clear();
                ShowMenu();
                var str = Console.ReadLine();
                var paragraph = Convert.ToInt32(str);

                switch (paragraph)
                {
                    case 1:
                        GetListProcess();
                        break;
                    case 2:
                        GetProcessById();
                        break;
                    case 3:
                        myProcess = StartProcess();
                        break;
                    case 4:
                        StartProcess();
                        break;
                    case 5:
                        ShowThreadInfo(myProcess);
                        break;
                    case 6:
                        ShowModuleInfo(myProcess);
                        break;
                    default:
                        break;
                }

                Console.WriteLine(@"Press 'Esc' to exit");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Choose number of paragraph \n");
            Console.WriteLine("1. Get List Process");
            Console.WriteLine("2. Get Process By Id");
            Console.WriteLine("3.Start Process");
            Console.WriteLine("4.Stop Process");
            Console.WriteLine("5.Show Thread Info");
            Console.WriteLine("6.Show Module Info");

        }

        static void GetListProcess()
        {
            var process = Process.GetProcesses(".").Select(proc => proc).OrderBy(proc => proc.Id);
            foreach (var proc in process)
            {
                string info = $@"PID: {proc.Id} Name: {proc.ProcessName}";
                Console.WriteLine(info);
            }
            Console.WriteLine("");
        }

        static void GetProcessById()
        {
            Console.WriteLine("enter the ID:");
            var ProcID = Console.ReadLine();
            int id = Convert.ToInt32(ProcID);

            Process proc = null;
            try
            {
                proc = Process.GetProcessById(id);
            }
            catch (Exception e)
            {
            }

            if (proc == null)
            {
                Console.WriteLine("Process with ID:{0} not exist", id);
            }
            else
            {
                string info = $@"PID: {proc.Id} Name: {proc.ProcessName}";
                Console.WriteLine(info);
            }
        }

        static Process StartProcess()
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.CheckFileExists)
                {
                    Process proc = Process.Start(ofd.FileName);
                    return proc;
                }
            }
            return null;
        }

        static void StopProcess(Process proc)
        {
            if (proc == null)
                return;

            //почему-то закрывает не все процессы
            //proc.CloseMainWindow();
            //proc.Close();

            //работает наверника
            proc.Kill();
            proc = null;
        }

        static void ShowThreadInfo(Process proc)
        {
            if (proc == null)
            {
                Console.WriteLine("There in't open process. \n \t Use method: Open Process ");
                return;
            }
            var threads = proc.Threads;
            foreach (ProcessThread thread in threads)
            {
                var info = $"id:{thread.Id} CurrentPriority:{thread.CurrentPriority}";
                Console.WriteLine(info);
            }
        }

        static void ShowModuleInfo(Process proc)
        {
            if (proc == null)
            {
                Console.WriteLine("There in't open process. \n \t Use method: Open Process ");
                return;
            }
            var modules = proc.Modules;
            foreach (ProcessModule module in modules)
            {
                var info = $"BaseAddress: {module.BaseAddress} FileName: {module.FileName}";
                Console.WriteLine(info);
            }
        }
    }
}
