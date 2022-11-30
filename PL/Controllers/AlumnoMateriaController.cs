using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        //
        // GET: /AlumnoMateria/
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = BL.AlumnoMateria.GetAll();

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
        }//termina GetAll

        [HttpGet]
        public ActionResult MateriaGetAsignada(int? IdAlumno)
        {
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
            ML.Result result = new ML.Result();

            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno.Value;

            result=BL.Alumno.GetById(alumnoMateria.Alumno.IdAlumno);

            if (result.Object != null)
            {
                //ML.Alumno alumno = new ML.Alumno();

                alumnoMateria.Alumno.IdAlumno = ((ML.Alumno)result.Object).IdAlumno;
                alumnoMateria.Alumno.Nombre = ((ML.Alumno)result.Object).Nombre;
                alumnoMateria.Alumno.ApellidoPaterno = ((ML.Alumno)result.Object).ApellidoPaterno;
                alumnoMateria.Alumno.ApellidoMaterno = ((ML.Alumno)result.Object).ApellidoMaterno;
               
                result = BL.AlumnoMateria.MateriasGetAsignadas(alumnoMateria);
                alumnoMateria.AlumnoMaterias = result.Objects;

                return View(alumnoMateria);

            }
            else
            {
                ViewBag.Message = "Ocurrio un error al obtener la información" + result.ErrorMessage;
                return PartialView("ValidationModal");
            }
 
        }//termina MateriasGetAsignadasByIdAlumno

        public ActionResult Delete(ML.AlumnoMateria alumnomateria)
        {
            alumnomateria.Alumno = new ML.Alumno();
            //alumnomateria.Alumno.IdAlumno;
            ML.Result result = BL.AlumnoMateria.Delete(alumnomateria);

            if (result.Correct == true)
            {
                ViewBag.Message = "Se ha eliminado correctamente el registro";
                return RedirectToAction("MateriaGetAsignada", alumnomateria.Alumno.IdAlumno);
            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar la materia";
                return RedirectToAction("MateriaGetAsignada", alumnomateria.Alumno.IdAlumno);
            }
        }

        [HttpGet]
        public ActionResult MateriaGetNoAsignada(int? IdAlumno)
        { 
            ML.Result result = new ML.Result();
            ML.AlumnoMateria alumnoMateria = new ML.AlumnoMateria();
           

            alumnoMateria.Alumno = new ML.Alumno();
            alumnoMateria.Alumno.IdAlumno = IdAlumno.Value;

            result = BL.Alumno.GetById(alumnoMateria.Alumno.IdAlumno);

            if (result.Object != null)
            {
                //ML.Alumno alumnoItem = new ML.Alumno();
                alumnoMateria.Alumno.IdAlumno = ((ML.Alumno)result.Object).IdAlumno;
                alumnoMateria.Alumno.Nombre = ((ML.Alumno)result.Object).Nombre;
                alumnoMateria.Alumno.ApellidoPaterno = ((ML.Alumno)result.Object).ApellidoPaterno;
                alumnoMateria.Alumno.ApellidoMaterno = ((ML.Alumno)result.Object).ApellidoMaterno;


                result = BL.AlumnoMateria.MateriaGetNoAsignadas(alumnoMateria);
                alumnoMateria.AlumnoMaterias = result.Objects;
            }
                return View(alumnoMateria);
        }

        [HttpPost]

        public ActionResult MateriaGetNoAsignada(ML.AlumnoMateria alumnoMateria)
        {
            if (alumnoMateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnoMateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

                    alumnomateria.Alumno = new ML.Alumno();
                    alumnomateria.Alumno.IdAlumno = alumnoMateria.Alumno.IdAlumno;

                    alumnomateria.Materia = new ML.Materia();
                    alumnomateria.Materia.IdMateria = int.Parse(IdMateria);
                        ML.Result result = BL.AlumnoMateria.Add(alumnomateria);
                }
            }
            else
            {

            }
            return RedirectToAction("MateriaGetAsignada", alumnoMateria.Alumno);

        }

    }
}