Library library = new Library();

// Main Loop
while (true)
{
  Console.WriteLine("Please write something, then hit 'enter'");
  string? userInput = Console.ReadLine();
  if (userInput == null)
  {
    throw new Exception("Could not read user input");
  }

  switch (userInput)
  {
    case "list":
      List<Book> availableBooks = library.ListAvailableBooks();

      foreach (var book in availableBooks)
      {
        Console.WriteLine($"Title: {book.Title}");
      }
      break;
    case "borrow":
      Console.WriteLine("Boorowing a book");
      break;
    case "return":
      Console.WriteLine("Returning a book");
      break;
    default:
      Console.WriteLine("Unrecognized command");
      break;
  }
}