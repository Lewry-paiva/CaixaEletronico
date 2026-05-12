namespace CaixaEletronico;

internal class Banco
{

    public bool Iniciar(string senha, Usuario usuario)
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

    public bool VerificarSaque(decimal valorAsacar, Usuario usuario)
    {
        if(valorAsacar <= usuario.Saldo)
        {
            usuario.Sacar(valorAsacar);
            return true;
        }
        else
        {
            Console.WriteLine("***** SALDO INSUFICIENTE! *****");
            return false;
        }
    }

    public void RealizarDeposito(decimal valorADepositar, Usuario usuario)
    {
        usuario.Deposito(valorADepositar);
    }

}
