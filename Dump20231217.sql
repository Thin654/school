CREATE DATABASE  IF NOT EXISTS `projectmax` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `projectmax`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: projectmax
-- ------------------------------------------------------
-- Server version	8.0.34

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `bank`
--

DROP TABLE IF EXISTS `bank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `bank` (
  `idbank` int NOT NULL,
  PRIMARY KEY (`idbank`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `bank`
--

LOCK TABLES `bank` WRITE;
/*!40000 ALTER TABLE `bank` DISABLE KEYS */;
/*!40000 ALTER TABLE `bank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coin`
--

DROP TABLE IF EXISTS `coin`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coin` (
  `coincode` int NOT NULL,
  `symbol` varchar(45) DEFAULT NULL,
  `namecoin` varchar(45) DEFAULT NULL,
  `icon` blob,
  `rate` int DEFAULT NULL,
  PRIMARY KEY (`coincode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coin`
--

LOCK TABLES `coin` WRITE;
/*!40000 ALTER TABLE `coin` DISABLE KEYS */;
INSERT INTO `coin` VALUES (1,'BTC','Bitcoin',NULL,37170);
/*!40000 ALTER TABLE `coin` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `credit`
--

DROP TABLE IF EXISTS `credit`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `credit` (
  `number` int NOT NULL,
  `identification` int NOT NULL,
  `cvv` int DEFAULT NULL,
  `expiry` date DEFAULT NULL,
  PRIMARY KEY (`number`,`identification`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `credit`
--

LOCK TABLES `credit` WRITE;
/*!40000 ALTER TABLE `credit` DISABLE KEYS */;
INSERT INTO `credit` VALUES (1,123,881,'2023-11-02');
/*!40000 ALTER TABLE `credit` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customer`
--

DROP TABLE IF EXISTS `customer`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `customer` (
  `idcustomer` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idcustomer`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customer`
--

LOCK TABLES `customer` WRITE;
/*!40000 ALTER TABLE `customer` DISABLE KEYS */;
INSERT INTO `customer` VALUES (4,'John Do','john.doe@example.com','newpassword');
/*!40000 ALTER TABLE `customer` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `movement`
--

DROP TABLE IF EXISTS `movement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `movement` (
  `movementid` int NOT NULL AUTO_INCREMENT,
  `coincode` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `rt_price` int DEFAULT NULL,
  `vol` int DEFAULT NULL,
  PRIMARY KEY (`movementid`),
  KEY `mov_coin_fk_idx` (`coincode`),
  CONSTRAINT `mov_coin_fk` FOREIGN KEY (`coincode`) REFERENCES `coin` (`coincode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `movement`
--

LOCK TABLES `movement` WRITE;
/*!40000 ALTER TABLE `movement` DISABLE KEYS */;
/*!40000 ALTER TABLE `movement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `trade`
--

DROP TABLE IF EXISTS `trade`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `trade` (
  `idtrade` int NOT NULL AUTO_INCREMENT,
  `customerid` int DEFAULT NULL,
  `coinid` int DEFAULT NULL,
  `transactionid` int DEFAULT NULL,
  `rate` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `long/short` tinyint DEFAULT NULL,
  `amount` int DEFAULT NULL,
  PRIMARY KEY (`idtrade`),
  KEY `trans_coin_fk_idx` (`coinid`),
  KEY `trade_trans_fk_idx` (`transactionid`),
  KEY `trade_cu_fk_idx` (`customerid`),
  CONSTRAINT `trade_coin_fk` FOREIGN KEY (`coinid`) REFERENCES `coin` (`coincode`),
  CONSTRAINT `trade_cu_fk` FOREIGN KEY (`customerid`) REFERENCES `customer` (`idcustomer`),
  CONSTRAINT `trade_trans_fk` FOREIGN KEY (`transactionid`) REFERENCES `transaction` (`transactionid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `trade`
--

LOCK TABLES `trade` WRITE;
/*!40000 ALTER TABLE `trade` DISABLE KEYS */;
/*!40000 ALTER TABLE `trade` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transaction`
--

DROP TABLE IF EXISTS `transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transaction` (
  `transactionid` int NOT NULL AUTO_INCREMENT,
  `customerid` int DEFAULT NULL,
  `credit` int DEFAULT NULL,
  `identification` int DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `amount` int DEFAULT NULL,
  `transbankid` int DEFAULT NULL,
  PRIMARY KEY (`transactionid`),
  KEY `tran_sa_fr_idx` (`transactionid`),
  KEY `cu_tr_fr_idx` (`customerid`),
  CONSTRAINT `cu_tr_fr` FOREIGN KEY (`customerid`) REFERENCES `customer` (`idcustomer`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transaction`
--

LOCK TABLES `transaction` WRITE;
/*!40000 ALTER TABLE `transaction` DISABLE KEYS */;
/*!40000 ALTER TABLE `transaction` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-12-17 11:14:57
