namespace State_Design_Pattern.Logic
{
    public class NewState : BookingState
    {
        public override void EnterState(BookingContext booking)
        {
            
        }

        public override void Cancel(BookingContext booking)
        {
            booking.State = new ClosedState();
        }

        public override void DataPassed(BookingContext booking)
        {
            
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            
        }
    }
}