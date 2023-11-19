namespace FizooHelper.Models
{
    public class SearchItem
    {
        public string Field { get; set; }
        public Operators Operator { set; get; }
        public string Value { get; set; }
        public Logic Logic { set; get; }
        public bool IsNum { set; get; } = false;
    }
}
