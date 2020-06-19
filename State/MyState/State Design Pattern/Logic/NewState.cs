using System;

namespace State_Design_Pattern.Logic
{
    public class NewState : BookingState
    {
        public override void EnterState(BookingContext booking)
        {
            booking.BookingID = new Random().Next();
            booking.ShowState("New");
            booking.View.ShowEntryPage();
        }

        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Canceled"));
        }

        public override void DataPassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Booking Expired"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            booking.Attendee = attendee;
            booking.TicketCount = ticketCount;
            booking.TransitionToState(new PendingState());            
        }
    }
}