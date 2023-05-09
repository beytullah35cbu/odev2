
namespace odev2
{




    public class Urun//Temel sınıf   yanı base
    {
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }

        //Metodun çok biçimli olduğunu bildirmek için virtual yazılır!
        public virtual double KDVUygula()  //ezılebılır ama zorunda degıl
        {
            return Fiyat * 1.08;//Ürün fiyatına %8 KDV ekler
        }

        public Urun() { }

        public Urun(string ad, double fiyat)
        {
            this.UrunAdi = ad; //this ad olarakda verebılırız
            this.Fiyat = fiyat;
        }
    }

    public class Tekstil : Urun   //urun sınıfından turedi
    {

        public string KumasTuru { get; set; }
        public int Beden { get; set; }

        public Tekstil(string ad, double fiyat, string kumasTuru, int beden)
        {
            UrunAdi = ad;
            Fiyat = fiyat;
            KumasTuru = kumasTuru;
            Beden = beden;
        }
    }

    public class CepTelefonu : Urun   //urun sınıfından turedı
    {
        public string Ozellikler { get; set; }
        public string Marka { get; set; }

        public CepTelefonu(string ad, double fiyat, string marka)
        {
            UrunAdi = ad;
            Fiyat = fiyat;
            Marka = marka;
        }

        //Farklı davranması gerektiği override ile belirtiliyor.
        public override double KDVUygula()  //ana methpdu ezıyor
        {
            return Fiyat * 1.30;
        }
    }

    public class Ekmek : Urun //urun sınıfından turedı
    {
        public string EkmekTuru { get; set; }
        public int Gramaj { get; set; }

        public Ekmek(string urunAdi, double fiyat, string ekmekTuru, int gramaj)
        {
            UrunAdi = urunAdi;
            Fiyat = fiyat;
            EkmekTuru = ekmekTuru;
            Gramaj = gramaj;
        }

        //Farklı davranması gerektiği override ile belirtiliyor.
        public override double KDVUygula() //ezılmek zorunda degıl
        {
            return Fiyat * 1.01;
        }
    }

    //odev ıcın eklendı cunku oyle ıstedı *_*

    public class Sut : Urun //odevde sut urunu olusturmamı ıstedı
    {
        public string Marka { get; set; }
        public double Hacim { get; set; }

        public Sut(string urunAdi, double fiyat, string marka, double hacim) 
        {
            UrunAdi = urunAdi;
            Fiyat = fiyat;
            Marka = marka;
            Hacim = hacim;
        }

        //overrıde ıle ana sınıfın methodunu degıstırdım  *_*  
        public override double KDVUygula()
        {
            return Fiyat * 1.05; //odevde yuzde 5 kdv olarak tanımlamamı ıstedı
        }
    }



















    public class Sepet
    {
        private List<Urun> urunler = new List<Urun>(); //urunler listesı

        public double ToplamTutar()
        {
            double toplamFiyat = 0;

            foreach (Urun item in urunler) //değerleri urunler lıstesıne aktar
            {
                toplamFiyat += item.KDVUygula(); //toplam fıyata ekle
            }

            return toplamFiyat; //son kdvlı fıyatı dondur
        }

        public void Ekle(Urun yeniUrun) //voıd oldugu ıcın return olmaz
        {
            urunler.Add(yeniUrun);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Sepet sepet = new Sepet(); //sepet sınıfından yenı nesne
            bool devamMi = true;

            while (devamMi) //devammı en sonda soru soruyor false olana kadar bu soruları sorucak  ve hepsını sepet degıskenıne eklıo
            {
                Console.Write("Ürün adı giriniz: ");
                string ad = Console.ReadLine();

                Console.Write("Ürün fiyatı giriniz: ");

                double fiyat = Convert.ToDouble(Console.ReadLine());

                Console.Write("Ürün türü (1:Ekmek, 2:Tekstil, 3:Cep Telefonu 4:Süt ürünü) giriniz: ");
                int tur = Convert.ToInt32(Console.ReadLine());

                switch (tur) //sorunun cevabına gore 3 tane case tanımı
                {




                    case 1:
                        Console.Write("Ekmek türü giriniz: ");
                        string ekmekTuru = Console.ReadLine();

                        Console.Write("Ekmek gramajı giriniz: ");
                        int gramaj = Convert.ToInt32(Console.ReadLine());

                        Ekmek ekmek = new Ekmek(ad, fiyat, ekmekTuru, gramaj);
                        sepet.Ekle(ekmek); //ekmek sectıysen ekmegın kdvsı hesaplanır ve sepete ekler
                        break; //case den cık






                    case 2:
                        Console.Write("Tekstil kumaş türü giriniz: ");
                        string kumasTuru = Console.ReadLine();

                        Console.Write("Tekstil bedenini giriniz: ");
                        int beden = Convert.ToInt32(Console.ReadLine());

                        Tekstil tekstil = new Tekstil(ad, fiyat, kumasTuru, beden);
                        sepet.Ekle(tekstil);
                        break;




                    case 3:
                        Console.Write("Cep telefonu markasını giriniz: ");
                        string marka = Console.ReadLine();

                        CepTelefonu cepTel = new CepTelefonu(ad, fiyat, marka);
                        sepet.Ekle(cepTel);
                        break;



           //sut sınıfı ekledıgım ıcın mecburen sut ıcın soru sormam lazım *_*  
                    case 4:
                        Console.Write("Süt markasını giriniz: ");
                        string sutMarka = Console.ReadLine();

                        Console.Write("Süt hacmini giriniz: ");
                        double sutHacim = Convert.ToDouble(Console.ReadLine());

                        Sut sut = new Sut(ad, fiyat, sutMarka, sutHacim);
                        sepet.Ekle(sut);
                        break;





                    default: //1 2 3  4 degerlerı dısında deger gırılırse //sutu ekledım 4ncu slot geldı
                        Console.WriteLine("Geçersiz ürün türü!");
                        break;
                }

                Console.Write("Alışverişe devam etmek istiyor musunuz? (E/H): ");
                string cevap = Console.ReadLine(); //cevap degıskınıne e veya h harfı ıstıyorum

                if (cevap.ToUpper() == "H") //h gırersen sepetı toplar ve switch
                {
                    devamMi = false;
                }
            }

            Console.WriteLine("Toplam tutar: " + sepet.ToplamTutar().ToString());
            Console.ReadKey();
        }
    }


}