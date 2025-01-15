using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;



internal class cInicializacaoHost
{
    public static void StartTCPHostAsync(int port)
    {
        Task.Run(() =>
        {
            TcpListener server = new TcpListener(IPAddress.Any, port);

            try
            {
                server.Start();

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Task.Run(() =>
                    {
                        HandleClient(client);
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                server.Stop();
            }
        });
    }

    private static void HandleClient(TcpClient client)
    {
        try
        {
            using (NetworkStream stream = client.GetStream())
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8) { AutoFlush = true })
            {
                string command;
                while ((command = reader.ReadLine()) != null)
                {
                    string response = cProcessamentoComandosCliente.ProcessCommand(command);
                    writer.WriteLine(response);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no cliente: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Cliente desconectado.");
            client.Close();
        }
    } 
}

