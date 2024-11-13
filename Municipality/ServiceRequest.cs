public class ServiceRequest
{
    public int RequestId { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }

    public ServiceRequest(int requestId, string description, string status)
    {
        RequestId = requestId;
        Description = description;
        Status = status;
    }

    public override string ToString()
    {
        return $"ID: {RequestId}, Description: {Description}, Status: {Status}";
    }
}
