TerminalUserInterface ui = new TerminalUserInterface();
Library library = new Library();

// Main Loop
while (true)
{
  string userInput = ui.Request<string>("Write your option, then hit 'enter'\nOptions:\n- list\n- borrow\n- return");

  switch (userInput)
  {
    case "list":
      List<Book> availableBooks = library.ListAvailableBooks();

      ui.Send($"Available books:");
      foreach (var book in availableBooks)
      {
        ui.Send($"\tTitle: {book.Title}");
      }
      break;
    case "borrow":
      string? bookTitle = ui.Request<string>("Please give title for book:");

      Book? borrowedBook = library.BorrowBook(bookTitle);
      if (borrowedBook == null)
      {
        ui.Send($"Sorry, no book with title {bookTitle} available");
      }
      else
      {
        ui.Send($"Book with title {borrowedBook.Title} borrowed!");
      }

      break;
    case "return":
      ui.Send("Returning a book");
      break;
    default:
      ui.Send("Unrecognized command");
      break;
  }
}