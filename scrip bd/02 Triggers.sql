DELIMITER //
CREATE TRIGGER BITlimit
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
CREATE TRIGGER BIFlimit
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
CREATE TRIGGER BIUlimitecargado
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
CREATE TRIGGER BIUEncriptar
BEFORE UPDATE ON Usuario
FOR EACH ROW
BEGIN
    IF NEW.Contrasena <> OLD.Contrasena THEN
        SET NEW.Contrasena = SHA2(NEW.Contrasena, 256);
    END IF;
END;
//
DELIMITER ;
DELIMITER //
CREATE TRIGGER BIIEncriptar
BEFORE INSERT ON Usuario
FOR EACH ROW
BEGIN
    SET NEW.Contrasena = SHA2(NEW.Contrasena, 256);
END;

//
DELIMITER ;

DELIMITER //
CREATE TRIGGER BIPpresupuesto
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
CREATE TRIGGER BIPTlimit
BEFORE INSERT ON PlantillaTitular
FOR EACH ROW
BEGIN
    -- Validar que no se duplique el jugador dentro de la misma plantilla
    IF EXISTS (
        SELECT 1 FROM PlantillaTitular
        WHERE idFutbolista = NEW.idFutbolista
          AND idPlantillas = NEW.idPlantillas
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya está en esa plantilla';
    END IF;

    -- Validar que no se exceda el límite máximo de jugadores por plantilla
    IF (
        SELECT COUNT(*) FROM PlantillaTitular
        WHERE idPlantillas = NEW.idPlantillas
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
CREATE TRIGGER BIElimit
BEFORE INSERT ON Equipos
FOR EACH ROW
BEGIN
    IF (SELECT COUNT(*) FROM Equipos) >= 32 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se pueden cargar más de 32 equipos';
    END IF;
END;
//
DELIMITER ;


-- prueba de si el test respeta los triggers
-- DELIMITER //
-- 
-- CREATE TRIGGER `password123`
-- BEFORE INSERT ON `Usuario`
-- FOR EACH ROW
-- BEGIN
--     IF NEW.Contrasena = 'password123' THEN
--         SIGNAL SQLSTATE '45000'
--         SET MESSAGE_TEXT = 'La contraseña "password123" no está permitida por razones de seguridad. Por favor, elige una contraseña diferente.';
--     END IF;
-- END//
-- 
-- DELIMITER ;


