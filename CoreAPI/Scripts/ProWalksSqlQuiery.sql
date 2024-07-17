


--collections of data is nothing but database

--//We are maintain the data in the format of tables

--Tables are part of database

--Tables List

select * from INFORMATION_SCHEMA.TABLES

select * from Regions

select NEWID()
--Insert the record(table)

--insert into <tablename>(col_names) values (col_values)
insert into 
Regions([Id] , [Code] , [Area] , [Name] , [Lat] , [Long] ,[population])
values
('DE59641B-D21A-465D-A1DF-075074231135', 'HN' , 19990000, 'Hindu' , 
10.90, 90.90 , 100000)


insert into 
Regions([Id] , [Code] , [Area] , [Name] , [Lat] , [Long] ,[population])
values
('A575F2AF-C097-4E13-B711-D50AB10201B4', 'MS' , 19990000, 'Muslims' , 
110.90, 190.90 , 5000)


select * from INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS





select * from Walks
select * from WalkDifficulties















select * from regions



--For Delete
delete Regions



insert into regions 
([Id], [Code] , [Area] , [Lat] , [Long] , [Name] , [Population] , [RegionImageUrl])
values
('279CDC54-39E9-4FE3-A302-F53EE2589206', 'Hn' , 1099990 , 10.90999, 90.0009, 'Hindu' , 20000000, 'sampleimage.com')





insert into regions 
( [Code] , [Area] , [Lat] , [Long] , [Name] , [Population] , [RegionImageUrl])
values
( 'Hn1' , 1099990 , 10.90999, 90.0009, 'Hindu' , 20000000, 'sampleimage.com')


select NEWID()