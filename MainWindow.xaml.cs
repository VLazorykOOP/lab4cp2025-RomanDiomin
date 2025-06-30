using CosmeticsApp.Data;
using CosmeticsApp.Models;
using System.Collections.Generic;
using System.Windows;

namespace CosmeticsApp
{
    public partial class MainWindow : Window
    {
        private readonly ProductRepository repository = new ProductRepository();

        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> products = repository.GetAllProducts();
            ProductsDataGrid.ItemsSource = products;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadProducts();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new Views.AddProductWindow();
            addWindow.ShowDialog();
            LoadProducts();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                var editWindow = new Views.EditProductWindow(selectedProduct);
                editWindow.ShowDialog();
                LoadProducts();
            }
            else
            {
                MessageBox.Show("Оберіть запис для редагування.");
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem is Product selectedProduct)
            {
                var result = MessageBox.Show("Ви впевнені, що хочете видалити запис?", "Підтвердження", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    repository.DeleteProduct(selectedProduct.Id);
                    LoadProducts();
                }
            }
            else
            {
                MessageBox.Show("Оберіть запис для видалення.");
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            var searchWindow = new Views.SearchWindow();
            searchWindow.ShowDialog();
        }
    }
}
