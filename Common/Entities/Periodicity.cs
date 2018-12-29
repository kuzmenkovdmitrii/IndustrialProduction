namespace Common.Entities
{
    public class Periodicity
    {
        public int Id { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }

        public bool OnceAWeek { get; set; }
        public bool TwiceAWeek { get; set; }
        public bool ThreeTimesAWeek { get; set; }
        public bool OnceAMonth { get; set; }
    }
}
