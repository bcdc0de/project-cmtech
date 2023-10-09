# project-cmtech
Código de Leitura de E-mails com API REST

O projeto "Sistema de Leitura de E-mails com API REST é uma aplicação desenvolvida em C# que se conecta a uma conta de e-mail por meio do protocolo IMAP usando a biblioteca MailKit. A aplicação é projetada para recuperar mensagens de e-mail não lidas de uma caixa de entrada, ler seus detalhes, como assunto, remetente, destinatário, data e corpo do texto, e armazenar esses dados em um banco de dados PostgreSQL.

## Organização das pastas

1. apirest-email: essa pasta é o projeto da API Rest desenvolvida em C# que se conecta a uma conta de e-mail;
2. rpa-email: RPA (Robot Process Automation) base para o projeto, que se conecta a uma conta de e-mail;
3. table-postgresql: script para criação da table no banco de dados.

Para execução escolha uma das pastas (apirest-email, rpa-email) e rode o script (table-postgresql) em sua base.

## apirest-email

1. Criar projeto dotnet: dotnet new webapi -n RpaEmailAPI;
2. 

## rpa-email

1. Criar projeto dotnet;
2. Instalação das bibliotecas MailKit e Npgsql.

## table-postgresql

1. Criar database;
2. Criar table com o script da página.