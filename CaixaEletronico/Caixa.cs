using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CaixaEletronico;

internal class Caixa
{
    decimal dinheiroNocaixa = 10000m;
    decimal limiteCaixa = 500000m;
    public static void Main()
    {
       IniciarSistema();
    }

    static void IniciarSistema()
    {
        Banco banco = new Banco();
        Usuario usuario = new Usuario();
        Caixa caixa = new Caixa();
        int erro = 0;

        while (erro < 3)
        {
            MostrarMenuInicial();
            string senha = Console.ReadLine();
            if (banco.ValidarSenha(senha, usuario))
            {
                erro = 0;
                int opcao = 0;
                while (opcao != 3)
                {
                    MostrarMenuPrincipal(usuario, caixa);
                    opcao = ValidarOpcao(Console.ReadLine());

                    switch (opcao)
                    {
                        case 1:
                            Console.Write("DIGITE O VALOR DO SAQUE: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal valor_saque))
                            {
                                if (caixa.ValorSaque(valor_saque) != 0 && usuario.Sacar(valor_saque))
                                {
                                    Console.WriteLine("***** SAQUE REALIZADO COM SUCESSO! *****");
                                }
                            }
                            else
                            {
                                Console.WriteLine("***** VALOR INVÁLIDO! *****");
                            }
                            break;

                            case 2:
                                Console.Write("DIGITE O VALOR DO DEPÓSITO: ");
                                if (decimal.TryParse(Console.ReadLine(), out decimal valor_deposito))
                                {
                                    if (caixa.ValorDeposito(valor_deposito))
                                    {
                                        usuario.Deposito(valor_deposito);
                                        Console.WriteLine("***** DEPÓSITO REALIZADO COM SUCESSO! *****");
                                    }              
                                }
                                else
                                {
                                    Console.WriteLine("***** VALOR INVÁLIDO! *****");
                                    
                                }
                            break;
                    }   
                            
                }
                
            }
            else
            {
                Console.WriteLine("***** SENHA INCORRETA! *****");
                Console.WriteLine($"VOCÊ TEM {3 - erro} TENTATIVAS RESTANTES!");
                erro++;
            }
        }
        
    }
   static void MostrarMenuInicial()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("BEM VINDO AO CAIXA ELETRÔNICO!");
        Console.WriteLine("CONTA: 154-85XXX-XX");
        Console.WriteLine("------------------------");
        Console.Write("DIGITE SUA SENHA: ");
    }

    static void MostrarMenuPrincipal(Usuario usuario, Caixa caixa)
    {
        Console.WriteLine("------------------------");
        Console.WriteLine($"NOME: {usuario.nome}");
        Console.WriteLine($"SALDO: {usuario.ExibirSaldo():C}");
        Console.WriteLine($"DINHEIRO NO CAIXA: {caixa.dinheiroNocaixa:C}");
        Console.WriteLine("1 - SACAR");
        Console.WriteLine("2 - DEPOSITAR");
        Console.WriteLine("3 - SAIR");
        Console.WriteLine("------------------------");
        Console.Write("ESCOLHA UMA OPÇÃO: ");
    }

    static int ValidarOpcao(string opcao_ = "0")
    {
       if(int.TryParse(opcao_, out int opcao) && opcao >= 1 && opcao <= 3)
        {
            return opcao;
        }
        else
        {
            Console.WriteLine("***** OPÇÃO INVÁLIDA! POR FAVOR *****");
            return 0;
        }
       
    } 

    public decimal ValorSaque(decimal valor_)
    {
        if (valor_ > dinheiroNocaixa)
        {
            Console.WriteLine("***** VALOR INDISPONÍVEL NO CAIXA! *****");
            return 0;
        }
        else
        {
            dinheiroNocaixa -= valor_;
            return valor_;
        }

    }

    public bool ValorDeposito(decimal valor_) 
    {
        if (valor_ > 0 && valor_ <= limiteCaixa)
        {
            dinheiroNocaixa += valor_;
            return true;
        }
        else
        {
            Console.WriteLine("***** VALOR EXEDENTE AO LIMITE DO CAIXA! *****");
            return false;
        }
    }

}
