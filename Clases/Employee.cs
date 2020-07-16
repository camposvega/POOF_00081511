using POOF_00081511.Interfaces;

namespace POOF_00081511.Clases
{
    public class Employee : IUserApp
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int id_user { get; set; }
        public int Id_rol { get; set; }

        public Employee(string name, int idUser)
        {
            Name = name;
            id_user = idUser;
            this.UserName = name;
            this.Id_rol = 1;
        }

        public string verListado()
        {
            return $"select a.nombre, a.apellido, case when b.entrada = '1' then 'Entrada' else 'Salida' end as entrada, " +
            $"b.fecha, b.temperatura from usuario a inner join registro b" +
            $" on a.id_usuario = b.id_usuario where a.id_usuario = '{id_user}'";
        }
    }
}