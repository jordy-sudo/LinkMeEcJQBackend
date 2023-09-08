    using LinkMeEcJQ.Domain;
    using MongoDB.Driver;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    namespace LinkMeEcJQ.Infrastructure.Persistence
    {
        public class ProductRepository
        {
            private readonly IMongoCollection<Product> _collection;

            public ProductRepository(IMongoDB dbContext)
            {
                _collection = dbContext.Products;
            }

            public async Task<List<Product>> GetAllAsync()
            {
                return await _collection.Find(_ => true).ToListAsync();
            }

            public async Task<Product> GetByIdAsync(string id)
            {
                return await _collection.Find(product => product.Id == id).FirstOrDefaultAsync();
            }

            public async Task CreateAsync(Product product)
            {
                await _collection.InsertOneAsync(product);
            }

            public async Task UpdateAsync(string id, Product product)
            {
            try
            {
                var existingProduct = await _collection.Find(p => p.Id == id).FirstOrDefaultAsync();

                if (existingProduct != null)
                {
                    existingProduct.UPC = product.UPC;
                    existingProduct.ProdName = product.ProdName;
                    existingProduct.Mfgr = product.Mfgr;
                    existingProduct.Model = product.Model;
                    existingProduct.UnitListPrice = product.UnitListPrice;
                    existingProduct.UnitInStock = product.UnitInStock;

                    var result = await _collection.ReplaceOneAsync(p => p.Id == id, existingProduct);

                    if (result.ModifiedCount == 1)
                    {
                    }
                    else
                    {
                        throw new Exception("No se pudo actualizar el documento.");
                    }
                }
                else
                {
                    throw new Exception("El documento con el ID especificado no se encontró.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error durante la actualización del documento.", ex);
            }
        }

            public async Task DeleteAsync(string id)
            {
                await _collection.DeleteOneAsync(p => p.Id == id);
            }
        }
    }
