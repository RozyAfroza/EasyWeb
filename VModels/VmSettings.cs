using System;
using System.Collections.Generic;

namespace LearningProject.VModels
{
    public abstract class BaseVm
    {
        public int ID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }

    }
    public class VmShop : BaseVm
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ShopNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public List<VmShop> DataList { get; set; } = new List<VmShop>();
    }
}
