USE WebFrameworksDB;
GO


--公司
SELECT * FROM dbo.Corporation AS corp

--部门
SELECT * FROM dbo.Department AS department
WHERE department.CorporationId= 5;

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
AND menu.Code= 'corp';

--手动赋权
--INSERT INTO dbo.RoleMenuButton
--        ( RoleId, MenuId, ButtonId )
--VALUES  ( 1,6,2),
--		( 1,6,3),
--		( 1,6,4);


