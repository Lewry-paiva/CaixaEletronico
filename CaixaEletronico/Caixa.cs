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
        Caixa caixa = new Caixa();

        int erro = 0;
        int opcao = 0;

        while (erro <= 3)
        {

            MostrarMenuInicial();
            Console.WriteLine("1 - ENTRAR");
            Console.WriteLine("2 - CRIAR CONTA");
            Console.WriteLine("------------------------");
            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    MostrarMenuInicial();
                    Console.Write("CONTA CORRENTE: ");
                    string contacorrente = Console.ReadLine();
                    Console.Write("SENHA: ");
                    string senha = Console.ReadLine();


                    if (banco.Iniciar(senha, contacorrente))
                    {
                        erro = 0;

                        while (opcao != 4)
                        {
                            Console.Clear();
                            MostrarMenuPrincipal(banco, caixa, contacorrente);
                            opcao = ValidarOpcao(Console.ReadLine());

                            switch (opcao)
                            {
                                case 1:
                                    Console.Write("DIGITE O VALOR DO SAQUE: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal valor_saque))
                                    {
                                        if (caixa.Saque(valor_saque, banco, contacorrente))
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
                                            banco.RealizarDeposito(valor_deposito, contacorrente);
                                            Console.WriteLine("***** DEPÓSITO REALIZADO COM SUCESSO! *****");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("***** VALOR INVÁLIDO! *****");
                                    }
                                    break;
                                case 3:
                                    Console.Write("DIGITE O VALOR DA TRANSFERÊNCIA: ");
                                    if (decimal.TryParse(Console.ReadLine(), out decimal valor_transferencia))
                                    {
                                        banco.transferencia(valor_transferencia, contacorrente);
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
                        Console.Clear();
                        Console.WriteLine("***** SENHA INCORRETA! *****");
                        Console.WriteLine($"VOCÊ TEM {4 - erro} TENTATIVAS RESTANTES!");
                        erro++;
                    }
                    break;
                case 2:
                    banco.NovoUsuario();

                    break; 
            }
            
        }
        
    }
   static void MostrarMenuInicial()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("CAIXA ELETRÔNICO!");
        Console.WriteLine("------------------------");
        
    }

    static void MostrarMenuPrincipal(Banco banco, Caixa caixa, string contacorrente)
    {
        Console.WriteLine("------------------------");
        banco.ExibirUsuario(contacorrente);
        Console.WriteLine($"DINHEIRO NO CAIXA: {caixa.dinheiroNocaixa:C}");
        Console.WriteLine("1 - SACAR");
        Console.WriteLine("2 - DEPOSITAR");
        Console.WriteLine("3 - TRANSFERIR");
        Console.WriteLine("4 - SAIR");
        Console.WriteLine("------------------------");
        Console.Write("ESCOLHA UMA OPÇÃO: ");
    }

    static int ValidarOpcao(string opcao_ = "0")
    {
       if(int.TryParse(opcao_, out int opcao) && opcao >= 1 && opcao <= 4)
        {
            return opcao;
        }
        else
        {
            Console.WriteLine("***** OPÇÃO INVÁLIDA! POR FAVOR *****");
            return 0;
        }
       
    } 

    public bool Saque(decimal valor_, Banco banco,string contacorrente)
    {
        if (valor_ > dinheiroNocaixa)
        {
            Console.WriteLine("***** VALOR INDISPONÍVEL NO CAIXA! *****");
            return false;
        }
        else if(banco.VerificarSaque(valor_, contacorrente))
        {
            dinheiroNocaixa -= valor_;
            return true;
        }
        return false;
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
