

List<Category> categories = new List<Category>
{
    new Category{CategoryId=1,CategoryName="Bilgisayar"},
    new Category{CategoryId=2,CategoryName="Telefon"}
};

List<Product> products = new List<Product>
{
    new Product{ProductId=1,CategoryId=1,ProductName="Acer Laptop",QuantityPerUnit="32 GB Ram",UnitPrice=10000,UnitsInStock=5},
    new Product{ProductId=2,CategoryId=1,ProductName="Asus Laptop",QuantityPerUnit="16 GB Ram",UnitPrice=8000,UnitsInStock=3},
    new Product{ProductId=3,CategoryId=1,ProductName="Hp Laptop",QuantityPerUnit="8 GB Ram",UnitPrice=6000,UnitsInStock=2},
    new Product{ProductId=4,CategoryId=2,ProductName="Samsung Telefon",QuantityPerUnit="4 GB Ram",UnitPrice=5000,UnitsInStock=15},
    new Product{ProductId=5,CategoryId=2,ProductName="Apple Telefon ",QuantityPerUnit="4 GB Ram",UnitPrice=8000,UnitsInStock=0},
};

//foreach (var product in products)
//{
//    Console.WriteLine(product.ProductName);
//}

//foreach (var product in products)
//{
//    if(product.UnitPrice>5000 && product.UnitInStock>3)
//    {
//        Console.WriteLine(product.ProductName);
//    }
//}


//linqtest();

static void linqtest()
{
    static List<Product> GetProducts(List<Product> products)
    {
        return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
    }
}

//findtest(products);

static void findtest(List<Product> products)
{
    var result = products.Any(p => p.ProductName == "Dell Laptop");
    Console.WriteLine(result);
}

//findall(products);

static void findall(List<Product> products)
{
    var result = products.FindAll(p => p.ProductName.Contains("top"));
    Console.WriteLine(result);
}

//AscDesc(products);

static void AscDesc(List<Product> products)
{
    var result = products.FindAll(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice).ThenByDescending(P => P.ProductName);
    //OrderByDescending first unitprice THEN productname

    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

var result = from p in products
             join c in categories
on p.CategoryId equals c.CategoryId
where p.UnitPrice >5000
             select new ProductDto { ProductId = p.ProductId, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
foreach (var productDto in result)
{
    Console.WriteLine(productDto.ProductName + " " + productDto.CategoryName);
}

//classiclinqtest(products);

static void classiclinqtest(List<Product> products)
{
    var result = from p in products
                 where p.UnitPrice > 6000
                 orderby p.UnitPrice
                 select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

class Product

{
    public int ProductId { get; set; }

    public int CategoryId { get; set; }
    public string ProductName { get; set; }

    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }

}


class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}


class ProductDto
{
    public int ProductId { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }

    public decimal UnitPrice { get; set; }
}