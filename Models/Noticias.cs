using System;
using System.Collections.Generic;
using System.IO;
using Aula37E_Players_AspNETCore.Models;
using E_PLAYERS.Interface;

namespace E_PLAYERS.Models
{
    public class Noticias : EPlayersBase , INoticias 
    {
        
        public int IdNoticia { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Imagem { get; set; }
    
     private const string PATH = "Database/noticias.csv";

        public void Create(Noticias n)
        {
            string[] linha =    { PrepararLinha(n) };
            File.AppendAllLines(PATH, linha);
        }
        private string PrepararLinha(Noticias n){
            return $"{n.IdNoticia};{n.Titulo};{n.Imagem}";
        }   
        public List<Noticias> ReadAll()
        {
           List<Noticias> noticias = new List<Noticias>();
           string[] linhas = File.ReadAllLines(PATH);
           foreach (var item in linhas)
           {
            string[] linha = item.Split(";");
            Noticias noticia = new Noticias();
            noticia.IdNoticia = Int32.Parse(linha[0]);
            noticia.Titulo = linha[1]; 
            noticia.Imagem = linha[2];

            noticias.Add(noticia);
           }
           return noticias;
        }   

        public void Update(Noticias n)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == n.IdNoticia.ToString());
            linhas.Add(PrepararLinha(n) );
            RewriteCSV(PATH,linhas); 
        }

        public void Delete(int id)
        {
            List<string> linhas = ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());
            RewriteCSV(PATH, linhas);
        }
        

    }
}