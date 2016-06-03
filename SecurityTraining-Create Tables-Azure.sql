CREATE TABLE [dbo].[Users](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL
)
GO
CREATE TABLE [dbo].[Secret](
	[key] [int] NULL,
	[value] [varchar](50) NULL
)
GO
CREATE TABLE [dbo].[Links](
	[link] [varchar](200) NOT NULL
)
GO
CREATE TABLE [dbo].[Comments](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[user_id] [int] FOREIGN KEY REFERENCES Users(id),
	[comment] [varchar](50) NOT NULL
)
GO
CREATE TABLE [dbo].[ChosenPets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[animal] [varchar](30) NOT NULL,
	[name] [varchar](70) NOT NULL
)
GO
INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
		   ,[Role])
     VALUES
           ('admin', 'admin1', 'Admin')
GO
INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
		   ,[Role])
     VALUES
           ('innyuser','wyczesaneP@ssw0rd', 'User')
GO
INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
		   ,[Role])
     VALUES
           ('superadmin','superadmin1', 'SuperAdmin')
GO