namespace DALStuff.Models
{
    public partial class TestResult
    {
        public int Id { get; set; }
        public string Class { get; set; }
        public string TestCase { get; set; }
        public string Name { get; set; }
        public string TranName { get; set; }
        public string Result { get; set; }
        public string Msg { get; set; }
    }
}
