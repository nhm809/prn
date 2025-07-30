using BLL.Services;
using DAL.Entities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for ProductEditWindow.xaml
    /// </summary>
    public partial class ProductEditWindow : Window
    {
        private readonly ProductService _productService = new();
        private readonly CategoryService _categoryService = new();
        private Product _editingProduct;
        private readonly string _mode;  

        public ProductEditWindow(Product? product, string mode)
        {
            InitializeComponent();
            _mode = mode;
            LoadCategories();

            if (mode == "Add")
            {
                Title = "Thêm sản phẩm";
                btnSave.Content = "Thêm";
            }
            else if (product != null)
            {
                _editingProduct = product;
                NameTextBox.Text = product.Name;
                PriceTextBox.Text = product.Price.ToString();
                StockTextBox.Text = product.Stock.ToString();
                DescriptionTextBox.Text = product.Description;
                ImageUrlTextBox.Text = product.ImageUrl;
                CategoryComboBox.SelectedValue = product.CategoryId;
            }
            else if (product != null) // Detail
            {
                _editingProduct = product;
                NameTextBox.Text = product.Name;
                PriceTextBox.Text = product.Price.ToString();
                StockTextBox.Text = product.Stock.ToString();
                DescriptionTextBox.Text = product.Description;
                ImageUrlTextBox.Text = product.ImageUrl;
                CategoryComboBox.SelectedValue = product.CategoryId;

                if (mode == "Edit")
                {
                    Title = "Sửa sản phẩm";
                    btnSave.Content = "Lưu";
                }
                else // Detail
                    {
                    Title = "Chi tiết sản phẩm";
                    btnSave.Visibility = Visibility.Collapsed;
                    NameTextBox.IsReadOnly = true;
                    PriceTextBox.IsReadOnly = true;
                    StockTextBox.IsReadOnly = true;
                    DescriptionTextBox.IsReadOnly = true;
                    ImageUrlTextBox.IsReadOnly = true;
                    CategoryComboBox.IsEnabled = false;
                }
            }
        }

        private async void LoadCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            CategoryComboBox.ItemsSource = categories;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!decimal.TryParse(PriceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Giá phải là số lớn hơn 0.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!int.TryParse(StockTextBox.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Tồn kho phải là số nguyên >= 0.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (CategoryComboBox.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(DescriptionTextBox.Text))
            {
                MessageBox.Show("Mô tả không được để trống.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hình ảnh có thể để trống, nhưng nếu có thì phải là file tồn tại
            string imageUrl = ImageUrlTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(imageUrl) && !File.Exists(imageUrl))
            {
                MessageBox.Show("Đường dẫn ảnh không hợp lệ hoặc file không tồn tại.", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_mode == "Add")
            {
                var newProduct = new Product
                {
                    Name = NameTextBox.Text.Trim(),
                    Price = price,
                    Stock = stock,
                    Description = DescriptionTextBox.Text.Trim(),
                    ImageUrl = imageUrl,
                    CategoryId = (int)CategoryComboBox.SelectedValue
                };
                await _productService.AddAsync(newProduct);
            }
            else if (_mode == "Edit" && _editingProduct != null)
            {
                _editingProduct.Name = NameTextBox.Text.Trim();
                _editingProduct.Price = price;
                _editingProduct.Stock = stock;
                _editingProduct.Description = DescriptionTextBox.Text.Trim();
                _editingProduct.ImageUrl = imageUrl;
                _editingProduct.CategoryId = (int)CategoryComboBox.SelectedValue;
                await _productService.UpdateAsync(_editingProduct);
            }

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*"
            };
            if (dialog.ShowDialog() == true)
            {
                ImageUrlTextBox.Text = dialog.FileName;
            }
        }
    }
}
