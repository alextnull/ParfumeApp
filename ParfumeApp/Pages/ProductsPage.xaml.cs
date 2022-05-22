using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParfumeApp
{
    /// <summary>
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {
        private int _currentPage = 0;
        private int _productsAtPage = 10;
        private int _productsCount = 0;

        public ProductsPage()
        {
            InitializeComponent();
            UpdateProducts();
        }

        private void UpdateProducts()
        {
            if (ProductsListView is null)
            {
                return;
            }

            var searchText = SearchTextBox.Text;
            var orderPriceSelectedIndex = OrderPriceComboBox.SelectedIndex;
            var saleSelectedIndex = SaleComboBox.SelectedIndex;
            Task.Run(() =>
            {
                var context = ParfumEntities.GetContext();
                var products = context.Products.AsQueryable();

                if (!string.IsNullOrEmpty(searchText))
                {
                    products = products.Where(p => p.NameProducts.Contains(searchText));
                }

                if (saleSelectedIndex == 1)
                {
                    products = products.Where(p => p.ActiveSale >= 0 && p.ActiveSale <= 10);
                }
                else if (saleSelectedIndex == 2)
                {
                    products = products.Where(p => p.ActiveSale >= 11 && p.ActiveSale <= 14);
                }
                else if (saleSelectedIndex == 3)
                {
                    products = products.Where(p => p.ActiveSale >= 15);
                }

                if (orderPriceSelectedIndex == 0)
                {
                    products = products.OrderBy(p => p.Price);
                }
                else if (orderPriceSelectedIndex == 1)
                {
                    products = products.OrderByDescending(p => p.Price);
                }

                _productsCount = products.Count();
                products = products.Skip(_productsAtPage * _currentPage).Take(_productsAtPage);


                var productsList = products.ToList();
                App.Current.Dispatcher.Invoke(() =>
                {
                    ProductsListView.ItemsSource = productsList;
                    PagesTextBlock.Text = $"{_productsAtPage * (_currentPage + 1)} из {_productsCount}";
                });
            });


            
        }

        private void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (_currentPage == 0)
                return;
            _currentPage--;
            UpdateProducts();
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (_productsAtPage * (_currentPage + 1) == _productsCount)
                return;
            _currentPage++;
            UpdateProducts();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void SaleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }

        private void OrderPriceComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProducts();
        }
    }
}
