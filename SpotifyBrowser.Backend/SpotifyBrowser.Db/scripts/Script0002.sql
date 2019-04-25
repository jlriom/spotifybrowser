
IF NOT EXISTS(select * from  [dbo].[AspNetRoles]) 
BEGIN
	BEGIN TRANSACTION
	INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'admin', N'Admin', N'admin', NULL);
	INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'151dba72-2400-43d6-9e33-cadbb71b865b', N'admin');
	COMMIT TRANSACTION
END