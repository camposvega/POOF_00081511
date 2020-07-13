using POOF_00081511.Interfaces;

namespace POOF_00081511.Clases
{
    public class Vigilant : IUserApp
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string verListado()
        {
            throw new System.NotImplementedException();
        }
    }
}