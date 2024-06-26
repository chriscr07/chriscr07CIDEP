USE [master]
GO
/****** Object:  Database [proyectocidep]    Script Date: 6/2/2024 07:44:32 ******/
CREATE DATABASE [proyectocidep]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'proyectocidep', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\proyectocidep.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
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
/****** Object:  Table [dbo].[Asistencia]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencia](
	[ID_Asistencia] [int] IDENTITY(1,1) NOT NULL,
	[ID_Estudiante] [int] NULL,
	[Fecha_Asistencia] [date] NULL,
	[ID_Estado] [int] NULL,
	[ID_Clase] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaAdministracion]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaAdministracion](
	[ID_AuditoriaAdministracion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[Accion] [nvarchar](50) NULL,
	[Detalles] [nvarchar](255) NULL,
	[Fecha_Accion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaAdministracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaAsistencia]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaAsistencia](
	[ID_AuditoriaAsistencia] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[ID_Asistencia] [int] NULL,
	[Accion] [nvarchar](50) NULL,
	[Fecha_Accion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaAsistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaCalificaciones]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaCalificaciones](
	[ID_AuditoriaCalificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[ID_Calificacion] [int] NULL,
	[Accion] [nvarchar](50) NULL,
	[Fecha_Accion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaCalificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaClases]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaClases](
	[ID_AuditoriaClase] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[ID_Clase] [int] NULL,
	[Accion] [nvarchar](50) NULL,
	[Fecha_Accion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaClase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AuditoriaComunicados]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AuditoriaComunicados](
	[ID_AuditoriaComunicado] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[ID_Comunicado] [int] NULL,
	[Accion] [nvarchar](50) NULL,
	[Fecha_Accion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_AuditoriaComunicado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Calificaciones]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Calificaciones](
	[ID_Calificacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Estudiante] [int] NULL,
	[Calificacion] [decimal](5, 2) NULL,
	[FechaCalificacion] [date] NULL,
	[ID_Curso] [int] NULL,
	[Descripcion] [nvarchar](100) NULL,
	[Porcentaje] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Calificacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clases]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clases](
	[ID_Clase] [int] IDENTITY(1,1) NOT NULL,
	[ID_Curso] [int] NULL,
	[ID_Grado] [int] NULL,
	[ID_Docente] [int] NULL,
	[NombreClase] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Clase] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comunicados]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comunicados](
	[ID_Comunicado] [int] IDENTITY(1,1) NOT NULL,
	[Mensaje] [nvarchar](300) NULL,
	[Fecha_Publicacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Comunicado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Configuraciones]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Configuraciones](
	[ID_Configuracion] [int] IDENTITY(1,1) NOT NULL,
	[Notificaciones] [bit] NULL,
	[Recordatorios] [bit] NULL,
	[Apariencia] [nvarchar](50) NULL,
	[PoliticaContrasenas] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Configuracion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cursos]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cursos](
	[ID_Curso] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Curso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Docentes]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Docentes](
	[ID_Docente] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Cedula] [nvarchar](50) NULL,
	[PrimerApellido] [nvarchar](20) NULL,
	[SegundoApellido] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Docente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EstadosAsistencia]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EstadosAsistencia](
	[ID_Estado] [int] IDENTITY(1,1) NOT NULL,
	[NombreEstado] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estudiantes]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estudiantes](
	[ID_Estudiante] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[PrimerApellido] [nvarchar](20) NULL,
	[SegundoApellido] [nvarchar](20) NULL,
	[FechaNacimiento] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Estudiante] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EvaluacionesDocentes]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EvaluacionesDocentes](
	[ID_Evaluacion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Docente] [int] NULL,
	[FechaEvaluacion] [date] NULL,
	[Calificacion] [decimal](5, 2) NULL,
	[Comentarios] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Evaluacion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grados]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grados](
	[ID_Grado] [int] IDENTITY(1,1) NOT NULL,
	[NombreGrado] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Grado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IniciosSesion]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IniciosSesion](
	[ID_InicioSesion] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[Fecha] [datetime] NULL,
	[Exito] [bit] NULL,
	[Detalles] [nvarchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_InicioSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mensajeria]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mensajeria](
	[ID_Mensaje] [int] IDENTITY(1,1) NOT NULL,
	[Contenido] [nvarchar](300) NULL,
	[Fecha_Envio] [datetime] NULL,
	[Remitente_ID] [int] NULL,
	[Destinatario_ID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Mensaje] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [nvarchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre_Usuario] [nvarchar](50) NULL,
	[Contraseña] [nvarchar](100) NULL,
	[ID_Rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
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
ALTER TABLE [dbo].[AuditoriaComunicados]  WITH CHECK ADD FOREIGN KEY([ID_Comunicado])
REFERENCES [dbo].[Comunicados] ([ID_Comunicado])
GO
ALTER TABLE [dbo].[AuditoriaComunicados]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Curso])
REFERENCES [dbo].[Cursos] ([ID_Curso])
GO
ALTER TABLE [dbo].[Calificaciones]  WITH CHECK ADD FOREIGN KEY([ID_Estudiante])
REFERENCES [dbo].[Estudiantes] ([ID_Estudiante])
GO
ALTER TABLE [dbo].[Clases]  WITH CHECK ADD FOREIGN KEY([ID_Curso])
REFERENCES [dbo].[Cursos] ([ID_Curso])
GO
ALTER TABLE [dbo].[Clases]  WITH CHECK ADD FOREIGN KEY([ID_Docente])
REFERENCES [dbo].[Docentes] ([ID_Docente])
GO
ALTER TABLE [dbo].[Clases]  WITH CHECK ADD FOREIGN KEY([ID_Grado])
REFERENCES [dbo].[Grados] ([ID_Grado])
GO
ALTER TABLE [dbo].[EvaluacionesDocentes]  WITH CHECK ADD FOREIGN KEY([ID_Docente])
REFERENCES [dbo].[Docentes] ([ID_Docente])
GO
ALTER TABLE [dbo].[IniciosSesion]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Mensajeria]  WITH CHECK ADD FOREIGN KEY([Destinatario_ID])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Mensajeria]  WITH CHECK ADD FOREIGN KEY([Remitente_ID])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Roles] ([ID_Rol])
GO
/****** Object:  StoredProcedure [dbo].[BorrarAviso]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarAviso]
    @ID_Aviso INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        DELETE FROM Avisos
        WHERE ID_Aviso = @ID_Aviso;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarAvisoGeneral]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarAvisoGeneral]
    @ID_Aviso INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        DELETE FROM AvisosGenerales
        WHERE ID_Aviso = @ID_Aviso;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarClase]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarClase]
    @ID_Clase INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        DELETE FROM Clases
        WHERE ID_Clase = @ID_Clase;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarRol]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarRol]
    @ID_Rol INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        DELETE FROM Roles
        WHERE ID_Rol = @ID_Rol;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[BorrarUsuario]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BorrarUsuario]
    @ID_Usuario INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Usuario = @ID_Usuario AND ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        DELETE FROM Usuarios
        WHERE ID_Usuario = @ID_Usuario;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearAvisoConArchivo]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearAvisoConArchivo]
    @Mensaje NVARCHAR(300),
    @Archivo VARBINARY(MAX)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        INSERT INTO Avisos (Mensaje, Archivo)
        VALUES (@Mensaje, @Archivo);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearAvisoConDesarrollo]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearAvisoConDesarrollo]
    @Mensaje NVARCHAR(300),
    @Archivo VARBINARY(MAX),
    @Desarrollo NVARCHAR(300)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        INSERT INTO Avisos (Mensaje, Archivo, Desarrollo)
        VALUES (@Mensaje, @Archivo, @Desarrollo);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearAvisoConDestinatario]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearAvisoConDestinatario]
    @Mensaje NVARCHAR(300),
    @Archivo VARBINARY(MAX),
    @ID_Destinatario INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        INSERT INTO Avisos (Mensaje, Archivo, ID_Destinatario)
        VALUES (@Mensaje, @Archivo, @ID_Destinatario);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearAvisoGeneral]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearAvisoGeneral]
    @Mensaje NVARCHAR(300),
    @Fecha_Publicacion DATETIME
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        INSERT INTO AvisosGenerales (Mensaje, Fecha_Publicacion)
        VALUES (@Mensaje, @Fecha_Publicacion);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearClase]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearClase]
    @ID_Curso INT,
    @ID_Grado INT,
    @ID_Docente INT,
    @NombreClase NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        INSERT INTO Clases (ID_Curso, ID_Grado, ID_Docente, NombreClase)
        VALUES (@ID_Curso, @ID_Grado, @ID_Docente, @NombreClase);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearRol]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearRol]
    @NombreRol NVARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        INSERT INTO Roles (NombreRol)
        VALUES (@NombreRol);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[CrearUsuario]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CrearUsuario]
    @Nombre_Usuario NVARCHAR(50),
    @Contraseña NVARCHAR(100),
    @ID_Rol INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Roles WHERE ID_Rol = @ID_Rol AND NombreRol = 'Administrador')
    BEGIN
        INSERT INTO Usuarios (Nombre_Usuario, Contraseña, ID_Rol)
        VALUES (@Nombre_Usuario, @Contraseña, @ID_Rol);
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarAvisoConArchivo]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarAvisoConArchivo]
    @ID_Aviso INT,
    @Mensaje NVARCHAR(300),
    @Archivo VARBINARY(MAX)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        UPDATE Avisos
        SET Mensaje = @Mensaje,
            Archivo = @Archivo
        WHERE ID_Aviso = @ID_Aviso;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarAvisoConDesarrollo]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarAvisoConDesarrollo]
    @ID_Aviso INT,
    @Mensaje NVARCHAR(300),
    @Archivo VARBINARY(MAX),
    @Desarrollo NVARCHAR(300)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        UPDATE Avisos
        SET Mensaje = @Mensaje,
            Archivo = @Archivo,
            Desarrollo = @Desarrollo
        WHERE ID_Aviso = @ID_Aviso;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarAvisoConDestinatario]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarAvisoConDestinatario]
    @ID_Aviso INT,
    @Mensaje NVARCHAR(300),
    @Archivo VARBINARY(MAX),
    @ID_Destinatario INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        UPDATE Avisos
        SET Mensaje = @Mensaje,
            Archivo = @Archivo,
            ID_Destinatario = @ID_Destinatario
        WHERE ID_Aviso = @ID_Aviso;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarAvisoGeneral]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarAvisoGeneral]
    @ID_Aviso INT,
    @Mensaje NVARCHAR(300),
    @Fecha_Publicacion DATETIME
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        UPDATE AvisosGenerales
        SET Mensaje = @Mensaje,
            Fecha_Publicacion = @Fecha_Publicacion
        WHERE ID_Aviso = @ID_Aviso;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarClase]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarClase]
    @ID_Clase INT,
    @ID_Curso INT,
    @ID_Grado INT,
    @ID_Docente INT,
    @NombreClase NVARCHAR(50)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        UPDATE Clases
        SET ID_Curso = @ID_Curso,
            ID_Grado = @ID_Grado,
            ID_Docente = @ID_Docente,
            NombreClase = @NombreClase
        WHERE ID_Clase = @ID_Clase;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarRol]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarRol]
    @ID_Rol INT,
    @NombreRol NVARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        UPDATE Roles
        SET NombreRol = @NombreRol
        WHERE ID_Rol = @ID_Rol;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarUsuario]
    @ID_Usuario INT,
    @Nombre_Usuario NVARCHAR(50),
    @Contraseña NVARCHAR(100),
    @ID_Rol INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Usuario = @ID_Usuario AND ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        UPDATE Usuarios
        SET Nombre_Usuario = @Nombre_Usuario,
            Contraseña = @Contraseña,
            ID_Rol = @ID_Rol
        WHERE ID_Usuario = @ID_Usuario;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAvisos]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAvisos]
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Usuario'))
    BEGIN
        SELECT * FROM Avisos;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerAvisosGenerales]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerAvisosGenerales]
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        SELECT * FROM AvisosGenerales;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerClases]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerClases]
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        SELECT * FROM Clases;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerRoles]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerRoles]
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        SELECT * FROM Roles;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[VerUsuarios]    Script Date: 6/2/2024 07:44:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[VerUsuarios]
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Usuarios WHERE ID_Rol = (SELECT ID_Rol FROM Roles WHERE NombreRol = 'Administrador'))
    BEGIN
        SELECT * FROM Usuarios;
    END
    ELSE
    BEGIN
        PRINT 'No tiene permiso para realizar esta acción.';
    END
END;
GO
USE [master]
GO
ALTER DATABASE [proyectocidep] SET  READ_WRITE 
GO
