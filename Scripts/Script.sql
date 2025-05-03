--25/08/2022
Go
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Discriminator], [active], [FirstName], [LastName], [DefaultLanguageId]) VALUES (N'9e0568ef-f131-4044-9bd9-8d49d186d278', N'admin', N'admin', N'admin@admin.com', N'admin', 1, N'AQAAAAEAACcQAAAAEO4I/NmCySe1oH1fJTXbZNrILcoRPCD0TMM/Nx8ZYlrCc664QMKyrO8HtR7eS6YCBg==', N'6cb0a025-6ff5-48e2-b6e7-054709bcfa1a', N'c87363fe-2e7a-4b54-a7ab-5a8cd2abed48', N'+111111111111', 1, 0, NULL, 0, 0, N'AppUser', 1, N'Admin', N'Admin', null)
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6429d7af-9cc3-4a67-bd9b-d3632a78ca7b', N'Administrator', N'Administrator', N'b912b7eb-d2e5-41e6-a683-a66233acd310')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9e0568ef-f131-4044-9bd9-8d49d186d278', N'6429d7af-9cc3-4a67-bd9b-d3632a78ca7b')
GO


go
SET IDENTITY_INSERT [dbo].[Languages] ON 
GO
INSERT [dbo].[Languages] ([Id], [Name], [Code], [Active], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (1, N'Albanian', N'sq', 1, NULL, CAST(N'2021-09-02T10:10:45.0454628' AS DateTime2), NULL, CAST(N'2022-04-15T09:45:02.6227956' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Languages] ([Id], [Name], [Code], [Active], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (2, N'English', N'en', 1, NULL, CAST(N'2021-09-02T10:10:45.0458184' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Languages] ([Id], [Name], [Code], [Active], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (3, N'Serbian', N'sr', 1, NULL, CAST(N'2021-09-02T10:10:45.0458334' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[Localizations] ON 
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4552, N'Shared', N'Share', N'Ndaje', N'Ndaje', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-24T16:02:46.6923468' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4553, N'Shared', N'AppTitle', N'Prokurimi', N'Prokurimi', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-10-26T16:46:15.3695498' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4554, N'Shared', N'PortalMenu', N'Portali', N'Portali', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4556, N'Shared', N'AdministrationMenu', N'Administrimi', N'Administrimi', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4557, N'Shared', N'UsersMenu', N'Përdoruesit', N'Përdoruesit', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4558, N'Shared', N'LangMenu', N'Gjuhët', N'Gjuhet', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-15T11:15:36.6375841' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4559, N'Shared', N'ListsMenu', N'Listat', N'Listat', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4560, N'Shared', N'LocalizationMenu', N'Lokalizimi', N'Lokalizimi', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4562, N'Shared', N'ManageMenu', N'Menaxhimi', N'Perdoret ne homepage', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4563, N'Shared', N'RepOfKosovaMenu', N'Prokurimi', N'Prokurimi', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4564, N'Shared', N'Username', N'Përdoruesi', N'Perdoruesi', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4565, N'Shared', N'Password', N'Fjalëkalimi', N'Pass', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4566, N'Shared', N'Login', N'Kyçu', N'Perdoret ne butona', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4567, N'Shared', N'Logout', N'Dil', N'Dil', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4570, N'Shared', N'ValidFrom', N'Në fuqi nga', N'Valid nga', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-21T10:00:43.1510474' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4571, N'Shared', N'ValidTo', N'Në fuqi deri', N'Valid deri', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-21T10:01:17.3343515' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4572, N'Shared', N'Search', N'Kërko', N'Kërko', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4573, N'Shared', N'CreateNew', N'Krijo të ri', N'Krijo të ri', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-23T15:29:28.5479504' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4574, N'Shared', N'Actions', N'Veprimet', N'Veprimet', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4576, N'Shared', N'Title', N'Titulli', N'Titulli', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4578, N'Shared', N'Documents', N'Dokumentet', N'Dokumentet', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4580, N'Shared', N'Details', N'Detajet', N'Details', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4581, N'Shared', N'Preview', N'Verzioni origjinal', N'Preview', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-02-23T16:37:27.5138759' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4582, N'Shared', N'Translations', N'Përkthimet', N'Translations', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4584, N'Shared', N'Edit', N'Ndrysho', N'Edit', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4585, N'Shared', N'Delete', N'Fshij', N'Delete', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4588, N'Shared', N'TranslationStatus', N'Statusi i përkthimit', N'TranslationStatus', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4590, N'Shared', N'PublicationDate', N'Data e publikimit', N'PublicationDate', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4591, N'Shared', N'ApplicationDate', N'Data e hyrjes në fuqi', N'Te futja e dokumentit ligjor', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4592, N'Shared', N'IsFinal', N'Është finale', N'ApplicationDate', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4594, N'Shared', N'IsCode', N'Është  kod', N'IsCode', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4596, N'Shared', N'Description', N'Përshkrimi', N'Description', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4597, N'Shared', N'Save', N'Ruaj', N'Save', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4598, N'Shared', N'Close', N'Mbyll', N'Close', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4599, N'Shared', N'Add', N'Shto', N'Add', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4601, N'Shared', N'Language', N'Gjuha', N'Language', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4606, N'Shared', N'Number', N'Numri', N'Number', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4607, N'Shared', N'Type', N'Lloji', N'Type', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-15T14:39:58.9298049' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4608, N'Shared', N'Action', N'Veprimi', N'Type', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4618, N'Shared', N'Date', N'Data', N'Date', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4621, N'Shared', N'Saving', N'Duke ruajtur', N'Saving', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4622, N'Shared', N'Choose', N'Zgjidh', N'Choose', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4628, N'Shared', N'Content', N'Përmbajtja', N'Content', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4629, N'Shared', N'QualityCheck', N'Cilësia', N'QualityCheck', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-10T11:25:36.7192993' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4630, N'Shared', N'Notes', N'Shënime', N'Notës', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-14T16:13:42.0997918' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4635, N'Shared', N'ChangeType', N'Lloji i ndryshimit', N'Node on the new Law', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-16T10:11:22.4033005' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4636, N'Shared', N'ReferencedFrom', N'Referuar nga', N'Node on the new Law', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4639, N'Shared', N'TranslatedOnLang', N'Përkthyer në gjuhën', N'Translated on language', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4640, N'Shared', N'Next', N'Tjetra', N'Next', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4641, N'Shared', N'Previous', N'E mëparshme', N'Previous', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4642, N'Shared', N'Access', N'Qasja', N'Access', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4644, N'Shared', N'Name', N'Emri', N'Name', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4645, N'Shared', N'AreYouSure', N'A jeni i sigurtë?', N'Are you sure?', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4646, N'Shared', N'Confirm', N'Konfirmoni', N'Confirm', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4647, N'Shared', N'Yes', N'Po', N'Yes', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4649, N'Shared', N'From', N'Nga', N'From', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4650, N'Shared', N'To', N'Deri', N'To', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4654, N'Shared', N'SearchCriteria', N'Kriteret e kërkimit', N'Search criteria', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4656, N'Shared', N'FristName', N'Emri', N'First name', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4657, N'Shared', N'LastName', N'Mbiemri', N'Last name', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4658, N'Shared', N'Role', N'Roli', N'Role', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4659, N'Shared', N'DefaultLanguage', N'Gjuha e paracaktuar', N'Default language', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4660, N'Shared', N'IsActive', N'Është aktiv', N'Is active', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4661, N'Shared', N'Roles', N'Rolet', N'Roles', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4662, N'Shared', N'Translator', N'Përkthyes  ', N'Translator', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4663, N'Shared', N'TranslationSupervisor', N'Mbikëqyrësi i përkthimit  ', N'Translation supervisor', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4664, N'Shared', N'Administrator', N'Administratori', N'Administrator', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4665, N'Shared', N'DataEntrySupervisor', N'Mbikëqyrësi i futjes së të dhënave', N'Data entry supervisor', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4666, N'Shared', N'OverallSupervisor', N'Mbikëqyrësi i përgjithshëm', N' Overall supervisor', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4667, N'Shared', N'Code', N'Kod', N'Code', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-15T09:15:49.3030774' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4668, N'Shared', N'EditLanguage', N'Edito gjuhën', N'Edit Language', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4669, N'Shared', N'Languages', N'Gjuhët', N'Languages', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4670, N'Shared', N'Lists', N'Listat', N'Lists', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4671, N'Shared', N'TranslationIn', N'Përkthimi në', N'Translation in', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4672, N'Shared', N'OrderIndex', N'Renditja', N'Order Index', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4673, N'Shared', N'SaveOrder', N'Ruaj renditjen', N'Save Order', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4674, N'Shared', N'ListTranslations', N'  Lista e përkthimeve', N'List translations', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4675, N'Shared', N'BackToList', N'Kthehu tek lista', N'Back to list', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4676, N'Shared', N'ResourceKey', N'Resource', N'Resource Key', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4677, N'Shared', N'KeyValue', N'Vlera', N'Key value', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4678, N'Shared', N'KeyName', N'Token', N'Key name', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4679, N'Shared', N'Synonyms', N'Sinonimi i emrit', N'Synonym of name', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4680, N'Shared', N'TranslationEditor', N'Editor i përkthimit', N'Translation editor', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4681, N'Shared', N'Clear', N'Pastro', N'Clear', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4682, N'Shared', N'ResetPassword', N'Rivendosni fjalëkalimin', N'Reset password', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4683, N'Shared', N'NewPassword', N'Fjalëkalim i ri  ', N'New password', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4684, N'Shared', N'SearchbyUsername', N'Kërko me emrin e përdoruesit', N'Search by username', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4685, N'Shared', N'AdministrationUsers', N'Administrimi i përdoruesve', N'Administration users', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4686, N'Shared', N'TypeNewPassword', N'Shkruaj fjalëkalimin e ri', N'Type new password', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4691, N'Shared', N'HasValidity', N'Është valide', N'Has Validity', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-15T16:16:59.6085899' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4693, N'Shared', N'LanguageTranlsation', N'Gjuha e përkthimit', N'Language Tranlsation', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-16T10:09:09.3183469' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4705, N'Shared', N'SourceDocs', N'Dokumentet burimore', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-15T11:33:22.9740904' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4706, N'Shared', N'Translated', N'Përkthyer', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-15T11:54:30.4813812' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4708, N'Shared', N'AppTitle', N'Assembly of the Republic of Kosovo', N'Titulli', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4709, N'Shared', N'PortalMenu', N'Portal', N'Portali', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4711, N'Shared', N'AdministrationMenu', N'Administration', N'Administrimi', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4712, N'Shared', N'UsersMenu', N'Users', N'Përdoruesit', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4713, N'Shared', N'LangMenu', N'Languages', N'Gjuhet', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4714, N'Shared', N'ListsMenu', N'Lists', N'Lists', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4715, N'Shared', N'LocalizationMenu', N'Localization', N'Lokalizimi', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4717, N'Shared', N'ManageMenu', N'Manage', N'Manage', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4718, N'Shared', N'RepOfKosovaMenu', N'Republic of Kosova', N'Republika e Kosovës', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4719, N'Shared', N'Username', N'Username', N'Perdoruesi', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4720, N'Shared', N'Password', N'Password', N'Pass', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4721, N'Shared', N'Login', N'Login', N'Login', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4722, N'Shared', N'Logout', N'Logout', N'Logout', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4725, N'Shared', N'ValidFrom', N'Valid from', N'Search with Law number', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4726, N'Shared', N'ValidTo', N'Valid to', N'Valid to', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4727, N'Shared', N'Search', N'Search', N'Search', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4728, N'Shared', N'CreateNew', N'Create new', N'Create new', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4729, N'Shared', N'Actions', N'Actions', N'Actions', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4731, N'Shared', N'Title', N'Title', N'Title', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4733, N'Shared', N'Documents', N'Documents', N'Documents', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4735, N'Shared', N'Details', N'Details', N'Details', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4736, N'Shared', N'Preview', N'Original version', N'Original version', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-04-29T09:42:51.3017548' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4737, N'Shared', N'Translations', N'Translations', N'Translations', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4739, N'Shared', N'Edit', N'Edit', N'Edit', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4740, N'Shared', N'Delete', N'Delete', N'Delete', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4743, N'Shared', N'TranslationStatus', N'Translation status', N'TranslationStatus', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4745, N'Shared', N'PublicationDate', N'Publication date', N'PublicationDate', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4746, N'Shared', N'ApplicationDate', N'Application date', N'ApplicationDate', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4747, N'Shared', N'IsFinal', N'Is final', N'Is final', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:07:54.4351447' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4749, N'Shared', N'IsCode', N'Is code', N'IsCode', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4751, N'Shared', N'Description', N'Description', N'Description', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4752, N'Shared', N'Save', N'Save', N'Save', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4753, N'Shared', N'Close', N'Close', N'Close', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4754, N'Shared', N'Add', N'Add', N'Add', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4756, N'Shared', N'Language', N'Language', N'Language', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4761, N'Shared', N'Number', N'Number', N'Number', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4762, N'Shared', N'Type', N'Type', N'Type', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4763, N'Shared', N'Action', N'Action', N'Action', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4773, N'Shared', N'Date', N'Date', N'Date', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4776, N'Shared', N'Saving', N'Saving', N'Saving', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4777, N'Shared', N'Choose', N'Choose', N'Choose', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4783, N'Shared', N'Content', N'Content', N'Content', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4784, N'Shared', N'QualityCheck', N'Quality Check', N'QualityCheck', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4785, N'Shared', N'Notes', N'Notes', N'Notes', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4790, N'Shared', N'ChangeType', N'Change type', N'Change type', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:09:53.2677658' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4791, N'Shared', N'ReferencedFrom', N'Referenced from', N'Referenced from', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:10:02.9002275' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4794, N'Shared', N'TranslatedOnLang', N'Translated on language', N'Translated on language', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4795, N'Shared', N'Next', N'Next', N'Next', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4796, N'Shared', N'Previous', N'Previous', N'Previous', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4797, N'Shared', N'Access', N'Access', N'Access', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4799, N'Shared', N'Name', N'Name', N'Name', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4800, N'Shared', N'AreYouSure', N'Are you sure?', N'Are you sure?', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4801, N'Shared', N'Confirm', N'Confirm', N'Confirm', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4802, N'Shared', N'Yes', N'Yes', N'Yes', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4804, N'Shared', N'From', N'From', N'From', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4805, N'Shared', N'To', N'To', N'To', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4809, N'Shared', N'SearchCriteria', N'Search criteria', N'Search criteria', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4811, N'Shared', N'FristName', N'First name', N'First name', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4812, N'Shared', N'LastName', N'Last name', N'Last name', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4813, N'Shared', N'Role', N'Role', N'Role', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4814, N'Shared', N'DefaultLanguage', N'Default language', N'Default language', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4815, N'Shared', N'IsActive', N'Is active', N'Is active', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4816, N'Shared', N'Roles', N'Roles', N'Roles', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4817, N'Shared', N'Translator', N'Translator', N'Translator', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4818, N'Shared', N'TranslationSupervisor', N'Translation supervisor', N'Translation supervisor', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4819, N'Shared', N'Administrator', N'Administrator', N'Administrator', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4820, N'Shared', N'DataEntrySupervisor', N'Data entry supervisor', N'Data entry supervisor', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4821, N'Shared', N'OverallSupervisor', N' Overall supervisor', N' Overall supervisor', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4822, N'Shared', N'Code', N'Code', N'Code', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4823, N'Shared', N'EditLanguage', N'Edit Language', N'Edit Language', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4824, N'Shared', N'Languages', N'Languages', N'Languages', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4825, N'Shared', N'Lists', N'Lists', N'Lists', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4826, N'Shared', N'TranslationIn', N'Translation in', N'Translation in', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4827, N'Shared', N'OrderIndex', N'Order Index', N'Order Index', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4828, N'Shared', N'SaveOrder', N'Save Order', N'Save Order', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:11:14.5215784' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4829, N'Shared', N'ListTranslations', N'List translations', N'List translations', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4830, N'Shared', N'BackToList', N'Back to list', N'Back to list', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4831, N'Shared', N'ResourceKey', N'Resource', N'Resource Key', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4832, N'Shared', N'KeyValue', N'Value', N'Key value', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4833, N'Shared', N'KeyName', N'Token', N'Key name', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4834, N'Shared', N'Synonyms', N'Trans name', N'Synonym of name', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4835, N'Shared', N'TranslationEditor', N'Translation editor', N'Translation editor', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4836, N'Shared', N'Clear', N'Clear', N'Clear', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4837, N'Shared', N'ResetPassword', N'Reset password', N'Reset password', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4838, N'Shared', N'NewPassword', N'New password', N'New password', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4839, N'Shared', N'SearchbyUsername', N'Search by username', N'Search by username', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4840, N'Shared', N'AdministrationUsers', N'Administration - Users', N'Administration users', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4841, N'Shared', N'TypeNewPassword', N'Type new password', N'Type new password', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4846, N'Shared', N'HasValidity', N'Has Validity', N'Has Validity', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:14:30.5322484' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4848, N'Shared', N'LanguageTranlsation', N'Language Tranlsation', N'Language Tranlsation', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:16:46.9661151' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4860, N'Shared', N'SourceDocs', N'Source Docs', N'Source Docs', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:20:58.4828094' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4861, N'Shared', N'Translated', N'Translated', N'Translated', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:30:48.2388927' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5018, N'Shared', N'InForce', N'Në fuqi', N'InForce', 1, NULL, CAST(N'2021-09-10T15:57:57.9421169' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-15T11:53:20.1841914' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5019, N'Shared', N'InForce', N'In force', N'InForce', 2, NULL, CAST(N'2021-09-10T15:57:57.9421691' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:31:04.1226663' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5191, N'Shared', N'EditTranslation', N'Ndrysho përkthimin', N'asdasd_sq', 1, NULL, CAST(N'2021-09-16T09:58:51.1015921' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-20T10:47:08.0632176' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5192, N'Shared', N'EditTranslation', N'Edit Translation', N'Edit Translation', 2, NULL, CAST(N'2021-09-16T09:58:51.1015980' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:22:01.4455105' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5196, N'Shared', N'Field4ACQUISs', N'Fusha ACQUIS', N'#_sq', 1, NULL, CAST(N'2021-09-17T09:25:45.2306518' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T10:22:58.4205153' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5197, N'Shared', N'Field4ACQUISs', N'Field ACQUIS', N'Field ACQUIS', 2, NULL, CAST(N'2021-09-17T09:25:45.2306883' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:26:58.4545153' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5201, N'Shared', N'Field4ACQUIS', N'Fusha ACQUIS', N'#', 1, NULL, CAST(N'2021-09-17T13:43:56.5298649' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T13:43:56.5298682' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5202, N'Shared', N'Field4ACQUIS', N'Field ACQUIS', N'Field ACQUIS', 2, NULL, CAST(N'2021-09-17T13:43:56.5298742' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:31:53.7552209' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5206, N'Shared', N'ReOrder', N'Renditja', N'#', 1, NULL, CAST(N'2021-09-17T09:53:57.2393939' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T09:53:57.2393977' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5207, N'Shared', N'ReOrder', N'Re Order', N'Re Order', 2, NULL, CAST(N'2021-09-17T09:53:57.2393984' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:32:13.8593056' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5211, N'Shared', N'DateCreated', N'Data e krijimit', N'#', 1, NULL, CAST(N'2021-09-17T10:04:07.5465193' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T10:04:07.5465209' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5212, N'Shared', N'DateCreated', N'Date Created', N'Date Created', 2, NULL, CAST(N'2021-09-17T10:04:07.5465254' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:32:41.0257286' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5216, N'Shared', N'MyJobs', N'Punët e mia', N'#', 1, NULL, CAST(N'2021-09-17T10:52:39.1014924' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T10:52:39.1014956' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5217, N'Shared', N'MyJobs', N'My Tasks', N'My Tasks', 2, NULL, CAST(N'2021-09-17T10:52:39.1015290' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T10:23:26.1719494' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5221, N'Shared', N'Project', N'Projekti', N'#', 1, NULL, CAST(N'2021-09-17T10:57:44.0123105' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T10:57:44.0123122' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5222, N'Shared', N'Project', N'Project', N'Project', 2, NULL, CAST(N'2021-09-17T10:57:44.0123181' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:33:33.4194985' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5226, N'Shared', N'User', N'Përdoruesi', N'#', 1, NULL, CAST(N'2021-09-17T10:58:25.0514178' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T10:58:25.0514188' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5227, N'Shared', N'User', N'User', N'User', 2, NULL, CAST(N'2021-09-17T10:58:25.0514196' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:33:44.6289816' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5231, N'Shared', N'DateChanged', N'Data e ndryshimit', N'#', 1, NULL, CAST(N'2021-09-17T10:59:56.6954484' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-09-17T10:59:56.6954501' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5232, N'Shared', N'DateChanged', N'Date Changed', N'Date Changed', 2, NULL, CAST(N'2021-09-17T10:59:56.6954508' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-18T16:34:27.4620913' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5236, N'Shared', N'DataInputQCStatus', N'Statusi i Kontrollës së Cilësisë', N'#', 1, NULL, CAST(N'2021-10-19T10:46:48.0294985' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-14T11:06:30.5318275' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5237, N'Shared', N'DataInputQCStatus', N'Quality Control Status', N'Data Input QC Status', 2, NULL, CAST(N'2021-10-19T10:46:48.0295385' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T16:41:08.3836620' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5241, N'Shared', N'RootOverritedType', N'Akt i ri juridik/Plotësues', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-26T14:21:05.4996723' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5242, N'Shared', N'RootOverritedType', N'New/Amendment Law', N'Root Overrited Type', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-22T15:17:36.9031216' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5252, N'Shared', N'DataInputQCStatuses', N'Statuset e Kontrollës së Cilësisë', N'DataInputQCStatuses', 1, NULL, CAST(N'2021-11-02T16:45:17.1297751' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-11T15:41:07.2553259' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5253, N'Shared', N'DataInputQCStatuses', N'Quality Control Status', N'DataInputQCStatuses', 2, NULL, CAST(N'2021-11-02T16:45:17.1298038' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T16:41:31.4869253' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5257, N'Shared', N'Albania', N'Shqip', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-11T15:14:18.3018711' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5258, N'Shared', N'Albania', N'Albanian', N'Albanian', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T10:24:18.5782205' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5262, N'Shared', N'English', N'Anglisht', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5263, N'Shared', N'English', N'English', N'English', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T10:24:29.9381770' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5267, N'Shared', N'Serbian', N'Serbisht', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-11T15:14:26.9777136' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5268, N'Shared', N'Serbian', N'Serbian', N'Serbian', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T10:24:41.6102251' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5272, N'Shared', N'Turkish', N'Turqisht', N'#_sq', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-11T15:14:38.7490575' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5273, N'Shared', N'Turkish', N'Turkish', N'Turkish', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T10:24:56.1694266' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5277, N'Shared', N'Bosnian', N'Boshnjakisht', N'#', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-11T15:15:25.7803026' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5278, N'Shared', N'Bosnian', N'Bosnian', N'Bosnian', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2021-11-19T10:25:06.6264676' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5292, N'Shared', N'Keyword', N'Fjalë kyçe', N'Fjalë kyqe', 1, NULL, CAST(N'2021-11-22T11:11:02.5902421' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-02-15T09:16:55.4724041' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5293, N'Shared', N'Keyword', N'Keyword', N'Keyword', 2, NULL, CAST(N'2021-11-22T11:11:02.5902474' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-01-11T15:28:26.5792408' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5312, N'Shared', N'USER_CANREAD', N'Lexon', N'Lexon', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5313, N'Shared', N'USER_CANREAD', N'Read', N'Lexon_en', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:34:25.0075819' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5317, N'Shared', N'USER_CANWRITE', N'Shkruan', N'Shkruan', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-21T09:48:53.9186760' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5318, N'Shared', N'USER_CANWRITE', N'Write', N'Shkruan_en', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:34:37.3939524' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5322, N'Shared', N'USER_CANDELETE', N'Fshij', N'Fshij', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5323, N'Shared', N'USER_CANDELETE', N'Delete', N'Fshij_en', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:34:52.4288870' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5327, N'Shared', N'EditedRootDetail', N'Verzioni i konsoliduar', N'Edited Root Detail', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-02-22T15:43:46.5456067' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5328, N'Shared', N'EditedRootDetail', N'Consolidated version', N'Consolidated version', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-04-29T09:43:39.8643644' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5332, N'Shared', N'IsCombined', N'Është e lidhur', N'IsCombined', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-21T09:49:42.8902584' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5333, N'Shared', N'IsCombined', N'Is Combined', N'IsCombined', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-02-08T10:42:57.3411237' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5342, N'Shared', N'SearchByDatas', N'Kërko sipas datave', N'SearchByDatas', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-21T09:50:56.7330216' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5343, N'Shared', N'SearchByDatas', N'Search by Data', N'SearchByDatas', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-02-08T10:37:44.0032983' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5352, N'Shared', N'OtherSearchFields', N'Fushat tjera të kërkimit', N'OtherSearchFields', 1, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-25T13:40:17.6888586' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5353, N'Shared', N'OtherSearchFields', N'Other search fields', N'OtherSearchFields', 2, NULL, CAST(N'2021-08-11T15:31:53.6080343' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-02-08T10:38:28.4165803' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5367, N'Shared', N'Albanian', N'Shqip', N'Albanian', 1, NULL, CAST(N'2022-04-21T15:13:52.9004104' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-04-21T15:13:52.9004198' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5368, N'Shared', N'Albanian', N'Albanian', N'Albanian', 2, NULL, CAST(N'2022-04-21T15:13:52.9004404' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-04-28T16:04:55.8901781' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5372, N'Shared', N'QualityControl', N'Kontrolla e cilësisë', N'Kontrolla e cilësisë', 1, NULL, CAST(N'2022-04-29T10:29:31.6617105' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-04-29T11:06:06.6328717' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5373, N'Shared', N'QualityControl', N'Quality Control', N'Quality Control', 2, NULL, CAST(N'2022-04-29T10:29:31.6617446' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-04-29T11:08:44.7653739' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5377, N'Shared', N'NormativeActCartel', N'Kartela e Aktit Juridik', N'#', 1, NULL, CAST(N'2022-04-29T10:39:56.4440391' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-28T13:46:25.1526241' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5378, N'Shared', N'NormativeActCartel', N'Legal Act Card', N'#_en', 2, NULL, CAST(N'2022-04-29T10:39:56.4440769' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:37:03.0975019' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5382, N'Shared', N'ShowMore', N'Më shumë', N'Më shumë', 1, NULL, CAST(N'2022-05-10T16:20:08.8667129' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-05T09:11:05.7126429' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5383, N'Shared', N'ShowMore', N'Show More', N'#_en', 2, NULL, CAST(N'2022-05-10T16:20:08.8667710' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:37:19.8587362' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5387, N'Shared', N'ShowLess', N'Më pak', N'Më pak', 1, NULL, CAST(N'2022-05-10T16:20:22.7508806' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-05T09:11:33.9471262' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5388, N'Shared', N'ShowLess', N'Show Less', N'#_en', 2, NULL, CAST(N'2022-05-10T16:20:22.7508821' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:37:31.5444486' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5392, N'Shared', N'Print', N'Shtyp', N'#', 1, NULL, CAST(N'2022-05-16T11:07:44.6017476' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-30T14:05:55.2029664' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5393, N'Shared', N'Print', N'Print', N'#_en', 2, NULL, CAST(N'2022-05-16T11:07:44.6017895' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:37:42.9632809' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5397, N'Shared', N'All', N'Të gjitha', N'Të gjitha', 1, NULL, CAST(N'2022-05-16T11:09:18.4604280' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-05T09:14:43.4406534' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5398, N'Shared', N'All', N'All', N'#_en', 2, NULL, CAST(N'2022-05-16T11:09:18.4604353' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T15:37:50.3920591' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5402, N'Shared', N'NotInForce', N'Nuk janë në fuqi', N'Nuk janë në fuqi', 1, NULL, CAST(N'2022-05-16T11:09:30.9289254' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-05T09:14:19.4559982' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5403, N'Shared', N'NotInForce', N'Not In Force', N'#_en', 2, NULL, CAST(N'2022-05-16T11:09:30.9289273' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T16:06:56.8785154' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5407, N'Shared', N'Open', N'Hape', N'#', 1, NULL, CAST(N'2022-05-16T11:09:46.1007734' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-29T15:05:32.3229911' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5408, N'Shared', N'Open', N'Open', N'#_en', 2, NULL, CAST(N'2022-05-16T11:09:46.1007759' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-05-16T11:22:56.7496833' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5412, N'Shared', N'Image', N'Fotografia', N'Image_sq', 1, NULL, CAST(N'2022-05-16T11:20:38.1588277' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-29T10:55:24.4088703' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5413, N'Shared', N'Image', N'Image', N'Image', 2, NULL, CAST(N'2022-05-16T11:20:38.1588754' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-05-16T11:20:38.1588765' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5471, N'Shared', N'Email', N'Email', N'#_en', 2, NULL, CAST(N'2022-06-16T13:25:01.9603395' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T16:07:05.6185115' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5472, N'Shared', N'Email', N'Email', N'#', 1, NULL, CAST(N'2022-06-16T13:25:01.9602812' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-16T13:25:01.9602860' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5473, N'Shared', N'email2', N'email2_sq', N'email2_sq', 1, NULL, CAST(N'2022-06-16T13:29:39.8778711' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-16T13:29:39.8778780' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5474, N'Shared', N'email2', N'email2', N'email2', 2, NULL, CAST(N'2022-06-16T13:29:39.8779299' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-16T13:29:39.8779307' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5485, N'Shared', N'ClosePDF', N' Mbyll PDF', N'#', 1, NULL, CAST(N'2022-06-20T10:00:58.8322024' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-04T11:29:21.0686440' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5486, N'Shared', N'ClosePDF', N' Close PDF', N'#_en', 2, NULL, CAST(N'2022-06-20T10:00:58.8322284' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T16:07:23.5493926' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5495, N'Shared', N'Finalize', N'Finalizo', N'#', 1, NULL, CAST(N'2022-06-20T10:34:55.5088368' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-20T10:34:55.5088377' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5496, N'Shared', N'Finalize', N'Finalize', N'#_en', 2, NULL, CAST(N'2022-06-20T10:34:55.5088383' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T16:20:09.6613573' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5500, N'Shared', N'Finalized', N'Finalizuar', N'#', 1, NULL, CAST(N'2022-06-20T10:35:49.3949023' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-06-20T10:35:49.3949031' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5501, N'Shared', N'Finalized', N'Finalized', N'#_en', 2, NULL, CAST(N'2022-06-20T10:35:49.3949036' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-07-20T16:19:53.7149907' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5502, N'Shared', N'Projects', N'Projektet', N'Projektet', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-09-30T21:18:37.7778171' AS DateTime2), NULL, CAST(N'2022-09-30T21:18:37.7778204' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5503, N'Shared', N'Projects', N'Projects', N'Projects', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-09-30T21:18:37.7779575' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-09-30T21:18:49.6498599' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5504, N'Shared', N'DocumentType', N'Lloji i dokumentit', N'Lloji i dokumentit', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-10-01T22:50:45.8328543' AS DateTime2), NULL, CAST(N'2022-10-01T22:50:45.8328586' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5505, N'Shared', N'DocumentType', N'Document type', N'Lloji i dokumentit_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-10-01T22:50:45.8329631' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-10-01T22:50:59.5788777' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5506, N'Shared', N'CreateOrUpdate', N'Krijo ose ndrysho', N'Krijo ose ndrysho', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-10-01T22:50:45.8328543' AS DateTime2), NULL, CAST(N'2022-10-01T22:50:45.8328586' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5507, N'Shared', N'CreateOrUpdate', N'Create or Update', N'Krijo ose ndrysho', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-10-01T22:50:45.8329631' AS DateTime2), N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2022-10-01T22:50:59.5788777' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5508, N'Shared', N'Hint', N'Sygjerim', N'Sygjerim', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-02-27T11:32:37.3098574' AS DateTime2), NULL, CAST(N'2023-02-27T11:32:37.3098605' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5509, N'Shared', N'Hint', N'Sygjerim_en', N'Sygjerim_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-02-27T11:32:37.3099966' AS DateTime2), NULL, CAST(N'2023-02-27T11:32:37.3099973' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5510, N'Shared', N'Hint', N'Sygjerim_sr', N'Sygjerim_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-02-27T11:32:37.3100068' AS DateTime2), NULL, CAST(N'2023-02-27T11:32:37.3100070' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5511, N'Shared', N'JobTitle', N'JobTitle', N'JobTitle', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-02-27T11:33:11.9553860' AS DateTime2), NULL, CAST(N'2023-02-27T11:33:11.9553867' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5512, N'Shared', N'JobTitle', N'JobTitle_en', N'JobTitle_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-02-27T11:33:11.9553900' AS DateTime2), NULL, CAST(N'2023-02-27T11:33:11.9553901' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[Localizations] ([Id], [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (5513, N'Shared', N'JobTitle', N'JobTitle_sr', N'JobTitle_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-02-27T11:33:11.9553905' AS DateTime2), NULL, CAST(N'2023-02-27T11:33:11.9553906' AS DateTime2), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[Localizations] OFF
GO
-- 14/03/2023



select * from [Localizations]
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Employee', N'Punëmarres', N'Punëmarres', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:36:47.8104409' AS DateTime2), NULL, CAST(N'2023-03-14T09:36:47.8104503' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Employee', N'Punëmarres_en', N'Punëmarres_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:36:47.8105113' AS DateTime2), NULL, CAST(N'2023-03-14T09:36:47.8105118' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Employee', N'Punëmarres_sr', N'Punëmarres_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:36:47.8105229' AS DateTime2), NULL, CAST(N'2023-03-14T09:36:47.8105230' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Employee', N'Punëmarres_tr', N'Punëmarres_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:36:47.8105235' AS DateTime2), NULL, CAST(N'2023-03-14T09:36:47.8105236' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Employee', N'Punëmarres_bs', N'Punëmarres_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:36:47.8105240' AS DateTime2), NULL, CAST(N'2023-03-14T09:36:47.8105241' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'PersonalNr', N'Nr. Personal', N'Nr. Personal', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:40:49.0947830' AS DateTime2), NULL, CAST(N'2023-03-14T09:40:49.0947836' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'PersonalNr', N'Nr. Personal_en', N'Nr. Personal_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:40:49.0947884' AS DateTime2), NULL, CAST(N'2023-03-14T09:40:49.0947885' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'PersonalNr', N'Nr. Personal_sr', N'Nr. Personal_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:40:49.0947889' AS DateTime2), NULL, CAST(N'2023-03-14T09:40:49.0947890' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'PersonalNr', N'Nr. Personal_tr', N'Nr. Personal_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:40:49.0947893' AS DateTime2), NULL, CAST(N'2023-03-14T09:40:49.0947894' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'PersonalNr', N'Nr. Personal_bs', N'Nr. Personal_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:40:49.0947897' AS DateTime2), NULL, CAST(N'2023-03-14T09:40:49.0947898' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'FirstName', N'Emri', N'Emri', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:41:07.2876290' AS DateTime2), NULL, CAST(N'2023-03-14T09:41:07.2876294' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'FirstName', N'Emri_en', N'Emri_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:41:07.2876339' AS DateTime2), NULL, CAST(N'2023-03-14T09:41:07.2876340' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'FirstName', N'Emri_sr', N'Emri_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:41:07.2876343' AS DateTime2), NULL, CAST(N'2023-03-14T09:41:07.2876344' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'FirstName', N'Emri_tr', N'Emri_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:41:07.2876346' AS DateTime2), NULL, CAST(N'2023-03-14T09:41:07.2876348' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'FirstName', N'Emri_bs', N'Emri_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:41:07.2876358' AS DateTime2), NULL, CAST(N'2023-03-14T09:41:07.2876359' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'MunicipalityResidenceName', N'Pozita e punes', N'Pozita e punes', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:37.2079085' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:37.2079095' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'MunicipalityResidenceName', N'Pozita e punes_en', N'Pozita e punes_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:37.2079159' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:37.2079161' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'MunicipalityResidenceName', N'Pozita e punes_sr', N'Pozita e punes_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:37.2079167' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:37.2079169' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'MunicipalityResidenceName', N'Pozita e punes_tr', N'Pozita e punes_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:37.2079174' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:37.2079176' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'MunicipalityResidenceName', N'Pozita e punes_bs', N'Pozita e punes_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:37.2079181' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:37.2079182' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'WorkingPositionName', N'Lokacioni', N'Lokacioni', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:56.2149687' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:56.2149693' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'WorkingPositionName', N'Lokacioni_en', N'Lokacioni_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:56.2149724' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:56.2149725' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'WorkingPositionName', N'Lokacioni_sr', N'Lokacioni_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:56.2149728' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:56.2149729' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'WorkingPositionName', N'Lokacioni_tr', N'Lokacioni_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:56.2149732' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:56.2149734' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'WorkingPositionName', N'Lokacioni_bs', N'Lokacioni_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:42:56.2149737' AS DateTime2), NULL, CAST(N'2023-03-14T09:42:56.2149738' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Evaluate', N'Vlersoje', N'Vlersoje', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:45:22.3598742' AS DateTime2), NULL, CAST(N'2023-03-14T09:45:22.3598749' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Evaluate', N'Vlersoje_en', N'Vlersoje_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:45:22.3598819' AS DateTime2), NULL, CAST(N'2023-03-14T09:45:22.3598821' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Evaluate', N'Vlersoje_sr', N'Vlersoje_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:45:22.3598827' AS DateTime2), NULL, CAST(N'2023-03-14T09:45:22.3598829' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Evaluate', N'Vlersoje_tr', N'Vlersoje_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:45:22.3598833' AS DateTime2), NULL, CAST(N'2023-03-14T09:45:22.3598835' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Evaluate', N'Vlersoje_bs', N'Vlersoje_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:45:22.3598839' AS DateTime2), NULL, CAST(N'2023-03-14T09:45:22.3598841' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Election', N'Zgjedhjet', N'Zgjedhjet', 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:51:31.2514982' AS DateTime2), NULL, CAST(N'2023-03-14T09:51:31.2514991' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Election', N'Zgjedhjet_en', N'Zgjedhjet_en', 2, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:51:31.2515030' AS DateTime2), NULL, CAST(N'2023-03-14T09:51:31.2515031' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Election', N'Zgjedhjet_sr', N'Zgjedhjet_sr', 3, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:51:31.2515034' AS DateTime2), NULL, CAST(N'2023-03-14T09:51:31.2515036' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Election', N'Zgjedhjet_tr', N'Zgjedhjet_tr', 4, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:51:31.2515039' AS DateTime2), NULL, CAST(N'2023-03-14T09:51:31.2515040' AS DateTime2), NULL, NULL, 0)
GO							   																																															  
INSERT [dbo].[Localizations] ( [ResourceKey], [KeyName], [KeyValue], [Description], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES ( N'Shared', N'Election', N'Zgjedhjet_bs', N'Zgjedhjet_bs', 5, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-03-14T09:51:31.2515043' AS DateTime2), NULL, CAST(N'2023-03-14T09:51:31.2515044' AS DateTime2), NULL, NULL, 0)
 							   


--Konfigurimet

USE [KQZ-ONLINE]
GO
SET IDENTITY_INSERT [dbo].[ServiceConfigurations] ON 
GO
INSERT [dbo].[ServiceConfigurations] ([Id], [ServiceName], [StartDate], [EndDate], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (1, N'PolllingCenterChange', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[ServiceConfigurations] ([Id], [ServiceName], [StartDate], [EndDate], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (2, N'AbroadVoter', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[ServiceConfigurations] ([Id], [ServiceName], [StartDate], [EndDate], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (3, N'RegisterPoliticalParty', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[ServiceConfigurations] ([Id], [ServiceName], [StartDate], [EndDate], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (4, N'SpecialNeedVoter', CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), CAST(N'2023-01-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[ServiceConfigurations] OFF
GO

--04/01/2024

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('B42CD943-6A69-423F-9E5D-840CDFA29081', N'PoliticalParty_ListOfCitizenInciatives', N'List Of Citizen Inciatives', N'List Of Citizen Inciatives', N'List Of Citizen Inciatives', 1, 3, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('1950244B-FBA0-4796-8419-D9FCFE9B3974', N'PoliticalParty', N'Political Party', N'Political Party', N'Political Party', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO 

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('8A308DBD-14B5-4E16-9F59-ED7DC0EBE000', N'PoliticalParty_ListOfIndipedentCandidate', N'List Of Indipedent Candidate', N'List Of Indipedent Candidate', N'List Of Indipedent Candidate', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO 

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('70A3B0D3-C3B9-46BE-A64A-4622CFCE06D5', N'PollingCenterChangeList', N'Polling Center Change', N'Polling Center Change', N'Polling Center Change', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO  

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('0B03882D-9A1E-49F6-BCE2-FDD66A72BD51', N'SpecialNeedsVoters', N'SpecialNeeds Voters', N'SpecialNeeds Voters', N'SpecialNeeds Voters', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO 

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('7DDEA83B-5D7B-4653-97E2-D354123D5028', N'ListOfRequestsAbroadVoters', N'Requests Abroad Voters', N'Requests Abroad Voters', N'Requests Abroad Voters', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO 

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('A29D548F-9496-4022-BA8D-7F8076E97BCC', N'ServicesConfigurations', N'Services Configurations', N'Services Configurations', N'Services Configurations', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO 

INSERT [dbo].[ActionRoots] ([Id], [CodeName], [NameAl], [NameSr], [NameEn], [IsActive], [TypeId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES ('BD1DAD6D-D282-4D15-8543-B6BEF3FAE1DB', N'Emails', N'Emails', N'Emails', N'Emails', 1, 1, NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2012-12-12T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO 

DELETE FROM UserActionRootRestRights

---09/01/2023 Skripta per krijimin tablese e Raporteve edhe insertin e shenimeve edhe procedurave


CREATE TABLE [dbo].[Reports](
	[Id] [uniqueidentifier] NOT NULL,
	[NameProcedure] [nvarchar](max) NULL,
	[NameForShow] [nvarchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedById] [nvarchar](450) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LastChangedById] [nvarchar](450) NULL,
	[LastChangedDate] [datetime2](7) NOT NULL,
	[DeletedById] [nvarchar](450) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReportsRoles]    Script Date: 1/9/2024 10:51:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReportsRoles](
	[Id] [uniqueidentifier] NOT NULL,
	[ReportId] [uniqueidentifier] NULL,
	[RoleId] [nvarchar](450) NULL,
	[CreatedById] [nvarchar](450) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[LastChangedById] [nvarchar](450) NULL,
	[LastChangedDate] [datetime2](7) NOT NULL,
	[DeletedById] [nvarchar](450) NULL,
	[DeletedDate] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_ReportsRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Reports] ([Id], [NameProcedure], [NameForShow], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
VALUES (N'28d3bbe9-bddb-417a-193f-08dbd9fb5322', N'ReportPollingCenterChange', N'Raportet e Ndrrimit te qendres se votimit', 1, NULL, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_AspNetUsers_CreatedById] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_AspNetUsers_CreatedById]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_AspNetUsers_DeletedById] FOREIGN KEY([DeletedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_AspNetUsers_DeletedById]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_AspNetUsers_LastChangedById] FOREIGN KEY([LastChangedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_AspNetUsers_LastChangedById]
GO
ALTER TABLE [dbo].[ReportsRoles]  WITH CHECK ADD  CONSTRAINT [FK_ReportsRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
GO
ALTER TABLE [dbo].[ReportsRoles] CHECK CONSTRAINT [FK_ReportsRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[ReportsRoles]  WITH CHECK ADD  CONSTRAINT [FK_ReportsRoles_AspNetUsers_CreatedById] FOREIGN KEY([CreatedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ReportsRoles] CHECK CONSTRAINT [FK_ReportsRoles_AspNetUsers_CreatedById]
GO
ALTER TABLE [dbo].[ReportsRoles]  WITH CHECK ADD  CONSTRAINT [FK_ReportsRoles_AspNetUsers_DeletedById] FOREIGN KEY([DeletedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ReportsRoles] CHECK CONSTRAINT [FK_ReportsRoles_AspNetUsers_DeletedById]
GO
ALTER TABLE [dbo].[ReportsRoles]  WITH CHECK ADD  CONSTRAINT [FK_ReportsRoles_AspNetUsers_LastChangedById] FOREIGN KEY([LastChangedById])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[ReportsRoles] CHECK CONSTRAINT [FK_ReportsRoles_AspNetUsers_LastChangedById]
GO
ALTER TABLE [dbo].[ReportsRoles]  WITH CHECK ADD  CONSTRAINT [FK_ReportsRoles_Reports_ReportId] FOREIGN KEY([ReportId])
REFERENCES [dbo].[Reports] ([Id])
GO
ALTER TABLE [dbo].[ReportsRoles] CHECK CONSTRAINT [FK_ReportsRoles_Reports_ReportId]
GO
/****** Object:  StoredProcedure [dbo].[ReportPollingCenterChange]    Script Date: 1/9/2024 10:52:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ReportPollingCenterChange]
    @From DATE = NULL,
    @To DATE = NULL
AS
BEGIN
    IF @From IS NULL
        SET @From = '01/01/1998'
    IF @To IS NULL
        SET @To = '01/01/3001'

    SELECT COUNT(DecisionId) as Total, 
           ISNULL((SELECT [Name] FROM ListTranslations WHERE ListId = pc.DecisionId), 'Në Pritje') as Emri
    FROM PollingCenterChanges as pc
    WHERE CreatedDate >= @From AND CreatedDate <= @To and  IsDeleted = 0
    GROUP BY DecisionId
END;
 
GO

-- 24/01/2024 SCRIPT FOR DELITING POLITICAL PARTY TEST DATA --
GO
DELETE FROM PoliticalPartyPersons
GO
DELETE FROM DocumentTranslations WHERE DocumentId in (select id from Documents where PoliticalPartyId is not null)
GO
DELETE FROM DocumentDownloadableTranslations WHERE DocumentId in (select id from Documents where PoliticalPartyId is not null)
GO
DELETE FROM Documents
GO
DELETE FROM PoliticalParties
GO


--29/-1/2024 SCRIPT FOR PROCEDURE OF REPORTS ReportPOllingCenterChange--

USE [KQZ-ONLINE-Test]
GO
/****** Object:  StoredProcedure [dbo].[ReportPollingCenterChange]    Script Date: 2/1/2024 11:02:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[ReportPollingCenterChange]
    @From DATE = NULL,
    @To DATE = NULL,
	@MunicipalityId int=NULL,
	@Admin varchar(250)=Null
AS
BEGIN
 
    IF @From IS NULL
       begin SET @From = '01/01/1998' end
    IF @To IS NULL
      begin   SET @To = '01/01/3001' end
	IF  @Admin ='Administrator'
    begin 
		select  
		municipality.Name as Komuna,
		count (pc.id) as [Totali],

		sum (CASE WHEN pc.DecisionId = 3 THEN 1 ELSE 0 END) as [Aprovuar],
		sum (CASE WHEN pc.DecisionId = 4 THEN 1 ELSE 0 END) as [Refuzuar],
		sum (CASE WHEN pc.DecisionId   is null THEN 1 ELSE 0 END) as [Ne Pritje] 
		from PollingCenterChanges as pc  
		INNER JOIN Municipalities as muni ON muni.Id=pc.MunicipalityId
		INNER JOIN MunicipalityTranslations as municipality ON municipality.MunicipalityId=muni.Id 
		WHERE pc.CreatedDate >= @From AND pc.CreatedDate <= @To and  pc.IsDeleted=0
		group by pc.MunicipalityId,municipality.Name
		union all 
		select  
		'-' as KomunaName,
		count (pc.id) as [Totali],
		sum (CASE WHEN pc.DecisionId = 3 THEN 1 ELSE 0 END) as [Aprovuar],
		sum (CASE WHEN pc.DecisionId = 4 THEN 1 ELSE 0 END) as [Refuzuar],
		sum (CASE WHEN pc.DecisionId   is null THEN 1 ELSE 0 END) as [Ne Pritje]
		from PollingCenterChanges as pc where pc.CreatedDate >= @From AND pc.CreatedDate <= @To and  pc.IsDeleted=0
	end
	ELSE if @MunicipalityId is not null
	begin
		SELECT COUNT(DecisionId) as Total, 
			   ISNULL((SELECT [Name] FROM ListTranslations WHERE ListId = pc.DecisionId), 'Në Pritje') as Emri
		FROM PollingCenterChanges as pc
		WHERE CreatedDate >= @From AND CreatedDate <= @To and  IsDeleted=0 and MunicipalityId=@MunicipalityId
		GROUP BY DecisionId
	end
END;

-- 12/02/2024 

  update ListTranslations set Name='Përmes Postës në kutinë postarë në Kosovë' where [name] ='Përmes Postës'
  go 

  INSERT [dbo].[Lists] ( [OrderIndex], [ListTypeId], [IsActive], [Code], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES
                       (  0,32, 1, NULL, N'3f0db82f-150d-4e4c-b78b-6f701ea69dd9', CAST(N'2024-01-12T15:56:17.3699716' AS DateTime2), N'3f0db82f-150d-4e4c-b78b-6f701ea69dd9', CAST(N'2024-01-12T15:56:49.7619015' AS DateTime2), NULL, NULL, 0)
 
  declare @ListId int = SCOPE_IDENTITY();
  INSERT [dbo].[ListTranslations] ( [Name], [NameTransitive], [ListId], [LanguageId], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES 
								  ( N'Përmes Postës në kutitë postarë jashtë Kosovës', N'', @ListId, 1, N'9e0568ef-f131-4044-9bd9-8d49d186d278', CAST(N'2023-07-02T15:26:53.7121711' AS DateTime2), NULL, CAST(N'2023-07-02T15:26:53.7121795' AS DateTime2), NULL, NULL, 0)



-- 13/02/2024 SCRIPT FOR PROCEDURE OF REPORT  ReportAbroadVoter--

  
GO
CREATE procedure [dbo].[ReportAbroadVoter] 
         @From DATE = NULL,
         @To DATE = NULL,
		 @MunicipalityId int =0,--Use this as AbroadVoter
		 @Admin varchar(50)=null
		 --@AbroadVoterTypeId int=0
as 
begin 
   declare @AbroadVoterTypeId int = @MunicipalityId

    IF @From IS NULL
       begin SET @From = '01/01/1998' end
    IF @To IS NULL
      begin   SET @To = '01/01/3001' end
	begin
	select  ROW_NUMBER() OVER (ORDER BY abv.LastName)  'Nr.Rendor',
	abv.LastName as Mbiemri,
	abv.FirstName as Emri,
	Convert(varchar,abv.BirthDate,104) as 'Data e Lindjes',
	abv.AboardCountry as Shteti,
	municipality.Name as Komuna,
	listtrans.Name as 'Menyra e Votimit'
	from AbroadVoters as abv
	INNER JOIN Municipalities as muni ON muni.Id=abv.MunicipalityId
    INNER JOIN MunicipalityTranslations as municipality ON municipality.MunicipalityId=muni.Id 
	INNER JOIN ListTranslations as listtrans ON listtrans.Id=abv.AbroadVoterTypeId
	WHERE abv.CreatedDate >= @From AND abv.CreatedDate <= @To and  abv.IsDeleted=0
	end
	end;

-- 22/02/2024
 

ALTER TABLE [dbo].[AbroadVoters] ADD IsAbroadKosovoPostalBoox bit default(0) NOT NULL
go
ALTER TABLE [dbo].[AbroadVoters] ADD IsDiplomaticRepresented bit default(0) NOT NULL
go
ALTER TABLE [dbo].[AbroadVoters] ADD IsKosovoPostalBoox bit default(0) NOT NULL


---06/03/2024
  
ALTER TABLE [dbo].[PoliticalParties] ADD CommentDiscussion nvarchar(max) default('') go
ALTER TABLE [dbo].[PoliticalParties] ADD FromDiscussion datetime2 null go
ALTER TABLE [dbo].[PoliticalParties] ADD IsDiscussion bit default(0)   null go
ALTER TABLE [dbo].[PoliticalParties] ADD ToDiscussion  datetime2 null

-- 06/03/2024

SET IDENTITY_INSERT [dbo].[ListTypes] ON 
	GO 
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (121, N'VPNVTypes', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	SET IDENTITY_INSERT [dbo].[ListTypes] OFF
GO

 
SET IDENTITY_INSERT [dbo].[ListTypes] ON 
	GO 
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (122, N'DecisionPoliticalParty', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	SET IDENTITY_INSERT [dbo].[ListTypes] OFF
GO

SET IDENTITY_INSERT [dbo].[ListTypes] ON 
GO 
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (123, N'CategoriesVPNV', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (124, N'NursingHomes', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (125, N'Hospital', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) VALUES (126, N'Shelters', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	SET IDENTITY_INSERT [dbo].[ListTypes] OFF
GO

--
/* Kete duhet me i shtu pas Deployed, nga Web-i i centralit
Name				listtype
Hospital			VPNVTypes
Home				VPNVTypes
HomeElderlyPeople	VPNVTypes
Shelters			VPNVTypes
Others				VPNVTypes
Aprovuar			DecisionPoliticalParty
Çregjistruar		DecisionPoliticalParty
Ne Konsultim Publik	DecisionPoliticalParty

*/


---04/04/2024

ALTER TABLE [dbo].[AspNetUsers] ADD HasChangeGeneratedPassword bit default(0) NOT NULL
update [dbo].[AspNetUsers] set HasChangeGeneratedPassword = 1


---11/04/2024

ALTER TABLE SpecialNeedsVoters
ADD InstitutionName NVARCHAR(MAX),
    InstitutionAddress NVARCHAR(MAX);

-- 12/03/2024

SET IDENTITY_INSERT [dbo].[ListTypes] ON 
GO 
	INSERT [dbo].[ListTypes] ([Id], [Name], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted])
	VALUES (130, N'SpecialNeedsVotersRefuzionReason', 1, NULL, CAST(N'2023-03-10T16:03:28.9617466' AS DateTime2), NULL, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
	GO
	 
	SET IDENTITY_INSERT [dbo].[ListTypes] OFF
GO

-- 15/04/2024 
alter procedure [dbo].[Report4VPNV] 
         @From DATE = NULL,
         @To DATE = NULL,
		 @MunicipalityId int =0,--Use this as VPNV
		 @Admin varchar(50)=null 
as 
begin 
   declare @AbroadVoterTypeId int = @MunicipalityId 
		IF @From IS NULL
		   begin SET @From = '01/01/1998' end
		IF @To IS NULL
		  begin   SET @To = '01/01/3001' end
		begin
			--select  ROW_NUMBER() OVER (ORDER BY abv.LastName)  'Nr.Rendor',
			SELECT abv.ApplicantCode as 'Kodi i Aplikimit',
			abv.LastName as Mbiemri,
			abv.FirstName as Emri,
			Convert(varchar,abv.BirthDate,104) as 'Data e Lindjes',
			municipality.Name as Komuna,
			listcat.Name as 'Kategoria',
			listType.Name as 'Tipi',
			listins.Name as 'Institucioni' 
			from SpecialNeedsVoters as abv
			INNER JOIN Municipalities as muni ON muni.Id=abv.MunicipalityId
			INNER JOIN MunicipalityTranslations as municipality ON municipality.MunicipalityId=muni.Id 
			INNER JOIN ListTranslations as listcat  ON listcat.ListId=abv.CategoryId
			INNER JOIN ListTranslations as listType ON listcat.ListId=abv.TypeId
			INNER JOIN ListTranslations as listins  ON listins.ListId=abv.InstitucionId
			WHERE abv.CreatedDate >= @From AND abv.CreatedDate <= @To and  abv.IsDeleted=0
		end
	end;
GO
	INSERT [dbo].[Reports] ([Id], [NameProcedure], [NameForShow], [IsActive], [CreatedById], [CreatedDate], [LastChangedById], [LastChangedDate], [DeletedById], [DeletedDate], [IsDeleted]) 
	VALUES (N'4E6DF75E-313A-41D9-8A7E-F5BE412BDD5F', N'Report4VPNV', N'Raportet e VPNV', 1, NULL, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), NULL, CAST(N'2023-01-05T00:00:00.0000000' AS DateTime2), NULL, NULL, 0)
GO



--20/06/2024

--First
ALTER TABLE AbroadVoters 
ADD CountryId INT null;

--Second
ALTER TABLE AbroadVoters
ADD CONSTRAINT FK_AbroadVoters_CountryId
FOREIGN KEY (CountryId) REFERENCES Countries(Id);