/* Create database and setup references */
USE master;

WHILE EXISTS(select NULL from sys.databases where name='RackUdstyr')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'RackUdstyr') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE RackUdstyr
END
GO

Create Database [RackUdstyr]
GO

use [RackUdstyr]
GO

Create Table [dbo].[Rack] (
  No int not null primary key,
  MaxSlots int not null
);

Create Table [dbo].[RacksUdstyr] (
  Id int not null primary key IDENTITY(1,1),
  UdstyrId int not null unique,
  RackNo int not null
);

Create Table [dbo].[Udstyr] (
  Id int not null primary key IDENTITY(1,1),
  OsId int,
  TypeId int not null
);

Create Table [dbo].[Os] (
  OsId int not null primary key IDENTITY(1,1),
  Navn varchar not null
);

Create Table [dbo].[Type] (
  TypeId int not null primary key IDENTITY(1,1),
  Navn varchar not null
);

Create Table [dbo].[RU] (
  No int not null,
  UId int not null,
);

Create Table [dbo].[Udlaant] (
  UId int not null primary key IDENTITY(1,1),
  DatoStart datetime not null,
  DatoSlut datetime not null,
  KId int not null
);

Create Table [dbo].[Klasse] (
  KId int not null primary key
)
GO

ALTER TABLE RackUdstyr
ADD Constraint rackUdstyrConst
FOREIGN KEY (RackNo) REFERENCES Rack(No)
ON UPDATE CASCADE,
FOREIGN KEY (UdstyrId) REFERENCES Udstyr(Id)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Udstyr
ADD Constraint udstyrConst
FOREIGN KEY (OsId) REFERENCES Os(OsId)
ON UPDATE CASCADE,
FOREIGN KEY (TypeId) REFERENCES Type(TypeId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE RU
ADD Constraint ruConst
FOREIGN KEY (No) REFERENCES Rack(No)
ON UPDATE CASCADE
ON DELETE CASCADE,
FOREIGN KEY (UId) REFERENCES Udlaant(UId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE Udlaant
ADD Constraint udlaantConst
FOREIGN KEY (KId) REFERENCES Klasse(KId)
ON UPDATE CASCADE
ON DELETE CASCADE
GO

INSERT INTO Klasse
VALUES
(14),
(16),
(34),
(47),
(58)
GO

INSERT INTO Type (Navn)
VALUES
('Router'),
('Switch'),
('Skærm'),
('Server'),
('Hub')
GO

INSERT INTO Os (Navn)
VALUES
('Windows 10'),
('Windows 2016 Server'),
('Windows 7'),
('IOS 12.2'),
('IOS 15.2'),
('Ubuntu 15')
GO

INSERT INTO Udstyr (OsId, TypeId)
VALUES
(1,4),
(1,5),
(2,4),
(2,5),
(3,NULL),
(4,2),
(4,6),
(5,NULL)
GO

INSERT INTO Rack (No, MaxSlots)
VALUES
(34,10),
(45,15),
(55,18),
(56,20),
(58,15)
GO

INSERT INTO RackUdstyr (UdstyrId, RackNo)
VALUES
(1,34),
(2,34),
(3,34),
(6,55),
(7,55),
(8,45)
GO

INSERT INTO Udlaant (DatoStart, DatoSlut, KId)
VALUES
(GETDATE(),DATEADD(day,1,GETDATE()),14),
(GETDATE(),DATEADD(day,2,GETDATE()),34),
(GETDATE(),DATEADD(day,3,GETDATE()),34),
(GETDATE(),DATEADD(day,100,GETDATE()),57)
GO

INSERT INTO RU (No, UId)
VALUES
(34,1),
(14,2),
(16,3),
(47,4)
GO
