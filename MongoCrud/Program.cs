using System.Security.Cryptography;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
namespace MongoCrud;

class Program
{
    public static IMongoClient client = new MongoClient("mongodb+srv://mongo:41264126@cluster0.2ljuy.mongodb.net/");


    static void Main(string[] args)
    {

        #region Mongo DataBase Listesi
        //var dblist = client.ListDatabases().ToList();

        //Console.WriteLine("Serverdaki Database Listesi:");

        //foreach (var item in dblist)
        //{
        //    Console.WriteLine(item);
        //}
        #endregion

        var database = client.GetDatabase("Northwind");

        //var collection = database.GetCollection<Customer>("customers");

        //Customer newcustomer = new Customer()
        //{
        //  _id= 27,
        //  company= "Rosein LLC",
        //  last_name= "Kardes",
        //  first_name= "Gulin",
        //  job_title = "Owner",
        //  business_phone = "(123)555-0134",
        //  fax_number = "(123)555-0123",
        //  address = "30 N Gould Street",
        //  city = "Sheridan",
        //  state_province = "WY",
        //  zip_postal_code = 99999,
        //  country_region = "USA"
        //};

        //collection.InsertOne(newcustomer);

        database.CreateCollection("categories");

        Category cat1 = new Category
        {
            _id = Guid.NewGuid().ToString(),//
            CategoryId = 11,
            CategoryName = "test2",
            Description = "test2"

        };

        Ekle<Category>("categories", cat1);

        ListOfCategories();

    }

    public static void ListOfCategories()
    {
        var tbl = client.GetDatabase("Northwind").GetCollection<BsonDocument>("categories");
        var kayitlar = tbl.Find<BsonDocument>(new BsonDocument()).ToList();
        foreach (var item in kayitlar)
        {
            Console.WriteLine($"Category Name: {item.GetValue("CategoryName")} _id:{item.GetValue("_id")}");
        }
    }
    public static bool Ekle<T>(string CollectiosName, object values)
    {
        try
        {
            var table = client.GetDatabase("Northwind").GetCollection<T>(CollectiosName);
            
            table.InsertOne((T)values);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

}


public class Category
{
    [BsonId]
    public string _id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}

//public class Customer
//{
//    [BsonId]  // MongoDB için _id alanı
//    public int _id { get; set; }

//    public string company { get; set; }
//    public string last_name { get; set; }
//    public string first_name { get; set; }
//    public string job_title { get; set; }
//    public string business_phone { get; set; }
//    public string fax_number { get; set; }
//    public string address { get; set; }
//    public string city { get; set; }
//    public string state_province { get; set; }
//    public int zip_postal_code { get; set; }
//    public string country_region { get; set; }
//}

