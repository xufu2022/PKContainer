using Microsoft.EntityFrameworkCore;

namespace KP.SharedKernel.Configuration;

public interface IModelConfiguration
{
    void ConfigureModel(ModelBuilder modelBuilder);
}
