using Domain.Location;
using Dto.Common;
using Dto.Location;

namespace Grains.Location;

public class LocationAggregateGrain: Grain<LocationAggregateState>, ILocationAggregateGrain
{
    public async Task<List<LocationDto>> GetLocations(PointDto ulCorner, PointDto rdCorner, ushort zoom)
    {
        throw new NotImplementedException();
    }
}