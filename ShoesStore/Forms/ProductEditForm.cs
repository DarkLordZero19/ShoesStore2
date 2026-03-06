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
        // ID нового товара генерируется базой данных, при редактировании ID только для чтения
        private bool isNewProduct;
        private User currentUser;
        public ProductEditForm()
        {
            try
            {
                InitializeComponent();
                context = new DataContext();
                LoadComboBoxes();
                isNewProduct = true;
                currentProduct = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации формы: {ex.Message}", "Критическая ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        public ProductEditForm(Product product, User user) : this()
        {
            try
            {
                currentUser = user;
                if (user != null)
                {
                    // Отображение ФИО пользователя
                    if (!string.IsNullOrEmpty(user.FullName))
                        userFullNameLabel.Text = user.FullName;
                    else
                        userFullNameLabel.Text = user.Login;
                }
                if (product != null)
                {
                    currentProduct = product;
                    isNewProduct = false;
                    LoadProductData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка списков категорий и производителей из существующих товаров
        private void LoadComboBoxes()
        {
            try
            {
                var products = context.GetAllProducts();
                // Выбираем уникальные категории
                var categories = products.Select(p => p.Category)
                                          .Where(c => !string.IsNullOrEmpty(c))
                                          .Distinct()
                                          .OrderBy(c => c)
                                          .ToList();
                categoryComboBox.Items.Clear();
                categoryComboBox.Items.AddRange(categories.ToArray());

                // Выбираем уникальные производители
                var manufacturers = products.Select(p => p.Manufacturer)
                                             .Where(m => !string.IsNullOrEmpty(m))
                                             .Distinct()
                                             .OrderBy(m => m)
                                             .ToList();
                manufacturerComboBox.Items.Clear();
                manufacturerComboBox.Items.AddRange(manufacturers.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadProductData()
        {
            if (currentProduct == null) return;

            try
            {
                nameTextBox.Text = currentProduct.Name;
                if (currentProduct.Category != null)
                    categoryComboBox.Text = currentProduct.Category;
                else
                    categoryComboBox.Text = "";
                priceTextBox.Text = currentProduct.Price.ToString("F2");
                stockTextBox.Text = currentProduct.Quantity.ToString();
                if (currentProduct.Description != null)
                    descriptionTextBox.Text = currentProduct.Description;
                else
                    descriptionTextBox.Text = "";
                if (currentProduct.Category != null)
                    categoryComboBox.Text = currentProduct.Category;
                else
                    categoryComboBox.Text = "";

                if (currentProduct.Manufacturer != null)
                    manufacturerComboBox.Text = currentProduct.Manufacturer;
                else
                    manufacturerComboBox.Text = "";

                if (currentProduct.Supplier != null)
                    supplierTextBox.Text = currentProduct.Supplier;
                else
                    supplierTextBox.Text = "";

                if (currentProduct.Unit != null)
                    unitTextBox.Text = currentProduct.Unit;
                else
                    unitTextBox.Text = "";

                discountTextBox.Text = currentProduct.Discount.ToString("F2");

                if (currentProduct.ImagePath != null)
                    imagePathTextBox.Text = currentProduct.ImagePath;
                else
                    imagePathTextBox.Text = "";
                LoadImagePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных в поля: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private bool CollectProductData(out Product product)
        {
            product = new Product();

            try
            {
                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("Введите название товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nameTextBox.Focus();
                    return false;
                }
                product.Name = nameTextBox.Text.Trim();
                if (!string.IsNullOrWhiteSpace(categoryComboBox.Text))
                    product.Category = categoryComboBox.Text.Trim();
                else
                    product.Category = null;

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

                if (!string.IsNullOrWhiteSpace(descriptionTextBox.Text))
                    product.Description = descriptionTextBox.Text.Trim();
                else
                    product.Description = null;
                if (!string.IsNullOrWhiteSpace(manufacturerComboBox.Text))
                    product.Manufacturer = manufacturerComboBox.Text.Trim();
                else
                    product.Manufacturer = null;

                if (!string.IsNullOrWhiteSpace(supplierTextBox.Text))
                    product.Supplier = supplierTextBox.Text.Trim();
                else
                    product.Supplier = null;

                if (!string.IsNullOrWhiteSpace(unitTextBox.Text))
                    product.Unit = unitTextBox.Text.Trim();
                else
                    product.Unit = null;

                if (!decimal.TryParse(discountTextBox.Text, out decimal discount) || discount < 0 || discount > 100)
                {
                    MessageBox.Show("Введите корректную скидку (от 0 до 100).", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    discountTextBox.Focus();
                    return false;
                }
                product.Discount = discount;

                if (!string.IsNullOrWhiteSpace(imagePathTextBox.Text))
                    product.ImagePath = imagePathTextBox.Text.Trim();
                else
                    product.ImagePath = null;

                if (!isNewProduct && currentProduct != null)
                    product.Id = currentProduct.Id;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сборе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Предварительный просмотр изображения и заглушка, если файл не найден
        private void LoadImagePreview()
        {
            try
            {
                if (pictureBoxPreview.Image != null && pictureBoxPreview.Image != Properties.Resources.picture)
                {
                    pictureBoxPreview.Image.Dispose();
                    pictureBoxPreview.Image = null;
                }

                if (!string.IsNullOrEmpty(imagePathTextBox.Text) && System.IO.File.Exists(imagePathTextBox.Text))
                {
                    try
                    {
                        // Загружаем изображение через поток, чтобы не блокировать файл
                        using (FileStream fs = new FileStream(imagePathTextBox.Text, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            pictureBoxPreview.Image = Image.FromStream(fs);
                        }
                    }
                    catch
                    {
                        pictureBoxPreview.Image = Properties.Resources.picture;
                    }
                }
                else
                {
                    pictureBoxPreview.Image = Properties.Resources.picture; // Заглушка из файлов
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение изображения с изменением размера до 300x200
        private string SaveImageToAppFolder(string sourcePath, int productId)
        {
            try
            {
                // Папка для изображений
                string appFolder = Path.GetDirectoryName(Application.ExecutablePath);
                string imagesFolder = Path.Combine(appFolder, "Images");
                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                // Генерируем уникальное имя
                string fileName = $"{Guid.NewGuid()}.jpg";
                string destPath = Path.Combine(imagesFolder, fileName);

                // Загружаем изображение и изменяем размер до 300x200
                using (var image = Image.FromFile(sourcePath))
                {
                    int newWidth = 300;
                    int newHeight = 200;
                    var resized = new Bitmap(newWidth, newHeight);
                    using (var g = Graphics.FromImage(resized))
                    {
                        g.DrawImage(image, 0, 0, newWidth, newHeight);
                    }
                    resized.Save(destPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                return "Images\\" + fileName; // Относительный путь для БД
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // Удаление старого изображения при замене или удалении товара
        private void DeleteOldImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath)) return;
            try
            {
                string fullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), imagePath);
                if (File.Exists(fullPath))
                    File.Delete(fullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления изображения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Сохранение товара и отработка изображения перед сохранением
        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CollectProductData(out Product product))
                    return;

                // Обработка изображения
                if (!string.IsNullOrEmpty(imagePathTextBox.Text) && File.Exists(imagePathTextBox.Text))
                {
                    string newImagePath = SaveImageToAppFolder(imagePathTextBox.Text, product.Id);
                    if (newImagePath != null)
                    {
                        // Если редактируем и было старое изображение, то удаляем
                        if (!isNewProduct && currentProduct != null && !string.IsNullOrEmpty(currentProduct.ImagePath))
                        {
                            DeleteOldImage(currentProduct.ImagePath);
                        }
                        product.ImagePath = newImagePath;
                    }
                }
                else
                {
                    // Если поле пути пустое, то удаляем старое изображение
                    if (!isNewProduct && currentProduct != null && !string.IsNullOrEmpty(currentProduct.ImagePath))
                    {
                        DeleteOldImage(currentProduct.ImagePath);
                    }
                    product.ImagePath = null;
                }
                
                // Сохранение в БД
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
            try
            {
                nameTextBox.Clear();
                categoryComboBox.SelectedIndex = -1;
                priceTextBox.Clear();
                stockTextBox.Clear();
                descriptionTextBox.Clear();
                manufacturerComboBox.SelectedIndex = -1;
                supplierTextBox.Clear();
                unitTextBox.Clear();
                discountTextBox.Text = "0";
                imagePathTextBox.Clear();
                LoadImagePreview();
                nameTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при очистке полей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Предпросмотр товара в окне сообщения
        private void previewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CollectProductData(out Product product))
                {
                    string categoryDisplay;
                    if (product.Category != null)
                        categoryDisplay = product.Category;
                    else
                        categoryDisplay = "—";

                    string manufacturerDisplay;
                    if (product.Manufacturer != null)
                        manufacturerDisplay = product.Manufacturer;
                    else
                        manufacturerDisplay = "—";

                    string supplierDisplay;
                    if (product.Supplier != null)
                        supplierDisplay = product.Supplier;
                    else
                        supplierDisplay = "—";

                    string unitDisplay;
                    if (product.Unit != null)
                        unitDisplay = product.Unit;
                    else
                        unitDisplay = "шт";

                    string descriptionDisplay;
                    if (product.Description != null)
                        descriptionDisplay = product.Description;
                    else
                        descriptionDisplay = "—";

                    string imagePathDisplay;
                    if (product.ImagePath != null)
                        imagePathDisplay = product.ImagePath;
                    else
                        imagePathDisplay = "—";

                    string info = $"Название: {product.Name}\n" +
                                  $"Категория: {categoryDisplay}\n" +
                                  $"Производитель: {manufacturerDisplay}\n" +
                                  $"Поставщик: {supplierDisplay}\n" +
                                  $"Цена: {product.Price:C2}\n" +
                                  $"Скидка: {product.Discount}%\n" +
                                  $"Цена со скидкой: {product.DiscountedPrice:C2}\n" +
                                  $"Количество: {product.Quantity} {unitDisplay}\n" +
                                  $"Описание: {descriptionDisplay}\n" +
                                  $"Путь к изображению: {imagePathDisplay}";
                    MessageBox.Show(info, "Предпросмотр товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка предпросмотра: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Генерация ID
        private void generateIdButton_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                priceTextBox.Text = (rnd.Next(500, 10000) / 100m).ToString("F2");
                stockTextBox.Text = rnd.Next(1, 100).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка генерации данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Загрузка тестовых данных
        private void loadSampleDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                nameTextBox.Text = "Кроссовки Nike Air Max";
                categoryComboBox.Text = "Кроссовки";
                priceTextBox.Text = "7500";
                stockTextBox.Text = "15";
                descriptionTextBox.Text = "Легкие и удобные кроссовки для повседневной носки.";
                manufacturerComboBox.Text = "Nike";
                supplierTextBox.Text = "Спортмастер";
                unitTextBox.Text = "пара";
                discountTextBox.Text = "10";
                imagePathTextBox.Text = "";
                LoadImagePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки тестовых данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Добавление изображения любого формата
        private void browseImageButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        imagePathTextBox.Text = ofd.FileName;
                        LoadImagePreview();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nameTextBox_Enter(object sender, EventArgs e)
        {

        }

        private void categoryComboBox_DropDown(object sender, EventArgs e)
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
        private void manufacturerComboBox_DropDown(object sender, EventArgs e)
        {

        }
        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}