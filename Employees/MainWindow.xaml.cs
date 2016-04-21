using System;
using System.Windows;

namespace Employees
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public MainWindow()
        //{
        //    InitializeComponent();
        //}
        Historical  historyWindow; 
        private void History(object sender, RoutedEventArgs e)
        {
            histOpened = true;
            historyWindow = new Historical();//new Window()
            historyWindow.ShowDialog();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            MenuExitClick(sender,e);
        }
    }
}
