
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/17/2016 10:05:11
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
    [CorporationID] int IDENTITY(1,1) NOT NULL,
    [CorporationCode] nvarchar(30)  NULL,
    [CorporationName] nvarchar(50)  NOT NULL,
    [ParentCorpID] int  NOT NULL,
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
    [DepartmentID] int IDENTITY(1,1) NOT NULL,
    [DepartmentCode] nvarchar(30)  NULL,
    [DepartmentName] nvarchar(100)  NOT NULL,
    [ParentDeptID] int  NOT NULL,
    [CorporationID] int  NOT NULL,
    [Sort] int  NULL,
    [Enabled] bit  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(30)  NOT NULL,
    [UserPwd] nvarchar(30)  NOT NULL,
    [EmployeeName] nvarchar(30)  NOT NULL,
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
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NULL,
    [Description] nvarchar(200)  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Menu'
CREATE TABLE [dbo].[Menu] (
    [MenuID] int IDENTITY(1,1) NOT NULL,
    [ParentMenuID] int  NOT NULL,
    [MenuName] nvarchar(30)  NOT NULL,
    [MenuCode] nvarchar(30)  NULL,
    [MenuUrl] nvarchar(100)  NOT NULL,
    [Icon] nvarchar(50)  NULL,
    [Sort] int  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'EmployeeDepartment'
CREATE TABLE [dbo].[EmployeeDepartment] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] int  NOT NULL,
    [DepartmentID] int  NOT NULL
);
GO

-- Creating table 'EmployeeRole'
CREATE TABLE [dbo].[EmployeeRole] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [EmployeeID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Button'
CREATE TABLE [dbo].[Button] (
    [ButtonID] int IDENTITY(1,1) NOT NULL,
    [ButtonName] nvarchar(50)  NULL,
    [ButtonCode] nvarchar(50)  NULL,
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
    [ID] int IDENTITY(1,1) NOT NULL,
    [MenuID] int  NOT NULL,
    [ButtonID] int  NOT NULL
);
GO

-- Creating table 'RoleMenuButton'
CREATE TABLE [dbo].[RoleMenuButton] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [MenuID] int  NOT NULL,
    [ButtonID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CorporationID] in table 'Corporation'
ALTER TABLE [dbo].[Corporation]
ADD CONSTRAINT [PK_Corporation]
    PRIMARY KEY CLUSTERED ([CorporationID] ASC);
GO

-- Creating primary key on [DepartmentID] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([DepartmentID] ASC);
GO

-- Creating primary key on [EmployeeID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [MenuID] in table 'Menu'
ALTER TABLE [dbo].[Menu]
ADD CONSTRAINT [PK_Menu]
    PRIMARY KEY CLUSTERED ([MenuID] ASC);
GO

-- Creating primary key on [ID] in table 'EmployeeDepartment'
ALTER TABLE [dbo].[EmployeeDepartment]
ADD CONSTRAINT [PK_EmployeeDepartment]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'EmployeeRole'
ALTER TABLE [dbo].[EmployeeRole]
ADD CONSTRAINT [PK_EmployeeRole]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ButtonID] in table 'Button'
ALTER TABLE [dbo].[Button]
ADD CONSTRAINT [PK_Button]
    PRIMARY KEY CLUSTERED ([ButtonID] ASC);
GO

-- Creating primary key on [ID] in table 'MenuButton'
ALTER TABLE [dbo].[MenuButton]
ADD CONSTRAINT [PK_MenuButton]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'RoleMenuButton'
ALTER TABLE [dbo].[RoleMenuButton]
ADD CONSTRAINT [PK_RoleMenuButton]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------