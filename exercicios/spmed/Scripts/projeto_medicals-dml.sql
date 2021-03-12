use projeto_medicals;
go

insert into tipoUsuario (tituloTipoUsuario)
values					('Administrador')
					   ,('Médico')
					   ,('Paciente');
go

insert into Usuario (idTipoUsuario, email, senha)
values				 (2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123')
					,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle456')
					,(2, 'helena.souza@spmedicalgroup.com.br', 'helena789')
					,(3, 'ligia@gmail.com', 'ligia123')
					,(3, 'alexandre@gmail.com', 'alexandre456')
					,(3, 'fernando@gmail.com', 'fernando789')
					,(3, 'henrique@gmail.com', 'henrique987')
					,(3, 'joao@gmail.com', 'joao654')
					,(3, 'bruno@gmail.com', 'bruno123')
					,(3, 'mariana@outlook.com', 'mariana987')
					,(1, 'adm@adm.com', 'adm123');
go

insert into especialidade (nomeEspecialidade)
values					  ('Acupuntura')
						 ,('Anestesiologia')
						 ,('Angiologia')
						 ,('Cardiologia')
						 ,('Cirurgia Cardiovascular')
						 ,('Cirurgia de Mão')
						 ,('Cirurgia do Aparelho Digestivo')
						 ,('Cirurgia Geral')
						 ,('Cirurgia Pediátrica')
						 ,('Cirurgia Plástica')
						 ,('Cirurgia Torácica')
						 ,('Cirurgia Vascular')
						 ,('Dermatologia')
						 ,('Radioterapia')
						 ,('Urologia')
						 ,('Pediatria')
						 ,('Psiquiatria');
go

insert into clinica (CNPJ, endereco, nomeFantasia, razaoSocial)
values				('86400902000130', 'Av. Barão Limeira, 532', 'Clinica Possarle', 'SP Médical Group');
go

insert into medico (idUsuario, idEspecialidade, idClinica, nomeMedico,CRM)
values			   (1, 2, 1,'Ricardo Lemos','54356-SP')
				  ,(2, 17, 1, 'Roberto Possarle' ,'53452-SP')
				  ,(3, 16, 1, 'Helena Strada' ,'65463-SP');
go

insert into paciente (idUsuario, dataNascimento, nomePaciente, RG, CPF, telefone, endereco)
values				 (4, '10/03/1983', 'Ligia','435225435', '94839859000', '1134567654', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000')
					,(5, '07/03/2001', 'Alexandre','326543457', '73556944057', '11987656543', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200')
					,(6, '10/10/1978', 'Fernando','546365253', '16839338002', '11972084453', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200')
					,(7, '13/10/1985', 'Henrique','543663625', '14332654765', '1134566543', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030')
					,(8, '27/08/1975', 'João','325444441', '91305348010', '1176566377', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380')
					,(9, '21/03/1972', 'Bruno','545662667', '79799299004', '11954368769', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001')
					,(10, '05/03/2018','Mariana','545662668', '13771913039', null, 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
go

insert into situacao (situacao)
values				 ('Realizada')
					,('Cancelada')
					,('Agendada');
go

insert into consulta (idMedico, idPaciente, idSituacao, dataConsulta, descricao)
values				 (3, 7, 1, '14/04/2021', 'Criança com catarro na garganta')
					,(2, 2, 2, '28/03/2021', 'Paciente com falta de confiança em si mesmo')
					,(2, 3, 1, '29/03/2021', 'Paciente com depressão severa')
					,(2, 2, 1, '08/04/2021', 'Paciente com boderline')
					,(1, 4, 2, '21/05/2021', 'Paciente verificando se tem alergia a anestesia utilizada na cirurgia')
					,(3, 7, 3, '30/03/2021', 'Criança com dor de bronquilote')
					,(1, 4, 3, '06/04/2021', 'Paciente com parestesia');
go