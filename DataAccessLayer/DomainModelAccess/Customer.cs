namespace DataAccessLayer.DomainModelAccess
{
    public class Customer
    {
        public string CustomerKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

    }
}