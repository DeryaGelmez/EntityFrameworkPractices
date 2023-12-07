using EntityFrameworkPractices.Entities;
using EntityFrameworkPractices;
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        using (var context = new AppDbContext())
        {
            DeleteProduct(context, 1);
            AddProducts(context);
            UpdateProduct(context, 2);
        }
    }

    static void DeleteProduct(AppDbContext context, int productId)
    {
        var productToDelete = context.Products.FirstOrDefault(p => p.Id == productId);

        if (productToDelete != null)
        {
            context.Products.Remove(productToDelete);
            context.SaveChanges();
            Console.WriteLine("Ürün başarıyla silindi.");
        }
        else
        {
            Console.WriteLine("Belirtilen ID'ye sahip ürün bulunamadı.");
        }
    }

    static void AddProducts(AppDbContext context)
    {
        var newProducts = new List<Product>
        {
            new Product { Name = "Ürün1", Price = 100, CategoryId = 1 },
            new Product { Name = "Ürün2", Price = 150, CategoryId = 1 },
        };

        context.Products.AddRange(newProducts);
        context.SaveChanges();
        Console.WriteLine("Ürünler başarıyla eklendi.");
    }

    static void UpdateProduct(AppDbContext context, int productId)
    {
        var productToUpdate = context.Products.FirstOrDefault(p => p.Id == productId);

        if (productToUpdate != null)
        {
            productToUpdate.Name = "Yeni Ürün Adı";
            productToUpdate.Price = 200;

            context.SaveChanges();
            Console.WriteLine("Ürün başarıyla güncellendi.");
        }
        else
        {
            Console.WriteLine("Belirtilen ID'ye sahip ürün bulunamadı.");
        }
    }
}
