namespace RaceAdmin
{
    public class Driver
    {
        public int CarIdx { get; set; }
        public string FullName { get; set; }
        public string TeamName { get; set; }
        public string CarNum { get; set; }
        public string IRating { get; set; }
        public int OldIncs { get; set; }
        public int NewIncs { get; set; }
        public string TeamIncs { get; set; }
        public int CurrentLap { get; set; }

        public Driver()
        {
            CarIdx = -1;
            FullName = "Empty";
            CarNum = "-1";
            IRating = "-1";
            OldIncs = 0;
            NewIncs = 0;
            CurrentLap = 0;
        }
    }
}
