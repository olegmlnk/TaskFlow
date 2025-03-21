namespace TaskFlow.API.Contracts
{
    public record TaskResponse
    (
        Guid id,
        string title,
        string description,
        string status,
        string priority
    );
}
