   M S B A M L   `   `   `  ����O  KFUMiniLongChauSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FUMiniLongChauSystemFUMiniLongChauSystem  5   	   &     FUMiniLongChauSystem.AdminWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FUMiniLongChauSystem     5   	     � Title$  Admin - User Management��5   	   $	��450��6)   $	��800��66   .��5	      � .+�5
   
   �� -   5         ��Name$ LogoutButton��5
      $��Đăng xuất��6'   $	��100��6;   $��25,39,675,365q�6G   6^   �� 5   
   -   5        $��Manager Product��5      $��400,44,290,341q�6M   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ UsersDataGrid��5         AutoGenerateColumns$ False��6*   $��10,77,400,35q�6F      
IsReadOnly$
 True��6\      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *UserId+6L     5      $
 Name��6%   $ 80 6P    63   �� *
FullName+6P     5      $ Email��6%   $ 80 6N    64   �� *Email+6N     5      $ Phone��6%   $	 120 6N    64   �� *Phone+6N     5      $
 Role��6%   $ 60 6L    63   �� *Role+6L   5      �� 5   
   	 �� Orientation$	 
Horizontal=�6   $
��Left=�6.   $��Bottom=�6I   $��	10,0,0,10q�6d   .+�5      �� -   5        $��Delete��5      $��80��6&   61   �� 5      -   5        $
��Edit��5      $��80��6$   6/   �� 5      -   5        $	��Add��5      $��80��6#   6.   �� 5      -   5        $��Details��5      $��80��6'   62   5      5      5      