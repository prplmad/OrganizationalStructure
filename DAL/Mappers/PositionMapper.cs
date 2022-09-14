

namespace DAL.Mappers
{
    public static class PositionMapper
    {
        public static DAL.Entities.PositionEntity FromBusinessToEntities(this BL.Models.Position position)
        {
            return new DAL.Entities.PositionEntity
            {
                CreatedAt = position.CreatedAt,
                IsDeleted = position.IsDeleted,
                PositionName = position.PositionName
            };
        }
    }
}
