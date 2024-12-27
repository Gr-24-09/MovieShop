--select distinct Title,Director,ReleaseYear,Price into Movies_temp from Movies
--Delete  Movies
--DBCC CHECKIDENT ('[Movies]', RESEED, 0);
insert into Movies(Title,Director,ReleaseYear,Price) select * from Movies_temp
