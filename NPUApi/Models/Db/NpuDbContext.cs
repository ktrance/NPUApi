using Microsoft.EntityFrameworkCore;

namespace NPUApi.Models.Db;

public class NpuDbContext(DbContextOptions<NpuDbContext> options) : DbContext(options)
{
    public DbSet<Npu> Npus { get; set; }
}