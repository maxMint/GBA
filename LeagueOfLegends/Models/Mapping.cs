using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using AutoMapper;
using LeagueOfLegends.Common.List;
using LeagueOfLegends.DataTables;

namespace LeagueOfLegends.Models
{
    public static class Mapping
    {
        public static void Init()
        {

            Mapper.Initialize(m =>
            {
                BLL.Mapping.Init(m);

                m.CreateMap<IDataTablesRequest, ListCriteria>()
                .ForMember(x => x.Skip, cfg => cfg.MapFrom(y => y.Start))
                .ForMember(x => x.Take, cfg => cfg.MapFrom(y => y.Length))
                .ForMember(x => x.Sorts, cfg =>
                cfg.MapFrom(y => y.Columns.GetSortedColumns().Select(
                    c =>
                    new SortExpression
                    {
                        Column = c.Data,
                        Direction =
                                    c.SortDirection == Column.OrderDirection.Ascendant
                                        ? ListSortDirection.Ascending
                                        : ListSortDirection.Descending
                    }).ToList()));
            });
        }
    }
}