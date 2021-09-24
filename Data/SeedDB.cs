using Livraria.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Livraria.Data
{
    public static class SeedDB
    {
        public static void Initialize(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<LivrariaContext>();
                context.Database.Migrate();

                if (!context.livros.Any())
                {
                   context.livros.Add(new Livros {Nome = "Duna", Sinopse = "Uma estonteante mistura de aventura e misticismo, ecologia e política", Autor = "Frank Herbert", Edicao = "1º", Lancamento = 2017 });
                    context.livros.Add(new Livros {Nome = "O Senhor dos Anéis", Sinopse = "O volume inicial de O Senhor dos Anéis, lançado originalmente em julho de 1954, foi o primeiro grande épico de fantasia moderno, conquistando milhões de leitores e se tornando o padrão de referência para todas as outras obras do gênero até hoje.", Autor = "J.R.R. Tolkien", Edicao = "6º", Lancamento = 1954 });
                    context.livros.Add(new Livros {Nome = "O Fim da Eternidade", Sinopse = "De forma leve e bem-humorada, Asimov realiza questionamentos ainda bastante contemporâneos, como o comodismo do ser humano, sua evolução perante as outras espécies e a busca incessante do controle sobre a vida dos outros. ", Autor = "Isaac Asimov", Edicao = "3º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "O Fim da Infância", Sinopse = "Nos primeiros anos da Guerra Fria, uma raça tecnologicamente superior ao homem desce dos céus para governar a Terra.", Autor = "Arthur C. Clarke", Edicao = "3º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "Laranja Mecânica", Sinopse = "Uma das mais brilhantes sátiras distópicas já escritas, Laranja Mecânica ganhou fama ao ser adaptado em uma obra magistral do cinema pelas mãos de Stanley Kubrick. ", Autor = "Anthony Burgess", Edicao = "1º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "Admirável mundo novo", Sinopse = "Um clássico moderno, o romance distópico de Aldous Huxley é incontornável para quem procura um dos exemplos mais marcantes da tematização de estados autoritários, ao lado de 1984, de George Orwell. ", Autor = " Aldous Leonard Huxley ", Edicao = "3º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "A revolução dos bichos", Sinopse = "Verdadeiro clássico moderno, concebido por um dos mais influentes escritores do século XX, A revolução dos bichos é uma fábula sobre o poder.", Autor = " George Orwell", Edicao = "4º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "1984", Sinopse = "Publicada originalmente em 1949, a distopia futurista 1984 é um dos romances mais influentes do século XX, um inquestionável clássico moderno.", Autor = "George Orwell", Edicao = "3º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "O conto da aia", Sinopse = "O romance distópico O conto da aia, de Margaret Atwood, se passa num futuro muito próximo e tem como cenário uma república onde não existem mais jornais, revistas, livros nem filmes. ", Autor = "Margaret Atwood", Edicao = "6º", Lancamento = 2019 });
                    context.livros.Add(new Livros {Nome = "Eu, Robô", Sinopse = "Um dos maiores clássicos da literatura de ficção científica, Eu, Robô, escrito pelo Bom Doutor, Isaac Asimov foi publicado originalmente em 1950.", Autor = "Isaac Asimov", Edicao = "2º", Lancamento = 2014 });
                }
                context.SaveChanges();

                if (!context.pedidos.Any())
                {
                    context.pedidos.Add(new Pedidos { livroId=4, endereco = "Rua do josé, casa vermelha do chico, 32", quantidade = 3 });
                    context.pedidos.Add(new Pedidos { livroId=5, endereco = "Rua joão martins, ap.21, Bahia, Salvador", quantidade = 1 });
                    context.pedidos.Add(new Pedidos { livroId=6, endereco = "Rua vermelha, casa 32, bairro galinheiros, Natal, Rio Grande do norte", quantidade = 5 });
                }
                context.SaveChanges();
            }
        }
    }
}
