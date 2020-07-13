using System.Data;
using System.Windows.Forms;
using POOF_00081511.Interfaces;

namespace POOF_00081511
{
    public class Manage
    {
        private static Manage instance = null;
        private Form1 mainForm;
        private UserControl current = null;
        private IUserApp user;

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
            return ConnectionBDD.executeQuery(user.verListado());
        }
        
        
    }
}