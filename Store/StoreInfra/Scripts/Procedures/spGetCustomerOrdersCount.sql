CREATE PROCEDURE spGetCustomerOrdersCount AS
    SELECT
        c.[Id],
        CONCAT(c.[FirstName], ' ', c.[LastName]) AS [Name],
        [Document]
    FROM
        [Customer] c
    INNER JOIN [Order] o ON o.[CustomerId] = c.[Id]
