   M S B A M L   `   `   `  ����  Lab4%    CosmeticsApp.Views.SearchWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  
Пошук��5   	   $	��400��6   $	��600��6$   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�6.   .+�5      �� -   5         ��Name$ SearchTextBox��5      $	��400��6-   $��0,0,10,0q�69   �� 5      -   5        $��
Пошук��5      $	��100��6%   61   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ SearchResultsDataGrid��5      $��1��62      AutoGenerateColumns$ False��5         
IsReadOnly$
 True��6/      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 40 6H   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+6H     5      $ Вид��6%   $	 * 6K   
 62   �� *Type+6K     5      $ 
Марка��6%   $	 * 6N   
 64   �� *Brand+6N     5      $ Виробник��6%   $	 * 6X   
 67   �� *Manufacturer+6X     5      $) #Термін придатності��6%   $		 140 6d   
 6A   �� *ExpirationDate+6d     5      $ Ціна��6%   $	 80 6M   
 63   �� *Price+6M   5      5      5      