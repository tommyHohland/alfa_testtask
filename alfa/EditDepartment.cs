using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TEST;

namespace alfa
{
    public partial class EditDepartment : Form
    {
        public EditDepartment()
        {
            InitializeComponent();
            dataGridView1.DataSource = General.conn.Departments.ToList();
            dataGridView1.Columns[2].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            General.conn.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddDepartmentForm form = new AddDepartmentForm();
            form.ShowDialog();
        }

        private void EditDepartment_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = General.conn.Departments.ToList();
        }
    }
}
