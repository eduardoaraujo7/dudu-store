use [dudu_store]

go

create proc sp_obter_cliente
	@cliente_id int

as
begin
	select
		cliente_id,
		nome,
		login,
		senha,
		tel

	from
		tb_cliente 
		
	where 
		cliente_id = @cliente_id
 end

