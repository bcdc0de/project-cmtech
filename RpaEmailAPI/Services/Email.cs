using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using MimeKit;

namespace RpaEmailAPI.Services
{
    public class Email
    {
        public ImapClient ImapClient { get; private set; }
        public string IMAP_HOST { get; private set; }
        public string IMAP_USER { get; private set; }
        public string IMAP_PASSWORD { get; private set; }

        private const int IMAP_PORTA = 993;

        public Email(string iMAP_HOST, string iMAP_USER, string iMAP_PASSWORD)
        {
            IMAP_HOST = iMAP_HOST;
            IMAP_USER = iMAP_USER;
            IMAP_PASSWORD = iMAP_PASSWORD;
            ImapClient = new ImapClient();
        }

        public async Task Connect()
        {
            if (!ImapClient.IsConnected)
                await ImapClient.ConnectAsync(IMAP_HOST, IMAP_PORTA, SecureSocketOptions.SslOnConnect);

            if (!ImapClient.IsAuthenticated)
            {
                await ImapClient.AuthenticateAsync(IMAP_USER, IMAP_PASSWORD);

                await ImapClient.Inbox.OpenAsync(FolderAccess.ReadWrite);
            }
        }

        public List<MimeMessage> GetMessages()
        {
            var messages = new List<MimeMessage>();
            var messageNotRead = ImapClient.Inbox.Search(MailKit.Search.SearchQuery.NotSeen);
            foreach (var uuid in messageNotRead)
            {
                var message = ImapClient.Inbox.GetMessage(uuid);
                messages.Add(message);
                ImapClient.Inbox.AddFlags(uuid, MessageFlags.Seen, true);
            }

            return messages;
        }

    }
}