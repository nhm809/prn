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
using DAL.Entities;
using BLL.Services;

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for ProductManagementWindow.xaml
    /// </summary>
    public partial class ProductManagementWindow : Window
    {
        private readonly ProductService _productService = new();
        private readonly ReviewService _reviewService = new();
        private readonly CartItemService _cartItemService = new();

        public ProductManagementWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            var products = await _productService.GetWithCategoryAsync();
            ProductsDataGrid.ItemsSource = products;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new ProductEditWindow(null, "Add");
            if (addWindow.ShowDialog() == true)
            {
                LoadProducts();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa.", "Thông báo");
                return;
            }
            var addWindow = new ProductEditWindow(selectedProduct, "Edit");
            if (addWindow.ShowDialog() == true)
            {
                LoadProducts();
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.", "Thông báo");
                return;
            }

            // Kiểm tra tồn tại trong Reviews hoặc CartItems
            bool existsInReview = await _reviewService.ExistsByProductIdAsync(selectedProduct.ProductId);
            bool existsInCart = await _cartItemService.ExistsByProductIdAsync(selectedProduct.ProductId);

            if (existsInReview  )
            {
                MessageBox.Show("Không thể xóa sản phẩm này vì dữ liệu làm ảnh hướng đến bảng Review.", "Không thể xóa", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (existsInCart)
            {
                MessageBox.Show("Không thể xóa sản phẩm vì sản phẩm đã được khách hàng thêm vào giỏ hàng.", "Không thể xóa", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc muốn xóa sản phẩm \"{selectedProduct.Name}\"?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                await _productService.DeleteAsync(selectedProduct);
                LoadProducts();
            }
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsDataGrid.SelectedItem as Product;
            if (selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xem chi tiết.", "Thông báo");
                return;
            }
            var detailWindow = new ProductDetailWindow(selectedProduct);
            detailWindow.ShowDialog();
        }
    }
}
