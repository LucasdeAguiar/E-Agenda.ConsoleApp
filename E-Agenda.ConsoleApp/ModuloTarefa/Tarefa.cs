using E_Agenda.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Agenda.ConsoleApp.ModuloTarefa
{
    public class Tarefa : EntidadeBase
    {
       

        private string titulo;
        private int prioridade;
        private DateTime dataCriacao;
        private DateTime dataConclusao;
        private List<Item> itens;

        public Tarefa(string titulo, int prioridade, DateTime dataCriacao)
        {
            this.titulo = titulo;
            this.prioridade = prioridade;
            this.dataCriacao = dataCriacao;
            
         
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public int Prioridade { get => prioridade; set => prioridade = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public DateTime DataConclusao { get => dataConclusao; set => dataConclusao = value; }
        public List<Item> Itens { get => itens; set => itens = value; }
        
        public void registraItem(string descricao)
        {
          Item item = new Item();
            item.descricao = descricao;
            item.pendente = true;
            Itens.Add(item);
        }





        public override void mostraEntidade()
        {
            Console.WriteLine("Título: " + Titulo);
            Console.WriteLine("Prioridade: " + Prioridade);
            Console.WriteLine("Data de criação: " + DataCriacao);
            Console.WriteLine("Data de conclusão: " + DataCriacao);
            mostrarItens();
        }

        public void mostrarItens()
        {
            for (int i = 0; i < Itens.Count; i++)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Descrição: " + Itens[i].descricao);
                Console.WriteLine("Está pendente? " + Itens[i].pendente);
                Console.WriteLine("-------------------------------------");
            }

        }

        

    }
}
