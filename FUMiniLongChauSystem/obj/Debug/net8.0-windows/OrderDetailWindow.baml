   M S B A M L   `   `   `  ����  FUMiniLongChauSystem,    &FUMiniLongChauSystem.OrderDetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Chi tiết đơn hàng��5   	   $	��720��5   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��5	   	   $��Segoe UI)�5
   	    � SizeToContent$ Height=�5   	    � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   DropShadowEffect   
BlurRadius   ShadowDepth   Opacity	   Color��%d   &	          5   
   $ 12Q�5      $ 0Q�5      $
 0.25Q�5      $	 Black��5      5      .��5      �� 
�������
 �� CornerRadius$
 10��5       �� Padding$ 20q�5      ���#E0E0E0$��1q�5       J� Effect# [  5      ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5       $
��Auto �6    �� 5"      $
��Auto �6    .+�5'      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�62   .+�5(      �� $
��📦��6   $��20(�6&   $��0,0,5,0q�64   �� 5)      $��Chi tiết đơn hàng��6   $��18(�5*      $
��Bold"�5+      ���#2C3E505,      5-      �� 50      -   5        $��OrderDetailListView��50      $��1��62    51       �� 
TargetType �� Property �� Value��%�   '��       �� 52      " ��6   .�53      ��  � ��$
 Left=�6G   �� 54       � ��$ SemiBold"�67   �� 55       � �� �#33367   �� 56       � ��$ 13(�65   �� 57       � ��$	 4,6q�64   58      59       �� View 5;      �� 5<      .P�5=      �� $��Sản phẩm��6)    �� Width$	 240��6;    �� DisplayMemberBinding 6G   �� *	ProductId+�� 5>      $��Số lượng��6)   $	 100��6;    6G   �� *
Quantity+�� 5?      $��
Đơn giá��6)   $	 130��6:    �� CellTemplate 5@      �� 5A   "   .R�5B   &   �� $��Right=�5C   0   ���#34495E��5B   0   �� *Price+ �� StringFormat$ 	{0:N0} đ��5D   0   5E   #   5G      �� 5H      $��Thành tiền��6)   $	 140��6=    5I      �� 5J   "   .R�5K   &   �� $��Right=�5L   0   $
��Bold"�5M   0   
��� d ���5K   0   �� *
TotalPrice+$ 	{0:N0} đ��5N   0   5O   #   5Q      5R      5T      �� 5W      $��2��6   $ 
Horizontal=�6&   $��Right=�6?   $��0,15,0,0q�6[   .+�5X      �� -   5        $��Đóng��5X      $	��100��5Y      $��32��5Z      ���#3498DB
�������$��SemiBold"�5]      $��0q�5^       � Cursor$
 Hand��5_      5`      5a      5b      5c      5d      