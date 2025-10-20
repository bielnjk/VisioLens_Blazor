
use visioLens;

create table cliente (
id_cli int primary key auto_increment,
nome_cli varchar(200),
cpf_cli varchar(20),
telefone_cli varchar(20),
endereco_cli varchar(100),
email_cli varchar(100)
);

create table colaborador (
id_colab int primary key auto_increment,
nome_colab varchar(200),
data_nascimento_colab date,
telefone_colab varchar(20),
email_colab varchar(100),
senha_colab varchar(200)
);


create table tipo_de_sessao (
id_tip_ses int primary key auto_increment,
duracao_tip_ses varchar(200),
preco_padrao_tip_ses varchar(200),
quantidade_fotos_tip_ses varchar(300),
entrega_tip_ses date,
observações_tip_ses varchar(200),
categoria_tip_ses varchar(100)
);

create table orcamento (
id_orc int primary key auto_increment,
pacote_fotos_orc varchar(300),
valor_total_orc varchar(100),
status_orc varchar(200),
forma_pagamento_orc varchar(200),
id_cli_fk int,
id_colab_fk int
);
alter table orcamento add foreign key(id_cli_fk) references cliente(id_cli);
alter table orcamento add foreign key(id_colab_fk) references colaborador(id_colab);
alter table orcamento add id_tip_ses_fk int;
alter table orcamento add foreign key(id_tip_ses_fk) references tipo_de_sessao(id_tip_ses);

create table pacote (
id_pac int primary key auto_increment,
nome_pac varchar(100),
descricao_pac varchar(200),
valor_pac varchar(100),
destinatario_pac varchar(100),
dimensões_pac varchar(200)
);

create table agendamento (
id_agen int primary key auto_increment,
data_agen date,
duracao_agen varchar(100),
observação_agen varchar(200),
id_cli_fk int,
id_tip_ses_fk int,
id_colab_fk int,
foreign key(id_cli_fk) references cliente(id_cli),
foreign key(id_tip_ses_fk) references tipo_de_sessao(id_tip_ses),
foreign key(id_colab_fk) references colaborador(id_colab)
);

create table pagamento (
id_pag int primary key auto_increment,
valor_total_pag varchar(100),
valor_pago_pag varchar(100),
valor_restante_pag varchar(100),
forma_pag varchar(100),
status_pag varchar(100),
id_cli_fk int,
id_colab_fk int,
id_pac_fk int,
foreign key(id_cli_fk) references cliente(id_cli),
foreign key(id_colab_fk) references colaborador(id_colab),
foreign key(id_pac_fk) references pacote(id_pac)
);

--Inserindo dados na tabela cliente
insert into cliente values (null, 'Beatriz de Oliveira', '709.458.698-32', '(69) 99698-4574', 'Rua Andorinha Nº3242 Bairro:JK', 'beatriz123@gmail.com');
insert into cliente values (null, 'Maria Aparecida Pereira', '542.968.458-15', '(69) 99874-6547', 'Rua Castelo Branco Nº4575 Bairro:Riachuelo', 'apaecida523@gmail.com');
insert into cliente values (null, 'Maria Eduarda Silva', '698.745.859-20', '(69) 99236-7852', 'Rua Seis de Maio Nº1230 Bairro:Centro', 'mariaeduarda24@gmail.com');

--Inserindo dados na tabela colaborador
insert into colaborador values (null, 'Jeovana Knoblauch', '2008-07-27', '(69) 99345-6941', 'jeovana254@gmail.com');
insert into colaborador values (null, 'Gabriel Ferreira', '2008-01-18', '(69) 99325-5214', 'ferreira876@gmail.com');
insert into colaborador values (null, 'Thayanne Carvalho', '2008-07-20', '(69) 99233-7485', 'thaycarvalho13@gmail.com');
insert into colaborador values (null, 'Eduarda Nogueira', '2005-09-15', '(69) 99254-7381', 'eduarda234@gmail.com');

--Inserindo dados na tabela tipo de sessão
insert into tipo_de_sessao values (null,'1 hora', '250,00', '15 fotos', '2025-10-15', 'Entrega digital por link', 'Ensaio Individual');
insert into tipo_de_sessao values (null,'2 horas', '400,00', '30 fotos', '2025-10-20', 'Entrega em pendrive', 'Pré-Wedding');
insert into tipo_de_sessao values (null,'3 horas', '600,00', '50 fotos', '2025-10-25', 'Com álbum impresso', 'Aniversário');
insert into tipo_de_sessao values (null,'45 minutos', '180,00', '10 fotos', '2025-10-18', 'Entrega online', 'Corporativo');

--Inserindo dados na tabela orçamento
insert into orcamento values (null, 'Pacote Bronze', '250,00', 'Aprovado', 'Pix', 1, 1, 1);
insert into orcamento values (null, 'Pacote Prata', '400,00', 'Em Análise', 'Cartão de Crédito', 2, 2, 2);
insert into orcamento values (null, 'Pacote Ouro', '600,00', 'Aprovado', 'Dinheiro', 3, 3, 3);
insert into orcamento values (null, 'Pacote Corporativo', '180,00', 'Pendente', 'Transferência', 1, 4, 4);

--Inserindo dados na tabela pacote
insert into pacote values (null, 'Pacote Bronze', '15 fotos digitais em alta resolução', '250,00', 'Cliente', 'Padrão');
insert into pacote values (null, 'Pacote Prata', '30 fotos + pendrive personalizado', '400,00', 'Cliente', 'Personalizado');
insert into pacote values (null, 'Pacote Ouro', '50 fotos + álbum impresso', '600,00', 'Cliente', 'Luxo');
insert into pacote values (null, 'Pacote Corporativo', '10 fotos digitais para uso profissional', '180,00', 'Empresa', 'Compacto');

--Inserindo dados na tabela agendamento
insert into agendamento values (null, '2025-10-15', '1 hora', 'Sessão individual em estúdio', 1, 1, 1);
insert into agendamento values (null, '2025-10-20', '2 horas', 'Sessão de casal ao ar livre', 2, 2, 2);
insert into agendamento values (null, '2025-10-25', '3 horas', 'Cobertura de aniversário', 3, 3, 3);
insert into agendamento values (null, '2025-10-18', '45 minutos', 'Fotos corporativas de equipe', 1, 4, 4);

--Inserindo dados na tabela pagamento
insert into pagamento values (null, '250,00', '250,00', '0,00', 'Pix', 'Pago', 1, 1, 1);
insert into pagamento values (null, '400,00', '200,00', '200,00', 'Cartão de Crédito', 'Parcial', 2, 2, 2);
insert into pagamento values (null, '600,00', '600,00', '0,00', 'Dinheiro', 'Pago', 3, 3, 3);
insert into pagamento values (null, '180,00', '0,00', '180,00', 'Transferência', 'Pendente', 1, 4, 4);
