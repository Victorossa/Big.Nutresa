using Big.Nutresa.Imagix.DataAccess.DAL;
using Big.Nutresa.Imagix.UI.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big.Nutresa.Imagix.Business.BLL
{
    public class ConfigurationGroupBLL
    {
        public int ProgramId { get; set; }
        public string Assembly { get; set; }
        const string MethodAssembly = "GetContent";
        public string Idiom{get;set;}
        public string Path { get; set; }
        public ConfigurationGroupBLL()
        {  
            
        }
        

        public void GetContentProviderClassByProgramId(int ProgramId)
        {
            
            this.Assembly= ConfigurationGroupDAL.GetContentProviderByProgram(ProgramId);
        }

        public object GetContent()
        {

            object[] parametersArray = new object[] { this.Idiom,this.Path,this.ProgramId };
            GetContentProviderClassByProgramId(this.ProgramId);
            return Utility.InvokeMethod(Assembly, MethodAssembly, parametersArray);

        }
    }
}
