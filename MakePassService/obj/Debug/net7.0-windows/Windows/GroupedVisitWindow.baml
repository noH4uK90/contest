   M S B A M L   `   `   `  ����J  FMakePassService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MakePassService.WindowsMakePassService.Windows  5   	   0    *MakePassService.Windows.GroupedVisitWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   7local%clr-namespace:MakePassService.Windows     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ GroupedVisitWindow��5	   	   $	��450��6$   $	��800��61   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��0��6   $��0��6    �� CornerRadius$ 10��6.   
�������$��5q�6W   ._�5      ��  �� Orientation$ Vertical=�6   .+�5      �� $ 10��6   
��� ���._�5      �� $2��,Информация для пропуска��6   $��Center=�6>   $��14(�6b   5      �� 5      $-��'Срок действия заявки:��6   $��Center=�68   �� 5      $ 
Horizontal=�6   $��Center=�66   .+�5      �� $	��с*��6   (  "System.Windows.Controls.DatePicker  5      $��80��6!   $��22��6,   
������� � 	Resources 5       �� 
TargetType �� Property	 �� Value��%_   '��       �� 5      " ��6$   .�5    "   ��  �@��CornerRadius$	 10��6A   5!      5"      5#      �� 5$      $
��по��6     5%      $��80��6!   $��22��6,   
������� 5&      ��%_   '��       �� 5'      " ��6$   .�5(   "   ��  �@��CornerRadius$	 10��6A   5)      5*      5+      5,      �� 5-      $#��Цель посещения*:��6   $��Center=�63   �� 5.      $	��200��6   $��0 0 0 10q�6'   5/      50      �� 52   
   $��0��6   $��1��6   $ 10��6.   
�������$��5q�6W   ._�53      �� $ Vertical=�6   .+�54      �� $ 10��6   
��� ���._�55      �� $+��%Принимающая сторона��6   $��Center=�6:   $��14(�6^   56      �� 58      $"��Подразделение*:��6   $��7 0 0 0q�62   �� 59      $��	10 0 10 0q�6   �� 5;      $��ФИО*:��6   $��7 0 0 0q�6(   �� 5<      $ 
Horizontal=�6   .+�5=      �� $��	10 0 10 0q�6   $	��330��61   �� 5>      $��/Resources/User.jpg��6   $��20��69   6F   5?      5@      5A      �� 5C   
   $��1��6   $��2��6   $ 10��62   
�������$��5q�6[   ._�5D      �� $ Vertical=�6   .+�5E      �� $ 10��6   
��� ���._�5F      �� $)��#Список посетителей��6   $��Center=�69   $��14(�6]   5G      �� 5I      $ 
Horizontal=�6   $��10q�66   .+�5J      �� $%��загрузить список��6   
���  ��$��5q�6H   �� 5K      $.��(скачать шаблон списка��6   
���  ��$��5q�6M   5L      &   System.Windows.Controls.DataGrid  5N      
   Columns
 5O      0  *System.Windows.Controls.DataGridTextColumn  5P      ,  &System.Windows.Controls.DataGridColumn   Header$	 №��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 68     5Q      $ ФИО��6-   $	 100 6:     5R      $ Контакты��6-   $	 250 6?   4  .System.Windows.Controls.DataGridTemplateColumn  5S      $ Фотография��61   $	 100 6E     5T      $ Паспорт��61   $	 100 6B   5V      5W      5X      �� 5Z   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��Center=�6K   $��Center=�6f   .+�5[      �� $!��Очистить форму��6   
���iii�$��0 0 5 0q�6B   �� 5\      $#��Оформить заявку��6   
�������$	��150��6B    5]      ��%^   '��       �� 5^      " ��6   .�5_      ��  �@��CornerRadius$	 7��69   5`      5a      5b      5c      5d      5e      