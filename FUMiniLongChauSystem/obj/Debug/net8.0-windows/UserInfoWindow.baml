   M S B A M L   `   `   `  ����  FUMiniLongChauSystem)    #FUMiniLongChauSystem.UserInfoWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$/  )Thông tin tài khoản - Mini Long Châu��5   	   $	��500��66   $	��360��6C    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�6   .��5      � ���#F9F9F9.+�5   
   �� 
������� �� CornerRadius$ 10��6$   $��2q�66    �� Padding$ 20q�6J   $��10q�6W    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5	         Color$ Black��6#      
BlurRadius$ 10Q�61      ShadowDepth$ 2Q�6A   	   Opacity$		 0.3Q�6Q   ._�5      � 
 � RowDefinitions
 5      �� 5      $
��Auto �6$   �� 5      $��* �6$   �� 5      $
��Auto �6$   .+�5      �� $��Thông tin tài khoản��6   $��20(�5      $
��Bold"�6*   ���#2E86C1$��Center=�5      $��0,0,0,20q�69   �� 5      $��1��6   $
��Auto=�6,   .��5      �� $	��Top=�6!   $��0,0,0,10q�69   .+�5      ��  �� Orientation$ Vertical=�6%   $��0,0,0,10q�6<   .+�5      �� $��
Họ tên:��6(   $��SemiBold"�67   �� 5      -   5         ��Name$ txtFullName��5   &   $��5q�6;   5      �� 5!      $ Vertical=�6%   $��0,0,0,10q�6<   .+�5"      �� $��Email:��6(   $��SemiBold"�66   �� 5#      -   5        $ txtEmail��5#   &    �� 
IsReadOnly$
 True��68   ���#EEE$��5q�6\   5$      �� 5&      $ Vertical=�6%   $��0,0,0,20q�6<   .+�5'      �� $��Số điện thoại:��6(   $��SemiBold"�6>   �� 5(      -   5        $ txtPhone��5(   &   $��5q�68   5)      9� 5,      $��🔐 Đổi mật khẩu��6#   $��SemiBold"�6<   .��5-      �� $��0,10,0,0q�6)   .+�5.   "   �� $ ��Mật khẩu hiện tại:��6,   G� 5/   "   -   5         G�Name$ OldPasswordBox��5/   .   $��5q�6F   $��0,0,0,10q�6R   �� 51   "   $��Mật khẩu mới:��6,   G� 52   "   -   5        $ NewPasswordBox��52   .   $��5q�6F   $��0,0,0,10q�6R   �� 54   "   $%��Xác nhận mật khẩu mới:��6,   G� 55   "   -   5        $ ConfirmPasswordBox��55   .   $��5q�6J   56      57      58      59      �� 5<      $��2��6   $ 
Horizontal=�6*   $��Right=�6C   $��0,10,0,0q�6_   .+�5=      �� -   5        $��Huỷ��5=      $	��100��6+   $��35��67   
�������
�������$��0,0,50,0q�5?      5@      �� 5A      -   5        $��Cập nhật��5A      $	��100��60   $��35��6<   ���#2E86C1
�������5C      5D      5E      5F      5G      5H      