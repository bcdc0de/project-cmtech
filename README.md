# project-cmtech
Código de Leitura de E-mails com API REST

O projeto "Sistema de Leitura de E-mails com API REST" é uma aplicação desenvolvida em C# que se conecta a uma conta de e-mail por meio do protocolo IMAP usando a biblioteca MailKit. A aplicação é projetada para recuperar mensagens de e-mail não lidas de uma caixa de entrada, ler seus detalhes, como assunto, remetente, destinatário, data e corpo do texto, e armazenar esses dados em um banco de dados PostgreSQL.

## Organização das pastas

1. emailManeger: essas pastas contém o projeto da API Rest C# para conectar as principais conta de E-mail (Outlook, Gmail, Yahoo);
2. apirest-email: Teste API Rest desenvolvida em C# que se conecta a uma conta de e-mail;
3. rpa-email: Teste de um RPA (Robot Process Automation) base para o projeto, que se conecta a uma conta de e-mail;
4. table-postgresql: script para criação da table no banco de dados.