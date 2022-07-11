﻿namespace OrderManagment.Domain.Critierias
{
    public class SearchCriteria
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public int OFFSet { 
            get
            {
                return (PageNumber - 1) * PageSize;
            }
        }
    }
}
