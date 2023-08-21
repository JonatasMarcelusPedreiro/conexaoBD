using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ConexaoBD
{

   
    internal class Tarefa
    {
        public int id;
        public string descricao;
        public bool concluido;
        public string criado_em;


        public Tarefa() 
        { 
        
        
        
        }


      public Tarefa(int id, string descricao, bool concluido, string criado_em )
        {
            
            this.id = id;
            this .descricao = descricao;    
            this.concluido = concluido;
            this.criado_em= criado_em;

        }

        public List <Tarefa> buscatodos()
        {

            string query = "SELECT * FROM tarefas;";

            DataTable tabela = Conexao.executaQuery(query);

            List<Tarefa> tarefas = new List<Tarefa>();

            // Para cada LINHA dentro de tabela.Rows
            //Ele guarda na variável linha o valor do loop atual dentro da tabela
            foreach (DataRow linha in tabela.Rows)
            {

                Tarefa tarefa = carregarDados(linha);
                tarefas.Add(tarefa);
                
            }

            return tarefas;

            
        }

        public void Insere(Tarefa tarefa)
        {
            int concluido = tarefa.concluido == true ? 1 : 0;   
            string query = $"INSERT INTO tarefas (descricao, concluido) VALUES ( '{tarefa.descricao} )' , {concluido} ";
            Conexao.executaQuery(query);

        }
        public Tarefa BuscaPorID(int id)
        {

            string query = $"SELECT * from tarefas WHERE id = {id} ";

           DataTable tabela =  Conexao.executaQuery(query);

            Tarefa tarefa = carregarDados(tabela.Rows[0]);
            
            
            return tarefa;




        } public Tarefa BuscaPorDescricao(string descricao)
        {

            string query = $"SELECT * from tarefas WHERE descricao LIKE   '%{descricao}%' ";

           DataTable tabela =  Conexao.executaQuery(query);

            Tarefa tarefa = carregarDados(tabela.Rows[0]);
            
            
            return tarefa;




        }

        //Recebe a linha de uma tabela e retorna ela no formato de classe
        public Tarefa  carregarDados( DataRow linha)
        {

            int id = int.Parse( linha["id"].ToString() );

            string descricao = linha["descricao"].ToString();
            bool concluido = linha["concluido"].ToString() == "1"? true : false;
            string criado_em = linha["criado_em"].ToString();

            Tarefa tarefa = new Tarefa();
            return tarefa;
        }

        

    }

}
