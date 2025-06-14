-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: aula_digital
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `alumnos`
--

DROP TABLE IF EXISTS `alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `alumnos` (
  `idAlumno` smallint NOT NULL AUTO_INCREMENT,
  `dni` int NOT NULL,
  `nombre` varchar(40) NOT NULL,
  `apellido` varchar(40) NOT NULL,
  PRIMARY KEY (`idAlumno`),
  UNIQUE KEY `dni` (`dni`),
  UNIQUE KEY `UQ_Alumnos` (`dni`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `alumnos`
--

LOCK TABLES `alumnos` WRITE;
/*!40000 ALTER TABLE `alumnos` DISABLE KEYS */;
/*!40000 ALTER TABLE `alumnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carritonotebooks`
--

DROP TABLE IF EXISTS `carritonotebooks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carritonotebooks` (
  `idCarrito` tinyint NOT NULL,
  `idNotebook` tinyint NOT NULL,
  PRIMARY KEY (`idCarrito`,`idNotebook`),
  KEY `FK_CarritoNotebooks_Notebooks` (`idNotebook`),
  CONSTRAINT `FK_CarritoNotebooks_Carritos` FOREIGN KEY (`idCarrito`) REFERENCES `carritos` (`idCarrito`),
  CONSTRAINT `FK_CarritoNotebooks_Notebooks` FOREIGN KEY (`idNotebook`) REFERENCES `notebooks` (`idNotebook`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carritonotebooks`
--

LOCK TABLES `carritonotebooks` WRITE;
/*!40000 ALTER TABLE `carritonotebooks` DISABLE KEYS */;
/*!40000 ALTER TABLE `carritonotebooks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `carritos`
--

DROP TABLE IF EXISTS `carritos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `carritos` (
  `idCarrito` tinyint NOT NULL AUTO_INCREMENT,
  `idDocente` smallint NOT NULL,
  `capacidad` tinyint NOT NULL,
  PRIMARY KEY (`idCarrito`),
  KEY `FK_Carritos_Docentes` (`idDocente`),
  CONSTRAINT `FK_Carritos_Docentes` FOREIGN KEY (`idDocente`) REFERENCES `docentes` (`idDocente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `carritos`
--

LOCK TABLES `carritos` WRITE;
/*!40000 ALTER TABLE `carritos` DISABLE KEYS */;
/*!40000 ALTER TABLE `carritos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `docentes`
--

DROP TABLE IF EXISTS `docentes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `docentes` (
  `idDocente` smallint NOT NULL AUTO_INCREMENT,
  `nombre` varchar(40) NOT NULL,
  `apellido` varchar(40) NOT NULL,
  `email` varchar(70) NOT NULL,
  PRIMARY KEY (`idDocente`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `docentes`
--

LOCK TABLES `docentes` WRITE;
/*!40000 ALTER TABLE `docentes` DISABLE KEYS */;
/*!40000 ALTER TABLE `docentes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `notebooks`
--

DROP TABLE IF EXISTS `notebooks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `notebooks` (
  `idNotebook` tinyint NOT NULL AUTO_INCREMENT,
  `estado` varchar(40) NOT NULL,
  `programas` varchar(40) NOT NULL,
  PRIMARY KEY (`idNotebook`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `notebooks`
--

LOCK TABLES `notebooks` WRITE;
/*!40000 ALTER TABLE `notebooks` DISABLE KEYS */;
/*!40000 ALTER TABLE `notebooks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `permisosprestamo`
--

DROP TABLE IF EXISTS `permisosprestamo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `permisosprestamo` (
  `idPermiso` smallint NOT NULL AUTO_INCREMENT,
  `idAlumno` smallint NOT NULL,
  `idDocente` smallint NOT NULL,
  `fechaPermiso` datetime NOT NULL,
  PRIMARY KEY (`idPermiso`),
  KEY `FK_Permiso_Alumnos` (`idAlumno`),
  KEY `FK_Permiso_Docentes` (`idDocente`),
  CONSTRAINT `FK_Permiso_Alumnos` FOREIGN KEY (`idAlumno`) REFERENCES `alumnos` (`idAlumno`),
  CONSTRAINT `FK_Permiso_Docentes` FOREIGN KEY (`idDocente`) REFERENCES `docentes` (`idDocente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `permisosprestamo`
--

LOCK TABLES `permisosprestamo` WRITE;
/*!40000 ALTER TABLE `permisosprestamo` DISABLE KEYS */;
/*!40000 ALTER TABLE `permisosprestamo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prestamodetalle`
--

DROP TABLE IF EXISTS `prestamodetalle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prestamodetalle` (
  `idDetalle` int NOT NULL AUTO_INCREMENT,
  `idPrestamo` int NOT NULL,
  `idNotebook` tinyint NOT NULL,
  `estadoPrestamo` varchar(40) NOT NULL,
  PRIMARY KEY (`idDetalle`),
  KEY `FK_PrestamoDetalle_Prestamos` (`idPrestamo`),
  KEY `FK_PrestamoDetalle_Notebooks` (`idNotebook`),
  CONSTRAINT `FK_PrestamoDetalle_Notebooks` FOREIGN KEY (`idNotebook`) REFERENCES `notebooks` (`idNotebook`),
  CONSTRAINT `FK_PrestamoDetalle_Prestamos` FOREIGN KEY (`idPrestamo`) REFERENCES `prestamos` (`idPrestamo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prestamodetalle`
--

LOCK TABLES `prestamodetalle` WRITE;
/*!40000 ALTER TABLE `prestamodetalle` DISABLE KEYS */;
/*!40000 ALTER TABLE `prestamodetalle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prestamos`
--

DROP TABLE IF EXISTS `prestamos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `prestamos` (
  `idPrestamo` int NOT NULL AUTO_INCREMENT,
  `idAlumno` smallint DEFAULT NULL,
  `idDocente` smallint DEFAULT NULL,
  `idCarrito` tinyint DEFAULT NULL,
  `fechaPrestamo` datetime DEFAULT NULL,
  `fechaDevolucion` datetime DEFAULT NULL,
  `tipoPrestamo` varchar(30) NOT NULL,
  PRIMARY KEY (`idPrestamo`),
  KEY `FK_Prestamos_Alumno` (`idAlumno`),
  KEY `FK_Prestamos_Docentes` (`idDocente`),
  KEY `FK_Prestamos_Carritos` (`idCarrito`),
  CONSTRAINT `FK_Prestamos_Alumno` FOREIGN KEY (`idAlumno`) REFERENCES `alumnos` (`idAlumno`),
  CONSTRAINT `FK_Prestamos_Carritos` FOREIGN KEY (`idCarrito`) REFERENCES `carritos` (`idCarrito`),
  CONSTRAINT `FK_Prestamos_Docentes` FOREIGN KEY (`idDocente`) REFERENCES `docentes` (`idDocente`),
  CONSTRAINT `CHK_Prestamos` CHECK ((((`tipoPrestamo` = _utf8mb4'individual') and (`idCarrito` is null)) or ((`tipoPrestamo` = _utf8mb4'carrito') and (`idCarrito` is not null))))
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prestamos`
--

LOCK TABLES `prestamos` WRITE;
/*!40000 ALTER TABLE `prestamos` DISABLE KEYS */;
/*!40000 ALTER TABLE `prestamos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'aula_digital'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-12 14:59:28
