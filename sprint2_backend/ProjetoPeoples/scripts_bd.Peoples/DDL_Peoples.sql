CREATE DATABASE M_Peoples;

USE M_Peoples;

CREATE TABLE Funcionarios(
	idFuncionario int primary key identity,
	nome varchar(50),
	sobrenome varchar(50))