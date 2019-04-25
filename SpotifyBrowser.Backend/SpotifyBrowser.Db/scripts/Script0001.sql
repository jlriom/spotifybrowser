
IF NOT EXISTS(select * from  [dbo].[AspNetUsers]) 
BEGIN
	BEGIN TRANSACTION
	INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'151dba72-2400-43d6-9e33-cadbb71b865b', N'admin@globomantics.com', N'ADMIN@GLOBOMANTICS.COM', N'admin@globomantics.com', N'ADMIN@GLOBOMANTICS.COM', 0, N'AQAAAAEAACcQAAAAECi3ahkgYfuCpckglBbY8R8Ah52Jk/FAXgAg7QNkul4+VWx4eADyFQ0FyS4cS8tFcg==', N'9ea80b23-9b95-4f25-b932-38cf1a713a1c', N'f1ea7244-12e2-4bf4-9d38-d774ec372d4b', NULL, 0, 0, NULL, 1, 0)
	INSERT INTO [dbo].[UserProfiles] ([Id], [Email], [FirstName], [LastName], [UserState]) VALUES (N'151dba72-2400-43d6-9e33-cadbb71b865b', N'admin@jl.org', N'jl', N'riom', 0)
	COMMIT TRANSACTION
END