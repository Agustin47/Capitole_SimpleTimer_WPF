

namespace CC_Test.Contracts
{
    public interface IClockService
    {

        /// <summary>
        /// Pausa el Reloj.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        PauseClockResponse PauseClock(PauseClockRequest request);


        /// <summary>
        /// Comienza el Reloj.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        StartClockResponse StartClock(StartClockRequest request);


        /// <summary>
        /// Reinicia el Reloj.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        StopClockResponse StopClock(StopClockRequest request);


    }
}
