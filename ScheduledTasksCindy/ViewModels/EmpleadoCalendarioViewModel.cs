using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScheduledTasksCindy.ViewModels
{
    public class EmpleadoCalendarioViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Planta { get; set; }
        public string Turno { get; set; }
        public string Color { get; set; }

    }
}