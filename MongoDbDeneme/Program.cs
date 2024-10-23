using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace MongoDbDeneme;

class Program
{
    static void Main(string[] args)
    {
        MongoClient client = new MongoClient("mongodb+srv://mongo:41264126@cluster0.2ljuy.mongodb.net/");

        var database = client.GetDatabase("Northwind");

        var collection = database.GetCollection<Customer>("customers");

        #region Veri Ekleme (Insert)

        //Customer customernew = new Customer()
        //{
        //    _id = 33,
        //    company = "Rosein LLC",
        //    last_name = "Kardes",
        //    first_name = "Gulin",
        //    job_title = "Owner",
        //    business_phone = "(123)555-0134",
        //    fax_number = "(123)555-0123",
        //    address = "30 N Gould Street",
        //    city = "Sheridan",
        //    state_province = "WY",
        //    zip_postal_code = 99999,
        //    country_region = "USA"
        //};

        //collection.InsertOne(customernew);

        //Category categorynew = new Category()
        //{
        //     _id = "12",
        //     CategoryId =12,
        //     CategoryName= "Tekstil",
        //     Description = "Textil"

        //};

        //var collection2 = database.GetCollection<Category>("categories");

        //collection2.InsertOne(categorynew);
        #endregion

        #region Read İslemi

        //var customer = collection.Find(p => p.first_name == "Karen").FirstOrDefault();
        //Console.WriteLine($"Musteri Sirketi: {customer.company}, Musteri Id: {customer._id}, Musteri Adı: {customer.first_name}");

        //var collection2 = database.GetCollection<Category>("categories");
        //var category = collection2.Find(p => p.CategoryName == "Tekstil").FirstOrDefault();

        //Console.WriteLine($"Kategori Adi: {category.CategoryName} Kategori Id: {category.CategoryId}" );




        #endregion

        #region Update Islemi

        //var sehirdegistir = Builders<Customer>.Update.Set(p=> p.city, "Izmir");

        //collection.UpdateOne(c => c._id == 33, sehirdegistir);


        #endregion

        #region Delete Islemi

        collection.DeleteOne(p=> p._id==0);
        collection.DeleteOne(p => p._id == 30);
        collection.DeleteOne(p => p._id == 31);



        #endregion
    }
}

public class Customer
{
    [BsonId]  // MongoDB için _id alanı
    public int _id { get; set; }

    public string company { get; set; }
    public string last_name { get; set; }
    public string first_name { get; set; }
    public string job_title { get; set; }
    public string business_phone { get; set; }
    public string fax_number { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state_province { get; set; }
    public int zip_postal_code { get; set; }
    public string country_region { get; set; }
}

public class Category
{
    [BsonId]
    public string _id { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
}

