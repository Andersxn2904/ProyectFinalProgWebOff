CREATE DATABASE TrailerAppp

Drop Database TrailerApp

USE TrailerAppp
Use DanderiTV

CREATE TABLE Actors (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255),
    Lastname VARCHAR(255)
);

CREATE TABLE Directors (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255),
    Lastname VARCHAR(255)
);

CREATE TABLE Movies (
    ID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(255),
    Year INT,
    Description TEXT,
    ImagePath VARCHAR(255),
    Streams INT NULL,
    TrailerPath VARCHAR(255),
    DirectorID INT
);

CREATE TABLE MoviesActors(
ID INT PRIMARY KEY IDENTITY(1,1),
ActorID INT,
MovieID INT

);
Select * from Users
CREATE TABLE Users (
    ID NVARCHAR(255) UNIQUE,
    UserName VARCHAR(255),
    Password VARCHAR(255),
    Role VARCHAR(255)
);

Insert into Directors(Name,Lastname) values('Andy', 'Mota')
Insert into Directors(Name,Lastname) values('Loki', 'FC')
Insert into Directors(Name,Lastname) values('Productor', 'Lastname')

Insert into Actors(Name,Lastname) values('Balji', 'FC')
Insert into Actors(Name,Lastname) values('Loki', 'FC')
Insert into Actors(Name,Lastname) values('Actor', 'Lastname')

