   M S B A M L   `   `   `  ����O  KFUMiniLongChauSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:FUMiniLongChauSystemFUMiniLongChauSystem  5   	   0    *FUMiniLongChauSystem.ConfirmCheckoutWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:FUMiniLongChauSystem     5   	     � Title$  Xác nhận đơn hàng��5   	   $	��550��5	   	   $	��650��6    � WindowStartupLocation$ CenterScreen=�5
   	   ���#f9f9f9$��Segoe UI)�5   	   $��14(�5   	    � 	Resources 5         LeftAlignedHeader �� 
TargetType �� Property �� Value��%T   &	        �� 5   
   " ��6*   .�5      ��  � ��$
 Left=�6;   5      5      .��5      �� ���#ccc$��1q�6     �� CornerRadius$ 10��64    �� Padding$ 20q�6F   
�������$��15q�6f   ._�5   
   �� .+�5      �� $"��🧾 Xác nhận đơn hàng��6   $
��Bold"�5      $��22(�5      $��0,0,0,15q�5      ���#2E86C15      �� 5      $��0,0,0,13q�6   .+�5      �� �� 5      $�👤 Tên khách hàng: ��6   $��SemiBold"�65    �� 5       -   5         ��Name$ CustomerNameRun��5       $�(chưa có)��63   5!      �� 5"      $��0,10,0,0q�6   �� 5#      $!�📞 Số điện thoại: ��6   $��SemiBold"�64    �� 5$      -   5        $ CustomerPhoneRun��5$      $�(chưa có)��64   5%      5&      �� 5)      ���#ddd$��1q�6(   $ 5��6<   ���#fbfbfb$ 5q�6b   $��0,0,0,10q�6n   ._�5*      �� -   5        	 ��Name$	 OrderItemsListView��5*      $��0q�5+      
�������$��1q�5-      ���#DDD$��5q�5/      
 �� View
 50      �� 51   "   .P�52      �� $��Sản phẩm��6-    �� Width$	 170��6?    �� HeaderContainerStyle# [  6K    �� CellTemplate 53   *   �� 54   .   .R�55   2   �� $��Center=�6R   ��6<   �� *Name+6R   56   /   58   '   �� 5:      $��Số lượng��6-   $	 100��6?   # [  6K    5;   *   �� 5<   .   .R�5=   2   �� $��Center=�6V   ��6<   �� *
Quantity+6V   5>   /   5@   '   �� 5B      $��
Đơn giá��6-   $	 120��6>   # [  6J    5C   *   �� 5D   .   .R�5E   2   �� $��Right=�6l   ��6<   �� *Price+ �� StringFormat$ 	{0:N0} đ��6l   5F   /   5H   '   �� 5J      $��Thành tiền��6-   $	 130��6A   # [  6M    5K   *   �� 5L   .   .R�5M   2   �� $
��Bold"�6q   
��� d �$��Right=�6�   ��6<   �� *
TotalPrice+$ 	{0:N0} đ��6�   5N   /   5P   '   5Q   #   5S      5T      �� 5W      $#��📦 Địa chỉ giao hàng:��6   $��SemiBold"�65   $��0,5,0,5q�6K   �� 5X      $ 5��6   ���#ccc$��1q�69   
�������._�5Y      �� -   5         ��Name$ AddressTextBox��5Y      $��35��5Z      $��0q�5[      $��8q�5\      $��0q�5]      
������ 5^      5_      ]� 5c      $��Right=�6   .+�5d      �� $��Tổng: ��6   $
��Bold"�5e      $��15(�5f      $��0,20,0,0q�5g      $��Center=�5h      �� 5i      -   5         ��Name$ TotalAmountTextBlock��5i      $��15(�5j      $
��Bold"�5k      ���#27ae60$��	5,20,20,0q�5m      $��Center=�5n      �� 5o      -   5        $%��✅ Xác nhận và Thanh toán��5o      $
��12,6q�5p      ���#27ae60
�������$��SemiBold"�5s      $��0q�5t       � Cursor$
 Hand��5u      $��0,20,0,0q�5v      $	��200��5x      5y      5z      5{      5|      