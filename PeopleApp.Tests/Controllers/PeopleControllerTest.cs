using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleApp.Controllers;
using System.Collections.Generic;
using PeopleApp.Models;
using System.Linq;
using System.Web.Http.Results;
using Moq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace PeopleApp.Tests.Controllers
{
    [TestClass]
    public class PeopleControllerTest
    {
        private PeopleController service;

        public PeopleControllerTest()
        {
            // configure Mock objects and Data for testing
            PeopleController controller = new PeopleController();

            var data = new List<Person>
            {
            new Person()
            {
                Id = 1,
                FirstName = "Joe",
                LastName = "Clem",
                Address = "8665 E 300 N",
                City = "Huntsville",
                State = "UT",
                Age = 70,
                Interests = "Skiing",
                PictureFile = "images/TappanSmall.jpg",
                ZipCode = "84317"
            },
                new Person()
                {
                    Id = 2,
                    FirstName = "Hawkeye",
                    LastName = "Pierce",
                    Address = "1345 Lobster St",
                    City = "Crab Apple Cove",
                    State = "MA",
                    Age = 32,
                    Interests = "Doctoring",
                    PictureFile = "images/Hawkeye.jpg",
                    ZipCode = "47563"
                },
                new Person()
                {
                    Id = 3,
                    FirstName = "Dana",
                    LastName = "Scully",
                    Address = "56 K Street",
                    City = "Washington",
                    State = "DC",
                    Age = 27,
                    Interests = "FBI Forensics Alien Hunter",
                    PictureFile = "images/Scully.jpg",
                    ZipCode = "76887"
                },
                new Person()
                {
                    Id = 4,
                    FirstName = "Gregory",
                    LastName = "House",
                    Address = "4657 Franklin Street",
                    City = "Princeton",
                    State = "NJ",
                    Age = 48,
                    Interests = "Diagnostics, Puzzles",
                    PictureFile = "images/House.jpg",
                    ZipCode = "998364"
                },
                }.AsQueryable();

            var mockSet = new Mock<DbSet<Person>>();
            mockSet.As<IQueryable<Person>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Person>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Person>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Person>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<PeopleAppContext>();
            mockContext.Setup(c => c.People).Returns(mockSet.Object);

            service = new PeopleController(mockContext.Object);
        }
        [TestMethod]
        public void GetPeople()
        {
            
            var people = service.GetPeople();

            Assert.IsNotNull(people);
            Assert.AreEqual(4, people.Count());
            Assert.AreEqual("Joe", people.ElementAt(0).FirstName);
            Assert.AreEqual("Pierce", people.ElementAt(1).LastName);
            Assert.AreEqual("images/Scully.jpg", people.ElementAt(2).PictureFile);
            Assert.AreEqual("Diagnostics, Puzzles", people.ElementAt(3).Interests);
        }

        [TestMethod]
        public void GetCustomPeople()
        {
            var people = service.GetCustomPeople("H");

            Assert.IsNotNull(people);
            Assert.AreEqual(2, people.Count());
            Assert.AreEqual("Hawkeye", people.ElementAt(0).FirstName);
            Assert.AreEqual("House", people.ElementAt(1).LastName);

        }

        [TestMethod]
        public async Task AddAPerson()
        {
            Person newPerson = new Person()
            {
                Id = 5,
                FirstName = "Barry",
                LastName = "Berkman",
                Address = "9483 Sana Rose St",
                City = "Los Angeles",
                State = "CA",
                Age = 27,
                Interests = "Assasin",
                PictureFile = "",
                ZipCode = "95847"
            };

            IHttpActionResult actionResult = await service.PostPerson(newPerson);
            var createdResult = actionResult as CreatedAtRouteNegotiatedContentResult<Person>;

            Assert.IsNotNull(createdResult);
            Assert.AreEqual("Default", createdResult.RouteName);
            Assert.AreEqual(5, createdResult.RouteValues["id"]);
        }

    }
}