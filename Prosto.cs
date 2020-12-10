using System;
 
namespace Nazvanie
{
	public class Plane
	{
		public static void Flight (int fuelUse, int rangeFly, ref int fuel, ref int flightTime, int speed)
		{
			int maxRangeFly = fuel / fuelUse;
			if (rangeFly > maxRangeFly)
			{
				Console.WriteLine("Полет неудачный");
				fuel = 0;
			}
			else
			{
				fuel -= fuelUse * rangeFly;
				flightTime += rangeFly / speed;
				
			}
		}
		
		public static void Flight (Plane plane, int rangeFly)
		{
			if (rangeFly > plane.MaxRangeFly)
			{
				Console.WriteLine("Полет неудачный");
				plane.Fuel = 0;
			}
			else
			{
				plane.Fuel -= plane.FuelUse * rangeFly;
				plane.FlightTime += rangeFly / plane.Speed;
				
			}
		}
		
		public static void RefuelingPlane (ref int fuel, int gasFuel)
		{
			fuel += gasFuel;
		}
		
		public int FlightTime { get; set; }
		public int Engines{ get; set; }
		public int WearEngine { get; set; }
		public int OperationsEngines { get; set; }
		public int Speed { get; set; }
		public int Weight { get; set; }
		public int WeightEngine { get; set; }
		public int Passangers { get; set; }
		public int MaxRangeFly 
		{
			get{ return Fuel / FuelUse; }
			set{}
		}
		public int FuelUse
		{ 
			get{ return (Weight) / (Engines * OperationsEngines); } 
			set{}
		}
		public int Fuel { get; set; }
		public string Name { get; set; }
	}
	
	class Program
    {
    	static void Main(string[] args)
    	{
    		Plane plane = new Plane();
    		
    		plane.Name = "Крутой";
    		plane.Speed = 1000;
    		plane.FuelUse = 30;
    		plane.Fuel = 10000;
    		plane.Flight(plane, 1800);
    		Console.WriteLine(plane.Fuel);
    	}
    }
}
