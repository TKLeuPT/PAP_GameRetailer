
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/16/2022 14:44:49
-- Generated from EDMX file: C:\Users\leona\source\repos\TKLeuPT\PAP_GameRetailer\GameRetailer\Models\GameRetailer.edmx
-- --------------------------------------------------
Create database [GameRetailer];
SET QUOTED_IDENTIFIER OFF;
GO
USE [GameRetailer];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Armazem_Login]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Armazem] DROP CONSTRAINT [FK_Armazem_Login];
GO
IF OBJECT_ID(N'[dbo].[FK_CabecalhoGuia_ToArmazem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CabecalhoGuia] DROP CONSTRAINT [FK_CabecalhoGuia_ToArmazem];
GO
IF OBJECT_ID(N'[dbo].[FK_CabecalhoGuia_ToCliente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CabecalhoGuia] DROP CONSTRAINT [FK_CabecalhoGuia_ToCliente];
GO
IF OBJECT_ID(N'[dbo].[FK_CabecalhoGuia_ToDistribuidor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CabecalhoGuia] DROP CONSTRAINT [FK_CabecalhoGuia_ToDistribuidor];
GO
IF OBJECT_ID(N'[dbo].[FK_CabecalhoGuiaToViatura]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CabecalhoGuia] DROP CONSTRAINT [FK_CabecalhoGuiaToViatura];
GO
IF OBJECT_ID(N'[dbo].[FK_Compra_Armazem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compra] DROP CONSTRAINT [FK_Compra_Armazem];
GO
IF OBJECT_ID(N'[dbo].[FK_Compra_Compra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Compra] DROP CONSTRAINT [FK_Compra_Compra];
GO
IF OBJECT_ID(N'[dbo].[FK_DetalheGuia_ToCabecalhoGuia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalheGuia] DROP CONSTRAINT [FK_DetalheGuia_ToCabecalhoGuia];
GO
IF OBJECT_ID(N'[dbo].[FK_Jogo_Armazem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Jogo] DROP CONSTRAINT [FK_Jogo_Armazem];
GO
IF OBJECT_ID(N'[dbo].[FK_Jogo_ToDetalheGuia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[DetalheGuia] DROP CONSTRAINT [FK_Jogo_ToDetalheGuia];
GO
IF OBJECT_ID(N'[dbo].[FK_Stock_Jogo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stock] DROP CONSTRAINT [FK_Stock_Jogo];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Armazem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Armazem];
GO
IF OBJECT_ID(N'[dbo].[CabecalhoGuia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CabecalhoGuia];
GO
IF OBJECT_ID(N'[dbo].[Cliente]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cliente];
GO
IF OBJECT_ID(N'[dbo].[Compra]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Compra];
GO
IF OBJECT_ID(N'[dbo].[DetalheGuia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DetalheGuia];
GO
IF OBJECT_ID(N'[dbo].[Distribuidor]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Distribuidor];
GO
IF OBJECT_ID(N'[dbo].[Jogo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jogo];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[Stock]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stock];
GO
IF OBJECT_ID(N'[dbo].[Viatura]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Viatura];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Armazem'
CREATE TABLE [dbo].[Armazem] (
    [CodArmazem] int IDENTITY(1,1) NOT NULL,
    [CodPostal] varchar(8)  NOT NULL,
    [Nome] varchar(30)  NOT NULL,
    [Morada] varchar(50)  NOT NULL,
    [Localidade] varchar(20)  NOT NULL,
    [Dono] int  NOT NULL
);
GO

-- Creating table 'CabecalhoGuia'
CREATE TABLE [dbo].[CabecalhoGuia] (
    [NumGuia] int IDENTITY(1,1) NOT NULL,
    [DataEmissao] datetime  NOT NULL,
    [CodArmazem] int  NOT NULL,
    [Matricula] varchar(30)  NOT NULL,
    [NumCliente] int  NOT NULL,
    [CodDistribuidor] int  NOT NULL
);
GO

-- Creating table 'Cliente'
CREATE TABLE [dbo].[Cliente] (
    [NumCliente] int IDENTITY(1,1) NOT NULL,
    [NIF] int  NOT NULL,
    [Nome] varchar(30)  NOT NULL,
    [Telemovel] varchar(15)  NOT NULL,
    [Email] varchar(50)  NOT NULL,
    [Morada] varchar(50)  NOT NULL,
    [Localidade] varchar(20)  NOT NULL,
    [CodPostal] varchar(8)  NOT NULL
);
GO

-- Creating table 'DetalheGuia'
CREATE TABLE [dbo].[DetalheGuia] (
    [NumDGuia] int IDENTITY(1,1) NOT NULL,
    [CodBarras] int  NOT NULL,
    [Quantidade] int  NOT NULL,
    [NumGuia] int  NOT NULL
);
GO

-- Creating table 'Distribuidor'
CREATE TABLE [dbo].[Distribuidor] (
    [CodDistribuidor] int IDENTITY(1,1) NOT NULL,
    [Nome] varchar(30)  NOT NULL,
    [Telemovel] varchar(15)  NOT NULL,
    [Email] varchar(50)  NOT NULL
);
GO

-- Creating table 'Jogo'
CREATE TABLE [dbo].[Jogo] (
    [CodBarras] int  NOT NULL,
    [Criadora] varchar(30)  NOT NULL,
    [Categoria] varchar(30)  NOT NULL,
    [AnoLancamento] int  NOT NULL,
    [Preco] decimal(18,0)  NOT NULL,
    [Nome] varchar(30)  NOT NULL,
    [NumDArmazem] int  NOT NULL
);
GO

-- Creating table 'Viatura'
CREATE TABLE [dbo].[Viatura] (
    [Matricula] varchar(30)  NOT NULL,
    [Marca] varchar(30)  NOT NULL,
    [Modelo] varchar(30)  NOT NULL,
    [Kms] int  NOT NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [dbo].[Login] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Email] varchar(150)  NOT NULL,
    [Password] varchar(300)  NOT NULL,
    [PasswordSalt] varchar(300)  NOT NULL,
    [FName] varchar(50)  NOT NULL,
    [LName] varchar(50)  NOT NULL,
    [UserType] varchar(50)  NOT NULL
);
GO

-- Creating table 'Stock'
CREATE TABLE [dbo].[Stock] (
    [NumJogo] int  NOT NULL,
    [Quantidade] int  NOT NULL
);
GO

-- Creating table 'Compra'
CREATE TABLE [dbo].[Compra] (
    [NumCompra] int IDENTITY(1,1) NOT NULL,
    [DataCompra] datetime  NOT NULL,
    [NumArmazem] int  NOT NULL,
    [CodBarras] int  NOT NULL,
    [Quantidade] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CodArmazem] in table 'Armazem'
ALTER TABLE [dbo].[Armazem]
ADD CONSTRAINT [PK_Armazem]
    PRIMARY KEY CLUSTERED ([CodArmazem] ASC);
GO

-- Creating primary key on [NumGuia] in table 'CabecalhoGuia'
ALTER TABLE [dbo].[CabecalhoGuia]
ADD CONSTRAINT [PK_CabecalhoGuia]
    PRIMARY KEY CLUSTERED ([NumGuia] ASC);
GO

-- Creating primary key on [NumCliente] in table 'Cliente'
ALTER TABLE [dbo].[Cliente]
ADD CONSTRAINT [PK_Cliente]
    PRIMARY KEY CLUSTERED ([NumCliente] ASC);
GO

-- Creating primary key on [NumDGuia] in table 'DetalheGuia'
ALTER TABLE [dbo].[DetalheGuia]
ADD CONSTRAINT [PK_DetalheGuia]
    PRIMARY KEY CLUSTERED ([NumDGuia] ASC);
GO

-- Creating primary key on [CodDistribuidor] in table 'Distribuidor'
ALTER TABLE [dbo].[Distribuidor]
ADD CONSTRAINT [PK_Distribuidor]
    PRIMARY KEY CLUSTERED ([CodDistribuidor] ASC);
GO

-- Creating primary key on [CodBarras] in table 'Jogo'
ALTER TABLE [dbo].[Jogo]
ADD CONSTRAINT [PK_Jogo]
    PRIMARY KEY CLUSTERED ([CodBarras] ASC);
GO

-- Creating primary key on [Matricula] in table 'Viatura'
ALTER TABLE [dbo].[Viatura]
ADD CONSTRAINT [PK_Viatura]
    PRIMARY KEY CLUSTERED ([Matricula] ASC);
GO

-- Creating primary key on [ID] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [NumJogo] in table 'Stock'
ALTER TABLE [dbo].[Stock]
ADD CONSTRAINT [PK_Stock]
    PRIMARY KEY CLUSTERED ([NumJogo] ASC);
GO

-- Creating primary key on [NumCompra] in table 'Compra'
ALTER TABLE [dbo].[Compra]
ADD CONSTRAINT [PK_Compra]
    PRIMARY KEY CLUSTERED ([NumCompra] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CodArmazem] in table 'CabecalhoGuia'
ALTER TABLE [dbo].[CabecalhoGuia]
ADD CONSTRAINT [FK_CabecalhoGuia_ToArmazem]
    FOREIGN KEY ([CodArmazem])
    REFERENCES [dbo].[Armazem]
        ([CodArmazem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CabecalhoGuia_ToArmazem'
CREATE INDEX [IX_FK_CabecalhoGuia_ToArmazem]
ON [dbo].[CabecalhoGuia]
    ([CodArmazem]);
GO

-- Creating foreign key on [NumCliente] in table 'CabecalhoGuia'
ALTER TABLE [dbo].[CabecalhoGuia]
ADD CONSTRAINT [FK_CabecalhoGuia_ToCliente]
    FOREIGN KEY ([NumCliente])
    REFERENCES [dbo].[Cliente]
        ([NumCliente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CabecalhoGuia_ToCliente'
CREATE INDEX [IX_FK_CabecalhoGuia_ToCliente]
ON [dbo].[CabecalhoGuia]
    ([NumCliente]);
GO

-- Creating foreign key on [CodDistribuidor] in table 'CabecalhoGuia'
ALTER TABLE [dbo].[CabecalhoGuia]
ADD CONSTRAINT [FK_CabecalhoGuia_ToDistribuidor]
    FOREIGN KEY ([CodDistribuidor])
    REFERENCES [dbo].[Distribuidor]
        ([CodDistribuidor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CabecalhoGuia_ToDistribuidor'
CREATE INDEX [IX_FK_CabecalhoGuia_ToDistribuidor]
ON [dbo].[CabecalhoGuia]
    ([CodDistribuidor]);
GO

-- Creating foreign key on [Matricula] in table 'CabecalhoGuia'
ALTER TABLE [dbo].[CabecalhoGuia]
ADD CONSTRAINT [FK_CabecalhoGuiaToViatura]
    FOREIGN KEY ([Matricula])
    REFERENCES [dbo].[Viatura]
        ([Matricula])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CabecalhoGuiaToViatura'
CREATE INDEX [IX_FK_CabecalhoGuiaToViatura]
ON [dbo].[CabecalhoGuia]
    ([Matricula]);
GO

-- Creating foreign key on [NumGuia] in table 'DetalheGuia'
ALTER TABLE [dbo].[DetalheGuia]
ADD CONSTRAINT [FK_DetalheGuia_ToCabecalhoGuia]
    FOREIGN KEY ([NumGuia])
    REFERENCES [dbo].[CabecalhoGuia]
        ([NumGuia])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DetalheGuia_ToCabecalhoGuia'
CREATE INDEX [IX_FK_DetalheGuia_ToCabecalhoGuia]
ON [dbo].[DetalheGuia]
    ([NumGuia]);
GO

-- Creating foreign key on [CodBarras] in table 'DetalheGuia'
ALTER TABLE [dbo].[DetalheGuia]
ADD CONSTRAINT [FK_Jogo_ToDetalheGuia]
    FOREIGN KEY ([CodBarras])
    REFERENCES [dbo].[Jogo]
        ([CodBarras])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Jogo_ToDetalheGuia'
CREATE INDEX [IX_FK_Jogo_ToDetalheGuia]
ON [dbo].[DetalheGuia]
    ([CodBarras]);
GO

-- Creating foreign key on [NumDArmazem] in table 'Jogo'
ALTER TABLE [dbo].[Jogo]
ADD CONSTRAINT [FK_Jogo_Armazem]
    FOREIGN KEY ([NumDArmazem])
    REFERENCES [dbo].[Armazem]
        ([CodArmazem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Jogo_Armazem'
CREATE INDEX [IX_FK_Jogo_Armazem]
ON [dbo].[Jogo]
    ([NumDArmazem]);
GO

-- Creating foreign key on [Dono] in table 'Armazem'
ALTER TABLE [dbo].[Armazem]
ADD CONSTRAINT [FK_Armazem_Login]
    FOREIGN KEY ([Dono])
    REFERENCES [dbo].[Login]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Armazem_Login'
CREATE INDEX [IX_FK_Armazem_Login]
ON [dbo].[Armazem]
    ([Dono]);
GO

-- Creating foreign key on [NumJogo] in table 'Stock'
ALTER TABLE [dbo].[Stock]
ADD CONSTRAINT [FK_Stock_Jogo]
    FOREIGN KEY ([NumJogo])
    REFERENCES [dbo].[Jogo]
        ([CodBarras])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [NumArmazem] in table 'Compra'
ALTER TABLE [dbo].[Compra]
ADD CONSTRAINT [FK_Compra_Armazem]
    FOREIGN KEY ([NumArmazem])
    REFERENCES [dbo].[Armazem]
        ([CodArmazem])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Compra_Armazem'
CREATE INDEX [IX_FK_Compra_Armazem]
ON [dbo].[Compra]
    ([NumArmazem]);
GO

-- Creating foreign key on [CodBarras] in table 'Compra'
ALTER TABLE [dbo].[Compra]
ADD CONSTRAINT [FK_Compra_Compra]
    FOREIGN KEY ([CodBarras])
    REFERENCES [dbo].[Jogo]
        ([CodBarras])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Compra_Compra'
CREATE INDEX [IX_FK_Compra_Compra]
ON [dbo].[Compra]
    ([CodBarras]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------