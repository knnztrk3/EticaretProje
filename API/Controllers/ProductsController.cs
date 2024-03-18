using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using API.RequestHelpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        //BaseApiControllerden route ve ControllerBase i aldı
        //dependency injection kullanarak context'imizi alicaz
        private readonly EticaretContext _context;
        private readonly IMapper _mapper;
        public ProductsController(EticaretContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<PagedList<Product>>> GetProducts([FromQuery] ProductParams productParams)
        {
            // return await _context.Products.ToListAsync();
            // extensions. içerisinden Sort metodu yardımı ile gelen parametreye göre list of products döndürüyoruz
            var query = _context.Products.Sort(productParams.orderBy).Search(productParams.searchTerm).Filter(productParams.brands, productParams.types).AsQueryable();

            var products = await PagedList<Product>.ToPagedList(query, productParams.PageNumber, productParams.PageSize);

            Response.AddPaginationHeader(products.MetaData);

            return products;
        }

        [HttpGet("{id}", Name = "GetProduct")]   // api/products/3
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            // Ürün var mı? PrimaryKey'inde arayıp Ürünü Veritabanımızdan getir
            var product = await _context.Products.FindAsync(id);

            // Ürün yoksa NotFound sayfasını döndür
            if (product == null) return NotFound();

            // ürün geldiyse ürünü dön
            return product;
        }

        [HttpGet("filters")]
        public async Task<IActionResult> GetFilters()
        {
            var brands = await _context.Products.Select(x => x.Brand).Distinct().ToListAsync();
            var types = await _context.Products.Select(x => x.Type).Distinct().ToListAsync();

            return Ok(new { brands, types });
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(CreateProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            _context.Products.Add(product);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return CreatedAtRoute("GetProduct", new { Id = product.Id }, product);

            return BadRequest(new ProblemDetails { Title = "Yeni ürün oluştulurken bir hata meydana geldi" });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ActionResult> UpdateProduct(UpdateProductDto productDto)
        {
            var product = await _context.Products.FindAsync(productDto.Id);

            if (product == null) return NotFound();

            _mapper.Map(productDto, product);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return NoContent();

            return BadRequest(new ProblemDetails { Title = "Ürün güncellenirken bir hata meydana geldi" });
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null) return NotFound();

            _context.Products.Remove(product);

            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails { Title = "Ürün silinirken bir hata meydana geldi" });
        }

    }
}