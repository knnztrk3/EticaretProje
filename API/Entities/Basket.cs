namespace API.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        // cookie olarak Guid tutucaz o yüzden string
        public string BuyerId { get; set; }
        // her basket (sepet) nesnesinin birden fazla itemi var -> one to many relationship
        public List<BasketItem> Items { get; set; } = new List<BasketItem>(); //Basket nesnesi olusturuldugunda basket item listesi olustur

        // if we already have the item in our basket, then we're going to increasing quantity
        // and if we do not have the item in the basket, we're going to be adding this as a new item to our basket
        public void AddItem(Product product, int quantity)
        {
            // sepetimizde urun var mı?
            // All -> we'll check to see if we actually have the item in our basket -> if it does exist, it's going to return true.
            // urun hali hazırda sepetimizde var mı yok mu kontrolünü yapıyoruz
            if (Items.All(item => item.ProductId != product.Id))
            {
                // eğer sepetimizde o üründen yoksa ürünü getir ve sepete ekle ve return ile geri döndür
                Items.Add(new BasketItem
                {
                    Product = product,
                    Quantity = quantity,
                });
                return;
            }
            // sepet icerisinde o ürün varsa alıp existingItem degiskeni icerisine at
            var existingItem = Items.FirstOrDefault(item => item.ProductId == product.Id);
            // eger item varsa, existingItem icerisi bos degilse, yani urun zaten var ve adetini arttır
            if (existingItem != null) existingItem.Quantity += quantity;
        }

        public void RemoveItem(int productId, int quantity)
        {
            // sepet icerisinde gelen üründen var mı?
            var item = Items.FirstOrDefault(item => item.ProductId == productId);
            // yoksa bos dön birşey yapma
            if (item == null) return;
            // varsa, adetini 1 düşür
            item.Quantity -= quantity;
            // ve adeti 0 a eşitlenirse eğer sepetten ürünü sil
            if (item.Quantity == 0) Items.Remove(item);
        }
    }
}