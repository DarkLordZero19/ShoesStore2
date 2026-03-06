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
                // Дата выдачи по умолчанию не выбрана
                issueDatePicker.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации формы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public OrderEditsForm(Order order, User user) : this()
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
                if (order != null)
                {
                    currentOrder = order;
                    // Режим редактирования
                    isNewOrder = false;
                    LoadOrderData();
                }
                // Настройка видимости кнопок
                ConfigureButtonBasedOnRole();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при настройке формы: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        // Настройка видимости кнопок сохранения и очистки
        private void ConfigureButtonBasedOnRole()
        {
            try
            {
                if (currentUser == null) return;
                // По умолчанию скрываем кнопки управления заказами
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

        // Загрузка списка клиентов из БД и отображение в clientDataGridView
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

                // Автоматическое заполнение ширины столбцов
                clientDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                clientDataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки списка клиентов: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Заполнение списка статусов заказа
        private void LoadStatuses()
        {
            statusComboBox.Items.Clear();
            statusComboBox.Items.AddRange(new string[] { "New", "Processing", "Completed", "Cancelled" });
            statusComboBox.SelectedIndex = 0;
        }

        // Загрузка данных выбранного заказа в поля формы
        private void LoadOrderData()
        {
            if (currentOrder == null) return;

            // Поиск и выделение клиента в таблице по его Id
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

            // При редактировании запрещаем менять клиента
            clientDataGridView.Enabled = false;

            statusComboBox.SelectedItem = currentOrder.Status;
            if (currentOrder.DeliveryAddress != null)
                deliveryAddressTextBox.Text = currentOrder.DeliveryAddress;
            else
                deliveryAddressTextBox.Text = "";
            orderDatePicker.Value = currentOrder.OrderDate;

            // Если дата выдачи указана, устанавливаем флажок и значение, иначе снимаем
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

        // Сбор данных из полей формы в объект Order для сохранения
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

            // Если флажок даты выдачи установлен, сохраняем выбранную дату, иначе null
            if (issueDatePicker.Checked)
                order.IssueDate = issueDatePicker.Value;
            else
                order.IssueDate = null;

            // Если это редактирование, передаём идентификатор заказа
            if (!isNewOrder && currentOrder != null)
                order.Id = currentOrder.Id;

            return true;
        }

        // Сохранить заказ
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!CollectOrderData(out Order order))
                return;
            try
            {
                if (isNewOrder)
                {
                    // Для нового заказа создаём без позиций (пустой список)
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

        // Сброс всех полей заказа
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
