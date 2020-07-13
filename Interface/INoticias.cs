using System.Collections.Generic;
using E_PLAYERS.Models;


namespace E_PLAYERS.Interface 
{
    public interface INoticias
    {

        void Create(Noticias n);

        List<Noticias> ReadAll();

        void Update(Noticias n);

        void Delete(int id);
         
    }
}