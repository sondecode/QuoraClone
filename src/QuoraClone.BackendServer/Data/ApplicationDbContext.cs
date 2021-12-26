﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuoraClone.BackendServer.Data.Entities;

namespace QuoraClone.BackendServer.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<User>().Property(x => x.Id).HasMaxLength(50).IsUnicode(false);
            builder.Entity<LabelInKnowledgeBase>().HasKey(c => new {c.LabelId, c.KnowledgeBaseId});
            builder.Entity<Permission>().HasKey(c => new { c.RoleId, c.FunctionId, c.CommandId});
            builder.Entity<Vote>().HasKey(c => new { c.KnowledgeBaseId, c.UserId });
            builder.Entity<CommandInFunction>().HasKey(c => new { c.CommandId, c.FunctionId });
            builder.HasSequence("KnowledgeBaseSequence");
        }
        public DbSet<Command> Commands { get; set; }
        public DbSet<CommandInFunction> CommandInFunctions { get; set; }
        public DbSet<ActivityLog> ActivityLog { get; set; }
        public DbSet<Category>  Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<KnowledgeBase> KnowledgeBases { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<LabelInKnowledgeBase>  LabelInKnowledgeBases { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
    }
}
