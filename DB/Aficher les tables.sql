/****** Script de la commande SelectTopNRows à partir de SSMS  ******/

  SELECT TOP (1000) [ID]
      ,[Mail]
      ,[Pwd]
  FROM [ToDoList].[dbo].[Users]



    SELECT TOP (1000) [ID]
      ,[TaskState]
      ,[DeadLine]
      ,[Note]
      ,[IDUserCreator]
  FROM [ToDoList].[dbo].[Tasks]



  SELECT TOP (1000) [IDTask]
      ,[IDUser]
  FROM [ToDoList].[dbo].[Task_User]



  SELECT TOP (1000) [ID]
      ,[Content]
      ,[CreateDate]
      ,[IDUser]
  FROM [ToDoList].[dbo].[Comments]



  SELECT TOP (1000) [IDComment]
      ,[IDTask]
  FROM [ToDoList].[dbo].[Task_Comments]

  


