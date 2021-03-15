--DQL
USE Medical_Group
GO

--Sele��o para mostrar todas as tabelas separadamente 
SELECT * FROM tipoUsuario
SELECT * FROM usuario
SELECT * FROM clinica
SELECT * FROM especialidade
SELECT * FROM medico
SELECT * FROM situacao
SELECT * FROM paciente
SELECT * FROM consulta
GO

--aqui ir� mostrar os email's dos usu�rios cadastrados com seus devidos "cargos"
SELECT email, nomeTipoUsuario FROM usuario
INNER JOIN tipoUsuario
ON tipoUsuario.idTipoUsuario = usuario.idTipoUsuario


--Jun��o de tabelas para mostrar quando ser� a consulta, com qual doutor(a), dados do paciente e a situa��o da consulta, se foi realizada, cancelada ou ainda est� agendada.
SELECT situacao, nomeMedico, nomePaciente, dataNascimento, dataConsulta, telefone, RG, CPF, rua, numero, bairro, cidade, estado, cep, complemento, descricao FROM consulta
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente
INNER JOIN medico
ON medico.idMedico = consulta.idMedico
INNER JOIN situacao
ON situacao.idSituacao = consulta.idSituacao

--Nessa situa��o, os m�dicos poder�o ver os agendamentos(ou cancelamentos) associados a eles.
SELECT situacao, nomeMedico, nomePaciente, dataNascimento, dataConsulta, telefone, RG, CPF, rua, numero, bairro, cidade, estado, cep, complemento, descricao FROM consulta
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente
INNER JOIN medico
ON medico.idMedico = consulta.idMedico
INNER JOIN situacao
ON situacao.idSituacao = consulta.idSituacao
WHERE medico.idMedico = 3;
-- idMedico 1 = Ricardo Lemos --
-- idMedico 2 = Ricardo Possarle -- 
-- idMedico 3 = Helena Strada --


-- J� nessa situa��o temos o contr�rio, o paciente poder� ver suas consultas (sendo elas agendadas ou n�o).
SELECT situacao, nomeMedico, nomePaciente, dataNascimento, dataConsulta, telefone, RG, CPF, rua, numero, bairro, cidade, estado, cep, complemento, descricao FROM consulta
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente
INNER JOIN medico
ON medico.idMedico = consulta.idMedico
INNER JOIN situacao
ON situacao.idSituacao = consulta.idSituacao
WHERE paciente.idPaciente = 9;
-- idPaciente 7 = Mariana -- 
-- idPaciente 8 = ligia -- 
-- idPaciente 9 = Alexandre -- 
-- idPaciente 10 = Fernando -- 
-- idPaciente 11 = Henrique -- 
-- idPaciente 12 = Jo�o -- 
-- idPaciente 13 = Bruno --


--Jun��o de tabelas para mostrar o m�dico e sua devida especialidade
SELECT nomeEspecialidade, nomeMedico FROM especialidade
INNER JOIN medico
ON medico.idEspecialidade = especialidade.idEspecialidade

--Jun��o de tabelas para mostrar os m�dicos, suas especialidades e a cl�nica na qual est�o atuando no momento
SELECT CRM, nomeMedico, nomeEspecialidade, nomeFantasia, cnpj, razaoSocial, rua, numero, bairro, cidade, estado FROM medico
INNER JOIN clinica
ON clinica.idClinica = medico.idClinica
INNER JOIN especialidade
ON especialidade.idEspecialidade = medico.idEspecialidade

-- Parte dedicada � administra��o para ver os cadastros dos usu�rios
SELECT nomeTipoUsuario, email, senha FROM usuario
INNER JOIN tipoUsuario
ON usuario.idTipoUsuario = tipoUsuario.idTipoUsuario
where idUsuario = 1

-- CAPACIDADES E CRIT�RIOS --

-- Quantidade de usu�rios cadastrados.
SELECT COUNT (usuario.idUsuario) AS QtdUsuarios FROM usuario

-- Mostra a idade dos pacientes atrav�s de um c�culo feito pelo n�mero de horas que um ano possui (8766h no caso).
SELECT dataNascimento, DATEDIFF(HOUR, dataNascimento, GETDATE())/8766 AS Idade FROM paciente

-- Mostra a idade dos pacientes atualizadas todos os anos.
SELECT paciente.nomePaciente, paciente.dataNascimento
,DATEDIFF(YEAR, paciente.dataNascimento, GETDATE()) AS 'Idade Atual'
FROM paciente


-- Cria��o de fun��o para determinar a quantidade de m�dicos especializados em determinada �rea

CREATE FUNCTION QntdMedicos(@idEspecialidade VARCHAR(255)) -- Ser� um m�todo parecido com o que usamos em C# no VSCODE, @idEspecialidade ser� um atributo declarado que receber� um valor mais a frente
RETURNS INT -- Auto-explicativo, ir� retornar um valor INTEIRO
AS -- Como
BEGIN -- In�cio do m�todo
		DECLARE @qntd AS INT -- Criado um outro atributo para armazenar o resultado.
		SET @qntd = -- Ir� definir parametros dentro do @qntd
		(
			SELECT COUNT(nomeMedico) FROM medico -- Contagem dos nomes dos m�dicos.
			INNER JOIN especialidade -- Relacionando com a tabela de especialidade
			ON medico.idEspecialidade = especialidade.idEspecialidade -- Rela��o de PK com FK
			WHERE especialidade.nomeEspecialidade = @idEspecialidade -- Condi��o "onde" onde s� ir� acontecer quando o nomeEspecialidade for igual ao @idEspecialidade.
		)
		RETURN @qntd -- Retorna o valor
END -- T�rmino da fun��o
GO
SELECT qntd = dbo.QntdMedicos('Pediatria') -- Vai reunir todos os m�dicos que s�o de espec�fica especialidade indicada dentro dos par�nteses e fazer a contagem
SELECT dbo.QntdMedicos('Pediatria') AS 'Quantidade de M�dicos' -- � a mesma fun��o, por�m com o nome da tabela alterado.
	





