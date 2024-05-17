using Kiosk.WebAPI.Models;

namespace Kiosk.WebAPI.Persistance
{
    // interfejsy repozytoriów specyficznych
    public interface IProductRepository : IRepository<Product>
    {
        int GetMaxId();
        bool CanBeUsed(string name);
    }
}
