using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGamesCatalog.Excepctions
{
    public class GameExistException : Exception
    {
        public GameExistException() : base("Já temos um jogo com o mesmo nome e produtora!!")
        {

        }
    }
}
