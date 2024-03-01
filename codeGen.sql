-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: new_schema
-- ------------------------------------------------------
-- Server version	8.3.0

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
-- Table structure for table `domain`
--

DROP TABLE IF EXISTS `domain`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `domain` (
  `domainId` int NOT NULL,
  `domainName` varchar(45) DEFAULT NULL,
  `fieldId` int DEFAULT NULL,
  `attributeValue` varchar(100) DEFAULT NULL,
  `domainSeq` int DEFAULT NULL,
  `pageId` int DEFAULT NULL,
  PRIMARY KEY (`domainId`),
  KEY `fieldId_idx` (`fieldId`),
  KEY `pageId_idx` (`pageId`),
  CONSTRAINT `fieldIdx` FOREIGN KEY (`fieldId`) REFERENCES `field` (`fieldId`),
  CONSTRAINT `pageIdx1` FOREIGN KEY (`pageId`) REFERENCES `pages` (`pageId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `domain`
--

LOCK TABLES `domain` WRITE;
/*!40000 ALTER TABLE `domain` DISABLE KEYS */;
INSERT INTO `domain` VALUES (1,'yes',23,'Yes',1,4),(2,'no',23,'No',2,4),(4,'pay1',19,'Full Pay',1,5),(5,'pay2',19,'2 Pay',2,5),(6,'pay3',19,'4 Pay',3,5),(7,'billby1',18,'Insured',1,5),(8,'billby2',18,'Mortgage',2,5),(9,'1',24,'1',1,4),(10,'2',24,'2',2,4),(11,'3',24,'3',3,4),(12,'4',24,'4',4,4),(13,'5',24,'5',5,4);
/*!40000 ALTER TABLE `domain` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `field`
--

DROP TABLE IF EXISTS `field`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `field` (
  `fieldId` int NOT NULL,
  `fieldName` varchar(45) DEFAULT NULL,
  `fieldDescription` varchar(45) DEFAULT NULL,
  `fieldType` varchar(45) DEFAULT NULL,
  `pageId` int DEFAULT NULL,
  `displayName` varchar(45) DEFAULT NULL,
  `sequence` int DEFAULT NULL,
  `dataSize` int DEFAULT NULL,
  `required` tinyint DEFAULT '0',
  `minSize` varchar(25) DEFAULT NULL,
  `maxSize` varchar(25) DEFAULT NULL,
  `reqCondition` varchar(45) DEFAULT NULL,
  `dispCondition` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`fieldId`),
  KEY `pageIdx_idx` (`pageId`),
  CONSTRAINT `pageIdx` FOREIGN KEY (`pageId`) REFERENCES `pages` (`pageId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `field`
--

LOCK TABLES `field` WRITE;
/*!40000 ALTER TABLE `field` DISABLE KEYS */;
INSERT INTO `field` VALUES (1,'policyEffDt','Policy Effective Date','datetime',1,'Effective Date',1,NULL,1,NULL,NULL,NULL,NULL),(2,'policyExpDt','Policy Expiration Date','datetime',1,'Expiration Date',2,NULL,1,NULL,NULL,NULL,NULL),(3,'firstName','Insured First Name','nvarchar',2,'First Name',1,25,1,NULL,NULL,NULL,NULL),(4,'lastName','Insured Last Name','nvarchar',2,'Last Name',2,25,1,NULL,NULL,NULL,NULL),(5,'addressLine1','Insured Address Line 1','nvarchar',2,'Address Line 1',3,40,1,NULL,NULL,NULL,NULL),(6,'addressLine2','Insured Address Line 2','nvarchar',2,'Address Line 2',4,40,0,NULL,NULL,NULL,NULL),(7,'email','Insured Email Address','nvarchar',2,'Email Address',5,15,1,NULL,NULL,NULL,NULL),(8,'phone','Insured Phone','nvarchar',2,'Contact Number',6,10,1,NULL,NULL,NULL,NULL),(9,'regNo','Vehicle Registration Number','nvarchar',3,'RegistrationNumber',1,15,1,NULL,NULL,NULL,NULL),(10,'engineNo','Vehicle Engine Number','nvarchar',3,'Engine Number',2,10,1,NULL,NULL,NULL,NULL),(11,'chasisNo','Vehicle Chasis Number','nvarchar',3,'Chasis Number',3,15,1,NULL,NULL,NULL,NULL),(12,'purchaseDt','Date of Purchase','datetime',3,'Purchase Date',4,NULL,0,NULL,NULL,NULL,NULL),(13,'manYear','Year of Manufacture','integer',3,'Manufacture Year',5,4,1,NULL,NULL,NULL,NULL),(14,'model','Vehicle Model','nvarchar',3,'Vehicle Model',6,15,1,NULL,NULL,NULL,NULL),(15,'make','Brand of the Vehicle','nvarchar',3,'Vehicle Brand',7,15,1,NULL,NULL,NULL,NULL),(16,'color','Vehicle Primary Color','nvarchar',3,'Vehicle Color',8,15,0,NULL,NULL,NULL,NULL),(17,'TP','Theft Protection ','checkbox',4,'Theft Protection ',1,NULL,0,NULL,NULL,NULL,NULL),(18,'billPaidBy','Bill Paid By','select',5,'Bill by',1,NULL,1,NULL,NULL,NULL,NULL),(19,'payPlan','PayPlan','select',5,'Pay Plan',2,NULL,1,NULL,NULL,NULL,NULL),(20,'price','Price of the vehicle','decimal',3,'Purchase Price',9,10,1,NULL,NULL,NULL,NULL),(21,'ODP','Own Damage Protection','checkbox',4,'Own Damage Protection',2,NULL,0,NULL,NULL,NULL,NULL),(22,'TPC','Third Party Cover','checkbox',4,'Third Party Cover',3,NULL,0,NULL,NULL,NULL,NULL),(23,'NCB','No Claim Bonus','Radio',4,'Eligible for No Claim Bonus',4,NULL,1,NULL,NULL,NULL,NULL),(24,'NCBYrs','NCB consecutive Years','select',4,'No. of cons. years',5,NULL,0,NULL,NULL,'NCB[.=\'Yes]\'','NCB[.=\'Yes\']');
/*!40000 ALTER TABLE `field` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pages`
--

DROP TABLE IF EXISTS `pages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `pages` (
  `pageId` int NOT NULL AUTO_INCREMENT,
  `pageTitle` varchar(45) DEFAULT NULL,
  `pageDescription` varchar(45) DEFAULT NULL,
  `pageIdentifier` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`pageId`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pages`
--

LOCK TABLES `pages` WRITE;
/*!40000 ALTER TABLE `pages` DISABLE KEYS */;
INSERT INTO `pages` VALUES (0,'Home Page','Home Page','Home'),(1,'Policy Details','Basic Details Page','PolicyDetails'),(2,'Insured Details','Insured Details Page','InsuredDetails'),(3,'Vehicle Details','Vehicle Details Page','VehicleDetails'),(4,'Coverage Details','Coverage Details Page ','CoverageDetails'),(5,'PayPlan','PayPlan details ','PayPlan');
/*!40000 ALTER TABLE `pages` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-03-01  9:31:45
