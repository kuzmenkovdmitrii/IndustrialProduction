using System.Collections.Generic;
using BLL.Infrastructure;
using BLL.Service.Interface;
using Common.Entities;
using DAL.Context;

namespace BLL.Service
{
    public class ProductService : IProductService
    {
        IUnitOfWork DB { get;}

        public ProductService(IUnitOfWork db)
        {
            DB = db;
        }

        public OperationDetails Create(Product product)
        {
            if (!CheckExistence(product.Id))
            {
                DB.ProductRepository.Create(product);
                return new OperationDetails(true, "Товар успешно добавлен");
            }

            return new OperationDetails(false, "Товар уже существует");
        }

        public OperationDetails Delete(int id)
        {
            if (CheckExistence(id))
            {
                DB.ProductRepository.Delete(id);
                return new OperationDetails(true, "Товар успешно удалён");
            }

            return new OperationDetails(false, "Товар с таким id не существует");
        }

        public OperationDetails Edit(Product product)
        {
            try
            {
                DB.ProductRepository.Update(product);
                return new OperationDetails(false, "Товар был успешно обновлён");
            }
            catch
            {
                return new OperationDetails(false, "Товар не был обновлён");
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return DB.ProductRepository.List();
        }

        public Product Get(int id)
        {
            return DB.ProductRepository.Get(id);
        }

        private bool CheckExistence(int id)
        {
            var check = DB.ProductRepository.Get(id);
            if (check != null)
            {
                return true;
            }

            return false;
        }
    }
}
