using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apresentação
{
    class PessoaGenerica
    {
        public void FuncaoGenerica<T>(int inteiro, T generico)
        {
            Console.WriteLine("{0}: seu Tipo e: {1} || {2} :Seu tipo e :{3}", inteiro , inteiro.GetType() , generico, generico.GetType() );
        }
    }
}
