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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (General.Login(txLogin.Text, txPass.Text))
            {
                case 1:
                    TimeForm timeform1 = new TimeForm();
                    timeform1.ShowDialog();
                    break;
                case 2:
                    EditDepartment timeform = new EditDepartment();
                    timeform.ShowDialog();
                    break;
                case 3:
                    ShowEmployeeForm empform = new ShowEmployeeForm();
                    empform.ShowDialog();
                    break;
                default:
                    MessageBox.Show("Ошибка");
                    break;
            }
        }
    }
}
