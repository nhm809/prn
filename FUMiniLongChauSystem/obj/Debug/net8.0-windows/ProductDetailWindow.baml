   M S B A M L   `   `   `  ����O  KFUMiniLongChauSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FUMiniLongChauSystemFUMiniLongChauSystem  5   	   .    (FUMiniLongChauSystem.ProductDetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FUMiniLongChauSystem     5   	     � Title$  Chi tiết sản phẩm��5      $	��420��6'   $	��420��64    � WindowStartupLocation$ CenterOwner=�6@   .��5	      � $��10q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $	��120 �6   �� 5      $��* �6   .+�5   
   �� $��Tên sản phẩm:��6   $��0��6)   $��0��66   $��Center=�6F   �� 5   
   -   5         ��Name$ NameTextBlock��5      $��0��6+   $��1��68   $��5q�6H   $
��Bold"�6S   �� 5   
   $��Giá:��6   $��1��6    $��0��6-   $��Center=�6=   �� 5   
   -   5        $ PriceTextBlock��5      $��1��6,   $��1��69   $��5q�6I   �� 5   
   $��
Tồn kho:��6   $��2��6$   $��0��61   $��Center=�6A   �� 5   
   -   5        $ StockTextBlock��5      $��2��6,   $��1��69   $��5q�6I   �� 5!   
   $��Danh mục:��6   $��3��6%   $��0��62   $��Center=�6B   �� 5"   
   -   5        $ CategoryTextBlock��5"      $��3��6/   $��1��6<   $��5q�6L   �� 5$   
   $��	Mô tả:��6   $��4��6"   $��0��6/   $��Center=�6?   �� 5%   
   -   5        $ DescriptionTextBlock��5%      $��4��62   $��1��6?   $��5q�6O   $
��Wrap=�6Z   �� 5'   
   $��Hình ảnh:��6   $��5��6%   $��0��62   $	��Top=�6B   �� 5(   
   -   5         ��Name$ ProductImage��5(      $��5��6&   $��1��63   $	��100��6C   $��5q�6P   $��Uniform=�6[   �� 5*   
   -   5        $��Đóng��5*      $��6��6    $��90��6-   $��30��68   $��Right=�6D   $��
0,10,5,104q�6`   $��1��6�   5+      5,      