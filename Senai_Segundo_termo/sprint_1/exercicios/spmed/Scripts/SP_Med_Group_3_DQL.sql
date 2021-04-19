--DQL
USE Medical_Group
GO

--Seleção para mostrar todas as tabelas separadamente 
SELECT * FROM tipoUsuario
SELECT * FROM usuario
SELECT * FROM clinica
SELECT * FROM especialidade
SELECT * FROM medico
SELECT * FROM situacao
SELECT * FROM paciente
SELECT * FROM consulta
GO

--aqui irá mostrar os email's dos usuários cadastrados com seus devidos "cargos"
SELECT email, nomeTipoUsuario FROM usuario
INNER JOIN tipoUsuario
ON tipoUsuario.idTipoUsuario = usuario.idTipoUsuario


--Junção de tabelas para mostrar quando será a consulta, com qual doutor(a), dados do paciente e a situação da consulta, se foi realizada, cancelada ou ainda está agendada.
SELECT situacao, nomeMedico, nomePaciente, dataNascimento, dataConsulta, telefone, RG, CPF, rua, numero, bairro, cidade, estado, cep, complemento, descricao FROM consulta
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente
INNER JOIN medico
ON medico.idMedico = consulta.idMedico
INNER JOIN situacao
ON situacao.idSituacao = consulta.idSituacao

--Nessa situação, os médicos poderão ver os agendamentos(ou cancelamentos) associados a eles.
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


-- Já nessa situação temos o contrário, o paciente poderá ver suas consultas (sendo elas agendadas ou não).
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
-- idPaciente 12 = João -- 
-- idPaciente 13 = Bruno --


--Junção de tabelas para mostrar o médico e sua devida especialidade
SELECT nomeEspecialidade, nomeMedico FROM especialidade
INNER JOIN medico
ON medico.idEspecialidade = especialidade.idEspecialidade

--Junção de tabelas para mostrar os médicos, suas especialidades e a clínica na qual estão atuando no momento
SELECT CRM, nomeMedico, nomeEspecialidade, nomeFantasia, cnpj, razaoSocial, rua, numero, bairro, cidade, estado FROM medico
INNER JOIN clinica
ON clinica.idClinica = medico.idClinica
INNER JOIN especialidade
ON especialidade.idEspecialidade = medico.idEspecialidade

-- Parte dedicada à administração para ver os cadastros dos usuários
SELECT nomeTipoUsuario, email, senha FROM usuario
INNER JOIN tipoUsuario
ON usuario.idTipoUsuario = tipoUsuario.idTipoUsuario
where idUsuario = 1

-- CAPACIDADES E CRITÉRIOS --

-- Quantidade de usuários cadastrados.
SELECT COUNT (usuario.idUsuario) AS QtdUsuarios FROM usuario

-- Mostra a idade dos pacientes através de um cáculo feito pelo número de horas que um ano possui (8766h no caso).
SELECT dataNascimento, DATEDIFF(HOUR, dataNascimento, GETDATE())/8766 AS Idade FROM paciente

-- Mostra a idade dos pacientes atualizadas todos os anos.
SELECT paciente.nomePaciente, paciente.dataNascimento
,DATEDIFF(YEAR, paciente.dataNascimento, GETDATE()) AS 'Idade Atual'
FROM paciente


-- Criação de função para determinar a quantidade de médicos especializados em determinada área

CREATE FUNCTION QntdMedicos(@idEspecialidade VARCHAR(255)) -- Será um método parecido com o que usamos em C# no VSCODE, @idEspecialidade será um atributo declarado que receberá um valor mais a frente
RETURNS INT -- Auto-explicativo, irá retornar um valor INTEIRO
AS -- Como
BEGIN -- Início do método
		DECLARE @qntd AS INT -- Criado um outro atributo para armazenar o resultado.
		SET @qntd = -- Irá definir parametros dentro do @qntd
		(
			SELECT COUNT(nomeMedico) FROM medico -- Contagem dos nomes dos médicos.
			INNER JOIN especialidade -- Relacionando com a tabela de especialidade
			ON medico.idEspecialidade = especialidade.idEspecialidade -- Relação de PK com FK
			WHERE especialidade.nomeEspecialidade = @idEspecialidade -- Condição "onde" onde só irá acontecer quando o nomeEspecialidade for igual ao @idEspecialidade.
		)
		RETURN @qntd -- Retorna o valor
END -- Término da função
GO
SELECT qntd = dbo.QntdMedicos('Pediatria') -- Vai reunir todos os médicos que são de específica especialidade indicada dentro dos parênteses e fazer a contagem
SELECT dbo.QntdMedicos('Pediatria') AS 'Quantidade de Médicos' -- É a mesma função, porém com o nome da tabela alterado.
	





