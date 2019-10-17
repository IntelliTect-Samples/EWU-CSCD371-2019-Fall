# EWU-CSCD371-2019-Fall
## Assignment 3
For this assignment we are going to unfortunately just do some academic exercises to make sure
we understand polymorphism and pattern matching. Some initial code has already been provided
(no, it does not compile, and that is expected).

### Part 1 - Shopping List (cuz everyone needs more lists)
- A static class named Printer has a static Print method on it that accepts an Item class and a TextWriter
- There is an existing abstract class named Item which has an abstract method named PrintInfo
- There is an existing class named Food which inherits from Item
  - Using polymorphism, implement Food so that it will utilize PrintInfo to print the food's
  information as "&lt;upc&gt; - &lt;brand&gt;"
- Create another class called Television that has a Size and Manufacturer property on it.
Again, using polymorphism, allow this class to print out its information as "&lt;Manufacturer&gt; - &lt;Size&gt;"

### Part 2 - Big Bang Theory Fun
- An existing class called Actor has been created. This is to be treated as a class you are not
allowed to modify (consider it a third party created class)
- Create at least 3 classes (Penny, Sheldon, Raj) that all inherit from the Actor class
- Create a static class that has an extension method for Actor on it called "Speak" that will use
pattern matching to call each of the specific classes that inherit from Actor
   - Now anyone who has seen Big Bang Theory before Raj got cured knows that Raj cannot speak when
women are around, so make sure that he only says something when WomenArePresent is false. If
WomenArePresent happens to be true, he can only "mumble" (logic should be expressed in the switch statement, not the method that takes care of what he says - meaning, there should be 2 methods that exist for Raj)

### Extra Credit (TBD)
