using CosmeticsApp.Data;
using CosmeticsApp.Models;
using System;
using System.Globalization;
using System.Windows;

namespace CosmeticsApp.Views
{
    public partial class AddProductWindow : Window
    {
        private readonly ProductRepository repository = new ProductRepository();

        public AddProductWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Product
                {
                    Type = TypeTextBox.Text,
                    Brand = BrandTextBox.Text,
                    Manufacturer = ManufacturerTextBox.Text,
                    ExpirationDate = ExpirationDatePicker.SelectedDate ?? DateTime.Now,
                    Price = decimal.Parse(PriceTextBox.Text, CultureInfo.InvariantCulture)
                };

                repository.AddProduct(product);
                MessageBox.Show("Продукт успішно додано!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при додаванні: " + ex.Message);
            }
        }
    }
}
