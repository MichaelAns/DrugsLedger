using DrugsLedger.Persistance.Models.Base;
using DrugsLedger.Persistance.Models.Enums;

namespace DrugsLedger.Persistance.Models
{
    public class Drug : BaseEntity
    {
        public string Name { get; set; }
        public int StorageLife { get; set; }
        public string OriginCountry { get; set; }        
        public DrugType DrugType { get; set; }
        public DistributionType DistributionType { get; set; }
        public StorageFeatures StorageFeatures { get; set; }
        public virtual ICollection<DrugShipment> DrugShipments { get; set; }
    }
}
