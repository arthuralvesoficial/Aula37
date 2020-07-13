using System.Collections.Generic;
using Aula37E_Players_AspNETCore.Models;

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