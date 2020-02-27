use [dudu_store]

go

create proc sp_alterar_cliente
	@cliente_id int,
	@nome varchar(100),
	@login varchar(50),
	@senha varchar(20),
	@tel varchar(11)

as
begin
	update 
		tb_cliente 
	set
		nome = @nome, login = @login, senha = @senha, tel = @tel
		where cliente_id = @cliente_id
 end

