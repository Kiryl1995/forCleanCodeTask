using Aircompany.Models;
using Aircompany.Planes;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; set; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return Planes.Where(p => p.GetType() == typeof(PassengerPlane)).Select(p => p as PassengerPlane).ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.Where(p => p.GetType() == typeof(MilitaryPlane)).Select(p => p as MilitaryPlane).ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            List<PassengerPlane> passengerPlanes = GetPassengersPlanes();
            return passengerPlanes.Aggregate((currentItem, nextItem) => currentItem.PassengersCapacity > nextItem.PassengersCapacity ? currentItem : nextItem);             
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            List<MilitaryPlane> militaryPlanes = GetMilitaryPlanes();
            return militaryPlanes.Where(p => p.Type == MilitaryType.Transport).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(w => w.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(w => w.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(w => w.MaxLoadCapacity));
        }


        public override string ToString()
        {
            return "Airport{planes=" + string.Join(", ", Planes.Select(x => x.Model)) + "}";
        }
    }
}
