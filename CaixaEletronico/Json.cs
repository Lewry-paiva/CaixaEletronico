using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;
using System.Text.Json;

namespace CaixaEletronico;

internal class Json
{
    
    public static JsonSerializerOptions options = new JsonSerializerOptions{WriteIndented = true, IncludeFields = true };
    public static void SalvarUsuario(Dictionary<string, Usuario> usuario)
    {
        string jsonString = JsonSerializer.Serialize(usuario, options);
        File.WriteAllText("usuario.json", jsonString);
    }

    public static Dictionary<string, Usuario> CarregarUsuario()
    {

        if (File.Exists("usuario.json"))
        {
            string jsonString = File.ReadAllText("usuario.json");
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                return JsonSerializer.Deserialize<Dictionary<string, Usuario>>(jsonString, options);
            }
        }
        return new Dictionary<string, Usuario>();

    }
}
