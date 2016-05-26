
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/26/2016 16:31:56
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

IF OBJECT_ID(N'[dbo].[FK_EmployeeCorporation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_EmployeeCorporation];
GO
IF OBJECT_ID(N'[dbo].[FK_EmployeeDepartment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_EmployeeDepartment];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleFunctionRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunctionRole];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleFunctionMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunctionMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleFunctionFunction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleFunction] DROP CONSTRAINT [FK_RoleFunctionFunction];
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
IF OBJECT_ID(N'[dbo].[Function]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Function];
GO
IF OBJECT_ID(N'[dbo].[RoleFunction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleFunction];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Corporation'
CREATE TABLE [dbo].[Corporation] (
    [CorporationID] int IDENTITY(1,1) NOT NULL,
    [ParentCorpID] int  NOT NULL,
    [CorporationCode] nvarchar(30)  NULL,
    [CorporationName] nvarchar(50)  NOT NULL,
    [Address] nvarchar(100)  NOT NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [DepartmentID] int IDENTITY(1,1) NOT NULL,
    [ParentDeptID] int  NOT NULL,
    [CorporationID] int  NOT NULL,
    [DepartmentCode] nvarchar(30)  NULL,
    [DepartmentName] nvarchar(100)  NOT NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [EmployeeID] int IDENTITY(1,1) NOT NULL,
    [CorporationID] int  NOT NULL,
    [DepartmentID] int  NOT NULL,
    [RoleIDs] nvarchar(300)  NULL,
    [EmployeeName] nvarchar(30)  NOT NULL,
    [LoginName] nvarchar(30)  NOT NULL,
    [Password] nvarchar(30)  NOT NULL,
    [PwdExpiredTime] datetime  NOT NULL,
    [Sex] tinyint  NOT NULL,
    [Phone] nvarchar(30)  NULL,
    [Email] nvarchar(30)  NULL,
    [Status] tinyint  NOT NULL,
    [LoginCount] int  NOT NULL,
    [LastLoginTime] datetime  NULL,
    [LastLoginIP] nvarchar(30)  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NOT NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(50)  NOT NULL,
    [Remark] nvarchar(500)  NULL,
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
    [MenuUrl] nvarchar(100)  NOT NULL,
    [MenuLavel] int  NULL,
    [SortOrder] int  NULL,
    [MenuIcon] nvarchar(100)  NULL,
    [IsShortCut] bit  NULL,
    [IsShow] bit  NULL,
    [FunctionIDs] nvarchar(300)  NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'Function'
CREATE TABLE [dbo].[Function] (
    [FunctionID] int IDENTITY(1,1) NOT NULL,
    [FunctionName] nvarchar(30)  NOT NULL,
    [FunctionRefName] nvarchar(30)  NOT NULL,
    [CreatedBy] nvarchar(30)  NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NULL
);
GO

-- Creating table 'RoleFunction'
CREATE TABLE [dbo].[RoleFunction] (
    [RoleFunctionID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [MenuID] int  NOT NULL,
    [FunctionID] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedTime] datetime  NULL,
    [LastUpdatedBy] nvarchar(30)  NULL,
    [LastUpdatedTime] datetime  NOT NULL
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

-- Creating primary key on [FunctionID] in table 'Function'
ALTER TABLE [dbo].[Function]
ADD CONSTRAINT [PK_Function]
    PRIMARY KEY CLUSTERED ([FunctionID] ASC);
GO

-- Creating primary key on [RoleFunctionID] in table 'RoleFunction'
ALTER TABLE [dbo].[RoleFunction]
ADD CONSTRAINT [PK_RoleFunction]
    PRIMARY KEY CLUSTERED ([RoleFunctionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CorporationID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_EmployeeCorporation]
    FOREIGN KEY ([CorporationID])
    REFERENCES [dbo].[Corporation]
        ([CorporationID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeCorporation'
CREATE INDEX [IX_FK_EmployeeCorporation]
ON [dbo].[Employee]
    ([CorporationID]);
GO

-- Creating foreign key on [DepartmentID] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK_EmployeeDepartment]
    FOREIGN KEY ([DepartmentID])
    REFERENCES [dbo].[Department]
        ([DepartmentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmployeeDepartment'
CREATE INDEX [IX_FK_EmployeeDepartment]
ON [dbo].[Employee]
    ([DepartmentID]);
GO

-- Creating foreign key on [RoleID] in table 'RoleFunction'
ALTER TABLE [dbo].[RoleFunction]
ADD CONSTRAINT [FK_RoleFunctionRole]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Role]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleFunctionRole'
CREATE INDEX [IX_FK_RoleFunctionRole]
ON [dbo].[RoleFunction]
    ([RoleID]);
GO

-- Creating foreign key on [MenuID] in table 'RoleFunction'
ALTER TABLE [dbo].[RoleFunction]
ADD CONSTRAINT [FK_RoleFunctionMenu]
    FOREIGN KEY ([MenuID])
    REFERENCES [dbo].[Menu]
        ([MenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleFunctionMenu'
CREATE INDEX [IX_FK_RoleFunctionMenu]
ON [dbo].[RoleFunction]
    ([MenuID]);
GO

-- Creating foreign key on [FunctionID] in table 'RoleFunction'
ALTER TABLE [dbo].[RoleFunction]
ADD CONSTRAINT [FK_RoleFunctionFunction]
    FOREIGN KEY ([FunctionID])
    REFERENCES [dbo].[Function]
        ([FunctionID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleFunctionFunction'
CREATE INDEX [IX_FK_RoleFunctionFunction]
ON [dbo].[RoleFunction]
    ([FunctionID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------