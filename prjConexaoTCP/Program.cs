using System.Net.Sockets;
using System.Text;

public class Program
{
    public static async Task Main()
    {
        cInicializacaoHost.StartTCPHostAsync(5554);
        cConexaoCliente.ConnectToServer("localhost", 5554);
        Console.ReadLine();
    }
}
