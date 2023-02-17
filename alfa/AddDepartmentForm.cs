using System;
using System.Windows.Forms;
using TEST;

namespace alfa
{
    public partial class AddDepartmentForm : Form
    {
        public AddDepartmentForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                General.conn.Departments.Add(new Departments() { Department = textBox1.Text });
                General.conn.SaveChanges();
            }
            else MessageBox.Show("Ошибка");
        }
    }
}
