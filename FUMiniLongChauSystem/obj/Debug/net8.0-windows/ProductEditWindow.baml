   M S B A M L   `   `   `  ����O  KFUMiniLongChauSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FUMiniLongChauSystemFUMiniLongChauSystem  5   	   ,    &FUMiniLongChauSystem.ProductEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FUMiniLongChauSystem     5   	     � Title$  Thông tin sản phẩm��5      $	��340��6'   $	��437��64    � WindowStartupLocation$ CenterOwner=�6@   .��5	      � $��10,10,10,-6q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   �� $��Tên sản phẩm:��6   $��0��6)   $��0��66   $��Center=�6F   �� 5   
   -   5         ��Name$ NameTextBox��5      $��0��6'   $��1��64   $��5q�6D   �� 5   
   $��Giá:��6   $��1��6    $��0��6-   $��Center=�6=   �� 5   
   -   5        $ PriceTextBox��5      $��1��6(   $��1��65   $��5q�6E   �� 5   
   $��
Tồn kho:��6   $��2��6$   $��0��61   $��Center=�6A   �� 5    
   -   5        $ StockTextBox��5       $��2��6(   $��1��65   $��5q�6E   �� 5"   
   $��Danh mục:��6   $��3��6%   $��0��62   $��Center=�6B   �� 5#   
   -   5         ��Name$ CategoryComboBox��5#      $��3��6-   $��1��6:   $��5q�6J    �� DisplayMemberPath$
 Name��6U    �� SelectedValuePath$ 
CategoryId��6n   �� 5%   
   $��	Mô tả:��6   $��4��6"   $��0��6/   $��Center=�6?   �� 5&   
   -   5        $ DescriptionTextBox��5&      $��4��6.   $��1��6;   $��5q�6K   �� 5(   
   $��Hình ảnh :��6   $��5��6&   $��0��63   $��Center=�6C   �� 5)   
   $��5��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��5q�6K   .+�5*      �� -   5        $ ImageUrlTextBox��5*      $	��200��6/   	 �� 
IsReadOnly$
	 True��6;   �� 5+      -   5        
 ��Name$
 SelectImageButton��5+      $��Chọn ảnh...��60   $��80��6F   $��5,0,0,0q�6Q   6b   5,      �� 5.   
   -   5        $
 btnSave��5.      $
��Lưu��6"   $��7,10,181,90q�6F   $��7��6[   $��1��6h   �� 5/   
   -	   5        $
 	btnCancel��5/      $��Hủy��6$   $��90��62   $��1��6U   $��148,10,59,90q�6e   $��7��6{   50      51      