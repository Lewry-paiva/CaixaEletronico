using System;

namespace CaixaEletronico;
internal class Banco
{
    Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();
    
    public Banco()
    {
        usuarios = Json.CarregarUsuario();
    }
    
    public bool Iniciar(string senha, string contacorrente)
    {
        if (usuarios.TryGetValue(contacorrente, out Usuario? user))
        {
            if (user.VerificarSenha(senha))
            {
                return true;
            }
            return false;
        }
        
        else
        {
            Console.WriteLine("***** SENHA INCORRETA! *****");
            return false;
        }

    }

    public bool VerificarSaque(decimal valorAsacar, string contacorrente)
    {
       usuarios.TryGetValue(contacorrente, out Usuario? user);
        if (valorAsacar <= user.saldo)
        {
            user.Sacar(valorAsacar);
            return true;
        }
        else
        {
            Console.WriteLine("***** SALDO INSUFICIENTE! *****");
            return false;
        }
    }

    public void RealizarDeposito(decimal valorADepositar, string contacorrente)
    {
        usuarios.TryGetValue(contacorrente, out Usuario? user);
        user.Deposito(valorADepositar);
    }

    public void NovoUsuario()
    {
        Usuario novoUsuario = new Usuario();

        Console.WriteLine("digite a conta");
        string contacorrente = Console.ReadLine();
        Console.WriteLine("digite o nome");
        string nome = Console.ReadLine();
        Console.WriteLine("digite a senha");
        string senha = Console.ReadLine();
        novoUsuario.SetSenha(senha);
        Console.WriteLine("Saldo");
        decimal saldo = decimal.Parse(Console.ReadLine());
        
        
        novoUsuario.Usuarios(contacorrente, nome, saldo);

        usuarios.Add(novoUsuario.contacorrente, novoUsuario);

        Json.SalvarUsuario(usuarios);
    }
    public void ExibirUsuario(string contacorrente)
    {
        
        usuarios.TryGetValue(contacorrente, out Usuario? user);
        if (user != null)
        {
            Console.WriteLine($"NOME: {user.nome}");
            Console.WriteLine($"SALDO: {user.saldo:C}");
        }
    }

    public void transferencia(decimal valorATransferir, string contacorrente)
    {
        Console.WriteLine("digite a conta do destinatário");
        string contaDestinatario = Console.ReadLine();

        usuarios.TryGetValue(contacorrente, out Usuario? user);
        usuarios.TryGetValue(contaDestinatario, out Usuario? destinatario);

        if (user != null && destinatario != null)
        {
            if (valorATransferir <= user.saldo)
            {
                user.Sacar(valorATransferir);
                destinatario.Deposito(valorATransferir);
                Console.WriteLine("Transferência realizada com sucesso!");
                Json.SalvarUsuario(usuarios);
            }
            else
            {
                Console.WriteLine("***** SALDO INSUFICIENTE! *****");
            }
        }
        else
        {
            Console.WriteLine("***** CONTA DESTINATÁRIO NÃO ENCONTRADA! *****");
        }
    }

}
