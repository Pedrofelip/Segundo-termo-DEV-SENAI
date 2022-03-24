USE CZBooks_manha;

SELECT * FROM tipoUsuarios;

SELECT * FROM instituicoes;

SELECT * FROM categorias;

SELECT * FROM usuarios;

SELECT * FROM autores;

SELECT * FROM livros;

SELECT * FROM autores
INNER JOIN livros
ON livros.IdAutor = autores.IdAutor

