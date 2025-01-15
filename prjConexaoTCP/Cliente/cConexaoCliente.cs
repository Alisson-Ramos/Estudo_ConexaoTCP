using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

public class cConexaoCliente
{

    public static async void ConnectToServer(string maquina, int porta)
    {
        try
        {
            using var clienteTCP = new TcpClient();
            await clienteTCP.ConnectAsync(maquina, porta);
            using var stream = clienteTCP.GetStream();
            using var reader = new StreamReader(stream, Encoding.UTF8);
            using var writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true };
            
            writer.WriteLine("ping");
            string response = await reader.ReadLineAsync();

            Console.WriteLine($"Resposta do servidor para {maquina}: {response}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao conectar com {maquina}: {ex.Message}");
        }
    }
}
