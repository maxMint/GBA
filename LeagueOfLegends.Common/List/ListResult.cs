using System.Collections.Generic;

namespace LeagueOfLegends.Common.List
{
    /// <summary>
    /// Class provides ListResult class to add total count to data list
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    public class ListResult<T>
    {
        /// <summary>
        /// Gets or sets Data (list of entities)
        /// </summary> 
        public List<T> Data { get; set; }

        /// <summary>
        /// Gets or sets Total Count
        /// </summary> 
        public int Total { get; set; }
    }
}
