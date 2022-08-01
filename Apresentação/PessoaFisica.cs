using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apresentação
{
    class PessoaFisica : Pessoa
    {
        public int Cpf { get; set; }
        public PessoaFisica(string? nome, int Cpf) : base(nome)
        {
            this.Cpf = Cpf;
        }
        
        public override string ToString()
        {
            return "Nome: " + Nome + "  Idade: " + Cpf;
        }
    }
}
