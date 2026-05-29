using System.Text.Json.Serialization;

namespace CaixaEletronico;
public class Usuario
{
    
    public string contacorrente;
    [JsonInclude] public string senha { get; private set; }
    [JsonInclude] public decimal saldo { get; private set; }
    public string nome;

    public void SetSenha(string senha)
    {
        if (string.IsNullOrWhiteSpace(senha))
        {
            throw new ArgumentException("senha invalida");
        }
        
        this.senha = senha;
    }
    

    public bool VerificarSenha(string senha)
    {
        return senha == this.senha;
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

    public void Usuarios(string contacorrente, string nome, decimal saldo)
    {
        this.contacorrente = contacorrente;
        this.nome = nome;
        this.saldo = saldo;
    }

}
