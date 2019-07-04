using Big.Nutresa.Imagix.DataAccess.Domain;
using System.Linq;

namespace Big.Nutresa.Imagix.DataAccess.DAL
{
    public class ConfigurationGroupDAL
    {
        public static string GetContentProviderByProgram(int ProgramId)
        {
            string data="";
            using (dbBigNutresaImagixEntities context = new dbBigNutresaImagixEntities())
            {
                // This works.
                NI_ConfigurationGroup result = context.NI_ConfigurationGroup
                    .Where(C => C.ProgramId == ProgramId).FirstOrDefault();
                if(result!=null)
                    data = result.ContentProviderClass;

            }
            return data;

        }
    }
}
