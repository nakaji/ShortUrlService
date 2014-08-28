using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShortUrlWebApp.Migrations;
using ShortUrlWebApp.Models;

namespace ShortUrlWebApp.Tests
{
    [TestClass]
    public static class AssenblyInitializer
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", AppDomain.CurrentDomain.BaseDirectory);
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppDbContext, Configuration>());

        }
    }
}
