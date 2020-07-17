using System.Collections.Generic;

namespace AdipemCommerce.Domain
{
	public class Product : EntityBase
	{
		public string Name { get; set; }
		public double Price { get; set;}
		public byte[] Images { get; set; }
		public string Description { get; set; }
	}
}
