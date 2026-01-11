using System.Reflection.Metadata;
using ConsoleApp2;

List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 1500, Stock = 10 },
            new Product { Id = 2, Name = "Mouse", Category = "Electronics", Price = 25, Stock = 50 },
            new Product { Id = 3, Name = "Keyboard", Category = "Electronics", Price = 45, Stock = 0 },
            new Product { Id = 4, Name = "Shirt", Category = "Clothing", Price = 30, Stock = 100 },
            new Product { Id = 5, Name = "Jeans", Category = "Clothing", Price = 60, Stock = 20 },
            new Product { Id = 6, Name = "Sneakers", Category = "Clothing", Price = 120, Stock = 5 },
            new Product { Id = 7, Name = "Apple", Category = "Food", Price = 2, Stock = 200 },
            new Product { Id = 8, Name = "Bread", Category = "Food", Price = 1.5, Stock = 0 },
            new Product { Id = 9, Name = "Coffee", Category = "Food", Price = 15, Stock = 40 }
        };
//Elektronika Sıralaması: Sadəcə "Electronics" kateqoriyasındakı məhsulları seçin və onları qiymətinə görə azalan sıra ilə (OrderByDescending) düzün.
//Adların Seçilməsi (Projection): Bütün məhsulların sadəcə adını və qiymətini ehtiva edən yeni bir siyahı (Anonymous Type) yaradın (Select istifadə edin).
var AnonymousType= products.Select(x=> new
{
    name=x.Name,
    cat= x.Category,
    price=x.Price,
} ).ToList();   
foreach (var product in AnonymousType)
    Console.WriteLine(product.cat+" "+product.name+" "+product.price);
//Select funskiyasi odurki biz her hansi bir listden her hansi bir datani yeni yaratdigim liste elave ede bilerik
//(OrderByDescending) funksiyasi odurki her hansi int double float tipindeki datalari azalan sira ile duzur