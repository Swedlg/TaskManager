   M S B A M L   `   `   `  ����I  ETaskManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagerWPFTaskManagerWPF  5   	        TaskManagerWPF.StageWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagerWPF     5   	     � Title$  Этап��5   	   $	��271��6   $	��387��6#   .��5	      � .+�5
   
   �� -   5         ��Name$ label_stage_description��5
      $"��Описание этапа:��61   $
��Left=�6K   $��	10,10,0,0q�6f   $	��Top=�6y   �� 5   
   -   5        $ label_stage_start_date��5      $��Дата начала:��60   $
��Left=�6G   $��	10,41,0,0q�6b   $	��Top=�6u   �� 5   
   -   5        $ label_stage_finish_date��5      $"��Дата окончания:��61   $
��Left=�6K   $��	10,72,0,0q�6f   $	��Top=�6y   �� 5   
   -   5        $ label_isComplited��5      $��Выполнен ли:��6+   $
��Left=�6B   $��
10,103,0,0q�6]   $	��Top=�6q   �� 5   
   -   5        $ label_isDeleted��5      $��Удален ли:��6)   $
��Left=�6>   $��
10,134,0,0q�6Y   $	��Top=�6m   �� 5   
   -   5        $ label_task_id��5      $��Задача��6'   $
��Left=�68   $��
10,165,0,0q�6S   $	��Top=�6g   �� 5   
   -   5         ��Name$ textBox_stage_description��5      $
��Left=�65   $��23��6P   $��
116,14,0,0q�6\    �� TextWrapping$
 Wrap=�6p   $	��Top=�6�   $	��254��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$! datePicker_stage_start_date��5      $
��Left=�6:   $��
116,42,0,0q�6U   $	��Top=�6i   $	��254��6�     5   
   -	   5        $" datePicker_stage_finish_date��5      $
��Left=�6;   $��
116,73,0,0q�6V   $	��Top=�6j   $	��254��6�   �� 5   
   -
   5         ��Name$ comboBox_task_id��5       �� DisplayMemberPath$ TaskName��6-    �� SelectedValuePath$ Id��6J   $
��Left=�6a   $��116,169,0,0q�6|   $	��Top=�6�   $	��254��6�   �� 5   
   -   5         ��Name$ checkBox_isComplited��5      $
��Left=�61   $��116,110,0,0q�6L   $	��Top=�6a   �� 5   
   -   5        $ checkBox_isDeleted��5      $
��Left=�6/   $��116,141,0,0q�6J   $	��Top=�6_   �� 5   
   -   5        	 ��Name$	 button_save��5      $��Сохранить��6&   $
��Left=�6:   $��
10,196,0,0q�6U   $	��Top=�6i   $	��360��6�   $��35��6�   6�   5      5      