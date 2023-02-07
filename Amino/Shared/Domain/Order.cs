namespace Amino.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public string OrderName { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public virtual Platform Platform { get; set; }
        public int PlatformId { get; set; }
    }
}