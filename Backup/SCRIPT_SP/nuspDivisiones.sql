create procedure nuspDivisiones @DivID varchar(4)  
as  
Select * from nuDivisiones where DivID like @DivID order by DivID 