namespace WebAuction.Models
{
    public class Lot
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float BuyOutPrice { get; set; } = 0f;
        public float StartPrice { get; set; } = 0f;
        public float Bet { get; set; } = 0f;
    }
}