USE Sp_MedGroup;

insert into ClassesUsuarios(Classe)
values ('Administrador'),('Médico'),('Paciente')

insert into EspecialidadesMed(Especialidade)
values ('Acupuntura'),('Anestesiologia'),('Angiologia'),('Cardiologia'),('Cirurgia Cardiovascular'),('Cirurgia da Mão'),
('Cirurgia da Mão'),('Cirurgia Geral'),('Cirurgia Pediátrica'),('Cirurgia Plástica'),('Cirurgia Torácica'),
('Cirurgia Vascular'),('Dermatologia'),('Radioterapia'),('Urologia'),('Pediatria'),('Psiquiatria')

insert into Clinica(Nome,CNPJ,RazaoSocial,Endereco)
values ('Clinica Possarle',86400902000130,'SP Medical Group','Av. Barão Limeira, 532, São Paulo, SP')

insert into Situacoes(Situacao)
values ('Agendado'),('Realizada'),('Cancelada')

insert into Usuarios(IdClasseUsuario,Nome,RG,CPF,Email,NumTelefone)
values (2,'Ricardo Lemos',333444555,11122233344,'ricardolemos@gmail.com', null),
	   (2,'Roberto Possarle',777888999,33344455588,'roberto@gmail.com', null),
	   (2,'Helena Strada',222333555,44488899977,'helena@gmail.com', null),
	   (3,'Ligia',435225435,94839859000,'ligia@gmail.com', 1134567654),
	   (3,'Alexandre',326543457,73556944057,'alexandre@gmail.com',11987656543),
	   (3,'Fernando',546365253,16839338002,'fernando@gmail.com',11972084453),
	   (3,'Henrique',543663625,14332654765,'henrique@gmail.com',1134566543),
	   (3,'João',325444441,91305348010,'joao@hotmail.com',1176566377),
	   (3,'Bruno',545662667,79799299004,'bruno@gmail.com',11954368769),
	   (3,'Mariana',545662668,13771913039,'mariana@outlook.com',null)

insert into Medicos(IdUsuario,IdClinica,IdEspecialidade,Crm)
values (1,1,2,'54356-SP'),
	   (2,1,17,'53452-SP'),
	   (3,1,16,'65463-SP')

insert into Pacientes(IdUsuario,DataNascimento,Endereco)
values (4,'13-10-1983','Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
	   (5,'23-7-2001','Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
	   (6,'10-10-1978','Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
	   (7,'13-10-1985','R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
	   (8,'27-8-1975','R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
	   (9,'21-3-1972','Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
	   (10,'5-3-2018','R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140')

insert into AgendaConsultas(IdSituacao,IdPaciente,IdMedico,DataConsulta)
values (2,10,3,'20-1-2020 15:30:00'),
	   (3,5,3, '1-6-2020 10:40:00'),
	   (2,6,2,'2-7-2020 11:10:00'),
	   (2,5,2,'2-6-2018 10:20:00'),
	   (3,7,1,'2-7-2019 11:50:00'),
	   (1,10,3,'3-8-2020 15:50:00'),
	   (1,7,1,'3-9-2020 11:30:00')