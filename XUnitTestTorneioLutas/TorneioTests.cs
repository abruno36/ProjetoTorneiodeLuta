using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Xunit;

namespace XUnitTestTorneioLutas
{
    public class TorneioTests
    {
        [Fact]
        public void CarregaLutadores()
        {
            //Arrange
            //Validação de existência da URL

            var request = (HttpWebRequest)WebRequest.Create("http://177.36.237.87/lutadores/api/competidores");
            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response;
            request.Method = "GET";

            try
            {
                response = request.GetResponse() as HttpWebResponse;
                //Assert
                string msg = "URL ENCONTRADA";
                string msg1 = "URL ENCONTRADA";
                Assert.True(msg == msg1, "URL ENCONTRADA");
            }
            catch (WebException ex)
            {
                //Assert
                string msg = "URL ENCONTRADA";
                string msg1 = "URL NÃO ENCONTRADA";
                Assert.True(msg == msg1, "URL NÃO ENCONTRADA");
                response = ex.Response as HttpWebResponse;
            }

            //Arrange
            // Obtenha o fluxo contendo o conteúdo retornado pelo arquivo.
            var dataStream = response.GetResponseStream();
            // Abra o fluxo usando um StreamReader para facilitando o acesso.
            StreamReader reader = new StreamReader(dataStream);
            // Ler o conteúdp
            string responseFromServer = reader.ReadToEnd();
            var lutadores = JsonConvert.DeserializeObject<List<Lutador>>(responseFromServer);

            // Limpar todos os fluxos.
            reader.Close();
            dataStream.Close();
            response.Close();

            //Incluindo dados no Json
            Lutador novoLutador = new Lutador();
            novoLutador.Nome = "Bruno";
            novoLutador.Derrotas = 5;
            novoLutador.Idade = 55;
            novoLutador.Lutas = 30;
            novoLutador.Vitorias = 20;
            novoLutador.ArtesMarciais = new List<string>() { "Judo", "Karate" };
            lutadores.Add(novoLutador);
            var json_serializado = JsonConvert.SerializeObject(lutadores);

            //Arrange
            //IEnumerable<Lutador> lutadores1 = new List<Lutador>()
            //{
            //      new Lutador(){Nome= "Muhammad Ali", Idade=74 , ArtesMarciais=new List<string>() { "Judo", "Karate" }, Lutas=61 , Derrotas=5 , Vitorias=56 }
            //    , new Lutador(){Nome= "Chuck Liddell", Idade=49 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=30 , Derrotas=9 , Vitorias=21 }
            //    , new Lutador(){Nome= "Sugar Ray Robinson", Idade=67 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=200 , Derrotas=19 , Vitorias=173 }
            //    , new Lutador(){Nome= "Anderson Silva", Idade=44 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=44 , Derrotas=9 , Vitorias=34 }
            //    , new Lutador(){Nome= "George Foreman", Idade=70 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=81 , Derrotas=5 , Vitorias=76 }
            //    , new Lutador(){Nome= "Sugar Ray Leonard", Idade=62 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=50 , Derrotas=3 , Vitorias=36 }
            //    , new Lutador(){Nome= "Jon Jones", Idade=31 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=50 , Derrotas=1 , Vitorias=23 }
            //    , new Lutador(){Nome= "Rocky Marciano", Idade=45 , ArtesMarciais=new List<string>() { "Judo", "Karate" }, Lutas=49 , Derrotas=0 , Vitorias=49 }
            //};


            int count = 0;
            //Act - método de leitura dos lutadores
            foreach (var lutador in lutadores)
            {
                count++;

                //Assert
                int vlrLutas = lutador.Lutas;
                Assert.True(vlrLutas > 0, "Lutas deve ser maior que zeros");

                //Assert
                int vlrVitorias = lutador.Vitorias;
                Assert.True(vlrLutas >= vlrVitorias, "Vitórias não pode ser maior que Lutas");
                //Console.WriteLine($"{lutador.Nome} \t\tPercentual de Vitórias: {lutador.PercentualVitorias} Artes Marciais:  {lutador.ArtesMarciais} Lutas: {lutador.Lutas}");
            }

            AchaResultado();

            //Acha numero de registro lidos no foreach acima, assert deve ser maior que 20.
            int vlrregistros = 40;
            Assert.True(count >= vlrregistros, "Numero de Lutadores menor que 20 - torneio não reaLizado");


        }

        [Fact]
        public void AchaResultado()
        {
            var request = (HttpWebRequest)WebRequest.Create("http://177.36.237.87/lutadores/api/competidores");

            //Arrange
            request.ContentType = "application/json; charset=utf-8";
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            // Obtenha o fluxo contendo o conteúdo retornado pelo arquivo.
            var dataStream = response.GetResponseStream();
            // Abra o fluxo usando um StreamReader para facilitando o acesso.
            StreamReader reader = new StreamReader(dataStream);
            // Ler o conteúdp
            string responseFromServer = reader.ReadToEnd();
            var lutadores = JsonConvert.DeserializeObject<List<Lutador>>(responseFromServer);
            // Limpar todos os fluxos.
            reader.Close();
            dataStream.Close();
            response.Close();

            //Incluindo dados no Json 
            Lutador novoLutador = new Lutador();
            novoLutador.Nome = "Bruno";
            novoLutador.Derrotas = 5;
            novoLutador.Idade = 55;
            novoLutador.Lutas = 30;
            novoLutador.Vitorias = 20;
            novoLutador.ArtesMarciais = new List<string>() { "Judo", "Karate" };
            lutadores.Add(novoLutador);


            //Serializar para Json novamente
            var json_serializado = JsonConvert.SerializeObject(lutadores);

            //IEnumerable<Lutador> lutadores1 = new List<Lutador>()
            //{
            //      new Lutador(){Nome= "Muhammad Ali", Idade=74 , ArtesMarciais=new List<string>() { "Judo", "Karate" }, Lutas=61 , Derrotas=5 , Vitorias=56 }
            //    , new Lutador(){Nome= "Chuck Liddell", Idade=49 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=30 , Derrotas=9 , Vitorias=21 }
            //    , new Lutador(){Nome= "Sugar Ray Robinson", Idade=67 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=200 , Derrotas=19 , Vitorias=173 }
            //    , new Lutador(){Nome= "Anderson Silva", Idade=44 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=44 , Derrotas=9 , Vitorias=34 }
            //    , new Lutador(){Nome= "George Foreman", Idade=70 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=81 , Derrotas=5 , Vitorias=76 }
            //    , new Lutador(){Nome= "Sugar Ray Leonard", Idade=62 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=50 , Derrotas=3 , Vitorias=36 }
            //    , new Lutador(){Nome= "Jon Jones", Idade=31 , ArtesMarciais=new List<string>() { "Judo", "Karate" } , Lutas=50 , Derrotas=1 , Vitorias=23 }
            //    , new Lutador(){Nome= "Rocky Marciano", Idade=45 , ArtesMarciais=new List<string>() { "Judo", "Karate" }, Lutas=49 , Derrotas=0 , Vitorias=49 }
            //};


            IEnumerable<Lutador> lutadores1 = JsonConvert.DeserializeObject<IEnumerable<Lutador>>(json_serializado);

            var classificacao = lutadores1.OrderByDescending(l => l.PercentualVitorias);

            foreach (var lutador in classificacao)
            {
                //Assert
                int vlrLutas = lutador.Lutas;
                Assert.True(vlrLutas > 0, "Valor de Lutas deve ser maior que zeros");

                //Assert
                int vlrVitorias = lutador.Vitorias;
                Assert.True(vlrLutas >= vlrVitorias, "Valor de Vitórias não pode ser maior que o valor de Lutas");
                //Console.WriteLine($"{lutador.Nome} \t\tPercentual de Vitórias: {lutador.PercentualVitorias} Artes Marciais:  {lutador.ArtesMarciais} Lutas: {lutador.Lutas}");
            }
        }
    }
}