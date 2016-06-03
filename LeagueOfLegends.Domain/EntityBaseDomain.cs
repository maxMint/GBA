
namespace LeagueOfLegends.Domain
{
    public abstract class EntityBaseDomain
    {
        public long Id { get; set; }

        public bool IsNew => Id == 0;
    }
}