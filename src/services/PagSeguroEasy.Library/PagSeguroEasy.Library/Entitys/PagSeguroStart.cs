
using PagSeguroEasy.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace Payments.PagSeguro.Entities
{
    public class PagSeguroStart
    {
        protected PagSeguroStart() { }
        public PagSeguroStart(string email, string token)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException("O E-mail não pode ser nulo ou vazio");
            }

            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("O token nao pode ser nulo ou vazio.");
            }

            EMail = new Email(email);
            Token = token;
        }
        public Email EMail { get; private set; }
        public string Token { get; private set; }
       
    }
}
