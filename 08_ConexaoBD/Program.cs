
using _08_ConexaoBD;
using System.Data;

//ConexaoSegura conexaoSegura = new ConexaoSegura();
//conexaoSegura.executaQuery("SELECT * FROM tarefas;");

//conexaoSegura.executaQuery("SELECT * FROM tarefas WHERE id=4;");
//conexaoSegura.executaQuery("SELECT * FROM tarefas WHERE descricao LIKE '%tud%'; ");



//Tarefa tarefa = new Tarefa();
//tarefa = tarefa.BuscaPorID(3);

//Console.WriteLine($"Tarefa {tarefa.id} - {tarefa.descricao}");
//Console.WriteLine($"criado_em {tarefa.criado_em} ");

Tarefa tarefa= new Tarefa();

Console.WriteLine("Seja bem-vindo ao sistema do Conradito Consultinhas");

List<Tarefa> tarefas = tarefa.buscatodos();
foreach( Tarefa t in tarefas)
{

    Console.WriteLine($"Tarefa {t.id} - {t.descricao} | criado em{t.criado_em}");
}

Console.WriteLine(" Digite 1 para consultar o ID ou 2 para consultar DESCRICAO");

string opcao = Console.ReadLine();


if(opcao == "3")
{


    Console.WriteLine("\n Bem-vindo ao cadastro de tarefas!\n");
    Console.WriteLine("Digite a descrição da tarefa:");
    string descricao = Console.ReadLine();

    Console.WriteLine("Tarefa concluida? Digite 1 para sim ou 2 para não");
    bool concluido = Console.ReadLine() == "1";

    Tarefa t = new Tarefa();
    t.descricao = descricao;
    t.concluido= concluido;

    tarefa.Insere( t );

}

/*
if (opcao == "1")

{
    Console.WriteLine("Digite o ID do usuário que deseja consultar:");

    int id = int.Parse(Console.ReadLine());
    
    tarefa = tarefa.BuscaPorID(id);


 Console.WriteLine("\nRsultados encontrados:");

 Console.WriteLine($"Tarefa {tarefa.id}- {tarefa.descricao}");
 Console.WriteLine($"| criado em {tarefa.criado_em}");



}

else
{

 Console.WriteLine(" Digite a DESCRIÇÃO que deseja encontrar:");
 string descricao = Console.ReadLine();
  tarefa = tarefa.BuscaPorDescricao(descricao);


}



Console.ReadKey();
/*