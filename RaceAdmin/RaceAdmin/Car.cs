namespace RaceAdmin
{
	using iRacingSdkWrapper;

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
		public string CarClassID { get; set; }
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
	}
}
