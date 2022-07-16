using Authentication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class GloboTicketAuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public GloboTicketAuthDbContext(DbContextOptions<GloboTicketAuthDbContext> options) : base(options)
        {
        }
    }
}
