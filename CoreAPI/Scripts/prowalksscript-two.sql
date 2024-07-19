

-- Database where you are going to maintain the database...

-- collection of tables

-- Excel one kind of a datasource  -- DBs


-- You shouldnot be depend
-- must be aware

--10 text files

--resume -- target 5 to 6 classes

select * from INFORMATION_SCHEMA.TABLES

--* will return the all the columns of the table
select COLUMN_NAME , DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Regions'
select COLUMN_NAME , DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'Walks'
select COLUMN_NAME , DATA_TYPE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = 'WalkDifficulties'


--3 months

--uniqueidentifier

select NEWID()

select * from Regions

--INSERT INTO Regions (Id, Code, Name, Area, Lat, Long, Population)
--            values('e1a1d5b0-1c2d-4f5e-8a6b-7c8d9e0f1a2b', 'AP', 'Andhra Pradesh', 162968, 15.9129, 79.7400, 49577103)

INSERT INTO Regions (Id, Code, Name, Area, Lat, Long, Population)
            values('f2b2e6c1-2d3e-5f6a-9b7c-8d9e0f1a2b3c', 'BR', 'Bihar', 94163, 25.0961, 85.3131, 104099452),
			      ('ECC8163F-F215-409C-9E43-D7F693E58B74', 'KA', 'Karnataka', 191791, 15.3173, 75.7139, 61095297),
				  ('947080EC-74F8-458D-9FF1-F2F3DBC2FCE1', 'TN', 'Tamil Nadu', 130058, 11.1271, 78.6569, 72147030),
				  ('7CB4524C-A66A-4CA7-AA58-62668D5A8074', 'KL', 'Kerala', 38863, 10.8505, 76.2711, 33406061)



--Project


--One person --> 



--Delete Regions

--select * from Regions

--select * from Regions

--KT Angular
--DB knowledge
--cloud computing knowledge


--'Bihr'

-- DB -> Response of the API -> UI


select * from WalkDifficulties
--

-- what are core tables

select newid()

INSERT INTO WalkDifficulties (Id, Code)
VALUES 
('1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6', 'Easy'),
('2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e', 'Medium'),
('3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f', 'Hard');





--Id	uniqueidentifier
--Name	nvarchar
--Length	float
--RegionId	uniqueidentifier
--WalkDifficultyId	uniqueidentifier

-- Table --> Id which indicates the PrimaryKey

INSERT INTO Walks (Id, Name, Length, RegionId, WalkDifficultyId)
VALUES 
('08B2D7F8-8CEE-4B97-98FE-FE2B18142D06', 'Walk in Andhra Pradesh', 10.5, 'e1a1d5b0-1c2d-4f5e-8a6b-7c8d9e0f1a2b', '1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6'),
('3C2E3FE4-0799-4FBA-96D6-60FC52E743C4', 'Walk in Bihar', 15.2, 'f2b2e6c1-2d3e-5f6a-9b7c-8d9e0f1a2b3c', '2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e'),
('2A96B340-4820-4396-943C-FA7D203D8A4B', 'Walk in Karnataka', 8.3, 'ECC8163F-F215-409C-9E43-D7F693E58B74', '3c4d5e6f-7a8b-9c0d-1e2f-3a4b5c6d7e8f'),
('4E6BAC9D-8A3B-42E9-A2BF-B68DB8267780', 'Walk in Tamil Nadu', 12.7, '947080EC-74F8-458D-9FF1-F2F3DBC2FCE1', '1a2b3c4d-5e6f-7a8b-9c0d-e1f2a3b4c5d6'),
('F5772387-6F11-456A-AB6E-08DCBF903881', 'Walk in Kerala', 20.1, '7CB4524C-A66A-4CA7-AA58-62668D5A8074', '2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e');


select * from Regions
select * from Walks
select * from WalkDifficulties


-- Question is here i want to join these 3 tables.

--  i want to get the records RegionCode , RegionName , Length , DifficulityCode -- I need that records

    --you need to join the tables
	--on which basis you have joint the tabl

	   

	  select re.Code , re.Area , wa.Length , wa.Name ,  wd.Code from 
	             Regions re inner join Walks wa 
	             on re.Id = wa.RegionId
				 inner join WalkDifficulties wd
				 on wd.Id = wa.WalkDifficultyId



	 select * from 
	             Regions re inner join Walks wa 
	             on re.Id = wa.RegionId
				 inner join WalkDifficulties wd
				 on wd.Id = wa.WalkDifficultyId



	select * from Regions re 
	             inner join Walks wa 
	             on re.Id = wa.RegionId

-- Database