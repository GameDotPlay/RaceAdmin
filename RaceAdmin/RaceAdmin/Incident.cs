namespace RaceAdmin
{
	using System;
	public class Incident
	{
		public Incident(double sessionTime, DateTime timeStamp, int value, int carIdx)
		{
			this.SessionTime = sessionTime;
			this.TimeStamp = timeStamp;
			this.Value = value;
			this.CarIdx = carIdx;
		}

		public DateTime TimeStamp { get; set; }
		public double SessionTime { get; set; }
		public int Value { get; set; }
		public int CarIdx { get; set; }
	}
}