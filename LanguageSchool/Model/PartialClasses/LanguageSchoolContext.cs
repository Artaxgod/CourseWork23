using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LanguageSchool.Model;


namespace LanguageSchool.Model
{
    public partial class LanguageSchoolContext : DbContext
    {
        public LanguageSchoolContext() : base("name=LanguageSchoolDBEntities") { }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<Schedules> Schedules { get; set; }
        public virtual DbSet<Homeworks> Homeworks { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Feedbacks> Feedbacks { get; set; }
    }
}
