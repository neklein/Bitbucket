using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using StudentManagement.BLL;
using StudentManagement.BLL.Data;
using StudentManagement.BLL.Models;

namespace StudentManagement.Test
{
    [TestFixture]
    public class RepositoryTests
    {
        [Test]
        public void CanReadDataFromFile()
        {
            StudentRepository repo = new StudentRepository(@"C:\repos\Bitbucket\Data\SystemIO\StudentTest.txt");

            List<Student> students = repo.List();

            Assert.AreEqual(4, students.Count);
        }
    }
}
