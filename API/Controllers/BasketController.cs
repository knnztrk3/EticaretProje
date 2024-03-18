using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly EticaretContext _context;
        public BasketController(EticaretContext context)
        {
            _context = context;
        }

        //get, add, remove
        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await RetrieveBasket(GetBuyerId());

            if (basket == null) return NotFound();
            return basket.MapBasketToDto();
        }

        [HttpPost] // api/basket?productId=3&quantity=2
        public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity)
        {
            // get basket
            var basket = await RetrieveBasket(GetBuyerId());
            // ifnot - create basket
            if (basket == null) basket = CreateBasket();
            // get product
            var product = await _context.Products.FindAsync(productId); // find primary keyine göre arama yapar
                                                                        // eger urun yoksa urun bulunamadı, notFound dön
            if (product == null) return BadRequest(new ProblemDetails { Title = "Ürün bulunamadı!" });
            // add item
            basket.AddItem(product, quantity);
            // save changes
            var result = await _context.SaveChangesAsync() > 0; // SaveChangesAsync returns -> number of changes 
            // CreatedAtRoute() -> Http201 Created yanıtıyla birlikte istemciye döndürür.
            if (result) return CreatedAtRoute("GetBasket", basket.MapBasketToDto());

            // if we not successfully return badrequest
            return BadRequest(new ProblemDetails { Title = "Ürün sepete eklenirken bir hata meydana geldi." });
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        {

            // get basket || if we dont create basket
            var basket = await RetrieveBasket(GetBuyerId());
            if (basket == null) NotFound();
            // remove item or reduce quantity
            basket.RemoveItem(productId, quantity);
            // save changes
            var result = await _context.SaveChangesAsync() > 0;

            if (result) return Ok();

            return BadRequest(new ProblemDetails
            {
                Title = "Sepetten ürün silinirken bir hata meydana geldi."
            });
        }

        // Retrieve -> getir, get,
        private async Task<Basket> RetrieveBasket(string buyerId)
        {
            if (string.IsNullOrEmpty(buyerId))
            {
                Response.Cookies.Delete("buyerId");
                return null;
            }

            return await _context.Baskets
                .Include(i => i.Items)
                .ThenInclude(p => p.Product)
                .FirstOrDefaultAsync(x => x.BuyerId == buyerId);
        }

        private string GetBuyerId()
        {
            return User.Identity?.Name ?? Request.Cookies["buyerId"];
        }

        private Basket CreateBasket()
        {
            // globally unique identifier for users
            var buyerId = User.Identity?.Name;
            if (string.IsNullOrEmpty(buyerId))
            {
                buyerId = Guid.NewGuid().ToString();
                var cookieOptions = new CookieOptions
                {
                    IsEssential = true,
                    Expires = DateTime.Now.AddDays(30)
                };

                Response.Cookies.Append("buyerId", buyerId, cookieOptions);
            }

            var basket = new Basket
            {
                BuyerId = buyerId
            };

            _context.Baskets.Add(basket);

            return basket;
        }
    }
}