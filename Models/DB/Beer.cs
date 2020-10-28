using System;

namespace DAMVC.Models.DB
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brewery { get; set; }  
        public string Country { get; set; }
        public float AlcPercent { get; set; }
        public float? PerceivedBitterness { get; set; }
        public float? PerceivedSweetness { get; set; }
        public float? PerceivedFruitiness { get; set; }
        public float ActualIBU { get; set; }
        public DateTime DrinkingTime { get; set; }
        public int SubmittedByUser { get; set; }
    }
}
