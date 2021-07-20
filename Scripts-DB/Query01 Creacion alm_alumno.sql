use Registro
CREATE TABLE alm_alumno(
alm_id INT IDENTITY(1,1) NOT NULL,
PRIMARY KEY(alm_id),
alm_codigo varchar(100),
alm_nombre varchar(300),
alm_edad int,
alm_sexo varchar(100),
alm_id_grd int,
alm_observacion  varchar(300),
CONSTRAINT FK_Alumnos_Grado FOREIGN KEY(alm_id_grd)
REFERENCES dbo.grd_grado(grd_id)
)