USE [master]
GO
/****** Object:  Database [ORUS369]    Script Date: 18/09/2021 11:58:38 p. m. ******/
CREATE DATABASE [ORUS369]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ORUS369', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ORUS369.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ORUS369_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ORUS369_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ORUS369] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ORUS369].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ORUS369] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ORUS369] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ORUS369] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ORUS369] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ORUS369] SET ARITHABORT OFF 
GO
ALTER DATABASE [ORUS369] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ORUS369] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ORUS369] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ORUS369] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ORUS369] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ORUS369] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ORUS369] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ORUS369] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ORUS369] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ORUS369] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ORUS369] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ORUS369] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ORUS369] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ORUS369] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ORUS369] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ORUS369] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ORUS369] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ORUS369] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ORUS369] SET  MULTI_USER 
GO
ALTER DATABASE [ORUS369] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ORUS369] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ORUS369] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ORUS369] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ORUS369] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ORUS369] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ORUS369] SET QUERY_STORE = OFF
GO
USE [ORUS369]
GO
/****** Object:  Table [dbo].[Asistencias]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencias](
	[Id_asistencia] [int] IDENTITY(1,1) NOT NULL,
	[Id_personal] [int] NULL,
	[Fecha_entrada] [datetime] NULL,
	[Fecha_salida] [datetime] NULL,
	[Estado] [varchar](50) NULL,
	[Horas] [numeric](18, 2) NULL,
	[Observacion] [varchar](max) NULL,
 CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED 
(
	[Id_asistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[Id_cargo] [int] IDENTITY(1,1) NOT NULL,
	[Cargo] [varchar](max) NULL,
	[SueldoPorHora] [numeric](18, 2) NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[Id_cargo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulos]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](max) NULL,
 CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdModulo] [int] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Personal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Personal](
	[Id_personal] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [varchar](max) NULL,
	[Identificacion] [varchar](max) NULL,
	[Pais] [varchar](max) NULL,
	[Id_cargo] [int] NULL,
	[SueldoPorHora] [numeric](18, 2) NULL,
	[Estado] [varchar](max) NULL,
	[Codigo] [varchar](max) NULL,
 CONSTRAINT [PK_Personal] PRIMARY KEY CLUSTERED 
(
	[Id_personal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[NombresApellidos] [varchar](50) NULL,
	[Login] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Personal] FOREIGN KEY([Id_personal])
REFERENCES [dbo].[Personal] ([Id_personal])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Personal]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Modulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulos] ([IdModulo])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Modulos]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Usuarios]
GO
ALTER TABLE [dbo].[Personal]  WITH CHECK ADD  CONSTRAINT [FK_Personal_Cargo] FOREIGN KEY([Id_cargo])
REFERENCES [dbo].[Cargo] ([Id_cargo])
GO
ALTER TABLE [dbo].[Personal] CHECK CONSTRAINT [FK_Personal_Cargo]
GO
/****** Object:  StoredProcedure [dbo].[buscarAsistenciasId]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscarAsistenciasId]
@Idpersonal int 
as 
select * from Asistencias
where Id_personal=@Idpersonal and Asistencias.Estado='ENTRADA'
GO
/****** Object:  StoredProcedure [dbo].[buscarCargos]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscarCargos]
@buscador varchar(50)
as 
select Id_cargo,Cargo,SueldoPorHora as Sueldo from Cargo
where Cargo like '%' + @buscador + '%'
GO
/****** Object:  StoredProcedure [dbo].[buscarPersonal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscarPersonal]
@Desde int,
@Hasta int,
@Buscador varchar(50)
as
Set Nocount On;
Select 
Id_personal,Nombres,Identificacion,SueldoPorHora,Cargo,Id_cargo,Estado,Codigo
from
(Select Id_personal ,Nombres,Identificacion,Personal.SueldoPorHora,Cargo.Cargo,Personal.Id_cargo,Estado,Codigo,
Row_Number() Over(Order by Id_personal) 'Numero_de_fila'
from Personal
inner join Cargo on Cargo.Id_cargo=Personal.Id_cargo ) as Paginado
Where (Paginado.Numero_de_fila >=@Desde) and (Paginado.Numero_de_fila<=@Hasta)
and (Nombres + Identificacion like '%' + @Buscador + '%')
GO
/****** Object:  StoredProcedure [dbo].[buscarPersonalIdentidad]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscarPersonalIdentidad]
@Buscador varchar(50)
as
SELECT * FROM Personal
where Identificacion = @Buscador
GO
/****** Object:  StoredProcedure [dbo].[confirmarSalida]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc  [dbo].[confirmarSalida]
@Id_personal as int,
@Fecha_salida DATETIME,
@Horas NUMERIC(18,2)
as
update Asistencias set
Fecha_salida = @Fecha_salida,
Horas = @Horas,
Estado = 'SALIDA'
where Id_personal = @Id_personal and Estado = 'ENTRADA'
GO
/****** Object:  StoredProcedure [dbo].[editarCargo]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editarCargo]
@id int,
@Cargo varchar(max),
@Sueldo numeric(18,2)
as 
if exists (select Cargo from Cargo where Cargo = @Cargo and Id_cargo = @id)
Raiserror('YA EXISTE UN CARGO CON ESTE NOMBRE, Ingrese de nuevo',16,1)
else
update Cargo set Cargo = @Cargo, SueldoPorHora = @Sueldo
where Id_cargo = @id
GO
/****** Object:  StoredProcedure [dbo].[editarPersonal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[editarPersonal]
@Id_personal int,
@Nombres as varchar(max),
@Identificacion varchar(max),
@Pais varchar(max),
@Id_cargo int,
@SueldoPorHora numeric(18,2)
as
if Exists(Select Identificacion from Personal where Identificacion=@Identificacion and Id_personal <>@Id_personal)
Raiserror('Ya existe un registro con esta Identificacion',16,1)
else
Update Personal set
Nombres=@Nombres ,Identificacion=@Identificacion,Pais=@Pais,Id_cargo =@Id_cargo ,SueldoPorHora =@SueldoPorHora 
where Id_personal=@Id_personal
GO
/****** Object:  StoredProcedure [dbo].[eliminarPermisos]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[eliminarPermisos]
@IdUsuario as int
as
delete from Permisos
where IdUsuario=@IdUsuario 
GO
/****** Object:  StoredProcedure [dbo].[eliminarPersonal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[eliminarPersonal]
@Id_personal int
as 
update Personal set Estado = 'ELIMINADO'
where Id_personal = @Id_personal
GO
/****** Object:  StoredProcedure [dbo].[insertarAsistencias]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarAsistencias]
@Id_personal int, 
@Fecha_entrada DATETIME,
@Fecha_salida DATETIME,
@Estado VARCHAR(50),
@Horas numeric(18,2),
@Observacion VARCHAR(MAX)
as
insert into Asistencias
values(@Id_personal,@Fecha_entrada,@Fecha_salida,@Estado,@Horas,@Observacion)
GO
/****** Object:  StoredProcedure [dbo].[insertarCargo]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarCargo]
@Cargo varchar(max),
@SueldoPorHora numeric(18,2)
as 
if exists (select Cargo from Cargo where Cargo = @Cargo)
Raiserror('YA EXISTE UN GRUPO CON ESTE NOMBRE, Ingrese de nuevo',16,1)
else
insert into Cargo values (@Cargo, @SueldoPorHora)
GO
/****** Object:  StoredProcedure [dbo].[insertarPermisos]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarPermisos]
@IdModulo as int,
@IdUsuario as int
as
INSERT INTO Permisos
values(@IdModulo,@IdUsuario)
GO
/****** Object:  StoredProcedure [dbo].[insertarPersonal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[insertarPersonal]
@Nombres varchar(max),
@Identificacion varchar(max),
@Pais varchar(max),
@Id_cargo int,
@SueldoPorHora numeric(18,2)
as
declare @Estado varchar(max)
declare @Codigo varchar(max)
declare @Id_personal int
set @Estado='ACTIVO'
set @Codigo='-'
if Exists(select Identificacion from Personal where Identificacion=@Identificacion)
Raiserror('Ya existe un registro con esta Identificacion',16,1)
else
Insert into Personal 
values(@Nombres ,
@Identificacion,
@Pais ,
@Id_cargo ,
@SueldoPorHora ,
@Estado ,
@Codigo )
Select @Id_personal=scope_identity()
Update Personal set Codigo = @Id_personal where Id_personal = @Id_personal
GO
/****** Object:  StoredProcedure [dbo].[insertarUsuario]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertarUsuario]
@Nombres varchar(50),
@Login varchar(50),
@Password varchar(50),
@Icono image,
@Estado varchar(50)
as
if EXISTS(SELECT Login from Usuarios where Login = @Login)
RAISERROR('YA EXISTE UN REGISTRO CON ESE USUARIO, POR FAVOR INGRESE DE NUEVO',16,1)
else
insert into Usuarios
values(@Nombres,@Login,@Password,@Icono,@Estado)
GO
/****** Object:  StoredProcedure [dbo].[mostrarPermisos]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrarPermisos]
@IdUsuario int
as
select IdModulo from Permisos where IdUsuario = @IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[mostrarPersonal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrarPersonal]
@Desde int,
@Hasta int
as
Set Nocount On;
Select 
Id_personal,Nombres,Identificacion,SueldoPorHora,Cargo,Id_cargo,Estado,Codigo,pais
from
(Select Id_personal ,Nombres,Identificacion,Personal.SueldoPorHora,Cargo.Cargo,Personal.Id_cargo,Estado,Codigo, Pais,
Row_Number() Over(Order by Id_personal) 'Numero_de_fila'
from Personal
inner join Cargo on Cargo.Id_cargo=Personal.Id_cargo ) as Paginado
Where (Paginado.Numero_de_fila >=@Desde) and (Paginado.Numero_de_fila<=@Hasta)
GO
/****** Object:  StoredProcedure [dbo].[obtenerIdUsuario]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[obtenerIdUsuario]
@Login varchar(50)
as select IdUsuario from Usuarios
where Login = @Login
GO
/****** Object:  StoredProcedure [dbo].[restaurarPersonal]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restaurarPersonal]
@Idpersonal int
as
update Personal set Estado = 'ACTIVO'
where Id_personal=@Idpersonal
GO
/****** Object:  StoredProcedure [dbo].[validarUsuario]    Script Date: 18/09/2021 11:58:39 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[validarUsuario]
@Password varchar (50),
@Login varchar(50)
as
select * from Usuarios
where Password = @Password and Login=@Login and Estado='ACTIVO'
GO
USE [master]
GO
ALTER DATABASE [ORUS369] SET  READ_WRITE 
GO
