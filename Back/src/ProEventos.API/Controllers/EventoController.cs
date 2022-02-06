﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        public IEnumerable<Evento> _evento = new Evento[]
        {
            new Evento()
                {
                    EventoId = 1,
                    Tema = "Angular e .NET 5",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QuantidadePessoas = 250,
                    dataEvento = DateTime.Now.AddDays(2).ToString("dd/mm/yyyy"),
                    ImagemURL = "Foto.png"
                },
                new Evento()
                {
                    EventoId = 2,
                    Tema = "Angular e suas novidades",
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QuantidadePessoas = 350,
                    dataEvento = DateTime.Now.AddDays(3).ToString("dd/mm/yyyy"),
                    ImagemURL = "Foto1.png"
                },
        };
        public EventoController()
        {
            
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IEnumerable<Evento> GetById(int id)
        {
            return _evento.Where(Evento => Evento.EventoId == id);
        }
        [HttpPost]
        public string Post()
        {
            return "Exemplo de post";
        }

        [HttpPut("{id}")]
        public string put(int id)
        {
            return $"Exemplo de put com id = {id}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Exemplo de Delete com id = {id}";
        }
    }
}