namespace Amino.Shared.Domain
{
    public class Order : BaseDomainModel
    {
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public virtual Platform Platform { get; set; }
        public int PlatformId { get; set; }
        public virtual PayType PayType { get; set; }
        public int PayTypeId { get; set; }

    }
}