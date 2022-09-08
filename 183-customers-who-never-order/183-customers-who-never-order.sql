# Write your MySQL query statement below
# select name from Customers where Customers.id not in(Orders.customerId)
# select name as customers
# from Customers a
# where not exists (
#     select id 
#     from Orders 
#     where customerId = a.id
# )
select name as customers from Customers c where not exists (select id from Orders where customerId = c.id)