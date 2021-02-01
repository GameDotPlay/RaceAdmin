namespace RaceAdmin
{
    public class Driver
    {
        private int carIdx;
        private string fullName;
        private string carNum;
        private string iRating;
        private int oldIncs;
        private int newIncs;
        private int currentLap;

        public Driver()
        {
            carIdx = -1;
            fullName = "Empty";
            carNum = "-1";
            iRating = "-1";
            oldIncs = 0;
            newIncs = 0;
            currentLap = 0;
        }

        public Driver(int carIdx, string name, string carNum, string iRating, int incidentCount, int newIncs, int currentLap)
        {
            this.carIdx = carIdx;
            this.fullName = name;
            this.carNum = carNum;
            this.iRating = iRating;
            this.oldIncs = incidentCount;
            this.newIncs = newIncs;
            this.currentLap = currentLap;
        }

        public int CarIdx { get; set; }
        public string FullName { get; set; }
        public string TeamName { get; set; }
        public string CarNum { get; set; }
        public string IRating { get; set; }
        public int OldIncs { get; set; }
        public int NewIncs { get; set; }
        public string TeamIncs { get; set; }
        public int CurrentLap { get; set; }
    }
}
