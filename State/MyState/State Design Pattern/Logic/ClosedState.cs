namespace State_Design_Pattern.Logic
{
    public class ClosedState : BookingState
    {
        private readonly string _reason;

        public ClosedState(string reason)
        {
            _reason = reason;
        }
        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed");
            booking.View.ShowStatusPage(_reason);
        }

        public override void Cancel(BookingContext booking)
        {
            booking.View.ShowError("Invalid action for this state");
        }

        public override void DataPassed(BookingContext booking)
        {
            booking.View.ShowError("Invalid action for this state");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.View.ShowError("Invalid action for this state");
        }
    }
}