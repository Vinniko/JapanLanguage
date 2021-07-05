-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: japanlanguagesitedb
-- ------------------------------------------------------
-- Server version	8.0.22

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
-- Table structure for table `articles`
--

DROP TABLE IF EXISTS `articles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `articles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(50) DEFAULT NULL,
  `text` longtext,
  `date` datetime DEFAULT NULL,
  `description` longtext,
  `imagePath` varchar(333) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `articles`
--

LOCK TABLES `articles` WRITE;
/*!40000 ALTER TABLE `articles` DISABLE KEYS */;
INSERT INTO `articles` VALUES (1,'Язык','Тут много текста про язык','2020-04-04 18:31:07','Японский - не такой сложный язык, каким кажется. Сегодня мы расскажем вам, что он из себя представляет.','Language Image 1.jpg'),(2,'Исскуство','Тут много текста про исскуство','2020-04-04 18:31:07','Исскуство Японии слишком необычно, чтобы говорить о нём в двух словах.','Art Image 1.jpg'),(3,'Культура','Тут много текста про культуру','2020-04-04 18:31:08','Тут про культуру, рил','Culture Image 1.jpg'),(4,'Язык','Тут много текста про язык','2020-04-04 18:31:12','Японский - не такой сложный язык, каким кажется. Сегодня мы расскажем вам, что он из себя представляет.','Language Image 1.jpg'),(5,'Исскуство','Тут много текста про исскуство','2020-04-04 18:31:12','Исскуство Японии слишком необычно, чтобы говорить о нём в двух словах.','Art Image 1.jpg'),(6,'Культура','Тут много текста про культуру','2020-04-04 18:31:13','Тут про культуру, рил','Culture Image 1.jpg');
/*!40000 ALTER TABLE `articles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `authorizationusers`
--

DROP TABLE IF EXISTS `authorizationusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `authorizationusers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_NAU` int DEFAULT NULL,
  `login` varchar(50) DEFAULT NULL,
  `age` int DEFAULT NULL,
  `id_country` int DEFAULT NULL,
  `money` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login` (`login`),
  KEY `id_NAU` (`id_NAU`),
  KEY `id_country` (`id_country`),
  CONSTRAINT `authorizationusers_ibfk_1` FOREIGN KEY (`id_NAU`) REFERENCES `noathorizationusers` (`id`),
  CONSTRAINT `authorizationusers_ibfk_2` FOREIGN KEY (`id_country`) REFERENCES `countries` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `authorizationusers`
--

LOCK TABLES `authorizationusers` WRITE;
/*!40000 ALTER TABLE `authorizationusers` DISABLE KEYS */;
INSERT INTO `authorizationusers` VALUES (1,1,'Vinniko',19,4,99990),(2,5,'ter21',1,1,0),(3,6,'wwffffw',1,1,9999),(4,7,'feffefe',1,1,9699),(5,8,'efefeff',1,1,9699),(6,9,'www',1,1,0),(7,10,'lulu',1,1,0),(8,11,'vinnik_211',1,1,0),(9,12,'vinnik_212',1,1,0),(10,13,'vinnik_213',1,1,0),(11,14,'vinnik_215',1,1,0),(12,15,'vinnik_216',1,1,0),(13,16,'vinnik_217',1,1,0),(14,17,'vinnik_218',1,1,0),(15,18,'vinnik_219',1,1,0),(16,19,'vinnik_33',1,1,0),(17,20,'test1',1,3,200);
/*!40000 ALTER TABLE `authorizationusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `countries`
--

DROP TABLE IF EXISTS `countries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `countries` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `countries`
--

LOCK TABLES `countries` WRITE;
/*!40000 ALTER TABLE `countries` DISABLE KEYS */;
INSERT INTO `countries` VALUES (1,'Россия'),(2,'Украина'),(3,'Канада'),(4,'Япония');
/*!40000 ALTER TABLE `countries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kurses`
--

DROP TABLE IF EXISTS `kurses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `kurses` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(50) DEFAULT NULL,
  `description` varchar(999) DEFAULT NULL,
  `price` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kurses`
--

LOCK TABLES `kurses` WRITE;
/*!40000 ALTER TABLE `kurses` DISABLE KEYS */;
INSERT INTO `kurses` VALUES (1,'Jap 5 (A1)','• Основы грамматики, лексики и письма.    \n• Развитие базовых разговорных и грамматических навыков.\n• Знакомство с двумя азбуками (хирагана и катагана).\n• Владение более чем сотней иероглифическими единицами.',300),(2,'Jap 4 (A2)','• Словарный запас увеличивается до 1500 лексических единиц.\n• Понимание устной речи и участие в диалогах, если собеседник говорит медленно и четко. \n• По окончании курса можно сдавать международный экзамен Nihongo Noryoku Shiken на четвертый уровень.',300),(3,'Jap 3 (B1)','• Японский язык изучается углубленно.\n• Основные акценты делаются на грамматику, лексику и иероглифический материал, отрабатывается письменная речь и восприятие японской речи на слух. \n• По окончании этого уровня можно сдавать международный экзамен Nihongo Noryoku Shiken на третий уровень.',300),(4,'Jap 2 (B2)','• Слушатели воспринимают аутентичные материалы — газетные и журнальные статьи, сообщения из СМИ, аудио- и видеоматериалы.\n• Умело используется изученная на предыдущих уровнях грамматика и лексика, благодаря чему успешно ведутся дискуссии. \n• Словарный запас  около 6000 лексических единиц и 1000 иероглифов.',300),(5,'Jap 1 (C2)','• Доступно понимание речи собеседника в естественном темпе. \n•  Происходит знакомство с деловой сферой японского языка.\n• Усваивается около 2000 иероглифов и до 10000 слов.\n• По окончании этого уровня можно сдавать международный экзамен Nihongo Noryoku Shiken на первый уровень.',300);
/*!40000 ALTER TABLE `kurses` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lessons`
--

DROP TABLE IF EXISTS `lessons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lessons` (
  `id` int NOT NULL AUTO_INCREMENT,
  `id_kurse` int DEFAULT NULL,
  `title` varchar(50) DEFAULT NULL,
  `description` varchar(999) DEFAULT NULL,
  `text` longtext,
  `hourses` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `id_kurse` (`id_kurse`),
  CONSTRAINT `lessons_ibfk_1` FOREIGN KEY (`id_kurse`) REFERENCES `kurses` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lessons`
--

LOCK TABLES `lessons` WRITE;
/*!40000 ALTER TABLE `lessons` DISABLE KEYS */;
INSERT INTO `lessons` VALUES (1,1,'Приветствие','• Усвоим то и это • Выучим это и вот это • Станем крутыми японцами','text',1),(2,1,'Азбука Хирагана','• Усвоим то и это • Выучим это и вот это • Станем крутыми японцами','text',2),(3,1,'Ромадзи','• Усвоим то и это • Выучим это и вот это • Станем крутыми японцами','text',1);
/*!40000 ALTER TABLE `lessons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `news`
--

DROP TABLE IF EXISTS `news`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `news` (
  `id` int NOT NULL AUTO_INCREMENT,
  `title` varchar(50) DEFAULT NULL,
  `text` longtext,
  `imagePath` varchar(333) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `description` longtext,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `news`
--

LOCK TABLES `news` WRITE;
/*!40000 ALTER TABLE `news` DISABLE KEYS */;
INSERT INTO `news` VALUES (1,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 15:44:37','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.'),(2,'ЯЗЫК С НОСИТЕЛЕМ','text','Fourth News Image.jpg','2020-03-25 15:44:37','Узнай все секреты языка и научись легко общаться, благодаря живым урокам с носителем языка.'),(3,'ЯПОНСКАЯ ГРАММАТИКА','text','Third News Image.jpg','2020-03-25 15:44:38','Вводный урок в Японскую грамматику поможет вам не только узнать больше, но и понять что Японский язык не кусается, а его грамматика на самом деле очень проста и хороша для запоминания.'),(4,'КИОТСКИЙ АКЦЕНТ','text','Second News Image.jpg','2020-03-25 15:44:38','Хотите побольше узнать о Киотском акценте, познакомится с историей его формирования и научиться говорить используя его? Эта статья поможет вам сделать первый шаг к изучению данного фонетического аспекта.'),(5,'ТОКИО - ГОРОД БУДУЩЕГО','text','First News Image 1.jpg','2020-03-25 15:44:38','Организованный тур в Японию с преподавателем Японского языка.'),(6,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 16:36:49','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.'),(7,'ЯЗЫК С НОСИТЕЛЕМ','text','Fourth News Image.jpg','2020-03-25 16:36:49','Узнай все секреты языка и научись легко общаться, благодаря живым урокам с носителем языка.'),(8,'ЯПОНСКАЯ ГРАММАТИКА','text','Third News Image.jpg','2020-03-25 16:36:50','Вводный урок в Японскую грамматику поможет вам не только узнать больше, но и понять что Японский язык не кусается, а его грамматика на самом деле очень проста и хороша для запоминания.'),(9,'КИОТСКИЙ АКЦЕНТ','text','Second News Image.jpg','2020-03-25 16:36:50','Хотите побольше узнать о Киотском акценте, познакомится с историей его формирования и научиться говорить используя его? Эта статья поможет вам сделать первый шаг к изучению данного фонетического аспекта.'),(10,'ТОКИО - ГОРОД БУДУЩЕГО','text','First News Image 1.jpg','2020-03-25 16:36:50','Организованный тур в Японию с преподавателем Японского языка.'),(11,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 16:58:11','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.'),(12,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 16:58:11','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.'),(13,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 16:58:11','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.'),(14,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 16:58:11','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.'),(15,'10 ЛУЧШИХ МЕСТ В ЯПОНИИ','text','Fifth News Image.jpg','2020-03-25 16:58:11','10 лучших мест в Японии! Посетите вместе с нами в осеннем туре.');
/*!40000 ALTER TABLE `news` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `noathorizationusers`
--

DROP TABLE IF EXISTS `noathorizationusers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `noathorizationusers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `noathorizationusers`
--

LOCK TABLES `noathorizationusers` WRITE;
/*!40000 ALTER TABLE `noathorizationusers` DISABLE KEYS */;
INSERT INTO `noathorizationusers` VALUES (1,'vinnik_21@bk.ru','123456789q'),(5,'ter21@list.ru','123456789q'),(6,'wwffffw@google.com','123456789q'),(7,'feffefe@bk.ru','123456789q'),(8,'efefeff@bk.ru','123456789q'),(9,'www@bk.ru','123456789q'),(10,'lulu@bk.ru','123456789q'),(11,'vinnik_211@bk.ru','123456789q'),(12,'vinnik_212@bk.ru','123456789q'),(13,'vinnik_213@bk.ru','123456789q'),(14,'vinnik_215@bk.ru','123456789q'),(15,'vinnik_216@bk.ru','123456789q'),(16,'vinnik_217@bk.ru','123456789q'),(17,'vinnik_218@bk.ru','123456789q'),(18,'vinnik_219@bk.ru','123456789q'),(19,'vinnik_33@bk.ru','123456789q'),(20,'test@mail.ru','123456789q');
/*!40000 ALTER TABLE `noathorizationusers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `userskurses`
--

DROP TABLE IF EXISTS `userskurses`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `userskurses` (
  `id_kurse` int DEFAULT NULL,
  `id_user` int DEFAULT NULL,
  KEY `id_kurse` (`id_kurse`),
  KEY `id_user` (`id_user`),
  CONSTRAINT `userskurses_ibfk_1` FOREIGN KEY (`id_kurse`) REFERENCES `kurses` (`id`),
  CONSTRAINT `userskurses_ibfk_2` FOREIGN KEY (`id_user`) REFERENCES `authorizationusers` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `userskurses`
--

LOCK TABLES `userskurses` WRITE;
/*!40000 ALTER TABLE `userskurses` DISABLE KEYS */;
INSERT INTO `userskurses` VALUES (2,1),(1,1),(3,1),(4,1),(5,1),(1,17),(2,17),(1,2);
/*!40000 ALTER TABLE `userskurses` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-07-05 11:10:12
