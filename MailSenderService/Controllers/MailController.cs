using MailSenderService.Model;
using MailSenderService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MailSenderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }        

        [HttpPost("SendMails")]
        public async Task<IActionResult> SendPdfsByUrl([FromBody] MailRequest request)
        {            
            try
            {
                await _mailService.MailRequestWithPdfUrl(request);
                return Ok("Mail Gönderildi");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}

/*

{
    "ToEmail": [
        "hakan.durmaz@logo.com.tr",
        "durmazhakan@icloud.com"
    ],
    "Subject": "Test Subject",
    "Boy": "Test Body",
    "PdfUrls": [
        "http://localhost:84/Default.aspx?DosyaNo=TLP101",
        "http://localhost:84/Default.aspx?DosyaNo=TLP102"
    ]    
}
 * */