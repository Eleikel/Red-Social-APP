﻿using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using Red_Social.Core.Application.Dtos.Email;
using Red_Social.Core.Application.Interfaces.Services;
using Red_Social.Core.Domain.Settings;
using System;
using System.Threading.Tasks;
using MailKit.Security;

namespace Red_Social.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {

        private MailSettings _mailSettings { get; }
        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                MimeMessage email = new();
                email.Sender = MailboxAddress.Parse(_mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                BodyBuilder builder = new();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();

                //Config the email sender
                using SmtpClient smtp = new();
                smtp.ServerCertificateValidationCallback = (s, c, h, e) => true; //Saltar o Omitir la validacion SSL
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
