namespace App.Repositories
{
    public class ConnectionStringOption
    {
        public const string Key = "ConnectionStrings";
        public string SqlServer { get; set; } = default!;
    }
}