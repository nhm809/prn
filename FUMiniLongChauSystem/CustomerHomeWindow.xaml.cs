using BLL.DTOs;
using BLL.Services;
using DAL.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FUMiniLongChauSystem
{
    public partial class CustomerHomeWindow : Window
    {
        private readonly CategoryService _categoryService = new();
        private readonly ProductService _productService = new();
        private readonly CartItemService _cartItemService = new();

        private List<Category> _categories = new();
        private List<Product> _products = new();
        private User _user;

        public CustomerHomeWindow(User user)
        {
            InitializeComponent();
            Loaded += CustomerHomeWindow_Loaded;
            _user = user;
        }

        private async void CustomerHomeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            _categories = await _categoryService.GetAllAsync();
            _products = await _productService.GetWithCategoryAsync(); // lấy luôn Category

            var allCategory = new Category { CategoryId = 0, Name = "Tất cả" };
            _categories.Insert(0, allCategory);

            CategoryListBox.ItemsSource = _categories;
            CategoryListBox.DisplayMemberPath = "Name";

            CategoryListBox.SelectedIndex = 0;
            SortComboBox.SelectedIndex = 0;

            FilterAndDisplayProducts();
        }

        private void FilterAndDisplayProducts()
        {
            if (_products == null) return;

            var selectedCategory = CategoryListBox.SelectedItem as Category;
            var filtered = selectedCategory != null && selectedCategory.CategoryId != 0
                ? _products.Where(p => p.CategoryId == selectedCategory.CategoryId).ToList()
                : _products;

            var keyword = SearchTextBox?.Text?.Trim().ToLower();
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(p => p.Name.ToLower().Contains(keyword)).ToList();
            }

            var selectedSort = (SortComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString();
            if (selectedSort == "Giá tăng dần")
            {
                filtered = filtered.OrderBy(p => p.Price).ToList();
            }
            else if (selectedSort == "Giá giảm dần")
            {
                filtered = filtered.OrderByDescending(p => p.Price).ToList();
            }
            else if (selectedSort == "Bán chạy")
            {
                filtered = filtered.OrderByDescending(p => p.OrderDetails?.Count ?? 0).ToList();
            }

            DisplayProducts(filtered);
        }

        private void DisplayProducts(List<Product> products)
        {
            if (ProductWrapPanel == null) return;
            ProductWrapPanel.Children.Clear();

            foreach (var product in products)
            {
                var border = new Border
                {
                    BorderThickness = new Thickness(1),
                    BorderBrush = Brushes.LightGray,
                    Margin = new Thickness(10),
                    Padding = new Thickness(10),
                    Width = 200,
                    Background = Brushes.White,
                    CornerRadius = new CornerRadius(8)
                };

                var stack = new StackPanel();

                string imageFile = string.IsNullOrWhiteSpace(product.ImageUrl) ? "Assets/noimage.jpg" : product.ImageUrl;
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imageFile);

                if (File.Exists(imagePath))
                {
                    var image = new Image
                    {
                        Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute)),
                        Height = 120,
                        Margin = new Thickness(0, 0, 0, 8),
                        Stretch = Stretch.UniformToFill
                    };
                    stack.Children.Add(image);
                }
                else
                {
                    stack.Children.Add(new TextBlock
                    {
                        Text = "Không tìm thấy ảnh",
                        Foreground = Brushes.Red,
                        FontSize = 11,
                        TextAlignment = TextAlignment.Center
                    });
                }

                stack.Children.Add(new TextBlock
                {
                    Text = product.Name,
                    FontWeight = FontWeights.Bold,
                    FontSize = 14,
                    Margin = new Thickness(0, 5, 0, 2),
                    TextWrapping = TextWrapping.Wrap
                });

                stack.Children.Add(new TextBlock
                {
                    Text = $"{product.Price:C}",
                    Foreground = Brushes.Green,
                    FontWeight = FontWeights.SemiBold,
                    Margin = new Thickness(0, 0, 0, 4)
                });

                stack.Children.Add(new TextBlock
                {
                    Text = product.Description,
                    FontSize = 12,
                    TextWrapping = TextWrapping.Wrap,
                    MaxHeight = 60,
                    Margin = new Thickness(0, 0, 0, 5)
                });

                var buttonPanel = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 5, 0, 0)
                };

                var addToCartButton = new Button
                {
                    Content = "🛒 Thêm",
                    FontSize = 12,
                    Padding = new Thickness(6, 2, 6, 2),
                    Margin = new Thickness(0, 0, 5, 0),
                    Background = Brushes.LightGreen,
                    Cursor = System.Windows.Input.Cursors.Hand,
                    Tag = product
                };
                addToCartButton.Click += AddToCartButton_Click;

                var detailButton = new Button
                {
                    Content = "🔍 Xem",
                    FontSize = 12,
                    Padding = new Thickness(6, 2, 6, 2),
                    Background = Brushes.LightSkyBlue,
                    Cursor = System.Windows.Input.Cursors.Hand,
                    Tag = product
                };
                detailButton.Click += ViewDetailButton_Click;

                buttonPanel.Children.Add(addToCartButton);
                buttonPanel.Children.Add(detailButton);

                stack.Children.Add(buttonPanel);
                border.Child = stack;

                ProductWrapPanel.Children.Add(border);
            }
        }

        private async void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Product product)
            {
                // Kiểm tra xem user đã có sản phẩm này trong giỏ chưa
                var existingItems = await _cartItemService.GetAllAsync();
                var existingItem = existingItems
                    .FirstOrDefault(c => c.UserId == _user.UserId && c.ProductId == product.ProductId);

                if (existingItem != null)
                {
                    existingItem.Quantity += 1;
                    await _cartItemService.UpdateAsync(existingItem);
                }
                else
                {
                    var cartItem = new CartItem
                    {
                        UserId = _user.UserId,
                        ProductId = product.ProductId,
                        Quantity = 1
                    };

                    await _cartItemService.AddAsync(cartItem);
                }

                MessageBox.Show($"Đã thêm '{product.Name}' vào giỏ hàng.");
            }
        }

        private void ViewDetailButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is Product product)
            {
                MessageBox.Show($"Chi tiết: {product.Name}\n\n{product.Description}", "Thông tin sản phẩm");
                // TODO: Hiển thị cửa sổ chi tiết sản phẩm
            }
        }

        private void CategoryListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndDisplayProducts();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterAndDisplayProducts();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterAndDisplayProducts();
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            var cartWindow = new CartWindow(_user);
            cartWindow.ShowDialog();
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            var infoWindow = new UserInfoWindow(_user);
            infoWindow.ShowDialog();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không?", "Đăng xuất", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                this.Close(); 
            }
        }
    }
}
