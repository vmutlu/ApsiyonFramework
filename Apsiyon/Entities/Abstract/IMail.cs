namespace Apsiyon.Entities.Abstract
{
    public interface IMail
    {
        string Address { get; set; }
        string Subject { get; set; }
        string Message { get; set; }
        bool IsBody { get; set; }
    }
}
