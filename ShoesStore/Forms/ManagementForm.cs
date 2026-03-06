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
    public partial class ManagementForm : Form
    {
        private DataContext context;
        private User currentUser;
        // Привязка данных через BindingList для автоматического обновления интерфейса
        private BindingList<Product> currentProducts;
        private BindingList<Order> currentOrders;
        private BindingList<OrderItem> currentOrderItems;
        private BindingList<User> clients;

        public ManagementForm()
        {
            try
            {
                InitializeComponent();
                context = new DataContext();
                currentProducts = new BindingList<Product>();
                currentOrders = new BindingList<Order>();
                currentOrderItems = new BindingList<OrderItem>();

                // Заполнение списка сортировки
                productSortComboBox.Items.AddRange(new string[]{
                    "Без сортировки",
                    "Цена (по возрастанию)",
                    "Цена (по убыванию)",
                    "Название (А-Я)",
                    "Название (Я-А)",
                    "Количество (по возрастанию)",
                    "Количество (по убыванию)"
                });
                productSortComboBox.SelectedIndex = 0;

                // Форматирования картинки
                productsDataGridView.CellFormatting += productsDataGridView_CellFormatting;
                productsDataGridView.RowPrePaint += productsDataGridView_RowPrePaint;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации формы: {ex.Message}", "Критическая ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public ManagementForm(User user, string initialTab) : this()
        {
            try
            {
                currentUser = user;
                if (user != null)
                {
                    if (!string.IsNullOrEmpty(user.FullName))
                        userFullNameLabel.Text = user.FullName;
                    else
                        userFullNameLabel.Text = user.Login;
                }
                ConfigureTabsBasedOnRole();
                SelectTab(initialTab);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigureTabsBasedOnRole()
        {
            try
            {
                if (currentUser == null) return;
                // По умолчанию скрываем кнопки управления товарами
                addProductButton.Visible = false;
                editProductButton.Visible = false;
                deleteProductButton.Visible = false;

                // По умолчанию скрываем кнопки управления заказами
                addOrderButton.Visible = false;
                editOrderButton.Visible = false;
                deleteOrderButton.Visible = false;

                switch (currentUser.Role)
                {
                    case "Client":
                        ordersTab.Parent = null;
                        break;
                    case "Manager":
                        createOrderTab.Parent = null;
                        addOrderButton.Visible = false;
                        editOrderButton.Visible = false;
                        deleteOrderButton.Visible = false;
                        break;
                    case "Admin":
                        addProductButton.Visible = true;
                        editProductButton.Visible = true;
                        deleteProductButton.Visible = true;
                        addOrderButton.Visible = true;
                        editOrderButton.Visible = true;
                        deleteOrderButton.Visible = true;
                        break;
                    case "Guest":
                        ordersTab.Parent = null;
                        createOrderTab.Parent = null;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке ролей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectTab(string tabName)
        {
            try
            {
                switch (tabName)
                {
                    case "Products":
                        tabControl1.SelectedTab = productsTab;
                        LoadProducts();
                        break;
                    case "Orders":
                        tabControl1.SelectedTab = ordersTab;
                        LoadOrders();
                        break;
                    case "Purchase":
                        tabControl1.SelectedTab = createOrderTab;
                        LoadProductsForPurchase();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выборе вкладки: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Вкладка "Управление товарами"

        // Загрузка товаров с учётом фильтров и сортировки
        private void LoadProducts()
        {
            try
            {
                statusLabel.Text = "Загрузка товаров...";
                string category = categoryFilterComboBox.SelectedItem?.ToString();
                if (category == "Все категории") category = null;
                string supplier = supplierFilterComboBox.SelectedItem?.ToString();
                if (supplier == "Все поставщики") supplier = null;
                string search = productSearchTextBox.Text.Trim();
                string sort = productSortComboBox.SelectedItem?.ToString();
                string sortParam = null;
                switch (sort)
                {
                    case "Цена (по возрастанию)": sortParam = "PriceASC"; break;
                    case "Цена (по убыванию)": sortParam = "PriceDESC"; break;
                    case "Название (А-Я)": sortParam = "NameASC"; break;
                    case "Название (Я-А)": sortParam = "NameDESC"; break;
                    case "Количество (по возрастанию)": sortParam = "QuantityASC"; break;
                    case "Количество (по убыванию)": sortParam = "QuantityDESC"; break;
                    default: sortParam = ""; break;
                }

                List<Product> products = context.GetProducts(category, supplier, search, sortParam);

                // Получение данных
                currentProducts = new BindingList<Product>(products);
                productsDataGridView.DataSource = null;
                productsDataGridView.DataSource = currentProducts;

                // Скрываем технические столбцы
                productsDataGridView.Columns["Id"].Visible = false;
                productsDataGridView.Columns["ImagePath"].Visible = false;

                // Добавляем столбец для изображения, если его ещё нет
                if (!productsDataGridView.Columns.Contains("ImageColumn"))
                {
                    DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                    imageCol.Name = "ImageColumn";
                    imageCol.HeaderText = "Фото";
                    imageCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    imageCol.Width = 80;
                    // Настройка
                    productsDataGridView.Columns.Insert(0, imageCol);
                }

                productsStatsLabel.Text = $"Всего товаров: {currentProducts.Count}";
                statusLabel.Text = "Готово";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ошибка загрузки";
            }
        }

        private void FillCategoryFilter()
        {
            try
            {
                var categories = context.GetAllProducts()
                                        .Select(p => p.Category)
                                        .Where(c => !string.IsNullOrEmpty(c))
                                        .Distinct()
                                        .OrderBy(c => c)
                                        .ToList();
                categoryFilterComboBox.Items.Clear();
                categoryFilterComboBox.Items.Add("Все категории");
                foreach (var cat in categories)
                {
                    categoryFilterComboBox.Items.Add(cat);
                }
                categoryFilterComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки категорий: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void productsStatsLabel_Click(object sender, EventArgs e)
        {

        }

        private void productsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (productsDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = productsDataGridView.SelectedRows[0];
                    Product selected = row.DataBoundItem as Product;
                    if (selected != null)
                    {
                        productNameLabel.Text = selected.Name;

                        if (selected.Category != null)
                            productCategoryLabel.Text = selected.Category;
                        else
                            productCategoryLabel.Text = "—";

                        productPriceLabel.Text = selected.Price.ToString("C2");
                        productStockLabel.Text = selected.Quantity.ToString();

                        if (selected.Description != null)
                            productDescriptionLabel.Text = selected.Description;
                        else
                            productDescriptionLabel.Text = "—";

                        if (selected.Manufacturer != null)
                            productManufacturerLabel.Text = selected.Manufacturer;
                        else
                            productManufacturerLabel.Text = "—";

                        if (selected.Supplier != null)
                            productSupplierLabel.Text = selected.Supplier;
                        else
                            productSupplierLabel.Text = "—";

                        if (selected.Unit != null)
                            productUnitLabel.Text = selected.Unit;
                        else
                            productUnitLabel.Text = "—";

                        productDiscountLabel.Text = selected.Discount.ToString("F2") + "%";
                        productDiscountedPriceLabel.Text = selected.DiscountedPrice.ToString("C2");
                    }
                }
                else
                {
                    ClearProductDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке деталей товара: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearProductDetails();
            }
        }

        // Вспомогательный метод для очистки всех полей
        private void ClearProductDetails()
        {
            productNameLabel.Text = "—";
            productCategoryLabel.Text = "—";
            productPriceLabel.Text = "—";
            productStockLabel.Text = "—";
            productDescriptionLabel.Text = "—";
            productManufacturerLabel.Text = "—";
            productSupplierLabel.Text = "—";
            productUnitLabel.Text = "—";
            productDiscountLabel.Text = "—";
            productDiscountedPriceLabel.Text = "—";
        }

        // Подсветка строк в зависимости от остатка и скидки
        private void productsDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= productsDataGridView.Rows.Count) return;

            DataGridViewRow row = productsDataGridView.Rows[e.RowIndex];
            Product product = row.DataBoundItem as Product;
            if (product == null) return;

            // Цвет фона строки
            if (product.Quantity == 0)
            {
                row.DefaultCellStyle.BackColor = Color.LightBlue; // Нет на складе
            }
            else if (product.Discount > 15)
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(0x2E, 0x8B, 0x57); // #2E8B57, Скидка >15%
            }
            else
            {
                row.DefaultCellStyle.BackColor = productsDataGridView.DefaultCellStyle.BackColor;
            }
        }
        // Отображение изображения в отдельном столбце
        private void productsDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = productsDataGridView.Rows[e.RowIndex];
            Product product = row.DataBoundItem as Product;
            if (product == null) return;

            if (productsDataGridView.Columns[e.ColumnIndex].Name == "ImageColumn")
            {
                // Загружаем изображение из файла или ставим заглушку
                if (!string.IsNullOrEmpty(product.ImagePath) && System.IO.File.Exists(product.ImagePath))
                {
                    try
                    {
                        // Загружаем изображение через поток, чтобы не блокировать файл
                        using (FileStream fs = new FileStream(product.ImagePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            e.Value = Image.FromStream(fs);
                        }
                    }
                    catch
                    {
                        e.Value = Properties.Resources.picture; // заглушка
                    }
                }
                else
                {
                    e.Value = Properties.Resources.picture;
                }
                e.FormattingApplied = true;
            }

            // Столбец "Цена", перечёркивание цены при наличии скидки
            if (productsDataGridView.Columns[e.ColumnIndex].Name == "Price" && product.Discount > 0)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);
                e.CellStyle.ForeColor = Color.Red;
            }

            // Столбец "Цена со скидкой", отображаем только если есть скидка
            if (productsDataGridView.Columns[e.ColumnIndex].Name == "DiscountedPrice")
            {
                if (product.Discount > 0)
                {
                    e.Value = product.DiscountedPrice.ToString("C2");
                    e.CellStyle.ForeColor = Color.Black;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Regular);
                }
                else
                {
                    e.Value = "";
                }
                e.FormattingApplied = true;
            }
        }

        private void productSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchProductButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void searchProductButton_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void productSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void categoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void supplierFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }
        private void productSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void applyProductFiltersButton_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void resetProductFiltersButton_Click(object sender, EventArgs e)
        {
            productSearchTextBox.Clear();
            if (categoryFilterComboBox.Items.Count > 0)
                categoryFilterComboBox.SelectedIndex = 0;
            if (productSortComboBox.Items.Count > 0)
                productSortComboBox.SelectedIndex = 0;
            LoadProducts();
        }

        private void refreshProductsButton_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void FillSupplierFilter()
        {
            try
            {
                var suppliers = context.GetAllProducts()
                                       .Select(p => p.Supplier)
                                       .Where(s => !string.IsNullOrEmpty(s))
                                       .Distinct()
                                       .OrderBy(s => s)
                                       .ToList();
                supplierFilterComboBox.Items.Clear();
                supplierFilterComboBox.Items.Add("Все поставщики");
                foreach (var sup in suppliers)
                {
                    supplierFilterComboBox.Items.Add(sup);
                }
                supplierFilterComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки поставщиков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                ProductEditForm editForm = new ProductEditForm(null);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadProducts();
                    FillCategoryFilter();
                    FillSupplierFilter();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (productsDataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите товар для редактирования.", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Product selected = productsDataGridView.SelectedRows[0].DataBoundItem as Product;
                if (selected != null)
                {
                    ProductEditForm editForm = new ProductEditForm(selected);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadProducts();
                        FillCategoryFilter();
                        FillSupplierFilter();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при редактировании товара: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Product selected = productsDataGridView.SelectedRows[0].DataBoundItem as Product;
            if (selected != null)
            {
                if (context.IsProductUsedInOrders(selected.Id))
                {
                    MessageBox.Show("Невозможно удалить товар, так как он присутствует в заказах.\nСначала удалите связанные заказы.",
                        "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show($"Удалить товар \"{selected.Name}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Сохраняем путь к изображению перед удалением из БД
                        string imagePath = selected.ImagePath;

                        context.DeleteProduct(selected.Id);

                        // Удаляем файл изображения, если он существует
                        if (!string.IsNullOrEmpty(imagePath))
                        {
                            string fullPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), imagePath);
                            if (File.Exists(fullPath))
                                File.Delete(fullPath);
                        }

                        LoadProducts();
                        FillCategoryFilter();
                        statusLabel.Text = "Товар удалён";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void productNameLabel_Click(object sender, EventArgs e)
        {

        }

        private void productCategoryLabel_Click(object sender, EventArgs e)
        {

        }

        private void productPriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void productStockLabel_Click(object sender, EventArgs e)
        {

        }

        private void productDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Вкладка "Управление заказами"

        // Вспомогательный метод для очистки деталей заказа
        private void ClearOrderDetails()
        {
            orderIdLabel.Text = "—";
            orderDateLabel.Text = "—";
            orderCustomerLabel.Text = "—";
            orderProductLabel.Text = "—";
            orderQuantityLabel.Text = "—";
            orderTotalLabelDetails.Text = "—";
            orderStatusLabel.Text = "—";
            orderAddressLabel.Text = "—";
            orderIssueDateLabel.Text = "—";
        }

        private void LoadOrders()
        {
            try
            {
                statusLabel.Text = "Загрузка заказов...";
                string statusFilter = orderStatusFilterComboBox.SelectedItem?.ToString();
                if (statusFilter == "Все") statusFilter = null;
                string search = orderSearchTextBox.Text.Trim();

                List<Order> orders = context.GetOrders(null, null, null, statusFilter);

                if (!string.IsNullOrEmpty(search))
                {
                    orders = orders.Where(o =>
                        o.Id.ToString().Contains(search) ||
                        GetUserLogin(o.UserId).IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();
                }

                currentOrders = new BindingList<Order>(orders);

                var displayOrders = currentOrders.Select(o => new
                {
                    o.Id,
                    Дата = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                    Клиент = GetUserLogin(o.UserId),
                    Статус = o.Status,
                    Адрес = o.DeliveryAddress,
                    Дата_Выдачи = o.IssueDate?.ToString("dd.MM.yyyy"),
                    Сумма = CalculateOrderTotal(o.Id).ToString("C2")
                }).ToList();

                ordersDataGridView.DataSource = null;
                ordersDataGridView.DataSource = displayOrders;
                if (ordersDataGridView.Columns["Id"] != null)
                    ordersDataGridView.Columns["Id"].Visible = false;

                ordersStatsLabel.Text = $"Всего заказов: {currentOrders.Count}";
                statusLabel.Text = "Готово";

                // Если после загрузки нет строк, то очищаем детали
                if (orders.Count == 0)
                    ClearOrderDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки заказов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Ошибка загрузки";
            }
        }

        private string GetUserLogin(int userId)
        {
            switch (userId)
            {
                case 1: return "admin";
                case 2: return "manager";
                case 3: return "client";
                default: return $"User{userId}";
            }
        }

        private decimal CalculateOrderTotal(int orderId)
        {
            try
            {
                var items = context.GetOrderItems(orderId);
                return items.Sum(i => i.Price * i.Quantity);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчёте суммы заказа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
        private void FillStatusFilter()
        {
            orderStatusFilterComboBox.Items.Clear();
            orderStatusFilterComboBox.Items.Add("Все");
            orderStatusFilterComboBox.Items.Add("New");
            orderStatusFilterComboBox.Items.Add("Processing");
            orderStatusFilterComboBox.Items.Add("Completed");
            orderStatusFilterComboBox.Items.Add("Cancelled");
            orderStatusFilterComboBox.SelectedIndex = 0;
        }

        private void ordersStatsLabel_Click(object sender, EventArgs e)
        {

        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ordersDataGridView.SelectedRows.Count > 0)
                {
                    dynamic selected = ordersDataGridView.SelectedRows[0].DataBoundItem;
                    int orderId = selected.Id;
                    Order order = currentOrders.FirstOrDefault(o => o.Id == orderId);
                    if (order != null)
                    {
                        orderIdLabel.Text = order.Id.ToString();
                        orderDateLabel.Text = order.OrderDate.ToString("dd.MM.yyyy HH:mm");
                        orderCustomerLabel.Text = GetUserLogin(order.UserId);
                        orderStatusLabel.Text = order.Status;

                        if (!string.IsNullOrEmpty(order.DeliveryAddress))
                            orderAddressLabel.Text = order.DeliveryAddress;
                        else
                            orderAddressLabel.Text = "—";

                        if (order.IssueDate.HasValue)
                            orderIssueDateLabel.Text = order.IssueDate.Value.ToString("dd.MM.yyyy");
                        else
                            orderIssueDateLabel.Text = "—";

                        List<OrderItem> items = context.GetOrderItems(orderId);
                        currentOrderItems = new BindingList<OrderItem>(items);
                        orderTotalLabelDetails.Text = currentOrderItems.Sum(i => i.Price * i.Quantity).ToString("C2");

                        if (currentOrderItems.Count > 0)
                        {
                            var firstItem = currentOrderItems[0];
                            Product product = context.GetAllProducts().FirstOrDefault(p => p.Id == firstItem.ProductId);
                            if (product != null)
                                orderProductLabel.Text = product.Name;
                            else
                                orderProductLabel.Text = $"Товар {firstItem.ProductId}";
                            orderQuantityLabel.Text = firstItem.Quantity.ToString();
                        }
                        else
                        {
                            orderProductLabel.Text = "—";
                            orderQuantityLabel.Text = "0";
                        }
                    }
                }
                else
                {
                    ClearOrderDetails();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке деталей заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearOrderDetails();
            }
        }

        private void orderSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchOrderButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void searchOrderButton_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void orderStatusFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void applyOrderFiltersButton_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void resetOrderFiltersButton_Click(object sender, EventArgs e)
        {
            orderSearchTextBox.Clear();
            orderStatusFilterComboBox.SelectedIndex = 0;
            LoadOrders();
        }

        private void refreshOrdersButton_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void addOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderEditsForm editForm = new OrderEditsForm(null, currentUser);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOrders();
                    FillStatusFilter();
                    if (ordersDataGridView.Rows.Count > 0)
                    {
                        ordersDataGridView.Rows[ordersDataGridView.Rows.Count - 1].Selected = true;
                    }
                    else
                    {
                        ClearOrderDetails();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы добавления заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ordersDataGridView.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Выберите заказ для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dynamic selected = ordersDataGridView.SelectedRows[0].DataBoundItem;
                int orderId = selected.Id;
                Order order = currentOrders.FirstOrDefault(o => o.Id == orderId);
                if (order != null)
                {
                    OrderEditsForm editForm = new OrderEditsForm(order, currentUser);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadOrders();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы редактирования заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dynamic selected = ordersDataGridView.SelectedRows[0].DataBoundItem;
            int orderId = selected.Id;

            DialogResult result = MessageBox.Show($"Удалить заказ №{orderId}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    context.DeleteOrder(orderId);
                    LoadOrders();
                    LoadProducts();
                    statusLabel.Text = "Заказ удалён";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void orderIdLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderDateLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderCustomerLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderProductLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderQuantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderTotalLabelDetails_Click(object sender, EventArgs e)
        {

        }

        private void orderStatusLabel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Вкладка "Покупка Товара"

        private List<Product> availableProducts;

        private void LoadProductsForPurchase()
        {
            try
            {
                availableProducts = context.GetAllProducts().Where(p => p.Quantity > 0).ToList();
                createOrderProductComboBox.DataSource = null;
                createOrderProductComboBox.DisplayMember = "Name";
                createOrderProductComboBox.ValueMember = "Id";
                createOrderProductComboBox.DataSource = availableProducts;

                if (availableProducts.Count > 0)
                {
                    createOrderProductComboBox.SelectedIndex = 0;
                }
                else
                {
                    createOrderProductPriceLabel.Text = "0";
                    createOrderProductStockLabel.Text = "0";
                    createOrderTotalLabel.Text = "0";
                }
                // Очистка полей адреса и даты
                deliveryAddressTextBox.Clear();
                issueDatePicker.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки товаров: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createOrderProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (createOrderProductComboBox.SelectedItem is Product selected)
            {
                createOrderProductPriceLabel.Text = selected.DiscountedPrice.ToString("C2");
                createOrderProductStockLabel.Text = selected.Quantity.ToString();

                orderQuantityComboBox.Items.Clear();
                for (int i = 1; i <= selected.Quantity; i++)
                {
                    orderQuantityComboBox.Items.Add(i);
                }
                if (orderQuantityComboBox.Items.Count > 0)
                {
                    orderQuantityComboBox.SelectedIndex = 0;
                }

                UpdateTotalPrice();
            }
        }

        private void createOrderProductPriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void createOrderProductStockLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderQuantityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateTotalPrice();
        }

        private void UpdateTotalPrice()
        {
            if (createOrderProductComboBox.SelectedItem is Product selected &&
                orderQuantityComboBox.SelectedItem != null)
            {
                int quantity = (int)orderQuantityComboBox.SelectedItem;
                decimal total = selected.DiscountedPrice * quantity;
                createOrderTotalLabel.Text = total.ToString("C2");
            }
        }

        private void createOrderTotalLabel_Click(object sender, EventArgs e)
        {

        }

        // Создание заказа с использованием цены со скидкой
        private void createOrderButton_Click(object sender, EventArgs e)
        {
            if (currentUser == null || currentUser.Role == "Guest")
            {
                MessageBox.Show("Только авторизованные клиенты могут оформлять заказы.", "Доступ запрещён", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (createOrderProductComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (orderQuantityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите количество.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Product selectedProduct = createOrderProductComboBox.SelectedItem as Product;
            int quantity = (int)orderQuantityComboBox.SelectedItem;

            if (quantity > selectedProduct.Quantity)
            {
                MessageBox.Show("Недостаточно товара на складе.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверка адреса
            string deliveryAddress = deliveryAddressTextBox.Text.Trim();
            if (string.IsNullOrEmpty(deliveryAddress))
            {
                MessageBox.Show("Введите адрес доставки.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                deliveryAddressTextBox.Focus();
                return;
            }

            try
            {
                Order newOrder = new Order
                {
                    UserId = currentUser.Id,
                    OrderDate = DateTime.Now,
                    Status = "New",
                    DeliveryAddress = deliveryAddress,
                    IssueDate = issueDatePicker.Checked ? issueDatePicker.Value : (DateTime?)null
                };

                List<OrderItem> items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductId = selectedProduct.Id,
                        Quantity = quantity,
                        Price = selectedProduct.DiscountedPrice // Сохраняем цену со скидкой
                    }
                };

                context.AddOrder(newOrder, items);

                MessageBox.Show("Заказ успешно оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadProductsForPurchase();
                if (tabControl1.TabPages.Contains(productsTab))
                    LoadProducts();

                statusLabel.Text = "Заказ оформлен";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Общие элементы

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refreshAllButton_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == productsTab)
                LoadProducts();
            else if (tabControl1.SelectedTab == ordersTab)
                LoadOrders();
            else if (tabControl1.SelectedTab == createOrderTab)
                LoadProductsForPurchase();
        }

        private void statusLabel_Click(object sender, EventArgs e)
        {

        }

        private void productsTab_Click(object sender, EventArgs e)
        {

        }

        private void ordersTab_Click(object sender, EventArgs e)
        {

        }

        private void createOrderTab_Click(object sender, EventArgs e)
        {

        }

        private void productsTab_Enter(object sender, EventArgs e)
        {
            FillCategoryFilter();
            FillSupplierFilter();
            LoadProducts();
        }

        private void ordersTab_Enter(object sender, EventArgs e)
        {
            FillStatusFilter();
            LoadOrders();
        }

        private void createOrderTab_Enter(object sender, EventArgs e)
        {
            LoadProductsForPurchase();
        }
        #endregion
    }
}