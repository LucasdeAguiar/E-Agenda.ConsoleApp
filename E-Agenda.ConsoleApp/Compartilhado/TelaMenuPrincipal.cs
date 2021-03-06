using E_Agenda.ConsoleApp.ModuloTarefa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Agenda.ConsoleApp.Compartilhado;

namespace E_Agenda.ConsoleApp.Compartilhado
{
    public class TelaMenuPrincipal
    {
        private string opcaoSelecionada;

        private const int QUANTIDADE_REGISTROS = 10;

        private Notificador notificador;

        private RepositorioTarefa repositorioTarefa;
        private TelaCadastroTarefa telaCadastroTarefa;

        public TelaMenuPrincipal(Notificador notificador)
        {
            this.notificador = notificador;

            repositorioTarefa = new RepositorioTarefa();
            telaCadastroTarefa = new TelaCadastroTarefa(repositorioTarefa, notificador);


        }

        public string MostrarOpcoes()
        {
            Console.Clear();

            Console.WriteLine("E - Agenda 1.0");

            Console.WriteLine();

            Console.WriteLine("Digite 1 para Cadastrar Tarefas");
            Console.WriteLine("Digite s para sair");

            opcaoSelecionada = Console.ReadLine();

            return opcaoSelecionada;
        }

        public TelaBase obterTela()
        {
            string opcao = MostrarOpcoes();

            TelaBase tela = null;

            switch (opcao)
            {
                case "1":
                    tela = telaCadastroTarefa;
                    break;

            }

            return tela;
        }


    }
}
