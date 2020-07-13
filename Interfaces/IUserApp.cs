using System;

namespace POOF_00081511.Interfaces
{
    public interface IUserApp
    {
        
        String Name { get; set; }
        String UserName { get; set; }
        String Password { get; set; }

        String verListado();
    }
}