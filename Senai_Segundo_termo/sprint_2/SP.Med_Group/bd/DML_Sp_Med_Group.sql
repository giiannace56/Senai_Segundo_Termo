-- DML
USE Medical;

INSERT INTO tiposUsuarios(tituloTipoUsuario)
VALUES		('Administrador')
		   ,('Medico')
		   ,('Paciente');

INSERT INTO usuarios(idTiposUsuarios, email, senha)
VALUES		(2, 'ricardo.lemos@spmedicalgroup.com.br', 'lemos123') -- 01
		   ,(2, 'roberto.possarle@spmedicalgroup.com.br', 'possarle123') -- 02
		   ,(2, 'helena.souza@spmedicalgroup.com.br', 'helena123') -- 03
		   ,(3, 'ligia@gmail.com', 'ligia123') -- 04
		   ,(3, 'alexandre@gmail.com', 'alexandre123') -- 05
		   ,(3, 'fernando@gmail.com', 'fernando123') -- 06
		   ,(3, 'henrique@gmail.com', 'henrique123') -- 07
		   ,(3, 'joao@hotmail.com', 'joao123') -- 08
		   ,(3, 'bruno@gmail.com', 'bruno123') -- 09
		   ,(3, 'mariana@outlook.com', 'mariana123') -- 10

INSERT INTO paciente(idUsuario, dataNascimento, endereco, rg, cpf, telefone)
VALUES		(4, '13/10/1983', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000', '43522543-5', '94839859000', '11 3456-7654') -- 1
		   ,(5, '23/07/2001', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200', '32654345-7', '73556944057', '11 98765-6543') -- 2
		   ,(6, '10/10/1978', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200', '54636525-3', '16839338002', '11 97208-4453') -- 3
		   ,(7, '13/10/1985', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030', '54366362-5', '14332654765', '11 3456-6543') -- 4
		   ,(8, '27/08/1975', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380', '53254444-1', '91305348010', '11 7656-6377') -- 5
		   ,(9, '21/03/1972', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001', '54566266-7', '79799299004', '11 95436-8769') -- 6
		   ,(10, '05/03/2018', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140', '54566266-8', '13771913039', ''); -- 7

INSERT INTO especialidade(nomeEspecialidade)
VALUES		 ('Acupuntura') -- 01
			,('Anestesiologia') -- 02
			,('Angiologia') -- 03
			,('Cardiologia') -- 04
			,('Cirurgia Cardiovascular') -- 05
			,('Cirurgia da Mão') -- 06
			,('Cirurgia do Aparelho Digestivo') -- 07
			,('Cirurgia Geral') -- 08
			,('Cirurgia Pediátrica') -- 09
			,('Cirurgia Plástica') -- 10
			,('Cirurgia Torácica') -- 11
			,('Cirurgia Vascular') -- 12
			,('Dermatologia') -- 13
			,('Radioterapia') -- 14
			,('Urologia') -- 15
			,('Pediatria') -- 16
			,('Psiquiatria'); -- 17

INSERT INTO clinica(cnpj, endereco, nomeFantasia, razaoSocial)
VALUES		 ('86.400.902/0001-30', 'Av. Barão Limeira, 532, São Paulo, SP', 'Clinica Possarle', 'SP Medical Group');

INSERT INTO situacao(situacao)
VALUES		 ('Agendada')
			,('Realizada')
			,('Cancelada');

INSERT INTO medico(idUsuario, idEspecialidade, idClinica, crm)
VALUES		 (1, 2, 1, '54356-SP')
			,(2, 17, 1, '53452-SP')
			,(3, 16, 1, '65463-SP');

INSERT INTO consulta(idMedico, idPaciente, idSituacao, dataConsulta, horaConsulta, descricao)
VALUES		 (3, 7, 2, '20/01/2020', '15:00', '')
			,(2, 2, 3, '06/01/2020', '10:00', '')
			,(2, 3, 2, '07/02/2020', '11:00', '')
			,(2, 2, 2, '06/02/2018', '10:00', '')
			,(1, 4, 3, '07/02/2019', '11:00', '')
			,(3, 7, 1, '08/03/2020', '15:00', '')
			,(1, 4, 1, '09/03/2020', '11:00', '');