select * from dbo.Songs

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('AlanWalker', 'On My Way', 10, '/data/audio/1.mp3', 'On My Way', '/data/img/1.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('AlanWalker', 'Faded', 10, '/data/audio/2.mp3', 'Faded', '/data/img/2.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('On and On', 'On and On', 10, '/data/audio/3.mp3', 'On and On', '/data/img/3.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Ft.Daniel Levi', 'Ft.Daniel Levi', 10, '/data/audio/4.mp3', 'Ft.Daniel Levi', '/data/img/4.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('AnDo Music', 'AnDo Music', 10, '/data/audio/5.mp3', 'AnDo Music', '/data/img/5.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('FineArt', 'FineArt', 10, '/data/audio/6.mp3', 'FineArt', '/data/img/6.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Agar Tum Saath Ho', 'Agar Tum Saath Ho', 10, '/data/audio/7.mp3', 'Agar Tum Saath Ho', '/data/img/7.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Suna Hai', 'Suna Hai', 10, '/data/audio/8.mp3', 'Suna Hai', '/data/img/8.jpg');

CREATE TABLE FavouritesSongs (
    FavoritesId INT PRIMARY KEY,
    SongId INT,
    UserName NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (SongId) REFERENCES Songs(SongId)
);

select * from dbo.FavouritesSongs