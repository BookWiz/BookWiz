using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using static BookWiz.Balance;
namespace BookWiz
{
    public partial class BookWiz : Form
    {
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip1;
        private ToolStripButton newToolStripButton;
        private ToolStripButton openToolStripButton;
        private ToolStripButton saveToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton helpToolStripButton;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private DateTimePicker dateTimePicker1;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private ComboBox comboBox1;
        private Button ConfirmBTN;
        private Button CancelBTN;
        private DateTime MaxSelectedDate;
        private TextBox DescriptionBox;
        internal static DataTable dt;
        private TableLayoutPanel tableLayoutPanel2;
        private Label GrandTotalLabel;
        private Label TotalLabel;
        private TableLayoutPanel tableLayoutPanel4;
        private Label IncomeTotalLabel;
        private Label label5;
        private DataGridView dataGridView2;
        private TableLayoutPanel tableLayoutPanel5;
        private Label ExpenseTotalLabel;
        private Label label7;
        private DataGridView dataGridView3;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private DataSet dataSet = new();
        object incomeTotal = 0;
        object expenseTotal = 0;
        private ToolStripButton printToolStripButton;
        object grandTotal;
        DataView Income;
        DataView Expenses;
        private ToolStripButton BalanceBTN;
        private ToolStripSeparator toolStripSeparator1;
        readonly CultureInfo culture = new("en-us");
        private void RefreshTables()
        {
            dt.AcceptChanges();
            incomeTotal = 0;
            expenseTotal = 0;
            ReconciledTotal = 0;
            NonreconciledTotal = 0;
            incomeTotal = Income.ToTable().Compute("sum(Amount)", string.Empty);
            expenseTotal = Expenses.ToTable().Compute("sum(Amount)", string.Empty);
            grandTotal = dt.Compute("sum(Amount)", string.Empty);
            ReconciledView.RowFilter = "Reconciled = true";
            NonreconciledView.RowFilter = "Reconciled = false";

            if (expenseTotal == DBNull.Value)
            {
                ExpenseTotalLabel.Text = "$0.00";
            }
            else
            {
                ExpenseTotalLabel.Text = Convert.ToDecimal(expenseTotal).ToString("C", culture);
            }
            if (incomeTotal == DBNull.Value)
            {
                IncomeTotalLabel.Text = "$0.00";
            }
            else
            {
                IncomeTotalLabel.Text = Convert.ToDecimal(incomeTotal).ToString("C", culture);
            }
            if (grandTotal == DBNull.Value)
            {
                GrandTotalLabel.Text = "$0.00";
            }
            else if (grandTotal == null)
            {
                GrandTotalLabel.Text = "$0.00";
            }

            else
            {
                GrandTotalLabel.Text = Convert.ToDecimal(grandTotal).ToString("C", culture);
            }
            dataGridView1.DataSource = dt;
            dataGridView2.DataSource = Income;
            dataGridView3.DataSource = Expenses;
            dt.DefaultView.Sort = "Date";
            Income.Sort = "Date";
            Expenses.Sort = "Date";
            dataGridView1.Columns["Amount"].DefaultCellStyle.Format = "C";
            dataGridView2.Columns["Amount"].DefaultCellStyle.Format = "C";
            dataGridView3.Columns["Amount"].DefaultCellStyle.Format = "C";
            int wide = 100;
            dataGridView1.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView3.Columns["Date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Date"].Width = wide;
            dataGridView2.Columns["Date"].Width = wide;
            dataGridView3.Columns["Date"].Width = wide;
            dataGridView1.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView3.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Amount"].Width = wide;
            dataGridView2.Columns["Amount"].Width = wide;
            dataGridView3.Columns["Amount"].Width = wide;
            dataGridView1.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView3.Columns["Type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Type"].Width = wide;
            dataGridView2.Columns["Type"].Width = wide;
            dataGridView3.Columns["Type"].Width = wide;
            dataGridView1.Columns["Reconciled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["Reconciled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView3.Columns["Reconciled"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Reconciled"].Width = wide;
            dataGridView2.Columns["Reconciled"].Width = wide;
            dataGridView3.Columns["Reconciled"].Width = wide;
            dataGridView1.Columns["Pending"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns["Pending"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView3.Columns["Pending"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns["Pending"].Width = wide;
            dataGridView2.Columns["Pending"].Width = wide;
            dataGridView3.Columns["Pending"].Width = wide;
            ReconciledTotal = Balance.ReconciledView.ToTable().Compute("sum(Amount)", string.Empty);
            NonreconciledTotal = NonreconciledView.ToTable().Compute("sum(Amount)", string.Empty);
            dataSet.AcceptChanges();
        }

        private void Reset()
        {
            MaxSelectedDate = dateTimePicker1.MaxDate;
            if (DateTime.Today > MaxSelectedDate)
            {
                dateTimePicker1.MaxDate = DateTime.Today;
            }
            dateTimePicker1.ResetText();
            numericUpDown1.Value = 0;
            numericUpDown1.DecimalPlaces = 2;

            comboBox1.SelectedItem = null;
            comboBox1.Text = "Transaction Type";
            DescriptionBox.ResetText();
            DescriptionBox.Text = null;
        }
        private void NewDoc()
        {
            dt.Rows.Clear();
            Reset();
            RefreshTables();
        }
        public BookWiz()
        {
            dt = new DataTable();
            Income = new DataView(dt);
            Expenses = new DataView(dt);
            dt.Clear();
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Amount", typeof(decimal));
            dt.Columns.Add("Type", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Reconciled", typeof(bool));
            dt.Columns.Add("Pending", typeof(bool));
            Income.RowFilter = "Type = 'Income'";
            Expenses.RowFilter = "Type = 'Expenses'";
            dataSet.Tables.Add(dt);
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Today;
            MaxSelectedDate = dateTimePicker1.MaxDate;
            if (DateTime.Today > MaxSelectedDate)
            {
                MaxSelectedDate = DateTime.Today;
            }
            NewDoc();
            RefreshTables();
        }
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(BookWiz));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            toolStrip1 = new ToolStrip();
            newToolStripButton = new ToolStripButton();
            openToolStripButton = new ToolStripButton();
            saveToolStripButton = new ToolStripButton();
            printToolStripButton = new ToolStripButton();
            toolStripSeparator = new ToolStripSeparator();
            BalanceBTN = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            helpToolStripButton = new ToolStripButton();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            GrandTotalLabel = new Label();
            TotalLabel = new Label();
            dataGridView1 = new DataGridView();
            tabPage2 = new TabPage();
            tableLayoutPanel4 = new TableLayoutPanel();
            IncomeTotalLabel = new Label();
            label5 = new Label();
            dataGridView2 = new DataGridView();
            tabPage3 = new TabPage();
            tableLayoutPanel5 = new TableLayoutPanel();
            ExpenseTotalLabel = new Label();
            label7 = new Label();
            dataGridView3 = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            comboBox1 = new ComboBox();
            ConfirmBTN = new Button();
            CancelBTN = new Button();
            DescriptionBox = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            label2 = new Label();
            label3 = new Label();
            tableLayoutPanel1.SuspendLayout();
            toolStrip1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((ISupportInitialize)dataGridView1).BeginInit();
            tabPage2.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            ((ISupportInitialize)dataGridView2).BeginInit();
            tabPage3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((ISupportInitialize)dataGridView3).BeginInit();
            ((ISupportInitialize)numericUpDown1).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 7;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(toolStrip1, 0, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 3);
            tableLayoutPanel1.Controls.Add(dateTimePicker1, 0, 1);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 1, 1);
            tableLayoutPanel1.Controls.Add(comboBox1, 3, 1);
            tableLayoutPanel1.Controls.Add(ConfirmBTN, 5, 1);
            tableLayoutPanel1.Controls.Add(CancelBTN, 6, 1);
            tableLayoutPanel1.Controls.Add(DescriptionBox, 4, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(840, 723);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.HelpRequested += HelpRequested;
            // 
            // toolStrip1
            // 
            tableLayoutPanel1.SetColumnSpan(toolStrip1, 7);
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { newToolStripButton, openToolStripButton, saveToolStripButton, printToolStripButton, toolStripSeparator, BalanceBTN, toolStripSeparator1, helpToolStripButton });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(840, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            newToolStripButton.Image = (Image)resources.GetObject("newToolStripButton.Image");
            newToolStripButton.ImageTransparentColor = Color.Magenta;
            newToolStripButton.Name = "newToolStripButton";
            newToolStripButton.Size = new Size(23, 22);
            newToolStripButton.Text = "&New";
            newToolStripButton.Click += NewToolStripButton_Click;
            // 
            // openToolStripButton
            // 
            openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            openToolStripButton.Image = (Image)resources.GetObject("openToolStripButton.Image");
            openToolStripButton.ImageTransparentColor = Color.Magenta;
            openToolStripButton.Name = "openToolStripButton";
            openToolStripButton.Size = new Size(23, 22);
            openToolStripButton.Text = "&Open";
            openToolStripButton.Click += OpenToolStripButton_Click;
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = (Image)resources.GetObject("saveToolStripButton.Image");
            saveToolStripButton.ImageTransparentColor = Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new Size(23, 22);
            saveToolStripButton.Text = "&Save";
            saveToolStripButton.Click += SaveToolStripButton_Click;
            // 
            // printToolStripButton
            // 
            printToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            printToolStripButton.Image = (Image)resources.GetObject("printToolStripButton.Image");
            printToolStripButton.ImageTransparentColor = Color.Magenta;
            printToolStripButton.Name = "printToolStripButton";
            printToolStripButton.Size = new Size(23, 22);
            printToolStripButton.Text = "&Print";
            printToolStripButton.Click += ExportToolStripButton1_Click;
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 25);
            // 
            // BalanceBTN
            // 
            BalanceBTN.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BalanceBTN.Image = (Image)resources.GetObject("BalanceBTN.Image");
            BalanceBTN.ImageTransparentColor = Color.Magenta;
            BalanceBTN.Name = "BalanceBTN";
            BalanceBTN.Size = new Size(23, 22);
            BalanceBTN.Text = "Balance Checkbook";
            BalanceBTN.Click += BalanceBTN_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // helpToolStripButton
            // 
            helpToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            helpToolStripButton.Image = (Image)resources.GetObject("helpToolStripButton.Image");
            helpToolStripButton.ImageTransparentColor = Color.Magenta;
            helpToolStripButton.Name = "helpToolStripButton";
            helpToolStripButton.Size = new Size(23, 22);
            helpToolStripButton.Text = "He&lp";
            helpToolStripButton.Click += HelpToolStripButton_Click;
            // 
            // tabControl1
            // 
            tableLayoutPanel1.SetColumnSpan(tabControl1, 7);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(3, 59);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(834, 661);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(tableLayoutPanel2);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(826, 633);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "All Transactions";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(GrandTotalLabel, 1, 0);
            tableLayoutPanel2.Controls.Add(TotalLabel, 0, 0);
            tableLayoutPanel2.Controls.Add(dataGridView1, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.Size = new Size(820, 627);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // GrandTotalLabel
            // 
            GrandTotalLabel.AutoSize = true;
            GrandTotalLabel.Dock = DockStyle.Fill;
            GrandTotalLabel.Location = new Point(41, 0);
            GrandTotalLabel.Name = "GrandTotalLabel";
            GrandTotalLabel.Size = new Size(782, 15);
            GrandTotalLabel.TabIndex = 11;
            GrandTotalLabel.Text = "$0.00";
            GrandTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TotalLabel
            // 
            TotalLabel.AutoSize = true;
            TotalLabel.Dock = DockStyle.Fill;
            TotalLabel.Location = new Point(3, 0);
            TotalLabel.Name = "TotalLabel";
            TotalLabel.Size = new Size(32, 15);
            TotalLabel.TabIndex = 10;
            TotalLabel.Text = "Total";
            TotalLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowDrop = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel2.SetColumnSpan(dataGridView1, 2);
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 18);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(820, 612);
            dataGridView1.TabIndex = 1;
            dataGridView1.UserDeletedRow += DataGridView1_UserDeletedRow;
            dataGridView1.DragDrop += dataGridView1_DragDrop;
            dataGridView1.DragOver += dataGridView1_DragOver;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tableLayoutPanel4);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(826, 633);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Income";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel4.Controls.Add(IncomeTotalLabel, 1, 0);
            tableLayoutPanel4.Controls.Add(label5, 0, 0);
            tableLayoutPanel4.Controls.Add(dataGridView2, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 2;
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.RowStyles.Add(new RowStyle());
            tableLayoutPanel4.Size = new Size(820, 627);
            tableLayoutPanel4.TabIndex = 2;
            // 
            // IncomeTotalLabel
            // 
            IncomeTotalLabel.AutoSize = true;
            IncomeTotalLabel.Dock = DockStyle.Fill;
            IncomeTotalLabel.Location = new Point(41, 0);
            IncomeTotalLabel.Name = "IncomeTotalLabel";
            IncomeTotalLabel.Size = new Size(782, 15);
            IncomeTotalLabel.TabIndex = 11;
            IncomeTotalLabel.Text = "$0.00";
            IncomeTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Dock = DockStyle.Fill;
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(32, 15);
            label5.TabIndex = 10;
            label5.Text = "Total";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel4.SetColumnSpan(dataGridView2, 2);
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(3, 18);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(820, 612);
            dataGridView2.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(tableLayoutPanel5);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(826, 633);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Expenses";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel5.Controls.Add(ExpenseTotalLabel, 1, 0);
            tableLayoutPanel5.Controls.Add(label7, 0, 0);
            tableLayoutPanel5.Controls.Add(dataGridView3, 0, 1);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 2;
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.Size = new Size(820, 627);
            tableLayoutPanel5.TabIndex = 2;
            // 
            // ExpenseTotalLabel
            // 
            ExpenseTotalLabel.AutoSize = true;
            ExpenseTotalLabel.Dock = DockStyle.Fill;
            ExpenseTotalLabel.Location = new Point(41, 0);
            ExpenseTotalLabel.Name = "ExpenseTotalLabel";
            ExpenseTotalLabel.Size = new Size(782, 15);
            ExpenseTotalLabel.TabIndex = 11;
            ExpenseTotalLabel.Text = "$0.00";
            ExpenseTotalLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Dock = DockStyle.Fill;
            label7.Location = new Point(3, 0);
            label7.Name = "label7";
            label7.Size = new Size(32, 15);
            label7.TabIndex = 10;
            label7.Text = "Total";
            label7.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dataGridView3
            // 
            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tableLayoutPanel5.SetColumnSpan(dataGridView3, 2);
            dataGridView3.Dock = DockStyle.Fill;
            dataGridView3.Location = new Point(3, 18);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView3.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView3.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(820, 612);
            dataGridView3.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.AllowDrop = true;
            dateTimePicker1.CustomFormat = "";
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(3, 28);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(114, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // numericUpDown1
            // 
            numericUpDown1.AllowDrop = true;
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Location = new Point(148, 28);
            numericUpDown1.Maximum = new decimal(new int[] { 999999, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(114, 23);
            numericUpDown1.TabIndex = 3;
            numericUpDown1.ThousandsSeparator = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(123, 25);
            label1.Name = "label1";
            label1.Size = new Size(19, 31);
            label1.TabIndex = 4;
            label1.Text = "$";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.Dock = DockStyle.Fill;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Income", "Expenses" });
            comboBox1.Location = new Point(268, 28);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(114, 23);
            comboBox1.TabIndex = 5;
            comboBox1.Text = "Transaction Type";
            // 
            // ConfirmBTN
            // 
            ConfirmBTN.AutoSize = true;
            ConfirmBTN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ConfirmBTN.Dock = DockStyle.Fill;
            ConfirmBTN.Location = new Point(717, 28);
            ConfirmBTN.Name = "ConfirmBTN";
            ConfirmBTN.Size = new Size(61, 25);
            ConfirmBTN.TabIndex = 6;
            ConfirmBTN.Text = "Confirm";
            ConfirmBTN.UseVisualStyleBackColor = true;
            ConfirmBTN.Click += ConfirmBTN_Click_1;
            // 
            // CancelBTN
            // 
            CancelBTN.AutoSize = true;
            CancelBTN.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelBTN.Dock = DockStyle.Fill;
            CancelBTN.Location = new Point(784, 28);
            CancelBTN.Name = "CancelBTN";
            CancelBTN.Size = new Size(53, 25);
            CancelBTN.TabIndex = 7;
            CancelBTN.Text = "Cancel";
            CancelBTN.UseVisualStyleBackColor = true;
            CancelBTN.Click += CancelBTN_Click_1;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Dock = DockStyle.Fill;
            DescriptionBox.Location = new Point(388, 28);
            DescriptionBox.MaxLength = 16;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.PlaceholderText = "Description";
            DescriptionBox.Size = new Size(323, 23);
            DescriptionBox.TabIndex = 8;
            DescriptionBox.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel3.Controls.Add(label2, 1, 0);
            tableLayoutPanel3.Location = new Point(0, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(200, 100);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(194, 100);
            label2.TabIndex = 11;
            label2.Text = "$0.00";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(32, 100);
            label3.TabIndex = 10;
            label3.Text = "Total";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // BookWiz
            // 
            AcceptButton = ConfirmBTN;
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CancelButton = CancelBTN;
            ClientSize = new Size(840, 723);
            Controls.Add(tableLayoutPanel1);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BookWiz";
            Text = "BookWiz";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((ISupportInitialize)dataGridView1).EndInit();
            tabPage2.ResumeLayout(false);
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ((ISupportInitialize)dataGridView2).EndInit();
            tabPage3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((ISupportInitialize)dataGridView3).EndInit();
            ((ISupportInitialize)numericUpDown1).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfirmBTN_Click_1(object sender, EventArgs e)
        {

            if (DescriptionBox.Text == "")
            {
                RefreshTables();
            }
            else
            {
                if (comboBox1.SelectedItem == null)
                {
                    RefreshTables();
                }
                else if (comboBox1.SelectedItem.ToString() == "Income")
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = dateTimePicker1.Value.Date;
                    dr[1] = numericUpDown1.Value;
                    dr[2] = comboBox1.SelectedItem;
                    dr[3] = DescriptionBox.Text;
                    dr[4] = false;
                    dr[5] = false;

                    dt.Rows.Add(dr);
                    Reset();
                    RefreshTables();
                }
                else if (comboBox1.SelectedItem.ToString() == "Expenses")
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = DateOnly.FromDateTime(dateTimePicker1.Value.Date);
                    dr[1] = -numericUpDown1.Value;
                    dr[2] = comboBox1.SelectedItem;
                    dr[3] = DescriptionBox.Text;
                    dr[4] = false;
                    dr[5] = false;


                    dt.Rows.Add(dr);
                    Reset();
                    RefreshTables();
                }

            }

        }
        private void CancelBTN_Click_1(object sender, EventArgs e)
        {
            Reset();
        }

        private void SaveToolStripButton_Click(object sender, EventArgs e)
        {
            RefreshTables();
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "XML-File | *.xml"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                dt.WriteXml(saveFileDialog.FileName, true);
            }
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new()
            {
                Filter = "XML-File | *.xml"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                dt.Rows.Clear();
                try
                {
                    dt.ReadXml(openFileDialog.FileName);
                }
                catch
                {
                    MessageBox.Show("Oops! Your data may not have been entered correctly.");

                }
                RefreshTables();

            }
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            NewDoc();
        }

        private void PrintToolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }

        const int PageHeight = 72 * 11;
        const int TopMargin = 72;
        const int BottomMargin = 72;
        const int LeftMargin = 72;

        StreamWriter s;
        int page;
        int y;
        int FontSize;

        void StartPage()
        {
            page++;
            y = PageHeight - TopMargin;

            OutputText(LeftMargin, PageHeight - 36, "BookWiz Report", 18);
            OutputText(LeftMargin, 36, $"Page {page}", 12);
            OutputText(LeftMargin + 144, 36, DateTime.Today.ToString(), 12);

        }

        void EndPage()
        {
            s.WriteLine("showpage");
        }

        void NewPage()
        {
            EndPage();
            StartPage();
        }

        void StartDoc(StreamWriter _s)
        {
            s = _s;
            page = 0;
            FontSize = -1;
            s.WriteLine("%!PS");
            s.WriteLine(
@"%Rounded Rect
/RR {
11 dict begin
  /dx 1000 def
  /dy 1000 def
  /r 100 def
  /lw 50 def

  /x1 lw 2 div def
  /x2 dx x1 sub def
  /y1 x1 def
  /y2 dy y1 sub def

  lw setlinewidth
  dx 2 div y1 moveto
  x1 x1 y1 y2 r arct
  x1 x2 y2 y2 r arct
  x2 x2 y2 y1 r arct
  x2 x1 y1 y1 r arct
  closepath stroke
end
}bind def

/Box <</FormType 1 /BBox [0 0 1000 1000] /Matrix 0.001 0.001 matrix scale /PaintProc {pop RR} bind >> def

%X
/X {
5 dict begin
  /dx 1000 def
  /dy 1000 def
  /lw 100 def
  /m 200 def
  
  1 setlinecap
  lw setlinewidth
  m m moveto dx m sub dy m sub lineto
  m dy m sub moveto dx m sub m lineto
  stroke
end
}bind def

/XBox <</FormType 1 /BBox [0 0 1000 1000] /Matrix 0.001 0.001 matrix scale /PaintProc {pop RR X} bind >> def
");
            StartPage();
        }

        void EndDoc()
        {
            EndPage();
            s.Close();
        }

        void OutputText(int x, int y, string text, int size)
        {

            if (FontSize != size)
            {
                s.WriteLine($"/Times-Roman {size} selectfont");
                FontSize = size;
            }

            s.WriteLine($"{x} {y - size * 3 / 4} moveto");
            s.WriteLine($"({text}) show");
        }

        void OutputText(int size, params (int x, string text)[] texts)
        {
            if ((y - size) < BottomMargin)
                NewPage();
            int x = LeftMargin;
            foreach (var t in texts)
            {
                OutputText(x, y, t.text, size);
                x += t.x;
            }
            y -= size;
        }

        void OutputText(string text, int size = 12)
        {
            OutputText(size, (0, text));
        }
        void OutputXBox(int x, int y, int size = 12)
        {
            s.WriteLine($"    gsave\r\n      {size} {size} scale\r\n      {(x + LeftMargin) / 12} {(y) / 12} translate\r\n\t  0.9 0.9 scale\r\n      XBox execform\r\n    grestore");
        }
        void OutputBox(int x, int y, int size = 12)
        {
            s.WriteLine($"    gsave\r\n      {size} {size} scale\r\n      {(x + LeftMargin) / 12} {(y) / 12} translate\r\n\t  0.9 0.9 scale\r\n      Box execform\r\n    grestore");
        }
        private void ExportToolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog2 = new()
            {
                Title = "Export as",
                Filter = "PDF-File | *.pdf"
            };
            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                String saveFile = "-sDEVICE=pdfwrite -r600 -o \"" + saveFileDialog2.FileName + "\" -";
                ProcessStartInfo psi = new("gswin64c.exe")
                {
                    Arguments = saveFile,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardInput = true
                };

                using Process p = Process.Start(psi);
                StartDoc(p.StandardInput);
                OutputText(12, (60, "Date"), (76 * 5 / 6, "Amount"), (50, "Type"), (152, "Description"), (75, "Reconciled"), (50, "Pending"));

                foreach (DataRow r in dt.Rows)
                {

                    if (r["Pending"].ToString() == "False" && r["Reconciled"].ToString() == "False")
                    {
                        OutputText(12,
                        (60, DateOnly.FromDateTime((DateTime)r["Date"]).ToString()),
                        (76 * 5 / 6, Convert.ToDecimal(r["Amount"]).ToString("C", culture)),
                        (50, (string)r["Type"]),
                        (152, (string)r["Description"]));
                        OutputBox(337, y, 12);
                        OutputBox(412, y, 12);

                    }
                    if (r["Pending"].ToString() == "False" && r["Reconciled"].ToString() == "True")
                    {
                        OutputText(12,
                        (60, DateOnly.FromDateTime((DateTime)r["Date"]).ToString()),
                        (76 * 5 / 6, Convert.ToDecimal(r["Amount"]).ToString("C", culture)),
                        (50, (string)r["Type"]),
                        (152, (string)r["Description"]));
                        OutputXBox(337, y, 12);
                        OutputBox(412, y, 12);
                    }

                    if (r["Pending"].ToString() == "True" && r["Reconciled"].ToString() == "False")
                    {
                        OutputText(12,
                        (60, DateOnly.FromDateTime((DateTime)r["Date"]).ToString()),
                        (76 * 5 / 6, Convert.ToDecimal(r["Amount"]).ToString("C", culture)),
                        (50, (string)r["Type"]),
                        (152, (string)r["Description"]));
                        OutputBox(337, y, 12);
                        OutputXBox(412, y, 12);
                    }
                }
                OutputText($"Total Income: {IncomeTotalLabel.Text}", 36);
                OutputText($"Total Expenses: {ExpenseTotalLabel.Text}", 36);
                if (ReconciledTotal == DBNull.Value)
                {
                    OutputText($"Total Reconciled: $0.00", 36);
                }
                else
                {
                    OutputText($"Total Reconciled: {Convert.ToDecimal(Balance.ReconciledTotal).ToString("C", culture)}", 36);
                }
                if (NonreconciledTotal == DBNull.Value)
                {
                    OutputText($"Total Nonreconciled: $0.00", 36);
                }
                else
                {
                    OutputText($"Total Nonreconciled: {Convert.ToDecimal(Balance.NonreconciledTotal).ToString("C", culture)}", 36);
                }
                OutputText($"Grand Total: {GrandTotalLabel.Text}", 36);

                EndDoc();
                p.WaitForExit(5000);
                if (!p.HasExited)
                {
                    MessageBox.Show("Oops!  Didn't work.");
                    p.Kill();
                }
                else if (p.ExitCode != 0)
                {

                    MessageBox.Show("Oops! Something went wrong! Make sure destination isn't open.");

                }
                else
                {
                    ProcessStartInfo psi2 = new(saveFileDialog2.FileName)
                    {
                        UseShellExecute = true
                    };

                    using Process p2 = Process.Start(psi2);
                }
            }
        }
        private void HelpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new();
            aboutBox1.ShowDialog();
        }


        private void DataGridView1_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            RefreshTables();
        }

        new private void HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            AboutBox1 aboutBox1 = new();
            aboutBox1.ShowDialog();
        }

        private void BalanceBTN_Click(object sender, EventArgs e)
        {
            Balance balance = new(dt);
            balance.ShowDialog();
        }
        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            string[] a = (string[])e.Data.GetData("FileName");
            var b = a[0];
            dt.Rows.Clear();
            try
            {
                dt.ReadXml(b);
            }
            catch
            {
                MessageBox.Show("Oops! Your data may not have been entered correctly.");

            }
            RefreshTables();


        }

        private void dataGridView1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetType() == typeof(DataObject))
            {
                string[] a = (string[])e.Data.GetData("FileName");
                var b = a[0];
                bool c = b.ToLower().EndsWith(".xml");
                if (c)
                {
                    e.Effect = DragDropEffects.All;
                }

            }
            else
            {
                e.Effect = DragDropEffects.All;
            }
        }
    }
}
