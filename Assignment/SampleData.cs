﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        private readonly string _FileName;

        public SampleData()
        {
            _FileName = "People.csv";
        }

        public SampleData(string file)
        {
            _FileName = file;
        }

        public enum Column
        {
            Id,
            FirstName,
            LastName,
            Email,
            StreetAddress,
            City,
            State,
            Zip
        }

        // 1.
        public IEnumerable<string> CsvRows => File.ReadAllLines(_FileName).Skip(1);

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
        {
            IEnumerable<string> orderedStates = CsvRows.OrderBy(person => person.Split(",")[(int)Column.State]).Distinct();
            return orderedStates;
        }

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
        {
            IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows().Select(person => person.Split(",")[(int)Column.State]);
            string[] sortStates = states.ToArray();

            return string.Join(",", sortStates);
        }

        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select(person => person.Split(","))
            .Select(person => new Person 
            {
                FirstName = person[(int)Column.FirstName],
                LastName = person[(int)Column.LastName],
                Email = person[(int)Column.Email],
                StreetAddress = person[(int)Column.StreetAddress],
                City = person[(int)Column.City],
                State = person[(int)Column.State],
                Zip = person[(int)Column.Zip],
                Address = new Address
                {
                    StreetAddress = person[(int)Column.StreetAddress],
                    City = person[(int)Column.City],
                    State = person[(int)Column.State],
                    Zip = person[(int)Column.Zip]
                }
            })
            .OrderBy(person => person.State)
            .ThenBy(person => person.City)
            .ThenBy(person => person.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
        {
            if (filter is null)
            {
                throw new ArgumentNullException(nameof(filter));
            }
            else
            {
                return People.Where(person => (person.Email != null && filter(person.Email)))
               .Select(person => (person.FirstName, person.LastName));
            } 
        }

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
        {
            if (people is null)
            {
                throw new ArgumentNullException(nameof(people));
            }
            else
            {
                IEnumerable<string?> peoples = people.Select(person => person.State);
                return peoples.Distinct().Aggregate((x, y) => x + "," + y);
            }
           
        }
    }
}