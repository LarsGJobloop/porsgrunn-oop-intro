Console.WriteLine("Please write something, then hit 'enter'");
string? userInput = Console.ReadLine();
if (userInput == null)
{
  throw new Exception("Could not read user input");
}

Console.WriteLine("User inputted");
Console.WriteLine(userInput);
