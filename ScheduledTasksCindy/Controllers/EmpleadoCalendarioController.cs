using ScheduledTasksCindy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScheduledTasksCindy.Controllers
{
    public class EmpleadoCalendarioController : Controller
    {
        // Crear una lista de EmpleadoCalendarioViewModel y guardarla en memoria
        public static List<EmpleadoCalendarioViewModel> _list = new List<EmpleadoCalendarioViewModel>();
        public static string _colorPlanta1 = "#007496";
        public static string _colorPlanta2 = "#00966f";

        public EmpleadoCalendarioController()
        {
            //_list.Add(new EmpleadoCalendarioViewModel
            //{
            //    Id = 1,
            //    Title = "Empleado 1",
            //    Start = new DateTime(2021, 1, 1),
            //    Planta = "Planta 1",
            //    Turno = "Turno 1",
            //    Color = _colorPlanta1
            //});
           
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerResumenCalendario(DateTime fechaInicial, DateTime fechaFinal)
        {
            // Si solo una de las fechas viene nula se envia un mensaje de error
            if (fechaInicial == DateTime.MinValue && fechaFinal != DateTime.MinValue)
            {
                return Json(new { Status = false, Message = "La fecha inicial es requerida" });
            }

            if (fechaInicial != DateTime.MinValue && fechaFinal == DateTime.MinValue)
            {
                return Json(new { Status = false, Message = "La fecha final es requerida" });
            }

            //Si las dos fechas son nulas se asignan las fechas del mes actual
            if (fechaInicial == DateTime.MinValue && fechaFinal == DateTime.MinValue)
            {
                fechaInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                fechaFinal = fechaInicial.AddMonths(1).AddDays(-1);
            }

            var fechaFinalFiltro = fechaFinal.AddDays(1);
            var result = _list.Where(x => x.Start >= fechaInicial && x.Start <= fechaFinalFiltro)
                .OrderBy(x => x.Turno)
                .ThenBy(x => x.Planta)
                .ThenBy(x => x.Start)
                .ToList();

            var json = Json(result, JsonRequestBehavior.AllowGet);
            json.MaxJsonLength = int.MaxValue;
            return json;
        }

        [HttpPost]
        public JsonResult CrearNuevo (CrearTurnoViewModel model)
        {
            
            _list.Add(new EmpleadoCalendarioViewModel
            {
                Id = _list.Count + 1,
                Title = model.NombreEmpleado,
                Start = model.FechaTurno,
                Planta = model.PlantaEmpleado,
                Turno = model.TurnoEmpleado,
                End = model.FechaTurno.AddHours(23).AddSeconds(59).AddMilliseconds(59),
                Color = (model.PlantaEmpleado == "Planta 1" ? _colorPlanta1 : _colorPlanta2)
            });

            return Json(new { Status = true, Message = "Creado correctamente" });
        }

        [HttpPost]
        public JsonResult Actualizar (CrearTurnoViewModel model)
        {
            var item = _list.FirstOrDefault(x => x.Id == model.IdTurno);
            if (item == null)
            {
                return Json(new { Status = false, Message = "No se encontro el registro" });
            }

            item.Title = model.NombreEmpleado;
            item.Start = model.FechaTurno;
            item.End = model.FechaTurno.AddHours(23).AddSeconds(59).AddMilliseconds(59);
            item.Planta = model.PlantaEmpleado;
            item.Turno = model.TurnoEmpleado;
            item.Color = (model.PlantaEmpleado == "Planta 1" ? _colorPlanta1 : _colorPlanta2);

            return Json(new { Status = true, Message = "Actualizado correctamente" });
            
        }
    }
}