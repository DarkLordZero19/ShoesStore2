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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            closeButton = new Button();
            clientPanel = new Panel();
            buyProductButton = new Button();
            label1 = new Label();
            managerPanel = new Panel();
            manageControlOrdersButton = new Button();
            manageControlProductButton = new Button();
            label2 = new Label();
            adminPanel = new Panel();
            adminControlOrdersButton = new Button();
            adminControlProductButton = new Button();
            exportButton = new Button();
            label3 = new Label();
            userFullNameLabel = new Label();
            companyLogoPictureBox = new PictureBox();
            clientPanel.SuspendLayout();
            managerPanel.SuspendLayout();
            adminPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)companyLogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(255, 128, 128);
            closeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            closeButton.Location = new Point(40, 395);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(95, 57);
            closeButton.TabIndex = 0;
            closeButton.Text = "Выход";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // clientPanel
            // 
            clientPanel.Controls.Add(buyProductButton);
            clientPanel.Controls.Add(label1);
            clientPanel.Location = new Point(232, 41);
            clientPanel.Name = "clientPanel";
            clientPanel.Size = new Size(185, 149);
            clientPanel.TabIndex = 1;
            clientPanel.Paint += clientPanel_Paint;
            // 
            // buyProductButton
            // 
            buyProductButton.BackColor = SystemColors.ButtonHighlight;
            buyProductButton.Location = new Point(13, 53);
            buyProductButton.Name = "buyProductButton";
            buyProductButton.Size = new Size(160, 52);
            buyProductButton.TabIndex = 4;
            buyProductButton.Text = "Купить товар";
            buyProductButton.UseVisualStyleBackColor = false;
            buyProductButton.Click += buyProductButton_Click;
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
            // managerPanel
            // 
            managerPanel.Controls.Add(manageControlOrdersButton);
            managerPanel.Controls.Add(manageControlProductButton);
            managerPanel.Controls.Add(label2);
            managerPanel.Location = new Point(486, 41);
            managerPanel.Name = "managerPanel";
            managerPanel.Size = new Size(194, 215);
            managerPanel.TabIndex = 2;
            managerPanel.Paint += managerPanel_Paint;
            // 
            // manageControlOrdersButton
            // 
            manageControlOrdersButton.BackColor = SystemColors.ButtonHighlight;
            manageControlOrdersButton.Location = new Point(24, 124);
            manageControlOrdersButton.Name = "manageControlOrdersButton";
            manageControlOrdersButton.Size = new Size(145, 48);
            manageControlOrdersButton.TabIndex = 3;
            manageControlOrdersButton.Text = "Управление заказа";
            manageControlOrdersButton.UseVisualStyleBackColor = false;
            manageControlOrdersButton.Click += manageControlOrdersButton_Click;
            // 
            // manageControlProductButton
            // 
            manageControlProductButton.BackColor = SystemColors.ButtonHighlight;
            manageControlProductButton.Location = new Point(24, 53);
            manageControlProductButton.Name = "manageControlProductButton";
            manageControlProductButton.Size = new Size(145, 52);
            manageControlProductButton.TabIndex = 2;
            manageControlProductButton.Text = "Управление товара";
            manageControlProductButton.UseVisualStyleBackColor = false;
            manageControlProductButton.Click += manageControlProductButton_Click;
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
            // adminPanel
            // 
            adminPanel.Controls.Add(adminControlOrdersButton);
            adminPanel.Controls.Add(adminControlProductButton);
            adminPanel.Controls.Add(exportButton);
            adminPanel.Controls.Add(label3);
            adminPanel.Location = new Point(756, 41);
            adminPanel.Name = "adminPanel";
            adminPanel.Size = new Size(219, 269);
            adminPanel.TabIndex = 3;
            adminPanel.Paint += adminPanel_Paint;
            // 
            // adminControlOrdersButton
            // 
            adminControlOrdersButton.BackColor = SystemColors.ButtonHighlight;
            adminControlOrdersButton.Location = new Point(19, 190);
            adminControlOrdersButton.Name = "adminControlOrdersButton";
            adminControlOrdersButton.Size = new Size(175, 48);
            adminControlOrdersButton.TabIndex = 5;
            adminControlOrdersButton.Text = "Управление заказа";
            adminControlOrdersButton.UseVisualStyleBackColor = false;
            adminControlOrdersButton.Click += adminControlOrdersButton_Click;
            // 
            // adminControlProductButton
            // 
            adminControlProductButton.BackColor = SystemColors.ButtonHighlight;
            adminControlProductButton.Location = new Point(19, 124);
            adminControlProductButton.Name = "adminControlProductButton";
            adminControlProductButton.Size = new Size(175, 48);
            adminControlProductButton.TabIndex = 4;
            adminControlProductButton.Text = "Управление товара";
            adminControlProductButton.UseVisualStyleBackColor = false;
            adminControlProductButton.Click += adminControlProductButton_Click;
            // 
            // exportButton
            // 
            exportButton.BackColor = SystemColors.ButtonHighlight;
            exportButton.Location = new Point(19, 53);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(175, 52);
            exportButton.TabIndex = 1;
            exportButton.Text = "Экспорт";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
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
            // userFullNameLabel
            // 
            userFullNameLabel.AutoSize = true;
            userFullNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            userFullNameLabel.Location = new Point(786, 9);
            userFullNameLabel.Name = "userFullNameLabel";
            userFullNameLabel.Size = new Size(112, 15);
            userFullNameLabel.TabIndex = 4;
            userFullNameLabel.Text = "userFullNameLabel";
            // 
            // companyLogoPictureBox
            // 
            companyLogoPictureBox.ErrorImage = Properties.Resources.error;
            companyLogoPictureBox.InitialImage = (Image)resources.GetObject("companyLogoPictureBox.InitialImage");
            companyLogoPictureBox.Location = new Point(12, 41);
            companyLogoPictureBox.Name = "companyLogoPictureBox";
            companyLogoPictureBox.Size = new Size(177, 149);
            companyLogoPictureBox.TabIndex = 5;
            companyLogoPictureBox.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1007, 489);
            Controls.Add(companyLogoPictureBox);
            Controls.Add(userFullNameLabel);
            Controls.Add(adminPanel);
            Controls.Add(managerPanel);
            Controls.Add(clientPanel);
            Controls.Add(closeButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            Text = "Панель Пользователя";
            clientPanel.ResumeLayout(false);
            clientPanel.PerformLayout();
            managerPanel.ResumeLayout(false);
            managerPanel.PerformLayout();
            adminPanel.ResumeLayout(false);
            adminPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)companyLogoPictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Panel clientPanel;
        private Panel managerPanel;
        private Panel adminPanel;
        private Button buyProductButton;
        private Label label1;
        private Button manageControlOrdersButton;
        private Button manageControlProductButton;
        private Label label2;
        private Button adminControlOrdersButton;
        private Button adminControlProductButton;
        private Button exportButton;
        private Label label3;
        private Label userFullNameLabel;
        private PictureBox companyLogoPictureBox;
    }
}