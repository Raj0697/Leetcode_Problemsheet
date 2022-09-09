# Write your MySQL query statement below

select employee_id , 
case
when employee_id %2!=0 and substr(name,1,1)!='m' then salary 
else 0
end as bonus
from Employees order by employee_id;

# select employee_id ,salary bonus from Employees
# where employee_id%2!=0 and name not like 'm%'

# union 
 
 
# select employee_id ,0 bonus from Employees
# where employee_id%2=0 or name  like 'm%'

# order by employee_id;



# select employee_id,salary as bonus
# from Employees  where
# employee_id %2!=0 and substr(name,1,1)!='m' 
 
# union

# select employee_id,0 as bonus
# from  Employees where
# employee_id%2=0 or substr(name,1,1)='m'

# order by employee_id;