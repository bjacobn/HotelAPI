namespace HotelAPI.Core.Models
{
    public class QueryParameters
    {
        private int _pageSize = 15;            //Defualt records per page
        public int StartIndex { get; set; }    //Start at index ?
        public int PageNumber { get; set; }    //Current page number

        //Custom records per page
        public int PageSize                    
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value;
            }
        }
    }
}
