using CosmeticsApp.Data;
using CosmeticsApp.Models;
using System.Collections.Generic;
using System.Windows;

namespace CosmeticsApp.Views
{
    public partial class SearchWindow : Window
    {
        private readonly ProductRepository repository = new ProductRepository();

        public SearchWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string keyword = SearchTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(keyword))
            {
                List<Product> results = repository.SearchProducts(keyword);
                SearchResultsDataGrid.ItemsSource = results;
            }
            else
            {
                MessageBox.Show("Введіть слово для пошуку.");
            }
        }
    }
}
