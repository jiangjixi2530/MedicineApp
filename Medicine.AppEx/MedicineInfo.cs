using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Medicine.AppEx
{
    [Table("MedicineInfo")]
    public class MedicineInfo
    {
        [Key]
        public Int64 Id { get; set; }
        /// <summary>
        /// 药品编码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 货位号
        /// </summary>
        public string ShelfNum { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>
        public string Spec { get; set; }
        /// <summary>
        /// 库存数量
        /// </summary>
        public Int64 Inventory { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 包装规格
        /// </summary>
        public string PackageSpec { get; set; }
        /// <summary>
        /// 厂家
        /// </summary>
        public string Factory { get; set; }
    }
}
