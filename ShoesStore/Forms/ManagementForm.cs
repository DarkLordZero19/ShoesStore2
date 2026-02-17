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
        private List<Product> currentProducts; 
        private List<Order> currentOrders;
        private List<OrderItem> currentOrderItems;

        public ManagementForm()
        {
            InitializeComponent();
            context = new DataContext();
            currentProducts = new List<Product>();
            currentOrders = new List<Order>();
            currentOrderItems = new List<OrderItem>();
        }

        public ManagementForm(User user, string initialTab) : this()
        {
            currentUser = user;
            ConfigureTabsBasedOnRole();
            SelectTab(initialTab);
        }

        private void ConfigureTabsBasedOnRole()
        {
            if (currentUser == null) return;

            switch (currentUser.Role)
            {
                case "Client":
                    ordersTab.Parent = null;
                    break;
                case "Manager":
                    createOrderTab.Parent = null;
                    break;
                case "Admin":
                    break;
                case "Guest":
                    ordersTab.Parent = null;
                    createOrderTab.Parent = null;
                    break;
            }
        }

        private void SelectTab(string tabName)
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

        #region Вкладка "Управление товарами"

        private void LoadProducts()
        {
            try
            {
                statusLabel.Text = "Загрузка товаров...";
                string category = categoryFilterComboBox.SelectedItem?.ToString();
                if (category == "Все категории") category = null;
                string search = productSearchTextBox.Text.Trim();
                string sort = productSortComboBox.SelectedItem?.ToString();

                currentProducts = context.GetProducts(category, search, sort);
                productsDataGridView.DataSource = null;
                productsDataGridView.DataSource = currentProducts;

                productsDataGridView.Columns["Id"].HeaderText = "ID";
                productsDataGridView.Columns["Name"].HeaderText = "Название";
                productsDataGridView.Columns["Price"].HeaderText = "Цена";
                productsDataGridView.Columns["Quantity"].HeaderText = "Остаток";
                productsDataGridView.Columns["Category"].HeaderText = "Категория";
                productsDataGridView.Columns["Description"].HeaderText = "Описание";

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
                }
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

        private void categoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void productSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void addProductButton_Click(object sender, EventArgs e)
        {
            ProductEditForm editForm = new ProductEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadProducts();
                FillCategoryFilter();
            }
        }

        private void editProductButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите товар для редактирования.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
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
                DialogResult result = MessageBox.Show($"Удалить товар \"{selected.Name}\"?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.DeleteProduct(selected.Id);
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

        private void LoadOrders()
        {
            try
            {
                statusLabel.Text = "Загрузка заказов...";
                string statusFilter = orderStatusFilterComboBox.SelectedItem?.ToString();
                if (statusFilter == "Все") statusFilter = null;
                string search = orderSearchTextBox.Text.Trim();

                currentOrders = context.GetOrders(null, null, null, statusFilter);

                if (!string.IsNullOrEmpty(search))
                {
                    currentOrders = currentOrders.Where(o =>
                        o.Id.ToString().Contains(search) ||
                        GetUserLogin(o.UserId).IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0
                    ).ToList();
                }

                var displayOrders = currentOrders.Select(o => new
                {
                    o.Id,
                    Дата = o.OrderDate.ToString("dd.MM.yyyy HH:mm"),
                    Клиент = GetUserLogin(o.UserId),
                    Статус = o.Status,
                    Сумма = CalculateOrderTotal(o.Id).ToString("C2")
                }).ToList();

                ordersDataGridView.DataSource = null;
                ordersDataGridView.DataSource = displayOrders;

                ordersStatsLabel.Text = $"Всего заказов: {currentOrders.Count}";
                statusLabel.Text = "Готово";
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
            var items = context.GetOrderItems(orderId);
            return items.Sum(i => i.Price * i.Quantity);
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

                    currentOrderItems = context.GetOrderItems(orderId);
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

        private void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите заказ для удаления.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dynamic selected = ordersDataGridView.SelectedRows[0].DataBoundItem;
            if (selected != null)
            {
                int orderId = selected.Id;
                DialogResult result = MessageBox.Show($"Удалить заказ №{orderId}?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        context.DeleteOrder(orderId);
                        LoadOrders();
                        statusLabel.Text = "Заказ удалён";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                createOrderProductPriceLabel.Text = selected.Price.ToString("C2");
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
                decimal total = selected.Price * quantity;
                createOrderTotalLabel.Text = total.ToString("C2");
            }
        }

        private void createOrderTotalLabel_Click(object sender, EventArgs e)
        {

        }

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

            try
            {
                Order newOrder = new Order
                {
                    UserId = currentUser.Id,
                    OrderDate = DateTime.Now,
                    Status = "New"
                };

                List<OrderItem> items = new List<OrderItem>
        {
            new OrderItem
            {
                ProductId = selectedProduct.Id,
                Quantity = quantity,
                Price = selectedProduct.Price
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