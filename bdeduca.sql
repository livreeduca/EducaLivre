-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 22/10/2025 às 09:36
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
  `numero` char(4) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
(3, 'AiDeMim', 'aidemim@gmail.com', 'admin123', 1),
(4, 'AiDeMinistrador', 'aideministrador@hotmail.com', 'senha123', 3),
(5, 'Aluno Chorão!', 'alunochorador@uol.com.br', 'chorachora', 2),
(6, 'Mãe Preocupada', 'preocupadissimamae@yahoo.com.br', 'preocupa567', 2);

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `instituicoes`
--
ALTER TABLE `instituicoes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

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
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

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
