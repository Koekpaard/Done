using Done.Data.Repositories;
using NUnit.Framework;
using System.Linq;

namespace Done.Data.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void AssertTodoRepoYieldsResults(int userId)
        {
            var result = TodoRepository.GetTodos(userId);
            Assert.IsTrue(result.Any());
        }

        [Test]
        public void AssertTodoRepoGetsTodoFromInternet()
        {
            var result = TodoRepository.GetTodos(1);

            // When there's no connection, the repo returns a list with only one item, with UserId -1. We should not get this one.
            Assert.IsFalse(result.Count == 1);
            Assert.IsFalse(result.Any(x => x.UserId == -1));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        public void AssertAllTodosBelongToUser(int userId)
        {
            var result = TodoRepository.GetTodos(userId);

            Assert.IsTrue(result.All(x => x.UserId == userId));
        }
    }
}