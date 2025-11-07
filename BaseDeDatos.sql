-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Servidor: mysql:3306
-- Tiempo de generación: 07-11-2025 a las 16:58:27
-- Versión del servidor: 8.0.44
-- Versión de PHP: 8.3.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `appdb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `Id` int NOT NULL,
  `PersonaId` int NOT NULL,
  `Contrasenia` varchar(200) NOT NULL,
  `Estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`Id`, `PersonaId`, `Contrasenia`, `Estado`) VALUES
(1, 1, 'string', 1),
(2, 2, 'string', 1),
(3, 3, 'pepito', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta`
--

CREATE TABLE `cuenta` (
  `Id` int NOT NULL,
  `NumeroCuenta` varchar(50) NOT NULL,
  `ClienteId` int NOT NULL,
  `TipoCuenta` varchar(50) NOT NULL,
  `SaldoInicial` decimal(15,2) NOT NULL DEFAULT '0.00',
  `Estado` tinyint(1) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `cuenta`
--

INSERT INTO `cuenta` (`Id`, `NumeroCuenta`, `ClienteId`, `TipoCuenta`, `SaldoInicial`, `Estado`) VALUES
(1, 'Cuenta 1', 1, 'Ahorro', 2000.00, 1),
(2, 'Cuenta 2', 1, 'Corriente', 2000.00, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `movimiento`
--

CREATE TABLE `movimiento` (
  `Id` int NOT NULL,
  `Fecha` datetime NOT NULL,
  `TipoMovimiento` varchar(50) NOT NULL,
  `Valor` decimal(15,2) NOT NULL DEFAULT '0.00',
  `Saldo` decimal(15,2) NOT NULL DEFAULT '0.00',
  `CuentaId` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `movimiento`
--

INSERT INTO `movimiento` (`Id`, `Fecha`, `TipoMovimiento`, `Valor`, `Saldo`, `CuentaId`) VALUES
(1, '2025-11-07 00:00:00', 'Credito', 10.00, 2010.00, 1),
(2, '2025-11-07 00:00:00', 'Credito', 10.00, 2020.00, 1),
(3, '2025-11-07 16:21:28', 'Debito', -1000.00, 1020.00, 1),
(4, '2025-11-06 00:00:00', 'Credito', 200.00, 1220.00, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE `persona` (
  `Id` int NOT NULL,
  `Nombre` varchar(100) NOT NULL,
  `Genero` varchar(20) NOT NULL,
  `FechaNacimiento` datetime NOT NULL,
  `Identificacion` varchar(50) NOT NULL,
  `Direccion` varchar(200) NOT NULL,
  `Telefono` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Volcado de datos para la tabla `persona`
--

INSERT INTO `persona` (`Id`, `Nombre`, `Genero`, `FechaNacimiento`, `Identificacion`, `Direccion`, `Telefono`) VALUES
(1, 'Juan Jose', 'Masculino', '2025-11-05 21:34:08', '1804569364', 'Patate', 'string'),
(2, 'Carlos Gomez', 'Femenino', '2025-11-05 21:34:08', '1795642365', 'mbato', 'string'),
(3, 'Pedro Pablo ', 'Masculino', '2025-11-07 00:00:00', '1804569364', 'Patate', '0983075722');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Cliente_PersonaId` (`PersonaId`);

--
-- Indices de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Cuenta_ClienteId` (`ClienteId`);

--
-- Indices de la tabla `movimiento`
--
ALTER TABLE `movimiento`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Movimiento_CuentaId` (`CuentaId`);

--
-- Indices de la tabla `persona`
--
ALTER TABLE `persona`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cliente`
--
ALTER TABLE `cliente`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `cuenta`
--
ALTER TABLE `cuenta`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `movimiento`
--
ALTER TABLE `movimiento`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de la tabla `persona`
--
ALTER TABLE `persona`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `FK_Cliente_Persona` FOREIGN KEY (`PersonaId`) REFERENCES `persona` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuenta`
--
ALTER TABLE `cuenta`
  ADD CONSTRAINT `FK_Cuenta_Cliente` FOREIGN KEY (`ClienteId`) REFERENCES `cliente` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `movimiento`
--
ALTER TABLE `movimiento`
  ADD CONSTRAINT `FK_Movimiento_Cuenta` FOREIGN KEY (`CuentaId`) REFERENCES `cuenta` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
