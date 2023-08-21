using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class Conexao
    {
        const string host = "localhost";
        const string banco = "08_lista_tarefas";
        const string usuario = "root";
        const string senha = "senac";

        //estático faz com que a vrável não seja apagada//
        //mesmo que se crie novas instâncias (new)//
        const string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
        static MySqlConnection conexao = new MySqlConnection(dadosConexao);
       
       
        


      
       
           


        public static DataTable executaQuery(string query)//vai rodar comandos dentro do banco
        {
            try
            {

             conexao.Open();

             MySqlCommand comando = new MySqlCommand(query, conexao);
             MySqlDataReader dados = comando.ExecuteReader();
             DataTable tabela= new DataTable();
             tabela.Load(dados);

                return tabela;
           

            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao realizar consulta:");
                Console.WriteLine(erro.Message);
                return null;
            }
            finally { conexao.Close(); }


           

            
        }
            
    
    

}
    
    

}

