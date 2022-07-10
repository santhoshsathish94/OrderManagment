namespace OrderManagment.Repository
{
    public class DatabaseOptions
    {
        public const string SectionName = "ConnectionStrings";
        public string OrderDatabase { get; set; } = string.Empty;
    }
}
