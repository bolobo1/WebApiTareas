using System;
using System.Collections.Generic;

namespace APITareas.Models.Database
{
    public partial class Colaborador
    {
        public Colaborador()
        {
            Tareas = new HashSet<Tareas>();
        }

        public int ColaboradorId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Tareas> Tareas { get; set; }
    }
}
