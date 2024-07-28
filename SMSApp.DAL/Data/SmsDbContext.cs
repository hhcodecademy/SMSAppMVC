using Microsoft.EntityFrameworkCore;
using SMSApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.DAL.Data
{
    public class SmsDbContext:DbContext
    {
        public SmsDbContext(DbContextOptions<SmsDbContext> opts):base(opts)
        {
            
        }
        public DbSet<Student> Students { get; set; }
    }
}
