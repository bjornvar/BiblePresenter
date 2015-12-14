using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblePresenter
{
    [Serializable()]
    class Bible
    {
        Dictionary<String, Book> books = new Dictionary<String, Book>();

        public void addVerse(string book, int chapter, int verse, string text)
        {
            Book b;
            books.TryGetValue(book, out b);
            if (null == b)
            {
                b = new Book();
                books.Add(book, b);
            }
            b.addVerse(chapter, verse, text);
        }

        public string getVerse(string book, int chapter, int verse)
        {
            Book b;
            books.TryGetValue(book, out b);
            return b.getVerse(chapter, verse);
        }

        public IEnumerable<string> getBookList()
        {
            return books.Keys;
        }

        public IEnumerable<int> getChapterList(string book)
        {
            Book b;
            books.TryGetValue(book, out b);
            return b.getChapterList();
        }

        public IEnumerable<int> getVerseList(string book, int chapter)
        {
            Book b;
            books.TryGetValue(book, out b);
            return b.getVerseList(chapter);
        }
    }

    [Serializable()]
    class Book
    {
        Dictionary<int, Chapter> chapters = new Dictionary<int, Chapter>();

        public void addVerse(int chapter, int verse, string text)
        {
            Chapter c;
            chapters.TryGetValue(chapter, out c);
            if (null == c)
            {
                c = new Chapter();
                chapters.Add(chapter, c);
            }
            c.addVerse(verse, text);
        }

        public string getVerse(int chapter, int verse)
        {
            Chapter b;
            chapters.TryGetValue(chapter, out b);
            return b.getVerse(verse);
        }

        public IEnumerable<int> getChapterList()
        {
            return chapters.Keys;
        }

        public IEnumerable<int> getVerseList(int chapter)
        {
            Chapter c;
            chapters.TryGetValue(chapter, out c);
            return c.getVerseList();
        }
    }

    [Serializable()]
    class Chapter
    {
        Dictionary<int, string> verses = new Dictionary<int, string>();

        public void addVerse(int verse, string text)
        {
            verses.Add(verse, text);
        }

        public string getVerse(int verse)
        {
            string verseText;
            verses.TryGetValue(verse, out verseText);
            return verseText;
        }

        public IEnumerable<int> getVerseList()
        {
            return verses.Keys;
        }
    }
}
