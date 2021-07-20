use Registro
Create table mxg_materiasxgrado(
mxg_id int IDENTITY (1,1) NOT NULL,
mxg_id_grd int,
mxg_id_mat int
PRIMARY KEY(mxg_id),
CONSTRAINT FK_Grado FOREIGN KEY(mxg_id_grd)
REFERENCES dbo.grd_grado(grd_id),
CONSTRAINT FK_Materias FOREIGN KEY(mxg_id_mat)
REFERENCES dbo.mat_materia(mat_id)
)