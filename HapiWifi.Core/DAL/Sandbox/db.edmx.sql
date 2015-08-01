
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/01/2015 12:12:19
-- Generated from EDMX file: C:\Users\jick\Desktop\HapiWifi\HapiWifi.Core\DAL\Sandbox\db.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HapiWifiDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[__MigrationHistory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[__MigrationHistory];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CompanySet'
CREATE TABLE [dbo].[CompanySet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Tagline] nvarchar(max)  NOT NULL,
    [Website] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [BannerImagePath] nvarchar(max)  NOT NULL,
    [LogoImagePath] nvarchar(max)  NOT NULL,
    [CompanyGroupCompany_Company_Id] int  NOT NULL
);
GO

-- Creating table 'CompanyGroupSet'
CREATE TABLE [dbo].[CompanyGroupSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CompanyBranchSet'
CREATE TABLE [dbo].[CompanyBranchSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Company_Id] int  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'C__MigrationHistory'
CREATE TABLE [dbo].[C__MigrationHistory] (
    [MigrationId] nvarchar(150)  NOT NULL,
    [ContextKey] nvarchar(300)  NOT NULL,
    [Model] varbinary(max)  NOT NULL,
    [ProductVersion] nvarchar(32)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [PK_CompanySet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompanyGroupSet'
ALTER TABLE [dbo].[CompanyGroupSet]
ADD CONSTRAINT [PK_CompanyGroupSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CompanyBranchSet'
ALTER TABLE [dbo].[CompanyBranchSet]
ADD CONSTRAINT [PK_CompanyBranchSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [MigrationId], [ContextKey] in table 'C__MigrationHistory'
ALTER TABLE [dbo].[C__MigrationHistory]
ADD CONSTRAINT [PK_C__MigrationHistory]
    PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Company_Id] in table 'CompanyBranchSet'
ALTER TABLE [dbo].[CompanyBranchSet]
ADD CONSTRAINT [FK_CompanyCompanyBranch]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[CompanySet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyCompanyBranch'
CREATE INDEX [IX_FK_CompanyCompanyBranch]
ON [dbo].[CompanyBranchSet]
    ([Company_Id]);
GO

-- Creating foreign key on [CompanyGroupCompany_Company_Id] in table 'CompanySet'
ALTER TABLE [dbo].[CompanySet]
ADD CONSTRAINT [FK_CompanyGroupCompany]
    FOREIGN KEY ([CompanyGroupCompany_Company_Id])
    REFERENCES [dbo].[CompanyGroupSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyGroupCompany'
CREATE INDEX [IX_FK_CompanyGroupCompany]
ON [dbo].[CompanySet]
    ([CompanyGroupCompany_Company_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------