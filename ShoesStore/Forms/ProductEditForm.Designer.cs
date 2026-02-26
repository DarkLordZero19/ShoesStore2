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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductEditForm));
            descriptionPanel = new Panel();
            descriptionTextBox = new TextBox();
            descriptionLabel = new Label();
            basicInfoPanel = new Panel();
            categoryComboBox = new ComboBox();
            nameLabel = new Label();
            categoryLabel = new Label();
            priceLabel = new Label();
            stockLabel = new Label();
            nameTextBox = new TextBox();
            priceTextBox = new TextBox();
            stockTextBox = new TextBox();
            buttonsPanel = new Panel();
            browseImageButton = new Button();
            cancelButton = new Button();
            loadSampleDataButton = new Button();
            saveButton = new Button();
            generateIdButton = new Button();
            ClearButton = new Button();
            previewButton = new Button();
            imagePanel = new Panel();
            imagePathTextBox = new TextBox();
            imageLabel = new Label();
            otherInfoPanel = new Panel();
            manufacturerComboBox = new ComboBox();
            discountLabel = new Label();
            unitLabel = new Label();
            supplierLabel = new Label();
            manufacturerLabel = new Label();
            discountTextBox = new TextBox();
            unitTextBox = new TextBox();
            supplierTextBox = new TextBox();
            pictureBoxPreview = new PictureBox();
            pictureLabel = new Label();
            descriptionPanel.SuspendLayout();
            basicInfoPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            imagePanel.SuspendLayout();
            otherInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).BeginInit();
            SuspendLayout();
            // 
            // descriptionPanel
            // 
            descriptionPanel.Controls.Add(descriptionTextBox);
            descriptionPanel.Controls.Add(descriptionLabel);
            descriptionPanel.Location = new Point(496, 166);
            descriptionPanel.Name = "descriptionPanel";
            descriptionPanel.Size = new Size(294, 71);
            descriptionPanel.TabIndex = 33;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(15, 27);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(267, 23);
            descriptionTextBox.TabIndex = 16;
            descriptionTextBox.TextChanged += descriptionTextBox_TextChanged;
            // 
            // descriptionLabel
            // 
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(15, 9);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(65, 15);
            descriptionLabel.TabIndex = 8;
            descriptionLabel.Text = "Описание:";
            // 
            // basicInfoPanel
            // 
            basicInfoPanel.Controls.Add(categoryComboBox);
            basicInfoPanel.Controls.Add(nameLabel);
            basicInfoPanel.Controls.Add(categoryLabel);
            basicInfoPanel.Controls.Add(priceLabel);
            basicInfoPanel.Controls.Add(stockLabel);
            basicInfoPanel.Controls.Add(nameTextBox);
            basicInfoPanel.Controls.Add(priceTextBox);
            basicInfoPanel.Controls.Add(stockTextBox);
            basicInfoPanel.Location = new Point(12, 37);
            basicInfoPanel.Name = "basicInfoPanel";
            basicInfoPanel.Size = new Size(200, 200);
            basicInfoPanel.TabIndex = 31;
            // 
            // categoryComboBox
            // 
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(38, 74);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(131, 23);
            categoryComboBox.TabIndex = 8;
            categoryComboBox.DropDown += categoryComboBox_DropDown;
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
            buttonsPanel.Controls.Add(browseImageButton);
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(loadSampleDataButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Controls.Add(generateIdButton);
            buttonsPanel.Controls.Add(ClearButton);
            buttonsPanel.Controls.Add(previewButton);
            buttonsPanel.Location = new Point(50, 305);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(898, 91);
            buttonsPanel.TabIndex = 30;
            // 
            // browseImageButton
            // 
            browseImageButton.BackColor = SystemColors.ButtonHighlight;
            browseImageButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            browseImageButton.Location = new Point(643, 26);
            browseImageButton.Name = "browseImageButton";
            browseImageButton.Size = new Size(119, 38);
            browseImageButton.TabIndex = 25;
            browseImageButton.Text = "Обзор изображения";
            browseImageButton.UseVisualStyleBackColor = false;
            browseImageButton.Click += browseImageButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.Red;
            cancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            cancelButton.ForeColor = SystemColors.Control;
            cancelButton.Location = new Point(768, 26);
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
            loadSampleDataButton.Location = new Point(518, 26);
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
            generateIdButton.Location = new Point(393, 26);
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
            ClearButton.Location = new Point(143, 26);
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
            previewButton.Location = new Point(268, 26);
            previewButton.Name = "previewButton";
            previewButton.Size = new Size(119, 38);
            previewButton.TabIndex = 22;
            previewButton.Text = "Предпросмотр";
            previewButton.UseVisualStyleBackColor = false;
            previewButton.Click += previewButton_Click;
            // 
            // imagePanel
            // 
            imagePanel.Controls.Add(imagePathTextBox);
            imagePanel.Controls.Add(imageLabel);
            imagePanel.Location = new Point(496, 37);
            imagePanel.Name = "imagePanel";
            imagePanel.Size = new Size(294, 71);
            imagePanel.TabIndex = 34;
            // 
            // imagePathTextBox
            // 
            imagePathTextBox.Location = new Point(15, 30);
            imagePathTextBox.Name = "imagePathTextBox";
            imagePathTextBox.Size = new Size(267, 23);
            imagePathTextBox.TabIndex = 1;
            // 
            // imageLabel
            // 
            imageLabel.AutoSize = true;
            imageLabel.Location = new Point(15, 12);
            imageLabel.Name = "imageLabel";
            imageLabel.Size = new Size(86, 15);
            imageLabel.TabIndex = 0;
            imageLabel.Text = "Изображения:";
            // 
            // otherInfoPanel
            // 
            otherInfoPanel.Controls.Add(manufacturerComboBox);
            otherInfoPanel.Controls.Add(discountLabel);
            otherInfoPanel.Controls.Add(unitLabel);
            otherInfoPanel.Controls.Add(supplierLabel);
            otherInfoPanel.Controls.Add(manufacturerLabel);
            otherInfoPanel.Controls.Add(discountTextBox);
            otherInfoPanel.Controls.Add(unitTextBox);
            otherInfoPanel.Controls.Add(supplierTextBox);
            otherInfoPanel.Location = new Point(254, 37);
            otherInfoPanel.Name = "otherInfoPanel";
            otherInfoPanel.Size = new Size(200, 200);
            otherInfoPanel.TabIndex = 35;
            // 
            // manufacturerComboBox
            // 
            manufacturerComboBox.FormattingEnabled = true;
            manufacturerComboBox.Location = new Point(36, 30);
            manufacturerComboBox.Name = "manufacturerComboBox";
            manufacturerComboBox.Size = new Size(133, 23);
            manufacturerComboBox.TabIndex = 8;
            manufacturerComboBox.DropDown += manufacturerComboBox_DropDown;
            // 
            // discountLabel
            // 
            discountLabel.AutoSize = true;
            discountLabel.Location = new Point(37, 147);
            discountLabel.Name = "discountLabel";
            discountLabel.Size = new Size(119, 15);
            discountLabel.TabIndex = 7;
            discountLabel.Text = "Скидка в процентах:";
            // 
            // unitLabel
            // 
            unitLabel.AutoSize = true;
            unitLabel.Location = new Point(37, 103);
            unitLabel.Name = "unitLabel";
            unitLabel.Size = new Size(119, 15);
            unitLabel.TabIndex = 6;
            unitLabel.Text = "Eдиница измерения:";
            // 
            // supplierLabel
            // 
            supplierLabel.AutoSize = true;
            supplierLabel.Location = new Point(37, 56);
            supplierLabel.Name = "supplierLabel";
            supplierLabel.Size = new Size(73, 15);
            supplierLabel.TabIndex = 5;
            supplierLabel.Text = "Поставщик:";
            // 
            // manufacturerLabel
            // 
            manufacturerLabel.AutoSize = true;
            manufacturerLabel.Location = new Point(37, 12);
            manufacturerLabel.Name = "manufacturerLabel";
            manufacturerLabel.Size = new Size(95, 15);
            manufacturerLabel.TabIndex = 4;
            manufacturerLabel.Text = "Производитель:";
            // 
            // discountTextBox
            // 
            discountTextBox.Location = new Point(37, 165);
            discountTextBox.Name = "discountTextBox";
            discountTextBox.Size = new Size(132, 23);
            discountTextBox.TabIndex = 3;
            // 
            // unitTextBox
            // 
            unitTextBox.Location = new Point(37, 121);
            unitTextBox.Name = "unitTextBox";
            unitTextBox.Size = new Size(132, 23);
            unitTextBox.TabIndex = 2;
            // 
            // supplierTextBox
            // 
            supplierTextBox.Location = new Point(37, 74);
            supplierTextBox.Name = "supplierTextBox";
            supplierTextBox.Size = new Size(132, 23);
            supplierTextBox.TabIndex = 1;
            // 
            // pictureBoxPreview
            // 
            pictureBoxPreview.Location = new Point(808, 37);
            pictureBoxPreview.Name = "pictureBoxPreview";
            pictureBoxPreview.Size = new Size(202, 200);
            pictureBoxPreview.TabIndex = 36;
            pictureBoxPreview.TabStop = false;
            // 
            // pictureLabel
            // 
            pictureLabel.AutoSize = true;
            pictureLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            pictureLabel.Location = new Point(808, 19);
            pictureLabel.Name = "pictureLabel";
            pictureLabel.Size = new Size(178, 15);
            pictureLabel.TabIndex = 37;
            pictureLabel.Text = "Предпросмотр изображения:";
            // 
            // ProductEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 450);
            Controls.Add(pictureLabel);
            Controls.Add(pictureBoxPreview);
            Controls.Add(descriptionPanel);
            Controls.Add(otherInfoPanel);
            Controls.Add(imagePanel);
            Controls.Add(basicInfoPanel);
            Controls.Add(buttonsPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ProductEditForm";
            Text = "Редактирование Товара";
            descriptionPanel.ResumeLayout(false);
            descriptionPanel.PerformLayout();
            basicInfoPanel.ResumeLayout(false);
            basicInfoPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            imagePanel.ResumeLayout(false);
            imagePanel.PerformLayout();
            otherInfoPanel.ResumeLayout(false);
            otherInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPreview).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox priceTextBox;
        private TextBox stockTextBox;
        private Panel buttonsPanel;
        private Button cancelButton;
        private Button loadSampleDataButton;
        private Button saveButton;
        private Button generateIdButton;
        private Button ClearButton;
        private Button previewButton;
        private Panel imagePanel;
        private TextBox imagePathTextBox;
        private Label imageLabel;
        private Panel otherInfoPanel;
        private Button browseImageButton;
        private TextBox discountTextBox;
        private TextBox unitTextBox;
        private TextBox supplierTextBox;
        private Label discountLabel;
        private Label unitLabel;
        private Label supplierLabel;
        private Label manufacturerLabel;
        private PictureBox pictureBoxPreview;
        private Label pictureLabel;
        private ComboBox categoryComboBox;
        private ComboBox manufacturerComboBox;
    }
}