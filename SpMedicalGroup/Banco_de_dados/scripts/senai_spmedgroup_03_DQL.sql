USE SpMedical;


--Lista todos os tipos de usuários
SELECT * FROM tipoUsuarios;

--Lista todos os usuários
SELECT * FROM usuarios;

--Lista todas as clinicas
SELECT * FROM clinicas;

--Lista todas as especialidades
SELECT * FROM especialidades;

--Lista todos os médicos
SELECT * FROM medicos;

--Lista todos os pacientes
SELECT * FROM pacientes;

--Lista todas as consultas
SELECT * FROM Agendamentos;

--mostra a quantidade de usuarios
SELECT COUNT(*) FROM usuarios;

--calcula a idade do paciente
SELECT idUsuario, dataNascimento, DATEDIFF(YY, dataNascimento, GETDATE()) as idade FROM pacientes

--mostra a quantidade de medicos de uma determinada especialidade
SELECT usuarios.idUsuario, medicos.idMedico, usuarios.nome, especialidades.especialidade
FROM medicos
INNER JOIN especialidades
ON medicos.idEspecialidade = especialidades.idEspecialidade
INNER JOIN usuarios
ON medicos.idUsuario = usuarios.idUsuario
WHERE medicos.idEspecialidade = 2;





