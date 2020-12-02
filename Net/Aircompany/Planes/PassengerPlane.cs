namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public int PassengersCapacity { get; set; }

        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            :base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            PassengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as PassengerPlane;
            return plane != null && base.Equals(obj) && PassengersCapacity == plane.PassengersCapacity;
        }
                          
        public override string ToString()
        {
            return base.ToString().Replace("}", ", passengersCapacity=" + PassengersCapacity + "}");
        }       
        
    }
}
