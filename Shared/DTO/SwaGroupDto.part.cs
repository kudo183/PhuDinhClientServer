﻿using System.ComponentModel;

namespace DTO
{
    public partial class SwaGroupDto : IDto, INotifyPropertyChanged
    {
        [Newtonsoft.Json.JsonIgnore]
        public string TenHienThi
        {
            get
            {
                return GroupName;
            }
        }
    }
}
