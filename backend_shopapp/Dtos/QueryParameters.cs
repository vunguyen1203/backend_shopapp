namespace backend_shopapp.Dtos
{
    public class QueryParameters  
    {  
        public string? Search { get; set; }  
        public string Sort { get; set; } = "CreatedAt";  
        public string Dir { get; set; } = "desc";
        public int Page { get; set; } = 1;  
        public int Size { get; set; } = 10;
    } 
}