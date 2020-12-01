using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
   /*ublic enum LanguageType
    {
        C_Sharp =1,
        Python,
        C,
        JaveScript,
        Java,
        Go,
        R,
        Swift,
        PHP
    }
   */
    public class DevTeam
    {
        public int DevTeamId { get; set; }
        public string DevTeamName { get; set; }
        public string DevTeamResponsibilty { get; set; }            //Properties
        public string DevTeamLanguage { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();


        public DevTeam() {} // why empty Constructor ??

        public DevTeam(int devTeamId, string devTeamName, string devTeamResponsibilty, string devTeamLanguage) //parameters
        {
            // Property  = parameters
            DevTeamId = devTeamId;
            DevTeamName = devTeamName;
            DevTeamResponsibilty = devTeamResponsibilty;
            DevTeamLanguage = devTeamLanguage;
          //  Developers = new List<Developer>();

        }
    }
}
