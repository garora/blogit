/****** Object:  Table [dbo].[bl_Category]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bl_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[DisplayName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](100) NULL,
	[AutoApprove] [bit] NOT NULL,
	[SectionId] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bl_Comments]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bl_Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContentId] [int] NULL,
	[CommentAuthor] [nvarchar](200) NOT NULL,
	[CommentAuthorEmail] [nvarchar](200) NOT NULL,
	[CommentAuthorURL] [nvarchar](200) NOT NULL,
	[CommentAuthorIP] [nvarchar](200) NOT NULL,
	[CommentDesc] [nvarchar](500) NOT NULL,
	[CommentDate] [datetime] NOT NULL,
	[IsApprove] [bit] NOT NULL,
	[ApprovedBy] [int] NULL,
	[ApprovedOn] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bl_Contents]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_Contents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[alias] [nvarchar](100) NOT NULL,
	[AuthorId] [varchar](10) NOT NULL,
	[CreatedOn] [datetime] NULL,
	[LastUpdated] [datetime] NULL,
	[Excerpt] [nvarchar](450) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[IsPrivate] [bit] NOT NULL,
	[Pass] [varchar](256) NULL,
	[IsEnable] [bit] NOT NULL,
	[IsApprove] [bit] NOT NULL,
	[IsPublish] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bl_GroupRights]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_GroupRights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[section_rights] [varchar](250) NOT NULL,
	[access_rights] [varchar](450) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bl_Groups]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_Groups](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[IsActive] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bl_Menus]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_Menus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Desc] [varchar](1000) NOT NULL,
	[ParentMenuId] [int] NOT NULL,
	[DisplayOrder] [int] NOT NULL,
	[Url] [nvarchar](500) NULL,
	[IsActive] [bit] NOT NULL,
	[ContentId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bl_Sections]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bl_Sections](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](300) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[UpdatedOn] [datetime] NOT NULL,
	[UpdatedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bl_Site_Options]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_Site_Options](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[IsAutoLoad] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bl_User_Details]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_User_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FirstName] [varchar](200) NULL,
	[LastName] [varchar](200) NULL,
	[EmailId] [varchar](100) NOT NULL,
	[Url] [varchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[bl_Users]    Script Date: 3/8/2015 8:26:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[bl_Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginId] [varchar](50) NOT NULL,
	[Pass] [varchar](256) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[LastLogin] [datetime] NOT NULL,
	[RegisterOn] [datetime] NOT NULL,
	[ActivationKey] [varchar](10) NULL,
	[gid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[bl_Category] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[bl_Category] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[bl_Comments] ADD  DEFAULT (getdate()) FOR [CommentDate]
GO
ALTER TABLE [dbo].[bl_Comments] ADD  DEFAULT ((0)) FOR [IsApprove]
GO
ALTER TABLE [dbo].[bl_Comments] ADD  DEFAULT (getdate()) FOR [ApprovedOn]
GO
ALTER TABLE [dbo].[bl_Contents] ADD  DEFAULT ((0)) FOR [IsPrivate]
GO
ALTER TABLE [dbo].[bl_Contents] ADD  DEFAULT ((0)) FOR [IsEnable]
GO
ALTER TABLE [dbo].[bl_Contents] ADD  DEFAULT ((0)) FOR [IsApprove]
GO
ALTER TABLE [dbo].[bl_Contents] ADD  DEFAULT ((0)) FOR [IsPublish]
GO
ALTER TABLE [dbo].[bl_GroupRights] ADD  DEFAULT ('1,2,3') FOR [section_rights]
GO
ALTER TABLE [dbo].[bl_GroupRights] ADD  DEFAULT ('read,write,edit,delete,approve') FOR [access_rights]
GO
ALTER TABLE [dbo].[bl_Menus] ADD  DEFAULT ((0)) FOR [ParentMenuId]
GO
ALTER TABLE [dbo].[bl_Menus] ADD  DEFAULT ((1)) FOR [DisplayOrder]
GO
ALTER TABLE [dbo].[bl_Sections] ADD  DEFAULT (getdate()) FOR [CreatedOn]
GO
ALTER TABLE [dbo].[bl_Sections] ADD  DEFAULT (getdate()) FOR [UpdatedOn]
GO
ALTER TABLE [dbo].[bl_Site_Options] ADD  DEFAULT ((0)) FOR [IsAutoLoad]
GO
ALTER TABLE [dbo].[bl_Users] ADD  DEFAULT ((0)) FOR [IsAdmin]
GO
ALTER TABLE [dbo].[bl_Category]  WITH CHECK ADD  CONSTRAINT [FK_bl_Category_bl_Sections] FOREIGN KEY([Id])
REFERENCES [dbo].[bl_Sections] ([Id])
GO
ALTER TABLE [dbo].[bl_Category] CHECK CONSTRAINT [FK_bl_Category_bl_Sections]
GO
ALTER TABLE [dbo].[bl_Comments]  WITH CHECK ADD  CONSTRAINT [FK_bl_Comments_bl_Contents] FOREIGN KEY([Id])
REFERENCES [dbo].[bl_Contents] ([Id])
GO
ALTER TABLE [dbo].[bl_Comments] CHECK CONSTRAINT [FK_bl_Comments_bl_Contents]
GO
ALTER TABLE [dbo].[bl_Contents]  WITH CHECK ADD  CONSTRAINT [FK_bl_Contents_bl_Category] FOREIGN KEY([Id])
REFERENCES [dbo].[bl_Category] ([Id])
GO
ALTER TABLE [dbo].[bl_Contents] CHECK CONSTRAINT [FK_bl_Contents_bl_Category]
GO
ALTER TABLE [dbo].[bl_GroupRights]  WITH CHECK ADD  CONSTRAINT [FK_bl_GroupRights_bl_Groups] FOREIGN KEY([Id])
REFERENCES [dbo].[bl_Groups] ([Id])
GO
ALTER TABLE [dbo].[bl_GroupRights] CHECK CONSTRAINT [FK_bl_GroupRights_bl_Groups]
GO
ALTER TABLE [dbo].[bl_User_Details]  WITH CHECK ADD  CONSTRAINT [FK_bl_User_Details_bl_Users] FOREIGN KEY([Id])
REFERENCES [dbo].[bl_Users] ([Id])
GO
ALTER TABLE [dbo].[bl_User_Details] CHECK CONSTRAINT [FK_bl_User_Details_bl_Users]
GO
ALTER TABLE [dbo].[bl_Users]  WITH CHECK ADD  CONSTRAINT [FK_bl_Users_bl_Groups] FOREIGN KEY([Id])
REFERENCES [dbo].[bl_Groups] ([Id])
GO
ALTER TABLE [dbo].[bl_Users] CHECK CONSTRAINT [FK_bl_Users_bl_Groups]
GO
ALTER DATABASE [BlogIt] SET  READ_WRITE 
GO