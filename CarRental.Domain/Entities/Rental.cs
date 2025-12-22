using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRental.Domain.Entities;

[Table("rentals")]
public class Rental
{
    [Column("id")]
    public int Id { get; set; }

    [Column("rental_date")]
    public required DateTime RentalDate { get; set; }

    [Column("rental_hours")]
    public required int RentalHours { get; set; }

    [Column("car_id")]
    public required int CarId { get; set; }

    [Column("client_id")]
    public required int ClientId { get; set; }

    public Car? Car { get; set; }
    public Client? Client { get; set; }
}