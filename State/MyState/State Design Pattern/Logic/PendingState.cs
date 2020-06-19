using System;
using System.Threading;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {
        private CancellationTokenSource _cancelToken;
        public override void EnterState(BookingContext booking)
        {
            _cancelToken = new CancellationTokenSource();
            booking.ShowState("Pending");
            booking.View.ShowStatusPage("Processiong Booking");
            StaticFunctions.ProcessBooking(booking, ProcessingComplete, _cancelToken);
        }

        public override void Cancel(BookingContext booking)
        {
            _cancelToken.Cancel();
        }

        public override void DataPassed(BookingContext booking)
        {
            
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            
        }
        
        private void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
            }
        }
    }
}