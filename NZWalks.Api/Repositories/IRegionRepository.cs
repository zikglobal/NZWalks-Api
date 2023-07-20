﻿using Microsoft.EntityFrameworkCore.Update.Internal;
using NZWalks.Api.Model.Domain;
using System.Runtime.InteropServices;

namespace NZWalks.Api.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();

        Task<Region?> GetByIdAsync(Guid id);

        Task<Region> CreateAsync(Region region);

        Task <Region?>UpdateAsync(Guid id, Region region);

        Task<Region?> DeleteAsync(Guid id);
    }
}
