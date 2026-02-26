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
            try
            {
                // Создание гостевого пользователя, Id = -1 означает отсутствие в БД
                User guestUser = new User
                {
                    Id = -1,
                    Login = "guest",
                    Password = "",
                    Role = "Guest"
                };
                OpenMainForm(guestUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе как гость: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

            try
            {
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
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при входе: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // После успешной авторизации скрываем форму входа и показываем главную
        private void OpenMainForm(User user)
        {
            try
            {
                MainForm mainForm = new MainForm(user);
                // При закрытии главной формы снова показываем окно входа
                mainForm.FormClosed += (s, args) => this.Show();
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии главного окна: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
            }
        }
    }
}