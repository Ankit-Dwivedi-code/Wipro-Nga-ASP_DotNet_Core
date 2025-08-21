namespace Day27_MVCAssignment2.Models
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

        //Nested Model
        public Address Address { get; set; } = new Address();
    }
}
