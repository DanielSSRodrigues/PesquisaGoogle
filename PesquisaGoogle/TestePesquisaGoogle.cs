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
        private readonly IWebDriver _driver;
        private readonly string _url;

        public TestePesquisaGoogle()
        {
            _url = "https://www.google.com.br/";
            _driver = new ChromeDriver();
        }

        [Fact]
        public void PesquisarTenisNoGoogle()
        {
            // Acessa o site do Google
            _driver.Navigate().GoToUrl(_url);
            Thread.Sleep(2000);

            // Encontra o campo de pesquisa e insere o termo "tênis"
            var campoPesquisa = _driver.FindElement(By.Name("q"));
            campoPesquisa.SendKeys("tênis");
            Thread.Sleep(2000);

            // Encontra o botão de pesquisa e clica nele
            var botaoPesquisa = _driver.FindElement(By.Name("btnK"));
            botaoPesquisa.Click();
            Thread.Sleep(2000);

            // Verifica se a página de resultados de pesquisa foi carregada
            var tituloEsperado = "tênis - Pesquisa Google";
            _driver.Title.Should().Be(tituloEsperado, $"O título atual é {_driver.Title}");
            Thread.Sleep(2000);

        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}