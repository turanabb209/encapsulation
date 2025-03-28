using System.Diagnostics.Metrics;
using System.Security.Cryptography;
using System;

namespace Encapsulation_Record
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Apple", "Iphone13", 1500.0, 1000.0, 4);
            product.BrandName ="Apple";
            product.Model = "Iphone13";
            product.Price = 1500.0;
            product.Cost = 1000.0;
            product.Count =8;

           // product.GetInfo();


            product.Sale(8);

           
         
          

        }
    }
    // Product classi yaradirsiz:
    // Id, BrandName, Model, Price, Cost -xercleri, Income -umumi gelir, Count - mehsulun sayi  fieldleri olur.
    class Product
    {
        private string _id ;
        private string _brandName;
        private string _model;
        private double _price;
        private double _cost;
        private double _income;
        private int _count;
        private int n;
        // QEYD:Butun fieldler encapsule edilmelidir. Encapsule shertlerini ozunuz mentiqle qurun.

        public int Id
        {
            get
            {
                return Id;
            }
            
        }
        public string BrandName
        {
            get
            {
                return _brandName;
            }
            set
            {
                _brandName = value;
            }
        }
        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        public double Price
        {
            get
            {
                return _price;
            }
            set
            {
                _price = value;
            }
        }
        public double Cost
        {
            get
            {
                return _cost;
            }
            set
            {
                _cost = value;
            }
        }
        public double Income
        {
            get
            {
                return _income;
            }
            set
            {
                _income = value;
            }
        }
        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }
        // Constructor ishe dushdukde Income ve Id-den bashqa butun deyerleri qebul edir.
        // (Income 0 - dan bashliyib mehsul satildiqca artacaq.Count menfi ola bilmez.Menfi gonderilerse 0 verilsin).
        // Id - ni ctor ishe dushdukde(yəni constructorun icerisinde).
        // BrandName ilk 2 simvolunu Modelin ilk 2 simvolunu birleshdirerek teyin edirsiz.
        // Meselen(Brand adi: Apple, Model: Iphone13 dirse Id: ApIp olmalidir)
        public Product(string brandName, string model, double price, double cost, int count)
        {
            _brandName = brandName;
            _model = model;
            _price = price;
            _cost = cost;
            _count = count;
            if (count < 0)
            {
                count = 0;
            }

            _income = 0;
            

            if ( brandName.Length >= 2 && model.Length >= 2)
            {
                brandName = brandName.Replace(" ","");
                model = model.Replace(" ", "");
                _id = brandName.Substring(0, 2) + model.Substring(0, 2); 
            }
            else
            {
                _id = "XXXX";
            }

        }
        // GetInfo() ve  Sale() methodlari olur.
    
        public void GetInfo()
        {
            {
                Console.WriteLine($"ID: {_id}");
                Console.WriteLine($"Brand: {_brandName}");
                Console.WriteLine($"Model: {_model}");
                Console.WriteLine($"Price: {_price} manat");
                Console.WriteLine($"Cost: {_cost} manat");
                Console.WriteLine($"Income: {_income} manat");
                Console.WriteLine($"Count: {_count} dene");
            }
        }
        // Eger kifayet qeder mehsul varsa Satishi heyata kecirir satilan qiymetden xercler cixilaraq gelire elave edir ve mehsul sayini azaldir.


        public void Sale(int n)
        {  //satmaq istediyim mehsul sayini n qebul edirem
            if ( n <= Count)
            {
                Income += (Price - Cost) * n;
                Count -= n;

                Console.WriteLine("income :"+ Income); 
            }
            else
            {
                Console.WriteLine("satis ucun mehsul yoxdur");
            }

        }
    }

}
