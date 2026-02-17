namespace ShoesStore.Forms
{
    partial class AutorizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            registrationButton = new Button();
            loginButton = new Button();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            guestButton = new Button();
            SuspendLayout();
            // 
            // registrationButton
            // 
            registrationButton.BackColor = SystemColors.ButtonHighlight;
            registrationButton.Location = new Point(257, 308);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new Size(102, 49);
            registrationButton.TabIndex = 0;
            registrationButton.Text = "Регистрация";
            registrationButton.UseVisualStyleBackColor = false;
            registrationButton.Click += registrationButton_Click;
            // 
            // loginButton
            // 
            loginButton.BackColor = SystemColors.ButtonHighlight;
            loginButton.Location = new Point(404, 308);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(107, 49);
            loginButton.TabIndex = 1;
            loginButton.Text = "Логин";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(257, 164);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(254, 23);
            usernameTextBox.TabIndex = 2;
            usernameTextBox.KeyDown += usernameTextBox_KeyDown;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(257, 233);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(254, 23);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.KeyDown += passwordTextBox_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(322, 21);
            label1.Name = "label1";
            label1.Size = new Size(130, 21);
            label1.TabIndex = 4;
            label1.Text = "Магазин обуви";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(257, 136);
            label2.Name = "label2";
            label2.Size = new Size(44, 21);
            label2.TabIndex = 5;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(257, 200);
            label3.Name = "label3";
            label3.Size = new Size(70, 21);
            label3.TabIndex = 6;
            label3.Text = "Пароль";
            // 
            // guestButton
            // 
            guestButton.BackColor = SystemColors.ButtonHighlight;
            guestButton.Location = new Point(257, 262);
            guestButton.Name = "guestButton";
            guestButton.Size = new Size(254, 23);
            guestButton.TabIndex = 7;
            guestButton.Text = "Кнопка гостя";
            guestButton.UseVisualStyleBackColor = false;
            guestButton.Click += guestButton_Click;
            // 
            // AutorizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 466);
            Controls.Add(guestButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(usernameTextBox);
            Controls.Add(loginButton);
            Controls.Add(registrationButton);
            Name = "AutorizationForm";
            Text = "AutorizationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button registrationButton;
        private Button loginButton;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button guestButton;
    }
}