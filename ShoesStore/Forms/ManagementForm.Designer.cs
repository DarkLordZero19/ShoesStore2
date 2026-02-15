namespace ShoesStore.Forms
{
    partial class ManagementForm
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
            tabControl = new TabControl();
            productsTab = new TabPage();
            panel2 = new Panel();
            productDescriptionLabel = new Label();
            productNameLabel = new Label();
            productCategoryLabel = new Label();
            productPriceLabel = new Label();
            productBrandLabel = new Label();
            productStockLabel = new Label();
            productSizeLabel = new Label();
            productColorLabel = new Label();
            refreshProductsButton = new Button();
            productsStatsLabel = new Label();
            deleteProductButton = new Button();
            editProductButton = new Button();
            addProductButton = new Button();
            resetProductFiltersButton = new Button();
            applyProductFiltersButton = new Button();
            label3 = new Label();
            productSortComboBox = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            categoryFilterComboBox = new ComboBox();
            productSearchTextBox = new TextBox();
            searchProductButton = new Button();
            productsDataGridView = new DataGridView();
            ordersTab = new TabPage();
            panel1 = new Panel();
            orderStatusLabel = new Label();
            orderIdLabel = new Label();
            orderProductLabel = new Label();
            orderCustomerLabel = new Label();
            orderQuantityLabel = new Label();
            orderDateLabel = new Label();
            orderTotalLabelDetails = new Label();
            orderNotesLabel = new Label();
            orderAddressLabel = new Label();
            orderPhoneLabel = new Label();
            orderSearchTextBox = new TextBox();
            deleteOrderButton = new Button();
            label15 = new Label();
            ordersStatsLabel = new Label();
            refreshOrdersButton = new Button();
            resetOrderFiltersButton = new Button();
            applyOrderFiltersButton = new Button();
            label13 = new Label();
            orderStatusFilterComboBox = new ComboBox();
            searchOrderButton = new Button();
            ordersDataGridView = new DataGridView();
            createOrderTab = new TabPage();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            createOrderNotesTextBox = new TextBox();
            createOrderPhoneTextBox = new TextBox();
            createOrderAddressTextBox = new TextBox();
            createOrderTotalLabel = new Label();
            label25 = new Label();
            label24 = new Label();
            orderQuantityComboBox = new ComboBox();
            orderSizeComboBox = new ComboBox();
            createOrderProductStockLabel = new Label();
            createOrderProductPriceLabel = new Label();
            createOrderButton = new Button();
            label17 = new Label();
            createOrderProductComboBox = new ComboBox();
            CloseButton = new Button();
            RefreshAllButton = new Button();
            StatusLabel = new Label();
            tabControl.SuspendLayout();
            productsTab.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
            ordersTab.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
            createOrderTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(productsTab);
            tabControl.Controls.Add(ordersTab);
            tabControl.Controls.Add(createOrderTab);
            tabControl.Location = new Point(12, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1301, 580);
            tabControl.TabIndex = 0;
            // 
            // productsTab
            // 
            productsTab.Controls.Add(panel2);
            productsTab.Controls.Add(refreshProductsButton);
            productsTab.Controls.Add(productsStatsLabel);
            productsTab.Controls.Add(deleteProductButton);
            productsTab.Controls.Add(editProductButton);
            productsTab.Controls.Add(addProductButton);
            productsTab.Controls.Add(resetProductFiltersButton);
            productsTab.Controls.Add(applyProductFiltersButton);
            productsTab.Controls.Add(label3);
            productsTab.Controls.Add(productSortComboBox);
            productsTab.Controls.Add(label2);
            productsTab.Controls.Add(label1);
            productsTab.Controls.Add(categoryFilterComboBox);
            productsTab.Controls.Add(productSearchTextBox);
            productsTab.Controls.Add(searchProductButton);
            productsTab.Controls.Add(productsDataGridView);
            productsTab.Location = new Point(4, 24);
            productsTab.Name = "productsTab";
            productsTab.Padding = new Padding(3);
            productsTab.Size = new Size(1293, 552);
            productsTab.TabIndex = 0;
            productsTab.Text = "Управление товарами";
            productsTab.UseVisualStyleBackColor = true;
            productsTab.Click += productsTab_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(productDescriptionLabel);
            panel2.Controls.Add(productNameLabel);
            panel2.Controls.Add(productCategoryLabel);
            panel2.Controls.Add(productPriceLabel);
            panel2.Controls.Add(productBrandLabel);
            panel2.Controls.Add(productStockLabel);
            panel2.Controls.Add(productSizeLabel);
            panel2.Controls.Add(productColorLabel);
            panel2.Location = new Point(807, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(351, 493);
            panel2.TabIndex = 37;
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.AutoSize = true;
            productDescriptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productDescriptionLabel.Location = new Point(15, 276);
            productDescriptionLabel.Name = "productDescriptionLabel";
            productDescriptionLabel.Size = new Size(68, 15);
            productDescriptionLabel.TabIndex = 16;
            productDescriptionLabel.Text = "Описание:";
            productDescriptionLabel.Click += productDescriptionLabel_Click;
            // 
            // productNameLabel
            // 
            productNameLabel.AutoSize = true;
            productNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productNameLabel.Location = new Point(15, 18);
            productNameLabel.Name = "productNameLabel";
            productNameLabel.Size = new Size(90, 15);
            productNameLabel.TabIndex = 9;
            productNameLabel.Text = "Имя продукта:";
            productNameLabel.Click += productNameLabel_Click;
            // 
            // productCategoryLabel
            // 
            productCategoryLabel.AutoSize = true;
            productCategoryLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productCategoryLabel.Location = new Point(15, 48);
            productCategoryLabel.Name = "productCategoryLabel";
            productCategoryLabel.Size = new Size(70, 15);
            productCategoryLabel.TabIndex = 10;
            productCategoryLabel.Text = "Категория:";
            productCategoryLabel.Click += productCategoryLabel_Click;
            // 
            // productPriceLabel
            // 
            productPriceLabel.AutoSize = true;
            productPriceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productPriceLabel.Location = new Point(15, 89);
            productPriceLabel.Name = "productPriceLabel";
            productPriceLabel.Size = new Size(40, 15);
            productPriceLabel.TabIndex = 11;
            productPriceLabel.Text = "Цена:";
            productPriceLabel.Click += productPriceLabel_Click;
            // 
            // productBrandLabel
            // 
            productBrandLabel.AutoSize = true;
            productBrandLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productBrandLabel.Location = new Point(15, 238);
            productBrandLabel.Name = "productBrandLabel";
            productBrandLabel.Size = new Size(46, 15);
            productBrandLabel.TabIndex = 15;
            productBrandLabel.Text = "Бренд:";
            productBrandLabel.Click += productBrandLabel_Click;
            // 
            // productStockLabel
            // 
            productStockLabel.AutoSize = true;
            productStockLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productStockLabel.Location = new Point(15, 126);
            productStockLabel.Name = "productStockLabel";
            productStockLabel.Size = new Size(55, 15);
            productStockLabel.TabIndex = 12;
            productStockLabel.Text = "Остаток:";
            productStockLabel.Click += productStockLabel_Click;
            // 
            // productSizeLabel
            // 
            productSizeLabel.AutoSize = true;
            productSizeLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productSizeLabel.Location = new Point(15, 163);
            productSizeLabel.Name = "productSizeLabel";
            productSizeLabel.Size = new Size(52, 15);
            productSizeLabel.TabIndex = 13;
            productSizeLabel.Text = "Размер:";
            productSizeLabel.Click += productSizeLabel_Click;
            // 
            // productColorLabel
            // 
            productColorLabel.AutoSize = true;
            productColorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productColorLabel.Location = new Point(15, 201);
            productColorLabel.Name = "productColorLabel";
            productColorLabel.Size = new Size(39, 15);
            productColorLabel.TabIndex = 14;
            productColorLabel.Text = "Цвет:";
            productColorLabel.Click += productColorLabel_Click;
            // 
            // refreshProductsButton
            // 
            refreshProductsButton.BackColor = SystemColors.ButtonHighlight;
            refreshProductsButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            refreshProductsButton.Location = new Point(667, 320);
            refreshProductsButton.Name = "refreshProductsButton";
            refreshProductsButton.Size = new Size(121, 42);
            refreshProductsButton.TabIndex = 36;
            refreshProductsButton.Text = "Обновить товары";
            refreshProductsButton.UseVisualStyleBackColor = false;
            refreshProductsButton.Click += refreshProductsButton_Click;
            // 
            // productsStatsLabel
            // 
            productsStatsLabel.AutoSize = true;
            productsStatsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            productsStatsLabel.Location = new Point(15, 523);
            productsStatsLabel.Name = "productsStatsLabel";
            productsStatsLabel.Size = new Size(113, 15);
            productsStatsLabel.TabIndex = 35;
            productsStatsLabel.Text = "productsStatsLabel";
            productsStatsLabel.Click += productsStatsLabel_Click;
            // 
            // deleteProductButton
            // 
            deleteProductButton.BackColor = SystemColors.ButtonHighlight;
            deleteProductButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            deleteProductButton.Location = new Point(667, 468);
            deleteProductButton.Name = "deleteProductButton";
            deleteProductButton.Size = new Size(121, 42);
            deleteProductButton.TabIndex = 34;
            deleteProductButton.Text = "Удалить товар";
            deleteProductButton.UseVisualStyleBackColor = false;
            deleteProductButton.Click += deleteProductButton_Click;
            // 
            // editProductButton
            // 
            editProductButton.BackColor = SystemColors.ButtonHighlight;
            editProductButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            editProductButton.Location = new Point(667, 420);
            editProductButton.Name = "editProductButton";
            editProductButton.Size = new Size(120, 42);
            editProductButton.TabIndex = 33;
            editProductButton.Text = "Редактировать товар";
            editProductButton.UseVisualStyleBackColor = false;
            editProductButton.Click += editProductButton_Click;
            // 
            // addProductButton
            // 
            addProductButton.BackColor = SystemColors.ButtonHighlight;
            addProductButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addProductButton.Location = new Point(667, 372);
            addProductButton.Name = "addProductButton";
            addProductButton.Size = new Size(121, 42);
            addProductButton.TabIndex = 32;
            addProductButton.Text = "Добавить товар";
            addProductButton.UseVisualStyleBackColor = false;
            addProductButton.Click += addProductButton_Click;
            // 
            // resetProductFiltersButton
            // 
            resetProductFiltersButton.BackColor = SystemColors.ButtonHighlight;
            resetProductFiltersButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            resetProductFiltersButton.Location = new Point(667, 259);
            resetProductFiltersButton.Name = "resetProductFiltersButton";
            resetProductFiltersButton.Size = new Size(121, 42);
            resetProductFiltersButton.TabIndex = 31;
            resetProductFiltersButton.Text = "Сбросить фильтры";
            resetProductFiltersButton.UseVisualStyleBackColor = false;
            resetProductFiltersButton.Click += resetProductFiltersButton_Click;
            // 
            // applyProductFiltersButton
            // 
            applyProductFiltersButton.BackColor = SystemColors.ButtonHighlight;
            applyProductFiltersButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            applyProductFiltersButton.Location = new Point(667, 211);
            applyProductFiltersButton.Name = "applyProductFiltersButton";
            applyProductFiltersButton.Size = new Size(121, 42);
            applyProductFiltersButton.TabIndex = 30;
            applyProductFiltersButton.Text = "Применить фильтры";
            applyProductFiltersButton.UseVisualStyleBackColor = false;
            applyProductFiltersButton.Click += applyProductFiltersButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(667, 164);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 29;
            label3.Text = "Сортировка товаров:";
            // 
            // productSortComboBox
            // 
            productSortComboBox.FormattingEnabled = true;
            productSortComboBox.Location = new Point(667, 182);
            productSortComboBox.Name = "productSortComboBox";
            productSortComboBox.Size = new Size(121, 23);
            productSortComboBox.TabIndex = 28;
            productSortComboBox.SelectedIndexChanged += productSortComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(667, 110);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 27;
            label2.Text = "Категории:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(667, 10);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 26;
            label1.Text = "Список товаров:";
            // 
            // categoryFilterComboBox
            // 
            categoryFilterComboBox.FormattingEnabled = true;
            categoryFilterComboBox.Location = new Point(667, 128);
            categoryFilterComboBox.Name = "categoryFilterComboBox";
            categoryFilterComboBox.Size = new Size(121, 23);
            categoryFilterComboBox.TabIndex = 25;
            categoryFilterComboBox.SelectedIndexChanged += categoryFilterComboBox_SelectedIndexChanged;
            // 
            // productSearchTextBox
            // 
            productSearchTextBox.Location = new Point(667, 28);
            productSearchTextBox.Name = "productSearchTextBox";
            productSearchTextBox.Size = new Size(121, 23);
            productSearchTextBox.TabIndex = 24;
            productSearchTextBox.KeyDown += productSearchTextBox_KeyDown;
            // 
            // searchProductButton
            // 
            searchProductButton.BackColor = SystemColors.ButtonHighlight;
            searchProductButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            searchProductButton.Location = new Point(667, 57);
            searchProductButton.Name = "searchProductButton";
            searchProductButton.Size = new Size(121, 38);
            searchProductButton.TabIndex = 23;
            searchProductButton.Text = "Поиск";
            searchProductButton.UseVisualStyleBackColor = false;
            searchProductButton.Click += searchProductButton_Click;
            // 
            // productsDataGridView
            // 
            productsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            productsDataGridView.Location = new Point(15, 6);
            productsDataGridView.Name = "productsDataGridView";
            productsDataGridView.Size = new Size(629, 505);
            productsDataGridView.TabIndex = 22;
            productsDataGridView.SelectionChanged += productsDataGridView_SelectionChanged;
            // 
            // ordersTab
            // 
            ordersTab.Controls.Add(panel1);
            ordersTab.Controls.Add(orderSearchTextBox);
            ordersTab.Controls.Add(deleteOrderButton);
            ordersTab.Controls.Add(label15);
            ordersTab.Controls.Add(ordersStatsLabel);
            ordersTab.Controls.Add(refreshOrdersButton);
            ordersTab.Controls.Add(resetOrderFiltersButton);
            ordersTab.Controls.Add(applyOrderFiltersButton);
            ordersTab.Controls.Add(label13);
            ordersTab.Controls.Add(orderStatusFilterComboBox);
            ordersTab.Controls.Add(searchOrderButton);
            ordersTab.Controls.Add(ordersDataGridView);
            ordersTab.Location = new Point(4, 24);
            ordersTab.Name = "ordersTab";
            ordersTab.Padding = new Padding(3);
            ordersTab.Size = new Size(1293, 552);
            ordersTab.TabIndex = 1;
            ordersTab.Text = "Управление заказами";
            ordersTab.UseVisualStyleBackColor = true;
            ordersTab.Click += ordersTab_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(orderStatusLabel);
            panel1.Controls.Add(orderIdLabel);
            panel1.Controls.Add(orderProductLabel);
            panel1.Controls.Add(orderCustomerLabel);
            panel1.Controls.Add(orderQuantityLabel);
            panel1.Controls.Add(orderDateLabel);
            panel1.Controls.Add(orderTotalLabelDetails);
            panel1.Controls.Add(orderNotesLabel);
            panel1.Controls.Add(orderAddressLabel);
            panel1.Controls.Add(orderPhoneLabel);
            panel1.Location = new Point(793, 30);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 494);
            panel1.TabIndex = 50;
            // 
            // orderStatusLabel
            // 
            orderStatusLabel.AutoSize = true;
            orderStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderStatusLabel.Location = new Point(13, 232);
            orderStatusLabel.Name = "orderStatusLabel";
            orderStatusLabel.Size = new Size(120, 15);
            orderStatusLabel.TabIndex = 15;
            orderStatusLabel.Text = "Изменение статуса:";
            orderStatusLabel.Click += orderStatusLabel_Click;
            // 
            // orderIdLabel
            // 
            orderIdLabel.AutoSize = true;
            orderIdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderIdLabel.Location = new Point(13, 10);
            orderIdLabel.Name = "orderIdLabel";
            orderIdLabel.Size = new Size(23, 15);
            orderIdLabel.TabIndex = 9;
            orderIdLabel.Text = "ID:";
            orderIdLabel.Click += orderIdLabel_Click;
            // 
            // orderProductLabel
            // 
            orderProductLabel.AutoSize = true;
            orderProductLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderProductLabel.Location = new Point(13, 100);
            orderProductLabel.Name = "orderProductLabel";
            orderProductLabel.Size = new Size(43, 15);
            orderProductLabel.TabIndex = 12;
            orderProductLabel.Text = "Товар:";
            orderProductLabel.Click += orderProductLabel_Click;
            // 
            // orderCustomerLabel
            // 
            orderCustomerLabel.AutoSize = true;
            orderCustomerLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderCustomerLabel.Location = new Point(13, 69);
            orderCustomerLabel.Name = "orderCustomerLabel";
            orderCustomerLabel.Size = new Size(52, 15);
            orderCustomerLabel.TabIndex = 35;
            orderCustomerLabel.Text = "Клиент:";
            orderCustomerLabel.Click += orderCustomerLabel_Click;
            // 
            // orderQuantityLabel
            // 
            orderQuantityLabel.AutoSize = true;
            orderQuantityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderQuantityLabel.Location = new Point(13, 144);
            orderQuantityLabel.Name = "orderQuantityLabel";
            orderQuantityLabel.Size = new Size(79, 15);
            orderQuantityLabel.TabIndex = 13;
            orderQuantityLabel.Text = "Количество:";
            orderQuantityLabel.Click += orderQuantityLabel_Click;
            // 
            // orderDateLabel
            // 
            orderDateLabel.AutoSize = true;
            orderDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderDateLabel.Location = new Point(13, 39);
            orderDateLabel.Name = "orderDateLabel";
            orderDateLabel.Size = new Size(36, 15);
            orderDateLabel.TabIndex = 34;
            orderDateLabel.Text = "Дата:";
            orderDateLabel.Click += orderDateLabel_Click;
            // 
            // orderTotalLabelDetails
            // 
            orderTotalLabelDetails.AutoSize = true;
            orderTotalLabelDetails.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderTotalLabelDetails.Location = new Point(13, 189);
            orderTotalLabelDetails.Name = "orderTotalLabelDetails";
            orderTotalLabelDetails.Size = new Size(43, 15);
            orderTotalLabelDetails.TabIndex = 14;
            orderTotalLabelDetails.Text = "Всего:";
            orderTotalLabelDetails.Click += orderTotalLabelDetails_Click;
            // 
            // orderNotesLabel
            // 
            orderNotesLabel.AutoSize = true;
            orderNotesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderNotesLabel.Location = new Point(13, 362);
            orderNotesLabel.Name = "orderNotesLabel";
            orderNotesLabel.Size = new Size(86, 15);
            orderNotesLabel.TabIndex = 21;
            orderNotesLabel.Text = "Примечение:";
            orderNotesLabel.Click += orderNotesLabel_Click;
            // 
            // orderAddressLabel
            // 
            orderAddressLabel.AutoSize = true;
            orderAddressLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderAddressLabel.Location = new Point(13, 276);
            orderAddressLabel.Name = "orderAddressLabel";
            orderAddressLabel.Size = new Size(45, 15);
            orderAddressLabel.TabIndex = 16;
            orderAddressLabel.Text = "Адрес:";
            orderAddressLabel.Click += orderAddressLabel_Click;
            // 
            // orderPhoneLabel
            // 
            orderPhoneLabel.AutoSize = true;
            orderPhoneLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderPhoneLabel.Location = new Point(13, 318);
            orderPhoneLabel.Name = "orderPhoneLabel";
            orderPhoneLabel.Size = new Size(60, 15);
            orderPhoneLabel.TabIndex = 20;
            orderPhoneLabel.Text = "Телефон:";
            orderPhoneLabel.Click += orderPhoneLabel_Click;
            // 
            // orderSearchTextBox
            // 
            orderSearchTextBox.Location = new Point(654, 48);
            orderSearchTextBox.Name = "orderSearchTextBox";
            orderSearchTextBox.Size = new Size(121, 23);
            orderSearchTextBox.TabIndex = 49;
            orderSearchTextBox.KeyDown += orderSearchTextBox_KeyDown;
            // 
            // deleteOrderButton
            // 
            deleteOrderButton.BackColor = SystemColors.ButtonHighlight;
            deleteOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            deleteOrderButton.Location = new Point(654, 355);
            deleteOrderButton.Name = "deleteOrderButton";
            deleteOrderButton.Size = new Size(121, 42);
            deleteOrderButton.TabIndex = 48;
            deleteOrderButton.Text = "Удалить товар";
            deleteOrderButton.UseVisualStyleBackColor = false;
            deleteOrderButton.Click += deleteOrderButton_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(654, 30);
            label15.Name = "label15";
            label15.Size = new Size(95, 15);
            label15.TabIndex = 47;
            label15.Text = "Список заказов:";
            // 
            // ordersStatsLabel
            // 
            ordersStatsLabel.AutoSize = true;
            ordersStatsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ordersStatsLabel.Location = new Point(6, 527);
            ordersStatsLabel.Name = "ordersStatsLabel";
            ordersStatsLabel.Size = new Size(100, 15);
            ordersStatsLabel.TabIndex = 46;
            ordersStatsLabel.Text = "ordersStatsLabel";
            ordersStatsLabel.Click += ordersStatsLabel_Click;
            // 
            // refreshOrdersButton
            // 
            refreshOrdersButton.BackColor = SystemColors.ButtonHighlight;
            refreshOrdersButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            refreshOrdersButton.Location = new Point(654, 297);
            refreshOrdersButton.Name = "refreshOrdersButton";
            refreshOrdersButton.Size = new Size(121, 42);
            refreshOrdersButton.TabIndex = 45;
            refreshOrdersButton.Text = "Обновить заказы";
            refreshOrdersButton.UseVisualStyleBackColor = false;
            refreshOrdersButton.Click += refreshOrdersButton_Click;
            // 
            // resetOrderFiltersButton
            // 
            resetOrderFiltersButton.BackColor = SystemColors.ButtonHighlight;
            resetOrderFiltersButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            resetOrderFiltersButton.Location = new Point(654, 235);
            resetOrderFiltersButton.Name = "resetOrderFiltersButton";
            resetOrderFiltersButton.Size = new Size(121, 42);
            resetOrderFiltersButton.TabIndex = 44;
            resetOrderFiltersButton.Text = "Сбросить фильтры";
            resetOrderFiltersButton.UseVisualStyleBackColor = false;
            resetOrderFiltersButton.Click += resetOrderFiltersButton_Click;
            // 
            // applyOrderFiltersButton
            // 
            applyOrderFiltersButton.BackColor = SystemColors.ButtonHighlight;
            applyOrderFiltersButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            applyOrderFiltersButton.Location = new Point(654, 187);
            applyOrderFiltersButton.Name = "applyOrderFiltersButton";
            applyOrderFiltersButton.Size = new Size(121, 42);
            applyOrderFiltersButton.TabIndex = 43;
            applyOrderFiltersButton.Text = "Применить фильтры";
            applyOrderFiltersButton.UseVisualStyleBackColor = false;
            applyOrderFiltersButton.Click += applyOrderFiltersButton_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(654, 130);
            label13.Name = "label13";
            label13.Size = new Size(111, 15);
            label13.TabIndex = 42;
            label13.Text = "Фильтр по статусу:";
            // 
            // orderStatusFilterComboBox
            // 
            orderStatusFilterComboBox.FormattingEnabled = true;
            orderStatusFilterComboBox.Location = new Point(654, 148);
            orderStatusFilterComboBox.Name = "orderStatusFilterComboBox";
            orderStatusFilterComboBox.Size = new Size(121, 23);
            orderStatusFilterComboBox.TabIndex = 41;
            orderStatusFilterComboBox.SelectedIndexChanged += orderStatusFilterComboBox_SelectedIndexChanged;
            // 
            // searchOrderButton
            // 
            searchOrderButton.BackColor = SystemColors.ButtonHighlight;
            searchOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            searchOrderButton.Location = new Point(654, 77);
            searchOrderButton.Name = "searchOrderButton";
            searchOrderButton.Size = new Size(121, 38);
            searchOrderButton.TabIndex = 40;
            searchOrderButton.Text = "Поиск";
            searchOrderButton.UseVisualStyleBackColor = false;
            searchOrderButton.Click += searchOrderButton_Click;
            // 
            // ordersDataGridView
            // 
            ordersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersDataGridView.Location = new Point(6, 6);
            ordersDataGridView.Name = "ordersDataGridView";
            ordersDataGridView.Size = new Size(630, 518);
            ordersDataGridView.TabIndex = 39;
            ordersDataGridView.SelectionChanged += ordersDataGridView_SelectionChanged;
            // 
            // createOrderTab
            // 
            createOrderTab.Controls.Add(label28);
            createOrderTab.Controls.Add(label27);
            createOrderTab.Controls.Add(label26);
            createOrderTab.Controls.Add(createOrderNotesTextBox);
            createOrderTab.Controls.Add(createOrderPhoneTextBox);
            createOrderTab.Controls.Add(createOrderAddressTextBox);
            createOrderTab.Controls.Add(createOrderTotalLabel);
            createOrderTab.Controls.Add(label25);
            createOrderTab.Controls.Add(label24);
            createOrderTab.Controls.Add(orderQuantityComboBox);
            createOrderTab.Controls.Add(orderSizeComboBox);
            createOrderTab.Controls.Add(createOrderProductStockLabel);
            createOrderTab.Controls.Add(createOrderProductPriceLabel);
            createOrderTab.Controls.Add(createOrderButton);
            createOrderTab.Controls.Add(label17);
            createOrderTab.Controls.Add(createOrderProductComboBox);
            createOrderTab.Location = new Point(4, 24);
            createOrderTab.Name = "createOrderTab";
            createOrderTab.Padding = new Padding(3);
            createOrderTab.Size = new Size(1293, 552);
            createOrderTab.TabIndex = 2;
            createOrderTab.Text = "Покупка Товара";
            createOrderTab.UseVisualStyleBackColor = true;
            createOrderTab.Click += createOrderTab_Click;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Location = new Point(581, 413);
            label28.Name = "label28";
            label28.Size = new Size(81, 15);
            label28.TabIndex = 65;
            label28.Text = "Примечания:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(581, 360);
            label27.Name = "label27";
            label27.Size = new Size(58, 15);
            label27.TabIndex = 64;
            label27.Text = "Телефон:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(579, 304);
            label26.Name = "label26";
            label26.Size = new Size(95, 15);
            label26.TabIndex = 63;
            label26.Text = "Адрес доставки:";
            // 
            // createOrderNotesTextBox
            // 
            createOrderNotesTextBox.Location = new Point(579, 431);
            createOrderNotesTextBox.Name = "createOrderNotesTextBox";
            createOrderNotesTextBox.Size = new Size(136, 23);
            createOrderNotesTextBox.TabIndex = 62;
            createOrderNotesTextBox.TextChanged += createOrderNotesTextBox_TextChanged;
            // 
            // createOrderPhoneTextBox
            // 
            createOrderPhoneTextBox.Location = new Point(577, 378);
            createOrderPhoneTextBox.Name = "createOrderPhoneTextBox";
            createOrderPhoneTextBox.Size = new Size(138, 23);
            createOrderPhoneTextBox.TabIndex = 61;
            createOrderPhoneTextBox.TextChanged += createOrderPhoneTextBox_TextChanged;
            // 
            // createOrderAddressTextBox
            // 
            createOrderAddressTextBox.Location = new Point(577, 322);
            createOrderAddressTextBox.Name = "createOrderAddressTextBox";
            createOrderAddressTextBox.Size = new Size(138, 23);
            createOrderAddressTextBox.TabIndex = 60;
            createOrderAddressTextBox.TextChanged += createOrderAddressTextBox_TextChanged;
            // 
            // createOrderTotalLabel
            // 
            createOrderTotalLabel.AutoSize = true;
            createOrderTotalLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createOrderTotalLabel.Location = new Point(579, 273);
            createOrderTotalLabel.Name = "createOrderTotalLabel";
            createOrderTotalLabel.Size = new Size(102, 15);
            createOrderTotalLabel.TabIndex = 59;
            createOrderTotalLabel.Text = "Итоговая сумма:";
            createOrderTotalLabel.Click += createOrderTotalLabel_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(579, 216);
            label25.Name = "label25";
            label25.Size = new Size(113, 15);
            label25.TabIndex = 58;
            label25.Text = "Выбор количества:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(579, 175);
            label24.Name = "label24";
            label24.Size = new Size(96, 15);
            label24.TabIndex = 57;
            label24.Text = "Выбор размера:";
            // 
            // orderQuantityComboBox
            // 
            orderQuantityComboBox.FormattingEnabled = true;
            orderQuantityComboBox.Location = new Point(579, 234);
            orderQuantityComboBox.Name = "orderQuantityComboBox";
            orderQuantityComboBox.Size = new Size(136, 23);
            orderQuantityComboBox.TabIndex = 56;
            orderQuantityComboBox.SelectedIndexChanged += orderQuantityComboBox_SelectedIndexChanged;
            // 
            // orderSizeComboBox
            // 
            orderSizeComboBox.FormattingEnabled = true;
            orderSizeComboBox.Location = new Point(579, 193);
            orderSizeComboBox.Name = "orderSizeComboBox";
            orderSizeComboBox.Size = new Size(136, 23);
            orderSizeComboBox.TabIndex = 55;
            orderSizeComboBox.SelectedIndexChanged += orderSizeComboBox_SelectedIndexChanged;
            // 
            // createOrderProductStockLabel
            // 
            createOrderProductStockLabel.AutoSize = true;
            createOrderProductStockLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createOrderProductStockLabel.Location = new Point(577, 148);
            createOrderProductStockLabel.Name = "createOrderProductStockLabel";
            createOrderProductStockLabel.Size = new Size(138, 15);
            createOrderProductStockLabel.TabIndex = 54;
            createOrderProductStockLabel.Text = "Количество на складе:";
            createOrderProductStockLabel.Click += createOrderProductStockLabel_Click;
            // 
            // createOrderProductPriceLabel
            // 
            createOrderProductPriceLabel.AutoSize = true;
            createOrderProductPriceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createOrderProductPriceLabel.Location = new Point(577, 111);
            createOrderProductPriceLabel.Name = "createOrderProductPriceLabel";
            createOrderProductPriceLabel.Size = new Size(81, 15);
            createOrderProductPriceLabel.TabIndex = 53;
            createOrderProductPriceLabel.Text = "Цена товара:";
            createOrderProductPriceLabel.Click += createOrderProductPriceLabel_Click;
            // 
            // createOrderButton
            // 
            createOrderButton.BackColor = SystemColors.ButtonHighlight;
            createOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createOrderButton.Location = new Point(577, 470);
            createOrderButton.Name = "createOrderButton";
            createOrderButton.Size = new Size(138, 42);
            createOrderButton.TabIndex = 52;
            createOrderButton.Text = "Сделать заказ";
            createOrderButton.UseVisualStyleBackColor = false;
            createOrderButton.Click += createOrderButton_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(579, 40);
            label17.Name = "label17";
            label17.Size = new Size(87, 15);
            label17.TabIndex = 51;
            label17.Text = "Выбор товара:";
            // 
            // createOrderProductComboBox
            // 
            createOrderProductComboBox.FormattingEnabled = true;
            createOrderProductComboBox.Location = new Point(579, 67);
            createOrderProductComboBox.Name = "createOrderProductComboBox";
            createOrderProductComboBox.Size = new Size(136, 23);
            createOrderProductComboBox.TabIndex = 50;
            createOrderProductComboBox.SelectedIndexChanged += createOrderProductComboBox_SelectedIndexChanged;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.FromArgb(255, 128, 128);
            CloseButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            CloseButton.Location = new Point(16, 589);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(75, 48);
            CloseButton.TabIndex = 0;
            CloseButton.Text = "Выход";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // RefreshAllButton
            // 
            RefreshAllButton.BackColor = SystemColors.ButtonHighlight;
            RefreshAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            RefreshAllButton.Location = new Point(106, 589);
            RefreshAllButton.Name = "RefreshAllButton";
            RefreshAllButton.Size = new Size(139, 48);
            RefreshAllButton.TabIndex = 1;
            RefreshAllButton.Text = "Обновить все данные";
            RefreshAllButton.UseVisualStyleBackColor = false;
            RefreshAllButton.Click += RefreshAllButton_Click;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Location = new Point(270, 606);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(67, 15);
            StatusLabel.TabIndex = 2;
            StatusLabel.Text = "StatusLabel";
            StatusLabel.Click += StatusLabel_Click;
            // 
            // ManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 640);
            Controls.Add(StatusLabel);
            Controls.Add(RefreshAllButton);
            Controls.Add(CloseButton);
            Controls.Add(tabControl);
            Name = "ManagementForm";
            Text = "ManagementForm";
            tabControl.ResumeLayout(false);
            productsTab.ResumeLayout(false);
            productsTab.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
            ordersTab.ResumeLayout(false);
            ordersTab.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
            createOrderTab.ResumeLayout(false);
            createOrderTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl;
        private TabPage productsTab;
        private TabPage ordersTab;
        private TabPage createOrderTab;
        private Button CloseButton;
        private Button RefreshAllButton;
        private Label StatusLabel;
        private Panel panel2;
        private Label productDescriptionLabel;
        private Label productNameLabel;
        private Label productCategoryLabel;
        private Label productPriceLabel;
        private Label productBrandLabel;
        private Label productStockLabel;
        private Label productSizeLabel;
        private Label productColorLabel;
        private Button refreshProductsButton;
        private Label productsStatsLabel;
        private Button deleteProductButton;
        private Button editProductButton;
        private Button addProductButton;
        private Button resetProductFiltersButton;
        private Button applyProductFiltersButton;
        private Label label3;
        private ComboBox productSortComboBox;
        private Label label2;
        private Label label1;
        private ComboBox categoryFilterComboBox;
        private TextBox productSearchTextBox;
        private Button searchProductButton;
        private DataGridView productsDataGridView;
        private Panel panel1;
        private Label orderStatusLabel;
        private Label orderIdLabel;
        private Label orderProductLabel;
        private Label orderCustomerLabel;
        private Label orderQuantityLabel;
        private Label orderDateLabel;
        private Label orderTotalLabelDetails;
        private Label orderNotesLabel;
        private Label orderAddressLabel;
        private Label orderPhoneLabel;
        private TextBox orderSearchTextBox;
        private Button deleteOrderButton;
        private Label label15;
        private Label ordersStatsLabel;
        private Button refreshOrdersButton;
        private Button resetOrderFiltersButton;
        private Button applyOrderFiltersButton;
        private Label label13;
        private ComboBox orderStatusFilterComboBox;
        private Button searchOrderButton;
        private DataGridView ordersDataGridView;
        private Label label28;
        private Label label27;
        private Label label26;
        private TextBox createOrderNotesTextBox;
        private TextBox createOrderPhoneTextBox;
        private TextBox createOrderAddressTextBox;
        private Label createOrderTotalLabel;
        private Label label25;
        private Label label24;
        private ComboBox orderQuantityComboBox;
        private ComboBox orderSizeComboBox;
        private Label createOrderProductStockLabel;
        private Label createOrderProductPriceLabel;
        private Button createOrderButton;
        private Label label17;
        private ComboBox createOrderProductComboBox;
    }
}