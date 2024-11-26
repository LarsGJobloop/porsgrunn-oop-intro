class Library
{
  // Data
  List<Book> registeredBooks;
  Dictionary<Book, int> bookInventory;

  // Constructor
  public Library()
  {
    registeredBooks = new List<Book>();
    bookInventory = new Dictionary<Book, int>();

    Book book1 = new Book("Foundation");
    registeredBooks.Add(book1); // Legg til i bøker vi vet om
    bookInventory.Add(book1, 10); // Legg til i beholdning vår

    Book book2 = new Book("Martian");
    registeredBooks.Add(book2);
    bookInventory.Add(book2, 20);
  }

  // Metoder
  public List<Book> ListAvailableBooks()
  {
    return registeredBooks;
  }
}