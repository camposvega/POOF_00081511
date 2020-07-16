using System;
using System.Windows.Forms;

namespace POOF_00081511.Views
{
    public partial class AddEntrada : UserControl
    {
        public AddEntrada()
        {
            InitializeComponent();
            agregarTemperatura();
            agregarEntrada();
            Manage.Instance.todosUsuarios(listBox1);
        }

        private void agregarTemperatura()
        {
            for (int i = 20; i < 45; i++)
            {
                listBox3.Items.Add(i);
            }
        }

        private void agregarEntrada()
        {
            listBox2.Items.Add("Entrada");
            listBox2.Items.Add("Salida");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Remove(this);
            Manage.Instance.Current = new DataView();
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Add(Manage.Instance.Current,0,0);
            Manage.Instance.MainForm.TableLayoutPanel1.SetColumnSpan(Manage.Instance.Current,1); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Text.Equals("") || listBox2.Text.Equals("") || listBox3.Text.Equals(""))
            {
                MessageBox.Show("DEBE LLENAR TODOS LOS CAMPOS");
                return;
            }
            if (Manage.Instance.guardarRegistro(listBox1.Text, listBox2.Text, listBox3.Text))
            {
                Manage.Instance.MainForm.TableLayoutPanel1.Controls.Remove(this);
                Manage.Instance.Current = new DataView();
                Manage.Instance.MainForm.TableLayoutPanel1.Controls.Add(Manage.Instance.Current,0,0);
                Manage.Instance.MainForm.TableLayoutPanel1.SetColumnSpan(Manage.Instance.Current,1); 
                MessageBox.Show("Ingreso correcto");
            }else MessageBox.Show("error en el ingreso de datos");
        }
    }
}