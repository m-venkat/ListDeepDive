using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace ListImplementationTest
{
    public class TestCSharpListFunctionality
    {
        private List<int> intList;

        public class Employee
        {
            public string Name { get; set; }
            public uint Age { get; set; }
            public uint Salary { get; set; }
            public string City { get; set; }
        }

        public TestCSharpListFunctionality()
        {

        }


        [Fact(DisplayName = "Ability to create List<int>")]
        [Trait("XUnitTests", "C# List Tests")]
        public void AbleToCreateIntList()
        {
            intList = new List<int>();
            intList.Should().NotBeNull("expected to create the instance successfully");
        }


        [Fact(DisplayName = "Ability to initialize collection thru initializer")]
        [Trait("XUnitTests", "C# List Tests")]
        public void AbleToInitializeCollection()
        {
            intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            intList.Count().Should().Be(7, "It was intialized with 7 elements");
            String.Join(",", intList).Should().Be("1,2,3,4,5,6,7", "it should contain these elements");
        }

        [Fact(DisplayName = "Ability to Query the list")]
        [Trait("XUnitTests", "C# List Tests")]
        public void AbilityToQueryList()
        {
            intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            var result = intList.Where(i => i >= 4);
            String.Join(",", result).Should().Be("4,5,6,7", "it should contain these elements");
        }


        [Fact(DisplayName = "Ability to add non primitive custom object to List")]
        [Trait("XUnitTests", "C# List Tests")]
        public void AbilityToAddCustomObjects()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee(){Name = "John",Age=34,Salary = 120,City ="Melbourne"},
                new Employee(){Name = "Ashok",Age=44,Salary = 20,City ="Melbourne"},
                new Employee(){Name = "Kishore",Age=54,Salary = 320,City ="Sydney"},
                new Employee(){Name = "Vinod",Age=64,Salary = 420,City ="Adelaide"}
            };
            empList.Count().Should().Be(4, "I added 4 objects");

        }

        [Fact(DisplayName = "Ability to Query the non primitive object List")]
        [Trait("XUnitTests", "C# List Tests")]
        public void QueryTheCustomList()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee(){Name = "John",Age=34,Salary = 120,City ="Melbourne"},
                new Employee(){Name = "Ashok",Age=44,Salary = 20,City ="Melbourne"},
                new Employee(){Name = "Kishore",Age=54,Salary = 320,City ="Sydney"},
                new Employee(){Name = "Vinod",Age=64,Salary = 420,City ="Adelaide"}
            };
            empList.Count(item => item.City == "Melbourne").Should().Be(2);
        }
    }
}
