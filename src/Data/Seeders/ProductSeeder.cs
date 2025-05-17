using Bogus;
using TallerIDWM.Src.Models;

namespace TallerIDWM.Src.Data.Seeders
{
    public class ProductSeeder
    {
        public static List<Product> GenerateProducts(int count = 10)
        {
            var faker = new Faker("es");

            var products = new Faker<Product>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Category, f => f.Commerce.Department())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.Price, f => f.Random.Decimal(5000, 50000))
                .RuleFor(p => p.Brand, f => f.Company.CompanyName())
                .RuleFor(p => p.Stock, f => f.Random.Int(10, 200))
                .RuleFor(
                    p => p.Urls,
                    (f, p) =>

                        [
                            $"https://res.cloudinary.com/dyi1vwgbg/image/upload/v1747509928/teclado_gamer_semi_mecanico_anti_ghosting_suporte_para_celular_revestimento_em_metal_clanm_cl_tm8153_4997_2_0f8b4437b36be18c510fed281b159d80_zhll5m.png",
                            $"https://res.cloudinary.com/dyi1vwgbg/image/upload/v1747509928/156187-800-800_mnlhhn.png",
                            $"https://res.cloudinary.com/dyi1vwgbg/image/upload/v1747509860/marcasfiddlerfd-kd609-negro3jpeg_2_slwxlv.jpg",
                        ]
                )
                .Generate(count);

            return products;
        }
    }
}
