SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
CREATE DATABASE IF NOT EXISTS `PlaceMyBet` DEFAULT CHARACTER SET utf8 ;
USE `PlaceMyBet` ;

-- -----------------------------------------------------
-- Table `mydb`.`Evento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Evento` (
  `Local` VARCHAR(25) NOT NULL,
  `Visitante` VARCHAR(25) NOT NULL,
  `Fecha` DATETIME NOT NULL,
  `Id evento` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`Id evento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Mercado`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Mercado` (
  `over/under` DOUBLE NOT NULL,
  `cuota over` DOUBLE NOT NULL,
  `cuota under` DOUBLE NOT NULL,
  `dinero over` DOUBLE NOT NULL,
  `dinero under` DOUBLE NOT NULL,
  `Id evento` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`over/under`),
  CONSTRAINT `Id evento`
    FOREIGN KEY (`Id evento`)
    REFERENCES `PlaceMyBet`.`Evento` (`Id evento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `mydb`.`Banco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Banco` (
  `Saldo actual` INT NOT NULL,
  `Nombre banco` VARCHAR(25) NOT NULL,
  `nº tarjeta` VARCHAR(25) NOT NULL,
   `email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`nº tarjeta`),
  KEY idx_emailBanco (email))
ENGINE = InnoDB;

ALTER TABLE `PlaceMyBet`.`Banco`
ADD FOREIGN KEY (`email`) REFERENCES `PlaceMyBet`.`Usuario`(`email`);
-- -----------------------------------------------------
-- Table `mydb`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Usuario` (
  `Nombre` VARCHAR(25) NOT NULL,
  `Apellidos` VARCHAR(25) NOT NULL,
  `Edad` INT NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`email`))
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `mydb`.`Apuestas`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `PlaceMyBet`.`Apuestas` (
  `Id` INT NOT NULL,
  `email` VARCHAR(45) NOT NULL,
  `over/under` DOUBLE NOT NULL,
  `Tipo` VARCHAR(45) NOT NULL,
  `Dinero` INT NOT NULL,
  PRIMARY KEY (`Id`),
  CONSTRAINT `over/under`
    FOREIGN KEY (`over/under`)
    REFERENCES `PlaceMyBet`.`Mercado` (`over/under`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `email_apuestas`
    FOREIGN KEY (`email`)
    REFERENCES `PlaceMyBet`.`Usuario` (`email`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
