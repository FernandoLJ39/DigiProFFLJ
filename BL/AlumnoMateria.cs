using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var alumnomMaterias = context.AlumnoGetAll().ToList();

                    result.Objects = new List<object>();


                    if (alumnomMaterias != null)
                    {
                        foreach (var obj in alumnomMaterias)
                        {
                            ML.Alumno alumno = new ML.Alumno();

                            alumno.IdAlumno = obj.IdAlumno;
                            alumno.Nombre = obj.Nombre;
                            alumno.ApellidoPaterno = obj.ApellidoPaterno;
                            alumno.ApellidoMaterno = obj.ApellidoMaterno;

                            result.Objects.Add(alumno);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
         
        public static ML.Result MateriasGetAsignadas(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var query = context.AlumnoGetMateriasAsignadas(alumnoMateria.Alumno.IdAlumno).ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                            alumnomateria.Materia = new ML.Materia();
                            alumnomateria.IdAlumnoMateria = obj.IdAlumnoMateri;
                            alumnomateria.Materia.Nombre = obj.NombreMateria;
                            alumnomateria.Materia.Costo = obj.Costo.Value;

                            result.Objects.Add(alumnomateria);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encuentran registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result MateriaGetNoAsignadas(ML.AlumnoMateria alumnoMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var query = context.AlumnoGetMateriasNoAsignadas(alumnoMateria.Alumno.IdAlumno);

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                            alumnomateria.Materia = new ML.Materia();
                            alumnomateria.Materia.IdMateria = obj.IdMateria;
                            alumnomateria.Materia.Nombre = obj.Nombre;
                            alumnomateria.Materia.Costo = obj.Costo.Value;


                            result.Objects.Add(alumnomateria);
                        }

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();  
            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var query = context.AlumnoMateriaDelete(alumnomateria.IdAlumnoMateria);
                    result.Object = alumnomateria; 
                     
                    if (query >= 1)
                    {
                        result.Correct = true; 
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encntraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        } 

        public static ML.Result Add(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var query = context.AlumnoMateriaAdd(alumnomateria.Alumno.IdAlumno,
                        alumnomateria.Materia.IdMateria);

                    result.Object = alumnomateria;

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


    }
}
