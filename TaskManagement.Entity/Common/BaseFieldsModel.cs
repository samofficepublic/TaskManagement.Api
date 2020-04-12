using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManagement.Entity.Common
{
    public class BaseFieldsModel
    {
        [Column(Order = 1)]
        public Int64 ID { get; set; }
        [Column(Order = 2)]
        public Guid UniqueId { get; set; }
        [Column(Order = 999)]
        public DateTime CreateDate { get; set; }=DateTime.UtcNow;
        [Column(Order = 1000)]
        public Int64? CreateBy { get; set; }
        [Column(Order = 1001)]
        public DateTime ModifyDate { get; set; }=DateTime.UtcNow;
        [Column(Order = 1002)]
        public Int64? ModifyBy { get; set; }

    }
}