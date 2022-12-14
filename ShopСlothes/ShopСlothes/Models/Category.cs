namespace ShopСlothes.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Categoryy { get; set; }
        public string? Description { get; set; }
        public List<Car>? cars { get; set; }//у каждой категолии будет свой товар?какие товарф входят
    }
}
