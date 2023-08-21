using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class ConexaoSegura
    {
        string host = "localhost";
        string banco = "08_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        //estático faz com que a vrável não seja apagada//
        //mesmo que se crie novas instâncias (new)//
        static MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataReader dados;


        public ConexaoSegura() //Método construtor:iniciar a classe e criar conexão
        {
            //Só cria a primeira conexão, que será nula//
            if( conexao == null)
            {
             string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
             conexao = new MySqlConnection(dadosConexao);

            }


        }
        public void executaQuery(string query)//vai rodar comandos dentro do banco
        {
            try
            {



            }
            catch (Exception erro)
            {
                Console.WriteLine("Erro ao realizar consulta:");
                Console.WriteLine(erro.Message);
            }
            finally
            {
                conexao.Close();
            }


            conexao.Open();


             comando = new MySqlCommand(query, conexao);
             dados = comando.ExecuteReader();

            Console.WriteLine("-------------------------------");
            if( dados.HasRows== false ) 
            {
                Console.WriteLine("Nenhum resultado encontrado D:");
            
            }
            //Se tirar a comparação, automaticamente ele compara a TRUE//
            while (dados.Read() )
            {
                Console.WriteLine("Descrição da tarefa: " + dados["descricao"]);
            }
            conexao.Close();
        }
    

}
    
    

}

