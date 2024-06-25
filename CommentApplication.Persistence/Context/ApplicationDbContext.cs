using CommentApplicatin.Domain.Common;
using CommentApplicatin.Domain.Entities;
using CommentApplication.Persistence.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IMediator? _mediator;

        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IMediator? mediator) : base(options)
        {
            _mediator = mediator;
        }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostComment> PostComments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PostComments;User Id=WorldCities;Password=MyVeryOwn$721;Integrated Security=False;MultipleActiveResultSets=True;TrustServerCertificate=True",
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
  
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken() )
        {
            await _mediator!.DispatchDomainEvents(this);

            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTimeOffset.Now;
                        break;                   
                   
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
