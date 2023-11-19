

using FizooHelper.Models;
using Microsoft.EntityFrameworkCore;
using Task.EFCore;
using Task.EFCore.Models;

namespace Task.Domain.Services.ProductDomain
{
    public class ProductsService : IProductsService
    {
        private readonly MyDBContext myDB;

        public ProductsService(MyDBContext myDB)
        {
            this.myDB = myDB;
        }
        public async Task<Respond<Product>> Add(Product dto)
        {
            var res=await myDB.Products.AddAsync(dto);
            await  myDB.SaveChangesAsync();
            return new Respond<Product>
            {
                IsSuccess = true,
                Data = res.Entity,
            };
        }

        public async Task<Respond<string>> Delete(int id)
        {
            var res =await myDB.Products.FindAsync(id);
            if(res==null)
            {
                return new Respond<string>()
                {
                    IsSuccess=false,
                    Message="Product not Found"

                };
            }
            myDB.Products.Remove(res);
             await myDB.SaveChangesAsync();
            return new Respond<string>
            {
                IsSuccess = true,
            };
        }

        public async Task<Respond<Product>> Get(int id)
        {
            var res = await myDB.Products.FindAsync(id);
            if (res == null)
            {
                return new Respond<Product>()
                {
                    IsSuccess = false,
                    Message = "Product not Found"

                };
            }
            return new Respond<Product>
            {
                IsSuccess = true,
                Data = res,
            };
        }

        public async Task<List<Product>> GetAll(FilterModel? filter = null)
        {
           return await myDB.Products.ToListAsync();
        }

        public async Task<Respond<Product>> Update(int id, Product dto)
        {
            var res = await myDB.Products.FindAsync(id);
            if (res == null)
            {
                return new Respond<Product>()
                {
                    IsSuccess = false,
                    Message = "Product not Found"

                };
            }
            res.Name = dto.Name;
            res.Price = dto.Price;
            res.Description = dto.Description;
            res.Category = dto.Category;
            await myDB.SaveChangesAsync();
            return new Respond<Product>
            {
                IsSuccess = true,
                Data = res,
            };
        }
    }
}
