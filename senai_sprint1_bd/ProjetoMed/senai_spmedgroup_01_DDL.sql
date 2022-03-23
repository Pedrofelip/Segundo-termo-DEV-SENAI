CREATE DATABASE Sp_MedGroup
USE Sp_MedGroup

CREATE TABLE ClassesUsuarios(
IdClasseUsuario int primary key identity,
Classe varchar(200));

CREATE TABLE EspecialidadesMed(
IdEspecialidade int primary key identity,
Especialidade varchar(200));

CREATE TABLE Clinica(
IdClinica int primary key identity,
Nome varchar(200) not null,
CNPJ char(14) not null,
RazaoSocial varchar(200) not null,
Endereco varchar(300) not null);

CREATE TABLE Situacoes(
IdSituacao int primary key identity,
Situacao varchar(200));

CREATE TABLE Usuarios(
IdUsuario int primary key identity,
IdClasseUsuario int foreign key references ClassesUsuarios,
Nome varchar(200) not null,
RG char(9) not null,
CPF char(11) not null,
Email varchar(200) not null,
NumTelefone varchar(20));

CREATE TABLE Medicos(
IdMedico int primary key identity,
IdUsuario int foreign key references Usuarios,
IdClinica int foreign key references Clinica,
IdEspecialidade int foreign key references EspecialidadesMed,
Crm char(10) not null);

CREATE TABLE Pacientes(
IdPaciente int primary key identity,
IdUsuario int foreign key references Usuarios,
DataNascimento date,
Endereco varchar(300));

CREATE TABLE AgendaConsultas(
IdAgendamento int primary key identity,
IdSituacao int foreign key references Situacoes,
IdPaciente int foreign key references Pacientes,
IdMedico int foreign key references Medicos,
DataConsulta smalldatetime not null);



