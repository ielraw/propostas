namespace Domain.Entities
{
    public interface IIdentityEntity
    {
        string Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
    }
}
