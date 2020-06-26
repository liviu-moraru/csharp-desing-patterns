using System;
using System.Drawing;
using System.Windows.Forms;

namespace MarkerPositions
{
    public class Marker : Label
    {
        private MarkerMediator _mediator;
        private Point mouseDownLocation;

        public Marker()
        {
            this.Text = "Drag me";
            this.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
        }

        public void SetMediator(MarkerMediator mediator)
        {
            _mediator = mediator;
        }
        
        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.mouseDownLocation = e.Location;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Text = this.Location.ToString();
                this.Left = e.X + this.Left - this.mouseDownLocation.X;
                this.Top = e.Y + this.Top - this.mouseDownLocation.Y;
                this._mediator.Send(this.Location, this);
            }
        }

        public void ReceiveLocation(Point location)
        {
            var distance = CalcDistance(location);
            if (distance < 100 && this.BackColor != Color.Red)
            {
                this.BackColor = Color.Red;
            }
            else if (distance >= 100 && this.BackColor != Color.Green)
            {
                this.BackColor = Color.Green;
            }
            double CalcDistance(Point point) =>
                Math.Sqrt(Math.Pow(this.Location.X - location.X, 2) + Math.Pow(this.Location.Y - location.Y, 2));
        }
    }
}