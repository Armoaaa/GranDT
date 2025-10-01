DELIMITER //
CREATE TRIGGER befInsTipo
BEFORE INSERT ON Tipo
FOR EACH ROW
BEGIN
    IF NEW.nombre NOT IN ('Arquero','Defensor','Mediocampista','Delantero') THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Tipo de jugador inválido';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER befInsFutbolista
BEFORE INSERT ON Futbolista
FOR EACH ROW
BEGIN
    IF NEW.cotizacion < 0 OR NEW.cotizacion > 99999999.99 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cotización fuera de rango permitido';
    END IF;

    IF (SELECT COUNT(*) FROM Futbolista) >= 1500 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se pueden cargar más de 1500 futbolistas';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER befInsUsuario
BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN


    IF (SELECT COUNT(*) FROM Usuario) >= 2000 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se pueden cargar más de 2000 usuarios';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER befInsPlantilla
BEFORE INSERT ON Plantillas
FOR EACH ROW
BEGIN
    IF NEW.presupuesto > 100000000 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Presupuesto excede el máximo permitido';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER befInsTitularChk
BEFORE INSERT ON PlantillaTitular
FOR EACH ROW
BEGIN
    IF EXISTS (
        SELECT 1 FROM PlantillaSuplente
        WHERE idFutbolista = NEW.idFutbolista
          AND idPlantillas = NEW.idPlantillas
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya está en esa plantilla como suplente';
    END IF;

    IF (
        SELECT COUNT(*) FROM (
            SELECT idFutbolista FROM PlantillaTitular WHERE idPlantillas = NEW.idPlantillas
            UNION ALL
            SELECT idFutbolista FROM PlantillaSuplente WHERE idPlantillas = NEW.idPlantillas
        ) t
    ) >= 20 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se pueden tener más de 20 jugadores en la plantilla';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER befInsSuplenteChk
BEFORE INSERT ON PlantillaSuplente
FOR EACH ROW
BEGIN
    IF EXISTS (
        SELECT 1 FROM PlantillaTitular
        WHERE idFutbolista = NEW.idFutbolista
          AND idPlantillas = NEW.idPlantillas
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya está en esa plantilla como titular';
    END IF;

    IF (
        SELECT COUNT(*) FROM (
            SELECT idFutbolista FROM PlantillaTitular WHERE idPlantillas = NEW.idPlantillas
            UNION ALL
            SELECT idFutbolista FROM PlantillaSuplente WHERE idPlantillas = NEW.idPlantillas
        ) t
    ) >= 20 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se pueden tener más de 20 jugadores en la plantilla';
    END IF;
END;
//
DELIMITER ;

DELIMITER //
CREATE TRIGGER befInsPuntuacionChk
BEFORE INSERT ON Puntuacion
FOR EACH ROW
BEGIN
    IF NEW.fechaNro >= 50 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Número de fecha inválido (debe ser < 50)';
    END IF;

    IF NEW.puntuacion < 1 OR NEW.puntuacion > 10 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La puntuación debe estar entre 1 y 10';
    END IF;

    IF EXISTS (
        SELECT 1 FROM Puntuacion
        WHERE idFutbolista = NEW.idFutbolista
          AND fechaNro = NEW.fechaNro
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El jugador ya tiene puntuación en esa fecha';
    END IF;
END;
//
DELIMITER ;
DELIMITER //
CREATE TRIGGER befInsEquipo
BEFORE INSERT ON Equipos
FOR EACH ROW
BEGIN
    IF (SELECT COUNT(*) FROM Equipos) >= 32 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se pueden cargar más de 32 equipos';
    END IF;
END;
//
DELIMITER ;

