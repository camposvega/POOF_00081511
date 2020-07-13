using System.Windows.Forms;

namespace POOF_00081511
{
    public class Manage
    {
        private static Manage instance = null;
        private Form1 mainForm;
        private UserControl current = null;

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
        
        
    }
}