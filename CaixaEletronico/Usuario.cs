namespace CaixaEletronico;
public class Usuario
{
    public string contacorrente;
    private string senha;
    private decimal saldo;
    public string nome;

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

    public void Usuarios(string contacorrente, string nome, string senha, decimal saldo)
    {
        this.contacorrente = contacorrente;
        this.nome = nome;
        this.senha = senha;
        this.saldo = saldo;
    }

}
