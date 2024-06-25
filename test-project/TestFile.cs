using System;
using System.Security.Cryptography;

namespace TestNamespace
{
    public class TestClass
    {
        public void TestMethod()
        {
            var random1 = new Random(); // Wrong!
            var random2 = RandomNumberGenerator.Create();
        }
    }
}