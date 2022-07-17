namespace CPMS.Data
{
    internal class DAO
    {
        protected readonly string connectionString =
            @"Data Source=(localdb)\ProjectModels;
                Initial Catalog=CPMS;
                Integrated Security=True;
                Connect Timeout=30;Encrypt=False;
                TrustServerCertificate=False;
                ApplicationIntent=ReadWrite;
                MultiSubnetFailover=False";
    }
}
