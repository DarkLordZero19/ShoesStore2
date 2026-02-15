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
            errorLabel = new Label();
            descriptionPanel = new Panel();
            descriptionTextBox = new TextBox();
            descriptionLabel = new Label();
            additionalInfoPanel = new Panel();
            brandTextBox = new TextBox();
            sizeLabel = new Label();
            colorLabel = new Label();
            brandLabel = new Label();
            sizeTextBox = new TextBox();
            colorTextBox = new TextBox();
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
            CancelButton = new Button();
            loadSampleDataButton = new Button();
            saveButton = new Button();
            generateIdButton = new Button();
            clearButton = new Button();
            previewButton = new Button();
            descriptionPanel.SuspendLayout();
            additionalInfoPanel.SuspendLayout();
            basicInfoPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.BackColor = SystemColors.Control;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(28, 414);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(61, 15);
            errorLabel.TabIndex = 34;
            errorLabel.Text = "ShowError";
            // 
            // descriptionPanel
            // 
            descriptionPanel.Controls.Add(descriptionTextBox);
            descriptionPanel.Controls.Add(descriptionLabel);
            descriptionPanel.Location = new Point(482, 21);
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
            // additionalInfoPanel
            // 
            additionalInfoPanel.Controls.Add(brandTextBox);
            additionalInfoPanel.Controls.Add(sizeLabel);
            additionalInfoPanel.Controls.Add(colorLabel);
            additionalInfoPanel.Controls.Add(brandLabel);
            additionalInfoPanel.Controls.Add(sizeTextBox);
            additionalInfoPanel.Controls.Add(colorTextBox);
            additionalInfoPanel.Location = new Point(261, 21);
            additionalInfoPanel.Name = "additionalInfoPanel";
            additionalInfoPanel.Size = new Size(200, 162);
            additionalInfoPanel.TabIndex = 32;
            // 
            // brandTextBox
            // 
            brandTextBox.Location = new Point(38, 118);
            brandTextBox.Name = "brandTextBox";
            brandTextBox.Size = new Size(131, 23);
            brandTextBox.TabIndex = 15;
            brandTextBox.Enter += brandTextBox_Enter;
            // 
            // sizeLabel
            // 
            sizeLabel.AutoSize = true;
            sizeLabel.Location = new Point(38, 12);
            sizeLabel.Name = "sizeLabel";
            sizeLabel.Size = new Size(50, 15);
            sizeLabel.TabIndex = 5;
            sizeLabel.Text = "Размер:";
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.Location = new Point(38, 56);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new Size(36, 15);
            colorLabel.TabIndex = 6;
            colorLabel.Text = "Цвет:";
            // 
            // brandLabel
            // 
            brandLabel.AutoSize = true;
            brandLabel.Location = new Point(38, 100);
            brandLabel.Name = "brandLabel";
            brandLabel.Size = new Size(43, 15);
            brandLabel.TabIndex = 7;
            brandLabel.Text = "Бренд:";
            // 
            // sizeTextBox
            // 
            sizeTextBox.Location = new Point(38, 30);
            sizeTextBox.Name = "sizeTextBox";
            sizeTextBox.Size = new Size(131, 23);
            sizeTextBox.TabIndex = 13;
            sizeTextBox.KeyPress += sizeTextBox_KeyPress;
            // 
            // colorTextBox
            // 
            colorTextBox.Location = new Point(38, 74);
            colorTextBox.Name = "colorTextBox";
            colorTextBox.Size = new Size(131, 23);
            colorTextBox.TabIndex = 14;
            colorTextBox.TextChanged += colorTextBox_TextChanged;
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
            basicInfoPanel.Location = new Point(28, 21);
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
            buttonsPanel.Controls.Add(CancelButton);
            buttonsPanel.Controls.Add(loadSampleDataButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Controls.Add(generateIdButton);
            buttonsPanel.Controls.Add(clearButton);
            buttonsPanel.Controls.Add(previewButton);
            buttonsPanel.Location = new Point(10, 310);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(780, 91);
            buttonsPanel.TabIndex = 30;
            // 
            // CancelButton
            // 
            CancelButton.BackColor = Color.Red;
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            CancelButton.ForeColor = SystemColors.Control;
            CancelButton.Location = new Point(653, 26);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(113, 38);
            CancelButton.TabIndex = 20;
            CancelButton.Text = "Отмена";
            CancelButton.UseVisualStyleBackColor = false;
            CancelButton.Click += CancelButton_Click;
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
            // clearButton
            // 
            clearButton.BackColor = SystemColors.ButtonHighlight;
            clearButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            clearButton.Location = new Point(153, 26);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(119, 38);
            clearButton.TabIndex = 21;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
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
            Controls.Add(errorLabel);
            Controls.Add(descriptionPanel);
            Controls.Add(additionalInfoPanel);
            Controls.Add(basicInfoPanel);
            Controls.Add(buttonsPanel);
            Name = "ProductEditForm";
            Text = "ProductEditForm";
            descriptionPanel.ResumeLayout(false);
            descriptionPanel.PerformLayout();
            additionalInfoPanel.ResumeLayout(false);
            additionalInfoPanel.PerformLayout();
            basicInfoPanel.ResumeLayout(false);
            basicInfoPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label errorLabel;
        private Panel descriptionPanel;
        private TextBox descriptionTextBox;
        private Label descriptionLabel;
        private Panel additionalInfoPanel;
        private TextBox brandTextBox;
        private Label sizeLabel;
        private Label colorLabel;
        private Label brandLabel;
        private TextBox sizeTextBox;
        private TextBox colorTextBox;
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
        private Button CancelButton;
        private Button loadSampleDataButton;
        private Button saveButton;
        private Button generateIdButton;
        private Button clearButton;
        private Button previewButton;
    }
}