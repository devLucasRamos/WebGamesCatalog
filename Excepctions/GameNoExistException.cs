using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGamesCatalog.Excepctions
{
    public class GameNoExistException : Exception
    {
        public GameNoExistException() : base("Nós não temos esse jogo!!") { }
    }
}
