# Write your MySQL query statement below
select contest_id, round(count(distinct u.user_id )*100.0 / (select count(*)  from Users )  ,2)  as percentage
from Users u
left join Register r
on u.user_id=r.user_id 
where r.contest_id is not null
group by r.contest_id
order by percentage DESC, r.contest_id ASC;