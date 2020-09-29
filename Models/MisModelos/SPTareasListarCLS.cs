using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APITareas.Models.MisModelos
{
    public class SPTareasListarCLS
    {
		[Key]
		public int TAREAS_ID { get; set; }
		public string TAREAS_DESCRIPCION { get; set; }
		public string TAREAS_ESTADO { get; set; }
		public string TAREAS_PRIORIDAD { get; set; }
		public DateTime TAREAS_FECHA_INICIO { get; set; }
		public DateTime TAREA_FECHA_FIN { get; set; }
		public string TAREAS_NOTAS { get; set; }
		public int COLABORADOR_ID { get; set; }
		public string NOMBRE { get; set; }

	}
}
