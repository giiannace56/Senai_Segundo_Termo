--DML
USE Medical_Group
GO

INSERT INTO tipoUsuario (nomeTipoUsuario)
VALUES					('Administrador')
					   ,('Paciente')
					   ,('Médico')
GO

INSERT INTO usuario		(idTipoUsuario, email, senha)
VALUES				    (1, 'cxrgo@email.com', 'amargo123')
					   ,(3, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardo123')
					   ,(3, 'roberto.possarle@spmedicalgroup.com.br', 'robert123')
					   ,(3, 'helena.souza@spmedicalgroup.com.br', 'helena123')
					   ,(2, 'ligia@gmail.com', 'ligia123')  
					   ,(2, 'alexandre@gmail.com', 'alexandre123')  
					   ,(2, 'fernando@gmail.com', 'fernando123')  
					   ,(2, 'henrique@gmail.com', 'henrique123')  
					   ,(2, 'joao@hotmail.com', 'joao123')  
					   ,(2, 'bruno@gmail.com', 'bruno123')  
					   ,(2, 'mariana@outlook.com', 'mariana123')  
GO

INSERT INTO clinica		(cnpj, rua, numero, bairro, cidade, estado, nomeFantasia, razaoSocial)
VALUES					('86400902000130', 'Av. Barão Limeira', 532, 'Campos Elíseos', 'São Paulo', 'SP', 'Clinica Possarle', 'SP Medical Group')
GO

INSERT INTO especialidade	(nomeEspecialidade)
VALUES						('Acunpuntura')
						   ,('Anestesiologia')
						   ,('Angiologia')
						   ,('Cardiologia')
						   ,('Cirurgia Cardiovascular')
						   ,('Cirurgia da Mão')
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
						   ,('Psiquiatria')
GO

INSERT INTO medico		(idUsuario, idEspecialidade, idClinica, CRM, nomeMedico)
VALUES					(2, 2, 1, 54356, 'Ricardo Lemos')
					   ,(3, 17, 1, 53452, 'Roberto Possarle')
					   ,(4, 16, 1, 65463, 'Helena Strada')
GO

INSERT INTO situacao	(situacao)
VALUES					('Agendada')
					   ,('Realizada')
					   ,('Cancelada')
GO

INSERT INTO paciente	(idUsuario, nomePaciente, RG, CPF, rua, numero, bairro, cidade, estado, cep, dataNascimento, telefone)
VALUES					(5, 'Ligia', '435225435', '94839859000', 'Estado de Israel', 240, 'Vila Clementino', 'São Paulo', 'SP','04022000', '13/10/1983', '1134567654')
					   ,(6, 'Alexandre', '326543457', '73556944057', 'Av. Paulista', 1578, 'Bela Vista','São Paulo', 'SP', '01310200', '23/07/2001', '11987656543')
					   ,(7, 'Fernando', '546365253', '16839338002', 'Av. Ibirapuera', 2927, 'Indianópolis', 'São Paulo', 'SP', '04029200','10/10/1978', '11972084453')
					   ,(8, 'Henrique', '543663625', '14332654765', 'R. Vitória', 120, 'Vila São Jorge', 'Barueri', 'SP', '06402030', '13/10/1985', '1134566543')
					   ,(9, 'João', '325444441', '91305348010', 'R. Ver. Geraldo de Camargo', 66, 'Santa Luzia', 'Ribeirão Pires', 'SP', '09405380', '27/08/1975', '1176566377')
					   ,(10, 'Bruno', '545662667', '79799299004', 'Alameda dos Arapanés', 945, 'Indianópolis', 'São Paulo', 'SP', '04524001', '21/03/1972', '11954368769')

INSERT INTO paciente   (idUsuario, nomePaciente, RG, CPF, rua, numero, bairro, cidade, estado, cep, dataNascimento)
VALUES				   (11, 'Mariana', '545662668', '13771913039', 'R. São Antonio', 232, 'Vila Universal', 'Barueri', 'SP', '06407140', '5/3/2018')

GO

INSERT INTO consulta	(idMedico, idPaciente, idSituacao, dataConsulta)
VALUES					(3, 7, 2, '20/01/2020')
					   ,(2, 8, 3, '06/01/2020')
					   ,(2, 9, 2, '07/02/2020')
					   ,(2, 10, 2, '06/02/2018')
					   ,(1, 11, 3, '07/02/2019')
					   ,(3, 12, 1, '08/03/2020')
					   ,(1, 13, 1, '09/03/2020')

GO