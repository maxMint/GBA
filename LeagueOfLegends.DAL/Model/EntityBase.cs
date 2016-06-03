using System.ComponentModel.DataAnnotations;

namespace LeagueOfLegends.DAL.Model
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }

        public bool IsNew
        {
            get { return Id == 0; }
        }
    }
}