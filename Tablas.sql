CREATE TABLE Alumno 
	(IdAlumno INT IDENTITY(1,1) PRIMARY KEY
	,Nombre VARCHAR (50)
	,ApellidoPaterno VARCHAR (50)
	,ApellidoMaterno VARCHAR (50))
----------------------------------------------------------------------
CREATE TABLE Materia 
	(IdMateria INT IDENTITY(1,1) PRIMARY KEY
	,Nombre VARCHAR (50)
	,Costo DECIMAL(18,2))
----------------------------------------------------------------------
CREATE TABLE AlumnoMateria
	(IdAlumnoMateria INT IDENTITY(1,1) PRIMARY KEY
	,IdAlumno INT FOREIGN KEY REFERENCES Alumno(IdAlumno)
	,IdMateria INT FOREIGN KEY REFERENCES Materia(IdMateria))