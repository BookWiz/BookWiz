using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BookWiz.BookWiz;
namespace BookWiz
{

    public partial class Balance : Form
    {
        internal static object ReconciledTotal;
        internal static object NonreconciledTotal;
        internal static DataView ReconciledView = new DataView(BookWiz.dt);
        internal static DataView NonreconciledView = new DataView(BookWiz.dt);
        object Total = 0;
        DataTable dt1;
        readonly CultureInfo culture = new("en-us");

        private void RefreshReconciliation()
        {
            ReconciledView.RowFilter = "Reconciled = true";
            NonreconciledView.RowFilter = "Reconciled = false";
            dataGridView1.DataSource = dt1;
            dataGridView2.DataSource = ReconciledView;
            dataGridView3.DataSource = NonreconciledView;
            dataGridView2.Columns[4].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView3.Columns[4].Visible = false;
            Total = dt1.Compute("sum(Amount)", string.Empty);
            ReconciledTotal = ReconciledView.ToTable().Compute("sum(Amount)", string.Empty);
            NonreconciledTotal = NonreconciledView.ToTable().Compute("sum(Amount)", string.Empty);
            TotalAmountLabel.Text = Total.ToString();

            if (Total == DBNull.Value)
            {
                TotalAmountLabel.Text = "$0.00";
            }
            else
            {
                TotalAmountLabel.Text = Convert.ToDecimal(Total).ToString("C", culture);
            }
            if (ReconciledTotal == DBNull.Value)
            {
                ReconciledAmountLabel.Text = "$0.00";
            }
            else
            {
                ReconciledAmountLabel.Text = Convert.ToDecimal(ReconciledTotal).ToString("C", culture);
            }
            if (NonreconciledTotal == DBNull.Value)
            {
                NonreconciledAmountLabel.Text = "$0.00";
            }
            else
            {
                NonreconciledAmountLabel.Text = Convert.ToDecimal(NonreconciledTotal).ToString("C", culture);
            }

        }
        public Balance(DataTable dt)
        {
            dt1 = dt;
            InitializeComponent();
            ReconciledTotal = 0;
            NonreconciledTotal = 0;
            RefreshReconciliation();


        }

        private void ReconciliationBTN_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection Selected;
            int ReconciledIndex;
            int PendingIndex;
            Selected = dataGridView1.SelectedRows;
            ReconciledIndex = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Reconciled"]);
            PendingIndex = dataGridView1.Columns.IndexOf(dataGridView1.Columns["Pending"]);

            if (tabControl1.SelectedTab == All)
            {
                foreach (DataGridViewRow row in Selected)
                {
                    if ((bool)row.Cells[ReconciledIndex].Value == false && (bool)row.Cells[PendingIndex].Value == false)
                    {
                        row.Cells[PendingIndex].Value = true;
                        row.Cells[ReconciledIndex].Value = false;
                    }
                    else if ((bool)row.Cells[ReconciledIndex].Value == false && (bool)row.Cells[PendingIndex].Value == true)
                    {
                        row.Cells[PendingIndex].Value = false;
                        row.Cells[ReconciledIndex].Value = true;
                    }
                    else if ((bool)row.Cells[ReconciledIndex].Value == true && (bool)row.Cells[PendingIndex].Value == false)
                    {
                        row.Cells[PendingIndex].Value = false;
                        row.Cells[ReconciledIndex].Value = false;
                    }
                }
            }
            else if (tabControl1.SelectedTab == Reconciled)
            {
                foreach (DataGridViewRow row in Selected)
                {
                    if ((bool)row.Cells[ReconciledIndex].Value == false && (bool)row.Cells[PendingIndex].Value == false)
                    {
                        row.Cells[PendingIndex].Value = true;
                        row.Cells[ReconciledIndex].Value = false;
                    }
                    else if ((bool)row.Cells[ReconciledIndex].Value == false && (bool)row.Cells[PendingIndex].Value == true)
                    {
                        row.Cells[PendingIndex].Value = false;
                        row.Cells[ReconciledIndex].Value = true;
                    }
                    else if ((bool)row.Cells[ReconciledIndex].Value == true && (bool)row.Cells[PendingIndex].Value == false)
                    {
                        row.Cells[PendingIndex].Value = false;
                        row.Cells[ReconciledIndex].Value = false;
                    }
                }
            }
            else if (tabControl1.SelectedTab == Nonreconciled)
            {
                foreach (DataGridViewRow row in Selected)
                {
                    if ((bool)row.Cells[ReconciledIndex].Value == false && (bool)row.Cells[PendingIndex].Value == false)
                    {
                        row.Cells[PendingIndex].Value = true;
                        row.Cells[ReconciledIndex].Value = false;
                    }
                    else if ((bool)row.Cells[ReconciledIndex].Value == false && (bool)row.Cells[PendingIndex].Value == true)
                    {
                        row.Cells[PendingIndex].Value = false;
                        row.Cells[ReconciledIndex].Value = true;
                    }
                    else if ((bool)row.Cells[ReconciledIndex].Value == true && (bool)row.Cells[PendingIndex].Value == false)
                    {
                        row.Cells[PendingIndex].Value = false;
                        row.Cells[ReconciledIndex].Value = false;
                    }
                }
            }

            dt1.AcceptChanges();

            RefreshReconciliation();
        }
    }
}
