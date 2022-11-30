using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: /Alumno/
        [HttpGet]
        public ActionResult GetAll()
        {
            //ServiceReferenceDepartamento.DepartamentoClient clientDepto = new ServiceReferenceDepartamento.DepartamentoClient();
            //var result = clientDepto.GetAllEF();
            ML.Result result = BL.Alumno.GetAll();

            ML.Alumno alumno = new ML.Alumno();
            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
                return View(alumno);
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
            
        }

        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            if (alumno.IdAlumno == 0)
            {
                result = BL.Alumno.Add(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Alumno agregado correctamente";
                }
            }
            else
            {
                result = BL.Alumno.Update(alumno);
                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizaron los datos del alumno correctamente";
                }
            }

            return PartialView("ValidationModal");
        }

        [HttpGet]
        public ActionResult Form(int? IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            if (IdAlumno == null)
            {
                return View(alumno);
            }
            else
            {
                ML.Result result = BL.Alumno.GetById(IdAlumno.Value);
                if (result.Correct)
                {
                    alumno.IdAlumno = ((ML.Alumno)result.Object).IdAlumno;
                    alumno.Nombre = ((ML.Alumno)result.Object).Nombre;
                    alumno.ApellidoPaterno = ((ML.Alumno)result.Object).ApellidoPaterno;
                    alumno.ApellidoMaterno = ((ML.Alumno)result.Object).ApellidoMaterno;

                    return View(alumno);
                }
                else
                {
                    ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
                    return PartialView("ValidationModal");
                }
            }
        }

        [HttpGet]
        public ActionResult Delete(int IdAlumno)
        {
            ML.Alumno alumno = new ML.Alumno();

            alumno.IdAlumno = IdAlumno;

            ML.Result result = BL.Alumno.Delete(alumno);

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                ViewBag.Message = "Ocurrió un error al eliminar el producto " + result.ErrorMessage;
                return PartialView("ValidationModal");
            }

        }

	}
}