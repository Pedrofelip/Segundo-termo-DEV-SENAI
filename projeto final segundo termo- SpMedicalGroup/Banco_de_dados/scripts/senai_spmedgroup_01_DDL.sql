CREATE DATABASE SpMedical;

GO

USE SpMedical;

GO

CREATE TABLE tipoUsuarios(
idTipoUsuario int primary key identity,
tipos varchar(150));

GO

CREATE TABLE situacoes(
idSituacao int primary key identity,
situacao varchar(150));

GO

CREATE TABLE clinicas(
idClinica int primary key identity,
nomeClinica varchar(150),
cnpj varchar(14),
razaoSocial varchar(150),
endereco varchar(150));

GO

CREATE TABLE especialidades(
idEspecialidade int primary key identity,
especialidade varchar(100));

GO

CREATE TABLE usuarios(
idUsuario int primary key identity,
idTipoUsuario int foreign key references tipoUsuarios(idTipoUsuario),
nome varchar(250),
rg varchar(9),
cpf varchar(11),
email varchar(250),
numeroTel varchar(50))

GO

CREATE TABLE medicos(
idMedico int primary key identity,
idUsuario int foreign key references usuarios(idUsuario),
idClinica int foreign key references clinicas(idClinica),
idEspecialidade int foreign key references especialidades(idEspecialidade),
crm varchar(10))

GO

CREATE TABLE pacientes(
idPaciente int primary key identity,
idUsuario int foreign key references usuarios(idUsuario),
dataNascimento date,
endereco varchar(150))

GO

CREATE TABLE agendamentos(
idAgendamento int primary key identity,
idSituacao int foreign key references situacoes(idSituacao) DEFAULT 2,
idPaciente int foreign key references pacientes(idPaciente),
idMedico int foreign key references medicos(idMedico),
dataConsulta datetime)

GO
--criando uma nova coluna
ALTER TABLE agendamentos
ADD descricao varchar(400)

ALTER TABLE usuarios
ADD senha varchar(50)