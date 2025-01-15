using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cProcessamentoComandosCliente
{
    public static string ProcessCommand(string command)
    {
        if (command.ToLower() == "ping")
            return "pong";
        return "fracasso";
    }
}

