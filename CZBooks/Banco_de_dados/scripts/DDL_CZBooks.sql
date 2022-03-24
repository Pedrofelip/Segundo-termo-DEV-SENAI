CREATE DATABASE CZBooks_manha;

USE CZBooks_manha;

GO

CREATE TABLE tipoUsuarios(
IdTipoUsuario int primary key identity,
tipoUsuario varchar(50))

GO

CREATE TABLE instituicoes(
IdInstituicao int primary key identity,
nomeInstituicao varchar(100),
CNPJ varchar(20),
razaoSocial varchar(100),
Endereco varchar(150))

GO

CREATE TABLE categorias(
Idcategoria int primary key identity,
categoria varchar(50))

GO

CREATE TABLE usuarios(
IdUsuario int primary key identity,
IdTipoUsuario int foreign key references tipoUsuarios(IdTipoUsuario),
nomeUsuario varchar(150),
RG varchar(20),
CPF varchar(20),
endereco varchar(150),
email varchar(100),
senha varchar(50))

GO

CREATE TABLE autores(
IdAutor int primary key identity,
IdUsuario int foreign key references usuarios(IdUsuario))

GO

CREATE TABLE livros(
IdLivro int primary key identity,
IdCategoria int foreign key references categorias(Idcategoria),
IdAutor int foreign key references autores(IdAutor),
IdInstituicao int foreign key references instituicoes(IdInstituicao),
titulo varchar(75),
sinopse varchar(250),
dataLancamento date,
preco decimal(18,2))