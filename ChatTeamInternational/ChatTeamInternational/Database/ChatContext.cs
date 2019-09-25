using ChatTeamInternational.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatTeamInternational.Database
{
    public class ChatContext: DbContext
    {


        

        public ChatContext(DbContextOptions<ChatContext> options)
            :base(options)
        { 
        }

        public DbSet<User> Users { get; set; }
      
        public DbSet<Message> Message { get; set; }
        


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
           

        //    modelBuilder.Entity<Message>()
        //       .HasKey(t => new { t.UserId, t.MessageId });
        //    modelBuilder.Entity<Message>()
        //        .HasOne(uc => uc.User)
        //        .WithMany(s => s.UserChats)
        //        .HasForeignKey(sc => sc.UserId);
        //    modelBuilder.Entity<UserChat>()
        //        .HasOne(sc => sc.Chat)
        //        .WithMany(c => c.UserChats)
        //        .HasForeignKey(sc => sc.ChatId);

        //    modelBuilder.Entity<UserConnection>()
        //        .HasKey(u => new { u.UserFromId, u.UserToId });

        //}

    }
}
