namespace RestaurentReservationSystem.Abstractions;

public class User
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    protected User(string name, string email)
    {
        Name = name;
        Email = email;
    }
}

public class Customer : User
{
    public List<Reservation> Reservations { get; }

    public Customer(string name, string email) : base(name, email)
    {
        Reservations = new List<Reservation>();
    }

    public void MakeReservation(Reservation reservation)
    {
        Reservations.Add(reservation);
    }
}