   M S B A M L   `   `   `  ����  USB_Detector    Employees.Historical   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$+  %История подключений��5   	   $	��500��6%   $	��800��62   $	��650��5   	   $	��300��6    � Icon$ Resources\ScrapsUSB.ico��5   	   .��5      �  � RowDefinitions 5   
   �� 5	      $
��Auto �6   6,   �� 5
      $��* �6   6)   .+�5   
   ]� $��0��6   .+�5      �� 
�������$,��&Сортировать по дате  ��6+   (  "System.Windows.Controls.DatePicker  5      -   5        $��Calendar��5      6)   �� 5      
�������$��  ��6+   �� 5      -   5        $��ClearFilter��5   5   $��Сбросить��6   $
��Auto��6(   6H   �� 5      
�������6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ Table��5         AutoGenerateColumns .  $��1��6?      
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5         RowBackground �#FFFFFF   AlternatingRowBackground �#ECECEC$	   HorizontalScrollBarVisibility$
	 Auto=�5      ��5      �� 
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Подключение��6(      
FontWeight$
 Bold"�6=   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6O   �� *Plug+  5      $ Модель��6'    68   �� *Model+  5      $! Серийный номер��6(    6@   �� *Serial+  5      $! Тип устройства��6'    6?   �� *	MediaType+  5      $! Тип интерфейса��6&    6>   �� *	Interface+  5      $ Емкость��6'    68   �� *
Capacity+  5       $ Дата и время��6'    6=   �� *Date+ �� StringFormat$ {0:yy/MM/dd H:mm:ss}��5$      5%      5&      