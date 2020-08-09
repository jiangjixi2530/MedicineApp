using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medicine.AppEx.ViewModel
{
    public class Medicine
    {
        public string 药品编码 { get; set; } = string.Empty;
        public string 药品名称 { get; set; } = string.Empty;
        public string 规格 { get; set; } = string.Empty;
        public string 厂家 { get; set; } = string.Empty;
        public int 基本数量 { get; set; }
        public string 单位 { get; set; } = string.Empty;
        public string 包装规格 { get; set; } = string.Empty;
        // public string 包装数量 { get; set; }
        public string 货位号 { get; set; } = string.Empty;
        public string 备注 { get; set; } = string.Empty;
    }
}
