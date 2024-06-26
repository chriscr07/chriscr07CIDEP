USE [master]
GO
/****** Object:  Database [proyectocidep]    Script Date: 4/9/2024 11:10:07 AM ******/
CREATE DATABASE [proyectocidep]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'proyectocidep', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyectocidep.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'proyectocidep_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyectocidep_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [proyectocidep] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [proyectocidep].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [proyectocidep] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [proyectocidep] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [proyectocidep] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [proyectocidep] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [proyectocidep] SET ARITHABORT OFF 
GO
ALTER DATABASE [proyectocidep] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [proyectocidep] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [proyectocidep] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [proyectocidep] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [proyectocidep] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [proyectocidep] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [proyectocidep] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [proyectocidep] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [proyectocidep] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [proyectocidep] SET  ENABLE_BROKER 
GO
ALTER DATABASE [proyectocidep] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [proyectocidep] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [proyectocidep] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [proyectocidep] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [proyectocidep] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [proyectocidep] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [proyectocidep] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [proyectocidep] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [proyectocidep] SET  MULTI_USER 
GO
ALTER DATABASE [proyectocidep] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [proyectocidep] SET DB_CHAINING OFF 
GO
ALTER DATABASE [proyectocidep] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [proyectocidep] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [proyectocidep] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [proyectocidep] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [proyectocidep] SET QUERY_STORE = ON
GO
ALTER DATABASE [proyectocidep] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [proyectocidep]
GO
/****** Object:  Table [dbo].[Asistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencia](
	[ID_Asistencia] [int] IDENTITY(1,1) NOT NULL,
	[ID_Estudiante] [int] NOT NULL,
	[Fecha_Asistencia] [datetime] NULL,
	[ID_Estado] [int] NOT NULL,
	[ID_Clase] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaAdministracion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaAdministracion](
	[ID_AuditoriaAdministracion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaAdministracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaAsistencia](
	[ID_AuditoriaAsistencia] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Asistencia] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaAsistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaAvisosGenerales]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaAvisosGenerales](
	[ID_AuditoriaAvisoGeneral] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_AvisoGeneral] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaAvisoGeneral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaCalificaciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaCalificaciones](
	[ID_AuditoriaCalificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Calificacion] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaCalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaClases]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaClases](
	[ID_AuditoriaClase] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Clase] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaDocentes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaDocentes](
	[ID_AuditoriaDocente] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Docente] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaDocente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaEstudiantes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaEstudiantes](
	[ID_AuditoriaEstudiante] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Estudiante] [int] NOT NULL,
	[Accion] [nvarchar](50) NOT NULL,
	[Detalles] [nvarchar](255) NOT NULL,
	[Fecha_Accion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaEstudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaIniciosSesion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaIniciosSesion](
	[ID_InicioSesion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Exito] [bit] NOT NULL,
	[Detalles] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_InicioSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AvisosGenerales]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AvisosGenerales](
	[ID_AvisoGeneral] [int] IDENTITY(1,1) NOT NULL,
	[Mensaje] [nvarchar](300) NOT NULL,
	[Fecha_Publicacion] [datetime] NOT NULL,
	[Activo] [bit] NOT NULL,
 CONSTRAINT [PK_AvisosGenerales] PRIMARY KEY CLUSTERED 
(
	[ID_AvisoGeneral] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[ID_Calificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Estudiante] [int] NOT NULL,
	[Calificacion] [decimal](5, 2) NOT NULL,
	[FechaCalificacion] [date] NOT NULL,
	[ID_Clase] [int] NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_TipoEvaluacion] [int] NOT NULL,
	[PorcentajeTotal] [decimal](5, 2) NOT NULL,
	[Activo] [bit] NOT NULL,
	[Retroalimentacion] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Calificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clases]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clases](
	[ID_Clase] [int] IDENTITY(1,1) NOT NULL,
	[ID_Curso] [int] NOT NULL,
	[ID_Grado] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Clase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuraciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuraciones](
	[ID_Configuracion] [int] IDENTITY(1,1) NOT NULL,
	[Notificaciones] [bit] NOT NULL,
	[Recordatorios] [bit] NOT NULL,
	[Apariencia] [nvarchar](50) NOT NULL,
	[PoliticaContrasenas] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Configuracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[ID_Curso] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [nvarchar](50) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docentes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docentes](
	[ID_Docente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](20) NOT NULL,
	[SegundoApellido] [nvarchar](20) NOT NULL,
	[ID_Usuario] [int] NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Cedula] UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DocentesClases]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DocentesClases](
	[ID_DocenteClase] [int] IDENTITY(1,1) NOT NULL,
	[ID_Docente] [int] NOT NULL,
	[ID_Clase] [int] NOT NULL,
 CONSTRAINT [PK_DocentesClases] PRIMARY KEY CLUSTERED 
(
	[ID_DocenteClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosAsistencia](
	[ID_Estado] [int] IDENTITY(1,1) NOT NULL,
	[NombreEstado] [nvarchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[ID_Estudiante] [int] IDENTITY(1,1) NOT NULL,
	[Cedula] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](20) NOT NULL,
	[SegundoApellido] [nvarchar](20) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[ID_Usuario] [int] NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_CedulaEstudiantes] UNIQUE NONCLUSTERED 
(
	[Cedula] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstudiantesGrados]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstudiantesGrados](
	[ID_EstudianteGrado] [int] IDENTITY(1,1) NOT NULL,
	[ID_Estudiante] [int] NOT NULL,
	[ID_Grado] [int] NOT NULL,
 CONSTRAINT [PK_EstudiantesGrados] PRIMARY KEY CLUSTERED 
(
	[ID_EstudianteGrado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstudiantesPadres]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstudiantesPadres](
	[ID_EstudiantePadre] [int] IDENTITY(1,1) NOT NULL,
	[ID_Estudiante] [int] NOT NULL,
	[ID_Padre] [int] NOT NULL,
 CONSTRAINT [PK_EstudiantesPadres] PRIMARY KEY CLUSTERED 
(
	[ID_EstudiantePadre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grados]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grados](
	[ID_Grado] [int] IDENTITY(1,1) NOT NULL,
	[NombreGrado] [nvarchar](20) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Grado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IniciosSesion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IniciosSesion](
	[ID_InicioSesion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Exito] [bit] NOT NULL,
	[Detalles] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_InicioSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensajeria]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensajeria](
	[ID_Mensaje] [int] IDENTITY(1,1) NOT NULL,
	[Contenido] [nvarchar](300) NOT NULL,
	[Fecha_Envio] [datetime] NOT NULL,
	[Remitente_ID] [int] NOT NULL,
	[Destinatario_ID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Mensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Padres]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Padres](
	[ID_Padre] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NOT NULL,
	[PrimerApellido] [nvarchar](50) NOT NULL,
	[SegundoApellido] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](150) NULL,
	[Numero] [nvarchar](15) NULL,
 CONSTRAINT [PK_Padres] PRIMARY KEY CLUSTERED 
(
	[ID_Padre] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TiposEvaluaciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TiposEvaluaciones](
	[ID_TipoEvaluacion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](max) NOT NULL,
	[Activo] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_TipoEvaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tokens]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tokens](
	[ID_Token] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[Token] [nvarchar](255) NOT NULL,
	[FechaCreacion] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Token] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [nvarchar](50) NOT NULL,
	[ContrasennaHash] [nvarchar](128) NOT NULL,
	[Salt] [nvarchar](128) NOT NULL,
	[ID_Rol] [int] NOT NULL,
	[Activo] [bit] NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [UQ_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD FOREIGN KEY([ID_Clase])
REFERENCES [dbo].[Clases] ([ID_Clase])
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Estudiantes] ([ID_Estudiante])
GO
ALTER TABLE [dbo].[Asistencia]  WITH CHECK ADD FOREIGN KEY([ID_Estado])
REFERENCES [dbo].[EstadosAsistencia] ([ID_Estado])
GO
ALTER TABLE [dbo].[AuditoriaAdministracion]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaAsistencia]  WITH CHECK ADD FOREIGN KEY([ID_Asistencia])
REFERENCES [dbo].[Asistencia] ([ID_Asistencia])
GO
ALTER TABLE [dbo].[AuditoriaAsistencia]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaAvisosGenerales]  WITH CHECK ADD  CONSTRAINT [FK__Auditoria__Avisos] FOREIGN KEY([ID_AvisoGeneral])
REFERENCES [dbo].[AvisosGenerales] ([ID_AvisoGeneral])
GO
ALTER TABLE [dbo].[AuditoriaAvisosGenerales] CHECK CONSTRAINT [FK__Auditoria__Avisos]
GO
ALTER TABLE [dbo].[AuditoriaAvisosGenerales]  WITH CHECK ADD  CONSTRAINT [FK__Auditoria__Usuarios] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaAvisosGenerales] CHECK CONSTRAINT [FK__Auditoria__Usuarios]
GO
ALTER TABLE [dbo].[AuditoriaCalificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Calificacion])
REFERENCES [dbo].[Calificaciones] ([ID_Calificacion])
GO
ALTER TABLE [dbo].[AuditoriaCalificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaClases]  WITH CHECK ADD FOREIGN KEY([ID_Clase])
REFERENCES [dbo].[Clases] ([ID_Clase])
GO
ALTER TABLE [dbo].[AuditoriaClases]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaDocentes]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaDocentes_Docentes] FOREIGN KEY([ID_Docente])
REFERENCES [dbo].[Docentes] ([ID_Docente])
GO
ALTER TABLE [dbo].[AuditoriaDocentes] CHECK CONSTRAINT [FK_AuditoriaDocentes_Docentes]
GO
ALTER TABLE [dbo].[AuditoriaDocentes]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaDocentes_Usuarios] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaDocentes] CHECK CONSTRAINT [FK_AuditoriaDocentes_Usuarios]
GO
ALTER TABLE [dbo].[AuditoriaEstudiantes]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaEstudiantes_Estudiantes] FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Estudiantes] ([ID_Estudiante])
GO
ALTER TABLE [dbo].[AuditoriaEstudiantes] CHECK CONSTRAINT [FK_AuditoriaEstudiantes_Estudiantes]
GO
ALTER TABLE [dbo].[AuditoriaEstudiantes]  WITH CHECK ADD  CONSTRAINT [FK_AuditoriaEstudiantes_Usuarios] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[AuditoriaEstudiantes] CHECK CONSTRAINT [FK_AuditoriaEstudiantes_Usuarios]
GO
ALTER TABLE [dbo].[AuditoriaIniciosSesion]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Estudiantes] ([ID_Estudiante])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([ID_TipoEvaluacion])
REFERENCES [dbo].[TiposEvaluaciones] ([ID_TipoEvaluacion])
GO
ALTER TABLE [dbo].[Clases]  WITH CHECK ADD FOREIGN KEY([ID_Curso])
REFERENCES [dbo].[Cursos] ([ID_Curso])
GO
ALTER TABLE [dbo].[Clases]  WITH CHECK ADD FOREIGN KEY([ID_Grado])
REFERENCES [dbo].[Grados] ([ID_Grado])
GO
ALTER TABLE [dbo].[Docentes]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[DocentesClases]  WITH CHECK ADD FOREIGN KEY([ID_Clase])
REFERENCES [dbo].[Clases] ([ID_Clase])
GO
ALTER TABLE [dbo].[DocentesClases]  WITH CHECK ADD FOREIGN KEY([ID_Docente])
REFERENCES [dbo].[Docentes] ([ID_Docente])
GO
ALTER TABLE [dbo].[Estudiantes]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[EstudiantesGrados]  WITH CHECK ADD FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Estudiantes] ([ID_Estudiante])
GO
ALTER TABLE [dbo].[EstudiantesGrados]  WITH CHECK ADD FOREIGN KEY([ID_Grado])
REFERENCES [dbo].[Grados] ([ID_Grado])
GO
ALTER TABLE [dbo].[EstudiantesPadres]  WITH CHECK ADD  CONSTRAINT [FK_EstudiantesPadres_Estudiantes] FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Estudiantes] ([ID_Estudiante])
GO
ALTER TABLE [dbo].[EstudiantesPadres] CHECK CONSTRAINT [FK_EstudiantesPadres_Estudiantes]
GO
ALTER TABLE [dbo].[EstudiantesPadres]  WITH CHECK ADD  CONSTRAINT [FK_EstudiantesPadres_Padres] FOREIGN KEY([ID_Padre])
REFERENCES [dbo].[Padres] ([ID_Padre])
GO
ALTER TABLE [dbo].[EstudiantesPadres] CHECK CONSTRAINT [FK_EstudiantesPadres_Padres]
GO
ALTER TABLE [dbo].[IniciosSesion]  WITH CHECK ADD  CONSTRAINT [FK_IniciosSesion_Usuarios] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[IniciosSesion] CHECK CONSTRAINT [FK_IniciosSesion_Usuarios]
GO
ALTER TABLE [dbo].[Mensajeria]  WITH CHECK ADD FOREIGN KEY([Destinatario_ID])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Mensajeria]  WITH CHECK ADD FOREIGN KEY([Remitente_ID])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Tokens]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Roles] ([ID_Rol])
GO
/****** Object:  StoredProcedure [dbo].[BorrarAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarAsistencia]
    @ID_Asistencia INT,
    @RolUsuario INT,
	 @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario IN (1, 2)
        BEGIN
            UPDATE Asistencia
            SET Activo = 0
            WHERE ID_Asistencia = @ID_Asistencia;

            INSERT INTO AuditoriaAsistencia (ID_Usuario, ID_Asistencia, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario, @ID_Asistencia, 'Borrado ', 'Elimina registro asistencia ', GETDATE());

            COMMIT TRANSACTION;
        END
        ELSE
        BEGIN
            THROW 50001, 'Accion no atorizada', 2;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW 50001, 'Acción no autorizada', 2;

    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarAvisoGeneral]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BorrarAvisoGeneral]
    @ID_AvisoGeneral INT,
    @RolUsuario INT,
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        
        IF @RolUsuario = 1 -- Usuario Administrador
        BEGIN
            DECLARE @Activo BIT;

            -- Verificar si el aviso general está activo
            SELECT @Activo = Activo
            FROM AvisosGenerales
            WHERE ID_AvisoGeneral = @ID_AvisoGeneral;

            IF @Activo IS NOT NULL AND @Activo = 1
            BEGIN
                -- Desactivar el aviso general
                UPDATE AvisosGenerales
                SET Activo = 0
                WHERE ID_AvisoGeneral = @ID_AvisoGeneral;

                -- Registrar en la tabla de auditoría
                INSERT INTO AuditoriaAvisosGenerales (ID_Usuario, ID_AvisoGeneral, Accion, Detalles, Fecha_Accion)
                VALUES (@ID_Usuario, @ID_AvisoGeneral, 'Borrado', 'Eliminado aviso general', GETDATE());

                COMMIT TRANSACTION;
				RETURN 1;
            END
            ELSE
            BEGIN
                ROLLBACK TRANSACTION;
                THROW 50001, 'El aviso general no está activo o no existe', 1;
            END
        END
        ELSE
        BEGIN
            ROLLBACK TRANSACTION;
            THROW 50001, 'Acción no autorizada', 1;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarCalificacion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarCalificacion]
    @ID_Calificacion INT,
    @ID_Usuario INT
AS
BEGIN
    -- Declarar variables para almacenar detalles antes de eliminar
    DECLARE @Calificacion DECIMAL(5,2);
    DECLARE @ID_Estudiante INT;
    DECLARE @FechaCalificacion DATETIME;
    DECLARE @NombreCurso NVARCHAR(255);
    DECLARE @TipoEvaluacion NVARCHAR(255);

    -- Verificar el rol de usuario
    IF NOT EXISTS (SELECT 1 FROM Usuarios WHERE ID_Usuario = @ID_Usuario AND ID_Rol IN (1, 2))
    BEGIN
        THROW 50001, 'No autorizado', 2;
        RETURN;
    END

    -- Obtener detalles antes de eliminar
    SELECT 
        @Calificacion = c.Calificacion,
        @ID_Estudiante = c.ID_Estudiante,
        @FechaCalificacion = c.FechaCalificacion,
        @NombreCurso = cu.NombreCurso,
        @TipoEvaluacion = te.Descripcion
    FROM 
        Calificaciones c
    INNER JOIN 
        Clases cl ON c.ID_Clase = cl.ID_Clase
	INNER JOIN Cursos cu ON cu.ID_Curso = cl.ID_Curso
    INNER JOIN 
        TiposEvaluaciones te ON c.ID_TipoEvaluacion = te.ID_TipoEvaluacion
    WHERE 
        c.ID_Calificacion = @ID_Calificacion;

    -- Iniciar transacción
    BEGIN TRANSACTION;

    -- Marcar la calificación como eliminada
    UPDATE Calificaciones SET Activo = 0 WHERE ID_Calificacion = @ID_Calificacion;

    -- Insertar en la tabla de auditoría
    INSERT INTO AuditoriaCalificaciones (ID_Usuario, ID_Calificacion, Accion, Detalles, Fecha_Accion)
    VALUES (@ID_Usuario, @ID_Calificacion, 'Eliminación', 'Elimina nota ' + @NombreCurso + ' estudiante ced ' + ISNULL((SELECT Cedula FROM Estudiantes WHERE ID_Estudiante = @ID_Estudiante), ''), GETDATE());

    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarClase]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarClase]
    @ID_Clase INT,
    @RolUsuario INT,
	 @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            UPDATE Clases
            SET activo = 0
            WHERE ID_Clase = @ID_Clase;

            INSERT INTO AuditoriaClases (ID_Usuario, ID_Clase, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario, @ID_Clase, 'Borrado ', 'Elimina clase ', GETDATE());

            COMMIT TRANSACTION;
        END
        ELSE
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50001, 'Accion no atorizada', 1;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW 50001, 'Accion fallida', 2;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarDocente]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[BorrarDocente]
    @ID_Docente INT,
    @RolUsuario INT,
	 @ID_UsuarioQueElimina INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            UPDATE Docentes
            SET activo = 0
            WHERE ID_Docente = @ID_Docente;

            INSERT INTO AuditoriaDocentes (ID_Usuario, ID_Docente, Accion, Detalles, Fecha_Accion)
			VALUES (@ID_UsuarioQueElimina, @ID_Docente, 'Borrado ', 'Se elimina docente con CED ' + (SELECT CEDULA FROM Docentes WHERE ID_Docente = @ID_Docente ), GETDATE());

            COMMIT TRANSACTION;
			RETURN 1;
        END
        ELSE
        BEGIN
            THROW 50001, 'Accion no atorizada', 2;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW 50001, 'Accion fallida', 2;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarEstadoAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[BorrarEstadoAsistencia]
    @ID_Estado INT,
    @RolUsuario INT,
	 @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            UPDATE EstadosAsistencia
            SET activo = 0
            WHERE ID_Estado = @ID_Estado;

			DECLARE @NombreEstado NVARCHAR(20);
			SET @NombreEstado = (SELECT NombreEstado FROM EstadosAsistencia WHERE ID_Estado = @ID_Estado);

             -- Insertar en la tabla de auditoría
            INSERT INTO AuditoriaAdministracion(ID_Usuario, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario,'Desactiva', 'Se desactiva estado de asistencia' + @NombreEstado, GETDATE());

            COMMIT TRANSACTION;
        END
        ELSE
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50001, 'Accion no atorizada', 1;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW 50001, 'Accion fallida', 2;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarEstudiante]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[BorrarEstudiante]
    @ID_Estudiante INT,
    @RolUsuario INT,
	 @ID_UsuarioQueElimina INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            UPDATE Estudiantes
            SET activo = 0
            WHERE ID_Estudiante = @ID_Estudiante;

            INSERT INTO AuditoriaEstudiantes (ID_Usuario, ID_Estudiante, Accion, Detalles, Fecha_Accion)
			VALUES (@ID_UsuarioQueElimina, @ID_Estudiante, 'Borrado ', 'Se elimina estudiante con CED ' + (SELECT CEDULA FROM ESTUDIANTES WHERE ID_ESTUDIANTE = @ID_Estudiante ), GETDATE());

            COMMIT TRANSACTION;
			RETURN 1;
        END
        ELSE
        BEGIN
            THROW 50001, 'Accion no atorizada', 2;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW 50001, 'Accion fallida', 2;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarUsuario]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarUsuario]
    @ID_Usuario INT,
    @RolUsuario INT,
	 @ID_UsuarioQueElimina INT
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            UPDATE Usuarios
            SET activo = 0
            WHERE ID_Usuario = @ID_Usuario;

            INSERT INTO AuditoriaAdministracion (ID_Usuario, Accion, Detalles, Fecha_Accion)
			VALUES (@ID_UsuarioQueElimina, 'Borrado ', 'Se elimina usuario con ID ' + CAST(@ID_Usuario AS NVARCHAR(10)), GETDATE());

            COMMIT TRANSACTION;
			RETURN 1;
        END
        ELSE
        BEGIN
            THROW 50001, 'Accion no atorizada', 2;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW 50001, 'Accion fallida', 2;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[BuscarInformacionUsuario]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BuscarInformacionUsuario]
    @ID_Usuario INT
AS
BEGIN
    SET NOCOUNT ON;

    -- Buscar en la tabla de docentes
    DECLARE @ID_Docente INT;
    DECLARE @NombreDocente NVARCHAR(50);
    DECLARE @CedulaDocente NVARCHAR(50);
    DECLARE @PrimerApellidoDocente NVARCHAR(20);
    DECLARE @SegundoApellidoDocente NVARCHAR(20);

    SELECT @ID_Docente = ID_Docente,
           @NombreDocente = Nombre,
           @CedulaDocente = Cedula,
           @PrimerApellidoDocente = PrimerApellido,
           @SegundoApellidoDocente = SegundoApellido
    FROM Docentes
    WHERE ID_Usuario = @ID_Usuario;

    -- Si es docente, devolver la información
    IF @ID_Docente IS NOT NULL
    BEGIN
        SELECT @ID_Docente AS ID,
               @NombreDocente AS Nombre,
               @CedulaDocente AS Cedula,
               @PrimerApellidoDocente AS PrimerApellido,
               @SegundoApellidoDocente AS SegundoApellido,
               'Docente' AS Rol;
        RETURN;
    END;

    -- Si no es docente, buscar en la tabla de estudiantes
    DECLARE @ID_Estudiante INT;
    DECLARE @NombreEstudiante NVARCHAR(50);
    DECLARE @CedulaEstudiante NVARCHAR(50);
    DECLARE @PrimerApellidoEstudiante NVARCHAR(20);
    DECLARE @SegundoApellidoEstudiante NVARCHAR(20);

    SELECT @ID_Estudiante = ID_Estudiante,
           @NombreEstudiante = Nombre,
           @CedulaEstudiante = Cedula,
           @PrimerApellidoEstudiante = PrimerApellido,
           @SegundoApellidoEstudiante = SegundoApellido
    FROM Estudiantes
    WHERE ID_Usuario = @ID_Usuario;

    -- Si es estudiante, devolver la información
    IF @ID_Estudiante IS NOT NULL
    BEGIN
        SELECT @ID_Estudiante AS ID,
               @NombreEstudiante AS Nombre,
               @CedulaEstudiante AS Cedula,
               @PrimerApellidoEstudiante AS PrimerApellido,
               @SegundoApellidoEstudiante AS SegundoApellido,
               'Estudiante' AS Rol;
        RETURN;
    END;

    -- Si no se encontró en ninguna tabla, devolver un mensaje de error
    SELECT 'Usuario no encontrado en las tablas de docentes y estudiantes.' AS Mensaje;
END;
GO
/****** Object:  StoredProcedure [dbo].[CambiarContrasenna]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CambiarContrasenna]
    @ID_Usuario INT,
    @ContrasennaActual NVARCHAR(100),
    @NuevaContrasenna NVARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @ContrasennaHash NVARCHAR(100);
    DECLARE @Salt NVARCHAR(128);

    SELECT @ContrasennaHash = ContrasennaHash, @Salt = Salt
    FROM Usuarios
    WHERE ID_Usuario = @ID_Usuario;

    IF @ContrasennaHash IS NOT NULL AND HASHBYTES('SHA2_512', CONCAT(@ContrasennaActual, @Salt)) = @ContrasennaHash
    BEGIN

        DECLARE @NuevoSalt NVARCHAR(128);
        EXEC GenerarSalt @NuevoSalt OUTPUT;
        DECLARE @NuevaContrasennaSalt NVARCHAR(228);
        SET @NuevaContrasennaSalt = @NuevaContrasenna + @NuevoSalt;


        DECLARE @NuevoHash NVARCHAR(128);
        SET @NuevoHash = HASHBYTES('SHA2_512', @NuevaContrasennaSalt);

        UPDATE Usuarios
        SET ContrasennaHash = @NuevoHash,
            Salt = @NuevoSalt
        WHERE ID_Usuario = @ID_Usuario;

        COMMIT TRANSACTION;

        SELECT 'Contraseña actualizada correctamente.' AS Mensaje;
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        SELECT 'Contraseña incorrecta.' AS Mensaje;
    END;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearAsistencia]
    @ID_Estudiante INT,
    @ID_Estado INT,
    @ID_Clase INT,
	@Fecha_Asistencia DATE,
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Insertar la asistencia
        INSERT INTO Asistencia (ID_Estudiante, ID_Estado, ID_Clase, Fecha_Asistencia, Activo)
        VALUES (@ID_Estudiante, @ID_Estado, @ID_Clase, GETDATE(), 1);

        -- Obtener el ID de la asistencia insertada
        DECLARE @ID_Asistencia INT;
        SET @ID_Asistencia = SCOPE_IDENTITY();

        -- Obtener el estado de la asistencia
        DECLARE @EstadoAsistencia NVARCHAR(20);
        SELECT @EstadoAsistencia = NombreEstado FROM EstadosAsistencia WHERE ID_Estado = @ID_Estado;

        -- Insertar en AuditoriaAsistencia
        INSERT INTO AuditoriaAsistencia (ID_Usuario, ID_Asistencia, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, @ID_Asistencia, 'Registro ', 'asistencia ' + @EstadoAsistencia + ' alumno ' + 
        (SELECT Cedula FROM Estudiantes WHERE ID_Estudiante = @ID_Estudiante), GETDATE());

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        RETURN 0; 
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearAvisoGeneral]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearAvisoGeneral]
    @Mensaje NVARCHAR(300),
    @ID_Usuario INT 
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Insertar el aviso general
        INSERT INTO AvisosGenerales (Mensaje, Fecha_Publicacion, Activo)
        VALUES (@Mensaje, GETDATE(), 1);

        -- Obtener el ID del aviso insertado
        DECLARE @ID_AvisoGeneral INT;
        SELECT @ID_AvisoGeneral = SCOPE_IDENTITY();

        -- Insertar en la tabla AuditoriaAvisosGenerales
        INSERT INTO AuditoriaAvisosGenerales (ID_Usuario, ID_AvisoGeneral, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, @ID_AvisoGeneral, 'Registro', 'Se registra un aviso general', GETDATE());

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        RETURN 0; 
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearCalificacion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCalificacion]
    @ID_Estudiante INT,
    @ID_Clase INT,
    @Calificacion DECIMAL(5,2),
    @ID_TipoEvaluacion INT,
    @ID_Usuario INT,
    @Porcentaje DECIMAL(5,2),
    @Retroalimentacion NVARCHAR(150)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Agregar registro de calificación
        INSERT INTO Calificaciones (ID_Estudiante, ID_Clase, ID_Usuario, Calificacion, ID_TipoEvaluacion, FechaCalificacion, PorcentajeTotal, Retroalimentacion, Activo)
        VALUES (@ID_Estudiante, @ID_Clase, @ID_Usuario, @Calificacion, @ID_TipoEvaluacion, GETDATE(), @Porcentaje, @Retroalimentacion, 1);
        -- ID calificación insertada
        DECLARE @ID_Calificacion INT;
        SET @ID_Calificacion = SCOPE_IDENTITY();

        -- Nombre curso
        DECLARE @NombreCurso NVARCHAR(255);
        SELECT @NombreCurso = c.NombreCurso FROM Cursos c JOIN Clases cl ON c.ID_Curso = cl.ID_Curso WHERE @ID_Clase = @ID_Clase;

        -- Insertar en la tabla AuditoriaCalificaciones
        INSERT INTO AuditoriaCalificaciones (ID_Usuario, ID_Calificacion, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, @ID_Calificacion, 'Registro', 'Calificación ' + CONVERT(NVARCHAR(7), @Calificacion) + ' en ' + 
		@NombreCurso + ' para el alumno cedula: ' + (SELECT Cedula FROM Estudiantes WHERE ID_Estudiante = @ID_Estudiante),
		GETDATE());
        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        RETURN 0; 
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearClase]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearClase]
    @ID_Curso INT,
    @ID_Grado INT,
    @ID_Usuario INT,
	@RolUsuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            -- Insertar la clase
            INSERT INTO Clases (ID_Curso, ID_Grado, Activo)
            VALUES (@ID_Curso, @ID_Grado, 1);

			-- ID calificación insertada
			DECLARE @ID_Clase INT;
			SET @ID_Clase = SCOPE_IDENTITY();

            -- Insertar en la tabla AuditoriaClases
            INSERT INTO AuditoriaClases (ID_Usuario, ID_Clase, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario, @ID_Clase,'Registro', 'Se registra clase con ID_Curso: ' + CAST(@ID_Curso AS NVARCHAR(10)) + ' y ID_Grado: ' +  
			CAST(@ID_Grado AS NVARCHAR(10)), GETDATE());

            COMMIT TRANSACTION;
            RETURN 1; 
        END
        ELSE
        BEGIN
            THROW 50001, 'Accion no atorizada', 1;
            RETURN 0; 
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        RETURN 0; -- Operación fallida
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearCurso]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearCurso]
    @NombreCurso NVARCHAR(50),
	@RolUsuario INT,
	@ID_Usuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            -- Insertar curso
            INSERT INTO Cursos (NombreCurso, Activo)
            VALUES (@NombreCurso, 1);

			-- ID calificación insertada
			DECLARE @ID_Curso INT;
			SET @ID_Curso = SCOPE_IDENTITY();

            -- Insertar en la tabla AuditoriaClases
            INSERT INTO AuditoriaAdministracion (ID_Usuario, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario, 'Registro curso', 'Creación curso ' + CAST(@ID_Curso AS NVARCHAR(10))  + ' ' + @NombreCurso, GETDATE());

            COMMIT TRANSACTION;
            RETURN 1; 
        END
        ELSE
        BEGIN
            THROW 50001, 'Accion no atorizada', 1;
            RETURN 0; 
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        RETURN 0; -- Operación fallida
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearDocente]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearDocente]
    @Cedula NVARCHAR(20),
    @Nombre NVARCHAR(50),
    @PrimerApellido NVARCHAR(20),
    @SegundoApellido NVARCHAR(20),
    @FechaNacimiento DATE,
    @ID_Usuario INT = NULL,
    @RolUsuario INT,
	@ID_UsuarioQueInserta INT
AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY;
			IF @RolUsuario <> 1
				BEGIN
					ROLLBACK TRANSACTION;
					THROW 50001, 'Usuario no autorizado', 1;
				END

			IF EXISTS (SELECT 1 FROM Docentes WITH (UPDLOCK) WHERE Cedula = @Cedula)
				BEGIN
					ROLLBACK TRANSACTION;
					THROW 50002, 'Docente ya existe', 1;
				END

			INSERT INTO Docentes (Cedula, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, ID_Usuario, Activo)
			VALUES (@Cedula, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @ID_Usuario, 1);

			-- Obtener el ID del estudiante recién insertado
			DECLARE @ID_Docente INT;
			SET @ID_Docente = SCOPE_IDENTITY();

			-- Insertar en la tabla de auditoría de estudiantes
			INSERT INTO AuditoriaDocentes (ID_Usuario, ID_Docente, Accion, Detalles, Fecha_Accion)
			VALUES (@ID_UsuarioQueInserta, @ID_Docente, 'Registro', 'Se registra docente con Cédula ' + @Cedula, GETDATE());

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY

    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        RETURN ERROR_NUMBER();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearEstadoAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearEstadoAsistencia]
    @NombreEstado NVARCHAR(20),
    @ID_Usuario INT,
	@RolUsuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario = 1
        BEGIN
            -- Insertar estado de asistencia
            INSERT INTO EstadosAsistencia(NombreEstado, Activo)
            VALUES (@NombreEstado, 1);

            -- Insertar en la tabla Auditoria
            INSERT INTO AuditoriaAdministracion(ID_Usuario, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario,'Registro', 'Se registra estado de asistencia ' + @NombreEstado, GETDATE());

            COMMIT TRANSACTION;
            RETURN 1; 
        END
        ELSE
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50001, 'Accion no atorizada', 1;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
			RETURN ERROR_NUMBER();
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearEstudiante]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearEstudiante]
    @Cedula NVARCHAR(20),
    @Nombre NVARCHAR(50),
    @PrimerApellido NVARCHAR(20),
    @SegundoApellido NVARCHAR(20),
    @FechaNacimiento DATE,
    @ID_Usuario INT = NULL,
    @RolUsuario INT,
	@ID_UsuarioQueInserta INT
AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY;

        IF @RolUsuario <> 1
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50001, 'Usuario no autorizado', 1;
        END

        IF EXISTS (SELECT 1 FROM Estudiantes WITH (UPDLOCK) WHERE Cedula = @Cedula)
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50002, 'Estudiante ya existe', 1;
        END

        INSERT INTO Estudiantes (Cedula, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, ID_Usuario, Activo)
        VALUES (@Cedula, @Nombre, @PrimerApellido, @SegundoApellido, @FechaNacimiento, @ID_Usuario, 1);

        -- Obtener el ID del estudiante recién insertado
        DECLARE @ID_Estudiante INT;
        SET @ID_Estudiante = SCOPE_IDENTITY();

        -- Insertar en la tabla de auditoría de estudiantes
        INSERT INTO AuditoriaEstudiantes (ID_Usuario, ID_Estudiante, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_UsuarioQueInserta, @ID_Estudiante, 'Registro', 'Se registra estudiante con Cédula ' + @Cedula, GETDATE());

        COMMIT TRANSACTION;

        RETURN 1; 
    END TRY

    BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION;
		END

		-- Lanzar el error original al cliente
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrorState INT = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH

END;
GO
/****** Object:  StoredProcedure [dbo].[CrearGrado]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearGrado]
    @NombreGrado NVARCHAR(50),
	@RolUsuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        IF @RolUsuario <> 1
        BEGIN
            THROW 50001, 'Usuario no autorizado', 2;
        END
        INSERT INTO [dbo].[Grados] (NombreGrado, Activo)
        VALUES (@NombreGrado, 1);
        COMMIT TRANSACTION;

        RETURN 1; 
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        RETURN ERROR_NUMBER(); 
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearPadre]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[CrearPadre]
    @Nombre NVARCHAR(50),
    @PrimerApellido NVARCHAR(20),
    @SegundoApellido NVARCHAR(20),
	@Email NVARCHAR(150),
	@Numero NVARCHAR(15),
    @RolUsuario INT,
	@ID_UsuarioQueInserta INT
AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY;

        IF @RolUsuario <> 1
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50001, 'Usuario no autorizado', 1;
        END

        IF EXISTS (SELECT 1 FROM Padres WITH (UPDLOCK) WHERE Nombre = @Nombre AND
		PrimerApellido = @PrimerApellido AND SegundoApellido = @SegundoApellido)
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50002, 'Padre ya existe', 1;
        END

        INSERT INTO Padres (Nombre, PrimerApellido, SegundoApellido, Email, Numero)
        VALUES (@Nombre, @PrimerApellido, @SegundoApellido, @Email, @Numero);

        -- Insertar en la tabla de auditoría de estudiantes
        INSERT INTO AuditoriaAdministracion(ID_Usuario, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_UsuarioQueInserta, 'Registro', 'Se registra padre ' + @Nombre + ' ' + @PrimerApellido + ' ' + @SegundoApellido, GETDATE());

        COMMIT TRANSACTION;

        RETURN 1; 
    END TRY

    BEGIN CATCH
		IF @@TRANCOUNT > 0
		BEGIN
			ROLLBACK TRANSACTION;
		END

		-- Lanzar el error original al cliente
		DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
		DECLARE @ErrorSeverity INT = ERROR_SEVERITY();
		DECLARE @ErrorState INT = ERROR_STATE();
		RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
	END CATCH

END;
GO
/****** Object:  StoredProcedure [dbo].[CrearTipoEvaluacion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearTipoEvaluacion]
    @Descripcion NVARCHAR(50),
	@RolUsuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF @RolUsuario <> 1
        BEGIN
            THROW 50001, 'Usuario no autorizado', 2;
        END

        INSERT INTO [dbo].[TiposEvaluaciones] (Descripcion, Activo)
        VALUES (@Descripcion, 1);

        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        RETURN ERROR_NUMBER(); 
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearUsuario]
    @Nombre_Usuario NVARCHAR(50),
    @ID_RolUsuarioNuevo INT,
    @Email NVARCHAR(150),
    @ID_Rol INT, --rol del usuario que está creando el usuario
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRANSACTION
        BEGIN TRY;

        -- Verificar si el usuario tiene permiso para crear usuarios
        IF @ID_Rol <> 1
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50001, 'No autorizado', 2;
        END

        -- Verificar si el nombre de usuario ya existe
        IF EXISTS (SELECT 1 FROM Usuarios WHERE Nombre_Usuario = @Nombre_Usuario)
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50002, 'El nombre de usuario ya existe', 2;
        END

        -- Verificar si el correo electrónico ya existe (ignorar mayúsculas y minúsculas)
        IF EXISTS (SELECT 1 FROM Usuarios WHERE LOWER(Email) = LOWER(@Email))
        BEGIN
			ROLLBACK TRANSACTION;
            THROW 50003, 'El correo electrónico ya está registrado', 2;
        END

		-- Generar una contraseña aleatoria
		DECLARE @Contrasenna NVARCHAR(100);
		EXEC GenerarContrasennaAleatoria @Contrasenna OUTPUT;


        DECLARE @Salt NVARCHAR(128);
        EXEC GenerarSalt @Salt OUTPUT;
        DECLARE @ContrasennaSalt NVARCHAR(228);
        SET @ContrasennaSalt = @Contrasenna + @Salt;
        DECLARE @Hash NVARCHAR(128);
        SET @Hash = HASHBYTES('SHA2_512', @ContrasennaSalt);

        -- Insertar el nuevo usuario en la tabla Usuarios
        INSERT INTO Usuarios (Nombre_Usuario, ContrasennaHash, Salt, ID_Rol, Activo, Email)
        VALUES (@Nombre_Usuario, @Hash, @Salt, @ID_RolUsuarioNuevo, 1, @Email);

        -- Insertar en la tabla AuditoriaAdministracion
        INSERT INTO AuditoriaAdministracion (ID_Usuario, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, 'Creación de usuario', 'Usuario creado: ' + @Nombre_Usuario, GETDATE());

        COMMIT TRANSACTION;
        RETURN 1; -- Operación exitosa
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        -- Insertar en la tabla AuditoriaAdministracion (error)
        INSERT INTO AuditoriaAdministracion (ID_Usuario, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, 'Error en creación de usuario', ERROR_MESSAGE(), GETDATE());

        RETURN ERROR_NUMBER(); 
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuarioAdmin]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearUsuarioAdmin]
    @Nombre_Usuario NVARCHAR(50),
    @Contrasenna NVARCHAR(100),
    @ID_RolUsuarioNuevo INT,
	@Email NVARCHAR(150),
    @ID_Rol INT --rol del usuario que está creando el usuario
AS
BEGIN
    -- Verificar si el nombre de usuario ya existe
    IF EXISTS (SELECT 1 FROM Usuarios WHERE Nombre_Usuario = @Nombre_Usuario)
    BEGIN
        -- El nombre de usuario ya está en uso
        RETURN 3;
    END
    
    -- Verificar si el rol del usuario es administrador
    IF @ID_Rol != 1
    BEGIN
        -- No tiene permiso para realizar esta acción
        RETURN 2;
    END
    
    -- Generar salt aleatorio
    DECLARE @Salt NVARCHAR(128);
    EXEC GenerarSalt @Salt OUTPUT;
    
    -- Concatenar la contraseña con el salt
    DECLARE @ContrasennaSalt NVARCHAR(228);
    SET @ContrasennaSalt = @Contrasenna + @Salt;
    
    -- Calcular el hash de la contraseña
    DECLARE @Hash NVARCHAR(128);
    SET @Hash = HASHBYTES('SHA2_512', @ContrasennaSalt);
    
    -- Insertar el nuevo usuario en la tabla Usuarios
    INSERT INTO Usuarios (Nombre_Usuario, ContrasennaHash, Salt, ID_Rol, Activo, Email)
    VALUES (@Nombre_Usuario, @Hash, @Salt, @ID_RolUsuarioNuevo, 1, @Email);
    
    -- Usuario creado exitosamente
    RETURN 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarAsistencia]
    @ID_Asistencia INT,
    @ID_Estudiante INT,
    @ID_Estado INT,
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Usuario = @ID_Usuario AND ID_Rol != 3) 
        BEGIN
            -- Actualizar la asistencia
            UPDATE Asistencia
            SET ID_Estado = @ID_Estado
            WHERE ID_Asistencia = @ID_Asistencia;

            -- Insertar en la tabla de auditoría
            INSERT INTO AuditoriaAsistencia (ID_Usuario, ID_Asistencia, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario, @ID_Asistencia, 'Edición', 'Edición de asistencia del estudiante ' + CAST(@ID_Estudiante AS NVARCHAR(10)) , GETDATE());

            COMMIT TRANSACTION;

            RETURN 1; 
        END
        ELSE
        BEGIN
            ROLLBACK TRANSACTION;
            THROW 50002, 'No tiene permiso para realizar esta acción', 2;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        RETURN ERROR_NUMBER(); 
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarAvisoGeneral]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarAvisoGeneral]
    @ID_AvisoGeneral INT,
    @Mensaje NVARCHAR(300),
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        -- Actualizar el aviso general
        UPDATE AvisosGenerales
        SET Mensaje = @Mensaje
        WHERE ID_AvisoGeneral = @ID_AvisoGeneral;
        -- Insertar en la tabla de auditoría
        INSERT INTO AuditoriaAvisosGenerales (ID_Usuario, ID_AvisoGeneral, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, @ID_AvisoGeneral, 'Edición', 'Edición del aviso general', GETDATE());
        COMMIT TRANSACTION;

        RETURN 1;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END

        RETURN ERROR_NUMBER();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarCalificacion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarCalificacion]
    @ID_Calificacion INT,
    @ID_Estudiante INT = NULL,
    @ID_Clase INT = NULL,
    @Calificacion DECIMAL(5,2) = NULL,
    @ID_TipoEvaluacion INT = NULL,
    @ID_Usuario INT,
    @Porcentaje DECIMAL(5,2) = NULL,
	@Retroalimentacion NVARCHAR(150) = NULL
AS
BEGIN
    BEGIN TRY
        -- Verificar si la calificación existe
        IF NOT EXISTS (SELECT 1 FROM Calificaciones WHERE ID_Calificacion = @ID_Calificacion)
        BEGIN
            THROW 50000, 'La calificación especificada no existe.', 2;
            RETURN ERROR_NUMBER();
        END;

        BEGIN TRANSACTION;

        -- Actualizar las columnas especificadas
        UPDATE Calificaciones
        SET
            ID_Estudiante = ISNULL(@ID_Estudiante, ID_Estudiante),
            ID_Clase = ISNULL(@ID_Clase, ID_Clase),
            Calificacion = ISNULL(@Calificacion, Calificacion),
            ID_TipoEvaluacion = ISNULL(@ID_TipoEvaluacion, ID_TipoEvaluacion),
            FechaCalificacion = GETDATE(),
            PorcentajeTotal = ISNULL(@Porcentaje, PorcentajeTotal),
		    Retroalimentacion = ISNULL(@Retroalimentacion, Retroalimentacion)
        WHERE ID_Calificacion = @ID_Calificacion;

        -- Obtener el nombre del curso para la auditoría
        DECLARE @@ID_Estudiante [INT];
        SELECT @ID_Estudiante = ID_Estudiante FROM Calificaciones WHERE ID_Calificacion = @ID_Calificacion;

        -- Insertar en la tabla AuditoriaCalificaciones
        INSERT INTO AuditoriaCalificaciones (ID_Usuario, ID_Calificacion, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario, @ID_Calificacion, 'Edición', 'Edición de calificación para la clase ' + CAST(@ID_Clase AS NVARCHAR(10))  +
		'del estudiante ' + CAST(@ID_Estudiante AS NVARCHAR(10)), GETDATE());
        COMMIT TRANSACTION;
        RETURN 1; 
    END TRY

    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        RETURN ERROR_NUMBER();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarClase]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarClase]
    @ID_Clase INT,
    @ID_Curso INT,
    @ID_Grado INT,
	@ID_Usuario INT,
	@RolUsuario INT,
	@Activo BIT
AS
BEGIN
    IF @RolUsuario = 1
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;
            -- Actualizar la clase
            UPDATE Clases
            SET ID_Curso = @ID_Curso,
                ID_Grado = @ID_Grado,
				Activo = @Activo
            WHERE ID_Clase = @ID_Clase;

            -- Insertar en la tabla de auditoría
            INSERT INTO AuditoriaClases (ID_Usuario, ID_Clase, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario, @ID_Clase, 'Edición', 'Edición de la clase ID: ' + CAST(@ID_Clase AS NVARCHAR(50)), GETDATE());

            COMMIT TRANSACTION;

            RETURN 1; 
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END

            RETURN ERROR_NUMBER();
        END CATCH
    END
    ELSE
    BEGIN
        RETURN -1; 
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarDocente]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarDocente]
    @ID_Docente INT,
    @Cedula NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @PrimerApellido NVARCHAR(20),
	@SegundoApellido NVARCHAR(20),
	@FechaNacimiento DATE,
    @RolUsuario INT,
    @Activo BIT,
	@ID_Usuario INT,
	@ID_Usuario_Accion INT
AS
BEGIN
    IF @RolUsuario <> 1
    BEGIN
        RETURN -1; 
    END

    BEGIN TRANSACTION;

    IF EXISTS (SELECT 1 FROM Docentes WHERE ID_Docente = @ID_Docente)
    BEGIN
        -- Cedula de docente disponible?
        IF @Cedula IS NOT NULL AND @Cedula != '' AND EXISTS 
            (SELECT 1 FROM Docentes WHERE Cedula = @Cedula AND ID_Docente != @ID_Docente)
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN -2;
        END

        UPDATE Docentes
        SET 
            Cedula = ISNULL(@Cedula, Cedula),
            Nombre = ISNULL(@Nombre, Nombre),
            PrimerApellido = ISNULL(@PrimerApellido, PrimerApellido),
			SegundoApellido = ISNULL(@SegundoApellido, SegundoApellido),
			FechaNacimiento = ISNULL(@FechaNacimiento, FechaNacimiento),
			ID_Usuario = ISNULL(@ID_Usuario, ID_Usuario),
            Activo = ISNULL(@Activo, Activo)
        WHERE ID_Docente = @ID_Docente;

        -- Inserción en la tabla de auditoría
        INSERT INTO AuditoriaDocentes (ID_Usuario, ID_Docente, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario_Accion, @ID_Docente, 'Edición', 'Edición de docente' + CAST(@ID_Docente AS NVARCHAR(10)), GETDATE());

        COMMIT TRANSACTION;
        
        RETURN 1; 
    END
    ELSE
    BEGIN
		IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
				RETURN -3;
			END      
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarEstadoAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[EditarEstadoAsistencia]
    @ID_Estado INT,
	@NombreEstado NVARCHAR(20),
	@ID_Usuario INT,
	@RolUsuario INT,
	@Activo BIT
AS
BEGIN
    IF @RolUsuario = 1
    BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;
            UPDATE EstadosAsistencia
            SET NombreEstado = @NombreEstado,
				Activo = @Activo
            WHERE ID_Estado = @ID_Estado;

            -- Insertar en la tabla de auditoría
            INSERT INTO AuditoriaAdministracion(ID_Usuario, Accion, Detalles, Fecha_Accion)
            VALUES (@ID_Usuario,'Edición', 'Se edita estado de asistencia' + @NombreEstado, GETDATE());

            COMMIT TRANSACTION;

            RETURN 1; 
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
            BEGIN
                ROLLBACK TRANSACTION;
            END

            RETURN ERROR_NUMBER();
        END CATCH
    END
    ELSE
    BEGIN
        RETURN -1; 
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarEstudiante]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarEstudiante]
    @ID_Estudiante INT,
    @Cedula NVARCHAR(50),
    @Nombre NVARCHAR(50),
    @PrimerApellido NVARCHAR(20),
	@SegundoApellido NVARCHAR(20),
	@FechaNacimiento DATE,
    @RolUsuario INT,
    @Activo BIT,
	@ID_Usuario INT,
	@ID_Usuario_Accion INT
AS
BEGIN
    IF @RolUsuario <> 1
    BEGIN
        RETURN -1; 
    END

    BEGIN TRANSACTION;

    IF EXISTS (SELECT 1 FROM Estudiantes WHERE ID_Estudiante = @ID_Estudiante)
    BEGIN
        -- Cedula de estudiante disponible?
        IF @Cedula IS NOT NULL AND @Cedula != '' AND EXISTS 
            (SELECT 1 FROM Estudiantes WHERE Cedula = @Cedula AND ID_Estudiante != @ID_Estudiante)
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN -2;
        END

        UPDATE Estudiantes
        SET 
            Cedula = ISNULL(@Cedula, Cedula),
            Nombre = ISNULL(@Nombre, Nombre),
            PrimerApellido = ISNULL(@PrimerApellido, PrimerApellido),
			SegundoApellido = ISNULL(@SegundoApellido, SegundoApellido),
			FechaNacimiento = CASE WHEN @FechaNacimiento IS NOT NULL THEN @FechaNacimiento ELSE FechaNacimiento END,
			ID_Usuario = ISNULL(@ID_Usuario, ID_Usuario),
            Activo = ISNULL(@Activo, Activo)
        WHERE ID_Estudiante = @ID_Estudiante;

        -- Inserción en la tabla de auditoría
        INSERT INTO AuditoriaEstudiantes (ID_Usuario, ID_Estudiante, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario_Accion, @ID_Estudiante, 'Edición', 'Edición de estudiante ' + CAST(@ID_Estudiante AS NVARCHAR(10)), GETDATE());

        COMMIT TRANSACTION;
        
        RETURN 1; 
    END
    ELSE
    BEGIN
		IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END
		RETURN -3;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarPadre]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarPadre]
    @ID_Padre INT,
    @Nombre NVARCHAR(50),
    @PrimerApellido NVARCHAR(20),
	@SegundoApellido NVARCHAR(20),
    @RolUsuario INT,
   	@Email NVARCHAR(150),
	@Numero NVARCHAR(15),
	@ID_Usuario_Accion INT
AS
BEGIN
    IF @RolUsuario <> 1
    BEGIN
        RETURN -1; 
    END

    BEGIN TRANSACTION;

    IF EXISTS (SELECT 1 FROM Padres WHERE ID_Padre = @ID_Padre)
    BEGIN
        -- Cedula de estudiante disponible?
        IF EXISTS (SELECT 1 FROM Padres WHERE Nombre = @Nombre AND PrimerApellido = @PrimerApellido AND @SegundoApellido = @SegundoApellido AND ID_Padre <> @ID_Padre)
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN -2;
        END

        UPDATE Padres
        SET 
            Nombre = ISNULL(@Nombre, Nombre),
            PrimerApellido = ISNULL(@PrimerApellido, PrimerApellido),
			SegundoApellido = ISNULL(@SegundoApellido, SegundoApellido),
			Email = ISNULL(@Email, Email),
			Numero = ISNULL(@Numero, Numero)
        WHERE ID_Padre = @ID_Padre;

        -- Inserción en la tabla de auditoría
        INSERT INTO AuditoriaAdministracion(ID_Usuario, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario_Accion, 'Edición', 'Se edita padre con ID: ' + CAST(@ID_Padre AS NVARCHAR(10)), GETDATE());

        COMMIT TRANSACTION;
        
        RETURN 1; 
    END
    ELSE
    BEGIN
		IF @@TRANCOUNT > 0
			BEGIN
				ROLLBACK TRANSACTION;
			END
		RETURN -3;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EditarUsuario]
    @ID_Usuario INT,
    @Nombre_Usuario NVARCHAR(100),
    @ID_Rol INT,
    @Email NVARCHAR(100),
    @RolUsuario INT,
    @Activo BIT,
	@ID_Usuario_Accion INT
AS
BEGIN
    IF @RolUsuario <> 1
    BEGIN
        RETURN -1; 
    END

    BEGIN TRANSACTION;

    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Usuario = @ID_Usuario)
    BEGIN
        -- Nombre de usuario disponible?
        IF @Nombre_Usuario IS NOT NULL AND @Nombre_Usuario != '' AND EXISTS 
            (SELECT 1 FROM Usuarios WHERE Nombre_Usuario = @Nombre_Usuario AND ID_Usuario != @ID_Usuario)
        BEGIN
            ROLLBACK TRANSACTION;
            RETURN -2;
        END

        UPDATE Usuarios
        SET 
            Nombre_Usuario = ISNULL(@Nombre_Usuario, Nombre_Usuario),
            ID_Rol = ISNULL(@ID_Rol, ID_Rol),
            Email = ISNULL(@Email, Email),
            Activo = ISNULL(@Activo, Activo)
        WHERE ID_Usuario = @ID_Usuario;

        -- Inserción en la tabla de auditoría
        INSERT INTO AuditoriaAdministracion (ID_Usuario, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario_Accion, 'Edición de usuario ', 'Edición de usuario ' + CAST(@ID_Usuario AS NVARCHAR(10)), GETDATE());

        COMMIT TRANSACTION;
        
        RETURN 1; 
    END
    ELSE
    BEGIN
        ROLLBACK TRANSACTION;
        RETURN -3;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarPadre]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[EliminarPadre]
    @ID_Padre INT,
    @RolUsuario INT,
	@ID_Usuario_Accion INT
AS
BEGIN
    IF @RolUsuario <> 1
    BEGIN
        RETURN -1; -- Error: Usuario no autorizado
    END

    BEGIN TRANSACTION;

    IF EXISTS (SELECT 1 FROM Padres WHERE ID_Padre = @ID_Padre)
    BEGIN

		DELETE FROM EstudiantesPadres WHERE ID_Padre = @ID_Padre;

        -- Obtener el nombre completo del padre
        DECLARE @NombreCompleto NVARCHAR(100);
        SELECT @NombreCompleto = Nombre + ' ' + PrimerApellido + ' ' + SegundoApellido
        FROM Padres
        WHERE ID_Padre = @ID_Padre;

        -- Eliminar el padre
        DELETE FROM Padres WHERE ID_Padre = @ID_Padre;

        -- Inserción en la tabla de auditoría
        INSERT INTO AuditoriaAdministracion(ID_Usuario, Accion, Detalles, Fecha_Accion)
        VALUES (@ID_Usuario_Accion, 'Eliminación', 'Se elimina padre: ' + @NombreCompleto, GETDATE());

        COMMIT TRANSACTION;
        
        RETURN 1; -- Éxito: Padre eliminado correctamente
    END
    ELSE
    BEGIN
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        RETURN -3; -- Error: No se encontró el padre con el ID especificado
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GenerarContrasennaAleatoria]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerarContrasennaAleatoria]
@Contrasenna  NVARCHAR(100) OUTPUT
AS
BEGIN
    DECLARE @CaracteresPermitidos NVARCHAR(100) = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    DECLARE @i INT = 1;
	SET @Contrasenna = '';

    WHILE @i <= 15
    BEGIN
        DECLARE @Posicion INT = (SELECT ABS(CHECKSUM(NEWID())) % LEN(@CaracteresPermitidos) + 1);
        SET @Contrasenna = @Contrasenna + SUBSTRING(@CaracteresPermitidos, @Posicion, 1);
        SET @i = @i + 1;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[GenerarSalt]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerarSalt]
    @Salt NVARCHAR(128) OUTPUT
AS
BEGIN
    DECLARE @CaracteresPermitidos NVARCHAR(64) = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_';
    DECLARE @Longitud INT = 128;
    DECLARE @i INT = 1;
    SET @Salt = '';

    WHILE @i <= @Longitud
    BEGIN
        DECLARE @Posicion INT = (SELECT ABS(CHECKSUM(NEWID())) % LEN(@CaracteresPermitidos) + 1);
        SET @Salt = @Salt + SUBSTRING(@CaracteresPermitidos, @Posicion, 1);
        SET @i = @i + 1;
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[GenerarToken]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GenerarToken]
    @ID_Usuario INT
AS
BEGIN
    DECLARE @Token NVARCHAR(255);

    DECLARE @RandomBytes VARBINARY(100); 
    SET @RandomBytes = CRYPT_GEN_RANDOM(50); 

    SET @Token = CONVERT(NVARCHAR(255), @RandomBytes, 2); 

    -- Truncar el token de ser necesario
    SET @Token = LEFT(@Token, 255);

    INSERT INTO Tokens (ID_Usuario, Token, FechaCreacion)
    VALUES (@ID_Usuario, @Token, GETDATE());
    SELECT @Token AS Token;
END;
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
    @Nombre_Usuario NVARCHAR(50),
    @Contrasenna NVARCHAR(100)
AS
BEGIN
    BEGIN TRANSACTION;

    DECLARE @ContrasennaHash NVARCHAR(100);
    DECLARE @Salt NVARCHAR(128);
    DECLARE @ID_Usuario INT;

    -- Obtener el ID del usuario y su hash de contraseña asociado al nombre de usuario
    SELECT @ID_Usuario = ID_Usuario, @ContrasennaHash = ContrasennaHash, @Salt = Salt
    FROM Usuarios
    WHERE Nombre_Usuario = @Nombre_Usuario;

    IF @ID_Usuario IS NOT NULL
    BEGIN
        IF @ContrasennaHash IS NOT NULL AND HASHBYTES('SHA2_512', CONCAT(@Contrasenna, @Salt)) = @ContrasennaHash
        BEGIN
            INSERT INTO AuditoriaIniciosSesion (ID_Usuario, Fecha, Exito, Detalles) 
            VALUES (@ID_Usuario, GETDATE(), 1, 'Inicio de sesión exitoso.');

            SELECT u.ID_Usuario, u.Nombre_Usuario, u.ID_Rol, u.Activo, r.NombreRol
            FROM Usuarios u
            JOIN Roles r ON u.ID_Rol = r.ID_Rol
            WHERE u.Nombre_Usuario = @Nombre_Usuario;
        END
        ELSE
        BEGIN
            -- Insertar registro de inicio de sesión fallido en la tabla de auditoría
            INSERT INTO AuditoriaIniciosSesion (ID_Usuario, Fecha, Exito, Detalles) 
            VALUES (@ID_Usuario, GETDATE(), 0, 'Inicio de sesión fallido.');

            -- Si las credenciales son inválidas, devolver un conjunto de resultados vacío
            SELECT NULL AS ID_Usuario, NULL AS Nombre_Usuario, NULL AS ID_Rol, NULL AS Activo, NULL AS NombreRol;
        END;
    END
    ELSE
    BEGIN
        -- Devolver un conjunto de resultados vacío
        SELECT NULL AS ID_Usuario, NULL AS Nombre_Usuario, NULL AS ID_Rol, NULL AS Activo, NULL AS NombreRol;
    END;
    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[LimpiarTokensExpirados]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[LimpiarTokensExpirados]
AS
BEGIN
    DELETE FROM Tokens
    WHERE FechaCreacion < DATEADD(HOUR, -24, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[ListarEstudiantesEnTablaAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[ListarEstudiantesEnTablaAsistencia]
AS
BEGIN
    SELECT DISTINCT E.Nombre, E.PrimerApellido, E.SegundoApellido, E.ID_Estudiante
    FROM Estudiantes E
    INNER JOIN Asistencia A ON E.ID_Estudiante = A.ID_Estudiante
	WHERE A.Activo =1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAsistenciaClasePorFechas]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerAsistenciaClasePorFechas] (
    @rolUsuario int,
    @idClase INT,
    @fechaInicio DATE,
    @fechaFin DATE
)
AS
BEGIN
    IF @rolUsuario = 3
    BEGIN
        -- Si el rol no es estudiante, no ejecutar el procedimiento
        RETURN;
    END

    -- Validar cuál fecha va primero y cuál va después
    DECLARE @fechaMenor DATE, @fechaMayor DATE;
    SET @fechaMenor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaInicio ELSE @fechaFin END;
    SET @fechaMayor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaFin ELSE @fechaInicio END;

    -- Iniciar una transacción
    BEGIN TRANSACTION;

    SELECT e.Nombre, e.PrimerApellido, e.SegundoApellido, c.NombreCurso, a.Fecha_Asistencia, ea.NombreEstado, g.NombreGrado
    FROM Asistencia a WITH (ROWLOCK, UPDLOCK, HOLDLOCK)
    INNER JOIN Estudiantes e WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON a.id_estudiante = e.id_estudiante
	INNER JOIN Clases cl WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON cl.ID_Clase = a.ID_Clase 
    INNER JOIN Cursos c WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON c.ID_Curso = cl.ID_Curso
    INNER JOIN EstadosAsistencia ea WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON a.ID_Estado = ea.ID_Estado
	INNER JOIN Grados g WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON g.ID_Grado = cl.ID_Grado
    WHERE a.ID_Clase = @idclase
    AND a.Fecha_Asistencia BETWEEN @fechaMenor AND @fechaMayor
	AND a.Activo = 1;;

    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAsistenciaEstudiantePorFechas]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerAsistenciaEstudiantePorFechas] (
    @rolUsuario int,
    @idEstudiante INT,
    @fechaInicio DATE,
    @fechaFin DATE
)
AS
BEGIN
    IF @rolUsuario = 3
    BEGIN
        -- Si el rol no es estudiante, no ejecutar el procedimiento
        RETURN;
    END

    -- Validar cuál fecha va primero y cuál va después
    DECLARE @fechaMenor DATE, @fechaMayor DATE;
    SET @fechaMenor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaInicio ELSE @fechaFin END;
    SET @fechaMayor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaFin ELSE @fechaInicio END;

    -- Iniciar una transacción
    BEGIN TRANSACTION;

    SELECT e.Nombre, e.PrimerApellido, e.SegundoApellido, c.NombreCurso, a.Fecha_Asistencia, ea.NombreEstado, g.NombreGrado
    FROM Asistencia a WITH (ROWLOCK, UPDLOCK, HOLDLOCK)
    INNER JOIN Estudiantes e WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON a.id_estudiante = e.id_estudiante
	INNER JOIN Clases cl WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON cl.ID_Clase = a.ID_Clase 
    INNER JOIN Cursos c WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON c.ID_Curso = cl.ID_Curso
    INNER JOIN EstadosAsistencia ea WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON a.ID_Estado = ea.ID_Estado
	INNER JOIN Grados g WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON g.ID_Grado = cl.ID_Grado
    WHERE a.id_estudiante = @idEstudiante
    AND a.Fecha_Asistencia BETWEEN @fechaMenor AND @fechaMayor
	AND a.Activo = 1;

    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerAsistenciaGradoPorFechas]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerAsistenciaGradoPorFechas] (
    @rolUsuario int,
    @idGrado INT,
    @fechaInicio DATE,
    @fechaFin DATE
)
AS
BEGIN
    IF @rolUsuario = 3
    BEGIN
        -- Si el rol no es estudiante, no ejecutar el procedimiento
        RETURN;
    END

    -- Validar cuál fecha va primero y cuál va después
    DECLARE @fechaMenor DATE, @fechaMayor DATE;
    SET @fechaMenor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaInicio ELSE @fechaFin END;
    SET @fechaMayor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaFin ELSE @fechaInicio END;

    -- Iniciar una transacción
    BEGIN TRANSACTION;

    SELECT e.Nombre, e.PrimerApellido, e.SegundoApellido, c.NombreCurso, a.Fecha_Asistencia, ea.NombreEstado, g.NombreGrado
    FROM Asistencia a WITH (ROWLOCK, UPDLOCK, HOLDLOCK)
    INNER JOIN Estudiantes e WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON a.id_estudiante = e.id_estudiante
	INNER JOIN Clases cl WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON cl.ID_Clase = a.ID_Clase
    INNER JOIN Cursos c WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON c.ID_Curso = cl.ID_Curso
    INNER JOIN EstadosAsistencia ea WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON a.ID_Estado = ea.ID_Estado
	INNER JOIN Grados g WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON g.ID_Grado = cl.ID_Grado
    WHERE g.ID_Grado = @idGrado
    AND a.Fecha_Asistencia BETWEEN @fechaMenor AND @fechaMayor
	AND a.Activo = 1;;

    COMMIT TRANSACTION;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerCalificacionesEstudiantePorFechas]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ObtenerCalificacionesEstudiantePorFechas] (
    @rolUsuario int,
    @idEstudiante INT,
    @fechaInicio DATE,
    @fechaFin DATE
)
AS
BEGIN
    -- Validar el rol del usuario
    IF @rolUsuario = 3
    BEGIN

        RETURN;
    END

    -- Determinar la fecha menor y mayor
    DECLARE @fechaMenor DATE, @fechaMayor DATE;
    SET @fechaMenor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaInicio ELSE @fechaFin END;
    SET @fechaMayor = CASE WHEN @fechaInicio < @fechaFin THEN @fechaFin ELSE @fechaInicio END;

    -- Consulta para obtener las calificaciones del estudiante por fechas
    SELECT 
        e.Nombre, 
        e.PrimerApellido, 
        e.SegundoApellido, 
        cr.NombreCurso, 
        g.NombreGrado,
		c.FechaCalificacion,
		te.Descripcion,
		c.Calificacion,
		c.PorcentajeTotal,
		c.Retroalimentacion,
        CAST(ROUND((CAST(c.Calificacion AS DECIMAL(10, 2)) / 100.0) * CAST(c.PorcentajeTotal AS DECIMAL(10, 2)), 2) AS DECIMAL(10, 2)) AS PorcentajeObtenido
    FROM 
        Calificaciones c WITH (ROWLOCK, UPDLOCK, HOLDLOCK)
    INNER JOIN 
        Estudiantes e WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON c.ID_Estudiante = e.ID_Estudiante
    INNER JOIN 
        Clases cl WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON c.ID_Clase = cl.ID_Clase
    INNER JOIN 
        Cursos cr WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON cl.ID_Curso = cr.ID_Curso
    INNER JOIN 
        Grados g WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON cl.ID_Grado = g.ID_Grado
    INNER JOIN 
        TiposEvaluaciones te WITH (ROWLOCK, UPDLOCK, HOLDLOCK) ON c.ID_TipoEvaluacion = te.ID_TipoEvaluacion
    WHERE 
        c.ID_Estudiante = @idEstudiante
        AND c.FechaCalificacion BETWEEN @fechaMenor AND @fechaMayor
        AND c.Activo = 1; 
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerClasesConAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create PROCEDURE [dbo].[ObtenerClasesConAsistencia]
AS
BEGIN
    SELECT DISTINCT cl.ID_Clase, g.NombreGrado, c.NombreCurso
    FROM Grados g 
	INNER JOIN Clases cl ON cl.ID_Grado = g.ID_Grado
    INNER JOIN Asistencia A ON  a.ID_Clase = cl.ID_Clase
	INNER JOIN Cursos c ON c.ID_Curso = cl.ID_Curso
	WHERE a.Activo =1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEstudiantesConAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[ObtenerEstudiantesConAsistencia]
AS
BEGIN
    SELECT DISTINCT E.Nombre, E.PrimerApellido, E.SegundoApellido, A.*
    FROM Estudiantes E
    INNER JOIN Asistencia A ON E.ID_Estudiante = A.ID_Estudiante
	WHERE a.Activo =1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerEstudiantesConCalificaciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[ObtenerEstudiantesConCalificaciones]
AS
BEGIN
    SELECT DISTINCT E.ID_Estudiante, E.Nombre, E.PrimerApellido, E.SegundoApellido
    FROM Estudiantes E
    INNER JOIN CAlificaciones C ON E.ID_Estudiante = C.ID_Estudiante
	WHERE c.Activo =1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerGradosConAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  create PROCEDURE [dbo].[ObtenerGradosConAsistencia]
AS
BEGIN
    SELECT DISTINCT g.ID_Grado, g.NombreGrado
    FROM Grados g 
	INNER JOIN Clases cl ON cl.ID_Grado = g.ID_Grado
    INNER JOIN Asistencia A ON  a.ID_Clase = cl.ID_Clase
	WHERE a.Activo =1;
END;
GO
/****** Object:  StoredProcedure [dbo].[ObtenerUsuariosNoAsignados]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ObtenerUsuariosNoAsignados]
    @RolUsuario INT
AS
BEGIN
    IF @RolUsuario = 1
    BEGIN
        SELECT ID_Usuario, ID_Rol, Nombre_Usuario
        FROM Usuarios
        WHERE ISNULL(ID_Usuario, 0) NOT IN (
            SELECT ISNULL(ID_Usuario, 0)
            FROM Docentes
            UNION ALL -- Use UNION ALL here to avoid duplicate results
            SELECT ISNULL(ID_Usuario, 0)
            FROM Estudiantes
        );
    END
    ELSE
        RETURN -1;
END;
GO
/****** Object:  StoredProcedure [dbo].[RecuperarContrasennaPaso1]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[RecuperarContrasennaPaso1]


@Email NVARCHAR(150)
AS
BEGIN
    DECLARE @ID_Usuario INT;
    DECLARE @NuevoToken NVARCHAR(255);
	 DECLARE @TokenExistente NVARCHAR(255);


    BEGIN TRY
        BEGIN TRANSACTION;

        CREATE TABLE #TempToken (
            Token NVARCHAR(255)
        );

        SELECT @ID_Usuario = ID_Usuario
        FROM Usuarios WITH (UPDLOCK)
        WHERE Email = @Email AND Activo = 1;

        IF @ID_Usuario IS NOT NULL
        BEGIN
		-- Verificar si ya existe un token para este usuario
            SELECT @TokenExistente = Token
            FROM Tokens
            WHERE ID_Usuario = @ID_Usuario;

            -- Si existe un token, eliminarlo
            IF @TokenExistente IS NOT NULL
            BEGIN
                DELETE FROM Tokens
                WHERE Token = @TokenExistente;
            END
            INSERT INTO #TempToken (Token)
            EXEC GenerarToken @ID_Usuario;

            SELECT @NuevoToken = Token
            FROM #TempToken;

            SELECT *
            FROM Tokens
            WHERE Token = @NuevoToken;
        END
        ELSE
        BEGIN
        SELECT NULL AS ID_Token, NULL AS ID_Usuario, NULL AS Token, NULL AS FechaCreacion;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        SELECT NULL AS ID_Token, NULL AS ID_Usuario, NULL AS Token, NULL AS FechaCreacion;
    END CATCH

    IF OBJECT_ID('tempdb..#TempToken') IS NOT NULL
        DROP TABLE #TempToken;
END;

GO
/****** Object:  StoredProcedure [dbo].[RecuperarContrasennaPaso2]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecuperarContrasennaPaso2]
    @Email NVARCHAR(150),
    @Token NVARCHAR(255),
    @NuevaContrasenna NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE @ID_Usuario INT;
        -- Verificar correo y obtiene id del usuario
        SELECT @ID_Usuario = ID_Usuario
        FROM Usuarios
        WHERE Email = @Email;

        -- Verificar validez de token
        IF EXISTS (SELECT 1 FROM Tokens WHERE Token = @Token AND ID_Usuario = @ID_Usuario)
        BEGIN

             DECLARE @Salt NVARCHAR(128);
			EXEC GenerarSalt @Salt OUTPUT;
    
			-- Concatenar la contraseña con el salt
			DECLARE @ContrasennaSalt NVARCHAR(228);
			SET @ContrasennaSalt = @NuevaContrasenna + @Salt;
    
			-- Calcular el hash de la contraseña
			DECLARE @Hash NVARCHAR(128);
			SET @Hash = HASHBYTES('SHA2_512', @ContrasennaSalt);

            -- Actualizar la contraseña en la tabla Usuarios
            UPDATE Usuarios
            SET ContrasennaHash = @Hash,
                Salt = @Salt
            WHERE ID_Usuario = @ID_Usuario;

            -- Eliminar el token utilizado
            DELETE FROM Tokens
            WHERE Token = @Token AND ID_Usuario = @ID_Usuario;

			DECLARE @Nombre_Usuario NVARCHAR(50);
			SET @Nombre_Usuario = (SELECT Nombre_Usuario FROM Usuarios WHERE ID_Usuario = @ID_Usuario);

			-- Insertar en la tabla AuditoriaAdministracion
			INSERT INTO AuditoriaAdministracion (ID_Usuario, Accion, Detalles, Fecha_Accion)
			VALUES (@ID_Usuario, 'Restablece contraseña', 'Usuario: ' + @Nombre_Usuario, GETDATE());

            COMMIT TRANSACTION;
            SELECT GetDate() AS FechaCreacion; 
        END
        ELSE
        BEGIN
            ROLLBACK TRANSACTION;
            SELECT NULL AS FechaCreacion;
        END
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
        BEGIN
            ROLLBACK TRANSACTION;
        END
        SELECT NULL AS FechaCreacion; 
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAsistencia]
   
AS
BEGIN
    BEGIN
        SELECT a.ID_Asistencia, a.ID_Estudiante, e.Nombre, e.PrimerApellido, e.SegundoApellido, a.Fecha_Asistencia,
        ea.ID_Estado, ea.NombreEstado, c.ID_Clase, cu.NombreCurso, g.NombreGrado, a.Activo
		FROM Asistencia a 
		JOIN Estudiantes e ON e.ID_Estudiante = a.ID_Estudiante 
		JOIN EstadosAsistencia ea ON ea.ID_Estado = a.ID_Estado 
		JOIN Clases c ON c.ID_Clase = a.ID_Clase 
		JOIN Cursos cu ON cu.ID_Curso = c.ID_Curso 
		JOIN Grados g ON g.ID_Grado = c.ID_Grado;
    END   
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAsistenciaPorGrado]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAsistenciaPorGrado]
    @ID_Grado INT
AS
BEGIN
    -- Seleccionar los registros de asistencia dentro del rango de fechas
    SELECT a.ID_Asistencia, a.ID_Estudiante, e.Nombre, e.PrimerApellido, e.SegundoApellido, a.Fecha_Asistencia,
           ea.ID_Estado, ea.NombreEstado, c.ID_Clase, cu.NombreCurso, g.NombreGrado, a.Activo
    FROM Asistencia a
    JOIN Estudiantes e ON e.ID_Estudiante = a.ID_Estudiante 
    JOIN EstadosAsistencia ea ON ea.ID_Estado = a.ID_Estado 
    JOIN Clases c ON c.ID_Clase = a.ID_Clase 
    JOIN Cursos cu ON cu.ID_Curso = c.ID_Curso 
    JOIN Grados g ON g.ID_Grado = c.ID_Grado
    WHERE g.ID_Grado = @ID_Grado
	AND a.Activo =1;
END;

GO
/****** Object:  StoredProcedure [dbo].[VerAsistenciaPorIdEstudiante]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAsistenciaPorIdEstudiante]
    @ID_Estudiante INT
AS
BEGIN
    BEGIN
        SELECT a.ID_Asistencia, a.ID_Estudiante, e.Nombre, e.PrimerApellido, e.SegundoApellido, a.Fecha_Asistencia,
        ea.ID_Estado, ea.NombreEstado, c.ID_Clase, cu.NombreCurso, g.NombreGrado, a.Activo
		FROM Asistencia a 
		JOIN Estudiantes e ON e.ID_Estudiante = a.ID_Estudiante 
		JOIN EstadosAsistencia ea ON ea.ID_Estado = a.ID_Estado 
		JOIN Clases c ON c.ID_Clase = a.ID_Clase 
		JOIN Cursos cu ON cu.ID_Curso = c.ID_Curso 
		JOIN Grados g ON g.ID_Grado = c.ID_Grado
		WHERE a.ID_Estudiante = @ID_Estudiante
		AND a.Activo =1;
    END   
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAsistenciaPorPerioddo]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAsistenciaPorPerioddo]
    @FechaInicio DATE,
    @FechaFin DATE
AS
BEGIN
    DECLARE @FechaMenor DATE;
    DECLARE @FechaMayor DATE;


    IF @FechaInicio < @FechaFin
    BEGIN
        SET @FechaMenor = @FechaInicio;
        SET @FechaMayor = @FechaFin;
    END
    ELSE
    BEGIN
        SET @FechaMenor = @FechaFin;
        SET @FechaMayor = @FechaInicio;
    END

    -- Seleccionar los registros de asistencia dentro del rango de fechas
    SELECT a.ID_Asistencia, a.ID_Estudiante, e.Nombre, e.PrimerApellido, e.SegundoApellido, a.Fecha_Asistencia,
           ea.ID_Estado, ea.NombreEstado, c.ID_Clase, cu.NombreCurso, g.NombreGrado, a.Activo
    FROM Asistencia a
    JOIN Estudiantes e ON e.ID_Estudiante = a.ID_Estudiante 
    JOIN EstadosAsistencia ea ON ea.ID_Estado = a.ID_Estado 
    JOIN Clases c ON c.ID_Clase = a.ID_Clase 
    JOIN Cursos cu ON cu.ID_Curso = c.ID_Curso 
    JOIN Grados g ON g.ID_Grado = c.ID_Grado
    WHERE a.Fecha_Asistencia BETWEEN @FechaMenor AND @FechaMayor
	AND a.Activo =1;
END;

GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaAdministracion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAuditoriaAdministracion]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT a.ID_AuditoriaAdministracion, a.ID_Usuario, u.Nombre_Usuario, a.Accion, a.Detalles, a.Fecha_Accion
			FROM AuditoriaAdministracion a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaAsistencia]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT a.ID_AuditoriaAsistencia, a.ID_Usuario, a.ID_Asistencia, u.Nombre_Usuario, a.Accion, a.Detalles, a.Fecha_Accion
			FROM AuditoriaAsistencia a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaAvisosGenerales]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaAvisosGenerales]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT a.ID_AuditoriaAvisoGeneral, a.ID_Usuario, a.ID_AvisoGeneral, u.Nombre_Usuario, a.Accion, a.Detalles, a.Fecha_Accion
			FROM AuditoriaAvisosGenerales a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaCalificaciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaCalificaciones]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT a.ID_AuditoriaCalificacion, a.ID_Usuario, a.ID_Calificacion, u.Nombre_Usuario, a.Accion, a.Detalles, a.Fecha_Accion
			FROM AuditoriaCalificaciones a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaClases]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaClases]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT a.ID_AuditoriaClase, a.ID_Usuario, a.ID_Clase, u.Nombre_Usuario, a.Accion, a.Detalles, a.Fecha_Accion
			FROM AuditoriaClases a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaDocentes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaDocentes]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT   a.ID_AuditoriaDocente, 
			a.ID_Usuario, 
			d.Nombre + ' ' + d.PrimerApellido + ' ' + d.SegundoApellido as NombreDocente, 
			u.Nombre_Usuario, 
			a.Accion, 
			a.Detalles, 
			a.Fecha_Accion
			FROM AuditoriaDocentes a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario JOIN
			Docentes d ON a.ID_Docente = d.ID_Docente;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaEstudiantes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaEstudiantes]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT   a.ID_AuditoriaEstudiante, 
			a.ID_Usuario, 
			u.Nombre_Usuario, 
			d.Nombre + ' ' + d.PrimerApellido + ' ' + d.SegundoApellido as NombreEstudiante, 		
			a.Accion, 
			a.Detalles, 
			a.Fecha_Accion
			FROM AuditoriaEstudiantes a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario JOIN
			Estudiantes d ON a.ID_Estudiante = d.ID_Estudiante;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAuditoriaIniciosSesion]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--select * from AuditoriaAdministracion

CREATE PROCEDURE [dbo].[VerAuditoriaIniciosSesion]
    @RolUsuario INT 
AS
BEGIN
    IF @RolUsuario = 1
		BEGIN
			SELECT   a.ID_InicioSesion, 
			a.ID_Usuario, 
			u.Nombre_Usuario, 	
			a.Exito, 
			a.Detalles, 
			a.Fecha
			FROM AuditoriaIniciosSesion a JOIN
			Usuarios u ON a.ID_Usuario = u.ID_Usuario;
		END

		ELSE
			BEGIN
				SELECT NULL;
		END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAvisoGeneral]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VerAvisoGeneral]
 @ID_AvisoGeneral INT
AS
BEGIN
        SELECT * FROM AvisosGenerales
		WHERE ID_AvisoGeneral = @ID_AvisoGeneral;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAvisosGenerales]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAvisosGenerales]
AS
BEGIN
        SELECT * FROM AvisosGenerales;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerCalificaciones]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  CREATE PROCEDURE [dbo].[VerCalificaciones]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        c.ID_Calificacion,
        CONCAT(e.Nombre, ' ', e.PrimerApellido, ' ', e.SegundoApellido) AS Estudiante,
        c.Calificacion,
        c.FechaCalificacion,
        cu.NombreCurso,
        g.NombreGrado,
        te.Descripcion AS TipoEvaluacion,
        c.PorcentajeTotal,
        c.Retroalimentacion
    FROM 
        [dbo].[Calificaciones] c
    INNER JOIN 
        [dbo].[Estudiantes] e ON c.ID_Estudiante = e.ID_Estudiante
    INNER JOIN 
        [dbo].[EstudiantesGrados] eg ON e.ID_Estudiante = eg.ID_Estudiante
    INNER JOIN 
        [dbo].[Grados] g ON eg.ID_Grado = g.ID_Grado
		INNER JOIN 
        [dbo].[Clases] cl ON cl.ID_Clase = c.ID_Clase
    INNER JOIN 
        [dbo].[Cursos] cu ON cl.ID_Curso = cu.ID_Curso
    INNER JOIN 
        [dbo].[TiposEvaluaciones] te ON c.ID_TipoEvaluacion = te.ID_TipoEvaluacion
    WHERE 
        c.Activo = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerCalificacionesPorID]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerCalificacionesPorID]
    @ID_Estudiante INT
AS
BEGIN
    SELECT 
    c.ID_Calificacion,
    CONCAT(e.Nombre, ' ', e.PrimerApellido, ' ', e.SegundoApellido) AS Estudiante,
    c.Calificacion,
    c.FechaCalificacion,
    cu.NombreCurso,
    g.NombreGrado,
    te.Descripcion AS TipoEvaluacion,
    c.PorcentajeTotal,
    c.Retroalimentacion
FROM 
    [proyectocidep].[dbo].[Calificaciones] c
INNER JOIN 
    [proyectocidep].[dbo].[Estudiantes] e ON c.ID_Estudiante = e.ID_Estudiante
INNER JOIN 
    [proyectocidep].[dbo].[EstudiantesGrados] eg ON e.ID_Estudiante = eg.ID_Estudiante
INNER JOIN 
    [proyectocidep].[dbo].[Grados] g ON eg.ID_Grado = g.ID_Grado
	INNER JOIN 
        [dbo].[Clases] cl ON cl.ID_Clase = c.ID_Clase
    INNER JOIN 
        [dbo].[Cursos] cu ON cl.ID_Curso = cu.ID_Curso
INNER JOIN 
    [proyectocidep].[dbo].[TiposEvaluaciones] te ON c.ID_TipoEvaluacion = te.ID_TipoEvaluacion
WHERE 
    c.Activo = 1
	AND c.ID_Estudiante = @ID_Estudiante
END;


GO
/****** Object:  StoredProcedure [dbo].[VerClasePorID]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VerClasePorID]
	@ID_Clase INT 
AS
BEGIN
        SELECT cl.ID_Clase, cl.ID_Curso, c.NombreCurso, cl.ID_Grado, g.NombreGrado,cl.Activo 
		FROM Clases cl JOIN
		Cursos c ON c.ID_Curso = cl.ID_Curso JOIN
		Grados g ON g.ID_Grado = cl.ID_Grado WHERE cl.ID_Clase = @ID_Clase;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerClases]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerClases]
AS
BEGIN
        SELECT cl.ID_Clase, cl.ID_Curso, c.NombreCurso, cl.ID_Grado, g.NombreGrado,cl.Activo 
		FROM Clases cl JOIN
		Cursos c ON c.ID_Curso = cl.ID_Curso JOIN
		Grados g ON g.ID_Grado = cl.ID_Grado;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerDocentes]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerDocentes]
AS
BEGIN
        SELECT * FROM Docentes;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerDocentesClases]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerDocentesClases]
AS
BEGIN
    BEGIN
        SELECT dc.ID_DocenteClase, d.ID_Docente, d.Nombre, d.PrimerApellido, d.SegundoApellido, g.NombreGrado, g.ID_Grado, c.ID_Clase, cu.NombreCurso
		FROM Docentes d JOIN 
		DocentesClases dc ON dc.ID_Docente = d.ID_Docente JOIN
		Clases c ON c.ID_Clase = dc.ID_Clase JOIN
		Grados g ON g.ID_Grado = c.ID_Grado JOIN
		Cursos cu on cu.ID_Curso = c.ID_Curso;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerEstadoAsistenciaPorID]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerEstadoAsistenciaPorID]
	@ID_Estado INT 
AS
BEGIN
        SELECT *
		FROM EstadosAsistencia
		WHERE ID_Estado = @ID_Estado;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerEstadosAsistencia]    Script Date: 4/9/2024 11:10:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VerEstadosAsistencia]
AS
BEGIN
    BEGIN
        SELECT *
		FROM EstadosAsistencia;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerEstudiantes]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerEstudiantes]
AS
BEGIN
    BEGIN
        SELECT *
		FROM Estudiantes;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerEstudiantesGrados]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerEstudiantesGrados]
AS
BEGIN
    BEGIN
        SELECT e.ID_Estudiante, e.Nombre, e.PrimerApellido, e.SegundoApellido, g.NombreGrado, g.ID_Grado
		FROM Estudiantes e JOIN 
		EstudiantesGrados eg ON eg.ID_Estudiante = e.ID_Estudiante JOIN
		Grados g ON g.ID_Grado = eg.ID_Grado;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerEstudiantesPadres]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VerEstudiantesPadres]
AS
BEGIN
        SELECT ep.ID_EstudiantePadre, ep.ID_Estudiante, e.Nombre + ' ' + e.PrimerApellido + ' ' + e.SegundoApellido as NombreEstudiante,
		p.ID_Padre, p.Nombre + ' ' + p.PrimerApellido + ' ' + p.SegundoApellido as NombrePadre, p.Email, p.Numero
		FROM EstudiantesPadres ep JOIN
		Padres p ON p.ID_Padre=ep.ID_Padre JOIN
		Estudiantes e ON e.ID_Estudiante=ep.ID_Estudiante;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerPadres]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[VerPadres]
AS
BEGIN
        SELECT * FROM Padres;
    
END;
GO
/****** Object:  StoredProcedure [dbo].[VerPerfilDeAdministrador]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerPerfilDeAdministrador]
    @ID_Usuario INT
AS
BEGIN
    SELECT u.ID_Usuario, u.Nombre_Usuario, u.ID_Rol, r.NombreRol, u.Activo AS ActivoUsuario, u.Email
    FROM Usuarios u 
    JOIN Roles r ON u.ID_Rol = r.ID_Rol
    WHERE u.ID_Usuario = @ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerPerfilDeDocente]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerPerfilDeDocente]
    @ID_Usuario INT
AS
BEGIN
    SELECT u.ID_Usuario, u.Nombre_Usuario, u.ID_Rol, r.NombreRol, u.Activo AS ActivoUsuario, u.Email,
           d.ID_Docente, d.Nombre, d.PrimerApellido, d.SegundoApellido, d.FechaNacimiento, d.Activo, d.Cedula
    FROM Usuarios u 
    JOIN Roles r ON u.ID_Rol = r.ID_Rol
    JOIN Docentes d ON u.ID_Usuario = d.ID_Usuario
    WHERE u.ID_Usuario = @ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerPerfilDeEstudiante]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerPerfilDeEstudiante]
    @ID_Usuario INT
AS
BEGIN
    SELECT u.ID_Usuario, u.Nombre_Usuario, u.ID_Rol, r.NombreRol, u.Activo AS ActivoUsuario, u.Email,
           e.ID_Estudiante, e.Nombre, e.PrimerApellido, e.SegundoApellido, e.FechaNacimiento, e.Activo, e.Cedula
    FROM Usuarios u 
    JOIN Roles r ON u.ID_Rol = r.ID_Rol
    JOIN Estudiantes e ON u.ID_Usuario = e.ID_Usuario
    WHERE u.ID_Usuario = @ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerRoles]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerRoles]
	@RolUsuario [INT]
AS
BEGIN
    IF @RolUsuario = 1
    BEGIN
        SELECT * FROM Roles;
    END
    ELSE
    BEGIN
        RETURN 0;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerUsuarioPorId]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerUsuarioPorId]
    @ID_Usuario INT
AS
BEGIN
    SELECT u.ID_Usuario, u.Nombre_Usuario, u.ID_Rol, r.NombreRol, u.Activo, u.Email
    FROM Usuarios u 
    JOIN Roles r ON u.ID_Rol = r.ID_Rol
    WHERE u.ID_Usuario = @ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[VerUsuarios]    Script Date: 4/9/2024 11:10:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerUsuarios]
AS
BEGIN
    BEGIN
        SELECT u.ID_Usuario, u.Nombre_Usuario, u.ID_Rol, r.NombreRol, u.Activo, u.Email
		FROM Usuarios u JOIN Roles r 
		ON u.ID_Rol = r.ID_Rol;
    END
END;
GO
USE [master]
GO
ALTER DATABASE [proyectocidep] SET  READ_WRITE 
GO
