namespace ModelsClass
{
    public class books
    {
        public books(int idbook, string author, string pages, string lang)
        {
            this.idbook = idbook;
            this.author = author;
            this.pages = pages;
            this.lang = lang;
        }
        public books() { }
        public int idbook { get; set; }
        public string author { get; set; }
        public string pages { get; set; }
        public string lang { get; set; }
    }
}