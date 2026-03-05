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
    public partial class OrderEditForm : Form
    {
        private DataContext context;
        private Order currentOrder;
        private bool isNewOrder;
        private List<User> clients;
        public OrderEditForm()
        {
            try
            {
                InitializeComponent();
                context = new DataContext();
                isNewOrder = true;
                currentOrder = null;
                LoadClients();
                LoadStatuses();
                // Тут устанавливаем флажок нового заказа, а также очищаем поле даты выдачи (по умолчанию не выбрано)
                issueDatePicker.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации формы: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public OrderEditForm(Order order) : this()
        {
            if (order != null)
            {
                currentOrder = order;
                isNewOrder = false;
                LoadOrderData();
            }
        }

        private void LoadClients()
        {
            try
            {
                clients = context.GetAllClients();
                clientComboBox.DisplayMember = "FullName";
                clientComboBox.ValueMember = "Id";
                clientComboBox.DataSource = clients;
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
            // Поиск и выбор клиента в списке по идентификатору
            for (int i = 0; i < clientComboBox.Items.Count; i++)
            {
                User user = clientComboBox.Items[i] as User;
                if (user != null && user.Id == currentOrder.UserId)
                {
                    clientComboBox.SelectedIndex = i;
                    break;
                }
            }
            // При редактировании запрещаем менять клиента
            clientComboBox.Enabled = false;

            statusComboBox.SelectedItem = currentOrder.Status;
            if (currentOrder.DeliveryAddress != null)
                deliveryAddressTextBox.Text = currentOrder.DeliveryAddress;
            else
                deliveryAddressTextBox.Text = "";
            orderDatePicker.Value = currentOrder.OrderDate;
            // Если дата выдачи указана, то устанавливаем флажок и значение, иначе снимаем флажок
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

        // Считываем данные из полей формы в объект Order
        private bool CollectOrderData(out Order order)
        {
            order = new Order();

            if (clientComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (statusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус заказа.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            order.UserId = ((User)clientComboBox.SelectedItem).Id;
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
                    // При добавлении нового заказа создаём его без позиций (пустой список)
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
                clientComboBox.SelectedIndex = -1;
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
    }
}
