namespace ShoesStore.Forms
{
    partial class OrderEditForm
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
            idLabel = new Label();
            clientComboBox = new ComboBox();
            statusComboBox = new ComboBox();
            deliveryAddressTextBox = new TextBox();
            basicInfoPanel = new Panel();
            deliveryAddressLabel = new Label();
            statusLabel = new Label();
            clientLabel = new Label();
            cancelButton = new Button();
            saveButton = new Button();
            buttonsPanel = new Panel();
            ClearButton = new Button();
            orderDatePicker = new DateTimePicker();
            issueDatePicker = new DateTimePicker();
            label4 = new Label();
            dateTimePanel = new Panel();
            label5 = new Label();
            basicInfoPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            dateTimePanel.SuspendLayout();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(12, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(18, 15);
            idLabel.TabIndex = 0;
            idLabel.Text = "ID";
            // 
            // clientComboBox
            // 
            clientComboBox.FormattingEnabled = true;
            clientComboBox.Location = new Point(15, 39);
            clientComboBox.Name = "clientComboBox";
            clientComboBox.Size = new Size(164, 23);
            clientComboBox.TabIndex = 1;
            // 
            // statusComboBox
            // 
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(15, 87);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(164, 23);
            statusComboBox.TabIndex = 2;
            // 
            // deliveryAddressTextBox
            // 
            deliveryAddressTextBox.Location = new Point(15, 131);
            deliveryAddressTextBox.Name = "deliveryAddressTextBox";
            deliveryAddressTextBox.Size = new Size(164, 23);
            deliveryAddressTextBox.TabIndex = 3;
            // 
            // basicInfoPanel
            // 
            basicInfoPanel.Controls.Add(deliveryAddressLabel);
            basicInfoPanel.Controls.Add(statusLabel);
            basicInfoPanel.Controls.Add(clientLabel);
            basicInfoPanel.Controls.Add(deliveryAddressTextBox);
            basicInfoPanel.Controls.Add(statusComboBox);
            basicInfoPanel.Controls.Add(clientComboBox);
            basicInfoPanel.Location = new Point(115, 12);
            basicInfoPanel.Name = "basicInfoPanel";
            basicInfoPanel.Size = new Size(200, 177);
            basicInfoPanel.TabIndex = 4;
            // 
            // deliveryAddressLabel
            // 
            deliveryAddressLabel.AutoSize = true;
            deliveryAddressLabel.Location = new Point(15, 113);
            deliveryAddressLabel.Name = "deliveryAddressLabel";
            deliveryAddressLabel.Size = new Size(95, 15);
            deliveryAddressLabel.TabIndex = 6;
            deliveryAddressLabel.Text = "Адрес доставки:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(15, 69);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(83, 15);
            statusLabel.TabIndex = 5;
            statusLabel.Text = "Статус заказа:";
            // 
            // clientLabel
            // 
            clientLabel.AutoSize = true;
            clientLabel.Location = new Point(15, 21);
            clientLabel.Name = "clientLabel";
            clientLabel.Size = new Size(94, 15);
            clientLabel.TabIndex = 4;
            clientLabel.Text = "Выбор клиента:";
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
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(ClearButton);
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Location = new Point(115, 346);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(516, 71);
            buttonsPanel.TabIndex = 56;
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
            // orderDatePicker
            // 
            orderDatePicker.Location = new Point(23, 36);
            orderDatePicker.Name = "orderDatePicker";
            orderDatePicker.Size = new Size(200, 23);
            orderDatePicker.TabIndex = 57;
            // 
            // issueDatePicker
            // 
            issueDatePicker.Location = new Point(23, 87);
            issueDatePicker.Name = "issueDatePicker";
            issueDatePicker.ShowCheckBox = true;
            issueDatePicker.Size = new Size(200, 23);
            issueDatePicker.TabIndex = 58;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(23, 21);
            label4.Name = "label4";
            label4.Size = new Size(74, 15);
            label4.TabIndex = 59;
            label4.Text = "Дата Заказа:";
            // 
            // dateTimePanel
            // 
            dateTimePanel.Controls.Add(label5);
            dateTimePanel.Controls.Add(issueDatePicker);
            dateTimePanel.Controls.Add(label4);
            dateTimePanel.Controls.Add(orderDatePicker);
            dateTimePanel.Location = new Point(387, 12);
            dateTimePanel.Name = "dateTimePanel";
            dateTimePanel.Size = new Size(244, 177);
            dateTimePanel.TabIndex = 60;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(23, 69);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 60;
            label5.Text = "Дата выдачи:";
            // 
            // OrderEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 450);
            Controls.Add(dateTimePanel);
            Controls.Add(buttonsPanel);
            Controls.Add(basicInfoPanel);
            Controls.Add(idLabel);
            Name = "OrderEditForm";
            Text = "Редактирование Заказа";
            basicInfoPanel.ResumeLayout(false);
            basicInfoPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            dateTimePanel.ResumeLayout(false);
            dateTimePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private ComboBox clientComboBox;
        private ComboBox statusComboBox;
        private TextBox deliveryAddressTextBox;
        private Panel basicInfoPanel;
        private Button cancelButton;
        private Button saveButton;
        private Panel buttonsPanel;
        private Label clientLabel;
        private Label deliveryAddressLabel;
        private Label statusLabel;
        private DateTimePicker orderDatePicker;
        private DateTimePicker issueDatePicker;
        private Label label4;
        private Panel dateTimePanel;
        private Label label5;
        private Button ClearButton;
    }
}