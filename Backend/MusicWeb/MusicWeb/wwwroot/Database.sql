select * from dbo.Songs

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Wren Evans, Itsnk', 'Từng quen', 10, '/data/audio/1.mp3', 'On My Way', '/data/img/1.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('The Masked Singer, Hippohappy', 'Rồi em sẽ gặp một chàng trai khác', 10, '/data/audio/2.mp3', 'Faded', '/data/img/2.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Karik, GDucky', 'Bạn đời', 10, '/data/audio/3.mp3', 'On and On', '/data/img/3.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Phương Ly', 'Anh là ngoại lệ của em ', 10, '/data/audio/4.mp3', 'Ft.Daniel Levi', '/data/img/4.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Quang Anh Rhyder, CoolKid, BAN', 'Chịu cách mình nói thua', 10, '/data/audio/5.mp3', 'AnDo Music', '/data/img/5.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('The Masked Singer, Voi Bản Đôn', 'Khóa ly biệt', 10, '/data/audio/6.mp3', 'FineArt', '/data/img/6.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('Binz', 'Hit me up', 10, '/data/audio/7.mp3', 'Agar Tum Saath Ho', '/data/img/7.jpg');

INSERT INTO dbo.Songs (Title, SongName, Rate, LinkLocal, Lyric, LinkImg)
VALUES ('W/n', 'id 072019', 10, '/data/audio/8.mp3', 'Suna Hai', '/data/img/8.jpg');

CREATE TABLE FavouritesSongs (
    FavoritesId INT PRIMARY KEY IDENTITY,
    SongId INT,
    UserName NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (SongId) REFERENCES Songs(SongId)
);

select * from dbo.FavouritesSongs