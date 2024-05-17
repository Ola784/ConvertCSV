using Kiosk.WebAPI.Models;

namespace Kiosk.WebAPI.Persistance
{
    // Implementacja repozytoriów specyficznych
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly KioskDbContext _kioskDbContext;

        public ProductRepository(KioskDbContext context)
            : base(context)
        {
            _kioskDbContext = context;
        }

        public int GetMaxId()
        {
            return _kioskDbContext.Products.Max(x => x.Id);
        }
        public bool CanBeUsed(string name)
        {
            bool result= true;
            foreach (var product in _kioskDbContext.Products)
            { if (product.Name == name) result=false; }
            return result;
        }
    }
}
