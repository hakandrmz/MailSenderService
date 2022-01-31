using MailSenderService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailSenderService.Services
{
    public interface IMailService
    {             
        Task MailRequestWithPdfUrl(MailRequest mailRequest);
    }
}
