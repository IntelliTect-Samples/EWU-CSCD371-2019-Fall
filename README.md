# Assignment

The purpose of this assignment is to learn LINQ including:

- Selecting (projection)
- Filtering
- Aggregation
- Sorting
- Unit testing collections.

## Reading

Read through Chapters 15 & 17 (16 is optional)

## Instructions

**Throughout, consider using the `System.Linq.Enumerable` methods `Zip`, `Count`, `Sort` and `Contains` methods for testing collections.**.  (Preferably avoid using `Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert` although that might be easier, in order to get a firmer grasp on on additional LINQ API.)

1. Implement the `ISampleData.CsvRows` property, loading the data from the `People.csv` file and returning each line as a single string.

- Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project.
- Using LINQ, skip the first row in the `People.csv`.
- Be sure to appropriately handle resource (`IDisposable`) items correctly if applicable (and it may not be depending on how you implement it).

1. Implement `IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()` to return a **sorted**, **unique** list of states.

- Use `ISampleData.CsvRows` for your data source.
- Don't forget the list should be unique.
- Sort the list alphabetically
- Include a test that leverages a hard coded list of Spokane based addresses.
- Include a test that uses LINQ to verify the data is sorted correctly (do not use a hard coded list).

1. Implement `ISampleData.GetAggregateSortedListOfStatesUsingCsvRows()` to return a `string` that contains a **unique**, comma separated list of states.

- Use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows` for your data source.
- Consider "selecting" only the states and calling `ToArray()` to retrieve an array of all the state names.
- Given the array, consider using `string.Join` to combine the list into a single string.

1. Implement the `ISampleData.People` property to return all the items in `People.csv` as `Person` objects

- Use `ISampleData.CsvRows` as the source of the data.
- Sort the list by State, City, Zip. (Sort the addresses first then select).
- Be sure that `Person.Address` is also populated.
- Adding null validation to all the `Person` and `Address` properties is **optional**.
- Consider using `ISampleData.CsvRows` in your test to verify your results.

1. Implement `ISampleDate.FilterByEmailAddress(Predicate<string> filter)` to return a list of names where the email address matches the `filter`.

- Use `ISampleData.People` for your data source.

1. Implement `ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)` to return a `string` that contains a **unique**, comma separated list of states.

- Use the `people` parameter from `ISampleData.GetUniqueListOfStates` for your data source.
- At a minimum, use `System.Linq.Enumerable.Aggregate` LINQ method to create your result.
- Don't forget the list should be unique.
- It is recommended that at a minimum you use `ISampleData.GetUniqueSortedListOfStatesGivenCsvRows` to validate your result.

### As Always

- Fully unit test the Assignment
- Nullablility should be enabled at the project level for all projects and all warnings should be handled without disabling them.
- Add the following list of code analysis assemblies and appropriately handle all warnings: `IntelliTectAnalyzer.dll`,`Microsoft.NetCore.Analyzers.dll`,`Microsoft.CodeQuality.Analyzers.dll`,`Microsoft.NetCore.Analyzers.dll`,`Microsoft.NetFramework.Analyzers.dll`. 
- Choose simplicity over than complexity.

## Extra Credit

The following are options for extra credit (you don't need to do them all):

- Write awesome, well tested code that follows all the guidelines outlined in the book.
- Implement all homework using async/await and multi-threading by defining a new `SampleDataAsync` class that implements `ISampleData`). Refactor both your SampleData and SampleDataAsync classes so there is minimal duplication.  This includes refactoring your tests so a significant amount of test code can be re-used.
