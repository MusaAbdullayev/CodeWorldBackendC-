using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; // Sum() metodu üçün lazımdır

namespace OnlineStore
{
    // Məhsul sinfi
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }

    // Səbət sinfi
    public class ShoppingCart
    {
        // Səbətin içini gizli saxlayırıq (private)
        private List<Product> items;

        public ShoppingCart()
        {
            // List istifadə etmək üçün onu yaratmaq (new) mütləqdir
            items = new List<Product>();
        }

        // Məhsul əlavə etmə
        public void AddProduct(Product product)
        {
            items.Add(product);
            Console.WriteLine($"{product.Name} səbətə əlavə olundu.");
        }

        // Məhsul silmə
        public void RemoveProduct(int productId)
        {
            // RemoveAll: Şərtə uyğun gələn bütün elementləri silir.
            // p => p.Id == productId : "Elə məhsulu tap ki, ID-si verilən rəqəm olsun"
            int removedCount = items.RemoveAll(p => p.Id == productId);

            if (removedCount > 0)
                Console.WriteLine($"ID: {productId} olan məhsul silindi.");
            else
                Console.WriteLine("Bu ID ilə məhsul tapılmadı.");
        }

        // Cəmi hesablama
        public decimal CalculateTotalPrice()
        {
            // items.Sum dövr (loop) qurmadan qiymətləri toplayır
            return items.Sum(p => p.Price);
        }

        // Ekrana çıxarma
        public void DisplayItems()
        {
            Console.WriteLine("\n--- Səbətin Vəziyyəti ---");
            if (items.Count == 0)
            {
                Console.WriteLine("Səbətiniz boşdur.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Price} AZN");
                }
                Console.WriteLine($"Ümumi Məbləğ: {CalculateTotalPrice()} AZN");
            }
            Console.WriteLine("-------------------------\n");
        }
    }

    // Proqramın işə düşdüyü hissə
    class ProgramTask1
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();

            // Məhsulları yaradıb əlavə edirik
            cart.AddProduct(new Product(1, "Notebook", 1500.50m));
            cart.AddProduct(new Product(2, "Mouse", 25.00m));
            cart.AddProduct(new Product(3, "Keyboard", 45.99m));

            // Hazırkı vəziyyət
            cart.DisplayItems();

            // Mouse-u silirik (ID: 2)
            cart.RemoveProduct(2);

            // Son vəziyyət
            cart.DisplayItems();
        }
    }
}


//*************************************************************************
//TASK 2: KİTABXANA SİSTEMİ(Dictionary və HashSet istifadəsi)
//*************************************************************************
//Məqsəd: Dictionary ilə açar söz (Key) vasitəsilə sürətli axtarış və 
//HashSet ilə unikallığın qorunması.


namespace LibrarySystem
{
    public class Book
    {
        public string ISBN { get; set; } // Unikal kod
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string isbn, string title, string author)
        {
            ISBN = isbn;
            Title = title;
            Author = author;
        }
    }

    public class Library
    {
        // Bütün kitablar: ISBN-ə görə kitabın özünü tapmaq üçün Dictionary
        private Dictionary<string, Book> allBooks;

        // Borc verilənlər: Sadəcə ISBN-ləri saxlayan unikal siyahı (HashSet)
        private HashSet<string> borrowedBooks;

        public Library()
        {
            allBooks = new Dictionary<string, Book>();
            borrowedBooks = new HashSet<string>();
        }

        // Kitabxanya yeni kitab qeydiyyatı
        public void AddBook(Book book)
        {
            // Eyni ISBN ikinci dəfə əlavə edilə bilməz
            if (allBooks.ContainsKey(book.ISBN))
            {
                Console.WriteLine($"Xəbərdarlıq: {book.ISBN} nömrəli kitab artıq var.");
            }
            else
            {
                allBooks.Add(book.ISBN, book);
                Console.WriteLine($"Əlavə olundu: {book.Title}");
            }
        }

        // Kitabı oxucuya vermək
        public void BorrowBook(string isbn)
        {
            // 1. Kitabxanada varmı?
            if (!allBooks.ContainsKey(isbn))
            {
                Console.WriteLine("Xəta: Kitab tapılmadı.");
                return;
            }

            // 2. Başqasındadırmı? (HashSet-də axtarış çox sürətlidir)
            if (borrowedBooks.Contains(isbn))
            {
                Console.WriteLine($"Xəta: '{allBooks[isbn].Title}' kitabı hal-hazırda məşğuldur.");
            }
            else
            {
                borrowedBooks.Add(isbn);
                Console.WriteLine($"Uğurlu: '{allBooks[isbn].Title}' oxucuya verildi.");
            }
        }

        // Kitabı geri almaq
        public void ReturnBook(string isbn)
        {
            // HashSet-dən silirik. Əgər silinərsə true qaytarır.
            if (borrowedBooks.Remove(isbn))
            {
                Console.WriteLine($"Təşəkkürlər: '{allBooks[isbn].Title}' qaytarıldı.");
            }
            else
            {
                Console.WriteLine("Bu kitab onsuz da borc verilməyib.");
            }
        }

        // ISBN ilə axtarış
        public void FindBookByISBN(string isbn)
        {
            if (allBooks.TryGetValue(isbn, out Book book))
            {
                Console.WriteLine($"Tapıldı: {book.Title} - {book.Author}");
            }
            else
            {
                Console.WriteLine("Kitab tapılmadı.");
            }
        }
    }

    class ProgramTask2
    {
        static void Main(string[] args)
        {
            Library lib = new Library();

            lib.AddBook(new Book("12345", "Səfillər", "V.Hüqo"));
            lib.AddBook(new Book("67890", "Cinayət və Cəza", "F.Dostoyevski"));

            // Kitabı veririk
            lib.BorrowBook("12345");

            // Eyni kitabı təkrar istəyirik (Xəta verməlidir)
            lib.BorrowBook("12345");

            // Kitabı qaytarırıq
            lib.ReturnBook("12345");

            // İndi yenidən verə bilərik
            lib.BorrowBook("12345");
        }
    }
}


//*************************************************************************
//TASK 3: TƏDBİR QEYDİYYATI(Override Equals və GetHashCode)
//*************************************************************************
//Məqsəd: HashSet -in xüsusi siniflər(Participant) üçün necə işlədiyini
//görmək. Email eyni olduqda obyektləri eyni qəbul etmək üçün Override edirik.

namespace EventSystem
{
    public class Participant
    {
        public string FullName { get; set; }
        public string Email { get; set; } // Unikal identifikator

        public Participant(string fullName, string email)
        {
            FullName = fullName;
            Email = email;
        }

        // VACİB HİSSƏ 1: Obyektlərin bərabərliyini yoxlayır
        public override bool Equals(object obj)
        {
            if (obj is Participant other)
            {
                // Adlar fərqli olsa belə, emaillər eynidirsə, deməli eyni adamdır
                // OrdinalIgnoreCase: Böyük-kiçik hərf fərqini nəzərə alma (A@a.com == a@a.com)
                return this.Email.Equals(other.Email, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        // VACİB HİSSƏ 2: Obyektin unikal kodunu qaytarır
        // HashSet birinci bura baxır. Əgər HashCode-lar eynidirsə, sonra Equals-a baxır.
        public override int GetHashCode()
        {
            return this.Email.ToLower().GetHashCode();
        }
    }

    public class Event
    {
        public string EventName { get; set; }
        private HashSet<Participant> attendees;

        public Event(string eventName)
        {
            EventName = eventName;
            attendees = new HashSet<Participant>();
        }

        // Qeydiyyat
        public bool RegisterParticipant(Participant participant)
        {
            // HashSet.Add metodu bizim yazdığımız Equals metodunu işlədərək 
            // dublikat olub-olmadığını yoxlayır.
            // Uğurludursa true, artıq varsa false qaytarır.
            return attendees.Add(participant);
        }

        public IEnumerable<Participant> GetAllAttendees()
        {
            return attendees;
        }

        // Statik metod (Interface gücünü göstərir)
        public static void PrintAttendees(IEnumerable<Participant> participants)
        {
            Console.WriteLine("--- İştirakçılar ---");
            foreach (var p in participants)
            {
                Console.WriteLine($"{p.FullName} ({p.Email})");
            }
            Console.WriteLine("--------------------");
        }
    }

    class ProgramTask3
    {
        static void Main(string[] args)
        {
            Event myEvent = new Event(".NET Konfransı");

            Participant p1 = new Participant("Əli", "ali@code.az");
            Participant p2 = new Participant("Vəli", "veli@code.az");

            // p3 fərqli obyektdir, amma emaili p1 ilə eynidir.
            // Məntiqimizə görə bu DUBLİKAT sayılmalıdır.
            Participant p3 = new Participant("Əlii (Başqa adla)", "ali@code.az");

            Console.WriteLine($"Qeydiyyat P1: {myEvent.RegisterParticipant(p1)}"); // True
            Console.WriteLine($"Qeydiyyat P2: {myEvent.RegisterParticipant(p2)}"); // True
            Console.WriteLine($"Qeydiyyat P3: {myEvent.RegisterParticipant(p3)}"); // False (Çünki email eynidir)

            // Siyahını çıxarırıq
            Event.PrintAttendees(myEvent.GetAllAttendees());
        }
    }
}