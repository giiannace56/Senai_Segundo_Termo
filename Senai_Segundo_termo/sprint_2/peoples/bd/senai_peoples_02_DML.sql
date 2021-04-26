-- DML

USE T_Peoples;
GO

INSERT INTO funcionarios(nome, sobrenome, dataNascimento)
VALUES	('Catarina', 'Strada', '01/03/1991'),
		('Tadeu', 'Vitelli', '13/07/1993');
GO

INSERT INTO tipoUsuarios(permissao)
VALUES	('Administrador'),
		('Comum');
GO

INSERT INTO usuarios(email, senha, idTipoUsuario)
VALUES	('catarina@email.com', '1234', 2),
		('tadeu@email.com', '1234', 2),
		('lucas@email.com', '1234', 2),
		('adm@email.com', '1234', 1);
GO