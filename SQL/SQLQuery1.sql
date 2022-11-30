CREATE PROCEDURE MateriaGetByIdAlumno
@IdAlumno INT 
AS 
	SELECT 
		AlumnoMateria.IdAlumnoMateria,
		Materia.Nombre

		FROM AlumnoMateria

		INNER JOIN Materia ON AlumnoMateria.IdMateria = Materia.IdMateria

		WHERE IdAlumno = @IdAlumno

