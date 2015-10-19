using JsonToMySql.Models;
using System.Collections.Generic;
using Telerik.OpenAccess.Metadata.Fluent;

namespace JsonToMySql
{
    public class FluentModel : FluentMetadataSource
    {
        protected override IList<MappingConfiguration> PrepareMapping()
        {
            List<MappingConfiguration> configurations = new List<MappingConfiguration>();

            var modelMapping = new MappingConfiguration<MakersProfit>();
            modelMapping.MapType(r => new
            {
                Id = r.MakerId,
                Name = r.MakerName,
                Profit = r.Profit
            }).ToTable("Reports");

            modelMapping.HasProperty(r => r.MakerId).IsIdentity();

            configurations.Add(modelMapping);

            return configurations;
        }
    }
}
