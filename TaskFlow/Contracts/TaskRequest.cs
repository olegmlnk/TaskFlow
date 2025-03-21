namespace TaskFlow.API.Contracts
{
    public record TaskRequest
    (
        string title,
        string description,
        string status,
        string priority
    );
}
