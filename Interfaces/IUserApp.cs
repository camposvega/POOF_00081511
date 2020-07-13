using System;

namespace POOF_00081511.Interfaces
{
    public interface IUserApp
    {
        
        String Name { get; set; }
        String UserName { get; set; }
        String Password { get; set; }
        int id_user { get; set; }
        int Id_rol { get; set; }

        String verListado();
    }
}