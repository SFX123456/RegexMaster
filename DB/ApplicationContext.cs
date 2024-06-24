using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegexMaster.Models;

namespace RegexMaster.DB;

public class ApplicationContext :IdentityDbContext<User>
{
    public DbSet<Reward> Rewards { get; set; }
    public override DbSet<User> Users { get; set; }
    public DbSet<RewardUser> RewardsUsers { get; set; }
    public DbSet<Level> Levels {get; set; }
    public DbSet<Campaign> Campaigns { get; set; }
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
                    :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Level>().ToTable("Level");
        
        builder.Entity<Reward>().ToTable("Reward");
        builder.Entity<RewardUser>().ToTable("RewardUser");

        builder.Entity<Campaign>().ToTable("Campaign");
        builder.Entity<CampaignLevel>().ToTable("CampaignLevel");

        /*
        builder.Entity<CampaignLevel>()
                        .HasKey(ur => new { ur.CampaignId, ur.LevelId });
        
        */
        
        builder.Entity<CampaignLevel>()
                        .HasOne(ur => ur.Campaign)
                        .WithMany(u => u.CampaignLevels)
                        .HasForeignKey(ur => ur.CampaignId);

        builder.Entity<CampaignLevel>()
                        .HasOne(ur => ur.Level)
                        .WithMany(r => r.CampaignLevels)
                        .HasForeignKey(ur => ur.LevelId);
        
        builder.Entity<RewardUser>()
                        .HasKey(ur => new { ur.UserId, ur.RewardId });

        builder.Entity<RewardUser>()
                        .HasOne(ur => ur.User)
                        .WithMany(u => u.RewardUsers)
                        .HasForeignKey(ur => ur.UserId);

        builder.Entity<RewardUser>()
                        .HasOne(ur => ur.Reward)
                        .WithMany(r => r.RewardsUsers)
                        .HasForeignKey(ur => ur.RewardId);

        builder.Entity<Level>()
                        .HasOne(ur => ur.Creater)
                        .WithMany(r => r.CreatedLevels)
                        .HasForeignKey(r => r.CreatedFrom);
        
        builder.Entity<Campaign>()
                        .HasOne(ru => ru.Reward)
                        .WithMany(ru => ru.Campaigns)
                        .HasForeignKey(ru => ru.RewardId);
        
        builder.Entity<Campaign>()
                        .HasOne(ru => ru.LastChangedFrom)
                        .WithMany(ru => ru.LastChangedCampaigns)
                        .HasForeignKey(ru => ru.LastChangedFromId);
        
        
        
        var user = new User();
       builder.Entity<User>().HasData(user);
       int levelId = 1;
       var level = new Level()
       {
                       CreatedFrom = user.Id, Description = "test", Difficulty = 1, UpVotes = 1, DownVotes = 2,
                       CreatedAt = DateTime.Now, Headline = "easy regex", Id = levelId
       };
       levelId++;
       builder.Entity<Level>().HasData(level);
       int campaignId = 1;
       builder.Entity<Campaign>()
                       .HasData(new Campaign()
                       {
                                       RewardId = 1, Description = "test", Headline = "haah", CreatedAt = DateTime.Now,
                                       LastChangedFromId = user.Id, LastChangedTime = DateTime.Now, Id = campaignId
                       });
       campaignId++;
       int campaignLevelId = 1;
       builder.Entity<CampaignLevel>()
                       .HasData(new CampaignLevel() {Id = campaignLevelId, CampaignId = 1, LevelId = 1, LevelAdded = DateTime.Now});
       int rewardId = 1;
        builder.Entity<Reward>().HasData(new Reward() {Id = rewardId, ShortDesc = "test", LongDesc = "test1", AvailableFrom = DateTime.Now, IconUrl = ""});
        rewardId++;
        int rewardUser = 1;
        builder.Entity<RewardUser>().HasData(new RewardUser() {Id = rewardUser, UserId = user.Id, RewardId = 1, AchievedAt = DateTime.Now });
        rewardUser++;
    }
}