using System;
using System.Collections.Generic;

namespace APITareas.Models.Database
{
    public partial class Tareas
    {
        public int TareasId { get; set; }
        public string TareasDescripcion { get; set; }
        public string TareasEstado { get; set; }
        public string TareasPrioridad { get; set; }
        public string TareasFechaInicio { get; set; }
        public string TareaFechaFin { get; set; }
        public string TareasNotas { get; set; }
        public int? TareasColaborador { get; set; }
        public virtual Colaborador TareasColaboradorNavigation { get; set; }

    }
}
