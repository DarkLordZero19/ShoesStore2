using Microsoft.VisualBasic.ApplicationServices;
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
        private List<Users> users = new List<Users>();
        private Users currentUser;
        public AutorizationForm()
        {
            InitializeComponent();
            context = new DataContext();
            LoadUsersAsync();
        }

        private async void LoadUsersAsync()
        {
            try
            {
                users = await context.GetUsersAsync(new List<Users>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки пользователей: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guestbtn_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем гостевого пользователя
                currentUser = new Users("Guest", "", Users.RoleType.Client);

                // Открываем главную форму для гостя
                var mainForm = new MainForm(currentUser);
                mainForm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка при входе как гость: {ex.Message}");
            }
        }

        private async void Registrationbtn_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение полей
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                ShowError("Введите имя пользователя для регистрации");
                UsernameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                ShowError("Введите пароль для регистрации");
                PasswordTextBox.Focus();
                return;
            }

            try
            {
                SetControlsEnabled(false);
                HideError();

                string username = UsernameTextBox.Text.Trim();
                string password = PasswordTextBox.Text;

                // Проверяем, не занято ли имя пользователя
                if (await IsUsernameTaken(username))
                {
                    ShowError("Пользователь с таким именем уже существует");
                    UsernameTextBox.Focus();
                    return;
                }

                // Создаем нового пользователя (по умолчанию Client)
                currentUser = new Users(username, password, Users.RoleType.Client);

                // Сохраняем в БД
                await context.SaveUserAsync(currentUser);

                // Добавляем в список
                users.Add(currentUser);

                MessageBox.Show("Регистрация успешно завершена! Теперь вы можете войти.",
                    "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Очищаем поля для входа
                PasswordTextBox.Clear();
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка регистрации: {ex.Message}");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }

        private async void Loginbtn_Click(object sender, EventArgs e)
        {
            // Проверяем заполнение полей
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text))
            {
                ShowError("Введите имя пользователя");
                UsernameTextBox.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(PasswordTextBox.Text))
            {
                ShowError("Введите пароль");
                PasswordTextBox.Focus();
                return;
            }

            try
            {
                // Отключаем кнопки на время проверки
                SetControlsEnabled(false);
                HideError();

                // Ищем пользователя в БД
                currentUser = await AuthenticateUser(
                    UsernameTextBox.Text.Trim(),
                    PasswordTextBox.Text
                );

                if (currentUser != null)
                {
                    // Успешная авторизация
                    var mainForm = new MainForm(currentUser);
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    ShowError("Неверное имя пользователя или пароль");
                    PasswordTextBox.Clear();
                    PasswordTextBox.Focus();
                }
            }
            catch (Exception ex)
            {
                ShowError($"Ошибка авторизации: {ex.Message}");
            }
            finally
            {
                SetControlsEnabled(true);
            }
        }
        private async Task<Users> AuthenticateUser(string username, string password)
        {
            // Если список пуст загружаем пользователей
            if (users.Count == 0)
            {
                users = await context.GetUsersAsync(new List<Users>());
            }

            // Ищем пользователя
            return users.FirstOrDefault(u =>
                u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);
        }

        private async Task<bool> IsUsernameTaken(string username)
        {
            if (users.Count == 0)
            {
                users = await context.GetUsersAsync(new List<Users>());
            }

            return users.Any(u =>
                u.UserName.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        private void SetControlsEnabled(bool enabled)
        {
            UsernameTextBox.Enabled = enabled;
            PasswordTextBox.Enabled = enabled;
            Guestbtn.Enabled = enabled;
            Registrationbtn.Enabled = enabled;
            Loginbtn.Enabled = enabled;
        }

        private void ShowError(string message)
        {
            if (ErrorLabel != null)
            {
                ErrorLabel.Text = message;
                ErrorLabel.ForeColor = System.Drawing.Color.Red;
                ErrorLabel.Visible = true;
            }
            else
            {
                MessageBox.Show(message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HideError()
        {
            if (ErrorLabel != null)
            {
                ErrorLabel.Visible = false;
            }
        }

        private void UsernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PasswordTextBox.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void PasswordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Loginbtn.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Вы действительно хотите выйти?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            base.OnFormClosing(e);
        }
    }
}
