using System;
using System.Collections.Generic;

namespace Assignment {
    public interface ISampleData {
        // 1.
        IEnumerable<string> CsvRows { get; }

        // 2.
        IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows();

        // 3.
        string GetAggregateSortedListOfStatesUsingCsvRows();

        // 4.
        IEnumerable<IPerson> People { get; }

        // 5.
        IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter);

        // 6.
        string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people);

    }
}
