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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagementForm));
            tabControl1 = new TabControl();
            productsTab = new TabPage();
            supplierFilterComboBox = new ComboBox();
            label24 = new Label();
            TableInfoPanel = new Panel();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label14 = new Label();
            productDiscountedPriceLabel = new Label();
            productDiscountLabel = new Label();
            productUnitLabel = new Label();
            productSupplierLabel = new Label();
            productManufacturerLabel = new Label();
            productDescriptionLabel = new Label();
            productNameLabel = new Label();
            productCategoryLabel = new Label();
            productPriceLabel = new Label();
            productStockLabel = new Label();
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
            editOrderButton = new Button();
            addOrderButton = new Button();
            TableInfoPanel2 = new Panel();
            orderIssueDateLabel = new Label();
            orderAddressLabel = new Label();
            label30 = new Label();
            label29 = new Label();
            label16 = new Label();
            label18 = new Label();
            label19 = new Label();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            orderStatusLabel = new Label();
            orderIdLabel = new Label();
            orderProductLabel = new Label();
            orderCustomerLabel = new Label();
            orderQuantityLabel = new Label();
            orderDateLabel = new Label();
            orderTotalLabelDetails = new Label();
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
            label32 = new Label();
            issueDatePicker = new DateTimePicker();
            label31 = new Label();
            deliveryAddressTextBox = new TextBox();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            createOrderTotalLabel = new Label();
            label25 = new Label();
            orderQuantityComboBox = new ComboBox();
            createOrderProductStockLabel = new Label();
            createOrderProductPriceLabel = new Label();
            createOrderButton = new Button();
            label17 = new Label();
            createOrderProductComboBox = new ComboBox();
            closeButton = new Button();
            refreshAllButton = new Button();
            statusLabel = new Label();
            userFullNameLabel = new Label();
            tabControl1.SuspendLayout();
            productsTab.SuspendLayout();
            TableInfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).BeginInit();
            ordersTab.SuspendLayout();
            TableInfoPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
            createOrderTab.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(productsTab);
            tabControl1.Controls.Add(ordersTab);
            tabControl1.Controls.Add(createOrderTab);
            tabControl1.Location = new Point(8, 37);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1301, 580);
            tabControl1.TabIndex = 0;
            // 
            // productsTab
            // 
            productsTab.Controls.Add(supplierFilterComboBox);
            productsTab.Controls.Add(label24);
            productsTab.Controls.Add(TableInfoPanel);
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
            productsTab.Enter += productsTab_Enter;
            // 
            // supplierFilterComboBox
            // 
            supplierFilterComboBox.FormattingEnabled = true;
            supplierFilterComboBox.Location = new Point(667, 165);
            supplierFilterComboBox.Name = "supplierFilterComboBox";
            supplierFilterComboBox.Size = new Size(119, 23);
            supplierFilterComboBox.TabIndex = 40;
            supplierFilterComboBox.SelectedIndexChanged += supplierFilterComboBox_SelectedIndexChanged;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(666, 144);
            label24.Name = "label24";
            label24.Size = new Size(70, 15);
            label24.TabIndex = 39;
            label24.Text = "Поставщик";
            // 
            // TableInfoPanel
            // 
            TableInfoPanel.Controls.Add(label4);
            TableInfoPanel.Controls.Add(label5);
            TableInfoPanel.Controls.Add(label6);
            TableInfoPanel.Controls.Add(label7);
            TableInfoPanel.Controls.Add(label8);
            TableInfoPanel.Controls.Add(label9);
            TableInfoPanel.Controls.Add(label10);
            TableInfoPanel.Controls.Add(label11);
            TableInfoPanel.Controls.Add(label12);
            TableInfoPanel.Controls.Add(label14);
            TableInfoPanel.Controls.Add(productDiscountedPriceLabel);
            TableInfoPanel.Controls.Add(productDiscountLabel);
            TableInfoPanel.Controls.Add(productUnitLabel);
            TableInfoPanel.Controls.Add(productSupplierLabel);
            TableInfoPanel.Controls.Add(productManufacturerLabel);
            TableInfoPanel.Controls.Add(productDescriptionLabel);
            TableInfoPanel.Controls.Add(productNameLabel);
            TableInfoPanel.Controls.Add(productCategoryLabel);
            TableInfoPanel.Controls.Add(productPriceLabel);
            TableInfoPanel.Controls.Add(productStockLabel);
            TableInfoPanel.Location = new Point(807, 17);
            TableInfoPanel.Name = "TableInfoPanel";
            TableInfoPanel.Size = new Size(351, 514);
            TableInfoPanel.TabIndex = 37;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(21, 284);
            label4.Name = "label4";
            label4.Size = new Size(109, 15);
            label4.TabIndex = 31;
            label4.Text = "Цена со скидкой:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.Location = new Point(21, 249);
            label5.Name = "label5";
            label5.Size = new Size(134, 15);
            label5.TabIndex = 30;
            label5.Text = "Скидка (в процентах):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(21, 222);
            label6.Name = "label6";
            label6.Size = new Size(129, 15);
            label6.TabIndex = 29;
            label6.Text = "Единица измерения:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(19, 192);
            label7.Name = "label7";
            label7.Size = new Size(76, 15);
            label7.TabIndex = 28;
            label7.Text = "Поставщик:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(19, 156);
            label8.Name = "label8";
            label8.Size = new Size(102, 15);
            label8.TabIndex = 27;
            label8.Text = "Производитель:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label9.Location = new Point(19, 136);
            label9.Name = "label9";
            label9.Size = new Size(68, 15);
            label9.TabIndex = 26;
            label9.Text = "Описание:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(19, 19);
            label10.Name = "label10";
            label10.Size = new Size(90, 15);
            label10.TabIndex = 22;
            label10.Text = "Имя продукта:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(19, 49);
            label11.Name = "label11";
            label11.Size = new Size(70, 15);
            label11.TabIndex = 23;
            label11.Text = "Категория:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label12.Location = new Point(19, 77);
            label12.Name = "label12";
            label12.Size = new Size(40, 15);
            label12.TabIndex = 24;
            label12.Text = "Цена:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label14.Location = new Point(19, 103);
            label14.Name = "label14";
            label14.Size = new Size(55, 15);
            label14.TabIndex = 25;
            label14.Text = "Остаток:";
            // 
            // productDiscountedPriceLabel
            // 
            productDiscountedPriceLabel.AutoSize = true;
            productDiscountedPriceLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productDiscountedPriceLabel.Location = new Point(190, 284);
            productDiscountedPriceLabel.Name = "productDiscountedPriceLabel";
            productDiscountedPriceLabel.Size = new Size(109, 15);
            productDiscountedPriceLabel.TabIndex = 21;
            productDiscountedPriceLabel.Text = "Цена со скидкой:";
            // 
            // productDiscountLabel
            // 
            productDiscountLabel.AutoSize = true;
            productDiscountLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productDiscountLabel.Location = new Point(190, 249);
            productDiscountLabel.Name = "productDiscountLabel";
            productDiscountLabel.Size = new Size(134, 15);
            productDiscountLabel.TabIndex = 20;
            productDiscountLabel.Text = "Скидка (в процентах):";
            // 
            // productUnitLabel
            // 
            productUnitLabel.AutoSize = true;
            productUnitLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productUnitLabel.Location = new Point(190, 222);
            productUnitLabel.Name = "productUnitLabel";
            productUnitLabel.Size = new Size(129, 15);
            productUnitLabel.TabIndex = 19;
            productUnitLabel.Text = "Единица измерения:";
            // 
            // productSupplierLabel
            // 
            productSupplierLabel.AutoSize = true;
            productSupplierLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productSupplierLabel.Location = new Point(190, 192);
            productSupplierLabel.Name = "productSupplierLabel";
            productSupplierLabel.Size = new Size(76, 15);
            productSupplierLabel.TabIndex = 18;
            productSupplierLabel.Text = "Поставщик:";
            // 
            // productManufacturerLabel
            // 
            productManufacturerLabel.AutoSize = true;
            productManufacturerLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productManufacturerLabel.Location = new Point(190, 156);
            productManufacturerLabel.Name = "productManufacturerLabel";
            productManufacturerLabel.Size = new Size(102, 15);
            productManufacturerLabel.TabIndex = 17;
            productManufacturerLabel.Text = "Производитель:";
            // 
            // productDescriptionLabel
            // 
            productDescriptionLabel.AutoSize = true;
            productDescriptionLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productDescriptionLabel.Location = new Point(190, 136);
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
            productNameLabel.Location = new Point(190, 19);
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
            productCategoryLabel.Location = new Point(190, 49);
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
            productPriceLabel.Location = new Point(190, 77);
            productPriceLabel.Name = "productPriceLabel";
            productPriceLabel.Size = new Size(40, 15);
            productPriceLabel.TabIndex = 11;
            productPriceLabel.Text = "Цена:";
            productPriceLabel.Click += productPriceLabel_Click;
            // 
            // productStockLabel
            // 
            productStockLabel.AutoSize = true;
            productStockLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productStockLabel.Location = new Point(190, 103);
            productStockLabel.Name = "productStockLabel";
            productStockLabel.Size = new Size(55, 15);
            productStockLabel.TabIndex = 12;
            productStockLabel.Text = "Остаток:";
            productStockLabel.Click += productStockLabel_Click;
            // 
            // refreshProductsButton
            // 
            refreshProductsButton.BackColor = SystemColors.ButtonHighlight;
            refreshProductsButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            refreshProductsButton.Location = new Point(667, 345);
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
            productsStatsLabel.Location = new Point(6, 534);
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
            deleteProductButton.Location = new Point(667, 489);
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
            editProductButton.Location = new Point(666, 441);
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
            addProductButton.Location = new Point(666, 393);
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
            resetProductFiltersButton.Location = new Point(667, 287);
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
            applyProductFiltersButton.Location = new Point(667, 239);
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
            label3.Location = new Point(667, 191);
            label3.Name = "label3";
            label3.Size = new Size(123, 15);
            label3.TabIndex = 29;
            label3.Text = "Сортировка товаров:";
            // 
            // productSortComboBox
            // 
            productSortComboBox.FormattingEnabled = true;
            productSortComboBox.Location = new Point(667, 209);
            productSortComboBox.Name = "productSortComboBox";
            productSortComboBox.Size = new Size(121, 23);
            productSortComboBox.TabIndex = 28;
            productSortComboBox.SelectedIndexChanged += productSortComboBox_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(667, 94);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 27;
            label2.Text = "Категории:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(667, 6);
            label1.Name = "label1";
            label1.Size = new Size(98, 15);
            label1.TabIndex = 26;
            label1.Text = "Список товаров:";
            // 
            // categoryFilterComboBox
            // 
            categoryFilterComboBox.FormattingEnabled = true;
            categoryFilterComboBox.Location = new Point(666, 112);
            categoryFilterComboBox.Name = "categoryFilterComboBox";
            categoryFilterComboBox.Size = new Size(121, 23);
            categoryFilterComboBox.TabIndex = 25;
            categoryFilterComboBox.SelectedIndexChanged += categoryFilterComboBox_SelectedIndexChanged;
            // 
            // productSearchTextBox
            // 
            productSearchTextBox.Location = new Point(667, 24);
            productSearchTextBox.Name = "productSearchTextBox";
            productSearchTextBox.Size = new Size(121, 23);
            productSearchTextBox.TabIndex = 24;
            productSearchTextBox.TextChanged += productSearchTextBox_TextChanged;
            productSearchTextBox.KeyDown += productSearchTextBox_KeyDown;
            // 
            // searchProductButton
            // 
            searchProductButton.BackColor = SystemColors.ButtonHighlight;
            searchProductButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            searchProductButton.Location = new Point(667, 53);
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
            productsDataGridView.Location = new Point(6, 6);
            productsDataGridView.Name = "productsDataGridView";
            productsDataGridView.Size = new Size(638, 525);
            productsDataGridView.TabIndex = 22;
            productsDataGridView.CellFormatting += productsDataGridView_CellFormatting;
            productsDataGridView.RowPrePaint += productsDataGridView_RowPrePaint;
            productsDataGridView.SelectionChanged += productsDataGridView_SelectionChanged;
            // 
            // ordersTab
            // 
            ordersTab.Controls.Add(editOrderButton);
            ordersTab.Controls.Add(addOrderButton);
            ordersTab.Controls.Add(TableInfoPanel2);
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
            ordersTab.Enter += ordersTab_Enter;
            // 
            // editOrderButton
            // 
            editOrderButton.BackColor = SystemColors.ButtonHighlight;
            editOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            editOrderButton.Location = new Point(667, 379);
            editOrderButton.Name = "editOrderButton";
            editOrderButton.Size = new Size(120, 42);
            editOrderButton.TabIndex = 52;
            editOrderButton.Text = "Редактировать заказ";
            editOrderButton.UseVisualStyleBackColor = false;
            editOrderButton.Click += editOrderButton_Click;
            // 
            // addOrderButton
            // 
            addOrderButton.BackColor = SystemColors.ButtonHighlight;
            addOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            addOrderButton.Location = new Point(667, 331);
            addOrderButton.Name = "addOrderButton";
            addOrderButton.Size = new Size(121, 42);
            addOrderButton.TabIndex = 51;
            addOrderButton.Text = "Добавить заказ";
            addOrderButton.UseVisualStyleBackColor = false;
            addOrderButton.Click += addOrderButton_Click;
            // 
            // TableInfoPanel2
            // 
            TableInfoPanel2.Controls.Add(orderIssueDateLabel);
            TableInfoPanel2.Controls.Add(orderAddressLabel);
            TableInfoPanel2.Controls.Add(label30);
            TableInfoPanel2.Controls.Add(label29);
            TableInfoPanel2.Controls.Add(label16);
            TableInfoPanel2.Controls.Add(label18);
            TableInfoPanel2.Controls.Add(label19);
            TableInfoPanel2.Controls.Add(label20);
            TableInfoPanel2.Controls.Add(label21);
            TableInfoPanel2.Controls.Add(label22);
            TableInfoPanel2.Controls.Add(label23);
            TableInfoPanel2.Controls.Add(orderStatusLabel);
            TableInfoPanel2.Controls.Add(orderIdLabel);
            TableInfoPanel2.Controls.Add(orderProductLabel);
            TableInfoPanel2.Controls.Add(orderCustomerLabel);
            TableInfoPanel2.Controls.Add(orderQuantityLabel);
            TableInfoPanel2.Controls.Add(orderDateLabel);
            TableInfoPanel2.Controls.Add(orderTotalLabelDetails);
            TableInfoPanel2.Location = new Point(805, 16);
            TableInfoPanel2.Name = "TableInfoPanel2";
            TableInfoPanel2.Size = new Size(350, 515);
            TableInfoPanel2.TabIndex = 50;
            // 
            // orderIssueDateLabel
            // 
            orderIssueDateLabel.AutoSize = true;
            orderIssueDateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderIssueDateLabel.Location = new Point(206, 161);
            orderIssueDateLabel.Name = "orderIssueDateLabel";
            orderIssueDateLabel.Size = new Size(84, 15);
            orderIssueDateLabel.TabIndex = 46;
            orderIssueDateLabel.Text = "Дата выдачи:";
            // 
            // orderAddressLabel
            // 
            orderAddressLabel.AutoSize = true;
            orderAddressLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderAddressLabel.Location = new Point(206, 132);
            orderAddressLabel.Name = "orderAddressLabel";
            orderAddressLabel.Size = new Size(45, 15);
            orderAddressLabel.TabIndex = 45;
            orderAddressLabel.Text = "Адрес:";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label30.Location = new Point(23, 161);
            label30.Name = "label30";
            label30.Size = new Size(84, 15);
            label30.TabIndex = 44;
            label30.Text = "Дата выдачи:";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label29.Location = new Point(23, 132);
            label29.Name = "label29";
            label29.Size = new Size(45, 15);
            label29.TabIndex = 43;
            label29.Text = "Адрес:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label16.Location = new Point(23, 102);
            label16.Name = "label16";
            label16.Size = new Size(120, 15);
            label16.TabIndex = 40;
            label16.Text = "Изменение статуса:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label18.Location = new Point(23, 18);
            label18.Name = "label18";
            label18.Size = new Size(23, 15);
            label18.TabIndex = 36;
            label18.Text = "ID:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label19.Location = new Point(23, 192);
            label19.Name = "label19";
            label19.Size = new Size(43, 15);
            label19.TabIndex = 37;
            label19.Text = "Товар:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label20.Location = new Point(23, 77);
            label20.Name = "label20";
            label20.Size = new Size(52, 15);
            label20.TabIndex = 42;
            label20.Text = "Клиент:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label21.Location = new Point(23, 219);
            label21.Name = "label21";
            label21.Size = new Size(79, 15);
            label21.TabIndex = 38;
            label21.Text = "Количество:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label22.Location = new Point(23, 47);
            label22.Name = "label22";
            label22.Size = new Size(36, 15);
            label22.TabIndex = 41;
            label22.Text = "Дата:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label23.Location = new Point(23, 246);
            label23.Name = "label23";
            label23.Size = new Size(43, 15);
            label23.TabIndex = 39;
            label23.Text = "Всего:";
            // 
            // orderStatusLabel
            // 
            orderStatusLabel.AutoSize = true;
            orderStatusLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            orderStatusLabel.Location = new Point(206, 102);
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
            orderIdLabel.Location = new Point(206, 18);
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
            orderProductLabel.Location = new Point(206, 192);
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
            orderCustomerLabel.Location = new Point(206, 77);
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
            orderQuantityLabel.Location = new Point(206, 219);
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
            orderDateLabel.Location = new Point(206, 47);
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
            orderTotalLabelDetails.Location = new Point(206, 246);
            orderTotalLabelDetails.Name = "orderTotalLabelDetails";
            orderTotalLabelDetails.Size = new Size(43, 15);
            orderTotalLabelDetails.TabIndex = 14;
            orderTotalLabelDetails.Text = "Всего:";
            orderTotalLabelDetails.Click += orderTotalLabelDetails_Click;
            // 
            // orderSearchTextBox
            // 
            orderSearchTextBox.Location = new Point(667, 48);
            orderSearchTextBox.Name = "orderSearchTextBox";
            orderSearchTextBox.Size = new Size(121, 23);
            orderSearchTextBox.TabIndex = 49;
            orderSearchTextBox.KeyDown += orderSearchTextBox_KeyDown;
            // 
            // deleteOrderButton
            // 
            deleteOrderButton.BackColor = SystemColors.ButtonHighlight;
            deleteOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            deleteOrderButton.Location = new Point(666, 489);
            deleteOrderButton.Name = "deleteOrderButton";
            deleteOrderButton.Size = new Size(121, 42);
            deleteOrderButton.TabIndex = 48;
            deleteOrderButton.Text = "Удалить заказ";
            deleteOrderButton.UseVisualStyleBackColor = false;
            deleteOrderButton.Click += deleteOrderButton_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(667, 30);
            label15.Name = "label15";
            label15.Size = new Size(95, 15);
            label15.TabIndex = 47;
            label15.Text = "Список заказов:";
            // 
            // ordersStatsLabel
            // 
            ordersStatsLabel.AutoSize = true;
            ordersStatsLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            ordersStatsLabel.Location = new Point(6, 534);
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
            refreshOrdersButton.Location = new Point(667, 283);
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
            resetOrderFiltersButton.Location = new Point(667, 235);
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
            applyOrderFiltersButton.Location = new Point(667, 187);
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
            label13.Location = new Point(667, 130);
            label13.Name = "label13";
            label13.Size = new Size(111, 15);
            label13.TabIndex = 42;
            label13.Text = "Фильтр по статусу:";
            // 
            // orderStatusFilterComboBox
            // 
            orderStatusFilterComboBox.FormattingEnabled = true;
            orderStatusFilterComboBox.Location = new Point(667, 148);
            orderStatusFilterComboBox.Name = "orderStatusFilterComboBox";
            orderStatusFilterComboBox.Size = new Size(121, 23);
            orderStatusFilterComboBox.TabIndex = 41;
            orderStatusFilterComboBox.SelectedIndexChanged += orderStatusFilterComboBox_SelectedIndexChanged;
            // 
            // searchOrderButton
            // 
            searchOrderButton.BackColor = SystemColors.ButtonHighlight;
            searchOrderButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            searchOrderButton.Location = new Point(667, 77);
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
            ordersDataGridView.Size = new Size(638, 525);
            ordersDataGridView.TabIndex = 39;
            ordersDataGridView.SelectionChanged += ordersDataGridView_SelectionChanged;
            // 
            // createOrderTab
            // 
            createOrderTab.Controls.Add(label32);
            createOrderTab.Controls.Add(issueDatePicker);
            createOrderTab.Controls.Add(label31);
            createOrderTab.Controls.Add(deliveryAddressTextBox);
            createOrderTab.Controls.Add(label28);
            createOrderTab.Controls.Add(label27);
            createOrderTab.Controls.Add(label26);
            createOrderTab.Controls.Add(createOrderTotalLabel);
            createOrderTab.Controls.Add(label25);
            createOrderTab.Controls.Add(orderQuantityComboBox);
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
            createOrderTab.Enter += createOrderTab_Enter;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Location = new Point(578, 270);
            label32.Name = "label32";
            label32.Size = new Size(79, 15);
            label32.TabIndex = 66;
            label32.Text = "Дата выдачи:";
            // 
            // issueDatePicker
            // 
            issueDatePicker.Location = new Point(579, 288);
            issueDatePicker.Name = "issueDatePicker";
            issueDatePicker.ShowCheckBox = true;
            issueDatePicker.Size = new Size(164, 23);
            issueDatePicker.TabIndex = 65;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(579, 220);
            label31.Name = "label31";
            label31.Size = new Size(43, 15);
            label31.TabIndex = 64;
            label31.Text = "Адрес:";
            // 
            // deliveryAddressTextBox
            // 
            deliveryAddressTextBox.Location = new Point(579, 238);
            deliveryAddressTextBox.Name = "deliveryAddressTextBox";
            deliveryAddressTextBox.Size = new Size(164, 23);
            deliveryAddressTextBox.TabIndex = 63;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label28.Location = new Point(579, 380);
            label28.Name = "label28";
            label28.Size = new Size(102, 15);
            label28.TabIndex = 62;
            label28.Text = "Итоговая сумма:";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label27.Location = new Point(579, 188);
            label27.Name = "label27";
            label27.Size = new Size(138, 15);
            label27.TabIndex = 61;
            label27.Text = "Количество на складе:";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label26.Location = new Point(579, 151);
            label26.Name = "label26";
            label26.Size = new Size(81, 15);
            label26.TabIndex = 60;
            label26.Text = "Цена товара:";
            // 
            // createOrderTotalLabel
            // 
            createOrderTotalLabel.AutoSize = true;
            createOrderTotalLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createOrderTotalLabel.Location = new Point(722, 380);
            createOrderTotalLabel.Name = "createOrderTotalLabel";
            createOrderTotalLabel.Size = new Size(102, 15);
            createOrderTotalLabel.TabIndex = 59;
            createOrderTotalLabel.Text = "Итоговая сумма:";
            createOrderTotalLabel.Click += createOrderTotalLabel_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(579, 323);
            label25.Name = "label25";
            label25.Size = new Size(113, 15);
            label25.TabIndex = 58;
            label25.Text = "Выбор количества:";
            // 
            // orderQuantityComboBox
            // 
            orderQuantityComboBox.FormattingEnabled = true;
            orderQuantityComboBox.Location = new Point(579, 341);
            orderQuantityComboBox.Name = "orderQuantityComboBox";
            orderQuantityComboBox.Size = new Size(164, 23);
            orderQuantityComboBox.TabIndex = 56;
            orderQuantityComboBox.SelectedIndexChanged += orderQuantityComboBox_SelectedIndexChanged;
            // 
            // createOrderProductStockLabel
            // 
            createOrderProductStockLabel.AutoSize = true;
            createOrderProductStockLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            createOrderProductStockLabel.Location = new Point(723, 188);
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
            createOrderProductPriceLabel.Location = new Point(723, 151);
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
            createOrderButton.Location = new Point(579, 413);
            createOrderButton.Name = "createOrderButton";
            createOrderButton.Size = new Size(164, 42);
            createOrderButton.TabIndex = 52;
            createOrderButton.Text = "Сделать заказ";
            createOrderButton.UseVisualStyleBackColor = false;
            createOrderButton.Click += createOrderButton_Click;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(580, 81);
            label17.Name = "label17";
            label17.Size = new Size(87, 15);
            label17.TabIndex = 51;
            label17.Text = "Выбор товара:";
            // 
            // createOrderProductComboBox
            // 
            createOrderProductComboBox.FormattingEnabled = true;
            createOrderProductComboBox.Location = new Point(580, 108);
            createOrderProductComboBox.Name = "createOrderProductComboBox";
            createOrderProductComboBox.Size = new Size(163, 23);
            createOrderProductComboBox.TabIndex = 50;
            createOrderProductComboBox.SelectedIndexChanged += createOrderProductComboBox_SelectedIndexChanged;
            // 
            // closeButton
            // 
            closeButton.BackColor = Color.FromArgb(255, 128, 128);
            closeButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            closeButton.Location = new Point(12, 623);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(75, 48);
            closeButton.TabIndex = 0;
            closeButton.Text = "Назад";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // refreshAllButton
            // 
            refreshAllButton.BackColor = SystemColors.ButtonHighlight;
            refreshAllButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            refreshAllButton.Location = new Point(102, 623);
            refreshAllButton.Name = "refreshAllButton";
            refreshAllButton.Size = new Size(139, 48);
            refreshAllButton.TabIndex = 1;
            refreshAllButton.Text = "Обновить все данные";
            refreshAllButton.UseVisualStyleBackColor = false;
            refreshAllButton.Click += refreshAllButton_Click;
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(266, 640);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(66, 15);
            statusLabel.TabIndex = 2;
            statusLabel.Text = "statusLabel";
            statusLabel.Click += statusLabel_Click;
            // 
            // userFullNameLabel
            // 
            userFullNameLabel.AutoSize = true;
            userFullNameLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            userFullNameLabel.Location = new Point(596, 9);
            userFullNameLabel.Name = "userFullNameLabel";
            userFullNameLabel.Size = new Size(112, 15);
            userFullNameLabel.TabIndex = 5;
            userFullNameLabel.Text = "userFullNameLabel";
            // 
            // ManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 687);
            Controls.Add(userFullNameLabel);
            Controls.Add(statusLabel);
            Controls.Add(refreshAllButton);
            Controls.Add(closeButton);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ManagementForm";
            Text = "Магазин Обуви";
            tabControl1.ResumeLayout(false);
            productsTab.ResumeLayout(false);
            productsTab.PerformLayout();
            TableInfoPanel.ResumeLayout(false);
            TableInfoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)productsDataGridView).EndInit();
            ordersTab.ResumeLayout(false);
            ordersTab.PerformLayout();
            TableInfoPanel2.ResumeLayout(false);
            TableInfoPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
            createOrderTab.ResumeLayout(false);
            createOrderTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage productsTab;
        private TabPage ordersTab;
        private TabPage createOrderTab;
        private Button closeButton;
        private Button refreshAllButton;
        private Label statusLabel;
        private Panel TableInfoPanel;
        private Label productDescriptionLabel;
        private Label productNameLabel;
        private Label productCategoryLabel;
        private Label productPriceLabel;
        private Label productStockLabel;
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
        private Panel TableInfoPanel2;
        private Label orderStatusLabel;
        private Label orderIdLabel;
        private Label orderProductLabel;
        private Label orderCustomerLabel;
        private Label orderQuantityLabel;
        private Label orderDateLabel;
        private Label orderTotalLabelDetails;
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
        private Label createOrderTotalLabel;
        private Label label25;
        private ComboBox orderQuantityComboBox;
        private Label createOrderProductStockLabel;
        private Label createOrderProductPriceLabel;
        private Button createOrderButton;
        private Label label17;
        private ComboBox createOrderProductComboBox;
        private Label userFullNameLabel;
        private Label productDiscountLabel;
        private Label productUnitLabel;
        private Label productSupplierLabel;
        private Label productManufacturerLabel;
        private Label productDiscountedPriceLabel;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label14;
        private Label label16;
        private Label label18;
        private Label label19;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private ComboBox supplierFilterComboBox;
        private Label label28;
        private Label label27;
        private Label label26;
        private Button editOrderButton;
        private Button addOrderButton;
        private Label label29;
        private Label orderIssueDateLabel;
        private Label orderAddressLabel;
        private Label label30;
        private DateTimePicker issueDatePicker;
        private Label label31;
        private TextBox deliveryAddressTextBox;
        private Label label32;
    }
}