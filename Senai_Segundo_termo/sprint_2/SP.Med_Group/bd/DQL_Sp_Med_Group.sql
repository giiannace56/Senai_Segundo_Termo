-- DQL

USE Medical;

SELECT * FROM consulta;
SELECT * FROM medico;
SELECT * FROM usuarios;
SELECT * FROM clinica;
SELECT * FROM situacao;
SELECT * FROM especialidade;
SELECT * FROM paciente;
SELECT * FROM tiposUsuarios;

-- Juntei tudo numa tabela só, queria testar se eu ia conseguir kkkkk

SELECT tiposUsuarios.tituloTipoUsuario, usuarios.email, paciente.dataNascimento,
paciente.cpf, paciente.rg, paciente.telefone, especialidade.nomeEspecialidade,
clinica.cnpj, clinica.endereco, clinica.nomeFantasia, clinica.razaoSocial,
medico.crm, consulta.dataConsulta, consulta.horaConsulta, situacao.situacao FROM consulta
INNER JOIN situacao
ON situacao.idSituacao = consulta.idSituacao
INNER JOIN paciente
ON paciente.idPaciente = consulta.idPaciente
INNER JOIN medico
ON medico.idMedico = consulta.idMedico
INNER JOIN clinica
ON clinica.idClinica = medico.idClinica
INNER JOIN usuarios
ON usuarios.idUsuario = paciente.idUsuario
INNER JOIN especialidade
ON especialidade.idEspecialidade = medico.idEspecialidade
INNER JOIN tiposUsuarios
ON tiposUsuarios.idTiposUsuarios = usuarios.idTiposUsuarios;