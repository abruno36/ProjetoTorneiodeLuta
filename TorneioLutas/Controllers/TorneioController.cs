﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using TorneioLutas.Models.Torneio;

namespace TorneioLutas.Controllers
{
    public partial class TorneioController : Controller
    {

        // GET: Torneio
        public ActionResult Index()
        {

            //Validação de existência da URL

            var request = (HttpWebRequest)WebRequest.Create("http://177.36.237.87/lutadores/api/competidores");
            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response;
            request.Method = "GET";

            try
            {
                TempData["Message"] = "Escolha 20 lutadores para inicio do torneio!";
                response = request.GetResponse() as HttpWebResponse;
            }
            catch (WebException ex)
            {
                TempData["Message"] = "Problemas com o arquivo de torneio - não foi localizado - verificar!";
                response = ex.Response as HttpWebResponse;
                return View();
            }

            //Arrange
            // Obtenha o fluxo contendo o conteúdo retornado pelo arquivo.
            var dataStream = response.GetResponseStream();
            // Abra o fluxo usando um StreamReader para facilitando o acesso.
            StreamReader reader = new StreamReader(dataStream);
            // Ler o conteúdp
            string responseFromServer = reader.ReadToEnd();
            var lutadores = JsonConvert.DeserializeObject<List<LutadorModel>>(responseFromServer);

            List<LutadorModel> lutadorLista = new List<LutadorModel>();

            int count = 0;

            //{
            //    get { return (int)(Vitorias / (double)Lutas * 100); }

            //}

            //foreach (var item in lutadores)
            //{
            //    LutadorModel lutador = new LutadorModel();
            //    count++;

            //    lutador.Id = count;
            //    lutador.Nome = item.Nome;
            //    lutador.Derrotas = item.Derrotas;
            //    lutador.Idade = item.Idade;
            //    lutador.Lutas = item.Lutas;
            //    lutador.Vitorias = item.Vitorias;
            //    lutador.ArtesMarciais = item.ArtesMarciais;
            //    lutador.PercentualVitorias = lutador.Vitorias / lutador.Lutas * 100;
            //    lutadorLista.Add(lutador);
            //}

            //var model = new LutadorModel();

            //model.Lutadores = lutadorLista;

            // Limpar todos os fluxos.
            reader.Close();
            dataStream.Close();
            response.Close();

            return View(lutadores);
        }

        //public ActionResult Torneio(int[] LutadoresIDs)
        //{
        //    var selecionados = model.Selecionados.Where(l => l.Selecionado).ToList();
        //    var naoSelecionados = model.Selecionados.Where(l => !l.Selecionado).ToList();

        //    int count = 0;
        //    //Método de leitura dos lutadores
        //    foreach (var lutadores1 in selecionados)
        //    {
        //        count++;
        //        int vlrLutas = 20;
        //        if (vlrLutas == 0)
        //        {
        //            TempData["Message"] = "Lutas deve ser maior que zeros!";
        //            return View(selecionados);
        //        }

        //        //int vlrVitorias = lutadores.Vitorias;
        //        int vlrVitorias = 1;
        //        if (vlrLutas < vlrVitorias)
        //        {
        //            TempData["Message"] = "Vitórias não pode ser maior que Lutas!";
        //            return View(selecionados);
        //        }
        //    }

        //    int vlrRegistros = 20;
        //    if (count != vlrRegistros)
        //    {
        //        TempData["Message"] =
        //            "Numero de Lutadores deve ser igual a  20 - torneio não reaLizado! Escolhidos apenas " + count +
        //            " Lutadores";
        //        return View(selecionados);
        //    }

        //    TempData["Message"] = "Processo pronto para a realização do sorteio!";
        //    return View(selecionados);
        //    return View();
        //}

        public ActionResult SubmitExpenses(int[] lutadoresIDs)
        {
            //expenseDate = (DateTime)Session["FirstDate"];
            //expenseDate2 = (DateTime)Session["SecondDate"];

            //if (expenseDate == null || expenseDate2 == null)
            //{
            //    expenseDate = DateTime.Now.AddMonths(-1);
            //    expenseDate2 = DateTime.Today;
            //}

            //string currentUserId = User.Identity.Name;

            //var query = from e in db.Expenses
            //            join user in db.UserProfiles on e.UserId equals user.UserId
            //            where e.ExpenseDate >= expenseDate && e.ExpenseDate <= expenseDate2 && e.DateSubmitted == null
            //            orderby e.ExpenseDate descending
            //            select new { e, user };

            //if (User.IsInRole("admin") && userId != 0)
            //{
            //    query = query.Where(x => x.user.UserId == userId);
            //}
            //else if (!User.IsInRole("admin"))
            //{
            //    query = query.Where(x => x.user.UserName == currentUserId);
            //}

            ////var localExpenseIDs = expenseIDs;

            //var joined = from dbExpense in query.Select(x => x.e).AsEnumerable()
            //    join localExpense in expenseIDs on dbExpense.ExpenseId equals localExpense
            //    where localExpense == dbExpense.ExpenseId
            //    select dbExpense;

            //foreach (Expense exp in joined)
            //{
            //    exp.DateSubmitted = DateTime.Today;
            //    exp.IsSubmitted = true;
            //}

            //try
            //{
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    return RedirectToAction("Submit");
            //}

            return View();

        }


    }
}