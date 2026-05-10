using System;
using System.Collections.Generic;
using System.Text;

namespace CaixaEletronico;

internal class Banco
{
    

    public bool ValidarSenha(Usuario usuario, string senha)
        {
            if (senha == usuario.exibirSenha())
            {
                return true;
            }
            else
            {
                Console.WriteLine("***** SENHA INCORRETA! *****");
                return false;
            }
    }
}
