using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShoesStore.Module;
using ShoesStore.Forms;
using ShoesStore.Data;

namespace ShoesStore.Forms
{
    public partial class ProductEditForm : Form
    {
        private DataContext context;
        private Product currentProduct;
        private bool isNewProduct;
        public ProductEditForm()
        {
            InitializeComponent();
            context = new DataContext();
            isNewProduct = true;
            currentProduct = null;
        }
        public ProductEditForm(Product product) : this()
        {
            if (product != null)
            {
                currentProduct = product;
                isNewProduct = false;
                LoadProductData();
            }
        }
        private void LoadProductData()
        {
            if (currentProduct == null) return;

            nameTextBox.Text = currentProduct.Name;
            categoryTextBox.Text = currentProduct.Category ?? "";
            priceTextBox.Text = currentProduct.Price.ToString("F2");
            stockTextBox.Text = currentProduct.Quantity.ToString();
            descriptionTextBox.Text = currentProduct.Description ?? "";
        }
        private bool CollectProductData(out Product product)
        {
            product = new Product();

            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Введите название товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nameTextBox.Focus();
                return false;
            }
            product.Name = nameTextBox.Text.Trim();

            product.Category = string.IsNullOrWhiteSpace(categoryTextBox.Text) ? null : categoryTextBox.Text.Trim();

            if (!decimal.TryParse(priceTextBox.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Введите корректную цену (положительное число).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                priceTextBox.Focus();
                return false;
            }
            product.Price = price;

            if (!int.TryParse(stockTextBox.Text, out int quantity) || quantity < 0)
            {
                MessageBox.Show("Введите корректное количество (целое неотрицательное число).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                stockTextBox.Focus();
                return false;
            }
            product.Quantity = quantity;

            product.Description = string.IsNullOrWhiteSpace(descriptionTextBox.Text) ? null : descriptionTextBox.Text.Trim();

            if (!isNewProduct && currentProduct != null)
            {
                product.Id = currentProduct.Id;
            }

            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!CollectProductData(out Product product))
                return;

            try
            {
                if (isNewProduct)
                {
                    context.AddProduct(product);
                    MessageBox.Show("Товар успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    context.UpdateProduct(product);
                    MessageBox.Show("Товар успешно обновлён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            categoryTextBox.Clear();
            priceTextBox.Clear();
            stockTextBox.Clear();
            descriptionTextBox.Clear();
            nameTextBox.Focus();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            if (CollectProductData(out Product product))
            {
                string info = $"Название: {product.Name}\n" +
                              $"Категория: {product.Category ?? "—"}\n" +
                              $"Цена: {product.Price:C2}\n" +
                              $"Количество: {product.Quantity}\n" +
                              $"Описание: {product.Description ?? "—"}";
                MessageBox.Show(info, "Предпросмотр товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void generateIdButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            priceTextBox.Text = (rnd.Next(500, 10000) / 100m).ToString("F2");
            stockTextBox.Text = rnd.Next(1, 100).ToString();
        }

        private void loadSampleDataButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "Кроссовки Nike Air Max";
            categoryTextBox.Text = "Кроссовки";
            priceTextBox.Text = "7500";
            stockTextBox.Text = "15";
            descriptionTextBox.Text = "Легкие и удобные кроссовки для повседневной носки.";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void categoryTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void priceTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void stockTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
