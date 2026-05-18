using System;

namespace CaixaEletronico;
internal class Banco
{
    Dictionary<string, Usuario> usuarios = new Dictionary<string, Usuario>();

    public Banco()
    {
        // Criar um usuário de exemplo
        Usuario usuarioExemplo = new Usuario();
        usuarioExemplo.Usuarios("123456", "João", "1", 5000m);
        usuarios.Add(usuarioExemplo.contacorrente, usuarioExemplo);
        
        Usuario usuarioExemplo2 = new Usuario();
        usuarioExemplo2.Usuarios("123458", "Maria", "1", 5000m);
        usuarios.Add(usuarioExemplo2.contacorrente, usuarioExemplo2);

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
        if (valorAsacar <= user.Saldo)
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
        
        Console.WriteLine("digite a conta");
        string contacorrente = Console.ReadLine();
        Console.WriteLine("digite o nome");
        string nome = Console.ReadLine();
        Console.WriteLine("digite a senha");
        string senha = Console.ReadLine();
        Console.WriteLine("Saldo");
        decimal saldo = decimal.Parse(Console.ReadLine());
        
        Usuario novoUsuario = new Usuario();
        novoUsuario.Usuarios(contacorrente, nome, senha, saldo);

        usuarios.Add(novoUsuario.contacorrente, novoUsuario);
    }
    public void ExibirUsuario(string contacorrente)
    {
        usuarios.TryGetValue(contacorrente, out Usuario? user);
        if (user != null)
        {
            Console.WriteLine($"NOME: {user.nome}");
            Console.WriteLine($"SALDO: {user.Saldo}");
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
            if (valorATransferir <= user.Saldo)
            {
                user.Sacar(valorATransferir);
                destinatario.Deposito(valorATransferir);
                Console.WriteLine("Transferência realizada com sucesso!");
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
