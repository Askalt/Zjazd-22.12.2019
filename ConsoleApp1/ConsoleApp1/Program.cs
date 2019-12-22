using System;

namespace ConsoleApp10
{

    //   public class Printer
    //    {
    //        bool paperOK;
    //        private int _paperCount; 
    //         public event EventHandler<OutofpaperEventArgs> Out_of_paper;
    //                   int paper_count;


    //        public void Print()
    //        {
    //            OutOfPaperEvent.Invoke(this, EventArgs.Empty);
    //        }
    //        private void OutOfPaperEventHandler(object sender,EventArgs args)
    //        {
    //            Console.WriteLine($"[Printer log]{DateTime.Now}  Out of paper");
    //        }
    //        private Printer()
    //        {
    //            OutOfPaperEvent += OutOfPaperEventHandler;
    //        }
    //        public Printer(int paperCount):this()
    //        {
    //            _paperCount = paperCount;

    //        }

    //        public void Print(int pageNumber)
    //        {
    //            if (_paperCount==0)
    //            {

    //            }
    //        }
    //    }        


    //    class Program
    //    {
    //        static void Main(string[] args)
    //        {
    //             bool printOK = true;

    //            var printer = new Printer(100);
    //            printer.OutOfPaperEvent += OutOfPaperHandler2;
    //            for (int i = 0; i < 250; i++)
    //            {
    //                printer.Print(i);
    //                if (!printOK)
    //                {
    //                    return;
    //                }
    //            }
    //        }

    //        static void Print()
    //        {

    //        }
    //        static void OutOfPaperHandler2(object sender)
    //        {

    //        }

    //    }
    //}

    using System;

    namespace Zjazd_nr_8
    {
        class Program
        {
            class Use_Ink
            {
                public event EventHandler<OutofinkEventArgs> Out_of_ink;
                int ink_count;
            }
            class Printer
            {
                public event EventHandler<OutofpaperEventArgs> Out_of_paper;
                public event EventHandler<OutofinkEventArgs> Out_of_ink;
                int paper_count;
                int ink_count;


                public Printer(int paper_count)
                {
                    this.paper_count = paper_count;
                }
                public void print(int page_number)
                {
                    Out_of_paper.Invoke(this, new OutofpaperEventArgs(page_number));
                }
                private void Outofpaperevent(object sender, EventArgs args)
                {
                    Console.WriteLine("print out of paper");
                }
                public void Print(int n)
                {
                    if (paper_count == 0)
                    {
                        Out_of_paper?.Invoke(this,
                            new OutofpaperEventArgs(n));
                        return;
                    }
                    else
                    {
                        paper_count--;
                        Console.WriteLine("{0} Pags_Print...", n);
                    }
                }


            }
            public class OutofpaperEventArgs : EventArgs
            {
                int page_number;
                public OutofpaperEventArgs(int page_number)
                {
                    this.page_number = page_number;

                }

            }

            static void Main(string[] args)
            {
                bool printOK = true;
                var drukarka = new Printer(100);
                drukarka.Out_of_paper += Out_of_Paper2;

                for (int i = 1; i < 110; i++)
                {

                    drukarka.Print(i);
                    if (!printOK)
                    {
                        return;
                    }

                }
                Console.ReadLine();

            }
            static void Out_of_Paper2(object sender, EventArgs args)
            {

                Console.WriteLine("Brak papieru !!!");

            }

        }

    }
}