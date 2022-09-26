using BooksDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDbContext.Repositories
{
    public class BooksRepository
    {
        BooksDbContext db;
        public BooksRepository()
        {
            db= new BooksDbContext();   
        }
        public bool addBook(Book book)
        {
            try
            {
                db.Books.Add(book);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool AddBooks(List<Book> books)
        {
            try
            {
                db.Books.AddRange(books);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<Book> getBookByTitle(string title)
        {
            return db.Books.Where(p => p.Title.Contains(title)).ToList();
        }
        public Book getBookById(int Id)
        {
            var book = db.Books.FirstOrDefault(p => p.Id == Id);
            return book;
        }
        public bool removeBook(int Id)
        {
            try
            {

                Book book= db.Books.FirstOrDefault(p => p.Id == Id);
                bool output= removeBook(book);
                return output;
            }
            catch
            {
                return false;
            }
        }
        public bool removeBook(Book book)
        {
            try
            {
                db.Books.Remove(book);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool editBook(int newPrice,string newTitle,int Id)
        {
            try
            {
                Book book = db.Books.FirstOrDefault(p => p.Id == Id);
                book.Price = newPrice;
                book.Title = newTitle;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public int getTotalCopies()
        {
            return db.Books.Sum(p => p.CopiesNumber);
        }
        public List<Book> GetBooks()
        {
            return db.Books.ToList();
        }
    }
}
