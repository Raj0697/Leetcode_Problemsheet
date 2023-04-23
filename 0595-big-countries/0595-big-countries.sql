/* Write your T-SQL query statement below */
--select name, population, area from World where area >= 3000000 or population >= 25000000

SELECT name, population, area
 FROM World
 Where (area >= 3000000 ) 
 
 UNION

 SELECT name, population, area
 FROM World
 Where (population >=25000000);