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
        private Products currentProduct;
        private bool isNewMode;
        public Products Product => currentProduct;

        // Конструктор для создания нового товара
        public ProductEditForm() : this(new Products(), true) { }

        public ProductEditForm(Products product, bool isNew = false)
        {
            InitializeComponent();
            context = new DataContext();
            currentProduct = product;
            isNewMode = isNew;

            // Заполняем поля данными продукта
            LoadProductData();
        }

        private void LoadProductData()
        {
            if (currentProduct != null)
            {
                nameTextBox.Text = currentProduct.Name;
                categoryTextBox.Text = currentProduct.Category;
                priceTextBox.Text = currentProduct.Price.ToString("F2");
                stockTextBox.Text = currentProduct.StockQuantity.ToString();
                sizeTextBox.Text = currentProduct.Size?.ToString() ?? "";
                colorTextBox.Text = currentProduct.Color;
                brandTextBox.Text = currentProduct.Brand;
                descriptionTextBox.Text = currentProduct.Description;
            }
        }
        private void ShowError(string message)
        {
            errorLabel.Text = message;
            errorLabel.Visible = true;
        }

        private void HideError()
        {
            errorLabel.Visible = false;
        }

        // Проверка корректности введённых данных
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                ShowError("Введите название товара");
                nameTextBox.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(categoryTextBox.Text))
            {
                ShowError("Введите категорию");
                categoryTextBox.Focus();
                return false;
            }

            if (!decimal.TryParse(priceTextBox.Text, out decimal price) || price <= 0)
            {
                ShowError("Цена должна быть положительным числом");
                priceTextBox.Focus();
                return false;
            }

            if (!int.TryParse(stockTextBox.Text, out int stock) || stock < 0)
            {
                ShowError("Количество на складе должно быть целым неотрицательным числом");
                stockTextBox.Focus();
                return false;
            }

            // Размер может быть пустым, но если заполнен, то число
            if (!string.IsNullOrWhiteSpace(sizeTextBox.Text) && !int.TryParse(sizeTextBox.Text, out _))
            {
                ShowError("Размер должен быть целым числом");
                sizeTextBox.Focus();
                return false;
            }

            HideError();
            return true;
        }

        // Сохранение данных в объект
        private void UpdateProductFromInputs()
        {
            currentProduct.Name = nameTextBox.Text.Trim();
            currentProduct.Category = categoryTextBox.Text.Trim();
            currentProduct.Price = decimal.Parse(priceTextBox.Text);
            currentProduct.StockQuantity = int.Parse(stockTextBox.Text);

            if (int.TryParse(sizeTextBox.Text, out int size))
                currentProduct.Size = size;
            else
                currentProduct.Size = null;

            currentProduct.Color = string.IsNullOrWhiteSpace(colorTextBox.Text) ? null : colorTextBox.Text.Trim();
            currentProduct.Brand = string.IsNullOrWhiteSpace(brandTextBox.Text) ? null : brandTextBox.Text.Trim();
            currentProduct.Description = string.IsNullOrWhiteSpace(descriptionTextBox.Text) ? null : descriptionTextBox.Text.Trim();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            UpdateProductFromInputs();

            if (isNewMode)
            {
                currentProduct.ID = Guid.NewGuid();
                currentProduct.CreatedDate = DateTime.Now;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            categoryTextBox.Clear();
            priceTextBox.Clear();
            stockTextBox.Clear();
            sizeTextBox.Clear();
            colorTextBox.Clear();
            brandTextBox.Clear();
            descriptionTextBox.Clear();
            HideError();
        }

        private void previewButton_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            UpdateProductFromInputs();

            string preview = $"Название: {currentProduct.Name}\n" +
                             $"Категория: {currentProduct.Category}\n" +
                             $"Цена: {currentProduct.Price:C}\n" +
                             $"Количество: {currentProduct.StockQuantity}\n" +
                             $"Размер: {currentProduct.Size?.ToString() ?? "не указан"}\n" +
                             $"Цвет: {currentProduct.Color ?? "не указан"}\n" +
                             $"Бренд: {currentProduct.Brand ?? "не указан"}\n" +
                             $"Описание: {currentProduct.Description ?? "не указан"}";

            MessageBox.Show(preview, "Предпросмотр товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void generateIdButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Сгенерированный ID: {Guid.NewGuid()}", "Генерация ID", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void loadSampleDataButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "Кроссовки Nike Air";
            categoryTextBox.Text = "Обувь";
            priceTextBox.Text = "4999.99";
            stockTextBox.Text = "15";
            sizeTextBox.Text = "42";
            colorTextBox.Text = "Черный";
            brandTextBox.Text = "Nike";
            descriptionTextBox.Text = "Легкие и удобные кроссовки для бега";
            HideError();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {
            HideError();
        }

        private void categoryTextBox_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void priceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
                e.KeyChar = ',';
        }

        private void priceTextBox_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(priceTextBox.Text, out decimal value))
                priceTextBox.Text = value.ToString("F2");
        }

        private void stockTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void sizeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void colorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void brandTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
