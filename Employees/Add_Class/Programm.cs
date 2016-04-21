using Dolinay;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Windows;

namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //  private ItemContext db = new ItemContext();
        // private ItemContext db;
        readonly DateTime dateOpen = DateTime.Now;
        const string baseName = @"CompanyWorkers.db"; //C:\
        private DriveDetector driveDetector = null;
        Dictionary<int, List<string>> plugDevice = new Dictionary<int, List<string>>();
        List<string> inDevice = new List<string>(); // в словаре со списком искать сложно
        List<DataDevice> allDevice = new List<DataDevice>();
        bool histOpened = false;
        private void CreateDateBase()
        {
            try
            {
                if (!File.Exists(baseName))
                {
                    SQLiteConnection.CreateFile(baseName);
                    using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + baseName))
                    {
                        connection.Open();
                        SQLiteCommand command = new SQLiteCommand(
                                             @"CREATE TABLE [DataDevice] (     
                                                                    [Date]      NVARCHAR (250) NOT NULL,                                                                                                                 
                                                                    [Plug]      NVARCHAR (250) NULL,
                                                                    [Model]     NVARCHAR (250) NULL,
                                                                    [Serial]    NVARCHAR (250) NULL,
                                                                    [MediaType] NVARCHAR (250) NULL,
                                                                    [Interface] NVARCHAR (250) NULL,
                                                                    [Capacity]  NVARCHAR (250) NULL
                                                                                                                        
                                                                );", connection);
                        //                    command.CommandText = @"CREATE TABLE [dbo].[DataDevice] (
                        //                                                                    [Date]      DATETIME       NOT NULL,
                        //                                                                    [Plug]      NVARCHAR (250) NULL,
                        //                                                                    [Model]     NVARCHAR (250) NULL,
                        //                                                                    [Serial]    NVARCHAR (250) NULL,
                        //                                                                    [MediaType] NVARCHAR (250) NULL,
                        //                                                                    [Interface] NVARCHAR (250) NULL,
                        //                                                                    [Capacity]  NVARCHAR (250) NULL,
                        //                                                                    CONSTRAINT [PK_dbo.DataDevice] PRIMARY KEY CLUSTERED ([Date] ASC)
                        //                                                                );";
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString()); //, MessageBoxButton.OKCancel) == MessageBoxResult.OK
            }
        }

        public MainWindow()
        {
          //  dateOpen = DateTime.Now;
            CreateDateBase();
            InitializeComponent();
            driveDetector = new DriveDetector();
            driveDetector.DeviceArrived += new DriveDetectorEventHandler(OnDriveArrived);
            driveDetector.DeviceRemoved += new DriveDetectorEventHandler(OnDriveRemoved);
            //this.Table.ItemsSource = allDevice;
        }
        private void Load(object sender, RoutedEventArgs e)
        {
                Thread deviceIncluded = new Thread(GetDev);
                deviceIncluded.Start();
        }
        private void GetDev()
        {

            ManagementObjectSearcher mosDisks;// = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE NOT MediaType = 'Fixed hard disk media' AND NOT Model='Multiple Card Reader'"); // AND MediaType = 'Fixed hard disk media'   WHERE  Model = '" + lastDevice + "'")
            List<string> deviceBeforStart = new List<string>();
            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                inDevice.Add(moDisk["SerialNumber"].ToString());
                deviceBeforStart.Add("Устройство подключено ");
                deviceBeforStart.Add(moDisk["Model"].ToString());
                deviceBeforStart.Add(moDisk["SerialNumber"].ToString());
                deviceBeforStart.Add(moDisk["MediaType"].ToString());
                deviceBeforStart.Add(moDisk["InterfaceType"].ToString());
                deviceBeforStart.Add(Math.Round(((((double)Convert.ToDouble(moDisk["Size"]) / 1024) / 1024) / 1024), 2) + " GB");
                // device.Add(string.Format("{0:yy/MM/dd H:mm:ss}", DateTime.Now));
                plugDevice.Add((plugDevice.Count() == 0) ? 0 : plugDevice.Keys.Max() + 1,
                    deviceBeforStart);
            }
        }
        private void GetDeviceInclude()
        {
            ManagementObjectSearcher mosDisks;
            mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE NOT MediaType = 'Fixed hard disk media' AND NOT Model='Multiple Card Reader'"); // AND MediaType = 'Fixed hard disk media'   WHERE  Model = '" + lastDevice + "'")
            List<string> device = new List<string>();
            foreach (ManagementObject moDisk in mosDisks.Get())
            {
                if (!inDevice.Contains(moDisk["SerialNumber"].ToString()))
                {
                    inDevice.Add(moDisk["SerialNumber"].ToString());
                    allDevice.Add(new DataDevice
                                    {
                                        Plug = "Подключено",
                                        Model = moDisk["Model"].ToString(),
                                        Serial = moDisk["SerialNumber"].ToString(),
                                        MediaType = moDisk["MediaType"].ToString(),
                                        Interface = moDisk["InterfaceType"].ToString(),
                                        Capacity = Math.Round(((((double)Convert.ToDouble(moDisk["Size"]) / 1024) / 1024) / 1024), 2) + " GB",
                                        Date = DateTime.Now //string.Format("{0:yy/MM/dd   H:mm:ss}", DateTime.Now) 
                                    }
                            );
                    AddLineToDatabase();
                    var last = allDevice.Last();
                    var type = last.GetType();
                    string stringtype = " ";
                    foreach (var prop in type.GetProperties()) // рефлексия - сериализация последнего объекта из класса
                    {
                        var properti = prop.GetValue(last);
                        if (properti.GetType() == stringtype.GetType())
                            device.Add((string)properti); //(string)prop.GetValue(last)
                    }
                    // добавляем утройство в список подключенных
                    plugDevice.Add((plugDevice.Count() == 0) ? 0 : plugDevice.Keys.Max() + 1,
                        device);
                }
            }
        }
        // Called by DriveDetector when removable device in inserted 
        private void OnDriveArrived(object sender, DriveDetectorEventArgs e)
        {
            // Report the event in the listbox.
            // e.Drive is the drive letter for the device which just arrived, e.g. "E:\\"
            Thread ab = new Thread(GetDeviceInclude);
            ab.Start();
            ab.Join();
            this.Table1.Items.Add (allDevice.Last());
            this.Table1.Items.Refresh(); 
            //this.Table1.Items.Refresh();
            //this.Table.ItemsSource = null;
            //this.Table.ItemsSource = allDevice;
        }

        // Called by DriveDetector after removable device has been unpluged 

        private void OnDriveRemoved(object sender, DriveDetectorEventArgs e)
        {
            // TODO: do clean up here, etc. Letter of the removed drive is in e.Drive;           
            // Just add report to the listbox
            Thread ab = new Thread(GetDeviceOut);
            ab.Start();
            ab.Join();
            this.Table1.Items.Add (allDevice.Last());
            this.Table1.Items.Refresh();    
            allDevice.Clear();
            //this.Table.ItemsSource = null;
            //this.Table.ItemsSource = allDevice;
            //this.Table.Items.Add(allDevice.Last());
            //this.Table.Items.Refresh();            
        }
        private void GetDeviceOut()
        {
            ManagementObjectSearcher mosDisks;
            mosDisks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE NOT MediaType = 'Fixed hard disk media' AND NOT Model='Multiple Card Reader'"); // AND MediaType = 'Fixed hard disk media'   WHERE  Model = '" + lastDevice + "'")
            List<string> device = new List<string>();
            //Находим все подключенные устройства
            foreach (ManagementObject moDisk in mosDisks.Get())
                device.Add(moDisk["SerialNumber"].ToString());
            int Key = 0; ;
            foreach (var key in plugDevice.Keys)
            {
                // из подключенных до этого устройств выбираем отключенное
                if (device.Where(x => x == plugDevice[key][(int)Colunm.Serial]).Count() == 0)
                {
                    Key = key;
                    inDevice.Remove(plugDevice[key][(int)Colunm.Serial]);
                    allDevice.Add(new DataDevice
                                           {
                                               Plug = "Отключено",
                                               Model = plugDevice[key][(int)Colunm.Model],
                                               Serial = plugDevice[key][(int)Colunm.Serial],
                                               MediaType = plugDevice[key][(int)Colunm.Media],
                                               Interface = plugDevice[key][(int)Colunm.Interface],
                                               Capacity = plugDevice[key][(int)Colunm.Capacity],
                                               Date =  DateTime.Now//string.Format("{0:yy/MM/dd   H:mm:ss}", DateTime.Now)
                                           }
                                  );
                    AddLineToDatabase();
                }
            }
            plugDevice.Remove(Key);
        }
        private void AddLineToDatabase()
        {
            try
            {
                SQLiteConnection connection =
                        new SQLiteConnection(string.Format("Data Source={0};", baseName));
                connection.Open();
                SQLiteCommand command = new SQLiteCommand(String.Format("INSERT INTO 'DataDevice' ('Date', 'Plug','Model', 'Serial', 'MediaType','Interface','Capacity') VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}');",
                    allDevice.Last().Date,
                    allDevice.Last().Plug,
                    allDevice.Last().Model,
                    allDevice.Last().Serial,
                    allDevice.Last().MediaType,
                    allDevice.Last().Interface,
                    allDevice.Last().Capacity
                    ), connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.ToString()); //, MessageBoxButton.OKCancel) == MessageBoxResult.OK
            }
        }
        private enum Colunm { InOut, Model, Serial, Media, Interface, Capacity } //, Date
    }


}