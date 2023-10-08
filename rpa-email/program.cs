using System;
using System.Collections.Generic;
using System.IO;
using MimeKit;
using RpaEmail;


var email = new Email(iMAP_HOST: "outlook.office365.com", iMAP_USER: "rs_teste@outlook.com", iMAP_PASSWORD: ENV.PASSWORD);
await email.Connect();

var messages = email.GetMessages();

var connectionString = "Host=localhost;Port=5432;Database=received-email;Username=postgres;Password=123456;";
var databaseManager = new DatabaseManager(connectionString);

databaseManager.InsertMessages(messages);

Console.WriteLine("Mensagens inseridas no banco de dados com sucesso.");
