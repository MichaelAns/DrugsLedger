using DrugsLedger.Persistance.Models;
using DrugsLedger.Persistance.Models.Base;

namespace DrugsLedger.Persistance
{
    public class DrugShipment : BaseEntity
    {
        public int Count { get; set; }
        public int DrugId { get; set; }
        public int ShipmentId { get; set; }
        public virtual Drug Drug { get; set; }
        public virtual Shipment Shipment { get; set; }
    }
}
