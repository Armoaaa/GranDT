DROP DATABASE IF EXISTS `Gran DT`;
CREATE SCHEMA IF NOT EXISTS `Gran DT` ;
USE `Gran DT` ;

-- -----------------------------------------------------
-- Table `Gran DT`.`Tipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`Tipo` (
  `idTipo` INT UNSIGNED NOT NULL,
  `Nombre` VARCHAR(50) NULL,
  PRIMARY KEY (`idTipo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`Equipos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`Equipos` (
  `idEquipos` INT NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEquipos`),
  UNIQUE INDEX `Nombre_UNIQUE` (`Nombre` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`Futbolista`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`Futbolista` (
  `idFutbolista` INT UNSIGNED NOT NULL,
  `Nombre` VARCHAR(45) NULL,
  `Apellido` VARCHAR(45) NULL,
  `Apodo` VARCHAR(45) NULL,
  `FechadeNacimiento` DATE NULL,
  `Cotizacion` DECIMAL UNSIGNED NULL,
  `idTipo` INT UNSIGNED NOT NULL,
  `Equipos_idEquipos` INT NOT NULL,
  PRIMARY KEY (`idFutbolista`, `idTipo`, `Equipos_idEquipos`),
  INDEX `fk_Futbolista_Tipo1_idx` (`idTipo` ASC) VISIBLE,
  INDEX `fk_Futbolista_Equipos1_idx` (`Equipos_idEquipos` ASC) VISIBLE,
  CONSTRAINT `fk_Futbolista_Tipo`
    FOREIGN KEY (`idTipo`)
    REFERENCES `Gran DT`.`Tipo` (`idTipo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Futbolista_Equipos1`
    FOREIGN KEY (`Equipos_idEquipos`)
    REFERENCES `Gran DT`.`Equipos` (`idEquipos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`Usuario` (
  `idUsuario` INT UNSIGNED NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellido` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(90) NOT NULL,
  `FechadeNacimiento` DATE NULL,
  `Contraseña` VARCHAR(64) NOT NULL,
  `esAdmin` TINYINT NULL COMMENT 'Prefiero poner solo un campo de esAdmin para la simplicidad y menos joins pero sacrificamos rendimiento',
  PRIMARY KEY (`idUsuario`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`Plantillas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`Plantillas` (
  `idPlantillas` INT UNSIGNED NOT NULL,
  `Presupuesto` DECIMAL NULL,
  `NombrePlantilla` VARCHAR(50) NULL,
  `idUsuario` INT UNSIGNED NOT NULL,
  `CantidadJugadores` TINYINT NULL,
  PRIMARY KEY (`idPlantillas`, `idUsuario`),
  INDEX `fk_Plantillas_Usuario1_idx` (`idUsuario` ASC) VISIBLE,
  UNIQUE INDEX `NombrePlantilla_UNIQUE` (`NombrePlantilla` ASC) VISIBLE,
  CONSTRAINT `fk_Plantillas_Usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `Gran DT`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`PlantillaTitular`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`PlantillaTitular` (
  `idFutbolista` INT UNSIGNED NOT NULL,
  `idPlantillas` INT UNSIGNED NOT NULL,
  `esTitular` TINYINT NULL,
  PRIMARY KEY (`idFutbolista`, `idPlantillas`),
  INDEX `fk_PlantillaJugador_Plantillas1_idx` (`idPlantillas` ASC) VISIBLE,
  CONSTRAINT `fk_PlantillaJugador_Futbolista1`
    FOREIGN KEY (`idFutbolista`)
    REFERENCES `Gran DT`.`Futbolista` (`idFutbolista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PlantillaJugador_Plantillas1`
    FOREIGN KEY (`idPlantillas`)
    REFERENCES `Gran DT`.`Plantillas` (`idPlantillas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`Puntuacion` (
  `idPuntuacion` INT UNSIGNED NOT NULL,
  `fechaNro` TINYINT NOT NULL,
  `Puntuacion` DECIMAL UNSIGNED NULL,
  `idFutbolista` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idPuntuacion`, `idFutbolista`),
  INDEX `fk_Puntuacion_Futbolista1_idx` (`idFutbolista` ASC) VISIBLE,
  CONSTRAINT `fk_Puntuacion_Futbolista1`
    FOREIGN KEY (`idFutbolista`)
    REFERENCES `Gran DT`.`Futbolista` (`idFutbolista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Gran DT`.`PlantillaSuplente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Gran DT`.`PlantillaSuplente` (
  `idFutbolista` INT UNSIGNED NOT NULL,
  `idPlantillas` INT UNSIGNED NOT NULL,
  `esSuplente` TINYINT NULL,
  PRIMARY KEY (`idFutbolista`, `idPlantillas`),
  INDEX `fk_PlantillaJugador_Plantillas1_idx` (`idPlantillas` ASC) VISIBLE,
  CONSTRAINT `fk_PlantillaJugador_Futbolista10`
    FOREIGN KEY (`idFutbolista`)
    REFERENCES `Gran DT`.`Futbolista` (`idFutbolista`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PlantillaJugador_Plantillas10`
    FOREIGN KEY (`idPlantillas`)
    REFERENCES `Gran DT`.`Plantillas` (`idPlantillas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

