   M S B A M L   `   `   `  ���� G  CUSB_Detector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Employees	Employees      Employees.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     )localclr-namespace:Employees     -     � Title$1  +Детектор USB-подключений��$	��600��$	��800��$	��650��$	��300�� � Icon$ Resources\ScrapsUSB.ico�� � 	Resources    TrayMenu��%S   &	        �� .@�m� -   $��Спрятать���� m� -   $��
Выход��.���   BackgroundWindowResource#��[  � RowDefinitions �� $
��Auto ��� $��* �.+�o� $��0��.@�m� $��Файл��.@�m� -   $��История���� m� -   $��
Выход��� $��1��.+�&   System.Windows.Controls.DataGrid  -     Name$ Table1��$��20,30,20,30q�   AutoGenerateColumns .     
IsReadOnly .    RowBackground �#FFFFFF   AlternatingRowBackground �#ECECEC$	   HorizontalScrollBarVisibility$
	 Auto=�
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 105*    Header$ Подключение��   
FontWeight$
 Bold"�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Plug+  $
 105* $ Модель�� �� *Model+  $
 110* $! Серийный номер�� �� *Serial+  $
 110* $! Тип устройства�� �� *	MediaType+  $
 110* $! Тип интерфейса�� �� *	Interface+  $	 80* $ Емкость�� �� *
Capacity+  $
 100* $ Дата и время�� �� *Date+ �� StringFormat$ {0:yy/MM/dd H:mm:ss}��