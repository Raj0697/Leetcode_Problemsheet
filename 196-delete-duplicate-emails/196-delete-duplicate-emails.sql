# Please write a DELETE statement and DO NOT write a SELECT statement.
# Write your MySQL query statement below
# Delete from Person p1 where inner join Person p2
# where p1.id < p2.id and p1.email = p2.email
DELETE P1 FROM Person AS P1 INNER JOIN Person AS P2 ON P2.email = P1.email AND P1.id > P2.id