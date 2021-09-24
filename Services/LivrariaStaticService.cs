using Livraria.Models;
using System;
using Livraria.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Services
{
     
    public class LivrariaStaticService : ILivrosService
    {
        List<Livros> getLivros()
        {
            List<Livros> listaLivros = new List<Livros>();
            listaLivros.Add(new Livros { Id = 1, Nome = "Duna 2", Sinopse = "Uma estonteante mistura de aventura e misticismo, ecologia e política", Autor = "Frank Herbert", Edicao = "1º", Lancamento = 2017 });
            listaLivros.Add(new Livros { Id = 2, Nome = "O Senhor dos Anéis 2", Sinopse = "O volume inicial de O Senhor dos Anéis, lançado originalmente em julho de 1954, foi o primeiro grande épico de fantasia moderno, conquistando milhões de leitores e se tornando o padrão de referência para todas as outras obras do gênero até hoje.", Autor = "J.R.R. Tolkien", Edicao = "6º", Lancamento = 1954 });
            listaLivros.Add(new Livros { Id = 3, Nome = "O Fim da Eternidade 2", Sinopse = "De forma leve e bem-humorada, Asimov realiza questionamentos ainda bastante contemporâneos, como o comodismo do ser humano, sua evolução perante as outras espécies e a busca incessante do controle sobre a vida dos outros. ", Autor = "Isaac Asimov", Edicao = "3º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 4, Nome = "O Fim da Infância 2", Sinopse = "Nos primeiros anos da Guerra Fria, uma raça tecnologicamente superior ao homem desce dos céus para governar a Terra.", Autor = "Arthur C. Clarke", Edicao = "3º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 5, Nome = "Laranja Mecânica 2", Sinopse = "Uma das mais brilhantes sátiras distópicas já escritas, Laranja Mecânica ganhou fama ao ser adaptado em uma obra magistral do cinema pelas mãos de Stanley Kubrick. ", Autor = "Anthony Burgess", Edicao = "1º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 6, Nome = "Admirável mundo novo 2", Sinopse = "Um clássico moderno, o romance distópico de Aldous Huxley é incontornável para quem procura um dos exemplos mais marcantes da tematização de estados autoritários, ao lado de 1984, de George Orwell. ", Autor = " Aldous Leonard Huxley ", Edicao = "3º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 7, Nome = "A revolução dos bichos 2", Sinopse = "Verdadeiro clássico moderno, concebido por um dos mais influentes escritores do século XX, A revolução dos bichos é uma fábula sobre o poder.", Autor = " George Orwell", Edicao = "4º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 8, Nome = "1984 2", Sinopse = "Publicada originalmente em 1949, a distopia futurista 1984 é um dos romances mais influentes do século XX, um inquestionável clássico moderno.", Autor = "George Orwell", Edicao = "3º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 9, Nome = "O conto da aia 2", Sinopse = "O romance distópico O conto da aia, de Margaret Atwood, se passa num futuro muito próximo e tem como cenário uma república onde não existem mais jornais, revistas, livros nem filmes. ", Autor = "Margaret Atwood", Edicao = "6º", Lancamento = 2019 });
            listaLivros.Add(new Livros { Id = 10, Nome = "Eu, Robô 2", Sinopse = "Um dos maiores clássicos da literatura de ficção científica, Eu, Robô, escrito pelo Bom Doutor, Isaac Asimov foi publicado originalmente em 1950.", Autor = "Isaac Asimov", Edicao = "2º", Lancamento = 2014 });
            return listaLivros;
        }

        public List<Livros> getAll(string busca = null, bool ordenacao = false) 
        {
            if (busca != null)
            {
                return getLivros().FindAll(a =>
                    a.Nome.ToLower().Contains(busca.ToLower())
                );
            }

            if (ordenacao)
            {
                var lista = getLivros();
               
                lista = lista.OrderBy(p => p.Nome).ToList();
                return lista;
            }
            return getLivros();
        }
        public bool create(Livros livros)
        {

            try
            {
                List<Livros> livro = getLivros();
                livros.Id =livro.Count() + 1;
                livro.Add(livros);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Livros get(int? id) { return getLivros().FirstOrDefault(p => p.Id == id); }

        public bool update(Livros l) { return false; }

        public bool delete(int? id) { return false; }

        

       
    }
}
