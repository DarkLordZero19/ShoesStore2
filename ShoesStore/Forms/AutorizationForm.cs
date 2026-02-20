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

namespace ShoesStore.Forms
{
    public partial class AutorizationForm : Form
    {
        private DataContext context;
        public AutorizationForm()
        {
            InitializeComponent();
            context = new DataContext();
        }

        private void usernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void guestButton_Click(object sender, EventArgs e)
        {
            User guestUser = new User
            {
                Id = -1,
                Login = "guest",
                Password = "",
                Role = "Guest"
            };
            OpenMainForm(guestUser);
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            string login = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                context.RegisterUser(login, password);
                MessageBox.Show("Регистрация прошла успешно. Теперь вы можете войти.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string login = usernameTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User user = context.GetUser(login, password);
            if (user != null)
            {
                OpenMainForm(user);
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void OpenMainForm(User user)
        {
            MainForm mainForm = new MainForm(user);
            mainForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            mainForm.Show();
        }
    }
}
