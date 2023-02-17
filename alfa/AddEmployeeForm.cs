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
    public partial class AddEmployeeForm : Form
    {
        bool isNew = true;
        Employee employee;
        public AddEmployeeForm()
        {
            InitializeComponent();
        }
        public AddEmployeeForm(Employee emp)
        {
            InitializeComponent();
            employee = emp;
            textBox1.Text = employee.FullName;
            dateTimePicker1.Value = employee.Birth_Date;
            comboBox1.SelectedValue = employee.ID_Department;
            comboBox2.SelectedValue = employee.ID_Position;
            checkBox1.Checked = employee.WorkType;
            textBox2.Text = employee.Residential_Address;
            isNew = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isNew)
            {
                Employee emp = new Employee()
                {
                    FullName = textBox1.Text,
                    Birth_Date = dateTimePicker1.Value,
                    ID_Department = (int)comboBox1.SelectedValue,
                    ID_Position = (int)comboBox2.SelectedValue,
                    WorkType = checkBox1.Checked,
                    Residential_Address = textBox2.Text
                };
                
                General.conn.Employee.Add(emp);
                General.conn.SaveChanges();
            }
            else
            {
                employee.FullName = textBox1.Text;
                employee.Birth_Date = dateTimePicker1.Value;
                employee.ID_Department = (int)comboBox1.SelectedValue;
                employee.ID_Position = (int)comboBox2.SelectedValue;
                employee.WorkType = checkBox1.Checked;
                employee.Residential_Address = textBox2.Text;
                General.conn.SaveChanges();
            }
        }

        private void AddEmployeeForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "alfa_testDataSet.Positions". При необходимости она может быть перемещена или удалена.
            this.positionsTableAdapter.Fill(this.alfa_testDataSet.Positions);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "alfa_testDataSet.Departments". При необходимости она может быть перемещена или удалена.
            this.departmentsTableAdapter.Fill(this.alfa_testDataSet.Departments);

        }
    }
}
