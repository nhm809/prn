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

namespace FUMiniLongChauSystem
{
    /// <summary>
    /// Interaction logic for ProductDetailWindow.xaml
    /// </summary>
    public partial class ProductDetailWindow : Window
    {
        public ProductDetailWindow(Product product)
        {
            InitializeComponent();

            // Hiển thị thông tin sản phẩm
            NameTextBlock.Text = product.Name;
            PriceTextBlock.Text = product.Price.ToString("N0");
            StockTextBlock.Text = product.Stock.ToString();
            CategoryTextBlock.Text = product.Category?.Name ?? "(Không có)";
            DescriptionTextBlock.Text = product.Description;

            if (!string.IsNullOrEmpty(product.ImageUrl))
            {
                try
                {
                    ProductImage.Source = new System.Windows.Media.Imaging.BitmapImage(new System.Uri(product.ImageUrl, System.UriKind.RelativeOrAbsolute));
                }
                catch
                {
                    // Nếu lỗi đường dẫn ảnh, có thể để trống hoặc hiển thị ảnh mặc định
                    ProductImage.Source = null;
                }
            }
            else
            {
                ProductImage.Source = null;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
