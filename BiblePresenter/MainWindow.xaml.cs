using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BiblePresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Presenter _presenter = new Presenter();
        Bible _bible = new Bible();
        const String _biblePath = @"C:\Users\Bjorn\Desktop\bible";

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists(_biblePath))
            {
                Stream TestFileStream = File.OpenRead(_biblePath);
                BinaryFormatter deserializer = new BinaryFormatter();
                _bible = (Bible)deserializer.Deserialize(TestFileStream);
                TestFileStream.Close();
            }
            else
            {
                _bible.addVerse("Genesis", 1, 1, "In the beginning God created the heavens and the earth.");
                _bible.addVerse("Genesis", 1, 2, "The earth was without form, and void; and darkness was on the face of the deep.");
                _bible.addVerse("Genesis", 1, 3, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Genesis", 1, 4, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Genesis", 2, 1, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Genesis", 2, 2, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Genesis", 2, 3, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Exodus", 1, 1, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Exodus", 1, 2, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Exodus", 2, 1, "And God saw the light, that it was good; and God divided the light from the darkness.");
                _bible.addVerse("Exodus", 3, 1, "And God saw the light, that it was good; and God divided the light from the darkness.");
            }
            lst_books.ItemsSource = _bible.getBookList();
        }

        private void btn_openPresenter_Click(object sender, RoutedEventArgs e)
        {
            _presenter.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            _presenter.Visibility = Visibility.Visible;
            this.Focus();
        }

        private void btn_sendVerse_Click(object sender, RoutedEventArgs e)
        {
            if ((null != lst_books.SelectedItem) && (null != lst_chapters.SelectedItem) && (null != lst_verses.SelectedItem))
            {
                _presenter.txt_verseRef.Text = lst_books.SelectedValue.ToString() + " " + lst_chapters.SelectedValue.ToString() + ", " + lst_verses.SelectedValue.ToString() + ":";
                _presenter.txt_verseBlock.Text = _bible.getVerse((string)lst_books.SelectedValue, (int)lst_chapters.SelectedValue, (int)lst_verses.SelectedValue);
            }
        }

        private void btn_clearVerse_Click(object sender, RoutedEventArgs e)
        {
            clearPresenter();
        }

        private void lst_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (null != lst_books.SelectedItem)
            {
                lst_chapters.ItemsSource = _bible.getChapterList((string)lst_books.SelectedValue);
            }
            lst_chapters.SelectedItem = null;
            lst_verses.SelectedItem = null;
            lst_verses.ItemsSource = null;
            clearPresenter();
        }

        private void lst_chapters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((null != lst_books.SelectedItem) && (null != lst_chapters.SelectedItem))
            {
                lst_verses.ItemsSource = _bible.getVerseList((string)lst_books.SelectedValue, (int)lst_chapters.SelectedValue);
            }
            lst_verses.SelectedItem = null;
            clearPresenter();
        }

        private void lst_verses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((null != lst_books.SelectedItem) && (null != lst_chapters.SelectedItem) && (null != lst_verses.SelectedItem))
            {
                txt_verseBlock.Text = _bible.getVerse((string)lst_books.SelectedValue, (int)lst_chapters.SelectedValue, (int)lst_verses.SelectedValue);
            }
            else
            {
                clearPresenter();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _presenter.Close();
            if (!File.Exists(_biblePath))
            {
                Stream TestFileStream = File.Create(_biblePath);
                BinaryFormatter serializer = new BinaryFormatter();
                serializer.Serialize(TestFileStream, _bible);
                TestFileStream.Close();
            }
        }

        private void clearPresenter()
        {
            _presenter.txt_verseRef.Text = "";
            _presenter.txt_verseBlock.Text = "";
        }
    }
}
