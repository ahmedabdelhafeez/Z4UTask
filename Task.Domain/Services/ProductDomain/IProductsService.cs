

using FizooHelper.Shared;
using Task.EFCore.Models;

namespace Task.Domain.Services.ProductDomain
{
    public interface IProductsService:IBaseInterface<Product,Product,List<Product>,Product,string>
    {
    }
}
