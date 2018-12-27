namespace WindowsForms.Stock
{
    partial class StockManager
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnInitStock = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.stockBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buyDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.curPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planEarnMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowBuyPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expectedSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.changed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.codeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.buyPriceDataGridViewTextBoxColumn,
            this.salePriceDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.buyDate,
            this.typeDataGridViewTextBoxColumn,
            this.curPrice,
            this.planEarnMoney,
            this.lowBuyPrice,
            this.expectedSource,
            this.changed,
            this.area});
            this.dataGridView1.DataSource = this.stockBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(24, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1097, 244);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(24, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInitStock
            // 
            this.btnInitStock.Location = new System.Drawing.Point(334, 21);
            this.btnInitStock.Name = "btnInitStock";
            this.btnInitStock.Size = new System.Drawing.Size(75, 23);
            this.btnInitStock.TabIndex = 3;
            this.btnInitStock.Text = "初始化股票信息";
            this.btnInitStock.UseVisualStyleBackColor = true;
            this.btnInitStock.Visible = false;
            this.btnInitStock.Click += new System.EventHandler(this.btnInitStock_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(121, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "删除";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1163, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataSource = typeof(WindowsForms.Stock.stock);
            // 
            // stockBindingSource1
            // 
            this.stockBindingSource1.DataSource = typeof(WindowsForms.Stock.stock);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "code";
            this.codeDataGridViewTextBoxColumn.HeaderText = "code";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.Width = 60;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 60;
            // 
            // buyPriceDataGridViewTextBoxColumn
            // 
            this.buyPriceDataGridViewTextBoxColumn.DataPropertyName = "buyPrice";
            this.buyPriceDataGridViewTextBoxColumn.HeaderText = "buyPrice";
            this.buyPriceDataGridViewTextBoxColumn.Name = "buyPriceDataGridViewTextBoxColumn";
            this.buyPriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // salePriceDataGridViewTextBoxColumn
            // 
            this.salePriceDataGridViewTextBoxColumn.DataPropertyName = "salePrice";
            this.salePriceDataGridViewTextBoxColumn.HeaderText = "salePrice";
            this.salePriceDataGridViewTextBoxColumn.Name = "salePriceDataGridViewTextBoxColumn";
            this.salePriceDataGridViewTextBoxColumn.Width = 80;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "count";
            this.countDataGridViewTextBoxColumn.HeaderText = "count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.Width = 60;
            // 
            // buyDate
            // 
            this.buyDate.DataPropertyName = "buyDate";
            this.buyDate.HeaderText = "buyDate";
            this.buyDate.Name = "buyDate";
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "type";
            this.typeDataGridViewTextBoxColumn.Items.AddRange(new object[] {
            "持有",
            "观望"});
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.typeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // curPrice
            // 
            this.curPrice.HeaderText = "curPrice";
            this.curPrice.Name = "curPrice";
            this.curPrice.ReadOnly = true;
            this.curPrice.Width = 80;
            // 
            // planEarnMoney
            // 
            this.planEarnMoney.DataPropertyName = "planEarnMoney";
            this.planEarnMoney.HeaderText = "planEarnMoney";
            this.planEarnMoney.Name = "planEarnMoney";
            this.planEarnMoney.Width = 80;
            // 
            // lowBuyPrice
            // 
            this.lowBuyPrice.DataPropertyName = "lowBuyPrice";
            this.lowBuyPrice.HeaderText = "lowBuyPrice";
            this.lowBuyPrice.Name = "lowBuyPrice";
            this.lowBuyPrice.Width = 80;
            // 
            // expectedSource
            // 
            this.expectedSource.DataPropertyName = "expectedSource";
            this.expectedSource.HeaderText = "expectedSource";
            this.expectedSource.Name = "expectedSource";
            // 
            // changed
            // 
            this.changed.HeaderText = "changed";
            this.changed.Name = "changed";
            this.changed.Visible = false;
            // 
            // area
            // 
            this.area.DataPropertyName = "area";
            this.area.HeaderText = "area";
            this.area.Name = "area";
            this.area.Visible = false;
            // 
            // StockManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 486);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnInitStock);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "StockManager";
            this.Text = "股票维护";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnInitStock;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.BindingSource stockBindingSource;
        private System.Windows.Forms.BindingSource stockBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buyDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn curPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn planEarnMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn expectedSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn changed;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
    }
}