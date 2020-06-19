namespace State_Design_Pattern.Logic
{
    public class BookedState : BookingState
    {
        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Booked");
            booking.View.ShowStatusPage("Enjoy the Event");
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking cancelled: Expect a refund"));
        }

        public override void DataPassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("We hope you enjoyed the event"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            
        }
    }
}