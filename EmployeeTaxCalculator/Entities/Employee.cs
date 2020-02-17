namespace Project1.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public CostToCompany CostToCompany { get; set; }
    }
}
