namespace Venhancer.Crowd.Core.Confugiration
{
    public class Client
    {
        public string? Id { get; set; }
        public string? Secret { get; set; }
        public List<string>? Audiences { get; set; } ///Client Hangi API ye erişebilir
    }
}
