using System;

namespace RpaEmailAPI.Models
{
    public class Mensagem
    {
        public int Id { get; set; } 
        public string Assunto { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public DateTime Data { get; set; }
        public string CorpoTexto { get; set; }
    }
}
