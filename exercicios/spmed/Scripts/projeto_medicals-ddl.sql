create database projeto_medicals;
go

use projeto_medicals;
go

create table tipoUsuario
(
	idTipoUsuario int primary key identity
	,tituloTipoUsuario varchar (200) unique not null
);
go

create table Usuario
(
	idUsuario int primary key identity
	,idTipoUsuario int foreign key references tipoUsuario(idTipoUsuario)
	,email varchar (150) unique not null
	,senha varchar (100) not null

);
go

create table especialidade
(
	idEspecialidade int primary key identity
	,nomeEspecialidade varchar (100) unique not null
);
go

create table clinica
(
	idClinica int primary key identity
	,CNPJ char (14) unique
	,endereco varchar (200) unique not null
	,nomeFantasia varchar (100) unique not null
	,razaoSocial varchar (150) unique not null
);
go

create table medico
(
	idMedico int primary key identity
	,idUsuario int foreign key references Usuario(idUsuario)
	,idEspecialidade int foreign key references especialidade(idEspecialidade)
	,idClinica int foreign key references clinica(idClinica)
	,nomeMedico varchar (100) not null
	,CRM varchar (50) unique not null
);
go

create table paciente
(
	idPaciente int primary key identity
	,idUsuario int foreign key references Usuario(idUsuario)
	,dataNascimento date not null
	,nomePaciente varchar (100) not null
	,RG char (9) unique not null
	,CPF char (11) unique not null
	,telefone varchar (11) 
	,endereco varchar (100) unique not null
);
go

create table situacao
(
	idSituacao int primary key identity
	,situacao varchar(30) not null
);
go

create table consulta
(
	idConsulta int primary key identity
	,idMedico int foreign key references medico(idMedico)
	,idPaciente int foreign key references paciente(idPaciente)
	,idSituacao int foreign key references situacao(idSituacao)
	,dataConsulta date not null
	,descricao varchar (255) not null
);
go