# EWU-CSCD371-2019-Fall
## Assignment 2
For this assignment we are going to build a simple logging system. It will append items to a file. Some code for this assignment is already provided.


- There is an existing `BaseLogger` class. It needs an **auto property** to hold the class name. This property should be set in the `LogFactory` using an **object initializer**.
- Create a `FileLogger` that derives from `BaseLogger`. It should take in a path to a file to write the log message to. When its `Log` method is called, it should **append** messages on their own line in the file. The output should include all of the following:
  - The current date/time
  - The name of the class that created the logger
  - The log level
  - The message
  - The format may vary, but an example might look like this "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
- The `LogFactory` should be updated with a new method `ConfigureFileLogger`. This should take in a file path and store it in a **private member**. It should use this when instantiating a new `FileLogger` in its `CreateLogger` method. 
- If the file logger has not be configured in the `LogFactory`, its `CreateLogger` method should return `null`.
- Inside of `BaseLoggerMixins` implement **extension methods** on `BaseLogger` for `Error`, `Warning`, `Information`, and `Debug`. Each of these methods should take in a `string` for the message, as well as a **parameter array** of arguments for the message. Each of these extension methods is expected to be a shortcut for calling the `BaseLogger.Log` method, by automatically supplying the appropriate `LogLevel`. These methods should throw an exception if the `BaseLogger` parameter is null. There are a couple example unit tests to get you started. 
- All of the above should be unit tested.

### Extra Credit
- Implement an additional logger. This logger must be unit tested. Some options to consider could be one that uses `System.Console` or `System.Diagnostics.Trace`.

### Relevant APIs to know about
[System.IO.Path](https://docs.microsoft.com/en-us/dotnet/api/system.io.path?view=netcore-3.0) IF you find yourself using string operations to build up a file path, stop and look through the members of this static class.

[System.IO.File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netcore-3.0) A simple class that can handle simple file reads and writes.

