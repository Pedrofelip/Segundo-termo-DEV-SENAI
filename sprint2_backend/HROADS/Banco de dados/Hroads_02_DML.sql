USE SENAI_HROADS_MANHA;

INSERT INTO Personagens (Nome, MaxVida,MaxMana, DataAtualizacao, DataCriacao, IdClasse)
VALUES ('DeuBug', 100, 80, '03/03/2021', '18/01/2019', 1),
	   ('BitBug', 70, 100, '03/03/2021', '17/03/2016', 4),
	   ('Fer8', 75, 60, '03/03/2021', '18/03/2018', 7);

INSERT INTO Classes (Nome)
VALUES ('Bárbaro'),
	   ('Cruzado'),
	   ('Caçadora de Demônios'),
	   ('Monge'),
	   ('Necromante'),
	   ('Feiticeiro'),
	   ('Arcanista');

INSERT INTO ClasseHabilidades (IdClasse, IdHabilidade)
VALUES (1, 1),
	   (1, 2),
	   (2, 2),
	   (3, 1),
	   (4, 3),
	   (4, 2),
	   (5, null),
	   (6, 3),
	   (7, null);

INSERT INTO Habilidades (Nome, IdTipo)
VALUES ('Lança Mortal', 1),
	   ('Escudo do Supremo', 2),
	   ('Recuperar Vida', 3);

INSERT INTO TiposDeHabilidades (Nome)
VALUES ('Ataque'),
	   ('Defesa'),
	   ('Cura'),
	   ('Magia');


--Tarefa (4)
UPDATE Personagens
SET Nome = 'Fer7'
WHERE IdPersonagem = 3;

--Tarefa (5)
UPDATE Classes
SET Nome = 'Necromancer'
WHERE IdClasse = 5;