﻿using System.ComponentModel;

namespace DTO
{
    public partial class TChuyenHangDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return "TenHienThi";
            }
        }
    }
}
