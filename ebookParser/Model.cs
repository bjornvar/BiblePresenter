using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebookParser
{
    public class Model
    {
        public String path { get; private set; }
        LinkedList<Book> bible = new LinkedList<Book>();

        public Model(String path)
        {
            this.path = path;
        }

        class Book
        {
            String bookName;
            LinkedList<Chapter> chapters = new LinkedList<Chapter>();
        }

        class Chapter
        {
            int chapterNumber;
            LinkedList<Verse> verses = new LinkedList<Verse>();
        }

        class Verse
        {
            int verseNumber;
            String text;
        }
    }
}
