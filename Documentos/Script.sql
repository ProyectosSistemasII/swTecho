SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP SCHEMA IF EXISTS `mydb` ;
CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci ;
USE `mydb` ;

-- -----------------------------------------------------
-- Table `Presentacion`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Presentacion` ;

CREATE TABLE IF NOT EXISTS `Presentacion` (
  `idPresentacion` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  PRIMARY KEY (`idPresentacion`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Alimentos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Alimentos` ;

CREATE TABLE IF NOT EXISTS `Alimentos` (
  `idAlimentos` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(100) NOT NULL,
  `Existencia` INT NOT NULL,
  `Rango` VARCHAR(100) NOT NULL,
  `AnioCaducidad` INT NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  `Presentacion_idPresentacion` INT NOT NULL,
  PRIMARY KEY (`idAlimentos`),
  INDEX `fk_Alimentos_Presentacion1_idx` (`Presentacion_idPresentacion` ASC),
  CONSTRAINT `fk_Alimentos_Presentacion1`
    FOREIGN KEY (`Presentacion_idPresentacion`)
    REFERENCES `Presentacion` (`idPresentacion`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Herramientas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Herramientas` ;

CREATE TABLE IF NOT EXISTS `Herramientas` (
  `idHerramientas` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(100) NOT NULL,
  `Existencia` INT NOT NULL,
  `CantidadBuenEstado` INT NULL DEFAULT 0,
  `CantidadMalEstado` INT NULL DEFAULT 0,
  `CantidadPerdida` INT NULL DEFAULT 0,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  PRIMARY KEY (`idHerramientas`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Departamento`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Departamento` ;

CREATE TABLE IF NOT EXISTS `Departamento` (
  `idDepartamento` INT NOT NULL AUTO_INCREMENT,
  `NombreD` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idDepartamento`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Municipio`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Municipio` ;

CREATE TABLE IF NOT EXISTS `Municipio` (
  `idMunicipio` INT NOT NULL AUTO_INCREMENT,
  `NombreM` VARCHAR(100) NOT NULL,
  `Departamento_idDepartamento` INT NOT NULL,
  PRIMARY KEY (`idMunicipio`),
  INDEX `fk_Municipio_Departamento1_idx` (`Departamento_idDepartamento` ASC),
  CONSTRAINT `fk_Municipio_Departamento1`
    FOREIGN KEY (`Departamento_idDepartamento`)
    REFERENCES `Departamento` (`idDepartamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Voluntarios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Voluntarios` ;

CREATE TABLE IF NOT EXISTS `Voluntarios` (
  `idVoluntarios` INT NOT NULL AUTO_INCREMENT,
  `Nombres` VARCHAR(100) NOT NULL,
  `Apellidos` VARCHAR(100) NOT NULL,
  `Telefono` VARCHAR(100) NOT NULL,
  `Direccion` VARCHAR(255) NULL,
  `Correo` VARCHAR(100) NOT NULL,
  `Activo` TINYINT(1) NULL,
  `Departamento_idDepartamento` INT NOT NULL,
  `Municipio_idMunicipio` INT NOT NULL,
  `PersonaEmergencia` VARCHAR(100) NULL,
  `TelEmergencia` VARCHAR(100) NULL,
  `Universidad` VARCHAR(100) NULL,
  PRIMARY KEY (`idVoluntarios`),
  INDEX `fk_Voluntarios_Departamento1` (`Departamento_idDepartamento` ASC),
  INDEX `fk_Voluntarios_Municipio1` (`Municipio_idMunicipio` ASC),
  CONSTRAINT `fk_Voluntarios_Departamento1`
    FOREIGN KEY (`Departamento_idDepartamento`)
    REFERENCES `Departamento` (`idDepartamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Voluntarios_Municipio1`
    FOREIGN KEY (`Municipio_idMunicipio`)
    REFERENCES `Municipio` (`idMunicipio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `TipoUsuarios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `TipoUsuarios` ;

CREATE TABLE IF NOT EXISTS `TipoUsuarios` (
  `idTipoUsuarios` INT NOT NULL AUTO_INCREMENT,
  `NombreTipo` VARCHAR(20) NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT '1',
  PRIMARY KEY (`idTipoUsuarios`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Usuarios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Usuarios` ;

CREATE TABLE IF NOT EXISTS `Usuarios` (
  `idUsuarios` INT NOT NULL AUTO_INCREMENT,
  `UserName` VARCHAR(100) NOT NULL,
  `Password` VARCHAR(255) NOT NULL,
  `TipoUsuarios_idTipoUsuarios` INT NOT NULL,
  `Voluntarios_idVoluntarios` INT NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  `PreguntaSecreta` VARCHAR(200) NOT NULL,
  `Respuesta` VARCHAR(200) NOT NULL,
  PRIMARY KEY (`idUsuarios`),
  INDEX `fk_Usuarios_TipoUsuarios1_idx` (`TipoUsuarios_idTipoUsuarios` ASC),
  INDEX `fk_Usuarios_Voluntarios1_idx` (`Voluntarios_idVoluntarios` ASC),
  CONSTRAINT `fk_Usuarios_TipoUsuarios1`
    FOREIGN KEY (`TipoUsuarios_idTipoUsuarios`)
    REFERENCES `TipoUsuarios` (`idTipoUsuarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuarios_Voluntarios1`
    FOREIGN KEY (`Voluntarios_idVoluntarios`)
    REFERENCES `Voluntarios` (`idVoluntarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Comunidad`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Comunidad` ;

CREATE TABLE IF NOT EXISTS `Comunidad` (
  `idComunidad` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(255) NULL,
  `Activo` TINYINT(1) NULL,
  `Departamento_idDepartamento` INT NOT NULL,
  `Municipio_idMunicipio` INT NOT NULL,
  PRIMARY KEY (`idComunidad`),
  INDEX `fk_Comunidad_Departamento1` (`Departamento_idDepartamento` ASC),
  INDEX `fk_Comunidad_Municipio1` (`Municipio_idMunicipio` ASC),
  CONSTRAINT `fk_Comunidad_Departamento1`
    FOREIGN KEY (`Departamento_idDepartamento`)
    REFERENCES `Departamento` (`idDepartamento`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Comunidad_Municipio1`
    FOREIGN KEY (`Municipio_idMunicipio`)
    REFERENCES `Municipio` (`idMunicipio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Encuestas`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Encuestas` ;

CREATE TABLE IF NOT EXISTS `Encuestas` (
  `idEncuestas` INT NOT NULL AUTO_INCREMENT,
  `CodigoHogar` VARCHAR(20) NOT NULL,
  `Voluntarios_idVoluntarios` INT NOT NULL,
  `Voluntarios_idVoluntarios1` INT NULL,
  `FechaEncuesta` VARCHAR(20) NULL,
  `HoraInicio` VARCHAR(20) NULL,
  `HoraFin` VARCHAR(20) NULL,
  `DatosEncuestado` VARCHAR(255) NULL,
  `EstadoEncuesta` VARCHAR(45) NOT NULL,
  `ObservacionesEstado` VARCHAR(255) NULL,
  `AldeaRuralNoZonaUrbana` VARCHAR(45) NULL,
  `CantonCaserioSector` VARCHAR(45) NULL,
  `XGPS` VARCHAR(45) NULL DEFAULT 0,
  `YGPS` VARCHAR(45) NULL DEFAULT 0,
  `JefeFamilia` VARCHAR(255) NULL,
  `PrimerTelefono` VARCHAR(20) NULL,
  `SegundoTelefono` VARCHAR(20) NULL,
  `Direccion` VARCHAR(100) NULL,
  `Especificaciones` VARCHAR(255) NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  `Comunidad_idComunidad` INT NOT NULL,
  PRIMARY KEY (`idEncuestas`),
  INDEX `fk_Encuestas_Voluntarios1_idx` (`Voluntarios_idVoluntarios` ASC),
  INDEX `fk_Encuestas_Comunidad1` (`Comunidad_idComunidad` ASC),
  INDEX `fk_Encuestas_Voluntarios2` (`Voluntarios_idVoluntarios1` ASC),
  CONSTRAINT `fk_Encuestas_Voluntarios1`
    FOREIGN KEY (`Voluntarios_idVoluntarios`)
    REFERENCES `Voluntarios` (`idVoluntarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Encuestas_Comunidad1`
    FOREIGN KEY (`Comunidad_idComunidad`)
    REFERENCES `Comunidad` (`idComunidad`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Encuestas_Voluntarios2`
    FOREIGN KEY (`Voluntarios_idVoluntarios1`)
    REFERENCES `Voluntarios` (`idVoluntarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Salida`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Salida` ;

CREATE TABLE IF NOT EXISTS `Salida` (
  `idSalida` INT NOT NULL AUTO_INCREMENT,
  `FechaSalida` DATE NOT NULL,
  `Usuarios_idUsuarios` INT NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  `Descripcion` VARCHAR(255) NULL,
  `Voluntarios_idVoluntarios` INT NOT NULL,
  PRIMARY KEY (`idSalida`),
  INDEX `fk_SalidaAlimentos_Usuarios1_idx` (`Usuarios_idUsuarios` ASC),
  INDEX `fk_Salida_Voluntarios1_idx` (`Voluntarios_idVoluntarios` ASC),
  CONSTRAINT `fk_SalidaAlimentos_Usuarios1`
    FOREIGN KEY (`Usuarios_idUsuarios`)
    REFERENCES `Usuarios` (`idUsuarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Salida_Voluntarios1`
    FOREIGN KEY (`Voluntarios_idVoluntarios`)
    REFERENCES `Voluntarios` (`idVoluntarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Prestamo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Prestamo` ;

CREATE TABLE IF NOT EXISTS `Prestamo` (
  `idPrestamo` INT NOT NULL AUTO_INCREMENT,
  `Usuarios_idUsuarios` INT NOT NULL,
  `Voluntarios_idVoluntarios` INT NOT NULL,
  `FechaPrestamo` DATE NULL,
  `Observaciones` VARCHAR(255) NULL,
  `Activo` INT NULL DEFAULT 1,
  `FechaFinPrestamo` DATE NULL,
  PRIMARY KEY (`idPrestamo`),
  INDEX `fk_DetallePrestamo_Voluntarios_idx` (`Voluntarios_idVoluntarios` ASC),
  INDEX `fk_Prestamo_Usuarios1_idx` (`Usuarios_idUsuarios` ASC),
  CONSTRAINT `fk_DetallePrestamo_Voluntarios`
    FOREIGN KEY (`Voluntarios_idVoluntarios`)
    REFERENCES `Voluntarios` (`idVoluntarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Prestamo_Usuarios1`
    FOREIGN KEY (`Usuarios_idUsuarios`)
    REFERENCES `Usuarios` (`idUsuarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S1_Integr`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S1_Integr` ;

CREATE TABLE IF NOT EXISTS `S1_Integr` (
  `idS1_Integr` INT NOT NULL AUTO_INCREMENT,
  `CodigoS1` INT NULL,
  `NombreCompleto` VARCHAR(100) NULL,
  `ApellidosCompleto` VARCHAR(100) NULL,
  `FechaNac` VARCHAR(30) NULL,
  `Genero` VARCHAR(20) NULL,
  `Embarazo` VARCHAR(20) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  PRIMARY KEY (`idS1_Integr`),
  INDEX `fk_S1_Integr_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S1_Integr_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S2_Dem`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S2_Dem` ;

CREATE TABLE IF NOT EXISTS `S2_Dem` (
  `idS2_Dem` INT NOT NULL AUTO_INCREMENT,
  `CodigoS2` INT NULL,
  `Nucleo` VARCHAR(100) NULL,
  `DPICedula` VARCHAR(100) NULL,
  `EstadoCivil` VARCHAR(100) NULL,
  `Parentesco` VARCHAR(100) NULL,
  `OtroFamiliar` VARCHAR(100) NULL,
  `Nacionalidad` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  `Departamento` VARCHAR(100) NULL,
  `Municipio` VARCHAR(100) NULL,
  PRIMARY KEY (`idS2_Dem`),
  INDEX `fk_S2_Dem_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S2_Dem_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S3_Edu`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S3_Edu` ;

CREATE TABLE IF NOT EXISTS `S3_Edu` (
  `idS3_Edu` INT NOT NULL AUTO_INCREMENT,
  `CodigoS3` INT NULL,
  `LeerEscribir` VARCHAR(100) NULL,
  `GradoEducacion` VARCHAR(100) NULL,
  `OtroGrado` VARCHAR(100) NULL,
  `AsistenciaEstablecimiento` VARCHAR(100) NULL,
  `NombreEstablecimiento` VARCHAR(100) NULL,
  `TipoEstablecimiento` VARCHAR(100) NULL,
  `OtroTipoEstablecimiento` VARCHAR(100) NULL,
  `UbicacionEstablecimiento` VARCHAR(100) NULL,
  `RazonNoAsistencia` VARCHAR(100) NULL,
  `OtraRazon` VARCHAR(100) NULL,
  `FormacionComplementaria` VARCHAR(100) NULL,
  `TipoFormacion` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  PRIMARY KEY (`idS3_Edu`),
  INDEX `fk_S3_Edu_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S3_Edu_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S4_Sal`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S4_Sal` ;

CREATE TABLE IF NOT EXISTS `S4_Sal` (
  `idS4_Sal` INT NOT NULL AUTO_INCREMENT,
  `CodigoS4` INT NULL,
  `AsistenciaSalud` VARCHAR(100) NULL,
  `NombreCentro` VARCHAR(100) NULL,
  `UbicacionCentro` VARCHAR(100) NULL,
  `ProblemaSalud` TINYINT(1) NULL,
  `EspecificarProblemaSalud` VARCHAR(100) NULL,
  `Accidente` TINYINT(1) NULL,
  `TipoAccidente` VARCHAR(100) NULL,
  `Seguro` VARCHAR(100) NULL,
  `Discapacidad` VARCHAR(100) NULL,
  `OtraDiscapacidad` VARCHAR(100) NULL,
  `OrigenDiscapacidad` VARCHAR(100) NULL,
  `OtroOrigen` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  PRIMARY KEY (`idS4_Sal`),
  INDEX `fk_S4_Sal_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S4_Sal_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S5_Tra`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S5_Tra` ;

CREATE TABLE IF NOT EXISTS `S5_Tra` (
  `idS5_Tra` INT NOT NULL AUTO_INCREMENT,
  `CodigoS5` INT NULL,
  `Trabajo` TINYINT(1) NULL,
  `Buscando` TINYINT(1) NULL,
  `RazonNoBusqueda` VARCHAR(100) NULL,
  `OtraRazonNoBusqueda` VARCHAR(100) NULL,
  `Ocupacion` VARCHAR(100) NULL,
  `OtraOcupacion` VARCHAR(100) NULL,
  `ContratoTrabajo` VARCHAR(100) NULL,
  `CondicionLaboral` VARCHAR(100) NULL,
  `UbicacionTrabajo` VARCHAR(100) NULL,
  `OtrosTrabajos` TINYINT(1) NULL,
  `EspecificarOtrosTrabajos` VARCHAR(100) NULL,
  `DiasTrabajo` INT NULL,
  `HorasTrabajo` FLOAT NULL,
  `IngresoMensual` FLOAT NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  PRIMARY KEY (`idS5_Tra`),
  INDEX `fk_S5_Tra_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S5_Tra_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S611_Ingre`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S611_Ingre` ;

CREATE TABLE IF NOT EXISTS `S611_Ingre` (
  `idS611_Ingre` INT NOT NULL AUTO_INCREMENT,
  `RecorteGastos` TINYINT(1) NULL DEFAULT 0,
  `Prestamo` TINYINT(1) NULL DEFAULT 0,
  `VentaMaterial` TINYINT(1) NULL DEFAULT 0,
  `TrabajoOcasional` TINYINT(1) NULL DEFAULT 0,
  `Ahorros` TINYINT(1) NULL DEFAULT 0,
  `AyudaFamiliar` TINYINT(1) NULL DEFAULT 0,
  `ApoyoEstado` TINYINT(1) NULL DEFAULT 0,
  `Otro` TINYINT(1) NULL DEFAULT 0,
  `Especificar` VARCHAR(45) NULL DEFAULT 0,
  `NSNR` TINYINT(1) NULL DEFAULT 0,
  PRIMARY KEY (`idS611_Ingre`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S6_Ingre`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S6_Ingre` ;

CREATE TABLE IF NOT EXISTS `S6_Ingre` (
  `idS6_Ingre` INT NOT NULL AUTO_INCREMENT,
  `ApoyoEstado` VARCHAR(100) NULL,
  `CantidadApoyo` FLOAT NULL,
  `Remesas` VARCHAR(100) NULL,
  `CantidadRemesas` FLOAT NULL,
  `Deuda` VARCHAR(100) NULL,
  `DineroDeuda` FLOAT NULL,
  `TiempoPagoDeuda` VARCHAR(100) NULL,
  `IngresoTotal` FLOAT NULL,
  `CubreGastos` VARCHAR(100) NULL,
  `Ahorro` VARCHAR(100) NULL,
  `MontoAhorro` FLOAT NULL,
  `DineroGasto` FLOAT NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  `S611_Ingre_idS611_Ingre` INT NULL,
  PRIMARY KEY (`idS6_Ingre`),
  INDEX `fk_S6_Ingre_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  INDEX `fk_S6_Ingre_S611_Ingre1_idx` (`S611_Ingre_idS611_Ingre` ASC),
  CONSTRAINT `fk_S6_Ingre_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S6_Ingre_S611_Ingre1`
    FOREIGN KEY (`S611_Ingre_idS611_Ingre`)
    REFERENCES `S611_Ingre` (`idS611_Ingre`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S706_Viv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S706_Viv` ;

CREATE TABLE IF NOT EXISTS `S706_Viv` (
  `idS706_Viv` INT NOT NULL AUTO_INCREMENT,
  `Concreto` INT NULL,
  `TejaBarro` INT NULL,
  `Lamina` INT NULL,
  `TejaDuralita` INT NULL,
  `Paja` INT NULL,
  `Desechos` INT NULL,
  PRIMARY KEY (`idS706_Viv`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S707_Viv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S707_Viv` ;

CREATE TABLE IF NOT EXISTS `S707_Viv` (
  `idS707_Viv` INT NOT NULL AUTO_INCREMENT,
  `BlockLadrilloPrefabr` INT NULL,
  `Madera` INT NULL,
  `Adobe` INT NULL,
  `Lamina` INT NULL,
  `BaharequeBambu` INT NULL,
  `Desechos` INT NULL,
  PRIMARY KEY (`idS707_Viv`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S708_Viv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S708_Viv` ;

CREATE TABLE IF NOT EXISTS `S708_Viv` (
  `idS708_Viv` INT NOT NULL AUTO_INCREMENT,
  `Encementado` INT NULL,
  `LadrillosBarro` INT NULL,
  `Madera` INT NULL,
  `Tierra` INT NULL,
  PRIMARY KEY (`idS708_Viv`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S7_Viv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S7_Viv` ;

CREATE TABLE IF NOT EXISTS `S7_Viv` (
  `idS7_Viv` INT NOT NULL AUTO_INCREMENT,
  `Ancho` INT NULL,
  `Largo` INT NULL,
  `Cuartos` VARCHAR(60) NULL,
  `Dormitorio` VARCHAR(60) NULL,
  `Camas` VARCHAR(60) NULL,
  `ProblemaVivienda` VARCHAR(60) NULL,
  `ProblemaA` VARCHAR(100) NULL,
  `ProblemaB` VARCHAR(100) NULL,
  `ProblemaC` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  `S706_Viv_idS706_Viv` INT NOT NULL,
  `S707_Viv_idS707_Viv` INT NOT NULL,
  `S708_Viv_idS708_Viv` INT NOT NULL,
  PRIMARY KEY (`idS7_Viv`),
  INDEX `fk_S7_Viv_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  INDEX `fk_S7_Viv_S706_Viv1_idx` (`S706_Viv_idS706_Viv` ASC),
  INDEX `fk_S7_Viv_S707_Viv1_idx` (`S707_Viv_idS707_Viv` ASC),
  INDEX `fk_S7_Viv_S708_Viv1_idx` (`S708_Viv_idS708_Viv` ASC),
  CONSTRAINT `fk_S7_Viv_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S7_Viv_S706_Viv1`
    FOREIGN KEY (`S706_Viv_idS706_Viv`)
    REFERENCES `S706_Viv` (`idS706_Viv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S7_Viv_S707_Viv1`
    FOREIGN KEY (`S707_Viv_idS707_Viv`)
    REFERENCES `S707_Viv` (`idS707_Viv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S7_Viv_S708_Viv1`
    FOREIGN KEY (`S708_Viv_idS708_Viv`)
    REFERENCES `S708_Viv` (`idS708_Viv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S807_Serv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S807_Serv` ;

CREATE TABLE IF NOT EXISTS `S807_Serv` (
  `idS807_Serv` INT NOT NULL AUTO_INCREMENT,
  `Ninguno` TINYINT(1) NULL DEFAULT 0,
  `CableTV` TINYINT(1) NULL DEFAULT 0,
  `TelefonoResid` TINYINT(1) NULL DEFAULT 0,
  `Internet` TINYINT(1) NULL DEFAULT 0,
  `NSNR` TINYINT(1) NULL DEFAULT 0,
  PRIMARY KEY (`idS807_Serv`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S808_Serv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S808_Serv` ;

CREATE TABLE IF NOT EXISTS `S808_Serv` (
  `idS808_Serv` INT NOT NULL AUTO_INCREMENT,
  `Refrigerador` INT NULL,
  `EquipoSonido` INT NULL,
  `Televisor` INT NULL,
  `DVD` INT NULL,
  `Motocicleta` INT NULL,
  `Automovil` INT NULL,
  `Computadora` INT NULL,
  `Amueblado` INT NULL,
  `Otros` INT NULL,
  `Especificar` VARCHAR(45) NULL,
  PRIMARY KEY (`idS808_Serv`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S8_Serv`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S8_Serv` ;

CREATE TABLE IF NOT EXISTS `S8_Serv` (
  `idS8_Serv` INT NOT NULL AUTO_INCREMENT,
  `AccesoAgua` VARCHAR(100) NULL,
  `FuenteAgua` VARCHAR(100) NULL,
  `OtraFuente` VARCHAR(100) NULL,
  `EnergiaElectrica` VARCHAR(100) NULL,
  `OtraEnergiaElectrica` VARCHAR(100) NULL,
  `EnergiaCocina` VARCHAR(100) NULL,
  `OtraEnergiaCocina` VARCHAR(100) NULL,
  `Sanitario` VARCHAR(100) NULL,
  `OtroTipoSanitario` VARCHAR(100) NULL,
  `BasuraHogar` VARCHAR(100) NULL,
  `OtroTipoBasura` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  `S807_Serv_idS807_Serv` INT NOT NULL,
  `S808_Serv_idS808_Serv` INT NOT NULL,
  PRIMARY KEY (`idS8_Serv`),
  INDEX `fk_S8_Serv_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  INDEX `fk_S8_Serv_S807_Serv1_idx` (`S807_Serv_idS807_Serv` ASC),
  INDEX `fk_S8_Serv_S808_Serv1_idx` (`S808_Serv_idS808_Serv` ASC),
  CONSTRAINT `fk_S8_Serv_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S8_Serv_S807_Serv1`
    FOREIGN KEY (`S807_Serv_idS807_Serv`)
    REFERENCES `S807_Serv` (`idS807_Serv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S8_Serv_S808_Serv1`
    FOREIGN KEY (`S808_Serv_idS808_Serv`)
    REFERENCES `S808_Serv` (`idS808_Serv`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S9_Prop`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S9_Prop` ;

CREATE TABLE IF NOT EXISTS `S9_Prop` (
  `idS9_Prop` INT NOT NULL AUTO_INCREMENT,
  `Propio` VARCHAR(100) NULL,
  `Propietario` VARCHAR(100) NULL,
  `OtroPropietario` VARCHAR(100) NULL,
  `TipoPropiedad` VARCHAR(100) NULL,
  `OtroTipoPropiedad` VARCHAR(100) NULL,
  `PropietarioTerreno` VARCHAR(100) NULL,
  `TelefonoPropietarioTerreno` VARCHAR(100) NULL,
  `NSNR` TINYINT(1) NULL,
  `OtraPropiedad` VARCHAR(100) NULL,
  `PropiedadA` VARCHAR(100) NULL,
  `PropiedadB` VARCHAR(100) NULL,
  `PropiedadC` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  PRIMARY KEY (`idS9_Prop`),
  INDEX `fk_S9_Prop_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S9_Prop_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S1006_Com`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S1006_Com` ;

CREATE TABLE IF NOT EXISTS `S1006_Com` (
  `idS1006_Com` INT NOT NULL AUTO_INCREMENT,
  `GrupoPolitico` TINYINT(1) NULL DEFAULT 0,
  `GrupoDeportivo` TINYINT(1) NULL DEFAULT 0,
  `GrupoReligioso` TINYINT(1) NULL DEFAULT 0,
  `GrupoJovenes` TINYINT(1) NULL DEFAULT 0,
  `GrupoMujeres` TINYINT(1) NULL DEFAULT 0,
  `OrganizacionComunitaria` TINYINT(1) NULL DEFAULT 0,
  `MesaTrabajo` TINYINT(1) NULL DEFAULT 0,
  `Otro` TINYINT(1) NULL DEFAULT 0,
  `Especificar` VARCHAR(45) NULL,
  `NSNR` TINYINT(1) NULL DEFAULT 0,
  PRIMARY KEY (`idS1006_Com`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S1008_Com`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S1008_Com` ;

CREATE TABLE IF NOT EXISTS `S1008_Com` (
  `idS1008_Com` INT NOT NULL AUTO_INCREMENT,
  `Familiar` INT NULL,
  `Vecinos` INT NULL,
  `LideresComunitarios` INT NULL,
  `Policia` INT NULL,
  `Municipalidad` INT NULL,
  `OrganizacionGobierno` INT NULL,
  `Ejercito` INT NULL,
  `PartidosPoliticos` INT NULL,
  `Techo` INT NULL,
  `MedioComunicacion` INT NULL,
  `IglesiasReligiosos` INT NULL,
  PRIMARY KEY (`idS1008_Com`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S1007_Com`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S1007_Com` ;

CREATE TABLE IF NOT EXISTS `S1007_Com` (
  `idS1007_Com` INT NOT NULL AUTO_INCREMENT,
  `NoInteresa` TINYINT(1) NULL DEFAULT 0,
  `FaltaInformacion` TINYINT(1) NULL DEFAULT 0,
  `FaltaTiempo` TINYINT(1) NULL DEFAULT 0,
  `CompromisoFamiliar` TINYINT(1) NULL DEFAULT 0,
  `Otro` TINYINT(1) NULL DEFAULT 0,
  `Especificar` VARCHAR(45) NULL,
  `NSNR` TINYINT(1) NULL DEFAULT 0,
  PRIMARY KEY (`idS1007_Com`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S1014_Com`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S1014_Com` ;

CREATE TABLE IF NOT EXISTS `S1014_Com` (
  `idS1014_Com` INT NOT NULL AUTO_INCREMENT,
  `Niños` TINYINT(1) NULL DEFAULT 0,
  `Jovenes` TINYINT(1) NULL DEFAULT 0,
  `Mujeres` TINYINT(1) NULL DEFAULT 0,
  `TerceraEdad` TINYINT(1) NULL DEFAULT 0,
  `Discapacitados` TINYINT(1) NULL DEFAULT 0,
  `GruposEtnicos` TINYINT(1) NULL DEFAULT 0,
  `NoGruposVulnerables` TINYINT(1) NULL DEFAULT 0,
  `Otros` TINYINT(1) NULL DEFAULT 0,
  `Especificar` VARCHAR(45) NULL,
  `NSNR` TINYINT(1) NULL DEFAULT 0,
  PRIMARY KEY (`idS1014_Com`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S10_Com`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S10_Com` ;

CREATE TABLE IF NOT EXISTS `S10_Com` (
  `idS10_Com` INT NOT NULL AUTO_INCREMENT,
  `Ayudo` VARCHAR(255) NULL,
  `AyudaVecinos` VARCHAR(255) NULL,
  `RelacionVecinos` VARCHAR(100) NULL,
  `ComentarioRelacion` VARCHAR(255) NULL,
  `OrganizarVecinos` VARCHAR(100) NULL,
  `OrganizarA` VARCHAR(255) NULL,
  `OrganizarB` VARCHAR(255) NULL,
  `OrganizarC` VARCHAR(255) NULL,
  `ParticipacionGrupo` VARCHAR(100) NULL,
  `Necesidad` VARCHAR(100) NULL,
  `NecesidadA` VARCHAR(100) NULL,
  `NecesidadB` VARCHAR(100) NULL,
  `NecesidadC` VARCHAR(100) NULL,
  `NecesidadCom` VARCHAR(100) NULL,
  `NecesidadComA` VARCHAR(100) NULL,
  `NecesidadComB` VARCHAR(100) NULL,
  `NecesidadComC` VARCHAR(100) NULL,
  `ProyectosVecinos` VARCHAR(100) NULL,
  `ProyectoA` VARCHAR(100) NULL,
  `ProyectoB` VARCHAR(100) NULL,
  `ProyectoC` VARCHAR(100) NULL,
  `AspectoPositivo` TINYINT(1) NULL,
  `AspectoPositivoA` VARCHAR(100) NULL,
  `AspectoPositivoB` VARCHAR(100) NULL,
  `AspectoNegativo` TINYINT(1) NULL,
  `AspectoNegativoA` VARCHAR(100) NULL,
  `AspectoNegativoB` VARCHAR(100) NULL,
  `Discriminacion` VARCHAR(100) NULL,
  `TipoDiscriminacion` VARCHAR(100) NULL,
  `OrganizacionComunitaria` VARCHAR(100) NULL,
  `TipoOrganizacion` VARCHAR(100) NULL,
  `ConfianzaOrganizacion` VARCHAR(100) NULL,
  `ComentarioConfianza` VARCHAR(100) NULL,
  `Lider` TINYINT(1) NULL,
  `LiderA` VARCHAR(100) NULL,
  `LiderB` VARCHAR(100) NULL,
  `LiderC` VARCHAR(100) NULL,
  `EstadoComunidadPasado` VARCHAR(100) NULL,
  `ComentarioEstadoPasado` VARCHAR(100) NULL,
  `EstadoComunidadFuturo` VARCHAR(100) NULL,
  `ComentarioEstadoFuturo` VARCHAR(100) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  `S1006_Com_idS1006_Com` INT NULL,
  `S1008_Com_idS1008_Com` INT NOT NULL,
  `S1007_Com_idS1007_Com` INT NULL,
  `S1014_Com_idS1014_Com` INT NOT NULL,
  PRIMARY KEY (`idS10_Com`),
  INDEX `fk_S10_Com_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  INDEX `fk_S10_Com_S1006_Com1_idx` (`S1006_Com_idS1006_Com` ASC),
  INDEX `fk_S10_Com_S1008_Com1_idx` (`S1008_Com_idS1008_Com` ASC),
  INDEX `fk_S10_Com_S1007_Com1_idx` (`S1007_Com_idS1007_Com` ASC),
  INDEX `fk_S10_Com_S1014_Com1_idx` (`S1014_Com_idS1014_Com` ASC),
  CONSTRAINT `fk_S10_Com_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S10_Com_S1006_Com1`
    FOREIGN KEY (`S1006_Com_idS1006_Com`)
    REFERENCES `S1006_Com` (`idS1006_Com`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S10_Com_S1008_Com1`
    FOREIGN KEY (`S1008_Com_idS1008_Com`)
    REFERENCES `S1008_Com` (`idS1008_Com`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S10_Com_S1007_Com1`
    FOREIGN KEY (`S1007_Com_idS1007_Com`)
    REFERENCES `S1007_Com` (`idS1007_Com`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_S10_Com_S1014_Com1`
    FOREIGN KEY (`S1014_Com_idS1014_Com`)
    REFERENCES `S1014_Com` (`idS1014_Com`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `S11_Mov`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `S11_Mov` ;

CREATE TABLE IF NOT EXISTS `S11_Mov` (
  `idS11_Mov` INT NOT NULL AUTO_INCREMENT,
  `VidaFamiliar` VARCHAR(100) NULL,
  `DireccionPasada` VARCHAR(100) NULL,
  `AnioTraslado` VARCHAR(100) NULL,
  `PorqueAnioTraslado` VARCHAR(100) NULL,
  `VIviendaActual` VARCHAR(100) NULL,
  `ComentarioFinal` VARCHAR(500) NULL,
  `Encuestas_idEncuestas` INT NOT NULL,
  PRIMARY KEY (`idS11_Mov`),
  INDEX `fk_S11_Mov_Encuestas1_idx` (`Encuestas_idEncuestas` ASC),
  CONSTRAINT `fk_S11_Mov_Encuestas1`
    FOREIGN KEY (`Encuestas_idEncuestas`)
    REFERENCES `Encuestas` (`idEncuestas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Permisos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Permisos` ;

CREATE TABLE IF NOT EXISTS `Permisos` (
  `idPermisos` INT NOT NULL AUTO_INCREMENT,
  `Nombre` VARCHAR(20) NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  PRIMARY KEY (`idPermisos`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Permisos_has_TipoUsuarios`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `Permisos_has_TipoUsuarios` ;

CREATE TABLE IF NOT EXISTS `Permisos_has_TipoUsuarios` (
  `idPermisos_has_TipoUsuarios` INT NOT NULL AUTO_INCREMENT,
  `Permisos_idPermisos` INT NOT NULL,
  `TipoUsuarios_idTipoUsuarios` INT NOT NULL,
  INDEX `fk_Permisos_has_TipoUsuarios_TipoUsuarios1_idx` (`TipoUsuarios_idTipoUsuarios` ASC),
  INDEX `fk_Permisos_has_TipoUsuarios_Permisos1_idx` (`Permisos_idPermisos` ASC),
  PRIMARY KEY (`idPermisos_has_TipoUsuarios`),
  CONSTRAINT `fk_Permisos_has_TipoUsuarios_Permisos1`
    FOREIGN KEY (`Permisos_idPermisos`)
    REFERENCES `Permisos` (`idPermisos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Permisos_has_TipoUsuarios_TipoUsuarios1`
    FOREIGN KEY (`TipoUsuarios_idTipoUsuarios`)
    REFERENCES `TipoUsuarios` (`idTipoUsuarios`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DetalleSalida`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DetalleSalida` ;

CREATE TABLE IF NOT EXISTS `DetalleSalida` (
  `idDetalleSalida` INT NOT NULL AUTO_INCREMENT,
  `Cantidad` INT NOT NULL,
  `Alimentos_idAlimentos` INT NOT NULL,
  `Activo` TINYINT(1) NULL DEFAULT 1,
  `Salida_idSalida` INT NOT NULL,
  INDEX `fk_Donacion_has_Alimentos_Alimentos1_idx` (`Alimentos_idAlimentos` ASC),
  PRIMARY KEY (`idDetalleSalida`),
  INDEX `fk_DetalleSalida_Salida1_idx` (`Salida_idSalida` ASC),
  CONSTRAINT `fk_Donacion_has_Alimentos_Alimentos1`
    FOREIGN KEY (`Alimentos_idAlimentos`)
    REFERENCES `Alimentos` (`idAlimentos`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_DetalleSalida_Salida1`
    FOREIGN KEY (`Salida_idSalida`)
    REFERENCES `Salida` (`idSalida`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `DetallePrestamo`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `DetallePrestamo` ;

CREATE TABLE IF NOT EXISTS `DetallePrestamo` (
  `idDetallePrestamo` INT NOT NULL AUTO_INCREMENT,
  `Herramientas_idHerramientas` INT NOT NULL,
  `Prestamo_idPrestamo` INT NOT NULL,
  `CantidadPrestada` INT NULL,
  `CantidadBuenEstado` INT NULL,
  `CantidadMalEstado` INT NULL DEFAULT 0,
  `CantidadPerdida` INT NULL DEFAULT 0,
  `Activo` INT NULL,
  `FechaDevolucion` DATE NULL,
  INDEX `fk_Herramientas_has_Prestamo_Prestamo1_idx` (`Prestamo_idPrestamo` ASC),
  INDEX `fk_Herramientas_has_Prestamo_Herramientas1_idx` (`Herramientas_idHerramientas` ASC),
  PRIMARY KEY (`idDetallePrestamo`),
  CONSTRAINT `fk_Herramientas_has_Prestamo_Herramientas1`
    FOREIGN KEY (`Herramientas_idHerramientas`)
    REFERENCES `Herramientas` (`idHerramientas`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Herramientas_has_Prestamo_Prestamo1`
    FOREIGN KEY (`Prestamo_idPrestamo`)
    REFERENCES `Prestamo` (`idPrestamo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
