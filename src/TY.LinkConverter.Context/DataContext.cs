using System;
using Microsoft.EntityFrameworkCore;

namespace TY.LinkConverter.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Data.Entity.ToDeeplink>().HasData(new Data.Entity.ToDeeplink
            {
                Id = 1,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = null,
                ParameterizedLink = "ty://?Page=Home"
            });

            modelBuilder.Entity<Data.Entity.ToDeeplink>().HasData(new Data.Entity.ToDeeplink
            {
                Id = 2,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\/(.*)\/(.*)-p-(?<content>\d+)\?boutiqueId=(?<boutique>\d+)&merchantId=(?<merchant>\d+$)",
                ParameterizedLink = "ty://?Page=Product&ContentId=[content]&CampaignId=[boutique]&MerchantId=[merchant]"
            });

            modelBuilder.Entity<Data.Entity.ToDeeplink>().HasData(new Data.Entity.ToDeeplink
            {
                Id = 3,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\/(.*)\/(.*)-p-(?<content>\d+$)",
                ParameterizedLink = "ty://?Page=Product&ContentId=[content]"
            });

            modelBuilder.Entity<Data.Entity.ToDeeplink>().HasData(new Data.Entity.ToDeeplink
            {
                Id = 4,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\/(.*)\/(.*)-p-(?<content>\d+)\?boutiqueId=(?<boutique>\d+$)",
                ParameterizedLink = "ty://?Page=Product&ContentId=[content]&CampaignId=[boutique]"
            });

            modelBuilder.Entity<Data.Entity.ToDeeplink>().HasData(new Data.Entity.ToDeeplink
            {
                Id = 5,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\/(.*)/(.*)-p-(?<content>\d+)\?merchantId=(?<merchant>\d+$)",
                ParameterizedLink = "ty://?Page=Product&ContentId=[content]&MerchantId=[merchant]"
            });

            modelBuilder.Entity<Data.Entity.ToDeeplink>().HasData(new Data.Entity.ToDeeplink
            {
                Id = 6,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\/sr\?q=(?<query>.*$)",
                ParameterizedLink = @"ty://?Page=Search&Query=[query]"
            });
            
            modelBuilder.Entity<Data.Entity.ToWebURL>().HasData(new Data.Entity.ToWebURL()
            {
                Id = 1,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = null,
                ParameterizedLink = @"https://www.trendyol.com"
            });

            modelBuilder.Entity<Data.Entity.ToWebURL>().HasData(new Data.Entity.ToWebURL
            {
                Id = 2,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\?Page=Product&ContentId=(?<content>\d+)&CampaignId=(?<campaign>\d+)&MerchantId=(?<merchant>\d+$)",
                ParameterizedLink = @"https://www.trendyol.com/brand/name-p-[content]?boutiqueId=[campaign]&merchantId=[merchant]"
            });

            modelBuilder.Entity<Data.Entity.ToWebURL>().HasData(new Data.Entity.ToWebURL
            {
                Id = 3,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\?Page=Product&ContentId=(?<content>\d+$)",
                ParameterizedLink = @"https://www.trendyol.com/brand/name-p-[content]"
            });

            modelBuilder.Entity<Data.Entity.ToWebURL>().HasData(new Data.Entity.ToWebURL
            {
                Id = 4,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\?Page=Product&ContentId=(?<content>\d+)&CampaignId=(?<campaign>\d+$)",
                ParameterizedLink = @"https://www.trendyol.com/brand/name-p-[content]?boutiqueId=[campaign]"
            });

            modelBuilder.Entity<Data.Entity.ToWebURL>().HasData(new Data.Entity.ToWebURL
            {
                Id = 5,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\?Page=Product&ContentId=(?<content>\d+)&MerchantId=(?<merchant>\d+$)",
                ParameterizedLink = @"https://www.trendyol.com/brand/name-p-[content]?merchantId=[merchant]"
            });
            
            modelBuilder.Entity<Data.Entity.ToWebURL>().HasData(new Data.Entity.ToWebURL
            {
                Id = 6,
                Active = true,
                Deleted = false,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                Pattern = @"^(\w+)+?:\/\/(.*)\?Page=Search&Query=(?<query>.*$)",
                ParameterizedLink = @"https://www.trendyol.com/sr?q=[query]"
            });
        }

        public DbSet<Data.Entity.ToDeeplink> ToDeeplinks{ get; set; }

        public DbSet<Data.Entity.ToWebURL> ToWebUrls{ get; set; }
    }
}