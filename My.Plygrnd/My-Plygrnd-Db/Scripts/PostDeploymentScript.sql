USE [my-plygrnd]
GO

TRUNCATE TABLE ReferenceLibrary
INSERT INTO ReferenceLibrary(RefType, RefCd, Descp)
VALUES	('BsnType', 1, 'Restaurant'),
		('BsnType', 2, 'Cafe')

TRUNCATE TABLE BusinessInfo
INSERT INTO BusinessInfo (Name, Type, PIC)
VALUES	('New Town', 1, 'Aiman'),
		('Relax @ Cafe', 2, 'Burhan')

TRUNCATE TABLE BusinessOutlet
INSERT INTO BusinessOutlet (BusinessId, BranchId, [Name], [Address])
VALUES	((SELECT Id FROM BusinessInfo (NOLOCK) WHERE [Name] = 'New Town'), 'NT001', 'New Town Puchong', '15, Jalan Puteri 1/6, Bandar Puteri, 47100 Puchong, Selangor'),
		((SELECT Id FROM BusinessInfo (NOLOCK) WHERE [Name] = 'New Town'), 'NT002', 'New Town Bangi', '23, Jalan Medan Pusat Bandar 4A, Seksyen 9, 43650 Bangi, Selangor'),
		((SELECT Id FROM BusinessInfo (NOLOCK) WHERE [Name] = 'Relax @ Cafe'), 'RC001', 'RC Klang', '2112, Jalan Meru, Kawasan 17, 41300 Klang, Selangor'),
		((SELECT Id FROM BusinessInfo (NOLOCK) WHERE [Name] = 'Relax @ Cafe'), 'RC002', 'RC PJ', 'ground floor 8, Lebuh Bandar Utama, Bu 12, 47800 Petaling Jaya, Selangor')

TRUNCATE TABLE WebUser
INSERT INTO WebUser (BusinessId, Username, Password, Status, CreationDate)
VALUES	((SELECT Id FROM BusinessInfo (NOLOCK) WHERE [Name] = 'New Town'), 'user1', '1234abcd', 'A', GETDATE()),
		((SELECT Id FROM BusinessInfo (NOLOCK) WHERE [Name] = 'Relax @ Cafe'), 'user2', '1234abcd', 'A', GETDATE())

-- Validate
SELECT * FROM ReferenceLibrary (NOLOCK)
SELECT * FROM BusinessInfo (NOLOCK)
SELECT * FROM BusinessOutlet (NOLOCK)
SELECT * FROM WebUser (NOLOCK)