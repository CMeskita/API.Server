using API.Server.Controllers;
using API.Server.Dto;
using API.Server.Entity;
using API.Server.Infra;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit.Sdk;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestServer
{
    public class ServidorTest
    {
     
        private const int Id = 1;
        private const string Name = "MARVEL-SRV";
        private const string IpAdress = "192.198.198.00";
        private const string Description = "";

        ServidorController _controller;
        Context _context;

        public ServidorTest()
        {

            _context = new Context();
             _controller = new ServidorController(_context);
        }

        [Fact]
        public void Listar_Servidor()
        {
            //Servidor dados = new Servidor(Name, IpAdress, Description);
            var result = _controller.GetServidores();
            Assert.NotNull(result);
            
        }
        [Fact]
        public void Cadstrar_Servidor()
        {
            DtoServidor dados = new(Name, IpAdress, Description);
            var result = _controller.InsertServidor(dados);
            Assert.NotNull(result);

        }
    }
}