   M S B A M L   `   `   `  ����I  ETaskManagerWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TaskManagerWPFTaskManagerWPF  5   	   (    "TaskManagerWPF.LinkDeveloperWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TaskManagerWPF     5   	     � Title$H  BФорма привязки разработчика к этапу��5   	   $��146.889��65   $��323.556��6F   .��5	      � .+�5
   
   �� -   5         ��Name$ label_stage��5
      $��	Этап:��6%   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   �� 5   
   -   5        $ label_developer��5      $��Разработчик:��6)   $
��Left=�6@   $��	10,41,0,0q�6[   $	��Top=�6n   �� 5   
   -   5         ��Name$ textBox_stage��5      $
��Left=�6)   $��23��6D   $��	98,14,0,0q�6P    �� TextWrapping$
 Wrap=�6c    �� 
IsReadOnly . $	��Top=�6�   $	��209��6�   �� 5   
   -   5         ��Name$ comboBox_developer��5       �� DisplayMemberPath$ FullNameOfDeveloper��6/    �� SelectedValuePath$ Id��6W   $
��Left=�6n   $��	98,45,0,0q�6�   $	��Top=�6�   $	��209��6�   �� 5   
   -   5         ��Name$ button_link��5      $��Привязать��6&   $
��Left=�6:   $��	10,72,0,0q�6U   $	��Top=�6h   $	��297��6�   $��35��6�   6�   5      5      