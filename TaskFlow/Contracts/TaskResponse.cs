namespace TaskFlow.API.Contracts
{
    public record TaskResponse
    (
        long id,
        string title,
        string description,
        string status,
        string priority
    );
}
