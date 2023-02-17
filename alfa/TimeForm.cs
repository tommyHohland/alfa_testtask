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
    public partial class TimeForm : Form
    {
        void ShowCalendar(int mounth)
        {
            dataGridView2.Rows.Clear();
            List<DateTime> date_list = new List<DateTime>();
            List<string> name_list = new List<string>();
            int id_dept = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            var list = General.conn.GetTabel(id_dept).OrderBy(x => x.Date).Where(x => x.Date.Month == mounth).OrderBy(x => x.FullName).ToList();


            for (int i = 0; i < list.Count; i++)
            {
                date_list.Add(list[i].Date);
                name_list.Add(list[i].FullName);
            }
            date_list = date_list.Distinct().ToList();
            dataGridView2.ColumnCount = date_list.Count + 1;
            for (int i = 0; i < dataGridView2.ColumnCount - 1; i++)
            {
                dataGridView2.Columns[i + 1].HeaderText = date_list[i].ToShortDateString();
            }
            List<string> markredNames = new List<string>();
            foreach (var item in list)
            {
                if (markredNames.Any(i => i == item.FullName))
                    continue;
                markredNames.Add(item.FullName);
                var l = list.Where(i => i.FullName == item.FullName).ToList();
                List<string> r = new List<string>();
                r.Add(item.FullName);
                foreach (var d in date_list)
                {
                    var ll = l.Where(i => i.Date == d).FirstOrDefault();
                    r.Add(ll != null ? ll.Mark : "-");
                }
                dataGridView2.Rows.Add(r.ToArray());
            }
        }
        public TimeForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = General.conn.SelectDepartments();
            Controls.OfType<Button>().ToList().ForEach(x => x.Click += new EventHandler(ShowMounthCalendar));
        }

        private void ShowMounthCalendar(object sender, EventArgs e)
        {
            string s = ((Button)sender).Name;
            ShowCalendar(int.Parse(s[s.Length-1].ToString()));
        }

       
    }
}
