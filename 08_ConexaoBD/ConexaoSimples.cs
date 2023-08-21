using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{
    internal class ConexaoSimples
    {
        // Inforções de conexão com o banco//
        string host = "localhost";
        string banco = "08_lista_tarefas";
        string usuario = "root";
        string senha = "senac";

        // método construtor: ele é chamado automaticamente quando a classe é criada//
                public ConexaoSimples()
        {
            //Usa os dados do banco para se conectat//
            string dadosConexao = $"Server={host};Database={banco};Uid={usuario};Pwd={senha};";
            //cria conexão com o banco usando dados//
            //o banco não se conecta sozinho,ele apenas cria conexão//
            MySqlConnection conexao = new MySqlConnection(dadosConexao);
            //abre conexão com o banco//
            conexao.Open();
            //Linha de código SQL
            string query = "SELECT*FROM tarefas;";
            //Envia um comando para o banco
            MySqlCommand comando = new MySqlCommand(query, conexao);
            //Guarda os dados que vierem do banco dentro de "dados"
            //MySqlDataReader recebe os dados em formato de tabela
            MySqlDataReader dados = comando.ExecuteReader();
            //Roda cada dado da tabela, até a última linha//
            //A última linha vai ser FALSE e quebrar o loopp//
            while (dados.Read() == true)
            {
                Console.WriteLine("Descrição da tarefa: " + dados["descricao"]);
            }
            //;Fecha a conexão do banco//
            conexao.Close();

        }
    }
}
