   M S B A M L   `   `   `  ����I  ETaskManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagerWPFTaskManagerWPF  5   	       TaskManagerWPF.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagerWPF     5   	     � Title$  Главная форма��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $	��10* �6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ button_tasks��5      $��Задачи��6'   $��0��68   $
��Left=�6H   $	��Top=�6c   $	��199��6{   $��38��6�   6�   �� 5   
   -   5        $ button_stages��5      $��
Этапы��6(   $��1��68   $
��Left=�6H   $	��Top=�6c   $	��199��6{   $��38��6�   6�   �� 5   
   -   5        $ button_developers��5      $��Разработчики��6,   $��2��6C   $
��Left=�6S   $	��Top=�6n   $	��199��6�   $��38��6�   6�   �� 5   
   -   5        $ button_program_languages��5      $1��+Языки программирования��63   $��3��6T   $
��Left=�6d   $	��Top=�6   $	��199��6�   $��38��6�   6�   5      5      