using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace CaixaEletronico;
public class Usuario
{
    private string senha= "1234";
    private decimal saldo = 5000m;
    public string nome = "IURY";

    public decimal Saldo => this.saldo;
    public string Senha => this.senha;

    public bool VerificarSenha(string senha)
    {
        return senha == Senha;
    }
    
    public string ExibirSaldo()
    {
        string saldoFormatado = this.saldo.ToString("C");
        return saldoFormatado;
    }

    public void Sacar(decimal valor)
    {   
            this.saldo -= valor;   
    }

    public void Deposito(decimal valor)
    {

        this.saldo += valor;

    }

    

}
