using System;
using System.Collections.Generic;

namespace api_desafio21dias.ModelViews
{
    public record AdmLoginView
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
