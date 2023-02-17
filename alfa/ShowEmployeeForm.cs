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
    public partial class ShowEmployeeForm : Form
    {
        public ShowEmployeeForm()
        {
            InitializeComponent();
            Output.DataSource = General.conn.SelectAllEmployees();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Output.DataSource = General.conn.SelectAllEmployees().Where(c => c.ФИО.Contains(txSearch.Text)).ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Output.SelectedCells[0].Value.ToString());
            var emp = General.conn.Employee.Where(c => c.ID == id).First();
            AddEmployeeForm form = new AddEmployeeForm(emp);
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Output.SelectedCells[0].Value.ToString());
            var emp = General.conn.Employee.Where(c => c.ID == id).First();
            General.conn.Employee.Remove(emp);
            General.conn.SaveChanges();
            Output.DataSource = General.conn.SelectAllEmployees();
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            AddEmployeeForm form = new AddEmployeeForm();
            form.ShowDialog();
        }

        private void ShowEmployeeForm_Load(object sender, EventArgs e)
        {
            Output.DataSource = General.conn.SelectAllEmployees();
        }
    }
}
