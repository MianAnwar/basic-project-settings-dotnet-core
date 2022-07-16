using Persistence;
using System;
using Xunit;
using System.Linq;
using Shouldly;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Contracts;
using Moq;
using System.Collections.Generic;

namespace Db.Test
{
    public class GloboTicketDbContextTests
    {
        private readonly GloboTicketDbContext _globoTicketDbContext;
        private readonly Mock<ILoggedInUserService> _loggedInUserServiceMock;
        private readonly string _loggedInUserId;
        public GloboTicketDbContextTests()
        {
            var dbContextOptions = new DbContextOptionsBuilder<GloboTicketDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _loggedInUserId = "00000000-0000-0000-0000-000000000000";
            _loggedInUserServiceMock = new Mock<ILoggedInUserService>();
            _loggedInUserServiceMock.Setup(
                                        m => m.UserId
                                        ).Returns(_loggedInUserId);

            _globoTicketDbContext = new GloboTicketDbContext(dbContextOptions, _loggedInUserServiceMock.Object);
        }

        [Fact]
        public async void Save_SetCreatedByProperty()
        {
            var x = Guid.NewGuid();
            var ev = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _globoTicketDbContext.Events.Add(ev);
            await _globoTicketDbContext.SaveChangesAsync();

            ev.CreatedBy.ShouldBe(_loggedInUserId);
        }

        [Fact]
        public async void Get_ListOfEvents()
        {
            var ev1 = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };
            var ev2 = new Event() { EventId = Guid.NewGuid(), Name = "Test event" };

            _globoTicketDbContext.Events.Add(ev1);
            _globoTicketDbContext.Events.Add(ev2);
            await _globoTicketDbContext.SaveChangesAsync();

            var x = _globoTicketDbContext.Events.AllAsync(x => x.LastModifiedDate < DateTime.Now);
            List<Event> nn = (from e in _globoTicketDbContext.Events select e).ToList();

            nn.Count.ShouldBe(2);
        }
    }
}
