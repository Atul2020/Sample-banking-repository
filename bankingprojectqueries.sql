create database bankingproj
use bankingproj

create table accountdetails(
 accountnumber int primary key,
 customername varchar(20),
 customeraddress varchar(20),
 currentbalance decimal
)

create table transactiondetails(
transactionid int primary key,
transactiondate Date,
accountnumber int foreign key references accountdetails(accountnumber),
amount decimal,
transactiontype varchar(20)
)
select * from accountdetails;


Go

create procedure viewdetails
as 
select * from accountdetails

viewdetails
update accountdetails set currentbalance+=100 where accountnumber=1146108143

select * from transactiondetails
truncate table transactiondetails
delete from transactiondetails where transactionid=1825327922
select * from transactiondetails where accountnumber=1000000001 order by transactiondate desc;
