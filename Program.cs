using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aggregate
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = (new[]
            {
                new KeyValuePair<string, int>("Adam", 30),
                new KeyValuePair<string, int>("Jon", 1),
                new KeyValuePair<string, int>("Valentin", 2),
                new KeyValuePair<string, int>("Alex", 3),
                new KeyValuePair<string, int>("Max", 4),
                new KeyValuePair<string, int>("Max", 7),
                new KeyValuePair<string, int>("Adam", 5),
                new KeyValuePair<string, int>("Valentin", -6)
            }).AsEnumerable<KeyValuePair<string, int>>();

            var dictionary = items.Select(x =>
            {
                return items.Aggregate(new KeyValuePair<string, int>(x.Key, 0), (aggregateValue, current) =>
                {
                    if (aggregateValue.Key.Equals(current.Key))
                    {
                        aggregateValue = new KeyValuePair<string, int>(aggregateValue.Key, aggregateValue.Value + current.Value);
                    }
                    return aggregateValue;
                });
            }).Distinct().ToDictionary(x => x.Key, x => x.Value);

            foreach (var i in dictionary)
            {
                Console.WriteLine(i.Key + " " + i.Value);
            }

            Console.ReadKey();
        }
    }
}