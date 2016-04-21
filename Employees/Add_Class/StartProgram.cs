using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Employees.Add_Class
{
    class StartProgram
    {
        static Mutex mutex = new Mutex(true, "{406ea660-64cf-4c82-b6f0-42d48172a799}");
        [STAThread]
        public static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                Employees.App app = new Employees.App();
                app.InitializeComponent();
                app.Run();
                mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Приложение уже запущено");
            }
        }
    }
}
