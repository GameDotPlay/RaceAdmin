namespace RaceAdmin
{
	using System;
	public class Incident
	{
		public Incident(double updateTime, DateTime timeStamp, int value, int carIdx)
		{
			UpdateTime = updateTime;
			TimeStamp = timeStamp;
			Value = value;
			CarIdx = carIdx;
		}

		public double UpdateTime { get; set; }
		public DateTime TimeStamp { get; set; }
		public int Value { get; set; }
		public int CarIdx { get; set; }
	}
}