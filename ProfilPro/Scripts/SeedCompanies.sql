MERGE INTO Company AS Target 
USING (VALUES 
  (0, N'DTI/PBS'), 
  (1, N'C2'), 
  (2, N'Axelan'), 
  (3, N'Fujitsu'), 
  (4, N'R3D/Techsolcom'), 
  (5, N'Teksystems')
) 
AS Source (Id, Name) 
ON Target.Id = Source.Id 

WHEN MATCHED THEN 
	UPDATE SET Name = Source.Name 

WHEN NOT MATCHED BY TARGET THEN 
	INSERT (Id, Name) 
	VALUES (Id, Name) 
 
WHEN NOT MATCHED BY SOURCE THEN 
	DELETE;