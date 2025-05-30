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

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
    }
}
