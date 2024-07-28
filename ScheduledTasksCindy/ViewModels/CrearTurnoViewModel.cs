using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduledTasksCindy.ViewModels
{
    public class CrearTurnoViewModel
    {
        public int IdTurno { get; set; }
        public string NombreEmpleado { get; set; }
        public string PlantaEmpleado { get; set; }
        public string TurnoEmpleado { get; set; }
        public DateTime FechaTurno { get; set; }
    }
}