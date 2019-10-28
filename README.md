# Assignment 4

The purpose of this assignment is to focus on unit testing with the following concepts:

- Leveraging a mock object rather than testing multiple units or IO
- Working with data driven tests.
- Working with code analysis
- Nullable reference types

## Reading

Read through Chapter 11 by the week of Oct. 28.
Read through information on [Nullability](https://intellitectsp-my.sharepoint.com/:w:/g/personal/mark_intellitect_com/EcaeQiQnpwpJpIh6-AjD_j4BoTlc6CLCBzYuXU-EHxHkWQ?e=0RWkzh). Feel free to comment or edit the content.  **Do not share** this document outside of class.

## Instructions

- Create a *`EnvironmentConfig`* configuration class that implements `IConfig` and settings using `Environment.SetEnvironment()` and `Environment.GetEnvironment()`
- **Settings should not persist across process settings (if this occurs you will get a 0)**
- Implement an `FileConfig` that reads/writes settings to a config.settings file in the same directory as the application.  Settings are stored as <name>=<value>.  (You can use String.Split to retrieve individual values).
- Do not allow null, empty string, or names with spaces or '='.  Feel free to document other assumptions using unit tests.  
- Choose simplicity over than complexity.
- Implement **SampleApp** to print out all the configuration settings based on hard coded values for config (iterating over the values is not supported by the interface).
- Have the **SampleApp** print out a hard coded list of settings to the console.  You do not need to unit test invocations of `System.Console` methods.
- Unit test the **SampleApp** using a `MockConfig` class (implementing `IConfig`) that uses settings stored in memory (such as an array or a `List<T>`)
- Use data driven testing to work with multiple values against the config API.
- Add code analysis to **SampleApp** address all warnings.  It is okay to appropriately disable rules such as  localization/culture rules. **Note: This is true for projects in all assignments going forward.***
- Nullablility should be enabled at the project level for all projects and all warnings should be handled without disabling them.  Also, be sure to check for null when appropriate.  **Note: This is true for all assignments going forward.***
- Follow the test principles described in [Unit testing best practices with .NET Core and .NET Standard](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices)
  - Where an assert is a logical assert rather than a statement assert
  - Ensure tests will run whether or not config files already exits.
  - Be sure to clean up after all tests have run and before a new test run starts.

## Extra Credit

The following are options for extra credit (you don't need to do them all):

- Provide a means to iterate over all the settings on a provider rather than only pulling out specific ones by name.
- Refactor the test classes that test through `IConfig` into a base class so that the same tests can be used to test multiple.
- Create an IConfigGroup that returns a set of setting based on wildcard filters (rather than just a single setting)
- Provide a mock instance for `System.Console`.  (You do not need to test method invocations of `System.Console`.)
- Create and implement an `IConfigAsync` interface (we are unlikely to cover async this quarter).
