-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema GranDT
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema GranDT
-- -----------------------------------------------------
DROP DATABASE IF EXISTS GranDT;

CREATE SCHEMA IF NOT EXISTS `GranDT` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `GranDT` ;

-- -----------------------------------------------------
-- Table `GranDT`.`Equipos`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Equipos` (
  `idEquipos` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEquipos`),
  UNIQUE INDEX `Nombre_UNIQUE` (`Nombre` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `GranDT`.`Tipo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Tipo` (
  `idTipo` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(50) NULL DEFAULT NULL,
  PRIMARY KEY (`idTipo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `GranDT`.`Futbolista`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Futbolista` (
  `idFutbolista` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NULL DEFAULT NULL,
  `Apellido` VARCHAR(45) NULL DEFAULT NULL,
  `Apodo` VARCHAR(45) NULL DEFAULT NULL,
  `FechadeNacimiento` DATE NULL DEFAULT NULL,
  `Cotizacion` DECIMAL(10,0) NULL DEFAULT NULL,
  `idTipo` INT UNSIGNED NOT NULL,
  `idEquipos` INT NOT NULL,
  PRIMARY KEY (`idFutbolista`, `idTipo`, `idEquipos`),
  INDEX `fk_Futbolista_Tipo1_idx` (`idTipo` ASC) VISIBLE,
  INDEX `fk_Futbolista_Equipos1_idx` (`idEquipos` ASC) VISIBLE,
  CONSTRAINT `fk_Futbolista_Equipos1`
    FOREIGN KEY (`idEquipos`)
    REFERENCES `GranDT`.`Equipos` (`idEquipos`),
  CONSTRAINT `fk_Futbolista_Tipo`
    FOREIGN KEY (`idTipo`)
    REFERENCES `GranDT`.`Tipo` (`idTipo`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `GranDT`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Usuario` (
  `idUsuario` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(45) NOT NULL,
  `Apellido` VARCHAR(45) NOT NULL,
  `Email` VARCHAR(90) NOT NULL,
  `FechadeNacimiento` DATE NULL DEFAULT NULL,
  `Contrasena` VARCHAR(64) NOT NULL,
  `esAdmin` TINYINT NULL DEFAULT NULL COMMENT 'Prefiero poner solo un campo de esAdmin para la simplicidad y menos joins pero sacrificamos rendimiento',
  PRIMARY KEY (`idUsuario`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `GranDT`.`Plantillas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Plantillas` (
  `idPlantillas` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `Presupuesto` DECIMAL(10,0) NULL DEFAULT NULL,
  `NombrePlantilla` VARCHAR(50) NULL DEFAULT NULL,
  `idUsuario` INT UNSIGNED NOT NULL,
  `CantidadJugadores` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`idPlantillas`, `idUsuario`),
  UNIQUE INDEX `NombrePlantilla_UNIQUE` (`NombrePlantilla` ASC) VISIBLE,
  INDEX `fk_Plantillas_Usuario1_idx` (`idUsuario` ASC) VISIBLE,
  CONSTRAINT `fk_Plantillas_Usuario1`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `GranDT`.`Usuario` (`idUsuario`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `GranDT`.`PlantillaTitular`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`PlantillaTitular` (
  `idFutbolista` INT UNSIGNED NOT NULL,
  `idPlantillas` INT UNSIGNED NOT NULL,
  `esTitular` TINYINT NULL DEFAULT NULL,
  PRIMARY KEY (`idFutbolista`, `idPlantillas`),
  INDEX `fk_PlantillaJugador_Plantillas1_idx` (`idPlantillas` ASC) VISIBLE,
  CONSTRAINT `fk_PlantillaJugador_Futbolista1`
    FOREIGN KEY (`idFutbolista`)
    REFERENCES `GranDT`.`Futbolista` (`idFutbolista`),
  CONSTRAINT `fk_PlantillaJugador_Plantillas1`
    FOREIGN KEY (`idPlantillas`)
    REFERENCES `GranDT`.`Plantillas` (`idPlantillas`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `GranDT`.`Puntuacion`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `GranDT`.`Puntuacion` (
  `idPuntuacion` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `fechaNro` TINYINT NOT NULL,
  `Puntuacion` DECIMAL(10,0) NULL DEFAULT NULL,
  `idFutbolista` INT UNSIGNED NOT NULL,
  PRIMARY KEY (`idPuntuacion`, `idFutbolista`),
  INDEX `fk_Puntuacion_Futbolista1_idx` (`idFutbolista` ASC) VISIBLE,
  CONSTRAINT `fk_Puntuacion_Futbolista1`
    FOREIGN KEY (`idFutbolista`)
    REFERENCES `GranDT`.`Futbolista` (`idFutbolista`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
