   M S B A M L   `   `   `  ����   FUMiniLongChauSystem%    FUMiniLongChauSystem.CartWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$4  .Thông tin trong giỏ hàng - Mini Long Châu�� � SizeToContent$ Height=�$	��650�� � WindowStartupLocation$ CenterScreen=����#f4f4f4.��� $��20q�.+��� 
������� �� CornerRadius$ 10��$��2q� �� Padding$ 20q�$��10q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   
BlurRadius$ 10Q�   ShadowDepth$ 2Q�	   Opacity$		 0.3Q�._��� .+��� -   $	��✖��$��30��$��30��
������ $��0q�$��14(�
���  ��$��Right=�$	��Top=��� $"��🛒 Giỏ hàng của bạn��$��20(�$
��Bold"����#2E86C1$��0,0,0,10q�$��Center=��� ���#2E86C1$��1q�$ 2��
�������._��� -   
 ��Name$
 CartListView��$��5q� �� View �� .P��� $��Sản phẩm�� �� Width$	 140�� �� CellTemplate �� .R��� $��Center=����� *Name+�� $��Số lượng��$	 120�� �� .R���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $	��−��$��25���� $��30�� �� TextAlignment$ Center=����� *
Quantity+�� -   $��+��$��25���� $��
Đơn giá��$ 80�� �� .R��� $��Right=����� *Price+ �� StringFormat$ 	{0:N0} đ���� $��Thành tiền��$	 100�� �� .R��� $
��Bold"�
��� d �$��Right=����� *
TotalPrice+$ 	{0:N0} đ���� $�� ��$ 50�� �� .R��� -   $
��🗑���� $ 
Horizontal=�$��Right=�$��0,10,0,0q�.+��� $��Tổng tiền: ��$
��Bold"�$��14(�$��Center=��� -    ��Name$ TotalAmountTextBlock��$��14(�$
��Bold"�
��� d �$��5,0,20,0q�$��Center=��� -   $��✔ Thanh toán�����#27ae60
�������$��5q�$
��10,5q�