using System;
using System.ComponentModel;

namespace LeagueOfLegends.Common.List
{
    /// <summary>
    /// Class provides criteria for entity sorting
    /// </summary>
    public class SortExpression
    {
        /// <summary>
        /// Gets or sets Column
        /// </summary> 
        public string Column { get; set; }

        /// <summary>
        /// Gets or sets Direction
        /// </summary> 
        public ListSortDirection Direction { get; set; }

        public String Key
        {
            get { return String.Format("{0}_{1}", Column, Direction == ListSortDirection.Ascending ? "ASC" : "DESC"); }
        }
    }
}
