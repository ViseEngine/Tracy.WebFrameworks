USE WebFrameworksDB;
GO


--公司
SELECT * FROM dbo.Corporation(NOLOCK) AS corp
ORDER BY corp.Code, corp.Sort;

--部门
SELECT * FROM dbo.Department(NOLOCK) AS department
WHERE department.CorporationId= 5;

--部门带出公司名称
SELECT department.*, corp.Name FROM dbo.Department(NOLOCK) AS department
LEFT JOIN dbo.Corporation(NOLOCK) AS corp ON department.CorporationId= corp.Id
ORDER BY department.CorporationId, department.Code;


--用户
SELECT * FROM dbo.[User] AS user1;

--用户-部门
SELECT * FROM dbo.UserDepartment AS userDepart;

--用户-角色
SELECT * FROM dbo.UserRole AS userRole
WHERE userRole.UserId= 1;

--角色
SELECT * FROM dbo.Role;

--菜单
SELECT * FROM dbo.Menu;

--按钮
SELECT * FROM dbo.Button;

--
SELECT * FROM dbo.RoleMenuButton AS roleMenuButton
WHERE roleMenuButton.RoleId= 1;

--权限
SELECT button.*, * FROM dbo.[User] AS user1
LEFT JOIN dbo.UserRole AS userRole ON userRole.UserId= user1.Id
LEFT JOIN dbo.RoleMenuButton AS roleMenuButton ON roleMenuButton.RoleId= userRole.RoleId
LEFT JOIN dbo.Menu AS menu ON menu.Id= roleMenuButton.MenuId
LEFT JOIN dbo.Button AS button ON button.Id= roleMenuButton.ButtonId
WHERE user1.Id= 1
AND menu.Code= 'depart';

--手动赋权
--INSERT INTO dbo.RoleMenuButton
--        ( RoleId, MenuId, ButtonId )
--VALUES  ( 1,7,2),
--		( 1,7,3),
--		( 1,7,4),
--		( 1,7,11),
--		( 1,7,12);


