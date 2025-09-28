DELIMITER //
CREATE TRIGGER befInsTitular
BEFORE INSERT ON PlantillaTitular
FOR EACH ROW
BEGIN
    IF EXISTS (
        SELECT 1 FROM PlantillaSuplente
        WHERE Futbolista_idFutbolista = NEW.Futbolista_idFutbolista
          AND Plantillas_idPlantillas = NEW.Plantillas_idPlantillas
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya está en esa plantilla como suplente';
    END IF;
END;
//
DELIMITER ;
DELIMITER //
CREATE TRIGGER befInsSuplente
BEFORE INSERT ON PlantillaSuplente
FOR EACH ROW
BEGIN
    IF EXISTS (
        SELECT 1 FROM PlantillaTitular
        WHERE Futbolista_idFutbolista = NEW.Futbolista_idFutbolista
          AND Plantillas_idPlantillas = NEW.Plantillas_idPlantillas
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Jugador ya está en esa plantilla como titular';
    END IF;
END;
//
DELIMITER ;
DELIMITER //
CREATE TRIGGER befInsTitularLimite
BEFORE INSERT ON PlantillaTitular
FOR EACH ROW
BEGIN
    DECLARE maxJugadores INT;
    DECLARE actuales INT;

    SELECT CantidadJugadores INTO maxJugadores
    FROM Plantillas
    WHERE idPlantillas = NEW.Plantillas_idPlantillas;

    SELECT COUNT(*) INTO actuales
    FROM (
      SELECT Futbolista_idFutbolista FROM PlantillaTitular WHERE Plantillas_idPlantillas = NEW.Plantillas_idPlantillas
      UNION ALL
      SELECT Futbolista_idFutbolista FROM PlantillaSuplente WHERE Plantillas_idPlantillas = NEW.Plantillas_idPlantillas
    ) AS todos;

    IF actuales >= maxJugadores THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Se alcanzó la cantidad máxima de jugadores en esta plantilla';
    END IF;
END;
//
DELIMITER ;
DELIMITER //
CREATE TRIGGER befInsPuntuacion
BEFORE INSERT ON Puntuacion
FOR EACH ROW
BEGIN
    IF EXISTS (
        SELECT 1 FROM Puntuacion
        WHERE idFutbolista = NEW.idFutbolista
          AND fechaNro = NEW.fechaNro
    ) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Ya existe puntuación para ese jugador y fecha';
    END IF;
END;
//
DELIMITER ;
DELIMITER //
CREATE TRIGGER befInsFutbolista
BEFORE INSERT ON Futbolista
FOR EACH ROW
BEGIN
    IF NEW.Cotizacion < 0 OR NEW.Cotizacion > 99999999.99 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Cotización fuera de rango permitido';
    END IF;
END;
//
DELIMITER ;
