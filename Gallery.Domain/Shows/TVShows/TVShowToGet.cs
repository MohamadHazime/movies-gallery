using System.Collections.Generic;

namespace Gallery.Domain
{
    public class TVShowToGet : ShowToGet
    {
        public string Name { get; set; }
        public List<string> OriginCountry { get; set; }
        public string FirstAirDate { get; set; }
    }
}
