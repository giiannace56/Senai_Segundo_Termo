-- DDL

CREATE DATABASE Medical

USE Medical

CREATE TABLE tiposUsuarios
(
		idTiposUsuarios INT PRIMARY KEY IDENTITY
	   ,tituloTipoUsuario VARCHAR(200) NOT NULL
);

CREATE TABLE usuarios
(
		idUsuario INT PRIMARY KEY IDENTITY
	   ,idTiposUsuarios INT FOREIGN KEY REFERENCES tiposUsuarios(idTiposUsuarios)
	   ,email VARCHAR(200) NOT NULL
	   ,senha VARCHAR(200) NOT NULL
);

CREATE TABLE paciente
(
		idPaciente INT PRIMARY KEY IDENTITY
	   ,idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	   ,dataNascimento DATE NOT NULL
	   ,endereco VARCHAR(200) NOT NULL
	   ,rg VARCHAR(200) NOT NULL
	   ,cpf VARCHAR(200) NOT NULL
	   ,telefone VARCHAR(200) 
);

CREATE TABLE especialidade
(
		idEspecialidade INT PRIMARY KEY IDENTITY
	   ,nomeEspecialidade VARCHAR(200) NOT NULL
);

CREATE TABLE clinica
(
		idClinica INT PRIMARY KEY IDENTITY
	   ,cnpj VARCHAR(200) NOT NULL
	   ,endereco VARCHAR(200) NOT NULL
	   ,nomeFantasia VARCHAR(200) NOT NULL
	   ,razaoSocial VARCHAR(200) NOT NULL
);

CREATE TABLE situacao
(
		idSituacao INT PRIMARY KEY IDENTITY
	   ,situacao VARCHAR(200) NOT NULL
);

CREATE TABLE medico
(
		idMedico INT PRIMARY KEY IDENTITY
	   ,idUsuario INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	   ,idEspecialidade INT FOREIGN KEY REFERENCES especialidade(idEspecialidade)
	   ,idClinica INT FOREIGN KEY REFERENCES clinica(idClinica)
	   ,crm VARCHAR(200) NOT NULL
);

CREATE TABLE consulta
(
		idConsulta INT PRIMARY KEY IDENTITY
	   ,idMedico INT FOREIGN KEY REFERENCES medico(idMedico)
	   ,idPaciente INT FOREIGN KEY REFERENCES paciente(idPaciente)
	   ,idSituacao INT FOREIGN KEY REFERENCES situacao(idSituacao)
	   ,dataConsulta DATE NOT NULL
	   ,horaConsulta VARCHAR(200) NOT NULL
	   ,descricao VARCHAR (200) NOT NULL
);