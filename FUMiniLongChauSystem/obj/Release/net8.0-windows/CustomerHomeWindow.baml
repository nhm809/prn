   M S B A M L   `   `   `  ����   FUMiniLongChauSystem-    'FUMiniLongChauSystem.CustomerHomeWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$$  Mini Long Châu - Trang chính��$	��770��$
��1100�� � WindowStartupLocation$ CenterScreen=����#F3F6F9$��Segoe UI)�.��]� .+��� ���#2E86C1$��60��$	��Top=�._�� $
��20,0q�$��Center=� � ColumnDefinitions �� $��* ��� $
��Auto �.+��� $��Mini Long Châu��$��0��$��24(�$
��Bold"�
�������$��Center=��� $��1�� �� Orientation$ 
Horizontal=�$��Right=�$��Center=�.+��� -   $��👤 Thông tin��$	��130��$��36��$	��8,4q�
����������#2E86C1$��SemiBold"� � Cursor$
 Hand�����#ffffff$��1q�$��10,0,0,0q��� -   $��🛒 Giỏ hàng��$	��130��$��36��$	��8,4q�
����������#2E86C1$��SemiBold"�$
 Hand�����#ffffff$��1q�$��10,0,0,0q��� -   $��🚪 Đăng xuất��$	��130��$��36��$	��8,4q�
����������#C0392B$��SemiBold"�$
 Hand�����#ffffff$��1q�$��10,0,0,0q�� $��20q� �� $	��220 ��� $��* �.+��� $��0��
������� �� CornerRadius$ 10�� �� Padding$ 10q����#ddd$��1q�._��� .+��� $��
Danh mục��$
��Bold"�$��18(�$��0,0,0,10q����#2E86C1�� -    ��Name$ CategoryListBox��
������ $��0q����#333$��14(��� $��1��$��20,0,0,0q�.+��� $ 
Horizontal=�$��0,0,0,10q�.+��� -    ��Name$ SearchTextBox��$	��500��$��32��$��14(�$	��8,4q�$��Center=�	 � ToolTip$.	 (Nhập tên thuốc để tìm kiếm...���� -   $
��🔍��$��40��$��32��$��8,0,0,0q�$	 Tìm kiếm�����#2E86C1
�������$
��Bold"�$
 Hand���� $ 
Horizontal=�$��Center=�$��0,0,0,10q�.+��� $��Sắp xếp:��$��Center=�$��0,0,10,0q�$��SemiBold"��� -   
 ��Name$
 SortComboBox��$	��160��$��32��.@��� $��Bán chạy�� �� 
IsSelected$
 True���� $��Giá giảm dần���� $��Giá tăng dần���� $
��Auto=�$	��500��.��� -    �Name$ ProductWrapPanel�� � 	ItemWidth$	 240�� � 
ItemHeight$
 Auto��$��0,0,0,20q��� $ 
Horizontal=�$��Center=�$��0,10,0,0q�.+��� -	   $	��←��$��32��$��32��$��5q��� -
    ��Name$ PageInfoTextBlock��$��Center=�$
��Bold"�$
��10,0q��� -   $	��→��$��32��$��32��$��5q�