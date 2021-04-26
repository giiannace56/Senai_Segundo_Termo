-- DQL

USE T_Peoples;
GO

SELECT * FROM funcionarios;
GO

SELECT idFuncionario, funcionarios.nome, funcionarios.sobrenome, CONVERT (VARCHAR, dataNascimento, 106) AS dataNascimento FROM funcionarios;
GO

SELECT idTipoUsuario, permissao FROM tipoUsuarios;
GO

SELECT idUsuario, email, tipoUsuarios.idTipoUsuario, permissao FROM usuarios
INNER JOIN tipoUsuarios
ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario;
GO

SELECT idUsuario, email, tipoUsuarios.idTipoUsuario, permissao FROM usuarios
INNER JOIN tipoUsuarios
ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario
WHERE email = 'adm@email.com' AND senha = '1234';
GO