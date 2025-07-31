using BLL.Services;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using BLL.DTOs;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        private readonly CartItemService _cartItemService = new();
        private User _user;

        public CartWindow(User user)
        {
            InitializeComponent();
            _user = user;
            Loaded += CartWindow_Loaded;
        }

        private async void CartWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var cartDtos = await _cartItemService.GetCartItemDtosByUserIdAsync(_user.UserId);

            var displayItems = cartDtos.Select(dto => new CartItemDto
            {
                CartItemId = dto.CartItemId,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Price = dto.Price
            });

            CartListView.ItemsSource = displayItems;
            decimal total = displayItems.Sum(i => i.TotalPrice);
            TotalAmountTextBlock.Text = total.ToString("N0") + " đ";
        }
        private async void Increase_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int cartItemId)
            {
                var cartItem = await _cartItemService.GetByIdAsync(cartItemId);
                if (cartItem != null)
                {
                    cartItem.Quantity += 1;
                    await _cartItemService.UpdateAsync(cartItem);
                    await RefreshCartItems();
                }
            }
        }


        private async void Decrease_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int cartItemId)
            {
                var cartItem = await _cartItemService.GetByIdAsync(cartItemId);
                if (cartItem != null && cartItem.Quantity > 1)
                {
                    cartItem.Quantity -= 1;
                    await _cartItemService.UpdateAsync(cartItem);
                    await RefreshCartItems();
                }
            }
        }

        private async void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is int cartItemId)
            {
                var cartItem = await _cartItemService.GetByIdAsync(cartItemId);
                if (cartItem != null)
                {
                    await _cartItemService.DeleteAsync(cartItem);
                    await RefreshCartItems();
                }
            }
        }

        private async Task RefreshCartItems()
        {
            // Lưu lại item đang được chọn
            var previouslySelected = CartListView.SelectedItem;

            var cartDtos = await _cartItemService.GetCartItemDtosByUserIdAsync(_user.UserId);

            var displayItems = cartDtos.Select(dto => new CartItemDto
            {
                CartItemId = dto.CartItemId,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Price = dto.Price
            }).ToList();

            CartListView.ItemsSource = displayItems;

            if (previouslySelected != null)
            {
                var previousId = (int)previouslySelected.GetType().GetProperty("CartItemId").GetValue(previouslySelected);

                var match = displayItems.FirstOrDefault(x =>
                    x.CartItemId == previousId);

                if (match != null)
                {
                    CartListView.SelectedItem = match;
                }
            }

            decimal total = displayItems.Sum(i => i.TotalPrice);
            TotalAmountTextBlock.Text = total.ToString("N0") + " đ";
        }

        private void QuantityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(char.IsDigit);
        }


        private async void QuantityTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Tag is int cartItemId)
            {
                if (int.TryParse(textBox.Text, out int newQuantity) && newQuantity > 0)
                {
                    var cartItem = await _cartItemService.GetByIdAsync(cartItemId);
                    if (cartItem != null)
                    {
                        cartItem.Quantity = newQuantity;
                        await _cartItemService.UpdateAsync(cartItem);
                        await RefreshCartItems();
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số nguyên dương!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                    await RefreshCartItems(); 
                }
            }
        }


        private void Checkout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanh toán thành công! 🎉", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
            // Hoặc mở cửa sổ thanh toán chi tiết khác
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
