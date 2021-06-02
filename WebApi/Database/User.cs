namespace WebApi.Database
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int UserId { get; internal set; }
    }
}