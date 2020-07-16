using System;
using System.Data;
using System.Windows.Forms;
using POOF_00081511.Clases;
using POOF_00081511.Interfaces;
using POOF_00081511.Views;

namespace POOF_00081511
{
    public class Manage
    {
        private static Manage instance = null;
        private Form1 mainForm;
        private UserControl current = null;
        private IUserApp user;
        private String label_nombre;
        public delegate void DelegateView();

        public static DelegateView delegateView;

        public IUserApp User
        {
            get => user;
            set => user = value;
        }

        public Form1 MainForm
        {
            get => mainForm;
            set => mainForm = value;
        }

        public UserControl Current
        {
            get => current;
            set => current = value;
        }

        public string LabelNombre
        {
            get => label_nombre;
            set => label_nombre = value;
        }

        private Manage()
        {
        }
        
        public static Manage Instance
        {
            get
            {
                if (instance==null)
                {
                    instance = new Manage();
                }
                return instance;
            }
        }

        public DataTable llenarTabla()
        {
            //MessageBox.Show(user.verListado());
            return ConnectionBDD.executeQuery(user.verListado());
        }

        public bool loginUser(String no, String apellido)
        {
            try
            {
                var dt = ConnectionBDD.executeQuery($"select * from usuario WHERE NOMBRE " +
                                                    $"LIKE '{no}%' AND APELLIDO = '{apellido}'");
                
                //MessageBox.Show(dt.Rows[0][0].ToString());
                User = crearUsuario(dt.Rows[0][2].ToString(),
                    (int) Int64.Parse(dt.Rows[0][0].ToString()), 
                    (int) Int64.Parse(dt.Rows[0][1].ToString()));
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" Nelson Mandela");
                return false;
            }
        }

        private IUserApp crearUsuario(String nombre, int id, int id_rol)
        {
            switch (id_rol)
            {
                case 1:
                    label_nombre = "salir";
                    delegateView = cerrarApp;
                    return new Employee(nombre, id);
                    break;
                case 2:
                    delegateView = agregarRegistro;
                    label_nombre = "Agregar";
                    return new Vigilant(nombre, id);
                    break;
                case 3:
                    label_nombre = "Administrar";
                    delegateView = dashView;
                    return new Admin(nombre, id);
                    break;
                default:
                    return new Employee("Rigo", 0);
            }
        }

        private void cerrarApp()
        {
            System.Windows.Forms.Application.Exit();
        }
        
        private void agregarRegistro()
        {
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Remove(Current);
            Manage.Instance.Current = new AddEntrada();
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Add(Manage.Instance.Current,0,0);
            Manage.Instance.MainForm.TableLayoutPanel1.SetColumnSpan(Manage.Instance.Current,1); 
        }
        
        private void dashView()
        {
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Remove(Current);
            Manage.Instance.Current = new DashBoard();
            Manage.Instance.MainForm.TableLayoutPanel1.Controls.Add(Manage.Instance.Current,0,0);
            Manage.Instance.MainForm.TableLayoutPanel1.SetColumnSpan(Manage.Instance.Current,1); 
        }
        
        public void usuariosAdentro(DataGridView dv)
        {
            try
            {
                var dt = ConnectionBDD.executeQuery("select a.fecha as entrada, b.nombre || ' ' ||b.apellido "+
                " as nombre from ("+
                                                     " select distinct on (id_usuario) id_usuario, fecha, entrada"+
                                                     " from registro"+
                                                     " order by id_usuario, fecha desc) a inner join usuario b "+
                                                     " on a.id_usuario = b.id_usuario where entrada = 1");
                
                //MessageBox.Show(dt.Rows[0][0].ToString());
                dv.DataSource = dt;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" err1");
            }
        }
        
        public void topDepartamentos(DataGridView dv)
        {
            try
            {
                var dt = ConnectionBDD.executeQuery("select count(b.id_usuario), c.nombre  from ("+
                                                    " select distinct on (id_usuario) id_usuario, fecha, entrada"+
                                                    " from registro"+
                                                    " order by id_usuario, fecha desc) a inner join usuario b "+
                                                    " on a.id_usuario = b.id_usuario inner join departamento c on"+
                                                    " b.id_departamento = c.id_departamento"+
                                                    " where entrada = 1 group by c.nombre");
                
                //MessageBox.Show(dt.Rows[0][0].ToString());
                dv.DataSource = dt;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" err2");
            }
        }
        
        public void topTemperaturas(DataGridView dv)
        {
            try
            {
                var dt = ConnectionBDD.executeQuery("select distinct on (a.id_usuario) a.id_usuario,"+ 
                                                    " b.nombre || ' ' ||b.apellido as nombre, temperatura"+
                                                    " from registro a inner join usuario b"+ 
                                                    " on a.id_usuario = b.id_usuario"+
                                                    " order by id_usuario, temperatura desc");
                
                //MessageBox.Show(dt.Rows[0][0].ToString());
                dv.DataSource = dt;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" err3");
            }
        }
        
        public void personasMayores(DataGridView dv)
        {
            try
            {
                var dt = ConnectionBDD.executeQuery("select nombre || ' ' || apellido as nombre, "+ 
                                                    "DATE_PART('year', AGE(current_date, fecha_nacimiento)) AS years "+
                                                    "from usuario where DATE_PART('year', AGE(current_date, fecha_nacimiento)) > 59");
                
                //MessageBox.Show(dt.Rows[0][0].ToString());
                dv.DataSource = dt;
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" err4");
            }
        }

        public void todosUsuarios(ListBox lb)
        {
            try
            {
                DataTable dt = ConnectionBDD.executeQuery("select nombre || ' ' || apellido as nombre from usuario");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lb.Items.Add(dt.Rows[i][0].ToString());   
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" err5");
            }
        }

        public bool guardarRegistro(String nombre, String entrada, String temperatura)
        {
            try
            {
                if (entrada.Equals("Entrada")) entrada = "1";
                else entrada = "0";
                ConnectionBDD.executeNonQuery($"INSERT INTO REGISTRO (ID_USUARIO, FECHA, ENTRADA, TEMPERATURA)" +
                                              $" SELECT ID_USUARIO, CURRENT_DATE,'{entrada}', " +
                                              $"'{temperatura}' from usuario " +
                                              $"where nombre || ' ' || apellido ='{nombre}'");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message+" err6");
                return false;
            }
        }
        
    }
}