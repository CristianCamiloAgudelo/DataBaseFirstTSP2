CREATE DATABASE DataBaseFirstTSP2
GO 
USE DataBaseFirstTSP2
    GO 
CREATE TABLE EquipoDesarrollo
  ( 
     EquipoDesarrolloId  BIGINT IDENTITY(1, 1) NOT NULL, 
	Nombre nvarchar(50), 

     PRIMARY KEY (EquipoDesarrolloId)
  )
GO
CREATE TABLE Usuario
  ( 
	UsuarioId   BIGINT IDENTITY(1, 1) NOT NULL,
     	Nombre nvarchar(50),
	Apellido nvarchar(50),
	Universidad nvarchar(50),
	Codigo nvarchar(50),
	Rol nvarchar(50),
	EquipoDesarrolloId BIGINT NOT NULL, 

     PRIMARY KEY (UsuarioId), 
	 FOREIGN KEY (EquipoDesarrolloId) REFERENCES EquipoDesarrollo(EquipoDesarrolloId) 
     
  ) 
  GO
  CREATE TABLE PlanGrupal
  ( 
     PlanGrupalId  BIGINT IDENTITY(1, 1) NOT NULL,
     Nombre nvarchar(50),
	 EquipoDesarrolloId BIGINT NOT NULL,

     PRIMARY KEY (PlanGrupalId),
	 FOREIGN KEY (EquipoDesarrolloId) REFERENCES EquipoDesarrollo(EquipoDesarrolloId) 
  )
GO 
CREATE TABLE PlanIndividual
  ( 
     PlanIndividualId  BIGINT IDENTITY(1, 1) NOT NULL,
     Nombre nvarchar(50),
	UsuarioId   BIGINT NOT NULL,
	
     PRIMARY KEY (PlanIndividualId),
	FOREIGN KEY (UsuarioId) REFERENCES Usuario(UsuarioId)
  )
GO 
CREATE TABLE Tarea
  ( 
     TareaId BIGINT IDENTITY(1, 1) NOT NULL, 
     Nombre nvarchar(50),
	MinutosLiderProyectoPlaneado int,
	MinutosLiderPlaneacionPlaneado int,
	MinutosLiderDesarrolloPlaneado int,
	MinutosLiderCalidadPlaneado int,
	MinutosLiderSoportePlaneado int,
	MinutosTotalesPlaneados int,
	MinutosLiderProyectoReales int,
	MinutosLiderPlaneacionReales int,
	MinutosLiderDesarrolloReales int,
	MinutosLiderCalidadReales int,
	MinutosLiderSoporteReales int,
	MinutosTotalesReales int,
	ValorPlaneado real,
	ValorGanado real,
	SemanaTerminacionPlaneada int,
	SemanaTerminacionReal int,
	PlanGrupalId BIGINT NOT NULL,
	PlanIndividualId BIGINT NOT NULL,

     PRIMARY KEY (TareaId),
	 FOREIGN KEY (PlanGrupalId) REFERENCES PlanGrupal(PlanGrupalId),
	 FOREIGN KEY (PlanIndividualId) REFERENCES PlanIndividual(PlanIndividualId) 
  )

GO 
  
INSERT INTO EquipoDesarrollo
VALUES
('SoftMan')

INSERT INTO Usuario
VALUES
('Cristian Camilo','Agudelo','Universidad de Caldas','1111111','Estudiante',1),
('Sebastian','Grajales','Universidad de Caldas','222222','Estudiante',1),
('Lorenzo','Zuluaga','Universidad de Caldas','333333','Estudiante',1),
('Yerson','Blandito','Universidad de Caldas','444444','Estudiante',1)

INSERT INTO PlanGrupal
VALUES
('Plan Grupal Grupo 1',1)

INSERT INTO PlanIndividual
VALUES
('Plan Individual Lider Planeacion',1),
('Plan Individual Lider Desarrollo',2),
('Plan Individual Lider Calidad',3),
('Plan Individual Lider Soporte',4)

