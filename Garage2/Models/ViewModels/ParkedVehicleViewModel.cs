using System.ComponentModel.DataAnnotations;

namespace Garage2.Models.ViewModels
{
	public class ParkedVehicleViewModel
	{
		[Key]
		public string RegistrationNumber { get; set; }
		public VehicleType VehicleType { get; set; }
		
		public DateTime ArrivalTime { get; set; }
	}
}
