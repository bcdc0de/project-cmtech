using System;
using System.Collections.Generic;
using Npgsql;
using MimeKit;

namespace RpaEmailAPI.Data
{
    public class DatabaseManager
    {
        private readonly string ConnectionString;

        public DatabaseManager(string connectionString)
        {
            ConnectionString = connectionString;
        }
        public void InsertMessages(List<MimeMessage> messages)
        {
            using (var connection = new NpgsqlConnection(ConnectionString))
            {
                connection.Open();

                foreach (var message in messages)
                {
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = connection;
                        cmd.CommandText = "INSERT INTO mensagens (assunto, remetente, destinatario, data, corpo_texto) VALUES (@assunto, @remetente, @destinatario, @data, @corpo_texto)";
                        cmd.Parameters.AddWithValue("assunto", message.Subject);
                        cmd.Parameters.AddWithValue("remetente", message.From.ToString());
                        cmd.Parameters.AddWithValue("destinatario", message.To.ToString());
                        cmd.Parameters.AddWithValue("data", message.Date);
                        cmd.Parameters.AddWithValue("corpo_texto", message.TextBody);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}