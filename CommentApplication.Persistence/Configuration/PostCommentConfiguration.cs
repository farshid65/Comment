using CommentApplicatin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentApplication.Persistence.Configuration
{
    public class PostCommentConfiguration : IEntityTypeConfiguration<PostComment>
    {
        public void Configure(EntityTypeBuilder<PostComment> builder)
        {
            builder.ToTable("PostComment", "dbo");
            builder.HasKey(sc => new {sc.PostsId,sc.CommentsId});
            builder.HasOne(sc => sc.Post)
                .WithMany(s => s.PostComments)
                .HasForeignKey(sc => sc.PostsId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(sc => sc.Comment)
                .WithMany(s=>s.PostComments)
                .HasForeignKey(sc => sc.CommentsId);
            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostComments);    
        }
    }
}
