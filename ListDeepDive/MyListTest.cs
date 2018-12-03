using System;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using MyCollections;
using Xunit;

namespace ListImplementationTest
{
    public class MyListTest
    {
        private List<int> intList;

        public class Employee
        {
            public string Name { get; set; }
            public uint Age { get; set; }
            public uint Salary { get; set; }
            public string City { get; set; }
        }

        public MyListTest()
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
            intList = new List<int>()
            {
                
            };
            intList.Count().Should().Be(7, "It was intialized with 7 elements");
            String.Join(",", intList).Should().Be("1,2,3,4,5,6,7", "it should contain these elements");
        }

        [Fact(DisplayName = "Ability to Query the list")]
        [Trait("XUnitTests", "C# List Tests")]
        public void AbilityToQueryList()
        {
            intList = new List<int>() { 1, 2, 3, 4, 5, 6, 7,8,9,10,11,12,13 };
            //var result = intList.Where(i => i >= 4);
            String.Join(",", intList).Should().Be("1,2,3,4,5,6,7,8,9,10,11,12,13", "it should contain these elements");
        }


        [Fact(DisplayName = "Count reflects exact and correct count")]
        [Trait("XUnitTests", "C# List Tests")]
        public void CountIsInSync()
        {
            intList = new List<int>();
            for(int j = 1; j <= 300; j++) { 
                intList.Add(j);
                intList.Count().Should().Be(j);
            }
            intList.Count().Should().Be(300);
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
          
            //empList.Count(item => item.City == "Melbourne").Should().Be(2);
        }

        [Fact(DisplayName = "Ability to Remove the items from the List")]
        [Trait("XUnitTests", "C# List Tests")]

        public void RemovalCountTest()
        {
           this.intList = new List<int>();
            for (int j = 1; j <= 300; j++)
            {
                intList.Add(j);
            }
            intList.Count().Should().Be(300,"Added 300 so far");
            for (int k = 0; k < 300; k++)
            {
                intList.Remove(k);
                intList.Count().Should().Be(300 - (k + 1)," Inside loop");
            }

        }


        //[Fact(DisplayName = "Ability to Add an item to collection thru Add Method")]
        //[Trait("XUnitTests", "C# List Tests")]
        //public void ListAddMethodWorks()
        //{
        //    List<Employee> empList = new List<Employee>();
        //    empList.Add(new Employee() { Name = "John", Age = 34, Salary = 120, City = "Melbourne" });
        //    empList.Add(new Employee() { Name = "Ashok", Age = 44, Salary = 20, City = "Melbourne" });
        //    empList.Count(item => item.City == "Melbourne").Should().Be(2);
        //}

        //[Fact(DisplayName = "Ability to call Remove Method and remove item")]
        //[Trait("XUnitTests", "C# List Tests")]
        //public void ListRemoveMethodWorks()
        //{
        //    List<Employee> empList = new List<Employee>();
        //    Employee e1 = new Employee() {Name = "John", Age = 34, Salary = 120, City = "Melbourne"};
        //    Employee e2 = new Employee() { Name = "Ashok", Age = 44, Salary = 20, City = "Melbourne" };
        //    Employee e3 = new Employee() { Name = "John", Age = 34, Salary = 120, City = "Melbourne" };
        //    empList.Add(e1);
        //    empList.Add(e2);
        //    empList.Count(item => item.City == "Melbourne").Should().Be(2);
        //    empList.Remove(e2);
        //    empList.Count(item => item.City == "Melbourne").Should().Be(1);
        //    empList.Remove(e3);
        //    empList.Count(item => item.City == "Melbourne").Should().Be(1);
        //    var firstEmp = empList.FirstOrDefault();
        //    empList.Remove(firstEmp);
        //    empList.Count().Should().Be(0);

        //}


        [Fact(DisplayName = "Able to iterate collection thru foreach")]
        [Trait("XUnitTests", "C# List Tests")]
        public void AbleToDoForEachLoop()
        {
            List<Employee> empList = new List<Employee>();
            Employee e1 = new Employee() { Name = "John", Age = 34, Salary = 120, City = "Melbourne" };
            Employee e2 = new Employee() { Name = "Ashok", Age = 44, Salary = 20, City = "Melbourne" };
            Employee e3 = new Employee() { Name = "Vishal", Age = 54, Salary = 220, City = "Sydney" };
            empList.Add(e1);
            empList.Add(e2);
            empList.Add(e3);

            String allNames = string.Empty;
            foreach (var emp in empList)
            {
                allNames += emp.Name;
            }

            allNames.Should().Be("JohnAshokVishal");

        }
    }
}
