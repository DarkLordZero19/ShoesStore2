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
            Registrationbtn = new Button();
            Loginbtn = new Button();
            UsernameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Guestbtn = new Button();
            ErrorLabel = new Label();
            SuspendLayout();
            // 
            // Registrationbtn
            // 
            Registrationbtn.BackColor = SystemColors.ButtonHighlight;
            Registrationbtn.Location = new Point(257, 308);
            Registrationbtn.Name = "Registrationbtn";
            Registrationbtn.Size = new Size(102, 49);
            Registrationbtn.TabIndex = 0;
            Registrationbtn.Text = "Регистрация";
            Registrationbtn.UseVisualStyleBackColor = false;
            Registrationbtn.Click += Registrationbtn_Click;
            // 
            // Loginbtn
            // 
            Loginbtn.BackColor = SystemColors.ButtonHighlight;
            Loginbtn.Location = new Point(404, 308);
            Loginbtn.Name = "Loginbtn";
            Loginbtn.Size = new Size(107, 49);
            Loginbtn.TabIndex = 1;
            Loginbtn.Text = "Логин";
            Loginbtn.UseVisualStyleBackColor = false;
            Loginbtn.Click += Loginbtn_Click;
            // 
            // UsernameTextBox
            // 
            UsernameTextBox.Location = new Point(257, 164);
            UsernameTextBox.Name = "UsernameTextBox";
            UsernameTextBox.Size = new Size(254, 23);
            UsernameTextBox.TabIndex = 2;
            UsernameTextBox.KeyDown += UsernameTextBox_KeyDown;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(257, 233);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(254, 23);
            PasswordTextBox.TabIndex = 3;
            PasswordTextBox.KeyDown += PasswordTextBox_KeyDown;
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
            // Guestbtn
            // 
            Guestbtn.BackColor = SystemColors.ButtonHighlight;
            Guestbtn.Location = new Point(257, 262);
            Guestbtn.Name = "Guestbtn";
            Guestbtn.Size = new Size(254, 23);
            Guestbtn.TabIndex = 7;
            Guestbtn.Text = "Кнопка гостя";
            Guestbtn.UseVisualStyleBackColor = false;
            Guestbtn.Click += Guestbtn_Click;
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new Point(12, 431);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(61, 15);
            ErrorLabel.TabIndex = 8;
            ErrorLabel.Text = "ShowError";
            // 
            // AutorizationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(803, 466);
            Controls.Add(ErrorLabel);
            Controls.Add(Guestbtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTextBox);
            Controls.Add(UsernameTextBox);
            Controls.Add(Loginbtn);
            Controls.Add(Registrationbtn);
            Name = "AutorizationForm";
            Text = "AutorizationForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Registrationbtn;
        private Button Loginbtn;
        private TextBox UsernameTextBox;
        private TextBox PasswordTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button Guestbtn;
        private Label ErrorLabel;
    }
}