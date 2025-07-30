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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

            var displayItems = cartDtos.Select(dto => new
            {
                CartItemId = dto.CartItemId,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Price = dto.Price,
                TotalPrice = dto.Price * dto.Quantity
            });

            CartListView.ItemsSource = displayItems;
            decimal total = displayItems.Sum(i => i.TotalPrice);
            TotalAmountTextBlock.Text = total.ToString("N0") + " đ";
        }
        private async void Increase_Click(object sender, RoutedEventArgs e)
        {
            if (CartListView.SelectedItem is not null)
            {
                dynamic selectedItem = CartListView.SelectedItem;
                int cartItemId = selectedItem.CartItemId;

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
            if (CartListView.SelectedItem is not null)
            {
                dynamic selectedItem = CartListView.SelectedItem;
                int cartItemId = selectedItem.CartItemId;

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
            if (CartListView.SelectedItem is not null)
            {
                dynamic selectedItem = CartListView.SelectedItem;
                int cartItemId = selectedItem.CartItemId;

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
            var cartDtos = await _cartItemService.GetCartItemDtosByUserIdAsync(_user.UserId);

            CartListView.ItemsSource = cartDtos.Select(dto => new
            {
                CartItemId = dto.CartItemId,
                Name = dto.Name,
                Quantity = dto.Quantity,
                Price = dto.Price,
                TotalPrice = dto.Price * dto.Quantity
            }).ToList();

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
