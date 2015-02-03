using System;
using System.Collections.Generic;
using System.Linq;

namespace tests
{

    internal class Person
    {
        public string FirstName;

        public Person(string s)
        {
            FirstName = s;
        }

        public override string ToString()
        {
            return FirstName;
        }
    }

    internal class Relationship
    {
        public Person A;
        public Person B;

        public Relationship(Person a, Person b)
        {
            A = a;
            B = b;
        }

        public bool Has(Person x, Person y)
        {
            return (x == A && y == B) || (x == B && y == A);
        }

        public override string ToString()
        {
            return String.Format("{0} and {1}:", A, B);
        }
    }

    internal class MapReduce
    {

        public static Dictionary<Person, List<Person>> Generate()
        {
            var a = new Person("A");
            var b = new Person("B");
            var c = new Person("C");
            var d = new Person("D");
            var e = new Person("E");
            var peopleData = new Dictionary<Person, List<Person>>
            {
                {a, new List<Person> {b, c, d}},
                {b, new List<Person> {a, c, d, e}},
                {c, new List<Person> {a, b, d, e}},
                {d, new List<Person> {a, b, c, e}},
                {e, new List<Person> {b, c, d}}
            };
            return peopleData;
        }

        public static Dictionary<Relationship, List<Person>> Map(Dictionary<Person, List<Person>> data)
        {
            var commonFriends = new Dictionary<Relationship, List<Person>>();
            foreach (var person in data)
            {
                var friends = person.Value;
                friends.ForEach(aFriend =>
                {
                    if (!commonFriends.Any(x => x.Key.Has(person.Key, aFriend)))
                        commonFriends.Add(new Relationship(person.Key, aFriend),
                            data[aFriend].Intersect(person.Value).ToList());

                });
            }
            return commonFriends;
        }

        public static Dictionary<Relationship, int> Reduce(Dictionary<Relationship, List<Person>> data)
        {
            return data.ToDictionary(relationship => relationship.Key, relationship => relationship.Value.Count);
        }

        public static void PrettyPrint<T1,T2>(Dictionary<T1, List<T2>> data)
        {
            foreach (var relationship in data)
            {
                Console.WriteLine("{0} have these friends in common", relationship.Key);

                foreach (var person in relationship.Value)
                {
                    Console.WriteLine("\t {0}", person);
                }

            }
        }

        public static void PrettyPrint<T1,T2>(Dictionary<T1, T2> data)
        {
            foreach (var relationship in data)
            {
                Console.WriteLine("{0} have these friends in common", relationship.Key);
                Console.WriteLine("\t {0}", relationship.Value);
            }
        }

        public static void TestRun()
        {
             var data = Generate();
            Func<Dictionary<Relationship, List<Person>>> action = () => Map(data);
            var mapped = (Dictionary<Relationship, List<Person>>)TestHarness.TimeTrial("Mappign took", action).Item2;
            PrettyPrint(mapped);
            PrettyPrint(Reduce(mapped));
            
            Console.ReadLine();
        }
    }
}
