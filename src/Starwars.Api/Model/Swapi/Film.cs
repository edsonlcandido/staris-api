namespace Starwars.Api.Model{
    // Remove the duplicate class definition    
    public class Film{
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }   
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public string url { get; set; }  
        public int id {get{
            int id = Int32.Parse(url.TrimEnd('/').Split('/').Last());
            return id;}}              
    }
}
