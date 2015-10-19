namespace JsonToMySql
{
    using Models;
    using System.Linq;
    using Telerik.OpenAccess;
    using Telerik.OpenAccess.Metadata;

    public partial class FluentModelContent : OpenAccessContext
    {
        private static BackendConfiguration backend = GetBackendConfiguration();

        private static MetadataSource metadataSource = new FluentModel();

        public FluentModelContent()
            : base("Server=localhost;Database=LaptopDB;Uid=root;Pwd=123456789;", backend, metadataSource)
        { }

        internal IQueryable<MakersProfit> Reports
        {
            get
            {
                return this.GetAll<MakersProfit>();
            }
        }

        public static BackendConfiguration GetBackendConfiguration()
        {
            BackendConfiguration backend = new BackendConfiguration();
            backend.Backend = "MySql";
            backend.ProviderName = "MySql.Data.MySqlClient";

            return backend;
        }
    }
}
