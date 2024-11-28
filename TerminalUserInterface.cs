class TerminalUserInterface
{
  private readonly Dictionary<Type, Func<string, object?>> parsers;

  public TerminalUserInterface()
  {
    parsers = new Dictionary<Type, Func<string, object?>>
    {
      // Register the default parsers
      { typeof(string), StringParsers.ToString },
      { typeof(int), StringParsers.ToInt },
      { typeof(bool), StringParsers.ToBool }
    };
  }

  public void Send(string message)
  {
    Console.WriteLine(message);
  }

  public T Request<T>(string message)
  {
    while (true)
    {
      // Inform the user
      Console.WriteLine(message);

      // Read from the input
      string? userInput = Console.ReadLine();
      if (userInput == null || userInput is "q" or "quit")
      {
        Console.WriteLine("Input canceled");
        return default!;
      }

      // Introspect on the type given and try to find
      // a registered parser for that type
      if (parsers.TryGetValue(typeof(T), out var parser))
      {
        var result = parser(userInput);
        if (result is T typedResult)
        {
          return typedResult;
        }
        else
        {
          // User input failure, inform them and try again.
          Console.WriteLine($"Unknown input. Expected: {typeof(T).Name}");
          continue;
        }
      }
      else
      {
        // This is a developer error, and should be handled by the developer
        throw new Exception($"Requested unsupported Type! Type: {nameof(T)}");
      }
    }
  }

  // Allow users to extend this with custom parsers
  public void AddParser<T>(Func<string, object?> parser)
  {
    if (parsers.ContainsKey(typeof(T)))
      throw new ArgumentException($"Parser for type {typeof(T).Name} already exists.");
    parsers[typeof(T)] = parser;
  }

}

class StringParsers
{
  // Parsers
  // A set of prebuilt parsers
  public static object? ToString(string str)
  {
    return str;
  }

  public static object? ToInt(string str)
  {
    return int.TryParse(str, out var result) ? result : null;
  }

  public static object? ToBool(string str)
  {
    return bool.TryParse(str, out var result) ? result : null;
  }
}
