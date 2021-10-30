using System;

namespace WebGamesCatalog.Excepctions
{
    public class GameNoExistException : Exception
    {
        public GameNoExistException() : base("Nós não temos esse jogo!!") { }
    }
}