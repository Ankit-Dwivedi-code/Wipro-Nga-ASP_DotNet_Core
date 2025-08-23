use AuthDB

-- Table: product table
CREATE TABLE Products (
	id INT IDENTITY(1,1) PRIMARY KEY,
	Name VARCHAR(255) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL
);

Select * from Products;

-- Delete the item in the Products table
DELETE FROM Products WHERE id = 1;