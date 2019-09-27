# EWU-CSCD371-2019-Fall

### Conventions

- Create solution first, then create projects in subdirs.
- Test should be named like so: `public void class_methodBeingTested_expectedResult() {}`

### When Starting New Solution

- add `<Nullable>Enable</Nullable>` to `*.csproj` files
- If not added by default, add `coverlet.collector` package as well.

### Testing
- Write a test to show you need to write some code (TDD Principle)
- Code coverage in unit test should be 100%. No point in writing unittest that doesn't run.
