using System;
using System.Threading.Tasks;
using jkas.notfier.function;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jks.notfier.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            var repo = new Repository("litecoin", "a82d2318d78cb455e8acfc200ea0f0e6b16682adf161ea836573e14523422d89");
            var data = await repo.GetUserTransactions();
        }
    }
}
