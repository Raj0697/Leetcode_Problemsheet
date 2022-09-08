# Write your MySQL query statement below
#select name from Customer where (referee_id != 2 or referee_id is null)

select name from Customer where referee_id NOT IN (2) OR referee_id IS NULL
#SELECT name FROM Customer WHERE referee_id <> 2 OR referee_id IS NULL;