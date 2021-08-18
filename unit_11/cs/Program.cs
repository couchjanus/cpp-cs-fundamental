using System;
using System.Collections;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            // Вызов library.GetBooks(5) будет возвращать набор из не более чем 5 объектов Book. Но так как у нас всего три таких объекта, то в методе GetBooks после трех операций сработает оператор yield break.

            foreach (Book b in library.GetBooks(5))
            {
                Console.WriteLine(b.Name);
            }
        }
    }
 
    class Book
    {
        public Book(string name)
        {
            this.Name=name;
        }
        public string Name { get; set; }
    }
 
class Library
{
    private Book[] books;
 
    public Library()
    {
        books = new Book[] { new Book("Отцы и дети"), new Book("Война и мир"), 
            new Book("Евгений Онегин") };
    }
 
    public int Length
    {
        get { return books.Length; }
    }
    // итератор - метод IEnumerable GetBooks(int max) в качестве параметра принимает количество выводимых объектов. 

    public IEnumerable GetBooks(int max)
    {
        for (int i = 0; i < max; i++)
        {
            // В процессе работы программы может сложиться, что его значение будет больше, чем длина массива books. И чтобы не произошло ошибки, используется оператор yield break. Этот оператор прерывает выполнение итератора. 
            if (i == books.Length)
            {
                yield break;
            }
            else
            {
                yield return books[i];
            }
        }
    }
}
}
