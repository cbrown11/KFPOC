

INSERT INTO [dbo].[Assets](Id, [Name], [Description]) 
VALUES
(4,'test4', 'test4'),
(5,'test5', 'test5');

UPDATE [dbo].[Assets]
SET [Name] = 'test 1 updated'
WHERE Id = 1;
