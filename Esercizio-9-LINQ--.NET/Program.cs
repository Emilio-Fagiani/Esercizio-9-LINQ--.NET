using Esercizio_9_LINQ__.NET;

class Program
{
    static void Main()
    {
        List<Category> category = new List<Category>
        {
            new Category { Id = 1, Name ="Telefonia"},
            new Category { Id = 2, Name ="Console"},
            new Category { Id = 3, Name ="PC"},
            new Category { Id = 4, Name ="Elettrodomestici"}
        };

        List<Product> products = new List<Product>
        {
            new Product { Id = 1,Name = "Asus c33",CategoryId = 3},
            new Product { Id = 2,Name = "Iphone 15",CategoryId = 1},
            new Product { Id = 3,Name = "Xbox",CategoryId = 2},
            new Product { Id = 4,Name = "Lavatrice",CategoryId = 4},
        };

        var query = category.GroupJoin(
            products,
            category => category.Id,
            products => products.Id,
            (category, matchingProucts) => new
            {
                CategoryName = category.Name,
                Product = matchingProucts.Select(p => p.Name)
            }
        );

        foreach (var item in query)
        {
            Console.WriteLine("Category: " + item.CategoryName);

            Console.WriteLine("Products:");
            foreach (var product in item.Product)
            {
                Console.WriteLine("- " + product);
            }

            Console.WriteLine();
        }



    }
}