DELIMITER //
CREATE PROCEDURE altaEquipo(IN nombre_equipo VARCHAR(45))
BEGIN
    IF EXISTS (SELECT 1 FROM Equipos WHERE Nombre = nombre_equipo) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Equipo ya existe';
    END IF;
    INSERT INTO Equipos (Nombre) VALUES (nombre_equipo);
END;
//
DELIMITER ;
DELIMITER //
CREATE PROCEDURE altaTipo(IN nombre_tipo VARCHAR(50))
BEGIN
    DECLARE nuevoId INT;
    SELECT IFNULL(MAX(idTipo),0)+1 INTO nuevoId FROM Tipo;
    INSERT INTO Tipo (idTipo, Nombre) VALUES (nuevoId, nombre_tipo);
END;
//
DELIMITER ;
DELIMITER //
CREATE PROCEDURE altaFutbolista(
    IN Nombre VARCHAR(45),
    IN Apellido VARCHAR(45),
    IN Apodo VARCHAR(45),
    IN FechadeNacimiento DATE,
    IN Cotizacion DECIMAL(11,2),
    IN idEquipos_in INT,
    IN idTipo_in INT
)
BEGIN
    DECLARE nuevoId INT;
    -- Validar cotizacion positiva y no mayor al máximo esperado
    IF Cotizacion < 0 OR Cotizacion > 99999999.99 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cotizacion fuera de rango';
    END IF;

    -- Evitar duplicados (puedes cambiar la regla de duplicado si quisieras)
    IF EXISTS (
        SELECT 1 FROM Futbolista
        WHERE Nombre = Nombre AND Apellido = Apellido AND idEquipos = idEquipos_in
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Futbolista ya existe en ese equipo';
    END IF;

    SELECT IFNULL(MAX(idFutbolista),0)+1 INTO nuevoId FROM Futbolista;
    INSERT INTO Futbolista (idFutbolista, Nombre, Apellido, Apodo, FechadeNacimiento, Cotizacion, idEquipos, idTipo)
    VALUES (nuevoId, Nombre, Apellido, Apodo, FechadeNacimiento, Cotizacion, idEquipos_in, idTipo_in);
END;
//
DELIMITER ;
DELIMITER //
CREATE PROCEDURE altaUsuario(
    IN Nombre_u VARCHAR(45),
    IN Apellido_u VARCHAR(45),
    IN Email_u VARCHAR(90),
    IN FechadeNacimiento_u DATE,
    IN Contrasena CHAR(64),
    IN esAdmin_in DOUBLE,
    OUT idUsuario_generado INT
)
BEGIN
    IF EXISTS (SELECT 1 FROM Usuario WHERE Email = Email_u) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Email ya registrado';
    END IF;

    INSERT INTO Usuario (Nombre, Apellido, Email, FechadeNacimiento, Contraseña, esAdmin)
    VALUES (Nombre_u, Apellido_u, Email_u, FechadeNacimiento_u, Contrasena, esAdmin_in);

    SET idUsuario_generado = LAST_INSERT_ID();
END;
//
DELIMITER ;

DELIMITER //
CREATE PROCEDURE altaPlantilla(
    IN Presupuesto_in DECIMAL(11,2),
    IN NombrePlantilla_in VARCHAR(50),
    IN Usuario_idUsuario_in INT,
    IN CantidadJugadores_in TINYINT,
    OUT idPlantilla_generado INT
)
BEGIN
    DECLARE nuevoId INT;
    -- Evitar nombre duplicado
    IF EXISTS (SELECT 1 FROM Plantillas WHERE NombrePlantilla = NombrePlantilla_in) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Nombre de plantilla ya existe';
    END IF;

    SELECT IFNULL(MAX(idPlantillas),0)+1 INTO nuevoId FROM Plantillas;
    INSERT INTO Plantillas (idPlantillas, Presupuesto, NombrePlantilla, Usuario_idUsuario, CantidadJugadores)
    VALUES (nuevoId, Presupuesto_in, NombrePlantilla_in, Usuario_idUsuario_in, CantidadJugadores_in);

    SET idPlantilla_generado = nuevoId;
END;
//
DELIMITER ;
DELIMITER //
CREATE PROCEDURE agregarTitular(
    IN Futbolista_idFutbolista_in INT,
    IN Plantillas_idPlantillas_in INT
)
BEGIN
    -- verificar si ya existe en titulares
    IF EXISTS (
        SELECT 1 FROM PlantillaTitular
        WHERE Futbolista_idFutbolista = Futbolista_idFutbolista_in
          AND Plantillas_idPlantillas = Plantillas_idPlantillas_in
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya es titular en esa plantilla';
    END IF;

    -- verificar si ya está como suplente
    IF EXISTS (
        SELECT 1 FROM PlantillaSuplente
        WHERE Futbolista_idFutbolista = Futbolista_idFutbolista_in
          AND Plantillas_idPlantillas = Plantillas_idPlantillas_in
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya está en esa plantilla (suplente)';
    END IF;

    INSERT INTO PlantillaTitular (Futbolista_idFutbolista, Plantillas_idPlantillas, esTitular)
    VALUES (Futbolista_idFutbolista_in, Plantillas_idPlantillas_in, 1);
END;
//
DELIMITER ;

DELIMITER //
CREATE PROCEDURE altaPuntuacion(
    IN fechaNro_in TINYINT,
    IN Puntuacion_in DECIMAL(3,1),
    IN idFutbolista_in INT
)
BEGIN
	DECLARE nuevoIdP INT;
    -- Validaciones simples
    IF fechaNro_in < 1 OR fechaNro_in >= 50 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'fechaNro inválida';
    END IF;
    IF Puntuacion_in < 1 OR Puntuacion_in > 10 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Puntuacion fuera de rango';
    END IF;

    IF EXISTS (
        SELECT 1 FROM Puntuacion
        WHERE idFutbolista = idFutbolista_in
          AND fechaNro = fechaNro_in
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Ya existe puntuación para ese jugador y fecha';
    END IF;

    -- generar idPuntuacion como MAX+1
    
    SELECT IFNULL(MAX(idPuntuacion),0)+1 INTO nuevoIdP FROM Puntuacion;
    INSERT INTO Puntuacion (idPuntuacion, fechaNro, Puntuacion, idFutbolista)
    VALUES (nuevoIdP, fechaNro_in, Puntuacion_in, idFutbolista_in);
END;
//
DELIMITER ;
DELIMITER //
CREATE FUNCTION plantillaPuntajeFecha(idPlantillas_in INT, fechaNro_in TINYINT)
RETURNS DECIMAL(10,2)
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE total DECIMAL(10,2);
    SELECT IFNULL(SUM(p.Puntuacion),0) INTO total
    FROM PlantillaTitular pt
    JOIN Puntuacion p ON pt.Futbolista_idFutbolista = p.idFutbolista
    WHERE pt.Plantillas_idPlantillas = idPlantillas_in
      AND p.fechaNro = fechaNro_in;
    RETURN total;
END;
//
DELIMITER ;
DELIMITER //
CREATE FUNCTION plantillaValidaPresupuesto(idPlantillas_in INT)
RETURNS BOOLEAN
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE presupuesto DECIMAL(11,2);
    DECLARE sumaCot DECIMAL(15,2);

    SELECT Presupuesto INTO presupuesto
    FROM Plantillas
    WHERE idPlantillas = idPlantillas_in;

    SELECT IFNULL(SUM(f.Cotizacion),0) INTO sumaCot
    FROM (
      SELECT Futbolista_idFutbolista AS idF FROM PlantillaTitular WHERE Plantillas_idPlantillas = idPlantillas_in
      UNION
      SELECT Futbolista_idFutbolista AS idF FROM PlantillaSuplente WHERE Plantillas_idPlantillas = idPlantillas_in
    ) as conjuntos
    JOIN Futbolista f ON f.idFutbolista = conjuntos.idF;

    RETURN sumaCot <= presupuesto;
END;
//
DELIMITER ;
DELIMITER //
CREATE FUNCTION plantillaValidaFormacion(idPlantillas_in INT)
RETURNS BOOLEAN
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE arqueros INT DEFAULT 0;
    DECLARE defensores INT DEFAULT 0;
    DECLARE mediocampistas INT DEFAULT 0;
    DECLARE delanteros INT DEFAULT 0;

    SELECT
      SUM(CASE WHEN t.Nombre LIKE 'Arquero' THEN 1 ELSE 0 END),
      SUM(CASE WHEN t.Nombre LIKE 'Defensor' THEN 1 ELSE 0 END),
      SUM(CASE WHEN t.Nombre LIKE 'Mediocampista' THEN 1 ELSE 0 END),
      SUM(CASE WHEN t.Nombre LIKE 'Delantero' THEN 1 ELSE 0 END)
    INTO arqueros, defensores, mediocampistas, delanteros
    FROM PlantillaTitular pt
    JOIN Futbolista f ON pt.Futbolista_idFutbolista = f.idFutbolista
    JOIN Tipo t ON f.idTipo = t.idTipo
    WHERE pt.Plantillas_idPlantillas = idPlantillas_in;

    RETURN (arqueros = 1 AND defensores = 4 AND mediocampistas = 4 AND delanteros = 2);
END;
//
DELIMITER ;

DELIMITER //
CREATE FUNCTION plantillaEsValida(idPlantillas_in INT)
RETURNS BOOLEAN
DETERMINISTIC
READS SQL DATA
BEGIN
    DECLARE okFormacion BOOLEAN;
    DECLARE okPresupuesto BOOLEAN;

    SET okFormacion = plantillaValidaFormacion(idPlantillas_in);
    SET okPresupuesto = plantillaValidaPresupuesto(idPlantillas_in);

    RETURN (okFormacion AND okPresupuesto);
END;
//
DELIMITER ;
