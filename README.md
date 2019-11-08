# Assignment 6

The purpose of this assignment is to write a class library with a generic collection class that supports a fixed number of items:

- Fully unit test the library.
- Run multiple code analysis libraries
- Implement both a generic method and a generic class.
- Support generic interfaces.
- Include in/out contextual keywords for covariance and contravariance.

## Reading

Read through Chapters 12 & 13.
(This would be far more valuable than listening to the lecture from 2019-11-05.)

## Instructions

- Write an `Array<T>` class:
  - Supports collecting a fixed number of items once instantiated
  - Has a constructor via which you can specify fixed width.  (Other constructors are welcome.)
  - Handle null appropriately when items are missing (this is likely a judgement call so justify your answer in the comments.)
  - Throw an exception if an item doesn't exist.
  - Include an index operator
  - Support using foreach over the items in the `Array<T>` class.
  - Support a collection initializer
  - Implement `System.Collections.Generic.ICollection<T>`
  - Ignore support for multi-dimensional arrays.
  - Add a `Capacity` property to return the capacity (the value specified in the constructor) of the collection.
- Add the following list of code analysis assemblies and appropriately handle all warnings: `IntelliTectAnalyzer.dll`,`Microsoft.NetCore.Analyzers.dll`,`Microsoft.CodeQuality.Analyzers.dll`,`Microsoft.NetCore.Analyzers.dll`,`Microsoft.NetFramework.Analyzers.dll`.  Use this list of code analyzers for all assignments in the future.
- Choose simplicity over than complexity.

### As Always

- Fully unit test the Assignment6 library.
- Run code analysis for all project and appropriately address all warnings.
- Nullablility should be enabled at the project level for all projects and all warnings should be handled without disabling them.

## Extra Credit

The following are options for extra credit (you don't need to do them all):

- Write a cast operator to a C# array or a `System.Collections.Generic.List<T>`.
- Add support for an `IReadOnlyArray` interface (for you to define) that provides readonly access to the count and each element in the array.  Be sure to appropriately decorate it for covariance and contravariance.
