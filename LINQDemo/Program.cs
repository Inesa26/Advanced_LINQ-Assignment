using System.Collections;
using System.Data;

namespace LINQDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Book> _books = new List<Book>
        {
            new Book { Title = "Fahrenheit 451", Author = "Ray Bradbury", Genre = "Science Fiction" },
            new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian" },
            new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction" },
            new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic" },
            new Book { Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance" },
            new Book { Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Fantasy" }
        };
            int[] numbers = { 1, 2, 3, 4, 5 };
            int[] numbers2 = { 8, 2, 9, 4, 6 };
            string[] names = { "one", "two", "three", "four", "five" };
            List<List<int>> listOfLists = new List<List<int>>
                {
                    new List<int> { 1, 2, 3 },
                    new List<int> { 4, 5 },
                    new List<int> { 6, 7, 8 }
                };

            var employees = new List<Employee>
        {
            new Employee { EmployeeID = 1, Name = "John", DepartmentID = 101 },
            new Employee { EmployeeID = 2, Name = "Alice", DepartmentID = 102 },
            new Employee { EmployeeID = 3, Name = "Bob", DepartmentID = 101 }
        };

            var departments = new List<Department>
        {
            new Department { DepartmentID = 101, DepartmentName = "Engineering" },
            new Department { DepartmentID = 102, DepartmentName = "Marketing" },
            new Department { DepartmentID = 103, DepartmentName = "Finance" }
        };
            var mixedList = new ArrayList { 1, "two", 3, "four", 5 };

            //Projection Operators: Select, SelectMany
            //Select
            int contor = 0;
            var newListOfBooks = _books.Select(eachBook => ++contor + eachBook.Title);
            foreach (var book in newListOfBooks)
            {
                Console.WriteLine(book);
            }
            //SelectMany
            var commonList = listOfLists.SelectMany(eachList => eachList).ToList();
            foreach (var element in commonList)
            {
                Console.Write(element);
            }
            Console.WriteLine();

            //Filtering Operators: Where, OfType, and Take.
            //Where
            var oddNumbers = numbers.Where(number => number % 2 == 0);
            Console.WriteLine(string.Join(", ", oddNumbers));

            //Take
            var firstThreeBooks = _books.Take(3);
            foreach (var book in firstThreeBooks)
            {
                Console.WriteLine(book);
            }
            //Quantifier Methods:  Any, All, Contains, SequenceEqual.
            //Contains
            Console.WriteLine(names.Contains("two"));

            //Any
            Console.WriteLine(_books.Any(book => book.Title.Equals("1984")));

            //SequenceEqual
            Console.WriteLine(numbers.SequenceEqual(numbers2));

            //Aggregation Methods:  Sum, Count, Average, and Min/ Max.
            //Average
            Console.WriteLine(numbers.Average());

            //Count
            Console.WriteLine(_books.Count());

            //Min
            Console.WriteLine(numbers.Min());

            //Sum
            Console.WriteLine(numbers.Sum());

            //Sorting Operators: OrderBy, OrderByDescending, ThenBy, and ThenByDescending, Reverse.

            //OrderBydescending
            var descendingOrderedList = numbers.OrderByDescending(element => element);
            Console.WriteLine(string.Join(", ", descendingOrderedList));

            //ThenBy
            var orderedListOfBooks = _books.OrderBy(eachBook => eachBook.Title).ThenBy(eachBook => eachBook.Author);
            foreach (var book in orderedListOfBooks)
            {
                Console.WriteLine(book);
            }

            //Reverse
            var reverseNumberList = numbers.Reverse();
            Console.WriteLine(string.Join(", ", reverseNumberList));

            //Set Operators: Union, Intersect, Except, and Distinct.
            //Union
            var unionResult = numbers.Union(numbers2);
            Console.WriteLine(string.Join(", ", unionResult));

            //Distinct
            var distinctNumbers = numbers.Distinct();
            Console.WriteLine(string.Join(", ", distinctNumbers));

            //Intersect
            var intersectNumbers = numbers.Intersect(numbers2);
            Console.WriteLine(string.Join(", ", intersectNumbers));

            //Except
            var exceptResult = numbers.Except(numbers2);
            Console.WriteLine(string.Join(", ", exceptResult));

            //Generation operators: Empty, Repeat, Range
            //Empty
            var empty = Enumerable.Empty<string>();

            //Repeat
            var repeat = Enumerable.Repeat(new Book(), 5);

            //Range
            var range = Enumerable.Range(0, 5);

            //Join Operators: Join, GroupJoin, and Zip.
            //Join
            var query = employees.Join(departments,
                                   employee => employee.DepartmentID,
                                   department => department.DepartmentID,
                                   (employee, department) => new { employee.Name, department.DepartmentName });

            foreach (var result in query)
            {
                Console.WriteLine($"{result.Name} - {result.DepartmentName}");
            }

            //Zip
            var zipped = numbers.Zip(names, (num, name) => $"{num}-{name}");

            foreach (var item in zipped)
            {
                Console.WriteLine(item);
            }

            //Grouping Operators: GroupBy

            //GroupBy
            var groupedBooks = _books.GroupBy(book => book.Genre);
            foreach (var group in groupedBooks)
            {
                Console.WriteLine($"{group.Key}:");
                foreach (var book in group)
                {
                    Console.WriteLine($"- {book.Title} by {book.Author}");
                }
                Console.WriteLine();
            }

            //Conversion Methods: OfType, Cast, ToArray, ToList, ToDictionary, ToLookup, AsEnumerable, AsQueryable
            // OfType: 

            var integersOnly = mixedList.OfType<int>();
            Console.WriteLine(string.Join(", ", integersOnly));

            // Cast
            var objectList = new List<object> { 1, "two", 3.0, "four" };
            var stringList = objectList.OfType<string>().ToList();
            foreach (var element in stringList)
            {
                Console.WriteLine(element);
            }

            //ToArray
            var booksArray = _books.ToArray();
            foreach (Book book in booksArray)
            {
                Console.WriteLine(book);
            }
            //ToDictionarry
            Console.WriteLine("Dictionary");
            var booksDictionary = _books.ToDictionary(book => book.Title);
            foreach (var pair in booksDictionary)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }

            // AsEnumerable: 
            IEnumerable<Book> bookEnumerable = _books.AsEnumerable();
            foreach (var book in bookEnumerable)
            {
                Console.WriteLine(book);
            }

            // AsQueryable: Converts an IEnumerable to an IQueryable.
            var bookQueryable = _books.AsQueryable();

            foreach (var book in bookQueryable)
            {
                Console.WriteLine(book);
            }
        }
    }
}
