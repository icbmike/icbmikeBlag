using System;
using IcbmikeBlag.Application.DAL;
using IcbmikeBlag.Application.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IcbmikeBlag.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var userRepository = new UserRepository(new BlagContext());
            userRepository.GetUser("mike", "password");
        }
    }
}
