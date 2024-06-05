namespace ModelLayer
{
    public class StudentModel(string Name, string Address, string Email)
    { 
        public string Name { get; set; } = Name;
        public string Address { get; set; } = Address;
        public string Email { get; set; } = Email;

        public override string ToString() => $" {Name} {Address} {Email} ";
    }
}
