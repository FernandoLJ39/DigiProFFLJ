using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Alumno : IAlumno
    {
        public SL_WCF.Result GetAll()
        {
            ML.Result resultAlumno = BL.Alumno.GetAll();
            return new Result { Correct = resultAlumno.Correct, ErrorMessage = resultAlumno.ErrorMessage, Ex = resultAlumno.Ex, Objects = resultAlumno.Objects };
        }

        public SL_WCF.Result Add(ML.Alumno alumno)
        {
            ML.Result resultDepartamento = BL.Alumno.Add(alumno);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result Update(ML.Alumno alumno)
        {
            ML.Result resultDepartamento = BL.Alumno.Update(alumno);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result Delete(ML.Alumno alumno)
        {
            ML.Result resultDepartamento = BL.Alumno.Delete(alumno);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex };
        }

        public SL_WCF.Result GetById(int IdAlumno)
        {
            ML.Result resultDepartamento = BL.Alumno.GetById(IdAlumno);
            return new Result { Correct = resultDepartamento.Correct, ErrorMessage = resultDepartamento.ErrorMessage, Ex = resultDepartamento.Ex, Object = resultDepartamento.Object };

        }


    }
}
