using System.Collections.Generic;

namespace LeagueOfLegends.Common.List
{
    /// <summary>
    /// Class provides additional criteria to implement paging and sorting for lists
    /// </summary>
    public class ListCriteria
    {
        /// <summary>
        /// Initializes a new instance of the ListCriteria class
        /// </summary>
        public ListCriteria()
        {
            this.Sorts = new List<SortExpression>();
        }

        /// <summary>
        /// Gets or sets number of entries to Skip
        /// </summary> 
        public int Skip { get; set; }

        /// <summary>
        /// Gets or sets number of entries to Take
        /// </summary> 
        public int Take { get; set; }

        public bool IsValidForPaging
        {
            get { return Take > 0; }
        }

        /// <summary>
        /// Gets or sets Sort order
        /// </summary> 
        public List<SortExpression> Sorts { get; set; }
    }
}
