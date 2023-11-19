
namespace FizooHelper.Models
{
    public class Respond<T>
    {
        public T? Data { set; get; }
        public bool IsSuccess { set; get; }
        public string? Message { set; get; }
    }
}
