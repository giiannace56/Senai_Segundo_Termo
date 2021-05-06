CREATE DATABASE HRoads;

USE HRoads;

CREATE TABLE TiposHabilidades
(
	idTiposHabilidades INT PRIMARY KEY IDENTITY
	,Tipos			   VARCHAR(200) 
);

CREATE TABLE Habilidades
(
	idHabilidades INT PRIMARY KEY IDENTITY
	,Tecnicas	  VARCHAR(200) 
);


CREATE TABLE Classes
(
	idClasses INT PRIMARY KEY IDENTITY
	,Cargos	  VARCHAR(200) 
);

CREATE TABLE Personagens
(
	idPersonagem	 INT PRIMARY KEY IDENTITY
	,Nomes			 VARCHAR(200) NOT NULL
	,VidaMaxima		 VARCHAR(200) NOT NULL
	,ManaMaxima		 VARCHAR(200) NOT NULL
	,DataAtualizacao DATE NOT NULL
	,DataCriacao	 DATE NOT NULL
	,idClasses		 INT FOREIGN KEY REFERENCES Classes(idClasses)
);


CREATE TABLE ClassesHabilidades
(
	idClasses			INT FOREIGN KEY REFERENCES Classes(idClasses)
	,idHabilidades		INT FOREIGN KEY REFERENCES Habilidades(idHabilidades)
);

CREATE TABLE TiposUsuarios
(
	idTiposUsuarios INT PRIMARY KEY IDENTITY
	,TiposUsuarios VARCHAR(200) NOT NULL
);

CREATE TABLE Usuarios
(
	idUsuarios			INT PRIMARY KEY IDENTITY
	,emailsUsuarios		VARCHAR(200) NOT NULL UNIQUE
	,senhasUsuarios		VARCHAR(200) NOT NULL
	,idTiposUsuarios	INT FOREIGN KEY REFERENCES TiposUsuarios(idTiposUsuarios)
);
