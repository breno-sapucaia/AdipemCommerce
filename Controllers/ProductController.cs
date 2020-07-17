using AdipemCommerce.Domain;
using AdipemCommerce.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AdipemCommerce.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
		private readonly DataContext _context;

		public ProductController(DataContext context)
		{
			_context = context;
		}
		[HttpGet]
		public ActionResult<IEnumerable<Product>> GetProducts()
		{
			return _context.Products;
		}


    }
}