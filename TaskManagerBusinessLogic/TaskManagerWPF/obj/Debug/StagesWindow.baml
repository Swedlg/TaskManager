   M S B A M L   `   `   `  ����I  ETaskManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagerWPFTaskManagerWPF  5   	   !    TaskManagerWPF.StagesWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagerWPF     5   	     � Title$  
Этапы��5   	   $	��450��6   $	��800��6$   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��35* �6   �� 5      $	��35* �6   �� 5      $	��35* �6   �� 5      $	��35* �6   �� 5      $
��220* �6    � ColumnDefinitions 5   
   �� 5      $
��644* �6   �� 5      $
��149* �6   .+�5   
   �� -   5         ��Name$ buttonCreate��5      $��Добавить��6'   $��0��6:   $��2��6H   $��Right=�6\   $	��Top=�6x   $	��150��6�   $��35��6�   6�   �� 5   
   -   5        $ buttonUpdate��5      $��Изменить��6'   $��1��6:   $��2��6H   $��Right=�6\   $	��Top=�6x   $	��150��6�   $��35��6�   6�   �� 5   
   -   5        $ buttonDelete��5      $��Удалить��6'   $��2��69   $��2��6G   $��Right=�6[   $	��Top=�6w   $	��150��6�   $��35��6�   6�   �� 5   
   -   5        $ buttonRefresh��5      $��Обновить��6(   $��3��6;   $��2��6I   $��Right=�6]   $	��Top=�6y   $	��150��6�   $��35��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridStages��5      $��0��6+      AutoGenerateColumns .     CanUserAddRows .  $��5��6n   $��2��6   $��0,0,147.727,-0.333q�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   
Visibility$ Hidden=�6%   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6:   �� 
 �� Path$
 Id�6X     5         Header$! Описание этапа��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 0.2* 6g   	 6=   �� $
 StageDescription�6v     5      $ Дата начала��6%   $
 0.2* 6b   	 6:   �� $
 StageStartDate�6q     5      $! Дата окончания��6%   $
 0.2* 6f   	 6=   �� $
 StageFinishDate�6u     5      $ Выполнена ли��6%   $
 0.2* 6`   	 6;   �� $
 isComplited�6o     5       $ Удалена ли��6%   $
 0.2* 6\   	 69   �� $
 	isDeleted�6k     5!      $ ID задачи��6%   $
 0.2* 6X   	 68   �� $
 TaskId�6g   5#      �� 5$   
   -   5        $ button_link_developer��5$      $1��+Привязать разработчика��60   $
��Left=�6Q   $��2,216.667,0,0q�6l   $��4��6�   $	��Top=�6�   $	��147��6�   $��31��6�   $��1��6�   6�   5%      5&      