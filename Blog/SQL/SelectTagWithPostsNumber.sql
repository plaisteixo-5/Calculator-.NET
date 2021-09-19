SELECT
    [Tag].[Id],
    [Tag].[Name],
    [Tag].[Slug],
    
    COUNT([Post].[Id]) AS [Posts]
FROM
    [Tag]
INNER JOIN [PostTag] ON [PostTag].[TagId] = [Tag].[Id]
INNER JOIN [Post] ON [PostTag].[PostId] = [Post].[Id]
GROUP BY
    [Tag].[Id],
    [Tag].[Name],
    [Tag].[Slug]