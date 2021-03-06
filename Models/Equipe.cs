using System;
using System.Collections.Generic;
using System.IO;
using E_PLAYERS.Models;
using E_PLAYERS.Interface;

namespace E_PLAYERS.Models
{
    public class Equipe : EPlayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }    
        public string Imagem { get; set; }

        private const string PATH = "Database/equipe.csv";
        public Equipe(){
            CreateFolderAndFile(PATH);
        }
        /// <summary>
        /// Preparar Linha
        /// </summary>
        /// <param name="e">Equipe</param>
        /// <returns>Retorna a Linha no arquivo csv</returns>
        private string PrepararLinha(Equipe e){
            return $"{e.IdEquipe};{e.Nome};{e.Imagem}";
        }
        
        /// <summary>
        /// Adiciona
        /// </summary>
        /// <param name="e">Equipe</param>
        public void Create(Equipe e){
            string[] linha = {PrepararLinha(e)};
            File.AppendAllLines(PATH, linha);
        }

        public void Delete(int idEquipe){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(';')[0] == IdEquipe.ToString());
            RewriteCSV(PATH, linhas);
        }

        public List<Equipe> ReadAll(){
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");
                Equipe equipe = new Equipe();
                equipe.IdEquipe = Int32.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }
            return equipes;
        }

        public void Update(Equipe e){
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(';')[0] == IdEquipe.ToString());
            linhas.Add(PrepararLinha(e));
            RewriteCSV(PATH, linhas);
        }
    }
}