
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/01/2015 14:10:13
-- Generated from EDMX file: C:\Users\Stephen\dev\Alpha-Centauri\binbash\Models\BinBashModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [binbash];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CartProduct_Cart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartProduct] DROP CONSTRAINT [FK_CartProduct_Cart];
GO
IF OBJECT_ID(N'[dbo].[FK_CartProduct_Product]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CartProduct] DROP CONSTRAINT [FK_CartProduct_Product];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_CategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_UserCart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Carts] DROP CONSTRAINT [FK_UserCart];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[CartProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CartProduct];
GO
IF OBJECT_ID(N'[dbo].[Carts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Carts];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Carts'
CREATE TABLE [dbo].[Carts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [CategoryId] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CartProduct'
CREATE TABLE [dbo].[CartProduct] (
    [Carts_Id] int  NOT NULL,
    [Products_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [PK_Carts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Carts_Id], [Products_Id] in table 'CartProduct'
ALTER TABLE [dbo].[CartProduct]
ADD CONSTRAINT [PK_CartProduct]
    PRIMARY KEY CLUSTERED ([Carts_Id], [Products_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'Carts'
ALTER TABLE [dbo].[Carts]
ADD CONSTRAINT [FK_UserCart]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserCart'
CREATE INDEX [IX_FK_UserCart]
ON [dbo].[Carts]
    ([User_Id]);
GO

-- Creating foreign key on [CategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_CategoryProduct]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProduct'
CREATE INDEX [IX_FK_CategoryProduct]
ON [dbo].[Products]
    ([CategoryId]);
GO

-- Creating foreign key on [Carts_Id] in table 'CartProduct'
ALTER TABLE [dbo].[CartProduct]
ADD CONSTRAINT [FK_CartProduct_Carts]
    FOREIGN KEY ([Carts_Id])
    REFERENCES [dbo].[Carts]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Products_Id] in table 'CartProduct'
ALTER TABLE [dbo].[CartProduct]
ADD CONSTRAINT [FK_CartProduct_Products]
    FOREIGN KEY ([Products_Id])
    REFERENCES [dbo].[Products]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CartProduct_Products'
CREATE INDEX [IX_FK_CartProduct_Products]
ON [dbo].[CartProduct]
    ([Products_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------