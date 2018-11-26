using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLTester
{
    public partial class frm_Tester : Form
    {
        OleDbConnection conn;
        

        public frm_Tester()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_Tester_Load(object sender, EventArgs e)
        {
            var connstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Alia\Desktop\Books.accdb;
                Persist Security Info=False;";
            conn = new OleDbConnection(connstring);
            conn.Open();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            OleDbCommand command = null;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable Table = new DataTable();

            try
            {
                command = new OleDbCommand(txtCommand.Text, conn);
                adapter.SelectCommand = command;
                adapter.Fill(Table);

                grdRecords.DataSource = Table;
                lblCount.Text = Table.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in SQL Command", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            command.Dispose();
            adapter.Dispose();
            Table.Dispose();
            
        }

        private void frm_Tester_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
            conn.Dispose();
        }
    }
}
