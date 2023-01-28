namespace HotelAPI.Models
{
    public class PagedResult<T>
    {
        public int TotalCount { get; set; }      // Total records
        public int PageNumber { get; set; }      //Current page number
        public int RecordNumber { get; set; }    //Number of records 
        
        public List<T> Items { get; set; }       //List of Records
    }  
}
