# EWU-CSCD371-2019-Fall

## Assignment 5

For this assignment assume that you have a large wall of mailboxes. The wall of mailboxes is **30 wide and 10 tall**.
There is an existing project with a Main method already implemented. There is also a `Mailboxes` class implemented that is a simple wrapper over the top of a list. The remainder of the project and *all* unit tests should be implemented. The unit tests should **not** use the file system, instead leverage the `System.IO.MemoryStream` class. It derives from `System.IO.Stream`. You can populate it with data using the the `System.IO.StreamReader` and `System.IO.StreamWriter` classes. Take note to either dispose of the `MemoryStream` yourself or allow the `StreamReader`/`StreamWriter` to do it (see notes on DataLoader).

- All parameters on public methods must be validated. Fail fast, don't have your code crash later on a condition that should have been checked initially.

#### Program
The Main method has already been implemented for you. Unless you are doing the extra credit, you should not need to modify it. You will probably want to implement the other classes before implementing this class.
- Implement GetOwnersDisplay. This method should return a **distinct** list of people who are owners on the mailboxes.
- Implement GetMailboxDetails. This method should return a string that contains all of the details of the specified mailbox, or null if the mailbox cannot be found.
- Implement AddNewMailbox. This method should find an unoccupied location in the Mailboxes and return a new `Mailbox` instance if a location is found. A mailbox *may not be placed adjacent* to another mailbox that contains a person with the same name. Adjacent is defined as orthogonal. There is a method on `Mailboxes` that should be helpful here. It should **not** modify the passed in `mailboxes`.

#### Size
- Create a new flagged `Size` enum.
- Ensure it has a reasonable default value
- It should have values for Small, Medium, Large
- All sizes should be able to be flagged as Premium

#### Person
- Create a new `Person` struct
- A person has a first and last name
- `Person` should implement `IEquatable<Person>`
- Ensure appropriate equality operators are also written
- Implement a reasonable ToString method

#### Mailbox
- Create a new `Mailbox` class
- A `Mailbox` contains a `Size`, a value tuple `(int X, int Y)` for its Location, and a `Person` Owner
- The ToString method should include all property members.
- When including the Size in the ToString, it should output empty string when the Size is the default (0) value, the name of the size with " Premium" it is a premium size, or simple the size name. For examples "Small" or "Medium Premium".

#### DataLoader
This class will be responsible for saving and loading our mailbox data. 
- I should take in a System.IO.Stream in its constructor. Though the stream being used here will point to a file, this is a generic way to save to a variety of sources.
- To read/write to the stream you will want to look at the `System.IO.StreamReader` and `System.IO.StreamWriter` classes. In particular you will want to look through the overloaded constructors to make sure that these classes do **not** close your stream.
- Before reading/writing to the `Stream` you will need to reset the stream pointer to the beginning. `Stream.Position` or `Stream.Seek` will be helpful here.
- The `StreamReader` and `StreamWriter` should be properly disposed of inside of the Load/Save methods.
- The data should be stored as [json](https://en.wikipedia.org/wiki/JSON). A popular library for working with json is [Newtonsoft.Json](https://www.newtonsoft.com/json). You will want to look at the static methods on the `JsonConvert` class for converting objects to and from strings of json data.
- The `DataLoader` should [properly implement](https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose#dispose-and-disposeboolean) the `IDispoable` interface. It should clean up the `Stream` that was passed in.
- The `DataLoader` should handle the `JsonReaderException`. This exception will be throw if the stream contents are not valid json. Such as "abc". If this is thrown the method should gracefully return `null`.

### Extra Credit
- It can be quite time consuming to create testable objects like the Mailbox class by hand. Use a third party library as part of the unit test to automatically generate these. A popuplar library for this is [Bogus](https://www.nuget.org/packages/Bogus/)
- The Main method in the Program is fairly un-testable in its current state due to all of the static `Console` methods. Implement an `IConsole` interface, use it in the Main method, and add unit tests for the Main method. You do *not* need to unit test your implementations of `IConsole`.