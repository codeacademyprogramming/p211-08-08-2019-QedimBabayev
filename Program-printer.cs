using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("xahis reng tokesiz");
            decimal rengmiqdari = decimal.Parse(Console.ReadLine());
            Console.WriteLine("vereq yukleyin");
            int vereqmiqdari = int.Parse(Console.ReadLine());
            Printer printer = new Printer(rengmiqdari, vereqmiqdari);
            Console.WriteLine("printeri ise salin");
            printer.PrintOn();
            Console.WriteLine("print edeceyiviz sayi daxil edin");
            int cap = int.Parse(Console.ReadLine());
            printer.ToPrint(cap);

            Console.WriteLine("yeni reng elave etmek isteyirsniz?");
            decimal yenirengmiqdari = decimal.Parse(Console.ReadLine());
            printer.FilledInk(yenirengmiqdari);

            int yenicap = int.Parse(Console.ReadLine());


            printer.ToPrint(yenicap);

            Console.WriteLine("yeni sehife elave etmek isteyirsniz?");


            int yenivereqmiqdari = int.Parse(Console.ReadLine());

            printer.LoadPaper(yenivereqmiqdari);


            int yenicap1 = int.Parse(Console.ReadLine());
            printer.ToPrint(yenicap1);

            printer.PrintOff();







        }
    }

    class Printer
    {
        public string PrinterName { get; set; }

        private decimal _cartridge;

        public decimal Cartridge
        {
            get { return _cartridge; }
            set

            {
                _cartridge = value;
                if(value <= 0 && InkFinished != null)
                {
                    InkFinished += () =>
                    {
                        Console.WriteLine("kartridgede reng bitib");
                    };
                    InkFinished();


                }


            }
        }


        private int _paper;

        public int Paper
        {
            get { return _paper; }
            set {
                _paper = value;
                if(value <= 0 && PageFinished != null)
                {
                    PageFinished += () =>
                    {
                        Console.WriteLine("kagiz bitib");
                    };
                    PageFinished();

                }
            }
        }


        public Printer(decimal reng, int vereq)
        {
            Paper = vereq;
            Cartridge = reng;

            InkFilled += () =>
            {
                Console.WriteLine("reng doldu");
            };
            InkFilled();
            PageLoaded += () =>
             {
                 Console.WriteLine("vereqler yuklendi");
             };
            PageLoaded();


        }



        public event Action PrinterOn;
        public event Action PrinterOff;
        public event Action PageFinished;
        public event Action InkFinished;
        public event Action Print;
        public event Action PageLoaded;
        public event Action InkFilled;  

        public void PrintOn()
        {
            Console.WriteLine("printer ise dushdu");

            PrinterOn += () =>
            {
                Console.WriteLine("xos geldiniz");
            };

            PrinterOn();
        }

        public void PrintOff()
        {
            Console.WriteLine("printer sondu");

            PrinterOff += () =>
            {
                Console.WriteLine("printer artiq sonmusdur");
            };
            PrinterOff();

        }


        public void LoadPaper (int vereqsayi)
        {
            Paper += vereqsayi;

        }
        public void FilledInk(decimal rengmiqdari)
        {
            Cartridge += rengmiqdari;

        }

        public void ToPrint(int capSayi)
        {
          

            for (int i = 0; i < capSayi; i++)
            {
                Cartridge -= 0.1M;
                Paper -= 1;



            }
         
                if(Cartridge <= 0)
            {
                Console.WriteLine("reng bitdi");

                return;


             
            

            }
            else if(Paper <=0)
            {
                Console.WriteLine("sehife bitdi");
                return;
             
            }


            Console.WriteLine("cap basa catdi");


        }
    }
}
