using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Q2_P2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] listBoxValues = { "ProductID", "ProductName","Company Name","Category Name","QuantityPerUnit","UnitPrice","UnitsInStock","UnitsInOrder","ReOrderLevel","Discontinued" };
            
           for(int i = 0; i < listBoxValues.Length; i++)
            {
                checkedListBox1.Items.Add(listBoxValues[i], true);
            }
            loadData();
        }
        
        private void loadData()
        {
            string query = "SELECT p.ProductID,p.ProductName,s.CompanyName,c.CategoryName,p.QuantityPerUnit, p.UnitPrice,p.UnitsInStock,p.UnitsOnOrder, p.ReorderLevel,p.Discontinued FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID JOIN Suppliers s ON p.SupplierID = s.SupplierID";
            SqlCommand command = new SqlCommand(query, DAO.getConnection());
            DataTable table = DAO.getTableFromSql(command);
            dataGridView1.DataSource = table;
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Remove(dataGridView1.Columns["Discontinued"]);

            DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
            textBoxColumn.ValueType = typeof(bool);
            textBoxColumn.HeaderText = "Discontinued";
            textBoxColumn.DataPropertyName = "Discontinued";
            dataGridView1.Columns.Add(textBoxColumn);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for(int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i,true);
                }
            }
            else
            {
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            for(int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Visible = false;
            }
            for(int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    dataGridView1.Columns[i].Visible = true;
                }
            }
        }
    }
}
