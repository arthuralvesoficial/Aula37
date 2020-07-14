using System.Collections.Generic;
using E_PLAYERS.Models;

namespace E_PLAYERS.Interface
{
    public interface IEquipe
    {
         void Create(Equipe e);

        List<Equipe> ReadAll();

        void Update(Equipe e);

        void Delete(int id);
    }
}