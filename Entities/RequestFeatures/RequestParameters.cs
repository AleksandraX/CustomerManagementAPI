﻿namespace CustomerManagementPortal.Entities.RequestFeatures
{
    public class RequestParameters
    {
        public int PageNumber { get; set; } = 1;
        private const int MaxPageSize = 50;
        private int _pageSize = 10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
    }
}
