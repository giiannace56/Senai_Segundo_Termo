use projeto_medicals;
go

select * from tipoUsuario;
select * from Usuario;
select * from especialidade;
select * from clinica;
select * from medico;
select * from paciente;
select * from situacao;
select * from consulta;

select idUsuario, tituloTipoUsuario, email from Usuario
inner join tipoUsuario
on  usuario.idTipoUsuario = tipoUsuario.idTipoUsuario;

select nomeMedico, nomeFantasia from consulta
inner join medico
on consulta.idMedico = medico.idMedico
inner join clinica
on medico.idClinica = clinica.idClinica;

select nomePaciente, nomeMedico, dataConsulta, nomeEspecialidade as especialidade, situacao from consulta
inner join medico
on consulta.idMedico = medico.idMedico
inner join paciente
on consulta.idPaciente = paciente.idPaciente
inner join especialidade
on medico.idEspecialidade = especialidade.idEspecialidade
inner join situacao
on consulta.idSituacao = situacao.idSituacao;

select tituloTipoUsuario[Permissao], email from Usuario
inner join tipoUsuario
on usuario.idTipoUsuario = tipoUsuario.idTipoUsuario
where email = 'adm@adm.com' and senha = 'adm123';