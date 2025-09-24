DROP SCHEMA GranDT;

CREATE SCHEMA IF NOT EXISTS `GranDT` ;
USE `GranDT` ;

-- -----------------------------------------------------
-- Table `GranDT`.`Equipos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Equipos` (
  `idEquipos` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEquipos`),
  UNIQUE INDEX `Nombre_UNIQUE` (`Nombre` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`Tipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Tipo` (
  `idTipo` INT NOT NULL,
  `Nombre` VARCHAR(50) NULL,
  PRIMARY KEY (`idTipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`Futbolista`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Futbolista` (
  `idFutbolista` INT NOT NULL,
  `Nombre` VARCHAR(45) NULL,
  `Apellido` VARCHAR(45) NULL,
  `Apodo` VARCHAR(45) NULL,
  `FechadeNacimiento` DATE NULL,
  `Cotizacion` DECIMAL NULL,
  `idEquipos` INT NOT NULL,
  `idTipo` INT NOT NULL,
  PRIMARY KEY (`idFutbolista`, `idEquipos`, `idTipo`),
  INDEX `fk_Futbolista_Equipos_idx` (`idEquipos` ASC) VISIBLE,
  INDEX `fk_Futbolista_Tipo1_idx` (`idTipo` ASC) VISIBLE,
  CONSTRAINT `fk_Futbolista_Equipos`
    FOREIGN KEY (`idEquipos`)
    REFERENCES `GranDT`.`Equipos` (`idEquipos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Futbolista_Tipo1`
    FOREIGN KEY (`idTipo`)
    REFERENCES `GranDT`.`Tipo` (`idTipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellido` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(90) NOT NULL,
  `FechadeNacimiento` DATE NULL,
  `Contraseña` VARCHAR(64) NOT NULL,
  `esAdmin` DOUBLE NULL COMMENT 'Prefiero poner solo un campo de esAdmin para la simplicidad y menos joins pero sacrificamos rendimiento',
  PRIMARY KEY (`idUsuario`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`Plantillas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Plantillas` (
  `idPlantillas` INT NOT NULL,
  `Presupuesto` DECIMAL NULL,
  `NombrePlantilla` VARCHAR(50) NULL,
  `Usuario_idUsuario` INT NOT NULL,
  `CantidadJugadores` TINYINT NULL,
  PRIMARY KEY (`idPlantillas`, `Usuario_idUsuario`),
  INDEX `fk_Plantillas_Usuario1_idx` (`Usuario_idUsuario` ASC) VISIBLE,
  UNIQUE INDEX `NombrePlantilla_UNIQUE` (`NombrePlantilla` ASC) VISIBLE,
  CONSTRAINT `fk_Plantillas_Usuario1`
    FOREIGN KEY (`Usuario_idUsuario`)
    REFERENCES `GranDT`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`PlantillaTitular`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`PlantillaTitular` (
  `Futbolista_idFutbolista` INT NOT NULL,
  `Plantillas_idPlantillas` INT NOT NULL,
  `esTitular` TINYINT NULL,
  PRIMARY KEY (`Futbolista_idFutbolista`, `Plantillas_idPlantillas`),
  INDEX `fk_PlantillaJugador_Plantillas1_idx` (`Plantillas_idPlantillas` ASC) VISIBLE,
  CONSTRAINT `fk_PlantillaJugador_Futbolista1`
    FOREIGN KEY (`Futbolista_idFutbolista`)
    REFERENCES `GranDT`.`Futbolista` (`idFutbolista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PlantillaJugador_Plantillas1`
    FOREIGN KEY (`Plantillas_idPlantillas`)
    REFERENCES `GranDT`.`Plantillas` (`idPlantillas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Puntuacion` (
  `idPuntuacion` INT NOT NULL,
  `fechaNro` TINYINT NOT NULL,
  `Puntuacion` DECIMAL NULL,
  `idFutbolista` INT NOT NULL,
  PRIMARY KEY (`idPuntuacion`, `idFutbolista`),
  INDEX `fk_Puntuacion_Futbolista1_idx` (`idFutbolista` ASC) VISIBLE,
  CONSTRAINT `fk_Puntuacion_Futbolista1`
    FOREIGN KEY (`idFutbolista`)
    REFERENCES `GranDT`.`Futbolista` (`idFutbolista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `GranDT`.`PlantillaSuplente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`PlantillaSuplente` (
  `Futbolista_idFutbolista` INT NOT NULL,
  `Plantillas_idPlantillas` INT NOT NULL,
  `esSuplente` TINYINT NULL,
  PRIMARY KEY (`Futbolista_idFutbolista`, `Plantillas_idPlantillas`),
  INDEX `fk_PlantillaJugador_Plantillas1_idx` (`Plantillas_idPlantillas` ASC) VISIBLE,
  CONSTRAINT `fk_PlantillaJugador_Futbolista10`
    FOREIGN KEY (`Futbolista_idFutbolista`)
    REFERENCES `GranDT`.`Futbolista` (`idFutbolista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PlantillaJugador_Plantillas10`
    FOREIGN KEY (`Plantillas_idPlantillas`)
    REFERENCES `GranDT`.`Plantillas` (`idPlantillas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;