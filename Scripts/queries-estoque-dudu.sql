use dudu_store

create table tb_cliente
(
cliente_id int primary key identity (1,1),
nome varchar(100) not null,
login varchar(50) not null,
senha varchar(20) not null,
tel varchar(11) not null,
ativo bit default(1)
)

create table tb_produto
(
produto_id int primary key identity(1,1),
nome varchar(50) not null,
descricao varchar (100),
preco float not null,
ativo bit default(1)

)

create table tb_fornecedor
(
fornecedor_id int primary key identity (1,1),
cnpj varchar(23) not null,
razao_social varchar(50) not null,
nome_fantasia varchar(50)not null,
telefone varchar(11) not null,
ativo bit default(1)
)

create table tb_pedido
(
pedido_id int primary key identity(1,1),
data date not null,
valor_total money not null,
ativo bit default(1)
)