using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace PL.Controllers
{
	public class MateriaController : Controller
	{
		//
		// GET: /Materia/
		[HttpGet]
		public ActionResult GetAll()
		{
			ML.Result result = BL.Materia.GetAll();

			ML.Materia materia = new ML.Materia();
			if (result.Correct)
			{
				materia.Materias = result.Objects.ToList();
				return View(materia);
			}
			else
			{
				ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
				return PartialView("ValidationModal");
			}

		}

		[HttpPost]
		public ActionResult Form(ML.Materia materia)
		{
			ML.Result result = new ML.Result();

			char[] ValidacionNombreMateria = ConfigurationManager.AppSettings["ValidacionNombreMateria"].ToCharArray();
			// &<>/
			foreach (char caracter in ValidacionNombreMateria)
			{
				materia.Nombre = materia.Nombre.Replace(caracter.ToString(), "");
			}

			if (materia.IdMateria == 0)
			{
				result = BL.Materia.Add(materia);
				if (result.Correct)
				{
					ViewBag.Message = "Materia agregada correctamente";
				}
			}
			else
			{
				result = BL.Materia.Update(materia);
				if (result.Correct)
				{
					ViewBag.Message = "Se actualizaron los datos de la materia correctamente";
				}
			}

			return PartialView("ValidationModal");
		}

		[HttpGet]
		public ActionResult Form(int? IdMateria)
		{
			ML.Materia materia = new ML.Materia();

			if (IdMateria == null)
			{
				return View(materia);
			}
			else
			{
				ML.Result result = BL.Materia.GetById(IdMateria.Value);
				if (result.Correct)
				{
					materia.IdMateria = ((ML.Materia)result.Object).IdMateria;
					materia.Nombre = ((ML.Materia)result.Object).Nombre;
					materia.Costo = ((ML.Materia)result.Object).Costo;

					return View(materia);
				}
				else
				{
					ViewBag.Message = "Ocurrió un error al obtener la información" + result.ErrorMessage;
					return PartialView("ValidationModal");
				}
			}
		}

		[HttpGet]
		public ActionResult Delete(int IdMateria)
		{
			ML.Materia materia = new ML.Materia();

			materia.IdMateria = IdMateria;

			ML.Result result = BL.Materia.Delete(materia);

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