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
    case "borrow":
      Console.WriteLine("Boorowing a book");
      break;
    case "return":
      Console.WriteLine("Returning a book");
      break;
    default:
      Console.Write("Unrecognized command");
      break;
  }
}