/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[Name]
      ,[Price]
      ,[CategoryId]
  FROM [RestaurantEPOS].[dbo].[FoodItem]

  INSERT INTO FoodItem Values (N'Spicy Samosa (15 pcs)', '3.50', 1)
  INSERT INTO FoodItem Values (N'Veg Samosa', '3.00', 1)
  INSERT INTO FoodItem Values (N'Mogo', '4.00', 1)
  INSERT INTO FoodItem Values (N'Mogo Patish (10pcs)', '5.00', 1)
  INSERT INTO FoodItem Values (N'Mogo & Paneer Sizzler', '6.00', 1)
  INSERT INTO FoodItem Values (N'Veg Sizzler', '6.00', 1)
  INSERT INTO FoodItem Values (N'Veg Super Sizzler', '10.00', 1)
  INSERT INTO FoodItem Values (N'Paneer Sizzler', '6.00', 1)
  INSERT INTO FoodItem Values (N'Paneer Shaslik', '6.00', 1)
  INSERT INTO FoodItem Values (N'Quorn Shashlik', '6.00', 1)
  INSERT INTO FoodItem Values (N'Egg Sizzler', '6.00', 1)
  INSERT INTO FoodItem Values (N'Methi Bhajia', '5.00', 1)
  INSERT INTO FoodItem Values (N'Mix Bhajia', '4.00', 1)
  INSERT INTO FoodItem Values (N'Crispy Bhajia', '4.00', 1)
  INSERT INTO FoodItem Values (N'Plain Chips', '1.50', 1)
  INSERT INTO FoodItem Values (N'Masala Chips', '2.50', 1)
  INSERT INTO FoodItem Values (N'Cheese Chips', '2.50', 1)
  
