using System;

namespace EmailManeger.Models;

public class Email
{
    public int Id { get; set; }
    public string? Assunto { get; set; }
    public string? Remetente { get; set; }
    public string? Destinatario { get; set; }
    public DateTime Data { get; set; }
    public string? CorpoTexto { get; set; }
    public string? ServidorEmail { get; set; }
}