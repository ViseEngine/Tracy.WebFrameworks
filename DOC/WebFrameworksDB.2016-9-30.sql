USE [WebFrameworksDB]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserRole] ON
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId]) VALUES (1, 1, 1)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId]) VALUES (2, 2, 1)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId]) VALUES (3, 2, 2)
INSERT [dbo].[UserRole] ([Id], [UserId], [RoleId]) VALUES (4, 3, 3)
SET IDENTITY_INSERT [dbo].[UserRole] OFF
/****** Object:  Table [dbo].[UserDepartment]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDepartment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_UserDepartment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserDepartment] ON
INSERT [dbo].[UserDepartment] ([Id], [UserId], [DepartmentId]) VALUES (1, 1, 1)
INSERT [dbo].[UserDepartment] ([Id], [UserId], [DepartmentId]) VALUES (2, 2, 8)
INSERT [dbo].[UserDepartment] ([Id], [UserId], [DepartmentId]) VALUES (3, 3, 11)
SET IDENTITY_INSERT [dbo].[UserDepartment] OFF
/****** Object:  Table [dbo].[User]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](30) NOT NULL,
	[UserPwd] [nvarchar](32) NOT NULL,
	[UserName] [nvarchar](30) NOT NULL,
	[Enabled] [bit] NULL,
	[IsChangePwd] [bit] NOT NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](30) NULL,
	[CreatedTime] [datetime] NOT NULL,
	[LastUpdatedBy] [nvarchar](30) NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([Id], [UserId], [UserPwd], [UserName], [Enabled], [IsChangePwd], [Description], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (1, N'admin', N'21232f297a57a5a743894a0e4a801fc3', N'系统管理员', 1, 1, N'系统管理员有最高权限', N'admin', CAST(0x0000A65001178843 AS DateTime), NULL, NULL)
INSERT [dbo].[User] ([Id], [UserId], [UserPwd], [UserName], [Enabled], [IsChangePwd], [Description], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (2, N'luning', N'202cb962ac59075b964b07152d234b70', N'鲁宁', 1, 0, N'', N'鲁宁的帐号', CAST(0x0000A65001178843 AS DateTime), NULL, NULL)
INSERT [dbo].[User] ([Id], [UserId], [UserPwd], [UserName], [Enabled], [IsChangePwd], [Description], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (3, N'test', N'202cb962ac59075b964b07152d234b70', N'测试帐号', 1, 0, N'测试的帐号', N'admin', CAST(0x0000A65001178843 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[RoleMenuButton]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleMenuButton](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[MenuId] [int] NOT NULL,
	[ButtonId] [int] NOT NULL,
 CONSTRAINT [PK_RoleMenuButton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[RoleMenuButton] ON
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (1, 1, 6, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (2, 1, 7, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (3, 1, 8, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (4, 1, 9, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (5, 1, 10, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (6, 1, 11, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (7, 1, 12, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (8, 1, 13, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (9, 1, 14, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (10, 1, 15, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (11, 1, 16, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (12, 1, 17, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (13, 1, 18, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (14, 1, 19, 1)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (15, 1, 1, 0)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (16, 1, 2, 0)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (17, 1, 3, 0)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (18, 1, 4, 0)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (19, 1, 5, 0)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (20, 1, 6, 2)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (21, 1, 6, 3)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (22, 1, 6, 4)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (23, 1, 7, 2)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (24, 1, 7, 3)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (25, 1, 7, 4)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (26, 1, 7, 11)
INSERT [dbo].[RoleMenuButton] ([Id], [RoleId], [MenuId], [ButtonId]) VALUES (27, 1, 7, 12)
SET IDENTITY_INSERT [dbo].[RoleMenuButton] OFF
/****** Object:  Table [dbo].[Role]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](200) NULL,
	[CreatedBy] [nvarchar](30) NULL,
	[CreatedTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](30) NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([Id], [Name], [Description], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (1, N'超级管理员', N'超级管理员有最高权限', N'admin', CAST(0x0000A651002F6DCC AS DateTime), NULL, NULL)
INSERT [dbo].[Role] ([Id], [Name], [Description], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (2, N'研发部主管', N'研发部主管的角色', N'admin', CAST(0x0000A651002F6DCC AS DateTime), NULL, NULL)
INSERT [dbo].[Role] ([Id], [Name], [Description], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (3, N'客服部主管', N'客服部主管的角色', N'admin', CAST(0x0000A651002F6DCC AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[MenuButton]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MenuButton](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MenuId] [int] NOT NULL,
	[ButtonId] [int] NOT NULL,
 CONSTRAINT [PK_MenuButton] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MenuButton] ON
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (1, 5, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (2, 6, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (3, 7, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (4, 8, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (5, 9, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (6, 10, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (7, 11, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (8, 12, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (9, 13, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (10, 14, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (11, 15, 1)
INSERT [dbo].[MenuButton] ([Id], [MenuId], [ButtonId]) VALUES (12, 16, 1)
SET IDENTITY_INSERT [dbo].[MenuButton] OFF
/****** Object:  Table [dbo].[Menu]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [nvarchar](30) NOT NULL,
	[Code] [nvarchar](30) NULL,
	[Url] [nvarchar](100) NULL,
	[Icon] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[CreatedBy] [nvarchar](30) NULL,
	[CreatedTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](30) NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Menu] ON
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (1, 0, N'系统管理', NULL, N'#', N'icon-cog', 1, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (2, 0, N'其它', NULL, N'#', N'icon-cog', 2, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (3, 1, N'权限管理', NULL, N'#', N'icon-cog', 1, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (4, 1, N'日志管理', NULL, N'#', N'icon-cog', 2, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (5, 2, N'流程管理', NULL, N'#', N'icon-cog', 1, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (6, 3, N'公司管理', N'corp', N'Corporation/Index', N'icon-cog', 1, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (7, 3, N'部门管理', N'depart', N'Department/Index', N'icon-cog', 2, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (8, 3, N'用户管理', N'user', N'User/Index', N'icon-cog', 3, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (9, 3, N'角色管理', N'role', N'Role/Index', N'icon-cog', 4, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (10, 3, N'菜单管理', N'menu', N'Menu/Index', N'icon-cog', 5, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (11, 3, N'按钮管理', N'button', N'Button/Index', N'icon-cog', 6, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (12, 3, N'图标管理', N'icon', N'Icon/Index', N'icon-cog', 7, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (13, 4, N'调试日志', N'debug', N'/DebugLog/Index', N'icon-cog', 1, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (14, 4, N'错误日志', N'error', N'/ErrorLog/Index', N'icon-cog', 2, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (15, 4, N'性能日志', N'performance', N'/PerformanceLog/Index', N'icon-cog', 3, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (16, 4, N'Xml日志', N'xml', N'/XmlLog/Index', N'icon-cog', 4, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (17, 5, N'表单定义', N'formdefine', N'/FormDefine/Index', N'icon-cog', 1, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (18, 5, N'流程定义', N'flowdefine', N'/FlowDefine/Index', N'icon-cog', 2, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
INSERT [dbo].[Menu] ([Id], [ParentId], [Name], [Code], [Url], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (19, 5, N'流程监控', N'flowmonitor', N'/FlowMonitor/Index', N'icon-cog', 3, N'admin', CAST(0x0000A65100317298 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Menu] OFF
/****** Object:  Table [dbo].[Department]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NULL,
	[Name] [nvarchar](100) NOT NULL,
	[ParentId] [int] NOT NULL,
	[CorporationId] [int] NOT NULL,
	[Sort] [int] NULL,
	[Enabled] [bit] NULL,
	[CreatedBy] [nvarchar](30) NULL,
	[CreatedTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](30) NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Department] ON
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (1, N'01', N'总经办', 0, 5, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (2, N'02', N'人力资源部', 0, 5, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (3, N'03', N'研发部', 0, 5, 3, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (4, N'04', N'销售部', 0, 5, 4, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (5, N'05', N'客服部', 0, 5, 5, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (6, N'0201', N'人力资源1部', 2, 5, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (7, N'0202', N'人力资源2部', 2, 5, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (8, N'0301', N'.net开发组', 3, 5, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (9, N'0302', N'java开发组', 3, 5, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (10, N'0303', N'前端开发组', 3, 5, 3, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (11, N'0401', N'销售1部', 4, 5, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (12, N'0402', N'销售2部', 4, 5, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (13, N'0501', N'国内机票组', 5, 5, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (14, N'0502', N'国际机票组', 5, 5, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (15, N'0503', N'酒店组', 5, 5, 3, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (16, N'0504', N'火车票组', 5, 5, 4, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (17, N'01', N'人力资源部', 0, 2, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (18, N'02', N'财务部', 0, 2, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (19, N'03', N'企划部', 0, 2, 3, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (20, N'04', N'工程部', 0, 2, 4, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (21, N'05', N'品质部', 0, 2, 5, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (22, N'0501', N'IQC', 21, 2, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (23, N'0502', N'IPQC', 21, 2, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (24, N'0503', N'OQC', 21, 2, 3, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (25, N'0401', N'PD', 20, 2, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (26, N'0402', N'EE', 20, 2, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (27, N'01', N'总裁办', 0, 7, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (28, N'02', N'人力资源部', 0, 7, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (29, N'03', N'IT资讯部', 0, 7, 3, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (30, N'04', N'品质保证部', 0, 7, 4, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (31, N'05', N'IE工程部', 0, 7, 5, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (32, N'0301', N'OA组', 29, 7, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (33, N'0302', N'网络组', 29, 7, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (34, N'0401', N'IQC', 30, 7, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (35, N'0402', N'OQC', 30, 7, 2, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (36, N'0501', N'IE一组', 31, 7, 1, 1, N'admin', CAST(0x0000A651002C3F58 AS DateTime), NULL, NULL)
INSERT [dbo].[Department] ([Id], [Code], [Name], [ParentId], [CorporationId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (37, N'0304', N'测试组', 3, 5, 4, 1, N'admin', CAST(0x0000A69101292049 AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Department] OFF
/****** Object:  Table [dbo].[Corporation]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corporation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](30) NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Sort] [int] NULL,
	[Enabled] [bit] NULL,
	[CreatedBy] [nvarchar](30) NULL,
	[CreatedTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](30) NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_Corporation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Corporation] ON
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (1, N'01', N'携瑞集团', 0, 1, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (2, N'0101', N'北京分公司', 1, 2, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (3, N'0102', N'上海分公司', 1, 3, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (4, N'0103', N'广州分公司', 1, 4, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (5, N'0104', N'深圳分公司', 1, 5, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (6, N'02', N'富士康科技集团', 0, 2, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (7, N'0201', N'深圳总部', 6, 1, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (8, N'0202', N'郑州科技园', 6, 2, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (9, N'0203', N'成都科技园', 6, 3, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (10, N'0204', N'南海科技园', 6, 4, 1, N'admin', CAST(0x0000A65000A7F9F4 AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (11, N'020101', N'群创科技', 7, 1, 1, N'admin', CAST(0x0000A69100B1AA1E AS DateTime), NULL, NULL)
INSERT [dbo].[Corporation] ([Id], [Code], [Name], [ParentId], [Sort], [Enabled], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (12, N'02010101', N'群创科技一分公司', 11, 1, 1, N'admin', CAST(0x0000A6910107D59C AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Corporation] OFF
/****** Object:  Table [dbo].[Button]    Script Date: 09/30/2016 18:05:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Button](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Code] [nvarchar](50) NULL,
	[Icon] [nvarchar](50) NULL,
	[Sort] [int] NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[CreatedTime] [datetime] NULL,
	[LastUpdatedBy] [nvarchar](50) NULL,
	[LastUpdatedTime] [datetime] NULL,
 CONSTRAINT [PK_Button] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Button] ON
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (1, N'浏览', N'browser', N'icon-eye', 1, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (2, N'添加', N'add', N'icon-add', 2, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (3, N'修改', N'edit', N'icon-application_edit', 3, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (4, N'删除', N'delete', N'icon-delete', 4, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (5, N'导入', N'import', N'icon-page_excel', 5, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (6, N'导出', N'export', N'icon-page_excel', 6, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (7, N'设置部门', N'setdepartment', N'icon-group', 7, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (8, N'设置角色', N'setrole', N'icon-user_key', 8, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (9, N'角色授权', N'authorize', N'icon-key', 9, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (10, N'分配按钮', N'setbutton', N'icon-link', 10, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (11, N'全部展开', N'expandall', N'icon-expand', 11, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
INSERT [dbo].[Button] ([Id], [Name], [Code], [Icon], [Sort], [CreatedBy], [CreatedTime], [LastUpdatedBy], [LastUpdatedTime]) VALUES (12, N'全部折叠', N'collapseall', N'icon-collapse', 12, N'admin', CAST(0x0000A651003CA62C AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Button] OFF
