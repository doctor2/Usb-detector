using System;
using System.Threading;
using System.Windows;


namespace Employees
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //System.Threading.Mutex mut;
       
        ////Запуск одной копии приложения
        //protected override void OnStartup(StartupEventArgs e)
        //{

        //    try
        //    {
        //        // if(mutex.WaitOne(TimeSpan.Zero, true)) {

        //        //AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Directory.GetCurrentDirectory());
        //        //ItemContext context = new ItemContext();
        //        //Database.SetInitializer<ItemContext>(new MyInitializer());
        //        //context.Database.Initialize(false);
        //        bool createdNew;
        //        string mutName = "Chek-UsbConnection"; //406ea660-64cf-4c82-b6f0-42d48172a799
        //        mut = new System.Threading.Mutex(true, mutName, out createdNew);
        //        if (!createdNew)
        //        {                  
        //            MessageBox.Show("Приложение уже запущено");
        //             //this.Close();
        //            Shutdown();
        //        }
        //        else
        //        {
        //            base.OnStartup(e);
        //        }              
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Ошибка: " + ex.ToString()); //, MessageBoxButton.OKCancel) == MessageBoxResult.OK
        //    }
        //}
    }
}