using Dto.Common;
using Dto.Location;

namespace Domain.Location;

public interface ILocationAggregateGrain: IGrainWithIntegerKey
{
    Task<List<LocationDto>> GetLocations(PointDto ulCorner, PointDto rdCorner, ushort zoom); 
}