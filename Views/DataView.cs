using System;
using System.Windows.Forms;

namespace POOF_00081511.Views
{
    public partial class DataView : UserControl
    {
        public DataView()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = Manage.Instance.llenarTabla();
            button1.Text = Manage.Instance.LabelNombre;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Manage.Instance.User.Id_rol == 2 || Manage.Instance.User.Id_rol == 3)
            {

            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage.delegateView();
        }

        public Button Button1
        {
            get => button1;
            set => button1 = value;
        }
    }
}