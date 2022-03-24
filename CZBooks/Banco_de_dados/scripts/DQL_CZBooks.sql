USE CZBooks_manha;

INSERT INTO tipoUsuarios(tipoUsuario)
VALUES ('Administrador'),
	   ('Cliente'),
	   ('Autor')

INSERT INTO instituicoes(nomeInstituicao,CNPJ,razaoSocial,Endereco)
VALUES ('CZBooks','11111222223333','CZBooks','Rua Felipe Bandeira, 142')

INSERT INTO categorias(categoria)
VALUES ('Ação'),
	   ('Romance'),
	   ('Aventura'),
	   ('Drama')

INSERT INTO usuarios(IdTipoUsuario,nomeUsuario,RG,CPF,endereco,email,senha)
VALUES (1,'Pedro Felipe','465789123456','11122233344','Avenida Jose Maria Fernandes, 480','adm@adm.com','12345'),
	   (2,'Marilene Barros','777888999444','44455566677','Av. Guilherme Coathing, 280','cliente@cliente.com','12345'),
	   (3,'Gabriele Viveiros','888999777444','78945612378','Rua Carlito, 415','autor@autor.com','12345')

INSERT INTO autores(IdUsuario)
VALUES (3)

INSERT INTO livros(IdCategoria,IdAutor,IdInstituicao,titulo,sinopse,dataLancamento,preco)
VALUES (1,1,1,'Muito rapido e Bravos','Apaixonado por carros um grupo de amigos se mete em varias ciladas','26-12-2019',19.00),
	   (2,1,1,'O lado bom da vida','Um livro sobre como a vida pode ser linda ao lado de quem nos amamos','24-11-2019',50.00)