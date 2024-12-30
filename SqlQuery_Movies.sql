--select distinct Title,Director,ReleaseYear,Price into Movies_temp from Movies
--Delete  Movies
--DBCC CHECKIDENT ('[Movies]', RESEED, 0);
--insert into Movies(Title,Director,ReleaseYear,Price) select distinct Title,Director,ReleaseYear,Price from Movies_temp





--INSERT INTO Customers 
--(FirstNameBillingAddress, LastNameBillingAddress,FirstNameDeliveryAddress, LastNameDeliveryAddress,BillingAddress, BillingZip, BillingCity,DeliveryAddress, DeliverZip, DeliverCity,EmailAddress, PhoneNo ) VALUES
--('John', 'Doe', 'John', 'Doe', '123 Main St', '12345', 'New York', '123 Main St', '12345', 'New York', 'john.doe@email.com', '123-456-7890'),
--('Jane', 'Smith', 'Jane', 'Smith', '456 Oak St', '54321', 'Los Angeles', '456 Oak St', '54321', 'Los Angeles', 'jane.smith@email.com', '234-567-8901'),
--('Michael', 'Brown', 'Michael', 'Brown', '789 Pine St', '67890', 'Chicago', '789 Pine St', '67890', 'Chicago', 'michael.brown@email.com', '345-678-9012'), 
--('Emily', 'Clark', 'Emily', 'Clark', '101 Elm St', '13579', 'Houston', '101 Elm St', '13579', 'Houston', 'emily.clark@email.com', '456-789-0123'), 
--('Daniel', 'Johnson', 'Daniel', 'Johnson', '202 Maple St', '24680', 'Phoenix', '202 Maple St', '24680', 'Phoenix', 'daniel.johnson@email.com', '567-890-1234'),
--('Sarah', 'Davis', 'Sarah', 'Davis', '303 Birch St', '11223', 'Philadelphia', '303 Birch St', '11223', 'Philadelphia', 'sarah.davis@email.com', '678-901-2345'), 
--('Chris', 'Martinez', 'Chris', 'Martinez', '404 Cedar St', '33445', 'San Antonio', '404 Cedar St', '33445', 'San Antonio', 'chris.martinez@email.com', '789-012-3456'),
--('Laura', 'Wilson', 'Laura', 'Wilson', '505 Walnut St', '55667', 'San Diego', '505 Walnut St', '55667', 'San Diego', 'laura.wilson@email.com', '890-123-4567'),
--('David', 'Moore', 'David', 'Moore', '606 Aspen St', '77889', 'Dallas', '606 Aspen St', '77889', 'Dallas', 'david.moore@email.com', '901-234-5678'),
--('Anna', 'Taylor', 'Anna', 'Taylor', '707 Cherry St', '99001', 'San Jose', '707 Cherry St', '99001', 'San Jose', 'anna.taylor@email.com', '012-345-6789');
--insert into OrderRows(OrderId,MovieId,Price) values ((select max(Id) from Orders),
--(select Id from Movies where Title='Finding Nemo'),
--(select Price from Movies where Title='Finding Nemo'))
--insert into OrderRows(OrderId,MovieId,Price) values ((select top 1 Id from Orders),
--(select Id from Movies where Title='Tangled'),
--(select Price from Movies where Title='Tangled'))
Truncate table OrderRows
