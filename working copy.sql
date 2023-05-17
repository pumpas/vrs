-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2023 at 12:18 PM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `aaa`
--

-- --------------------------------------------------------

--
-- Table structure for table `answers`
--

CREATE TABLE `answers` (
  `user` varchar(15) NOT NULL,
  `question` varchar(50) NOT NULL,
  `answer` text NOT NULL,
  `id` int(5) NOT NULL,
  `likes` int(2) NOT NULL,
  `dislikes` int(2) NOT NULL,
  `best` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `answers`
--

INSERT INTO `answers` (`user`, `question`, `answer`, `id`, `likes`, `dislikes`, `best`) VALUES
('karpol2', 'Ukraine vs Russia', 'I hope Ukraine wins this war. #SlavaUkraine', 1, 0, 0, 0),
('Useris2', 'Pizza or tacos?', 'Pizzas ofc.', 24, 0, 0, 0),
('mykolas', 'Luka Doncic in a game 1 loss to the Suns: 45/12/8 ', 'Luka deserves MVPs', 26, 0, 0, 0),
('kazka', 'Amber vs Depp, who wsins?', 'Justice for Johnny Depp', 27, 0, 0, 0),
('testasAI', 'What\'s the best piece of advice you ever received?', 'xsgahfdfshsfhs', 41, 0, 0, 0),
('testasAI', 'About Lithuania', 'gadfjsfgkm,dgjnsgfbsg', 42, 0, 0, 1),
('test55', 'If you could live in a book, TV show, or movie, wh', 'dsafdasvasdkjchasd', 52, 0, 0, 0),
('test55', 'If you could live in a book, TV show, or movie, wh', 'dafsvsdcasdcASDSCASFBADSDAF', 53, 0, 0, 0),
('test55', 'Luka Doncic in a game 1 loss to the Suns: 45/12/8 ', 'asdasdvsdvfvsdfvdgbdf', 54, 0, 0, 0),
('test55', 'If you could live in a book, TV show, or movie, wh', 'sdagandgbfdgdbtgese', 55, 0, 0, 0),
('kazom', 'What languages do you speak?', 'spanola', 63, 0, 0, 0);

-- --------------------------------------------------------

--
-- Table structure for table `liked`
--

CREATE TABLE `liked` (
  `QuestionId` int(11) DEFAULT NULL,
  `AnswerId` int(11) DEFAULT NULL,
  `UserId` int(11) DEFAULT NULL,
  `Id` int(11) NOT NULL,
  `likedOrDisliked` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `liked`
--

INSERT INTO `liked` (`QuestionId`, `AnswerId`, `UserId`, `Id`, `likedOrDisliked`) VALUES
(0, 1, 154, 1, 1);

-- --------------------------------------------------------

--
-- Table structure for table `questions`
--

CREATE TABLE `questions` (
  `user` varchar(15) NOT NULL,
  `question` varchar(50) NOT NULL,
  `id` int(5) NOT NULL,
  `content` text NOT NULL,
  `likes` int(2) NOT NULL,
  `dislikes` int(2) NOT NULL,
  `topAnswer` varchar(15) NOT NULL,
  `doctor` varchar(15) DEFAULT NULL,
  `doctorww` varchar(15) DEFAULT NULL,
  `doctorr` varchar(15) DEFAULT NULL,
  `doc` int(5) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `questions`
--

INSERT INTO `questions` (`user`, `question`, `id`, `content`, `likes`, `dislikes`, `topAnswer`, `doctor`, `doctorww`, `doctorr`, `doc`) VALUES
('karpol2', 'Amber vs Depp, who wsins?', 1, 'In my opinion, I think Depp should win this, because he deserves justice. Amber should go to hell. Well what are your opinions?', 0, 0, '0', 'useris1', NULL, NULL, NULL),
('test55', 'Who wins this time nba mvp?', 2, 'So far, I can tell, that Antetokounmpo, Embiid and Jokic are front runners, but, in my opinion, Jokic should win this season\'s mvp, because of its master of pass, scoring abilities.', 0, 0, '0', NULL, NULL, NULL, NULL),
('test55', 'Is Elden Ring tiring game', 5, 'So far, I\'ve played for 120hours, and yet, I am struggling to defeat third boss, the gameplay is insane, but difficulty of this game is insane-hard game.\r\n\r\nAny reccomendation to beat this game?', 0, 0, '0', NULL, NULL, NULL, NULL),
('mykolas', 'In your opinion, is it worth studying at KTU?', 6, 'So far, I have received informations about Kaunas Technology University, is that this place is quite expensive with costs of study. I am not sure if is worth travelling to Lithuania and studying there. What are your opinions? If you\'re KTU student, I would appreciate your opinion 100%.', 0, 0, '0', NULL, NULL, NULL, NULL),
('useris1', 'KTU dormitory', 7, 'Guys, what issues you are having living in dormitories? I saw one cockroach so far, but, what about you?', 0, 0, '0', NULL, NULL, NULL, NULL),
('karpol2', 'What\'s the story behind one of your scars?', 8, 'I\'ve got scar from accidentally cutting finger with sharp knife, it\'s still sensitive, but I would say it\'s looking awesome while having this scar.', 0, 0, '0', NULL, NULL, NULL, NULL),
('test55', 'If you could live in a book, TV show, or movie, wh', 9, 'If you could live in a book, TV show, or movie, what would it be? ', 0, 0, '1', NULL, NULL, NULL, NULL),
('Useris2', 'What do you like most about your family?', 10, 'I like most about my family is that they\'re trustworthy, always by your hands, always waiting for you, always help you from serious problems.', 0, 0, '0', NULL, NULL, NULL, NULL),
('useris1', 'Pizza or tacos?', 11, 'Pizza for life, what about you guys?', 0, 0, '0', NULL, NULL, NULL, NULL),
('karpol2', 'What languages do you speak?', 12, 'Since I am not good with learning languages, so far I can only chat(not talk) English language, Lithuanian, and a bit of Russian language.', 0, 0, '0', NULL, NULL, NULL, NULL),
('karpol2', 'Ukraine vs Russia', 13, 'Well, I think this discussion is about how thing goes between Ukraine and Russia. I heard that Russia got attacked by Ukraine in one region, but I don\'t remember correctly. But of course, I wish Russia canceled war, or shouldn\'t start war at all. #SlavaUkraini', 0, 0, '0', NULL, NULL, NULL, NULL),
('kazka', 'Luka Doncic in a game 1 loss to the Suns: 45/12/8 ', 14, 'Not a bad game from Luka, but the suns still pull through and go up 1-0 in the series\r\n\r\n', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'What\'s the best piece of advice you ever received?', 15, 'Never give up. Thats the best advice for me, for you, for everyone.', 0, 0, '0', NULL, NULL, NULL, NULL),
('karpol2', 'Who inspires you to be better?', 16, 'Noone. I focus on my own, i don\'t have anyone to inspire, not really much looking forward to inspire from someone.', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'About Lithuania', 17, 'Hello guys, is it worth living in Lithuania? What are situation there?', 0, 0, '1', NULL, NULL, NULL, NULL),
('Useris2', 'adsssssssssssssssssssssss', 36, 'asddddddddddddddddddddddd', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'aaaaaaaaaaaaaaaaaaa', 40, 'azzzzzzzzzzzzaaaaa', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'ssssssssssssssssssssssssssssss', 43, 'sssssssssssssssssssssssssssssssssssss', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'qqqqqqqqqqqqqqqqqqqqqqqqqq', 47, 'qqqqqqqqqqqqqqqqqqqqqqqq', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'qwwwwwwwwwwwwwwwwwq', 51, 'qwwwwwwwwwwwwwwwwww', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'fddfsfaadafdda', 52, 'asddddddddddddddddddddddd', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'fddfsfaadafddaqqqqqqq', 57, 'asddddddddddddddddddddddd', 0, 0, '0', NULL, NULL, NULL, NULL),
('Useris2', 'qqqqqqqqqqqqqqqqqqqqqqqq', 63, 'asddddddddddddddddddddddd', 0, 0, '0', NULL, NULL, NULL, 28),
('Useris2', 'qqqqqqqqqqqqqqqqqqqqqqqqqqqqwddz', 64, 'ggggggxsdqdqwdqdqdqwdq', 0, 0, '0', NULL, NULL, NULL, 111),
('Useris2', 'Suskaudo labai koja', 65, 'nezinua kadasdsadsadqw', 0, 0, '0', NULL, NULL, NULL, 164);

-- --------------------------------------------------------

--
-- Table structure for table `questionsq`
--

CREATE TABLE `questionsq` (
  `user` varchar(15) NOT NULL,
  `question` varchar(50) NOT NULL,
  `id` int(5) NOT NULL,
  `content` text NOT NULL,
  `likes` int(2) NOT NULL,
  `dislikes` int(2) NOT NULL,
  `topAnswer` varchar(15) NOT NULL,
  `doctor` varchar(15) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `questionsq`
--

INSERT INTO `questionsq` (`user`, `question`, `id`, `content`, `likes`, `dislikes`, `topAnswer`, `doctor`) VALUES
('karpol2', 'Amber vs Depp, who wsins?', 1, 'In my opinion, I think Depp should win this, because he deserves justice. Amber should go to hell. Well what are your opinions?', 0, 0, '0', NULL),
('test55', 'Who wins this time nba mvp?', 2, 'So far, I can tell, that Antetokounmpo, Embiid and Jokic are front runners, but, in my opinion, Jokic should win this season\'s mvp, because of its master of pass, scoring abilities.', 0, 0, '0', NULL),
('test55', 'Is Elden Ring tiring game', 5, 'So far, I\'ve played for 120hours, and yet, I am struggling to defeat third boss, the gameplay is insane, but difficulty of this game is insane-hard game.\r\n\r\nAny reccomendation to beat this game?', 0, 0, '0', NULL),
('mykolas', 'In your opinion, is it worth studying at KTU?', 6, 'So far, I have received informations about Kaunas Technology University, is that this place is quite expensive with costs of study. I am not sure if is worth travelling to Lithuania and studying there. What are your opinions? If you\'re KTU student, I would appreciate your opinion 100%.', 0, 0, '0', NULL),
('useris1', 'KTU dormitory', 7, 'Guys, what issues you are having living in dormitories? I saw one cockroach so far, but, what about you?', 0, 0, '0', NULL),
('karpol2', 'What\'s the story behind one of your scars?', 8, 'I\'ve got scar from accidentally cutting finger with sharp knife, it\'s still sensitive, but I would say it\'s looking awesome while having this scar.', 0, 0, '0', NULL),
('test55', 'If you could live in a book, TV show, or movie, wh', 9, 'If you could live in a book, TV show, or movie, what would it be? ', 0, 0, '1', NULL),
('Useris2', 'What do you like most about your family?', 10, 'I like most about my family is that they\'re trustworthy, always by your hands, always waiting for you, always help you from serious problems.', 0, 0, '0', NULL),
('useris1', 'Pizza or tacos?', 11, 'Pizza for life, what about you guys?', 0, 0, '0', NULL),
('karpol2', 'What languages do you speak?', 12, 'Since I am not good with learning languages, so far I can only chat(not talk) English language, Lithuanian, and a bit of Russian language.', 0, 0, '0', NULL),
('karpol2', 'Ukraine vs Russia', 13, 'Well, I think this discussion is about how thing goes between Ukraine and Russia. I heard that Russia got attacked by Ukraine in one region, but I don\'t remember correctly. But of course, I wish Russia canceled war, or shouldn\'t start war at all. #SlavaUkraini', 0, 0, '0', NULL),
('kazka', 'Luka Doncic in a game 1 loss to the Suns: 45/12/8 ', 14, 'Not a bad game from Luka, but the suns still pull through and go up 1-0 in the series\r\n\r\n', 0, 0, '0', NULL),
('Useris2', 'What\'s the best piece of advice you ever received?', 15, 'Never give up. Thats the best advice for me, for you, for everyone.', 0, 0, '0', NULL),
('karpol2', 'Who inspires you to be better?', 16, 'Noone. I focus on my own, i don\'t have anyone to inspire, not really much looking forward to inspire from someone.', 0, 0, '0', NULL),
('Useris2', 'About Lithuania', 17, 'Hello guys, is it worth living in Lithuania? What are situation there?', 0, 0, '1', NULL),
('Useris2', 'fddfsfaadafdda', 35, 'asddddddddddddddddddddddd', 0, 0, '0', NULL),
('Useris2', 'adsssssssssssssssssssssss', 36, 'asddddddddddddddddddddddd', 0, 0, '0', '156');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(5) NOT NULL,
  `name` varchar(15) NOT NULL,
  `currency` int(6) NOT NULL,
  `email` varchar(40) NOT NULL,
  `password` varchar(20) NOT NULL,
  `firstname` varchar(50) DEFAULT NULL,
  `lastname` varchar(255) DEFAULT NULL,
  `mobilenumber` varchar(255) DEFAULT NULL,
  `age` int(11) DEFAULT NULL,
  `specialty` varchar(255) DEFAULT NULL,
  `role` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `currency`, `email`, `password`, `firstname`, `lastname`, `mobilenumber`, `age`, `specialty`, `role`) VALUES
(141, 'karpol2', 120, 'karpol2@gmail.c', 'kentauras', NULL, NULL, NULL, NULL, NULL, NULL),
(153, 'kazka', 448, 'kazka@gmail.com', 'kentauras', NULL, NULL, NULL, NULL, NULL, NULL),
(164, 'kazom', 272, 'kazom@gmail.com', 'kazom123', 'Rimas', 'Valenta', NULL, NULL, 'Ortopedas', 'Doctor'),
(121, 'mykolas', 200, 'mykolas@gmail.c', 'cesnakinis', NULL, NULL, NULL, NULL, NULL, NULL),
(165, 'Names', 0, 'name@gmail.com', 'name123', NULL, NULL, NULL, NULL, NULL, NULL),
(156, 'test55', 4750, 'test55@gmail.co', 'neeeeee', 'Linas', 'Daubaras', NULL, NULL, 'Gastroenterologas', 'Doctor'),
(154, 'testasAI', 326, 'testasAi@gmail.', 'alioo', NULL, NULL, NULL, NULL, NULL, NULL),
(163, 'Testaskarpol2', 300, 'karpolisc@gmail.com', 'ilgasis', NULL, NULL, NULL, NULL, NULL, NULL),
(111, 'useris1', 300, 'useris1@gmail.c', 'kebabas123', NULL, NULL, NULL, NULL, NULL, NULL),
(24, 'Useris2', 14, 'useris2@gmail.com', 'randomizas', '', '', '', NULL, '', ''),
(28, 'Useris4', 20, 'useris4@gmail.c', 'passwordz', NULL, NULL, NULL, NULL, NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `answers`
--
ALTER TABLE `answers`
  ADD PRIMARY KEY (`id`),
  ADD KEY `userio nickas` (`user`),
  ADD KEY `questionai` (`question`);

--
-- Indexes for table `liked`
--
ALTER TABLE `liked`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `questions`
--
ALTER TABLE `questions`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `question` (`question`),
  ADD UNIQUE KEY `doctor` (`doctor`) USING BTREE,
  ADD KEY `userio` (`user`),
  ADD KEY `content` (`content`(1024)),
  ADD KEY `content_3` (`content`(1024)),
  ADD KEY `content_5` (`content`(1024)),
  ADD KEY `fk_doc` (`doc`);
ALTER TABLE `questions` ADD FULLTEXT KEY `content_2` (`content`);
ALTER TABLE `questions` ADD FULLTEXT KEY `content_4` (`content`);

--
-- Indexes for table `questionsq`
--
ALTER TABLE `questionsq`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `question` (`question`),
  ADD KEY `userio` (`user`),
  ADD KEY `content` (`content`(1024)),
  ADD KEY `content_3` (`content`(1024)),
  ADD KEY `content_5` (`content`(1024));
ALTER TABLE `questionsq` ADD FULLTEXT KEY `content_2` (`content`);
ALTER TABLE `questionsq` ADD FULLTEXT KEY `content_4` (`content`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`name`),
  ADD UNIQUE KEY `id` (`id`),
  ADD UNIQUE KEY `firstname` (`firstname`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `answers`
--
ALTER TABLE `answers`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=65;

--
-- AUTO_INCREMENT for table `questions`
--
ALTER TABLE `questions`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=66;

--
-- AUTO_INCREMENT for table `questionsq`
--
ALTER TABLE `questionsq`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `questions`
--
ALTER TABLE `questions`
  ADD CONSTRAINT `fk_doc` FOREIGN KEY (`doc`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `fk_orders_customer` FOREIGN KEY (`user`) REFERENCES `users` (`name`),
  ADD CONSTRAINT `fk_orders_doc` FOREIGN KEY (`doctor`) REFERENCES `users` (`name`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
