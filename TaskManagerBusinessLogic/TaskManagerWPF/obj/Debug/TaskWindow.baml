   M S B A M L   `   `   `  ����I  ETaskManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagerWPFTaskManagerWPF  5   	       TaskManagerWPF.TaskWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagerWPF     5   	     � Title$  Задача��5   	   $��230.444��6   $��378.667��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ label_task_name��5
      $$��Название задачи:��6)   $
��Left=�6D   $��	10,10,0,0q�6_   $	��Top=�6r   �� 5   
   -   5        $ label_task_start_date��5      $��Дата начала:��6/   $
��Left=�6F   $��	10,41,0,0q�6a   $	��Top=�6t   �� 5   
   -   5        $ label_task_finish_date��5      $"��Дата окончания:��60   $
��Left=�6J   $��	10,72,0,0q�6e   $	��Top=�6x   �� 5   
   -   5        $ label_is_deleted��5      $��Удален ли:��6*   $
��Left=�6?   $��
10,103,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5        $ label_employer_id��5      $��Заказчик:��6+   $
��Left=�6?   $��
10,134,0,0q�6Z   $	��Top=�6n   �� 5   
   -   5         ��Name$ textBox_task_name��5      $
��Left=�6-   $��23��6H   $��
122,13,0,0q�6T    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��240��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$  datePicker_task_start_date��5      $
��Left=�69   $��
122,42,0,0q�6T   $	��Top=�6h   $	��240��6�     5   
   -   5        $! datePicker_task_finish_date��5      $
��Left=�6:   $��
122,73,0,0q�6U   $	��Top=�6i   $	��240��6�   �� 5   
   -	   5         ��Name$ checkBox_isDeleted��5      $
��Left=�6/   $��122,110,0,0q�6J   $	��Top=�6_   �� 5   
   -
   5         ��Name$ button_save��5      $��Сохранить��6&   $
��Left=�6:   $��
10,165,0,0q�6U   $	��Top=�6i   $	��352��6�   $��26��6�   6�   �� 5   
   -   5        $ textBox_employer_id��5       �� 
IsReadOnly . $
��Left=�6A   $��23��6\   $��122,137,0,0q�6h   $
 Wrap=�6}   $	��Top=�6�   $	��240��6�   5      5      