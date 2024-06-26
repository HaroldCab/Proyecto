-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-06-2024 a las 19:55:44
-- Versión del servidor: 10.4.28-MariaDB
-- Versión de PHP: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `dbtarea`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tarea`
--

CREATE TABLE `tarea` (
  `Id` int(11) NOT NULL,
  `Titulo` varchar(255) NOT NULL,
  `Descripcion` text DEFAULT NULL,
  `Completada` bit(1) NOT NULL DEFAULT b'0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tarea`
--

INSERT INTO `tarea` (`Id`, `Titulo`, `Descripcion`, `Completada`) VALUES
(1, 'Revisión de Correo Electrónico', 'Chequear y responder a los correos importantes, archivar los mensajes y eliminar el spam.', b'0'),
(2, 'Actualización de Documentos', 'Descripción: Revisar y actualizar los informes, presentaciones y documentos relevantes para los proyectos actuales.', b'0'),
(3, 'Planificación de Reuniones', 'Organizar la agenda para las próximas reuniones, enviar invitaciones y preparar el material necesario.', b'1'),
(4, 'Gestión de Proyectos', 'Supervisar el avance de los proyectos, identificar posibles retrasos y ajustar los planes según sea necesario.', b'0'),
(5, 'Mantenimiento de la Base de Datos', 'Asegurarse de que la base de datos esté actualizada, realizar copias de seguridad y optimizar el rendimiento.', b'1'),
(6, 'Networking Profesional', 'Establecer y mantener contactos profesionales, asistir a eventos de networking y actualizar el perfil de LinkedIn.', b'1'),
(7, 'Desarrollo de Estrategias de Marketing', 'Crear y ejecutar planes de marketing, analizar métricas y ajustar las estrategias según los resultados.', b'1'),
(8, 'Gestión Financiera', 'Revisar los estados financieros, preparar presupuestos y realizar seguimiento de los gastos e ingresos.', b'0'),
(9, 'Capacitación del Personal', 'Organizar sesiones de formación para el equipo, identificar necesidades de capacitación y evaluar el desempeño.', b'1'),
(11, 'Bienestar en el Trabajo', 'Promover actividades de bienestar para los empleados, como pausas activas, talleres de manejo del estrés y eventos de team building.', b'1');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tarea`
--
ALTER TABLE `tarea`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `tarea`
--
ALTER TABLE `tarea`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
