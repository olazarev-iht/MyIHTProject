using IhtApcWebServer.Data.Models.APCHardware;
using Microsoft.EntityFrameworkCore;

namespace IhtApcWebServer.Data
{
    public class APCHardwareArchiveDBContext : DbContext
    {
        private static readonly object Lock = new();

        public DbSet<APCDevice> APCDevices { get; set; } = null!;

        public DbSet<ConstParams> ConstParams { get; set; } = null!;

        public DbSet<DynParams> DynParams { get; set; } = null!;

        public DbSet<LiveParams> LiveParams { get; set; } = null!;

        public DbSet<ParameterData> ParameterDatas { get; set; } = null!;

        public DbSet<ParameterDataInfo> ParameterDataInfos { get; set; } = null!;

        public DbSet<ParamViewGroup> ParamViewGroups { get; set; } = null!;

        public DbSet<ParamSettings> ParamSettings { get; set; } = null!;

        public DbSet<ConfigSettings> ConfigSettings { get; set; } = null!;

        public DbSet<ErrorLog> ErrorLogs { get; set; } = null!;

        public APCHardwareArchiveDBContext(DbContextOptions<APCHardwareArchiveDBContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            throw new NotSupportedException("Use SaveChangesAsync instead");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            lock (Lock)
            {
                return base.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
