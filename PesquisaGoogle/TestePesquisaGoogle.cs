using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading;


namespace PesquisaGoogle
{
    public class TestePesquisaGoogle : IDisposable
    {
        private readonly IWebDriver navegador;
        private readonly string _url;

        public TestePesquisaGoogle()
        {
            _url = "https://www.google.com.br/";
            navegador = new ChromeDriver();
        }

        [Fact]
        public void PesquisarTenisNoGoogle()
        {
            // Acessa o site do Google
            navegador.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);

            // Encontra o campo de pesquisa e insere o termo "tênis"
            var campoPesquisa = navegador.FindElement(By.Name("q"));
            campoPesquisa.SendKeys("tênis");
            Thread.Sleep(2000);

            // Encontra o botão de pesquisa e clica nele
            var botaoPesquisa = navegador.FindElement(By.Name("btnK"));
            botaoPesquisa.Click();
            Thread.Sleep(2000);

            // Verifica se a página de resultados de pesquisa foi carregada
            var tituloEsperado = "tênis - Pesquisa Google";
            navegador.Title.Should().Be(tituloEsperado, $"O título atual é {navegador.Title}");
            Thread.Sleep(2000);

        }

        public void Dispose()
        {
            navegador.Quit();
            navegador.Dispose();
        }
    }
}