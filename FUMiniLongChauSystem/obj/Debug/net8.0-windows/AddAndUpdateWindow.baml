   M S B A M L   `   `   `  ����O  KFUMiniLongChauSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FUMiniLongChauSystemFUMiniLongChauSystem  5   	   -    'FUMiniLongChauSystem.AddAndUpdateWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FUMiniLongChauSystem     5   	     � Title$  Add or Update User��5   	   $	��408��6$   $	��509��61   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �� $��User ID:��6   $��0��6$   $��0��61   $��Center=�6A   �� 5   
   -   5         ��Name$ UserIdTextBox��5      $��0��6)   $��1��66   $��5q�6F    �� 
IsReadOnly$
 True��6Q   �� 5   
   $��
Full Name:��6   $��1��6&   $��0��63   $��Center=�6C   �� 5   
   -   5        $ FullNameTextBox��5      $��1��6+   $��1��68   $��5q�6H   �� 5   
   $��Email:��6   $��2��6"   $��0��6/   $��Center=�6?   �� 5    
   -   5        $ EmailTextBox��5       $��2��6(   $��1��65   $��5q�6E   �� 5#   
   -   5         ��Name$ PasswordLabel��5#      $��	Password:��6+   $��3��6<   $��0��6I   $��Center=�6Y   G� 5$   
   -   5         G�Name$ PasswordBox��5$      $��3��6+   $��1��68   $��5q�6H   �� 5&   
   $��Phone:��6   $��4��6"   $��0��6/   $��Center=�6?   �� 5'   
   -   5        $ PhoneTextBox��5'      $��4��6(   $��1��65   $��5q�6E   �� 5)   
   $��Role:��6   $��5��6!   $��0��6.   $��Center=�6>   �� 5*   
   -   5         ��Name$ RoleComboBox��5*      $��5��6)   $��1��66   $��5q�6F   .@�5+      �� $��Admin��6   �� 5,      $��Customer��6   5-      �� 5/   
   -   5         ��Name$ btnSave��5/      $
��Save��6"   $��10,52,285,100q�61   $��1��6a   $��6��6q   �� 50   
   -	   5        $ 	btnCancel��50      $��Cancel��6$   $��154,52,134,100q�6P   $��6��6h   $��1��6u   51      52      