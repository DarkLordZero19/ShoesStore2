namespace ShoesStore.Forms
{
    partial class MainForm
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
            Closebtn = new Button();
            ClientPanel = new Panel();
            BuyProductbtn = new Button();
            label1 = new Label();
            ManagerPanel = new Panel();
            ManageControlOrdersbtn = new Button();
            ManageControlProductbtn = new Button();
            label2 = new Label();
            AdminPanel = new Panel();
            AdminControlOrdersbtn = new Button();
            AdminControlProductbtn = new Button();
            Exportbtn = new Button();
            label3 = new Label();
            ErrorLabel = new Label();
            ClientPanel.SuspendLayout();
            ManagerPanel.SuspendLayout();
            AdminPanel.SuspendLayout();
            SuspendLayout();
            // 
            // Closebtn
            // 
            Closebtn.BackColor = Color.FromArgb(255, 128, 128);
            Closebtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Closebtn.Location = new Point(40, 395);
            Closebtn.Name = "Closebtn";
            Closebtn.Size = new Size(95, 57);
            Closebtn.TabIndex = 0;
            Closebtn.Text = "Выход";
            Closebtn.UseVisualStyleBackColor = false;
            Closebtn.Click += Closebtn_Click;
            // 
            // ClientPanel
            // 
            ClientPanel.Controls.Add(BuyProductbtn);
            ClientPanel.Controls.Add(label1);
            ClientPanel.Location = new Point(68, 41);
            ClientPanel.Name = "ClientPanel";
            ClientPanel.Size = new Size(185, 149);
            ClientPanel.TabIndex = 1;
            ClientPanel.Paint += ClientPanel_Paint;
            // 
            // BuyProductbtn
            // 
            BuyProductbtn.BackColor = SystemColors.ButtonHighlight;
            BuyProductbtn.Location = new Point(13, 53);
            BuyProductbtn.Name = "BuyProductbtn";
            BuyProductbtn.Size = new Size(160, 52);
            BuyProductbtn.TabIndex = 4;
            BuyProductbtn.Text = "Купить товар";
            BuyProductbtn.UseVisualStyleBackColor = false;
            BuyProductbtn.Click += BuyProductbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(23, 19);
            label1.Name = "label1";
            label1.Size = new Size(137, 21);
            label1.TabIndex = 0;
            label1.Text = "Панель клиента";
            // 
            // ManagerPanel
            // 
            ManagerPanel.Controls.Add(ManageControlOrdersbtn);
            ManagerPanel.Controls.Add(ManageControlProductbtn);
            ManagerPanel.Controls.Add(label2);
            ManagerPanel.Location = new Point(361, 41);
            ManagerPanel.Name = "ManagerPanel";
            ManagerPanel.Size = new Size(194, 215);
            ManagerPanel.TabIndex = 2;
            ManagerPanel.Paint += ManagerPanel_Paint;
            // 
            // ManageControlOrdersbtn
            // 
            ManageControlOrdersbtn.BackColor = SystemColors.ButtonHighlight;
            ManageControlOrdersbtn.Location = new Point(24, 124);
            ManageControlOrdersbtn.Name = "ManageControlOrdersbtn";
            ManageControlOrdersbtn.Size = new Size(145, 48);
            ManageControlOrdersbtn.TabIndex = 3;
            ManageControlOrdersbtn.Text = "Управление заказа";
            ManageControlOrdersbtn.UseVisualStyleBackColor = false;
            ManageControlOrdersbtn.Click += ManageControlOrdersbtn_Click;
            // 
            // ManageControlProductbtn
            // 
            ManageControlProductbtn.BackColor = SystemColors.ButtonHighlight;
            ManageControlProductbtn.Location = new Point(24, 53);
            ManageControlProductbtn.Name = "ManageControlProductbtn";
            ManageControlProductbtn.Size = new Size(145, 52);
            ManageControlProductbtn.TabIndex = 2;
            ManageControlProductbtn.Text = "Управление товара";
            ManageControlProductbtn.UseVisualStyleBackColor = false;
            ManageControlProductbtn.Click += ManageControlProductbtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(16, 19);
            label2.Name = "label2";
            label2.Size = new Size(165, 21);
            label2.TabIndex = 0;
            label2.Text = "Панель менеджера";
            // 
            // AdminPanel
            // 
            AdminPanel.Controls.Add(AdminControlOrdersbtn);
            AdminPanel.Controls.Add(AdminControlProductbtn);
            AdminPanel.Controls.Add(Exportbtn);
            AdminPanel.Controls.Add(label3);
            AdminPanel.Location = new Point(675, 41);
            AdminPanel.Name = "AdminPanel";
            AdminPanel.Size = new Size(219, 269);
            AdminPanel.TabIndex = 3;
            AdminPanel.Paint += AdminPanel_Paint;
            // 
            // AdminControlOrdersbtn
            // 
            AdminControlOrdersbtn.BackColor = SystemColors.ButtonHighlight;
            AdminControlOrdersbtn.Location = new Point(19, 190);
            AdminControlOrdersbtn.Name = "AdminControlOrdersbtn";
            AdminControlOrdersbtn.Size = new Size(175, 48);
            AdminControlOrdersbtn.TabIndex = 5;
            AdminControlOrdersbtn.Text = "Управление заказа";
            AdminControlOrdersbtn.UseVisualStyleBackColor = false;
            AdminControlOrdersbtn.Click += AdminControlOrdersbtn_Click;
            // 
            // AdminControlProductbtn
            // 
            AdminControlProductbtn.BackColor = SystemColors.ButtonHighlight;
            AdminControlProductbtn.Location = new Point(19, 124);
            AdminControlProductbtn.Name = "AdminControlProductbtn";
            AdminControlProductbtn.Size = new Size(175, 48);
            AdminControlProductbtn.TabIndex = 4;
            AdminControlProductbtn.Text = "Управление товара";
            AdminControlProductbtn.UseVisualStyleBackColor = false;
            AdminControlProductbtn.Click += AdminControlProductbtn_Click;
            // 
            // Exportbtn
            // 
            Exportbtn.BackColor = SystemColors.ButtonHighlight;
            Exportbtn.Location = new Point(19, 53);
            Exportbtn.Name = "Exportbtn";
            Exportbtn.Size = new Size(175, 52);
            Exportbtn.TabIndex = 1;
            Exportbtn.Text = "Экспорт";
            Exportbtn.UseVisualStyleBackColor = false;
            Exportbtn.Click += Exportbtn_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 19);
            label3.Name = "label3";
            label3.Size = new Size(204, 21);
            label3.TabIndex = 0;
            label3.Text = "Панель администратора";
            // 
            // ErrorLabel
            // 
            ErrorLabel.AutoSize = true;
            ErrorLabel.Location = new Point(40, 465);
            ErrorLabel.Name = "ErrorLabel";
            ErrorLabel.Size = new Size(61, 15);
            ErrorLabel.TabIndex = 9;
            ErrorLabel.Text = "ShowError";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 489);
            Controls.Add(ErrorLabel);
            Controls.Add(AdminPanel);
            Controls.Add(ManagerPanel);
            Controls.Add(ClientPanel);
            Controls.Add(Closebtn);
            Name = "MainForm";
            Text = "MainForm";
            ClientPanel.ResumeLayout(false);
            ClientPanel.PerformLayout();
            ManagerPanel.ResumeLayout(false);
            ManagerPanel.PerformLayout();
            AdminPanel.ResumeLayout(false);
            AdminPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Closebtn;
        private Panel ClientPanel;
        private Panel ManagerPanel;
        private Panel AdminPanel;
        private Button BuyProductbtn;
        private Label label1;
        private Button ManageControlOrdersbtn;
        private Button ManageControlProductbtn;
        private Label label2;
        private Button AdminControlOrdersbtn;
        private Button AdminControlProductbtn;
        private Button Exportbtn;
        private Label label3;
        private Label ErrorLabel;
    }
}