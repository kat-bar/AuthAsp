using Auth.Models;

namespace Auth.ViewModels
{
    public class Book
    {
        public int Id { get; set; }
        public User UserId { get; set; }
        public string Name { get; set; }    // название 
        public string Company { get; set; }
        public int Price { get; set; }
    }
}
