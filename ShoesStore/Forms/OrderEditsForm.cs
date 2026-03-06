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
using ShoesStore.Data;
using ShoesStore.Forms;

namespace ShoesStore.Forms
{
    public partial class OrderEditsForm : Form
    {
        private DataContext context;
        private BindingList<User> clients;
        private Order currentOrder;
        private bool isNewOrder;
        private User currentUser;

        public OrderEditsForm()
        {
            try
            {
                InitializeComponent();
                context = new DataContext();
                isNewOrder = true;
                currentOrder = null;
                LoadClients();
                LoadStatuses();
                issueDatePicker.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации формы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            clientDataGridView.DataSource = clients;
        }

        public OrderEditsForm(Order order, User user) : this()
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
                if (order != null)
                {
                    currentOrder = order;
                    isNewOrder = false;
                    LoadOrderData();
                }
                ConfigureButtonBasedOnRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void ConfigureButtonBasedOnRole()
        {
            try
            {
                if (currentUser == null) return;
                // По умолчанию скрываем кнопки управления товарами
                saveButton.Visible = false;
                ClearButton.Visible = false;

                switch (currentUser.Role)
                {
                    case "Client":
                        saveButton.Visible = false;
                        ClearButton.Visible = false;
                        break;
                    case "Manager":
                        saveButton.Visible = false;
                        ClearButton.Visible = false;
                        break;
                    case "Admin":
                        saveButton.Visible = true;
                        ClearButton.Visible = true;
                        break;
                    case "Guest":
                        saveButton.Visible = false;
                        ClearButton.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке ролей: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadClients()
        {
            try
            {
                List<User> allClients = context.GetAllClients();
                clients = new BindingList<User>(allClients);

                clientDataGridView.DataSource = null;
                clientDataGridView.DataSource = clients;

                if (clientDataGridView.Columns["Id"] != null)
                    clientDataGridView.Columns["Id"].Visible = false;

                if (clientDataGridView.Columns["Password"] != null)
                    clientDataGridView.Columns["Password"].Visible = false;

                if (clientDataGridView.Columns["Role"] != null)
                    clientDataGridView.Columns["Role"].Visible = false;

                clientDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                clientDataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStatuses()
        {
            statusComboBox.Items.Clear();
            statusComboBox.Items.AddRange(new string[] { "New", "Processing", "Completed", "Cancelled" });
            statusComboBox.SelectedIndex = 0;
        }

        private void LoadOrderData()
        {
            if (currentOrder == null) return;

            idLabel.Text = currentOrder.Id.ToString();

            for (int i = 0; i < clientDataGridView.Rows.Count; i++)
            {
                DataGridViewRow row = clientDataGridView.Rows[i];
                User user = row.DataBoundItem as User;
                if (user != null && user.Id == currentOrder.UserId)
                {
                    clientDataGridView.Rows[i].Selected = true;
                    break;
                }
            }

            clientDataGridView.Enabled = false;

            statusComboBox.SelectedItem = currentOrder.Status;
            if (currentOrder.DeliveryAddress != null)
                deliveryAddressTextBox.Text = currentOrder.DeliveryAddress;
            else
                deliveryAddressTextBox.Text = "";
            orderDatePicker.Value = currentOrder.OrderDate;

            if (currentOrder.IssueDate.HasValue)
            {
                issueDatePicker.Checked = true;
                issueDatePicker.Value = currentOrder.IssueDate.Value;
            }
            else
            {
                issueDatePicker.Checked = false;
            }
        }

        private void OrderEditsForm_Load(object sender, EventArgs e)
        {

        }

        private bool CollectOrderData(out Order order)
        {
            order = new Order();
            if (clientDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            User selectedClient = clientDataGridView.SelectedRows[0].DataBoundItem as User;
            if (selectedClient == null)
            {
                MessageBox.Show("Ошибка получения данных клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (statusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            order.UserId = selectedClient.Id;
            order.Status = statusComboBox.SelectedItem.ToString();
            order.DeliveryAddress = deliveryAddressTextBox.Text.Trim();
            order.OrderDate = orderDatePicker.Value;

            if (issueDatePicker.Checked)
                order.IssueDate = issueDatePicker.Value;
            else
                order.IssueDate = null;

            if (!isNewOrder && currentOrder != null)
                order.Id = currentOrder.Id;

            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!CollectOrderData(out Order order))
                return;
            try
            {
                if (isNewOrder)
                {
                    context.AddOrder(order, new List<OrderItem>());
                    MessageBox.Show("Заказ успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    context.UpdateOrder(order);
                    MessageBox.Show("Заказ успешно обновлён.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                DialogResult = DialogResult.OK;
                Close();
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
                clientDataGridView.ClearSelection();
                statusComboBox.SelectedIndex = 0;
                deliveryAddressTextBox.Clear();
                orderDatePicker.Value = DateTime.Now;
                issueDatePicker.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при очистке полей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void clientDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                deliveryAddressTextBox.Focus();
            }
        }
    }
}
