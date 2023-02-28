using DrugsLedger.Persistance.Models.Base;

namespace DrugsLedger.Persistance.Models
{
    public class Shipment : BaseEntity
    {
        public DateOnly Date { get; set; }
        public virtual ICollection<DrugShipment> DrugShipments { get; set; }
    }
}
