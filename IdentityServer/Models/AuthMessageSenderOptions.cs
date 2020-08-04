using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServer.Models
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; } = "<Your sendrid user>";

        public string SendGridKey { get; set; } =
            "Your Sendgrid api key";
    }
}
