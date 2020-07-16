using System;
using System.Windows.Forms;

namespace POOF_00081511.Views
{
    public partial class DashBoard : UserControl
    {
        public DashBoard()
        {
            InitializeComponent();
            
            Manage.Instance.personasMayores(DataGridView4);
            Manage.Instance.topDepartamentos(DataGridView3);
            Manage.Instance.topTemperaturas(DataGridView2);
            Manage.Instance.usuariosAdentro(DataGridView1);
        }

        public DataGridView DataGridView1
        {
            get => dataGridView1;
            set => dataGridView1 = value;
        }

        public DataGridView DataGridView2
        {
            get => dataGridView2;
            set => dataGridView2 = value;
        }

        public DataGridView DataGridView3
        {
            get => dataGridView3;
            set => dataGridView3 = value;
        }

        public DataGridView DataGridView4
        {
            get => dataGridView4;
            set => dataGridView4 = value;
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