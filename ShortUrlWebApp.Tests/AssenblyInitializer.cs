using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ShortUrlWebApp.Tests
{
    [TestClass]
    public static class AssenblyInitializer
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
