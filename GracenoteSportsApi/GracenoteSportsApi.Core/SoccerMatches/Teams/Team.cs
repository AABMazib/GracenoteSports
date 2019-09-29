using System;

namespace GracenoteSportsApi.Core.SoccerMatches.Teams
{
    public class Team
    {
        public int TeamId { set; get; }
        public string Name { set; get; }
        public int PlayerId { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime? BirthDate { set; get; }
        public static Team FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            return new Team
            {
                TeamId = Convert.ToInt32(values[0]),
                Name = values[1],
                PlayerId = Convert.ToInt32(values[2]),
                FirstName = values[3],
                LastName = values[4],
                BirthDate = values[5].Equals("NULL", StringComparison.OrdinalIgnoreCase) ? (DateTime?)null : Convert.ToDateTime(values[5])
            };
        }
    }
}
