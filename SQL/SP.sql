
------------------------------------
--Alumno

CREATE PROCEDURE AlumnoGetAll
AS
	SELECT [IdAlumno]
		  ,[Nombre]
		  ,[ApellidoPaterno]
		  ,[ApellidoMaterno]
	  FROM [Alumno]
-------------------------------
CREATE PROCEDURE AlumnoGetById
@IdAlumno INT 
AS 
		SELECT [IdAlumno]
		  ,[Nombre]
		  ,[ApellidoPaterno]
		  ,[ApellidoMaterno]
	  FROM [Alumno]
	  WHERE IdAlumno = @IdAlumno
--------------------------------------
CREATE PROCEDURE AlumnoAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR (50),
@ApellidoMaterno VARCHAR (50)
AS 
	INSERT INTO [Alumno]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno])
     VALUES
           (@Nombre,
			@ApellidoPaterno,
			@ApellidoMaterno)
--------------------------------------

CREATE PROCEDURE AlumnoUpdate
@IdAlumno INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR (50),
@ApellidoMaterno VARCHAR (50)
AS 
	UPDATE [Alumno]
	   SET [Nombre] = @Nombre
		  ,[ApellidoPaterno] = @ApellidoPaterno
		  ,[ApellidoMaterno] = @ApellidoMaterno
	 WHERE IdAlumno = @IdAlumno
------------------------------------------

CREATE PROCEDURE AlumnoDelete
@IdAlumno INT 
AS
	DELETE FROM [Alumno]
      WHERE IdAlumno = @IdAlumno
--------------------------------------------
--Materia 

CREATE PROCEDURE MateriaGetAll
AS
	SELECT [IdMateria]
		  ,[Nombre]
		  ,[Costo]
	  FROM [Materia]
-------------------------------
CREATE PROCEDURE MateriaGetById
@IdMateria INT 
AS 
		SELECT [IdMateria]
		  ,[Nombre]
		  ,[Costo]
	  FROM Materia
	  WHERE IdMateria = @IdMateria
--------------------------------------
CREATE PROCEDURE MateriaAdd
@Nombre VARCHAR(50),
@Costo DECIMAL(18,2)
AS 
	INSERT INTO [Materia]
           ([Nombre]
           ,[Costo])
     VALUES
           (@Nombre,
			@Costo)
--------------------------------------

CREATE PROCEDURE MateriaUpdate
@IdMateria INT,
@Nombre VARCHAR(50),
@Costo DECIMAL(18,2)
AS 
	UPDATE Materia
	   SET [Nombre] = @Nombre
		  ,[Costo] = @Costo

	 WHERE IdMateria = @IdMateria
------------------------------------------

CREATE PROCEDURE MateriaDelete
@IdMateria INT 
AS
	DELETE FROM Materia
      WHERE IdMateria = @IdMateria
				