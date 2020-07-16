using System.Collections.Generic;
using System.IO;

namespace E_PLAYERS.Models
{
 public class EPlayersBase
    {
        /// <summary>
        /// Cria o arquivo csv e o diretório
        /// </summary>
        /// <param name="_path">Caminho onde é criado o arquivo csv e a pasta.</param>
        public void CreateFolderAndFile(string _path){

            string folder = _path.Split("/")[0]; 

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
            }
        }
        /// <summary>
        /// lê o arquivo para fazer as alterações
        /// </summary>
        /// <param name="PATH">caminho do arquivo para leitura</param>
        /// <returns>Conteúdo</returns>
        public List<string> ReadAllLinesCSV(string PATH){

            List<string> linhas = new List<string>();
            using (StreamReader file = new StreamReader(PATH)){
                string linha;
                while ((linha = file.ReadLine()) != null){
                    linhas.Add(linha);
                }
            }
            return linhas;
        }
        /// <summary>
        /// Altera ou apaga conteudo do arquivo
        /// </summary>
        /// <param name="PATH">Caminho</param>
        /// <param name="linhas">Linhas </param>
        public void RewriteCSV(string PATH, List<string> linhas){
            using (StreamWriter output = new StreamWriter(PATH)){
                foreach (var item in linhas){
                    output.Write(item + "\n");
                }
            }
        }
    }
}