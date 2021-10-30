using System;

namespace WebGamesCatalog.Excepctions
{
    public class GameExistException : Exception
    {
        public GameExistException() : base("Já temos um jogo com o mesmo nome e produtora!!") { }
    }
}