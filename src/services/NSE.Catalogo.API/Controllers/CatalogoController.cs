﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSE.Catalogo.API.Models;
using NSE.WebApi.Core.Controllers;
using NSE.WebApi.Core.Identidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Controllers
{
    [ApiController]
    [Authorize]
    public class CatalogoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        

        [HttpGet("catalogo/produtos")]
        [AllowAnonymous]
        public async Task<IEnumerable<Produto>> Index()
        {
            return await _produtoRepository.ObterTodos();
        }

        
        [HttpGet("catalogo/produtos/{id}")]
        [ClaimsAuthorize("Catalogo","Ler")]
        public async Task<Produto> ProdutoDetalhe(Guid Id)
        {
            return await _produtoRepository.ObterPorId(Id);
        }
    }
}
