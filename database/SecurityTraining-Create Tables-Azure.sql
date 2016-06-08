CREATE TABLE [dbo].[Users](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL
)
GO
CREATE TABLE [dbo].[Secret](
	[key] [int] NULL,
	[value] [varchar](255) NULL
)
GO
CREATE TABLE [dbo].[Links](
	[link] [varchar](255) NOT NULL
)
GO
CREATE TABLE [dbo].[Comments](
	[id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[user_id] [int] FOREIGN KEY REFERENCES Users(id),
	[comment] [varchar](255) NOT NULL
)
GO
CREATE TABLE [dbo].[ChosenPets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[animal] [varchar](255) NOT NULL,
	[name] [varchar](255) NOT NULL
)
GO
INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password]
		   ,[Role])
     VALUES
           ('admin', 'admin1')
GO
INSERT INTO [dbo].[Users]
           ([UserName]
           ,[Password])
     VALUES
           ('anotheruser','awsomeP@ssw0rd')
GO