using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace CaixaEletronico;
public class Usuario
{
    private string senha_ = "1234";
    private decimal saldo_ = 5000m;
    public string nome = "IURY";

    public decimal Saldo => saldo_;

    public bool VerificarSenha(string senha)
    {
        return senha == senha_;
    }
    
    public string ExibirSaldo()
    {
        string saldoFormatado = saldo_.ToString("C");
        return saldoFormatado;
    }

    public bool Sacar(decimal valor)
    {
        if (Saldo < valor)
        {
            Console.WriteLine("***** SALDO INSUFICIENTE! *****");
            return false;
        }
        else
        {
            saldo_ -= valor;
            return true;
        }
        
    }

    public void Deposito(decimal valor)
    {

        saldo_ += valor;

    }

    

}
