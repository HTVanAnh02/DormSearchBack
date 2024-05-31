namespace DormSearchBe.Api.Controllers.Favorites
{
    public class FavoritesHouse
    {
        public string? Favorite_House_Id { get; set; }
        public string? HouseId { get; set; }
        public string? IsFavorite_House { get; set; }
        public ReadOnlySpan<char> FavoriteHouseId { get; internal set; }
    }
}
