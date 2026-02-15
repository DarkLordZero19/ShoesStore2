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
        private Users currentUser;
        public MainForm(Users user)
        {
            InitializeComponent();
            context = new DataContext();
            currentUser = user;

            this.Text = $"Магазин обуви - {user.UserName} ({user.Role})";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            ConfigurePanelsByRole();
        }

        private void ConfigurePanelsByRole()
        {
            ClientPanel.Visible = true;
            ManagerPanel.Visible = true;
            AdminPanel.Visible = true;

            switch (currentUser.Role)
            {
                case Users.RoleType.Admin:
                    AdminPanel.Visible = true;
                    ManagerPanel.Visible = true;
                    ClientPanel.Visible = true;
                    break;

                case Users.RoleType.Manager:
                    ManagerPanel.Visible = true;
                    ClientPanel.Visible = true;
                    break;

                case Users.RoleType.Client:
                case Users.RoleType.Guest:
                    ClientPanel.Visible = true;
                    break;
            }
        }
        private void BuyProductbtn_Click(object sender, EventArgs e)
        {
            OpenManagementForm(ManagementMode.CreateOrder);
        }

        private void ManageControlProductbtn_Click(object sender, EventArgs e)
        {
            OpenManagementForm(ManagementMode.Products);
        }

        private void ManageControlOrdersbtn_Click(object sender, EventArgs e)
        {
            OpenManagementForm(ManagementMode.Orders);
        }

        private void Exportbtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Функция экспорта в разработке", "Информация",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AdminControlProductbtn_Click(object sender, EventArgs e)
        {
            OpenManagementForm(ManagementMode.Products);
        }

        private void AdminControlOrdersbtn_Click(object sender, EventArgs e)
        {
            OpenManagementForm(ManagementMode.Orders);
        }

        private void Closebtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenManagementForm(ManagementMode mode)
        {
            try
            {
                var managementForm = new ManagementForm(currentUser, mode);
                managementForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Вы действительно хотите выйти?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    Application.Exit();
                else
                    e.Cancel = true;
            }
            base.OnFormClosing(e);
        }
        private void ClientPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ManagerPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
