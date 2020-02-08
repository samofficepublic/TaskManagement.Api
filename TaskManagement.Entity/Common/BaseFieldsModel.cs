using System;

namespace TaskManagement.Entity.Common
{
    public class BaseFieldsModel
    {
        public Int64 ID { get; set; }
        public DateTime CreateDate { get; set; }=DateTime.Now;
        public Int64? CreateBy { get; set; }
        public DateTime ModifyDate { get; set; }
        public Int64? ModifyBy { get; set; }

        public Guid RowVersion
        {
            get
            {
                return new Guid();
            }
        }
    }
}