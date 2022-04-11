using E_Agenda.ConsoleApp.Compartilhado;
using E_Agenda.ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class TelaCadastroTarefa : TelaBase , ICadastroBasico
    {
        private readonly Notificador notificador;
        private readonly RepositorioTarefa repositorioTarefa;


        public TelaCadastroTarefa(RepositorioTarefa repositorioTarefa, Notificador notificador) : base("Cadastro de Tarefas")
        {
            this.repositorioTarefa = repositorioTarefa;
            this.notificador = notificador;
        }



        public override string MostrarOpcoes()
        {
            MostrarTitulo(Titulo);


            Console.WriteLine("Digite 1 para Inserir");
            Console.WriteLine("Digite 2 para Editar");
            Console.WriteLine("Digite 3 para Excluir");
            Console.WriteLine("Digite 4 para Visualizar");


            Console.WriteLine("Digite s para sair");

            string opcao = Console.ReadLine();

            return opcao;


        }

        
        public void InserirRegistro()
        {
            MostrarTitulo("Inserindo nova Tarefa");
            Tarefa tarefa = obterTarefa();

            repositorioTarefa.Inserir(tarefa);


        }
        
        public void EditarRegistro()
        {
            MostrarTitulo("Editando Tarefa");

            int numeroTarefa = ObterNumeroTarefa();

            Tarefa tarefaAtualizada = obterTarefa();

            repositorioTarefa.Editar(numeroTarefa, tarefaAtualizada);

            notificador.apresentarMensagem("Tarefa editada com sucesso", TipoMensagem.Sucesso);

        }

        public void ExcluirRegistro()
        {
            MostrarTitulo("Excluindo Tarefa");

            bool temTarefasCadastradas = VisualizarRegistros("Pesquisando:");

            if (temTarefasCadastradas == false)
            {
                notificador.apresentarMensagem("Nenhuma tarefa cadastrada..", TipoMensagem.Atencao);
                return;
            }

            int numeroTarefa = ObterNumeroTarefa();

            repositorioTarefa.Excluir(numeroTarefa);

            notificador.apresentarMensagem("Carro excluído com sucesso", TipoMensagem.Sucesso);

        }

         public bool VisualizarRegistros(string tipo)
        {
            if (tipo == "Tela")
                MostrarTitulo("Visualização de Tarefas");

            List<EntidadeBase> tarefas = repositorioTarefa.SelecionarTodos();

            if (tarefas.Count == 0)
                return false;
            
            for (int i = 0; i < tarefas.Count; i++)
            {
                Tarefa tarefa = (Tarefa)tarefas[i];

                Console.WriteLine("Título: " + tarefa.Titulo);
                Console.WriteLine("Prioridade: " + tarefa.Prioridade);
                Console.WriteLine("Data de Criação: " + tarefa.DataCriacao);
                Console.WriteLine("Data de Conclusão: " + tarefa.DataConclusao);
                tarefa.mostrarItens();
                Console.WriteLine("\n");
                
            }
            Console.ReadLine();
            return true;
        }


        private Tarefa obterTarefa()
        {
            Console.WriteLine("Digite o título da tarefa:");
            string titulo = Console.ReadLine();
            Console.WriteLine("Digite o grau de prioridade da tarefa: (1 - Baixa),(2 - Normal),(3 - Alta)");
            int prioridade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite a data de criação da tarefa: ");
            DateTime dataCriacao = Convert.ToDateTime(Console.ReadLine());


            Tarefa t = new Tarefa(titulo, prioridade , dataCriacao);

            Console.WriteLine("Digite a quantidade de itens que terá a tarefa");
             int qtItens = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < qtItens; i++)
            {
                Console.WriteLine("Digite a descrição do item:");
                 string itemDescricao = Console.ReadLine();

              t.registraItem(itemDescricao);

            }
 

            return t;
        }

        private int ObterNumeroTarefa()
        {
            int numeroTarefa;
            bool numeroTarefaEncontrado;

            do
            {
                List<EntidadeBase> tarefas = repositorioTarefa.SelecionarTodos();




                for (int i = 0; i < tarefas.Count; i++)
                {
                    Tarefa tarefa = (Tarefa)tarefas[i];

                    Console.WriteLine("Número: " + tarefa.numero);
                    Console.WriteLine("Título: " + tarefa.Titulo);
                    Console.WriteLine("Data de criação: " + tarefa.DataCriacao);
                    Console.WriteLine("Data de conclusão: " + tarefa.DataConclusao);
                    tarefa.mostrarItens();
                 
                    Console.WriteLine("\n");

                }

                Console.Write("Digite o número do carro que deseja selecionar: ");
                numeroTarefa = Convert.ToInt32(Console.ReadLine());

                numeroTarefaEncontrado = repositorioTarefa.ExisteRegistro(numeroTarefa);

                if (numeroTarefaEncontrado == false)
                    notificador.apresentarMensagem("Número da tarefa não encontrado, tente novamente..", TipoMensagem.Atencao);

            } while (numeroTarefaEncontrado == false);

            return numeroTarefa;
        }
    }
}
