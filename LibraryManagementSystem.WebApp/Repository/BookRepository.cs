
namespace LibraryManagementSystem.WebApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Korkma Ben Varım",
                    Author = "Murat Menteş",
                    PublicationYear = 2024,
                    ISBN="9786254490675",
                    Genre="Roman (Yerli)",
                    Publisher="ALFA YAYINLARI",
                    PageCount=480,
                    Language="TÜRKÇE",
                    AvailableCopies=5,
                    Summary="Tuhaf adamlar acayip koşullarda lazım olabilir.”\r\nFu, Gönül İşleri Bakanlığı’nın 22 üyesini katledenleri bulabilecek mi?\r\nMüntekim Gıcırbey başkalarının intikamını alarak nereye varacak?",
                    ImageUrl="korkma_ben.jpeg"
                },
                new Book { Id = 2, Title = "Kan,Ter ve Pikseller",
                    Author = "Jason Schreier",
                    PublicationYear = 2021,
                    ISBN="9786257737548",
                    Genre="Popüler Bilim",
                    Publisher="İTHAKİ YAYINLARI",
                    PageCount=280,
                    Language="TÜRKÇE",
                    AvailableCopies=10,
                    Summary="Video oyunları geliştirmek… Kahramanca bir yolculuk mu yoksa aptalca bir çaba mı? Jason Schreier, Kan, Ter ve Pikseller’de oyun geliştiriciliğinin perde arkasını gösteriyor ve okurlarını, yaratıcıların bazen uzun saatler çalıştırılan altı yüz kişilik ekiplerden, bazen de yalnız bir bilgisayar dâhisinden oluştuğu sularda heyecanlı bir yolculuğa çıkarıyor",
                    ImageUrl="kan_ter.jpeg"
                },
                new Book { Id = 3, Title = "Son Dilek (The Witcher)",
                    Author = "Andrzej Sapkowski",
                    PublicationYear = 2017,
                    ISBN="9786052990186",
                    Genre="Roman (Çeviri)",
                    Publisher="PEGASUS YAYINLARI",
                    PageCount=400,
                    Language="TÜRKÇE",
                    AvailableCopies=20,
                    Summary="Rivyalı Geralt bir Witcher’dır. Henüz küçük bir çocukken seçilmiş, eğitilmiş, büyülerle donatılmış ve mutasyon geçirmiş bir canavar avcısı. Acımasız, tekinsiz, karanlık ve canavarlarla dolu bir dünyada yaşar.",
                    ImageUrl="witcher_son_dilek.jpeg"
                },
                new Book { Id = 4, Title = "Dijital Kale",
                    Author = "Dan Brown",
                    PublicationYear = 2023,
                    ISBN="9789752112438",
                    Genre="Roman (Çeviri)",
                    Publisher="ALTIN KİTAPLAR",
                    PageCount=400,
                    Language="TÜRKÇE",
                    AvailableCopies=30,
                    Summary="Ulusal Güvenlik Teşkilatı dünyanın kaderini değiştirecek ve dijital ortamdaki tüm şifreli metinleri bilecek özel bir bilgisayar üretir. Ne var ki, günün birinde bu özel bilgisayar karşılaştığı esrarengiz bir şifreyi çözemez",
                    ImageUrl="dijital_kale.jpeg"}
            };
        }
        public List<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.FirstOrDefault(x => x.Id == id);
        }
    }
}
