using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using BlogIT.Dal.Entities;

namespace BlogIT.Dal.Mapping
{
    public class DataTypeMap : ClassMap<DataType>
    {
        public DataTypeMap()
        {
            Id(x => x.ID);

            Map(x => x.Name);

            Table("DataType");
        }
    }
}
