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
            InitializeComponent();
            context = new DataContext();
        }
        public MainForm(User user) : this()
        {
            currentUser = user;
            ConfigureUIBasedOnRole();
        }

        private void ConfigureUIBasedOnRole()
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
        private void OpenManagementForm(string initialTab)
        {
            ManagementForm mgmtForm = new ManagementForm(currentUser, initialTab);
            mgmtForm.ShowDialog();
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
            MessageBox.Show("Экспорт будет доступен позже.");
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
