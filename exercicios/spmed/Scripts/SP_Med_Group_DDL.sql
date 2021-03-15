--DDL

--Cria um bd
CREATE DATABASE Medical_Group
GO

--Define qual bd irei usar
USE Medical_Group
GO

--Criação de tabelas
CREATE TABLE tipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY
	,nomeTipoUsuario	VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario)
	,email			VARCHAR (100) UNIQUE NOT NULL
	,senha			VARCHAR (100) NOT NULL
);
GO

CREATE TABLE clinica
(
	idClinica		INT PRIMARY KEY IDENTITY
	,cnpj			CHAR(14) UNIQUE NOT NULL
	,rua			VARCHAR(255) UNIQUE NOT NULL
	,numero			INT NOT NULL
	,bairro			VARCHAR(255) UNIQUE NOT NULL
	,cidade			VARCHAR(255) UNIQUE NOT NULL
	,estado			VARCHAR(255) UNIQUE NOT NULL
	,nomeFantasia	VARCHAR(255) UNIQUE NOT NULL
	,razaoSocial	VARCHAR(255) UNIQUE NOT NULL
);
GO

CREATE TABLE especialidade
(
	idEspecialidade		INT PRIMARY KEY IDENTITY
	,nomeEspecialidade	VARCHAR(255) NOT NULL
);
GO

CREATE TABLE medico
(
	idMedico			INT PRIMARY KEY IDENTITY
	,idUsuario			INT FOREIGN KEY REFERENCES usuario(idUsuario)
	,idEspecialidade	INT FOREIGN KEY REFERENCES especialidade(idEspecialidade)
	,idClinica			INT FOREIGN KEY REFERENCES clinica(idClinica)
	,CRM				INT UNIQUE NOT NULL
	,nomeMedico			VARCHAR(255) NOT NULL
);

CREATE TABLE situacao
(
	idSituacao	INT PRIMARY KEY IDENTITY
	,situacao	VARCHAR(45) UNIQUE NOT NULL
);
GO

CREATE TABLE paciente
(
	idPaciente		INT PRIMARY KEY IDENTITY
	,idUsuario		INT FOREIGN KEY REFERENCES usuario(idUsuario)
	,nomePaciente	VARCHAR(255) NOT NULL
	,RG				CHAR(9) UNIQUE NOT NULL
	,CPF			CHAR(11) UNIQUE NOT NULL
	,rua			VARCHAR(255) NOT NULL
	,numero			INT NOT NULL
	,bairro			VARCHAR(255) NOT NULL
	,cidade			VARCHAR(255) NOT NULL
	,estado			CHAR(2) NOT NULL
	,cep			CHAR(8) NOT NULL
	,complemento	VARCHAR(255) DEFAULT 'N/D'
	,dataNascimento	DATE NOT NULL
	,telefone		VARCHAR(11) DEFAULT 'N/D'		
);
GO

CREATE TABLE consulta
(
	idConsulta		INT PRIMARY KEY IDENTITY
	,idMedico		INT FOREIGN KEY REFERENCES medico(idMedico)
	,idPaciente		INT FOREIGN KEY REFERENCES paciente(idPaciente)
	,idSituacao		INT FOREIGN KEY	REFERENCES situacao(idSituacao)
	,dataConsulta	DATE NOT NULL
	,descricao		VARCHAR(255) DEFAULT 'Não informado.'
);
GO