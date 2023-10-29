namespace BookWiz
{
    partial class Balance
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
            dataSet11 = new DataSet1();
            tableLayoutPanel1 = new TableLayoutPanel();
            TotalLabel = new Label();
            ReconciledLabel = new Label();
            NonReconciledLabel = new Label();
            ReconciliationBTN = new Button();
            TotalAmountLabel = new Label();
            ReconciledAmountLabel = new Label();
            NonreconciledAmountLabel = new Label();
            tabControl1 = new TabControl();
            All = new TabPage();
            dataGridView1 = new DataGridView();
            Reconciled = new TabPage();
            dataGridView2 = new DataGridView();
            Nonreconciled = new TabPage();
            dataGridView3 = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataSet11).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            All.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            Reconciled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            Nonreconciled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // dataSet11
            // 
            dataSet11.DataSetName = "DataSet1";
            dataSet11.Namespace = "http://tempuri.org/DataSet1.xsd";
            dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(TotalLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(ReconciledLabel, 2, 0);
            tableLayoutPanel1.Controls.Add(NonReconciledLabel, 4, 0);
            tableLayoutPanel1.Controls.Add(ReconciliationBTN, 6, 0);
            tableLayoutPanel1.Controls.Add(TotalAmountLabel, 1, 0);
            tableLayoutPanel1.Controls.Add(ReconciledAmountLabel, 3, 0);
            tableLayoutPanel1.Controls.Add(NonreconciledAmountLabel, 5, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(800, 450);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Dock = DockStyle.Fill;
            TotalLabel.Location = new Point(3, 0);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(35, 31);
            TotalLabel.TabIndex = 1;
            TotalLabel.Text = "Total:";
            TotalLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReconciledLabel
            // 
            ReconciledLabel.AutoSize = true;
            ReconciledLabel.Dock = DockStyle.Fill;
            ReconciledLabel.Location = new Point(177, 0);
            ReconciledLabel.Name = "ReconciledLabel";
            ReconciledLabel.Size = new Size(68, 31);
            ReconciledLabel.TabIndex = 2;
            ReconciledLabel.Text = "Reconciled:";
            ReconciledLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NonReconciledLabel
            // 
            NonReconciledLabel.AutoSize = true;
            NonReconciledLabel.Dock = DockStyle.Fill;
            NonReconciledLabel.Location = new Point(384, 0);
            NonReconciledLabel.Name = "NonReconciledLabel";
            NonReconciledLabel.Size = new Size(88, 31);
            NonReconciledLabel.TabIndex = 3;
            NonReconciledLabel.Text = "Nonreconciled:";
            NonReconciledLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReconciliationBTN
            // 
            ReconciliationBTN.AutoSize = true;
            ReconciliationBTN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ReconciliationBTN.Dock = DockStyle.Fill;
            ReconciliationBTN.Location = new Point(611, 3);
            ReconciliationBTN.Name = "ReconciliationBTN";
            ReconciliationBTN.Size = new Size(186, 25);
            ReconciliationBTN.TabIndex = 4;
            ReconciliationBTN.Text = "Reconcile/Pending/Unreconcile";
            ReconciliationBTN.UseVisualStyleBackColor = true;
            ReconciliationBTN.Click += ReconciliationBTN_Click;
            // 
            // TotalAmountLabel
            // 
            TotalAmountLabel.AutoSize = true;
            TotalAmountLabel.Dock = DockStyle.Fill;
            TotalAmountLabel.Location = new Point(44, 0);
            TotalAmountLabel.Name = "TotalAmountLabel";
            TotalAmountLabel.Size = new Size(127, 31);
            TotalAmountLabel.TabIndex = 5;
            TotalAmountLabel.Text = "$0.00";
            TotalAmountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ReconciledAmountLabel
            // 
            ReconciledAmountLabel.AutoSize = true;
            ReconciledAmountLabel.Dock = DockStyle.Fill;
            ReconciledAmountLabel.Location = new Point(251, 0);
            ReconciledAmountLabel.Name = "ReconciledAmountLabel";
            ReconciledAmountLabel.Size = new Size(127, 31);
            ReconciledAmountLabel.TabIndex = 6;
            ReconciledAmountLabel.Text = "$0.00";
            ReconciledAmountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // NonreconciledAmountLabel
            // 
            NonreconciledAmountLabel.AutoSize = true;
            NonreconciledAmountLabel.Dock = DockStyle.Fill;
            NonreconciledAmountLabel.Location = new Point(478, 0);
            NonreconciledAmountLabel.Name = "NonreconciledAmountLabel";
            NonreconciledAmountLabel.Size = new Size(127, 31);
            NonreconciledAmountLabel.TabIndex = 7;
            NonreconciledAmountLabel.Text = "$0.00";
            NonreconciledAmountLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 7);
            tabControl1.Controls.Add(All);
            tabControl1.Controls.Add(Reconciled);
            tabControl1.Controls.Add(Nonreconciled);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 34);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(794, 413);
            tabControl1.TabIndex = 9;
            // 
            // All
            // 
            All.Controls.Add(dataGridView1);
            All.Location = new Point(4, 24);
            All.Name = "All";
            All.Padding = new Padding(3);
            All.Size = new Size(786, 385);
            All.TabIndex = 0;
            All.Text = "All Transactions";
            All.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(780, 379);
            dataGridView1.TabIndex = 1;
            // 
            // Reconciled
            // 
            Reconciled.Controls.Add(dataGridView2);
            Reconciled.Location = new Point(4, 24);
            Reconciled.Name = "Reconciled";
            Reconciled.Padding = new Padding(3);
            Reconciled.Size = new Size(786, 385);
            Reconciled.TabIndex = 1;
            Reconciled.Text = "Reconciled";
            Reconciled.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(780, 379);
            dataGridView2.TabIndex = 0;
            // 
            // Nonreconciled
            // 
            Nonreconciled.Controls.Add(dataGridView3);
            Nonreconciled.Location = new Point(4, 24);
            Nonreconciled.Name = "Nonreconciled";
            Nonreconciled.Padding = new Padding(3);
            Nonreconciled.Size = new Size(786, 385);
            Nonreconciled.TabIndex = 2;
            Nonreconciled.Text = "Nonreconciled";
            Nonreconciled.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(3, 3);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.Size = new Size(780, 379);
            dataGridView3.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4993782F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4993753F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4993753F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4993753F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4993753F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4993753F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5018749F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5018749F));
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(200, 100);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(18, 60);
            label1.TabIndex = 1;
            label1.Text = "Total:";
            // 
            // Balance
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Balance";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BookWiz - Balance Checkbook";
            ((System.ComponentModel.ISupportInitialize)dataSet11).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            All.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            Reconciled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            Nonreconciled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataSet1 dataSet11;
        private TableLayoutPanel tableLayoutPanel1;
        private Label TotalLabel;
        private Label ReconciledLabel;
        private Label NonReconciledLabel;
        private Button ReconciliationBTN;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Label TotalAmountLabel;
        private Label ReconciledAmountLabel;
        private Label NonreconciledAmountLabel;
        private TabControl tabControl1;
        private TabPage All;
        private TabPage Reconciled;
        private TabPage Nonreconciled;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridView dataGridView1;
    }
}