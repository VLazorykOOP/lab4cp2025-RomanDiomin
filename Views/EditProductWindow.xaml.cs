using CosmeticsApp.Data;
using CosmeticsApp.Models;
using System;
using System.Globalization;
using System.Windows;

namespace CosmeticsApp.Views
{
    public partial class EditProductWindow : Window
    {
        private readonly ProductRepository repository = new ProductRepository();
        private readonly Product originalProduct;

        public EditProductWindow(Product product)
        {
            InitializeComponent();
            originalProduct = product;
            LoadProductData();
        }

        private void LoadProductData()
        {
            TypeTextBox.Text = originalProduct.Type;
            BrandTextBox.Text = originalProduct.Brand;
            ManufacturerTextBox.Text = originalProduct.Manufacturer;
            ExpirationDatePicker.SelectedDate = originalProduct.ExpirationDate;
            PriceTextBox.Text = originalProduct.Price.ToString(CultureInfo.InvariantCulture);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                originalProduct.Type = TypeTextBox.Text;
                originalProduct.Brand = BrandTextBox.Text;
                originalProduct.Manufacturer = ManufacturerTextBox.Text;
                originalProduct.ExpirationDate = ExpirationDatePicker.SelectedDate ?? DateTime.Now;
                originalProduct.Price = decimal.Parse(PriceTextBox.Text, CultureInfo.InvariantCulture);

                repository.UpdateProduct(originalProduct);
                MessageBox.Show("Продукт оновлено!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
