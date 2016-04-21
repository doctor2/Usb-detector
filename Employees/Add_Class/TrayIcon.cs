using System;
using System.Windows;

namespace Employees
{
    public partial class MainWindow : Window
    {
        // переопределяем обработку первичной инициализации приложения
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e); // базовый функционал приложения в момент запуска
            createTrayIcon(); // создание нашей иконки
        }
        private System.Windows.Forms.NotifyIcon TrayIcon = null;
        private System.Windows.Controls.ContextMenu TrayMenu = null;

        private bool createTrayIcon()
        {
            bool result = false;
            if (TrayIcon == null)
            { // только если мы не создали иконку ранее
                TrayIcon = new System.Windows.Forms.NotifyIcon(); // создаем новую
                TrayIcon.Icon = Employees.Properties.Resources.ScrapsUSB; // изображение для трея
                // обратите внимание, за ресурсом с картинкой мы лезем в свойства проекта, а не окна,
                // поэтому нужно указать полный namespace
                TrayIcon.Text = "USB-детектор"; // текст подсказки, всплывающей над иконкой
                TrayMenu = Resources["TrayMenu"] as System.Windows.Controls.ContextMenu; // а здесь уже ресурсы окна и тот самый x:Key

                // сразу же опишем поведение при щелчке мыши, о котором мы говорили ранее
                // это будет просто анонимная функция, незачем выносить ее в класс окна
                TrayIcon.Click += delegate(object sender, EventArgs e)
                {
                    if ((e as System.Windows.Forms.MouseEventArgs).Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        // по левой кнопке показываем или прячем окно
                        ShowHideMainWindow(sender, null);
                    }
                    else
                    {
                        // по правой кнопке (и всем остальным) показываем меню
                        TrayMenu.IsOpen = true;
                        Activate(); // нужно отдать окну фокус, см. ниже
                    }
                };
                result = true;
            }
            else
            { // все переменные были созданы ранее
                result = true;
            }
            TrayIcon.Visible = true; // делаем иконку видимой в трее
            return result;
        }
        private void ShowHideMainWindow(object sender, RoutedEventArgs e)
        {
            TrayMenu.IsOpen = false; // спрячем менюшку, если она вдруг видима
            if (IsVisible)
            {// если окно видно на экране
                // прячем его
                Hide();
                // меняем надпись на пункте меню
                (TrayMenu.Items[0] as System.Windows.Controls.MenuItem).Header = "Показать";
            }
            else
            { // а если не видно
                // показываем
                Show();
                // меняем надпись на пункте меню
                (TrayMenu.Items[0] as System.Windows.Controls.MenuItem).Header = "Спрятать";
                WindowState = CurrentWindowState;
                Activate(); // обязательно нужно отдать фокус окну,
                // иначе пользователь сильно удивится, когда увидит окно ававав
                // но не сможет в него ничего ввести с клавиатуры
            }
        }
        private WindowState fCurrentWindowState = WindowState.Normal;
        public WindowState CurrentWindowState
        {
            get { return fCurrentWindowState; }
            set { fCurrentWindowState = value; }
        }
        protected override void OnStateChanged(EventArgs e)
        {
            base.OnStateChanged(e); // системная обработка при нажатии на свернуть
            if (this.WindowState == System.Windows.WindowState.Minimized)
            {
                // если окно минимизировали, просто спрячем
                Hide();
                // и поменяем надпись на менюшке
                (TrayMenu.Items[0] as System.Windows.Controls.MenuItem).Header = "Показать";
            }
            else
            {
                // в противном случае запомним текущее состояние
                CurrentWindowState = WindowState;
            }
        }
        private bool fCanClose = false;
        public bool CanClose
        { // флаг, позволяющий или запрещающий выход из приложения
            get { return fCanClose; }
            set { fCanClose = value; }
        }

        // переопределяем обработчик запроса выхода из приложения
        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e); // встроенная обработка
            if (!CanClose)
            {    // если нельзя закрывать
                e.Cancel = true;// выставляем флаг отмены закрытия
                // запоминаем текущее состояние окна
                CurrentWindowState = this.WindowState;
                // меняем надпись в менюшке
                (TrayMenu.Items[0] as System.Windows.Controls.MenuItem).Header = "Показать";
                // прячем окно
                Hide();
            }
            else
            { // все-таки закрываемся
                // убираем иконку из трея
                TrayIcon.Visible = false;
            }
        }
        private void MenuExitClick(object sender, RoutedEventArgs e)
        {           
            var close = MessageBox.Show("Вы уверены?", "Закрытие", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
            if (close)
            {
                CanClose = true;
                if (histOpened && historyWindow.Activate())
                    historyWindow.Close();
            }
            else
                CanClose = false;
            Close();
        }
    }
}
