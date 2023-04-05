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
            navegador.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);

            var campoPesquisa = navegador.FindElement(By.Name("q"));
            campoPesquisa.SendKeys("tênis Nike");
            Thread.Sleep(2000);

            var botaoPesquisa = navegador.FindElement(By.Name("btnK"));
            botaoPesquisa.Click();
            Thread.Sleep(2000);

            // Assertiva utilizando Fluent Assertions
            var tituloEsperado = "tênis Nike - Pesquisa Google";
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