# Write your MySQL query statement below
select * from patients where conditions LIKE '% diab1%' or conditions LIKE 'diab1_%'