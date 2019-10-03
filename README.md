# EWU-CSCD371-2019-Fall

Issue 1:
Reproduction steps:
Run the application. 

Observed:
The application throws a NullReferenceException and crashes.
System.NullReferenceException
  HResult=0x80004003
  Message=Object reference not set to an instance of an object.
  Source=PrincessBrideTrivia
  StackTrace:
   at PrincessBrideTrivia.Program.DisplayQuestion(Question question) in C:\Dev\EWU\EWU-CSCD371-2019-Fall\PrincessBrideTrivia\Program.cs:line 57
   at PrincessBrideTrivia.Program.AskQuestion(Question question) in C:\Dev\EWU\EWU-CSCD371-2019-Fall\PrincessBrideTrivia\Program.cs:line 32
   at PrincessBrideTrivia.Program.Main(String[] args) in C:\Dev\EWU\EWU-CSCD371-2019-Fall\PrincessBrideTrivia\Program.cs:line 16

Expected:
The application is expected to display trivia questions that the user can attempt to answer. It should not be crashing.

An associated unit test should also be created to prove it won't crash this way again in the future.

Issue 2:
Reproduction steps:
Run the unit tests.

Observed:
The GetPercentCorrect_ReturnsExpectedPercentage unit test is currently failing. 

Expected:
The unit test is correct. The method being tested is wrong and should be fixed so the unit test passes. After the user has finished answering all of the questions the percentage of correct answers should be displayed to them.


Issue 3 (extra credit)
Feature request:
Currently the application displays all of the answers in the same order each time. Adjust the application so the answers are displayed in a random order. Add appropriate unit tests and ensure the app continues to function properly.
