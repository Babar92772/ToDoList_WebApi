/****** Script de la commande SelectTopNRows à partir de SSMS  ******/

SELECT TOP (1000) [ID]
      ,[Mail]
      ,[Pwd]
  FROM [ToDoList].[dbo].[Users]

  
  SELECT TOP (1000) [ID]
      ,[TaskState]
      ,[CreateDate]
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
      ,[IDTask]
  FROM [ToDoList].[dbo].[Comments]




  


