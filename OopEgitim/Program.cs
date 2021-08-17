using System;

namespace OopEgitim
{
    class Program
    {
        static void Main(string[] args)
        {
            int sayi1 = 10;
            int sayi2 = 20;
            sayi1 = sayi2;
            sayi2 = 100;
            Console.WriteLine("sayı1: " + sayi1);

            int[] sayilar1 = new[] { 1, 2, 3 };
            int[] sayilar2 = new[] { 10, 20, 30 };
            sayilar1 = sayilar2;
            sayilar2 = new[] { 7, 8, 9 };
            Console.WriteLine(sayilar2[0]);
            Console.WriteLine("sayılar1[0]: " + sayilar1[0]);

            CreditManager creditManager = new CreditManager();
            //creditManager.Calculate();
            //creditManager.Save();

            Customer customer = new Customer(); //örneğini oluşturmak, instance oluşturmak, instance creation
            customer.Id = 1;
            customer.City = "Ankara";
            //customer.NationalIdentity = "1234560";

            //CustomerManager customerManager = new CustomerManager(customer);
            //customerManager.Save();
            //customerManager.Save();
            //customerManager.Save();
            //customerManager.Save();
            //customerManager.Save();
            //customerManager.Delete();

            Company company = new Company();
            company.TaxNumber = "100000";
            company.CompanyName = "Arçelik";
            company.Id = 100;
            
            //CustomerManager customerManager1 = new CustomerManager(new Company());
            //CustomerManager customerManager2 = new CustomerManager(new Person());

            Person person = new Person();
            person.FirstName = "Engin";
            person.LastName = "Demiroğ";
            person.NationalIdentity = "123456";

            Customer c1 = new Customer();
            Customer c2 = new Person();
            Customer c3 = new Company();

            CustomerManager customerManager3 = new CustomerManager(new Customer(), new MilitaryCreditManager());
            customerManager3.GiveCredit();
            CustomerManager customerManager4 = new CustomerManager(new Customer(), new TeacherCreditManager());
            customerManager4.GiveCredit();
            CustomerManager customerManager5 = new CustomerManager(new Customer(), new CarCreditManager());
            customerManager4.GiveCredit();
        }
    }

    class CreditManager
    {
        //public void Calculate()
        //{
        //    Console.WriteLine("Hesaplandı");
        //}

        //public void Save()
        //{
        //    Console.WriteLine("Kredi Verildi");
        //}
    }

    interface ICreditManager
    {
        void Calculate();
        void Save();
    }

    abstract class BaseCreditManager : ICreditManager
    {
        public abstract void Calculate();
        public virtual void Save()
        {
            Console.WriteLine("kaydedildi");
        }
    }

    class TeacherCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Öğretmen kredisi hesaplandı");
        }
        public override void Save()
        {
            //önüne kod eklenebilir
            base.Save(); //bu abstractan gelen save fonk. İster kullan ister sil
            //sonuna kod eklenebilir
        }
    }

    class MilitaryCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            //hesaplamalar
            Console.WriteLine("Asker kredisi hesaplandı");
        }
    }

    class CarCreditManager : BaseCreditManager, ICreditManager
    {
        public override void Calculate()
        {
            Console.WriteLine("Araç kredisi hesaplandı");
        }
    }

    class Customer
    {
        public Customer()
        {
            Console.WriteLine("Müşteri nesnesi başlatıldı!");
        }
        public int Id { get; set; }
        public string City { get; set; }
    }

    class Person : Customer
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalIdentity { get; set; }
    }

    class Company : Customer
    {
        public string CompanyName { get; set; }
        public string TaxNumber { get; set; }
    }

    class CustomerManager
    {
        private Customer _customer;
        ICreditManager _creditManager;
        public CustomerManager(Customer customer, ICreditManager creditManager)
        {
            _customer = customer;
            _creditManager = creditManager;
        }
        public void Save()
        {
           // Console.WriteLine(_customer.FirstName + " adlı müşteri kaydedildi");
        }
        public void Delete()
        {
           // Console.WriteLine(_customer.FirstName + " adlı müşteri silindi");
        }
        public void GiveCredit()
        {
            _creditManager.Calculate();
            Console.WriteLine("Kredi verildi");
        }

    }

    //SOLID'e uygun olması için her sınıf sadece bir tür tutmalı görevleri ayrı ayrı olmalı
}
