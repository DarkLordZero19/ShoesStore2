namespace ShoesStore.Forms
{
    partial class ProductEditForm
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
            descriptionPanel = new Panel();
            descriptionTextBox = new TextBox();
            descriptionLabel = new Label();
            basicInfoPanel = new Panel();
            nameLabel = new Label();
            categoryLabel = new Label();
            priceLabel = new Label();
            stockLabel = new Label();
            nameTextBox = new TextBox();
            categoryTextBox = new TextBox();
            priceTextBox = new TextBox();
            stockTextBox = new TextBox();
            buttonsPanel = new Panel();
            cancelButton = new Button();
            loadSampleDataButton = new Button();
            saveButton = new Button();
            generateIdButton = new Button();
            ClearButton = new Button();
            previewButton = new Button();
            descriptionPanel.SuspendLayout();
            basicInfoPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // descriptionPanel
            // 
            descriptionPanel.Controls.Add(descriptionTextBox);
            descriptionPanel.Controls.Add(descriptionLabel);
            descriptionPanel.Location = new Point(445, 100);
            descriptionPanel.Name = "descriptionPanel";
            descriptionPanel.Size = new Size(294, 100);
            descriptionPanel.TabIndex = 33;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(15, 48);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(267, 23);
            descriptionTextBox.TabIndex = 16;
            descriptionTextBox.TextChanged += descriptionTextBox_TextChanged;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(15, 30);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(65, 15);
            descriptionLabel.TabIndex = 8;
            descriptionLabel.Text = "Описание:";
            // 
            // basicInfoPanel
            // 
            basicInfoPanel.Controls.Add(nameLabel);
            basicInfoPanel.Controls.Add(categoryLabel);
            basicInfoPanel.Controls.Add(priceLabel);
            basicInfoPanel.Controls.Add(stockLabel);
            basicInfoPanel.Controls.Add(nameTextBox);
            basicInfoPanel.Controls.Add(categoryTextBox);
            basicInfoPanel.Controls.Add(priceTextBox);
            basicInfoPanel.Controls.Add(stockTextBox);
            basicInfoPanel.Location = new Point(103, 44);
            basicInfoPanel.Name = "basicInfoPanel";
            basicInfoPanel.Size = new Size(200, 200);
            basicInfoPanel.TabIndex = 31;
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(38, 12);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(62, 15);
            nameLabel.TabIndex = 1;
            nameLabel.Text = "Название:";
            // 
            // categoryLabel
            // 
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(38, 56);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(67, 15);
            categoryLabel.TabIndex = 2;
            categoryLabel.Text = "Категории:";
            // 
            // priceLabel
            // 
            priceLabel.AutoSize = true;
            priceLabel.Location = new Point(38, 103);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(38, 15);
            priceLabel.TabIndex = 3;
            priceLabel.Text = "Цена:";
            // 
            // stockLabel
            // 
            stockLabel.AutoSize = true;
            stockLabel.Location = new Point(38, 147);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(131, 15);
            stockLabel.TabIndex = 4;
            stockLabel.Text = "Количество на складе:";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(38, 30);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(131, 23);
            nameTextBox.TabIndex = 9;
            nameTextBox.Enter += nameTextBox_Enter;
            // 
            // categoryTextBox
            // 
            categoryTextBox.Location = new Point(38, 74);
            categoryTextBox.Name = "categoryTextBox";
            categoryTextBox.Size = new Size(131, 23);
            categoryTextBox.TabIndex = 10;
            categoryTextBox.KeyUp += categoryTextBox_KeyUp;
            // 
            // priceTextBox
            // 
            priceTextBox.Location = new Point(38, 121);
            priceTextBox.Name = "priceTextBox";
            priceTextBox.Size = new Size(131, 23);
            priceTextBox.TabIndex = 11;
            priceTextBox.KeyPress += priceTextBox_KeyPress;
            priceTextBox.Leave += priceTextBox_Leave;
            // 
            // stockTextBox
            // 
            stockTextBox.Location = new Point(38, 165);
            stockTextBox.Name = "stockTextBox";
            stockTextBox.Size = new Size(131, 23);
            stockTextBox.TabIndex = 12;
            stockTextBox.KeyPress += stockTextBox_KeyPress;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(loadSampleDataButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Controls.Add(generateIdButton);
            buttonsPanel.Controls.Add(ClearButton);
            buttonsPanel.Controls.Add(previewButton);
            buttonsPanel.Location = new Point(10, 310);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(780, 91);
            buttonsPanel.TabIndex = 30;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Red;
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cancelButton.ForeColor = SystemColors.Control;
            cancelButton.Location = new Point(653, 26);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(113, 38);
            cancelButton.TabIndex = 20;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // loadSampleDataButton
            // 
            loadSampleDataButton.BackColor = SystemColors.ButtonHighlight;
            loadSampleDataButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            loadSampleDataButton.Location = new Point(528, 26);
            loadSampleDataButton.Name = "loadSampleDataButton";
            loadSampleDataButton.Size = new Size(119, 38);
            loadSampleDataButton.TabIndex = 24;
            loadSampleDataButton.Text = "Тестовые данные";
            loadSampleDataButton.UseVisualStyleBackColor = false;
            loadSampleDataButton.Click += loadSampleDataButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = SystemColors.ButtonHighlight;
            saveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            saveButton.Location = new Point(18, 26);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(119, 38);
            saveButton.TabIndex = 19;
            saveButton.Text = "Сохранить";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // generateIdButton
            // 
            generateIdButton.BackColor = SystemColors.ButtonHighlight;
            generateIdButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            generateIdButton.Location = new Point(403, 26);
            generateIdButton.Name = "generateIdButton";
            generateIdButton.Size = new Size(119, 38);
            generateIdButton.TabIndex = 23;
            generateIdButton.Text = "Сгенерировать ID";
            generateIdButton.UseVisualStyleBackColor = false;
            generateIdButton.Click += generateIdButton_Click;
            // 
            // ClearButton
            // 
            ClearButton.BackColor = SystemColors.ButtonHighlight;
            ClearButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ClearButton.Location = new Point(153, 26);
            ClearButton.Name = "ClearButton";
            ClearButton.Size = new Size(119, 38);
            ClearButton.TabIndex = 21;
            ClearButton.Text = "Очистить";
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Click += ClearButton_Click;
            // 
            // previewButton
            // 
            previewButton.BackColor = SystemColors.ButtonHighlight;
            previewButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            previewButton.Location = new Point(281, 26);
            previewButton.Name = "previewButton";
            previewButton.Size = new Size(119, 38);
            previewButton.TabIndex = 22;
            previewButton.Text = "Предпросмотр";
            previewButton.UseVisualStyleBackColor = false;
            previewButton.Click += previewButton_Click;
            // 
            // ProductEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(descriptionPanel);
            Controls.Add(basicInfoPanel);
            Controls.Add(buttonsPanel);
            Name = "ProductEditForm";
            Text = "ProductEditForm";
            descriptionPanel.ResumeLayout(false);
            descriptionPanel.PerformLayout();
            basicInfoPanel.ResumeLayout(false);
            basicInfoPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel descriptionPanel;
        private TextBox descriptionTextBox;
        private Label descriptionLabel;
        private Panel basicInfoPanel;
        private Label nameLabel;
        private Label categoryLabel;
        private Label priceLabel;
        private Label stockLabel;
        private TextBox nameTextBox;
        private TextBox categoryTextBox;
        private TextBox priceTextBox;
        private TextBox stockTextBox;
        private Panel buttonsPanel;
        private Button cancelButton;
        private Button loadSampleDataButton;
        private Button saveButton;
        private Button generateIdButton;
        private Button ClearButton;
        private Button previewButton;
    }
}