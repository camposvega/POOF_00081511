using System;
using System.Windows.Forms;

namespace POOF_00081511.Views
{
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Remove(this);
            Manage.Instance.Current = new DataView();
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Add(Manage.Instance.Current,0,0);
            Manage.Instance.MainForm.TableLayoutPanel1.SetColumnSpan(Manage.Instance.Current,1); 
        }
        
    }
}