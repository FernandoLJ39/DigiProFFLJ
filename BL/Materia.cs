using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var restulQuery = context.MateriaAdd(materia.Nombre, decimal.ToSingle(materia.Costo));


                    if (restulQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }//termina add

        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var restulQuery = context.MateriaUpdate(materia.IdMateria,materia.Nombre, decimal.ToSingle(materia.Costo));


                    if (restulQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var restulQuery = context.MateriaDelete(materia.IdMateria);


                    if (restulQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var materias = context.MateriaGetAll().ToList();

                    result.Objects = new List<object>();


                    if (materias != null)
                    {
                        foreach (var obj in materias)
                        {
                            ML.Materia materia = new ML.Materia();

                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo.Value;

                            result.Objects.Add(materia);
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

        public static ML.Result GetById(int IdMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FLunaPruebaDigiProEntities context = new DL.FLunaPruebaDigiProEntities())
                {
                    var objMateria = context.MateriaGetById(IdMateria).FirstOrDefault();

                    result.Objects = new List<object>();

                    if (objMateria != null)
                    {
                        ML.Materia materia = new ML.Materia();
                        materia.IdMateria = objMateria.IdMateria;
                        materia.Nombre = objMateria.Nombre;
                        materia.Costo = objMateria.Costo.Value;

                        result.Object = materia;

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
    }
}
