using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using siteMapper;

namespace siteMapperTests
{
    [TestClass]
    public class WebsiteTest
    {
        [TestMethod]
        public void CreatWebsite()
        {
        }
        [TestMethod]
        public void AddPage1()
        {
        }
        [TestMethod]
        public void AddPage2()
        {
        }
        [TestMethod]
        public void AddAllPages()
        {
        }
        [TestMethod]
        public void Equals()
        {
        }
    }
    [TestClass]
    public class PageTest
    {
        siteMapper.Website stubSite;
        string testDomain;

        [TestInitialize]
        public void TestInit()
        {
            testDomain = "https://www.test.com/";
            stubSite = new siteMapper.Website(testDomain);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            stubSite = null;
            testDomain = String.Empty;
        }
        [TestMethod]
        public void CreatPage()
        {
            Page testPage = new Page(testDomain, stubSite);

            Assert.AreEqual(testPage.URL, testDomain);
        }
        [TestMethod]
        public void AddLink1()
        {
            Page testPage = new Page(testDomain, stubSite);
            Page testPage2 = new Page(testDomain + "/contact", stubSite);
            testPage.AddLink(testPage);

            Assert.IsTrue(testPage.Links.Contains(testPage2));
        }
        [TestMethod]
        public void AddLink2()
        {
            Page testPage = new Page(testDomain, stubSite);
            Page testPage2 = new Page(testDomain + "/contact", stubSite);
            testPage.AddLink(testDomain + "/contact");

            Assert.IsTrue(testPage.Links.Contains(testPage2));
        }
        [TestMethod]
        public void AddAllLinks()
        {
            Page testPage = new Page(testDomain, stubSite);
            testPage.AddAllLinks();

            Assert.IsNotNull(testPage.Links);
            Assert.IsFalse(testPage.Links.Count <= 0);
        }
        [TestMethod]
        public void Equals()
        {
            Page testPage = new Page(testDomain, stubSite);
            Page testPage2 = new Page(testDomain, stubSite);
            Page testPage3 = new Page(testDomain + "/privacy-policy", stubSite);
            Page testPage4 = new Page("www.twest.com", stubSite);

            Assert.AreEqual(testPage, testPage2);
            Assert.IsTrue(testPage.Equals(testPage2));
            Assert.AreNotEqual(testPage, testPage3);
            Assert.IsFalse(testPage.Equals(testPage3));
            Assert.AreNotEqual(testPage, testPage4);
            Assert.IsFalse(testPage.Equals(testPage4));
        }
    }
}
