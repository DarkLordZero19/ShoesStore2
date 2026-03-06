namespace ShoesStore.Forms
{
    partial class OrderEditsForm
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
            clientDataGridView = new DataGridView();
            buttonsPanel = new Panel();
            ClearButton = new Button();
            cancelButton = new Button();
            saveButton = new Button();
            userFullNameLabel = new Label();
            statusLabel = new Label();
            statusComboBox = new ComboBox();
            deliveryAddressLabel = new Label();
            deliveryAddressTextBox = new TextBox();
            label5 = new Label();
            issueDatePicker = new DateTimePicker();
            label4 = new Label();
            orderDatePicker = new DateTimePicker();
            basicInfoPanel = new Panel();
            clientLabel = new Label();
            idLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)clientDataGridView).BeginInit();
            buttonsPanel.SuspendLayout();
            basicInfoPanel.SuspendLayout();
            SuspendLayout();
            // 
            // clientDataGridView
            // 
            clientDataGridView.AllowUserToAddRows = false;
            clientDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientDataGridView.Location = new Point(358, 30);
            clientDataGridView.MultiSelect = false;
            clientDataGridView.Name = "clientDataGridView";
            clientDataGridView.ReadOnly = true;
            clientDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            clientDataGridView.Size = new Size(430, 322);
            clientDataGridView.TabIndex = 0;
            clientDataGridView.CellDoubleClick += clientDataGridView_CellDoubleClick;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(ClearButton);
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Location = new Point(154, 367);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(516, 71);
            buttonsPanel.TabIndex = 57;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = SystemColors.ButtonHighlight;
            ClearButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ClearButton.Location = new Point(204, 16);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(119, 38);
            ClearButton.TabIndex = 56;
            ClearButton.Text = "Очистить";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Red;
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cancelButton.ForeColor = SystemColors.Control;
            cancelButton.Location = new Point(368, 16);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 38);
            cancelButton.TabIndex = 54;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = SystemColors.ButtonHighlight;
            saveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            saveButton.Location = new Point(32, 16);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(119, 38);
            saveButton.TabIndex = 55;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // userFullNameLabel
            // 
            userFullNameLabel.AutoSize = true;
            userFullNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            userFullNameLabel.Location = new Point(85, 9);
            userFullNameLabel.Name = "userFullNameLabel";
            userFullNameLabel.Size = new Size(112, 15);
            userFullNameLabel.TabIndex = 58;
            userFullNameLabel.Text = "userFullNameLabel";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(13, 9);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(83, 15);
            statusLabel.TabIndex = 60;
            statusLabel.Text = "Статус заказа:";
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(13, 27);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(200, 23);
            statusComboBox.TabIndex = 59;
            // 
            // deliveryAddressLabel
            // 
            deliveryAddressLabel.AutoSize = true;
            deliveryAddressLabel.Location = new Point(13, 56);
            deliveryAddressLabel.Name = "deliveryAddressLabel";
            deliveryAddressLabel.Size = new Size(95, 15);
            deliveryAddressLabel.TabIndex = 62;
            deliveryAddressLabel.Text = "Адрес доставки:";
            // 
            // deliveryAddressTextBox
            // 
            deliveryAddressTextBox.Location = new Point(13, 74);
            deliveryAddressTextBox.Name = "deliveryAddressTextBox";
            deliveryAddressTextBox.Size = new Size(200, 23);
            deliveryAddressTextBox.TabIndex = 61;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 162);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 66;
            label5.Text = "Дата выдачи:";
            // 
            // issueDatePicker
            // 
            issueDatePicker.Location = new Point(13, 180);
            issueDatePicker.Name = "issueDatePicker";
            issueDatePicker.ShowCheckBox = true;
            issueDatePicker.Size = new Size(200, 23);
            issueDatePicker.TabIndex = 64;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 114);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 65;
            label4.Text = "Дата Заказа:";
            // 
            // orderDatePicker
            // 
            orderDatePicker.Location = new Point(13, 129);
            orderDatePicker.Name = "orderDatePicker";
            orderDatePicker.Size = new Size(200, 23);
            orderDatePicker.TabIndex = 63;
            // 
            // basicInfoPanel
            // 
            basicInfoPanel.Controls.Add(statusLabel);
            basicInfoPanel.Controls.Add(label5);
            basicInfoPanel.Controls.Add(statusComboBox);
            basicInfoPanel.Controls.Add(issueDatePicker);
            basicInfoPanel.Controls.Add(deliveryAddressTextBox);
            basicInfoPanel.Controls.Add(label4);
            basicInfoPanel.Controls.Add(deliveryAddressLabel);
            basicInfoPanel.Controls.Add(orderDatePicker);
            basicInfoPanel.Location = new Point(20, 63);
            basicInfoPanel.Name = "basicInfoPanel";
            basicInfoPanel.Size = new Size(246, 218);
            basicInfoPanel.TabIndex = 67;
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            clientLabel.Location = new Point(358, 9);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(99, 15);
            clientLabel.TabIndex = 68;
            clientLabel.Text = "Выбор клиента:";
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(676, 423);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(0, 15);
            idLabel.TabIndex = 69;
            // 
            // OrderEditsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(idLabel);
            Controls.Add(clientLabel);
            Controls.Add(basicInfoPanel);
            Controls.Add(userFullNameLabel);
            Controls.Add(buttonsPanel);
            Controls.Add(clientDataGridView);
            Name = "OrderEditsForm";
            Text = "OrderEditsForm";
            Load += OrderEditsForm_Load;
            ((System.ComponentModel.ISupportInitialize)clientDataGridView).EndInit();
            buttonsPanel.ResumeLayout(false);
            basicInfoPanel.ResumeLayout(false);
            basicInfoPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView clientDataGridView;
        private Panel buttonsPanel;
        private Button ClearButton;
        private Button cancelButton;
        private Button saveButton;
        private Label userFullNameLabel;
        private Label statusLabel;
        private ComboBox statusComboBox;
        private Label deliveryAddressLabel;
        private TextBox deliveryAddressTextBox;
        private Label label5;
        private DateTimePicker issueDatePicker;
        private Label label4;
        private DateTimePicker orderDatePicker;
        private Panel basicInfoPanel;
        private Label clientLabel;
        private Label idLabel;
    }
}