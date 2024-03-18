using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(EticaretContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "kenan",
                    Email = "kenan@hotmail.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@hotmail.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "Admin" });
            }

            if (context.Products.Any())
            {
                return;
            }

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Mavi Erkek Çocuk T-shirt",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 20000,
                    PictureUrl = "/images/products/erkekcocuktisort1.png",
                    Brand = "Mavi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Black White T-shirt",
                    Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                    Price = 15000,
                    PictureUrl = "/images/products/erkekcocuktisort2.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Beyaz Dragon Baskılı Erkek Çocuk T-shirt",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/erkekcocuktisort3.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "NY Baskılı T-shirt",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 30000,
                    PictureUrl = "/images/products/erkekcocuktisort4.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Çizgili Erkek Çocuk T-shirt",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 25000,
                    PictureUrl = "/images/products/erkekcocuktisort5.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Imzalı Atatürk Baskılı T-shirt",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 12000,
                    PictureUrl = "/images/products/erkekcocuktisort6.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Kapüşonlu Erkek Çocuk Alt Üst Takım",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 10000,
                    PictureUrl = "/images/products/erkekcocukaltusttakim1.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Kapüşonlu Erkek Çocuk Alt Üst Takım",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 8000,
                    PictureUrl = "/images/products/erkekcocukaltusttakim2.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Chicago Baskılı Erkek Çocuk Alt Üst Takım",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 15000,
                    PictureUrl = "/images/products/erkekcocukaltusttakim3.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "FELIX Baskılı Erkek Çocuk Alt Üst Takım",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 18000,
                    PictureUrl = "/images/products/erkekcocukaltusttakim4.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "SIMBA Baskılı Erkek Çocuk Alt Üst Takım",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 15000,
                    PictureUrl = "/images/products/erkekcocukaltusttakim5.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "STRONG Baskılı Erkek Çocuk Alt Üst Takım",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 16000,
                    PictureUrl = "/images/products/erkekcocukaltusttakim6.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Minecraft Baskılı Erkek Çocuk Sweatshirt",
                    Description =
                        "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 14000,
                    PictureUrl = "/images/products/erkekcocuksweatshirt1.png",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Basic Baskılı Erkek Çocuk Sweatshirt",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 25000,
                    PictureUrl = "/images/products/erkekcocuksweatshirt2.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Basic Baskılı Erkek Çocuk Sweatshirt K",
                    Description =
                        "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                    Price = 18999,
                    PictureUrl = "/images/products/erkekcocuksweatshirt3.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Denim Baskılı Erkek Çocuk Sweatshirt G",
                    Description =
                        "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                    Price = 19999,
                    PictureUrl = "/images/products/erkekcocuksweatshirt4.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Denim Baskılı Erkek Çocuk Sweatshirt T",
                    Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                    Price = 15000,
                    PictureUrl = "/images/products/erkekcocuksweatshirt5.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Erkek Çocuk Eşofman Takım Siyah",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/erkekesofmantakim1.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Erkek Çocuk Eşofman Takım Beyaz",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/erkekesofmantakim2.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Bright Baskılı Alt Üst Takım Krem",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim1.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Bright Baskılı Alt Üst Takım Mor",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim2.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Kız Çocuk Alt Üst Takım",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim3.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Girls Baskılı Alt Üst Takım",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim4.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Baskılı Alt Üst Takım",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim5.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Have Fun Baskılı Alt Üst Takım",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim6.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Baskılı Cepli Alt Üst Takım Sarı",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim7.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Baskılı Cepli Alt Üst Takım L",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim8.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Baskılı Cepli Alt Üst Takım P",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim9.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Baskılı Cepli Alt Üst Takım Y",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukaltusttakim10.jpg",
                    Brand = "Bakbi",
                    Type = "Takım",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Mickey Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukelbise1.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Düğmeli Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 19000,
                    PictureUrl = "/images/products/kizcocukelbise2.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Unicorn Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukelbise3.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Cherry Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 20000,
                    PictureUrl = "/images/products/kizcocukelbise4.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Smile Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukelbise5.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Daisy Duck Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 15000,
                    PictureUrl = "/images/products/kizcocukelbise6.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Lovely Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 17000,
                    PictureUrl = "/images/products/kizcocukelbise7.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Desenli Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 16000,
                    PictureUrl = "/images/products/kizcocukelbise8.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Unicorn Baskılı Kız Çocuk Elbise T",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 16500,
                    PictureUrl = "/images/products/kizcocukelbise9.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Mickey Baskılı Kız Çocuk Elbise M",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 16000,
                    PictureUrl = "/images/products/kizcocukelbise10.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Mickey Baskılı Kız Çocuk Elbise",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocukelbise11.jpg",
                    Brand = "Bakbi",
                    Type = "Elbise",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Cepli Kız Çocuk Pantolon T",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 19000,
                    PictureUrl = "/images/products/kizcocukpantolon1.jpg",
                    Brand = "Bakbi",
                    Type = "Pantolon",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Cepli Kız Çocuk Pantolon S",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 12000,
                    PictureUrl = "/images/products/kizcocukpantolon2.jpg",
                    Brand = "Bakbi",
                    Type = "Pantolon",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Ayı Baskılı Kız Çocuk Sweatshirt P",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 21000,
                    PictureUrl = "/images/products/kizcocuksweatshirt1.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Ayı Baskılı Kız Çocuk Sweatshirt B",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 20000,
                    PictureUrl = "/images/products/kizcocuksweatshirt2.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Perfect Baskılı Kız Çocuk Sweatshirt",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocuksweatshirt3.jpg",
                    Brand = "Bakbi",
                    Type = "Sweatshirt",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Kelebek Baskılı Kız Çocuk T-shirt",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocuktisort1.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Kalp Baskılı Kız Çocuk T-shirt",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 18000,
                    PictureUrl = "/images/products/kizcocuktisort2.png",
                    Brand = "Bakbi",
                    Type = "Tişört",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Miav Baskılı Kız Çocuk Sweatshirt",
                    Description =
                        "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                    Price = 15000,
                    PictureUrl = "/images/products/kizcocuktisort3.png",
                    Brand = "Mavi",
                    Type = "Tişört",
                    QuantityInStock = 100
                }
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}