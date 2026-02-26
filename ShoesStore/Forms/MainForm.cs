using ShoesStore.Data;
using ShoesStore.Forms;
using ShoesStore.Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ShoesStore.Forms.ManagementForm;

namespace ShoesStore.Forms
{
    public partial class MainForm : Form
    {
        private DataContext context;
        private User currentUser;
        public MainForm()
        {
            try
            {
                InitializeComponent();
                context = new DataContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации приложения: {ex.Message}\nПриложение будет закрыто.",
                    "Критическая ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
        public MainForm(User user) : this()
        {
            currentUser = user;
            if (user != null)
            {
                if (!string.IsNullOrEmpty(user.FullName))
                    userFullNameLabel.Text = user.FullName;
                else
                    userFullNameLabel.Text = user.Login;
            }
            ConfigureUIBasedOnRole();
        }

        // Настройка видимости панелей в зависимости от роли пользователя
        private void ConfigureUIBasedOnRole()
        {
            try
            {
                clientPanel.Visible = false;
                managerPanel.Visible = false;
                adminPanel.Visible = false;

                if (currentUser == null) return;

                switch (currentUser.Role)
                {
                    case "Client":
                        clientPanel.Visible = true;
                        break;
                    case "Manager":
                        clientPanel.Visible = true;
                        managerPanel.Visible = true;
                        break;
                    case "Admin":
                        adminPanel.Visible = true;
                        managerPanel.Visible = true;
                        clientPanel.Visible = true;
                        break;
                    case "Guest":
                        clientPanel.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка настройки интерфейса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Открытие формы управления с указанием нужной вкладки
        private void OpenManagementForm(string initialTab)
        {
            try
            {
                ManagementForm mgmtForm = new ManagementForm(currentUser, initialTab);
                // Модальное окно
                mgmtForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии формы управления: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buyProductButton_Click(object sender, EventArgs e)
        {
            OpenManagementForm("Purchase");
        }

        private void manageControlProductButton_Click(object sender, EventArgs e)
        {
            OpenManagementForm("Products");
        }

        private void manageControlOrdersButton_Click(object sender, EventArgs e)
        {
            OpenManagementForm("Orders");
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Экспорт будет доступен позже.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void adminControlProductButton_Click(object sender, EventArgs e)
        {
            OpenManagementForm("Products");
        }

        private void adminControlOrdersButton_Click(object sender, EventArgs e)
        {
            OpenManagementForm("Orders");
        }

        private void clientPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void managerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void adminPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
