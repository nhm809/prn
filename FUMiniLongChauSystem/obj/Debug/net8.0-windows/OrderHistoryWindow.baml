   M S B A M L   `   `   `  ����  FUMiniLongChauSystem-    'FUMiniLongChauSystem.OrderHistoryWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Lịch sử đơn hàng��5   	   $	��900��6"    � WindowStartupLocation$ CenterScreen=�5   	   ���#F3F6F9$	��500��5   	   $��Segoe UI)�5   	    � SizeToContent$ Height=�5	   	    � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%  '��       �� 5   
   " ��6   .�5      ��  � ��$ 6q�6(   �� 5       � ��
 �����6+   �� 5       � ��$ Stretch=�6;    5      P� 5       �@��AlternationIndex$	 1��6C   . �5      ��  � �� �#FAFAFA63   5      P� 5       �@J�IsMouseOver$
	 True��61   . �5      ��  � �� �#D6EAF863   5      5      5      .��5      ]� $��20,15,20,20q�6   .+�5   
   �� $)��#Lịch sử đơn hàng của bạn��6   $��24(�5      $
��Bold"�5       ���#2C3E50$��0,0,0,10q�5"      $	��Top=�5#      �� 5&   
   
�������
 �� CornerRadius$
 10��5'       �� Padding$ 10q�5(      ���#DADADA$��1q�5*       J� SnapsToDevicePixels$
 True��5+      ._�5,      �� -   5        $��OrderListView��5,      $��0q�5-       �� AlternationCount$ 2��5.      $��0q�5/       50      ��%  '��       �� 52      " ��6   .�53      ��  � ��$
 Left=�6G   �� 54       � ��$
 Bold"�67   �� 55       � �� �#2C3E5067   �� 56       � ��$ 14(�65   �� 57       � ��$	 4,6q�64   �� 58       � �� �#ECF0F167   59      5:       �� View 5<      �� 5=      .P�5>      �� $��	Mã đơn��6)    �� Width$ 80��69    �� DisplayMemberBinding 6D   �� *	OrderId+�� 5?      $��Ngày đặt��6)   $	 150��6;    6G   �� *	OrderDate+�� 5@      $��Tổng tiền��6)   $	 110��6<    �� CellTemplate 5A      �� 5B   "   .R�5C   &   �� $
��Left=�6f   ��60   �� *TotalAmount+ �� StringFormat$ 	{0:N0} đ��6f   5D   #   5F      �� 5G      $��Trạng thái��6)   $	 120��6=    6I   �� *Status+�� 5H      $��Địa chỉ giao hàng��6)   $	 230��6D    6P   �� *ShippingAddress+�� 5I      $��
Chi tiết��6)   $	 110��6;    5J      �� 5K   "   .R�5L   &   �� -   5        $��🔍 Chi tiết��5L   -   ���#3498DB
�������$	��4,2q�5P   -   $��0q�5Q   -    � Cursor$
 Hand��5R   -   $��12(�5S   -   $��SemiBold"�5T   -   $��80��5U   -   $��28��5V   -   $��Center=�5W   -   5X   #   5Z      5[      5]      5^      5_      5`      