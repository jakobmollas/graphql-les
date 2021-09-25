USE [graphql-les]
GO
SET IDENTITY_INSERT [dbo].[Platforms] ON 
GO
INSERT [dbo].[Platforms] ([Id], [Name], [LicensKey]) VALUES (1, N'.NET 5', NULL)
GO
INSERT [dbo].[Platforms] ([Id], [Name], [LicensKey]) VALUES (2, N'Docker', NULL)
GO
INSERT [dbo].[Platforms] ([Id], [Name], [LicensKey]) VALUES (3, N'Windows', N'123abc123')
GO
INSERT [dbo].[Platforms] ([Id], [Name], [LicensKey]) VALUES (4, N'Ubuntu', NULL)
GO
INSERT [dbo].[Platforms] ([Id], [Name], [LicensKey]) VALUES (5, N'Debian', NULL)
GO
INSERT [dbo].[Platforms] ([Id], [Name], [LicensKey]) VALUES (6, N'C64', NULL)
GO
SET IDENTITY_INSERT [dbo].[Platforms] OFF
GO
SET IDENTITY_INSERT [dbo].[Commands] ON 
GO
INSERT [dbo].[Commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (8, N'build a project', N'dotnet build', 1)
GO
INSERT [dbo].[Commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (9, N'run a project', N'dotnet run', 1)
GO
INSERT [dbo].[Commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (10, N'start docker compose', N'dotnet-compose up -d', 2)
GO
INSERT [dbo].[Commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (11, N'Restore NuGet packages in project/solution', N'dotnet restore', 1)
GO
INSERT [dbo].[Commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (12, N'Show program listing', N'list', 6)
GO
INSERT [dbo].[Commands] ([Id], [HowTo], [CommandLine], [PlatformId]) VALUES (13, N'run program', N'run', 6)
GO
SET IDENTITY_INSERT [dbo].[Commands] OFF
GO
