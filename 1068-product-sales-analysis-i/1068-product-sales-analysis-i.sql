# Write your MySQL query statement below
-- Write your PostgreSQL query statement below
SELECT pd.product_name, sl.year, sl.price FROM Sales AS sl INNER JOIN Product AS pd ON sl.product_id = pd.product_id;