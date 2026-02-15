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
        public enum ManagementMode
        {
            Products,
            Orders,
            CreateOrder
        }

        private DataContext context;
        private Users currentUser;
        private List<Products> allProducts;
        private List<Orders> allOrders;
        private List<Users> allUsers;
        private ManagementMode currentMode;
        public ManagementForm(Users user, ManagementMode mode = ManagementMode.Products)
        {
            InitializeComponent();
            context = new DataContext();
            currentUser = user;
            currentMode = mode;
            allProducts = new List<Products>();
            allOrders = new List<Orders>();
            allUsers = new List<Users>();

            SelectTab(mode);
            ConfigureAccessByRole();
            LoadAllDataAsync();
        }
        private void SelectTab(ManagementMode mode)
        {
            switch (mode)
            {
                case ManagementMode.Products:
                    if (productsTab != null)
                        productsTab.Select();
                    break;
                case ManagementMode.Orders:
                    if (ordersTab != null)
                        ordersTab.Select();
                    break;
                case ManagementMode.CreateOrder:
                    if (createOrderTab != null)
                        createOrderTab.Select();
                    break;
            }
        }

        private async void LoadAllDataAsync()
        {
            try
            {
                StatusLabel.Text = "Загрузка данных...";
                allProducts = await context.GetProductsAsync(new List<Products>());
                allOrders = await context.GetOrdersAsync(new List<Orders>());
                allUsers = await context.GetUsersAsync(new List<Users>());

                RefreshProductsGrid();
                RefreshOrdersGrid();
                FillCreateOrderProductCombo();

                StatusLabel.Text = "Данные загружены";
            }
            catch (Exception ex)
            {
                StatusLabel.Text = "Ошибка загрузки";
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureAccessByRole()
        {
            bool isAdmin = currentUser.Role == Users.RoleType.Admin;
            bool isManager = currentUser.Role == Users.RoleType.Manager;
            bool isClient = currentUser.Role == Users.RoleType.Client;

            addProductButton.Enabled = isClient || isAdmin || isManager;
            editProductButton.Enabled = isClient || isAdmin || isManager;
            deleteProductButton.Enabled = isClient || isAdmin;

            deleteOrderButton.Enabled = isClient || isAdmin;

            createOrderTab.Enabled = isClient || isManager || isAdmin;
        }

        private void RefreshProductsGrid()
        {
            var filtered = ApplyProductFilters(allProducts);
            productsDataGridView.DataSource = null;
            productsDataGridView.DataSource = filtered;

            productsDataGridView.Columns["ID"].Visible = false;
            productsDataGridView.Columns["Description"].Visible = false;
            productsDataGridView.Columns["CreatedDate"].Visible = false;

            productsStatsLabel.Text = $"Всего товаров: {filtered.Count}";
        }

        private List<Products> ApplyProductFilters(List<Products> source)
        {
            IEnumerable<Products> query = source;

            string search = productSearchTextBox.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(p => p.Name.ToLower().Contains(search) ||
                                         p.Description.ToLower().Contains(search) ||
                                         p.Brand.ToLower().Contains(search));

            if (categoryFilterComboBox.SelectedItem != null && categoryFilterComboBox.SelectedItem.ToString() != "Все")
            {
                string cat = categoryFilterComboBox.SelectedItem.ToString();
                query = query.Where(p => p.Category == cat);
            }

            if (productSortComboBox.SelectedItem != null)
            {
                string sort = productSortComboBox.SelectedItem.ToString();
                if (sort == "Цена (возр.)") query = query.OrderBy(p => p.Price);
                else if (sort == "Цена (уб.)") query = query.OrderByDescending(p => p.Price);
                else if (sort == "Название") query = query.OrderBy(p => p.Name);
            }

            return query.ToList();
        }

        private void RefreshOrdersGrid()
        {
            var filtered = ApplyOrderFilters(allOrders);
            ordersDataGridView.DataSource = null;
            ordersDataGridView.DataSource = filtered;

            ordersDataGridView.Columns["ID"].Visible = false;
            ordersDataGridView.Columns["UserId"].Visible = false;
            ordersDataGridView.Columns["ProductId"].Visible = false;
            ordersDataGridView.Columns["Notes"].Visible = false;
            ordersDataGridView.Columns["ShippingAddress"].Visible = false;
            ordersDataGridView.Columns["Phone"].Visible = false;

            ordersStatsLabel.Text = $"Всего заказов: {filtered.Count}";
        }

        private List<Orders> ApplyOrderFilters(List<Orders> source)
        {
            IEnumerable<Orders> query = source;

            string search = orderSearchTextBox.Text.Trim().ToLower();
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(o =>
                {
                    var user = allUsers.FirstOrDefault(u => u.ID == o.UserId);
                    bool userNameContains = false;
                    if (user != null && user.UserName != null)
                    {
                        userNameContains = user.UserName.ToLower().Contains(search);
                    }
                    return userNameContains || o.Id.ToString().Contains(search);
                });
            }

            if (orderStatusFilterComboBox.SelectedItem != null && orderStatusFilterComboBox.SelectedItem.ToString() != "Все")
            {
                string status = orderStatusFilterComboBox.SelectedItem.ToString();
                query = query.Where(o => o.Status == status);
            }

            return query.ToList();
        }

        private void FillCreateOrderProductCombo()
        {
            createOrderProductComboBox.DataSource = null;
            createOrderProductComboBox.DataSource = allProducts;
            createOrderProductComboBox.DisplayMember = "Name";
            createOrderProductComboBox.ValueMember = "ID";
        }

        private void UpdateCreateOrderDetails()
        {
            if (createOrderProductComboBox.SelectedItem is Products selected)
            {
                createOrderProductPriceLabel.Text = selected.Price.ToString("C");
                createOrderProductStockLabel.Text = selected.StockQuantity.ToString();

                orderSizeComboBox.Items.Clear();
                if (selected.Size.HasValue)
                    orderSizeComboBox.Items.Add(selected.Size.Value);
                else
                    orderSizeComboBox.Items.Add("Стандарт");
                orderSizeComboBox.SelectedIndex = 0;

                orderQuantityComboBox.Items.Clear();
                int max = Math.Min(10, selected.StockQuantity);
                for (int i = 1; i <= max; i++)
                    orderQuantityComboBox.Items.Add(i);
                if (orderQuantityComboBox.Items.Count > 0)
                    orderQuantityComboBox.SelectedIndex = 0;

                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            if (createOrderProductComboBox.SelectedItem is Products product &&
                orderQuantityComboBox.SelectedItem != null)
            {
                int qty = (int)orderQuantityComboBox.SelectedItem;
                decimal total = product.Price * qty;
                createOrderTotalLabel.Text = total.ToString("C");
            }
        }

        private void productsStatsLabel_Click(object sender, EventArgs e)
        {

        }

        private void productsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count > 0)
            {
                var row = productsDataGridView.SelectedRows[0];
                if (row.DataBoundItem is Products p)
                {
                    productNameLabel.Text = p.Name;
                    productCategoryLabel.Text = p.Category;
                    productPriceLabel.Text = p.Price.ToString("C");
                    productStockLabel.Text = p.StockQuantity.ToString();

                    if (p.Size.HasValue)
                        productSizeLabel.Text = p.Size.Value.ToString();
                    else
                        productSizeLabel.Text = "-";

                    if (p.Color != null)
                        productColorLabel.Text = p.Color;
                    else
                        productColorLabel.Text = "-";

                    if (p.Brand != null)
                        productBrandLabel.Text = p.Brand;
                    else
                        productBrandLabel.Text = "-";

                    if (p.Description != null)
                        productDescriptionLabel.Text = p.Description;
                    else
                        productDescriptionLabel.Text = "-";
                }
            }
        }

        private void productSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                applyProductFiltersButton.PerformClick();
        }

        private void searchProductButton_Click(object sender, EventArgs e)
        {
            applyProductFiltersButton.PerformClick();
        }

        private void categoryFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyProductFiltersButton.PerformClick();
        }

        private void productSortComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyProductFiltersButton.PerformClick();
        }

        private void applyProductFiltersButton_Click(object sender, EventArgs e)
        {
            RefreshProductsGrid();
        }

        private void resetProductFiltersButton_Click(object sender, EventArgs e)
        {
            productSearchTextBox.Clear();
            categoryFilterComboBox.SelectedIndex = -1;
            productSortComboBox.SelectedIndex = -1;
            RefreshProductsGrid();
        }

        private void refreshProductsButton_Click(object sender, EventArgs e)
        {
            LoadAllDataAsync();
        }

        private async void addProductButton_Click(object sender, EventArgs e)
        {
            using (var editForm = new ProductEditForm(new Products(), true))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await context.AddProductAsync(editForm.Product);
                        LoadAllDataAsync();
                        StatusLabel.Text = "Товар добавлен";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void editProductButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count == 0) return;
            var product = productsDataGridView.SelectedRows[0].DataBoundItem as Products;
            if (product == null) return;

            using (var editForm = new ProductEditForm(product, false))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        await context.UpdateProductAsync(editForm.Product);
                        LoadAllDataAsync();
                        StatusLabel.Text = "Товар обновлён";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void deleteProductButton_Click(object sender, EventArgs e)
        {
            if (productsDataGridView.SelectedRows.Count == 0) return;
            var product = productsDataGridView.SelectedRows[0].DataBoundItem as Products;
            if (product == null) return;

            var confirm = MessageBox.Show($"Удалить товар {product.Name}?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await context.DeleteProductAsync(product.ID);
                    LoadAllDataAsync();
                    StatusLabel.Text = "Товар удалён";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void productSizeLabel_Click(object sender, EventArgs e)
        {

        }

        private void productColorLabel_Click(object sender, EventArgs e)
        {

        }

        private void productBrandLabel_Click(object sender, EventArgs e)
        {

        }

        private void productDescriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void ordersStatsLabel_Click(object sender, EventArgs e)
        {

        }

        private void ordersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (ordersDataGridView.SelectedRows.Count > 0)
            {
                var row = ordersDataGridView.SelectedRows[0];
                if (row.DataBoundItem is Orders o)
                {
                    orderIdLabel.Text = o.Id.ToString().Substring(0, 8) + "...";
                    orderDateLabel.Text = o.OrderDate.ToShortDateString();

                    var user = allUsers.FirstOrDefault(u => u.ID == o.UserId);
                    if (user != null && user.UserName != null)
                        orderCustomerLabel.Text = user.UserName;
                    else
                        orderCustomerLabel.Text = "Неизвестно";

                    var product = allProducts.FirstOrDefault(p => p.ID == o.ProductId);
                    if (product != null && product.Name != null)
                        orderProductLabel.Text = product.Name;
                    else
                        orderProductLabel.Text = "Неизвестно";

                    orderQuantityLabel.Text = o.Quantity.ToString();
                    orderTotalLabelDetails.Text = o.TotalPrice.ToString("C");
                    orderStatusLabel.Text = o.Status;

                    if (o.ShippingAddress != null)
                        orderAddressLabel.Text = o.ShippingAddress;
                    else
                        orderAddressLabel.Text = "-";

                    if (o.Phone != null)
                        orderPhoneLabel.Text = o.Phone;
                    else
                        orderPhoneLabel.Text = "-";

                    if (o.Notes != null)
                        orderNotesLabel.Text = o.Notes;
                    else
                        orderNotesLabel.Text = "-";
                }
            }
        }

        private void orderSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                applyOrderFiltersButton.PerformClick();
        }

        private void searchOrderButton_Click(object sender, EventArgs e)
        {
            applyOrderFiltersButton.PerformClick();
        }

        private void orderStatusFilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applyOrderFiltersButton.PerformClick();
        }

        private void applyOrderFiltersButton_Click(object sender, EventArgs e)
        {
            RefreshOrdersGrid();
        }

        private void resetOrderFiltersButton_Click(object sender, EventArgs e)
        {
            orderSearchTextBox.Clear();
            orderStatusFilterComboBox.SelectedIndex = -1;
            RefreshOrdersGrid();
        }

        private void refreshOrdersButton_Click(object sender, EventArgs e)
        {
            LoadAllDataAsync();
        }

        private async void deleteOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersDataGridView.SelectedRows.Count == 0) return;
            var order = ordersDataGridView.SelectedRows[0].DataBoundItem as Orders;
            if (order == null) return;

            var confirm = MessageBox.Show("Удалить заказ?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    await context.DeleteOrderAsync(order.Id);
                    LoadAllDataAsync();
                    StatusLabel.Text = "Заказ удалён";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void orderAddressLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderPhoneLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderNotesLabel_Click(object sender, EventArgs e)
        {

        }

        private void createOrderProductComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCreateOrderDetails();
        }

        private void createOrderProductPriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void createOrderProductStockLabel_Click(object sender, EventArgs e)
        {

        }

        private void orderSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void orderQuantityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void createOrderTotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void createOrderAddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void createOrderPhoneTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void createOrderNotesTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private async void createOrderButton_Click(object sender, EventArgs e)
        {
            if (createOrderProductComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите товар", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (orderQuantityComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(createOrderAddressTextBox.Text))
            {
                MessageBox.Show("Введите адрес доставки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(createOrderPhoneTextBox.Text))
            {
                MessageBox.Show("Введите телефон", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var product = createOrderProductComboBox.SelectedItem as Products;
            int qty = (int)orderQuantityComboBox.SelectedItem;
            decimal total = product.Price * qty;

            var order = new Orders(
                currentUser,
                product,
                qty,
                total,
                "Pending",
                createOrderNotesTextBox.Text,
                createOrderAddressTextBox.Text,
                createOrderPhoneTextBox.Text
            );

            try
            {
                await context.AddOrderAsync(order);
                MessageBox.Show("Заказ оформлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadAllDataAsync();
                createOrderNotesTextBox.Clear();
                createOrderAddressTextBox.Clear();
                createOrderPhoneTextBox.Clear();
                StatusLabel.Text = "Заказ создан";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshAllButton_Click(object sender, EventArgs e)
        {
            LoadAllDataAsync();
        }

        private void productsTab_Click(object sender, EventArgs e)
        {

        }

        private void StatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void ordersTab_Click(object sender, EventArgs e)
        {

        }

        private void createOrderTab_Click(object sender, EventArgs e)
        {

        }
    }
}