using static UITraining.Models.GeneralStatus;

namespace UITraining.Models.DTO
{
    public class SupplierDTO
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }
        public GeneralStatusData SupplierStatus { get; set; }
    }
}