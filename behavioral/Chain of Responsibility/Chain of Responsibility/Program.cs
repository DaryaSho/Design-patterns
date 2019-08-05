using System;
using System.Collections.Generic;

namespace Chain_of_Responsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Reader> readers = new List<Reader>()
            {
                new Reader(true, false, false),
                new Reader(false, true, false),
                new Reader(false, false, true)
            };           
            Shelf newspaperShelf = new NewspaperShelf();
            Shelf bookShelf = new BookShelf();
            Shelf magazineShelf = new MagazineShelf();
            bookShelf.Successor = magazineShelf;
            magazineShelf.Successor = newspaperShelf;


            readers.ForEach(x => bookShelf.Handle(x));
            Console.Read();
        }
    }
    class Reader
    {
        public bool Newspaper { get; set; }
        public bool Book { get; set; }
        public bool Magazine { get; set; }
        public Reader (bool newspaper, bool book, bool magazine)
        {
            Newspaper = newspaper;
            Book = book;
            Magazine = magazine;
        }
    }
    abstract class Shelf
    {
        public Shelf Successor { get; set; }
        public abstract void Handle(Reader reader);
    }

    class NewspaperShelf : Shelf
    {
        public override void Handle(Reader reader)
        {
            if (reader.Newspaper == true)
            {
                Console.WriteLine("Read Newspaper!");
            }
            else if (Successor != null)
            {
                Successor.Handle(reader);
            }
        }
    } 
    class MagazineShelf : Shelf
    {
        public override void Handle(Reader reader)
        {
            if (reader.Magazine == true)
            {
                Console.WriteLine("Read Magazine!");
            }
            else if (Successor != null)
            {
                Successor.Handle(reader);
            }
        }
    }
    class BookShelf : Shelf
    {
        public override void Handle(Reader reader)
        {
            if (reader.Book == true)
            {
                Console.WriteLine("Read Book!");
            }
            else if (Successor != null)
            {
                Successor.Handle(reader);
            }
        }
    }
}
