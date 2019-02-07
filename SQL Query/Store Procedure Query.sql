CREATE PROCEDURE ReportDetails
AS SELECT 
Customer.ID as InvoiceNo, Customer.CustomerName, Customer.OrderNumber, Customer.Description, Customer.Date,
Purchase.ID, Purchase.CustomerID, Purchase.ProductID, Product.ProductName, Purchase.Price, Purchase.Quantity, Purchase.TotalPrice
FROM (( Purchase INNER JOIN Customer ON Purchase.CustomerID = Customer.ID)
		INNER JOIN Product ON Purchase.ProductID = Product.ID)
RETURN 0