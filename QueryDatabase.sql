Create database DanderiTV

use DanderiTV

DROP TABLE IF EXISTS Series;
DROP TABLE IF EXISTS Genres;
DROP TABLE IF EXISTS Producers;


go

CREATE TABLE Series (
    ID INT  PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255),
    CoverUrl NVARCHAR(max),
    VideoUrl NVARCHAR(max),
    MainGenreID INT,
    SecondaryGenreID INT NULL,
    ProducerID INT,
    Created Datetime NULL,
    FOREIGN KEY (MainGenreID) REFERENCES Genres(ID),
    FOREIGN KEY (SecondaryGenreID) REFERENCES Genres(ID),
    FOREIGN KEY (ProducerID) REFERENCES Producers(ID)
);

CREATE TABLE Genres (
    ID INT  PRIMARY KEY IDENTITY(1,1),
    Created Datetime,
    Name VARCHAR(255)
);

CREATE TABLE Producers (
    ID INT  PRIMARY KEY IDENTITY(1,1),
    Created Datetime,
    Name VARCHAR(255)
);

-- Insertar registros en la tabla Genres
INSERT INTO Genres (Created, Name)
VALUES
    (CURRENT_TIMESTAMP, 'Genre 1'),
    (CURRENT_TIMESTAMP, 'Genre 2'),
    (CURRENT_TIMESTAMP, 'Genre 3'),
    (CURRENT_TIMESTAMP, 'Genre 4'),
    (CURRENT_TIMESTAMP, 'Genre 5');

-- Insertar registros en la tabla Producers
INSERT INTO Producers (Created, Name)
VALUES
    (CURRENT_TIMESTAMP, 'Producer 1'),
    (CURRENT_TIMESTAMP, 'Producer 2'),
    (CURRENT_TIMESTAMP, 'Producer 3'),
    (CURRENT_TIMESTAMP, 'Producer 4'),
    (CURRENT_TIMESTAMP, 'Producer 5');

-- Insertar registros en la tabla Series
INSERT INTO Series (Name, CoverUrl, VideoUrl, MainGenreID, SecondaryGenreID, ProducerID, Created)
VALUES
    ('Serie 1', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 1, 2, 1, CURRENT_TIMESTAMP),
    ('Serie 2', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 2, 3, 2, CURRENT_TIMESTAMP),
    ('Serie 3', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 3, 4, 3, CURRENT_TIMESTAMP),
    ('Serie 4', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 4, 5, 4, CURRENT_TIMESTAMP),
    ('Serie 5', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 5, 1, 5, CURRENT_TIMESTAMP),
    ('Serie 6', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 1, 3, 2, CURRENT_TIMESTAMP),
    ('Serie 7', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 2, 4, 3, CURRENT_TIMESTAMP),
    ('Serie 8', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 3, 5, 4, CURRENT_TIMESTAMP),
    ('Serie 9', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 4, 1, 5, CURRENT_TIMESTAMP),
    ( 'Serie 10', 'https://play-lh.googleusercontent.com/Eq7Sr7QjQyxvkEtObHQqXxfobQKCob4Rhg5e8Vxr2lRmPuBRRB-v_-7hNgNbTgzkoAp9Y1Hm0z_b6A863sU', 'https://www.youtube.com/embed/rF9QzsDIVlU?si=B22F5N22oOKXPTe0', 5, 2, 1, CURRENT_TIMESTAMP);


