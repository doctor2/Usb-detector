   M S B A M L   `   `   `  ����   USB_Detector    Employees.Historical   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$+  %История подключений��$	��500��$	��800��$	��650��$	��300�� � Icon$ Resources\ScrapsUSB.ico��.���  � RowDefinitions �� $
��Auto ��� $��* �.+�]� $��0��.+��� 
�������$,��&Сортировать по дате  ��(  "System.Windows.Controls.DatePicker  -   $��Calendar���� 
�������$��  ���� -   $��ClearFilter��$��Сбросить��$
��Auto���� 
�������&   System.Windows.Controls.DataGrid  -     Name$ Table��   AutoGenerateColumns .  $��1��   
IsReadOnly .    ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ *    RowBackground �#FFFFFF   AlternatingRowBackground �#ECECEC$	   HorizontalScrollBarVisibility$
	 Auto=����� 
   Columns
 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Подключение��   
FontWeight$
 Bold"�1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Plug+  $ Модель�� �� *Model+  $! Серийный номер�� �� *Serial+  $! Тип устройства�� �� *	MediaType+  $! Тип интерфейса�� �� *	Interface+  $ Емкость�� �� *
Capacity+  $ Дата и время�� �� *Date+ �� StringFormat$ {0:yy/MM/dd H:mm:ss}��