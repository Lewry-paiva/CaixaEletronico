namespace CaixaEletronico;

internal class Banco
{

    public bool ValidarSenha(string senha, Usuario usuario)
    {
        if (usuario.VerificarSenha(senha))
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
