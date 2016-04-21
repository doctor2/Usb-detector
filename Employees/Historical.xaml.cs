using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Windows;

namespace Employees
{
    /// <summary>
    /// Interaction logic for Historical.xaml
    /// </summary>
    public partial class Historical : Window
    {
        const string baseName = @"CompanyWorkers.db";
        List<DataDevice> table;
        //ItemContext db;ItemContext dindb
        public Historical()
        {
            
            //db = dindb;
            InitializeComponent();
           // Calendar.SelectedDate = DateTime.Now;
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection =
                       new SQLiteConnection(string.Format("Data Source={0};", baseName));
            connection.Open();
            SQLiteCommand command = new SQLiteCommand("SELECT * FROM 'DataDevice' ", connection); //"SELECT * FROM 'DataDevice' "
            SQLiteDataReader reader = command.ExecuteReader();  
            table = new List<DataDevice>();
            foreach (DbDataRecord item in reader)
            {
                table.Add(new DataDevice
                {
                    Date = DateTime.Parse( item["Date"].ToString()),
                    Plug = item["Plug"].ToString(),
                    Model = item["Model"].ToString(),
                    Serial = item["Serial"].ToString(),
                    MediaType = item["MediaType"].ToString(),
                    Interface = item["Interface"].ToString(),
                    Capacity = item["Capacity"].ToString()
                });
            }
            this.Table.ItemsSource = table;
            this.Table.Items.Refresh();
            connection.Close();
            
        }

        private void Calendar_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //var date = table
            //    .Where(hist => hist.Date.Date == Calendar.SelectedDate);
            this.Table.ItemsSource = null;
            this.Table.ItemsSource = table
                .Where(hist => hist.Date.Date == Calendar.SelectedDate);
            this.Table.Items.Refresh();
        }

        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            Calendar.SelectedDate = null;
            this.Table.ItemsSource = null;
            this.Table.ItemsSource = table;
            this.Table.Items.Refresh();
        }
        //protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        //{
        //    table.Clear();
        //    base.OnClosing(e);
        //}
    }
}
