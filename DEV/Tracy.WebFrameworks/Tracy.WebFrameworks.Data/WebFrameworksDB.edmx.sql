
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/27/2016 15:43:30
-- Generated from EDMX file: D:\sources.github\Tracy.WebFrameworks\DEV\Tracy.WebFrameworks\Tracy.WebFrameworks.Data\WebFrameworksDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [WebFrameworksDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CorporationDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Department] DROP CONSTRAINT [FK_CorporationDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmployeeDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeDepartment] DROP CONSTRAINT [FK_EmployeeEmployeeDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_DepartmentEmployeeDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeDepartment] DROP CONSTRAINT [FK_DepartmentEmployeeDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuMenuButton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuButton] DROP CONSTRAINT [FK_MenuMenuButton];
GO
IF OBJECT_ID(N'[dbo].[FK_ButtonMenuButton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MenuButton] DROP CONSTRAINT [FK_ButtonMenuButton];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleRoleMenuButton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleMenuButton] DROP CONSTRAINT [FK_RoleRoleMenuButton];
GO
IF OBJECT_ID(N'[dbo].[FK_MenuRoleMenuButton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleMenuButton] DROP CONSTRAINT [FK_MenuRoleMenuButton];
GO
IF OBJECT_ID(N'[dbo].[FK_ButtonRoleMenuButton]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleMenuButton] DROP CONSTRAINT [FK_ButtonRoleMenuButton];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeEmployeeRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeRole] DROP CONSTRAINT [FK_EmployeeEmployeeRole];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleEmployeeRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmployeeRole] DROP CONSTRAINT [FK_RoleEmployeeRole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Corporation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Corporation];
GO
IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Menu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menu];
GO
IF OBJECT_ID(N'[dbo].[EmployeeDepartment]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeDepartment];
GO
IF OBJECT_ID(N'[dbo].[EmployeeRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmployeeRole];
GO
IF OBJECT_ID(N'[dbo].[Button]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Button];
GO
IF OBJECT_ID(N'[dbo].[MenuButton]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MenuButton];
GO
IF OBJECT_ID(N'[dbo].[RoleMenuButton]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleMenuButton];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Corporation'
CREATE TABLE [dbo].[Corporation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(30)  NULL,
    [Name] nvarchar(50)  NOT NULL,
    [ParentId] int  NOT NULL,
    [Sort] int  NULL,
    [Enabled] bit  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(30)  NULL,
    [Name] nvarchar(100)  NOT NULL,
    [ParentId] int  NOT NULL,
    [CorporationId] int  NOT NULL,
    [Sort] int  NULL,
    [Enabled] bit  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(30)  NOT NULL,
    [UserPwd] nvarchar(32)  NOT NULL,
    [UserName] nvarchar(30)  NOT NULL,
    [Enabled] bit  NULL,
    [IsChangePwd] bit  NOT NULL,
    [Description] nvarchar(200)  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NOT NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Description] nvarchar(200)  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Menu'
CREATE TABLE [dbo].[Menu] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ParentId] int  NOT NULL,
    [Name] nvarchar(30)  NOT NULL,
    [Code] nvarchar(30)  NULL,
    [Url] nvarchar(100)  NULL,
    [Icon] nvarchar(50)  NULL,
    [Sort] int  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'UserDepartment'
CREATE TABLE [dbo].[UserDepartment] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [DepartmentId] int  NOT NULL
);
GO

-- Creating table 'UserRole'
CREATE TABLE [dbo].[UserRole] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'Button'
CREATE TABLE [dbo].[Button] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Code] nvarchar(50)  NULL,
    [Icon] nvarchar(50)  NULL,
    [Sort] int  NULL,
    [CreatedBy] nvarchar(50)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(50)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'MenuButton'
CREATE TABLE [dbo].[MenuButton] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MenuId] int  NOT NULL,
    [ButtonId] int  NOT NULL
);
GO

-- Creating table 'RoleMenuButton'
CREATE TABLE [dbo].[RoleMenuButton] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [MenuId] int  NOT NULL,
    [ButtonId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Corporation'
ALTER TABLE [dbo].[Corporation]
ADD CONSTRAINT [PK_Corporation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Menu'
ALTER TABLE [dbo].[Menu]
ADD CONSTRAINT [PK_Menu]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserDepartment'
ALTER TABLE [dbo].[UserDepartment]
ADD CONSTRAINT [PK_UserDepartment]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserRole'
ALTER TABLE [dbo].[UserRole]
ADD CONSTRAINT [PK_UserRole]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Button'
ALTER TABLE [dbo].[Button]
ADD CONSTRAINT [PK_Button]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MenuButton'
ALTER TABLE [dbo].[MenuButton]
ADD CONSTRAINT [PK_MenuButton]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleMenuButton'
ALTER TABLE [dbo].[RoleMenuButton]
ADD CONSTRAINT [PK_RoleMenuButton]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------