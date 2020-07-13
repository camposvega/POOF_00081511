using System.Windows.Forms;

namespace POOF_00081511.Views
{
    public partial class DataView : UserControl
    {
        public DataView()
        {
            InitializeComponent();
            this.dataGridView1.DataSource = Manage.Instance.llenarTabla();
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
    }
}