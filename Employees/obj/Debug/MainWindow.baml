   M S B A M L   `   `   `  ����G  CUSB_Detector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Employees	Employees  5   	       Employees.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:Employees     5   	   -   5          � Title$1  +Детектор USB-подключений��5   	   $	��600��6*   $	��800��67   $	��650��5   	   $	��300��6    � Icon$ Resources\ScrapsUSB.ico��5   	    � 	Resources 5	         TrayMenu��%�   &	        �� 5
   
   .@�5      m� -   5        $��Спрятать��5      6)   �� 5      m� 5      -   5        $��
Выход��5      6&   5      5      .��5      �   BackgroundWindowResource#��[ 6    � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   o� $��0��6   .@�5      m� $��Файл��6   .@�5      m� -   5        $��История��5      6>   �� 5       6   m� 5!      -   5        $��
Выход��5!      69   5"      5#      � 5%   
   $��1��6   .+�5&      &   System.Windows.Controls.DataGrid  -   5          Name$ Table1��5&      $��20,30,20,30q�6'      AutoGenerateColumns .     
IsReadOnly .    RowBackground �#FFFFFF   AlternatingRowBackground �#ECECEC$	   HorizontalScrollBarVisibility$
	 Auto=�5)      
   Columns
 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$
 105* 6*      Header$ Подключение��68      
FontWeight$
 Bold"�6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6_   �� *Plug+  5-      $
 105* 6*   $ Модель��68    6I   �� *Model+  5.      $
 110* 6*   $! Серийный номер��68    6P   �� *Serial+  5/      $
 110* 6)   $! Тип устройства��67    6O   �� *	MediaType+  50      $
 110* 6)   $! Тип интерфейса��67    6O   �� *	Interface+  51      $	 80* 6*   $ Емкость��67    6H   �� *
Capacity+  52      $
 100* 6*   $ Дата и время��68    6N   �� *Date+ �� StringFormat$ {0:yy/MM/dd H:mm:ss}��5;      5<      5L      5M      