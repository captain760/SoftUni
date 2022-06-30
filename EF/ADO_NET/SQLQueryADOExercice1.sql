--Problem 02
SELECT 
v.Name,
COUNT(MinionId) AS MinionCount
FROM Villains AS v
JOIN MinionsVillains AS mv ON v.Id = mv.VillainId
GROUP BY v.Id, v.Name
HAVING COUNT(MinionId)>3
ORDER BY MinionCount DESC
GO
--Problem 03
SELECT * FROM Villains WHERE Id = 1
GO
SELECT 
ROW_NUMBER() OVER (ORDER BY m.[Name]) AS RowNumber,
m.[Name],
m.Age
FROM Minions AS m
JOIN MinionsVillains AS mv ON m.Id = mv.MinionId
WHERE mv.VillainId = 1
GO
--Problem 04
SELECT [Name]
FROM Towns
WHERE [Name] = @townName
GO
SELECT Id
FROM Villains
WHERE [Name] = @villainName
GO
INSERT INTO Villains ([Name], EvilnessFactorId)
VALUES
(@villainName, 4)
GO
INSERT INTO Minions([Name], [Age], [TownId])
VALUES
(@minionName, @minionAge,@townId)
GO
SELECT [Id]
FROM Minions
WHERE [Name] = @minionName
GO
INSERT INTO MinionsVillain(MinionId, villainId)
VALUES
(@minionId, @VillainId)
GO
--Problem 05
SELECT
t.[Name]
FROM Towns AS t
JOIN Countries AS c ON t.CountryCode = c.Id
WHERE c.[Name] = 'Bulgaria'
GO
UPDATE Towns
SET [Name] = UPPER([Name])
WHERE [Name] in (SELECT
t.[Name]
FROM Towns AS t
JOIN Countries AS c ON t.CountryCode = c.Id
WHERE c.[Name] = 'Bulgaria')