-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02/12/2025 às 12:05
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `bdeduca`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `avalia_instituicao`
--

CREATE TABLE `avalia_instituicao` (
  `id` int(11) NOT NULL,
  `usuario_id` int(11) NOT NULL,
  `instituicao_id` int(11) NOT NULL,
  `nota` int(11) DEFAULT NULL CHECK (`nota` between 1 and 5),
  `comentario` text DEFAULT NULL,
  `data_avaliacao` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `instituicao_selos`
--

CREATE TABLE `instituicao_selos` (
  `id` int(11) NOT NULL,
  `instituicao_id` int(11) NOT NULL,
  `selo_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `instituicoes`
--

CREATE TABLE `instituicoes` (
  `id` int(11) NOT NULL,
  `nome` varchar(255) NOT NULL,
  `rua` varchar(300) DEFAULT NULL,
  `bairro` varchar(300) DEFAULT NULL,
  `numero` char(4) DEFAULT NULL,
  `cidade` varchar(100) DEFAULT NULL,
  `estado` varchar(50) DEFAULT NULL,
  `descricao` text DEFAULT NULL,
  `telefone` varchar(20) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `website` varchar(200) DEFAULT NULL,
  `imagem_url1` varchar(300) DEFAULT NULL,
  `imagem_url2` varchar(300) DEFAULT NULL,
  `imagem_url3` varchar(300) DEFAULT NULL,
  `imagem_url4` varchar(300) DEFAULT NULL,
  `nota` decimal(3,2) DEFAULT 0.00,
  `ativa` tinyint(1) DEFAULT 1,
  `data_cadastro` timestamp NOT NULL DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `instituicoes`
--

INSERT INTO `instituicoes` (`id`, `nome`, `rua`, `bairro`, `numero`, `cidade`, `estado`, `descricao`, `telefone`, `email`, `website`, `imagem_url1`, `imagem_url2`, `imagem_url3`, `imagem_url4`, `nota`, `ativa`, `data_cadastro`) VALUES
(2, 'Colégio Vale Sagrado', 'Avenida Principal', 'Centro', '843', 'Serra Clara', 'MG', 'Excelência acadêmica com valores éticos fortes, preparando cidadãos responsáveis para o futuro.', '(31) 5555-0202', 'secretaria@valesagrado.com.br', 'valesagrado.com.br', 'https://youinjapan.net/otaku-places/gto/gto_seirin_anime.jpg', '', '', '', 4.01, 1, '2025-12-02 12:40:17'),
(8, 'Colégio Lestegrande', 'Rua da Fronteira, 505', 'Vila Leste', '505', 'Campo Grande', 'MS', 'Visão global e preparo para o mundo. Meta: formar alunos com mente aberta e adaptáveis.', '(67) 5555-0808', 'contato@colegioleste.com.br', 'colegioleste.com.br', 'https://i.pinimg.com/originals/6b/f1/81/6bf1812c0bdbc96240d44f41fd95d092.png', '', '', '', 3.65, 1, '2023-08-01 03:00:00'),
(13, 'Preparatório Horizonte Estudantil', 'Rua do Saber, 333', 'Vila Estudantil', '333', 'Novo Leste', 'PE', 'Preparação intensiva para os vestibulares mais difíceis do país. Meta: 100% de aprovação.', '(81) 5555-1313', 'contato@phora.com.br', 'phora.com.br', 'https://i.pinimg.com/736x/0a/0f/cd/0a0fcd9e07aa9102066dcde0850512fb.jpg', '', '', '', 4.20, 1, '2024-01-05 03:00:00'),
(14, 'Colégio Aurora do Leste', 'Avenida Nascente, 444', 'Bairro Oriental', '444', 'Leste Azul', 'ES', 'Ensino médio de qualidade com intercâmbio cultural. Foco em idiomas e visão de mundo.', '(27) 5555-1414', 'secretaria@auroraleste.com.br', 'auroraleste.com.br', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRrbcGHXP99WO_7eY42N5BCHk3LdLH-YLbvVI0uyCJUgeC5SWW41mzhwxGhLXdu8RlYwSU&usqp=CAU', '', '', '', 3.85, 1, '2024-02-14 03:00:00'),
(15, 'Academia Real de Rosetária', 'Praça do Castelo, SN', 'Centro Histórico', '500', 'Reino Valealto', 'SC', 'Tradição e nobreza no ensino. Formação de elite para a administração pública e privada.', '(48) 5555-1515', 'contato@arr.edu.br', 'arr.edu.br', 'https://almaelmacom.wordpress.com/wp-content/uploads/2016/02/tokiwadai_academy.png', '', '', '', 4.30, 1, '2024-03-21 03:00:00'),
(16, 'Colégio Monte Branco', 'Rua da Montanha, 666', 'Alto da Serra', '666', 'Montanha Serena', 'RJ', 'Foco em esportes automobilísticos e engenharia mecânica. Disciplina e velocidade.', '(21) 5555-1616', 'info@montebranco.com.br', 'montebranco.com.br', 'https://cdn.myanimelist.net/s/common/uploaded_files/1456475684-9c7267bc1e3e428b50aedb3b912f62fb.jpeg', '', '', '', 3.60, 1, '2024-04-30 03:00:00'),
(17, 'Preparatório Colina Verde', 'Rua das Palmeiras, 777', 'Colina Verde', '777', 'Colina Norte', 'SP', 'Ambiente acolhedor e familiar para o ensino fundamental e médio. Valores comunitários.', '(11) 5555-1717', 'secretaria@pverde.com.br', 'pverde.com.br', 'https://cdn.myanimelist.net/s/common/uploaded_files/1456471946-b9dff50e9655869b8cbf066860eec1e1.jpeg', '', '', '', 3.70, 1, '2024-05-19 03:00:00'),
(18, 'Universidade Capital do Saber', 'Avenida do Conhecimento, 888', 'Zona Central', '888', 'Brasília', 'DF', 'O principal centro de pesquisa do país. Formação de ponta em todas as áreas do saber.', '(61) 5555-1818', 'reitoria@ucs.edu.br', 'ucs.edu.br', 'https://cdn.myanimelist.net/s/common/uploaded_files/1456471783-b5d3f5b70b782909dff1b9fbb6891be6.jpeg', '', '', '', 4.75, 1, '2024-06-28 03:00:00'),
(19, 'Instituto Municipal Aurora Marinha', 'Rua da Praia, 999', 'Orla', '999', 'Costa Serena', 'CE', 'Educação básica de qualidade para a comunidade local, com foco em biologia marinha.', '(85) 5555-1919', 'contato@imamarinha.org.br', 'imamarinha.org.br', 'https://cdn.myanimelist.net/s/common/uploaded_files/1456471882-44d7fe538a2cdf2cf722f865b0e46c16.jpeg', '', '', '', 3.40, 1, '2024-07-15 03:00:00'),
(20, 'Instituto Sul da Aurora', 'Avenida Sul, 1010', 'Bairro Novo', '1010', 'Cidade Sulmar', 'BA', 'Ambiente descontraído com foco em tecnologia e mídias sociais. Inovação e juventude.', '(71) 5555-2020', 'secretaria@isa.com.br', 'isa.com.br', 'https://pt.quizur.com/_image?href=https%3A%2F%2Fimg.quizur.com%2Ff%2Fimg60adbea68e7589.31411977.jpeg%3FlastEdited%3D1621999275&w=600&h=600&f=webp', '', '', '', 3.50, 1, '2024-08-22 03:00:00'),
(21, 'Instituto Técnico Estadual Neo-Industrial', 'Rua da Fábrica, 1111', 'Distrito Industrial', '1111', 'Neo Capital', 'MG', 'Formação profissionalizante para a indústria 4.0. Especialização técnica de alto nível.', '(31) 5555-2121', 'info@iteni.edu.br', 'iteni.edu.br', 'https://3.bp.blogspot.com/-IcUFWUK6JxM/UbcO-VaM4kI/AAAAAAAAA6I/63zsfDACBJA/s1600/Building+Anime+Landscape+19.png', '', '', '', 4.05, 1, '2024-09-10 03:00:00'),
(22, 'Instituto Flor do Poente', 'Rua do Sol, 1212', 'Jardim Oeste', '1212', 'Jardim Oeste', 'MS', 'Ambiente criativo e artístico. Foco em música, dança e artes visuais.', '(67) 5555-2222', 'contato@ifp.com.br', 'ifp.com.br', 'https://cdnb.artstation.com/p/assets/images/images/047/275/197/large/john-luker-higb-school-ext-final.jpg?1647205816', '', '', '', 3.90, 1, '2024-10-01 03:00:00'),
(23, 'Instituto Brisa Serena', 'Rua do Vento, 1313', 'Vale do Vento', '1313', 'Vale do Vento', 'RS', 'Ambiente calmo e focado no bem-estar mental dos alunos. Meditação e estudos holísticos.', '(51) 5555-2323', 'secretaria@ibrisa.com.br', 'ibrisa.com.br', 'https://opengameart.org/sites/default/files/styles/medium/public/school.png', '', '', '', 3.75, 1, '2024-11-11 03:00:00');

-- --------------------------------------------------------

--
-- Estrutura stand-in para view `ranking_instituicoes`
-- (Veja abaixo para a visão atual)
--
CREATE TABLE `ranking_instituicoes` (
`instituicao_id` int(11)
,`nome_instituicao` varchar(255)
,`media_avaliacoes` decimal(14,4)
,`total_avaliacoes` bigint(21)
);

-- --------------------------------------------------------

--
-- Estrutura para tabela `selos`
--

CREATE TABLE `selos` (
  `id` int(11) NOT NULL,
  `nome` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `tipo`
--

CREATE TABLE `tipo` (
  `id` int(11) NOT NULL,
  `tipo` varchar(40) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `tipo`
--

INSERT INTO `tipo` (`id`, `tipo`) VALUES
(1, 'Administrador'),
(2, 'Usuário Comum'),
(3, 'Moderador');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `id` int(11) NOT NULL,
  `nome` varchar(70) NOT NULL,
  `email` varchar(255) NOT NULL,
  `senha` varchar(260) NOT NULL,
  `tipo_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`id`, `nome`, `email`, `senha`, `tipo_id`) VALUES
(12, 'admin', 'admin@gmail.com', '$2a$13$hTdaDEH0lwFAFHQhlYyBmO5RininQ8uLnYLylwCi.p7Nk2zVp7yUa', 1),
(13, 'Professor', 'professorteste@gmail.com', '$2a$13$ScpNNKv5q1cuePzUo4/pE.QZg6YLx9mG4QIR4AlQbh2ESAVNCAG6a', 2);

-- --------------------------------------------------------

--
-- Estrutura para view `ranking_instituicoes`
--
DROP TABLE IF EXISTS `ranking_instituicoes`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `ranking_instituicoes`  AS SELECT `i`.`id` AS `instituicao_id`, `i`.`nome` AS `nome_instituicao`, avg(`a`.`nota`) AS `media_avaliacoes`, count(`a`.`id`) AS `total_avaliacoes` FROM (`instituicoes` `i` join `avalia_instituicao` `a` on(`i`.`id` = `a`.`instituicao_id`)) GROUP BY `i`.`id`, `i`.`nome` ORDER BY avg(`a`.`nota`) DESC, count(`a`.`id`) DESC ;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `avalia_instituicao`
--
ALTER TABLE `avalia_instituicao`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `usuario_id` (`usuario_id`,`instituicao_id`),
  ADD KEY `instituicao_id` (`instituicao_id`);

--
-- Índices de tabela `instituicao_selos`
--
ALTER TABLE `instituicao_selos`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `instituicao_id` (`instituicao_id`,`selo_id`),
  ADD KEY `selo_id` (`selo_id`);

--
-- Índices de tabela `instituicoes`
--
ALTER TABLE `instituicoes`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `selos`
--
ALTER TABLE `selos`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `tipo`
--
ALTER TABLE `tipo`
  ADD PRIMARY KEY (`id`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`),
  ADD KEY `tipo_id` (`tipo_id`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `avalia_instituicao`
--
ALTER TABLE `avalia_instituicao`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `instituicao_selos`
--
ALTER TABLE `instituicao_selos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `instituicoes`
--
ALTER TABLE `instituicoes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=55;

--
-- AUTO_INCREMENT de tabela `selos`
--
ALTER TABLE `selos`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `tipo`
--
ALTER TABLE `tipo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `avalia_instituicao`
--
ALTER TABLE `avalia_instituicao`
  ADD CONSTRAINT `avalia_instituicao_ibfk_1` FOREIGN KEY (`usuario_id`) REFERENCES `usuarios` (`id`),
  ADD CONSTRAINT `avalia_instituicao_ibfk_2` FOREIGN KEY (`instituicao_id`) REFERENCES `instituicoes` (`id`);

--
-- Restrições para tabelas `instituicao_selos`
--
ALTER TABLE `instituicao_selos`
  ADD CONSTRAINT `instituicao_selos_ibfk_1` FOREIGN KEY (`instituicao_id`) REFERENCES `instituicoes` (`id`),
  ADD CONSTRAINT `instituicao_selos_ibfk_2` FOREIGN KEY (`selo_id`) REFERENCES `selos` (`id`);

--
-- Restrições para tabelas `usuarios`
--
ALTER TABLE `usuarios`
  ADD CONSTRAINT `usuarios_ibfk_1` FOREIGN KEY (`tipo_id`) REFERENCES `tipo` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
