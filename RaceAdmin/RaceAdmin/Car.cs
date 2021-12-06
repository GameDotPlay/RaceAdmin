namespace RaceAdmin
{
	using iRacingSdkWrapper;
	using System;

	public class Car
	{
		// Internally updated variables.
		public bool LastBetweenPitCones { get; set; }

		// Session info variables.
		public int CarIdx { get; set; }
		public string CurrentDriver { get; set; }
		public string TeamName { get; set; }
		public string TeamID { get; set; }
		public int TeamIncidentCount { get; set; }
		public string CarNumber { get; set; }
		public string CarScreenName { get; set; }
		public string CarClassShortName { get; set; }
		
		// Live telemetry variables.
		public float PercentAroundTrack { get; set; }
		public bool BetweenPitCones { get; set; }
		public int CurrentLap { get; set; }
		public int LapsCompleted { get; set; }
		public TrackSurfaces TrackSurface { get; set; }
		public TrackSurfaceMaterials TrackSurfaceMaterial { get; set; }
		public int OverallPositionInRace { get; set; }
		public int ClassPositionInRace { get; set; }

		public override string ToString()
		{
			return $"CarIdx: {CarIdx}{Environment.NewLine}" +
				   $"Current Driver: {CurrentDriver}{Environment.NewLine}" +
				   $"Team Name: {TeamName}{Environment.NewLine}" +
				   $"Team ID: {TeamID}{Environment.NewLine}" +
				   $"Team Incident Count: {TeamIncidentCount}{Environment.NewLine}" +
				   $"Car Number: {CarNumber}{Environment.NewLine}" +
				   $"Car Class: {CarClassShortName}{Environment.NewLine}" +

				   $"Live variables: {Environment.NewLine}" +
				   $"Percent Around Track: {PercentAroundTrack}{Environment.NewLine}" +
				   $"Between Pit Cones: {BetweenPitCones}{Environment.NewLine}" +
				   $"Current Lap: {CurrentLap}{Environment.NewLine}" +
				   $"Laps Completed: {LapsCompleted}{Environment.NewLine}" +
				   $"Track Surface: {TrackSurface}{Environment.NewLine}" +
				   $"Track Surface Material: {TrackSurfaceMaterial}{Environment.NewLine}" +
				   $"Overall Position in Race: {OverallPositionInRace}{Environment.NewLine}" +
				   $"Class Position in Race: {ClassPositionInRace}{Environment.NewLine}";
		}
	}
}
