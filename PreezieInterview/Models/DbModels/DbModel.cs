namespace PreezieInterview.Api.Models.DbModels
{
    public abstract class DbModel
    {
        public DbModel()
        {
            Id = Nanoid.Nanoid.Generate();
        }

        public string Id { get; protected set; }
    }
}
