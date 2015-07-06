using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace Remoting
{
    public class RemoteObject : MarshalByRefObject
    {
        //construtor
        public RemoteObject()
        {
            Console.WriteLine("Objeto remoto ativado.");
        }

        //retorno da mensagem de resposta
        public String ReplyMessage(String msg)
        {
            Console.WriteLine("Cliente : " + msg);
            return "Servidor : On-line";
        }
    }   
}
