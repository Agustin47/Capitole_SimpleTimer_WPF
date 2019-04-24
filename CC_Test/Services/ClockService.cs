using CC_Test.Contracts;

namespace CC_Test.Services
{
    public class ClockService : IClockService
    {

        public PauseClockResponse PauseClock(PauseClockRequest request)
        {
            return new PauseClockResponse { Time = request.Time };
        }

        public StartClockResponse StartClock(StartClockRequest request)
        {
            return new StartClockResponse { Time = request.Time.AddMilliseconds(500) };
        }

        public StopClockResponse StopClock(StopClockRequest request)
        {
            return new StopClockResponse { Time = "00:00:00" };

        }
    }
}
