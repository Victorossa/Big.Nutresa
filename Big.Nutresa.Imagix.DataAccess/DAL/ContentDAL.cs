using Big.Nutresa.Imagix.DataAccess.Domain;
using System;
using System.Linq;
using System.Xml;

namespace Big.Nutresa.Imagix.DataAccess.DAL
{
    public class ContentDAL
    {
        public static XmlDocument GetContentConfiguration(int programId)
        {
            XmlDocument doc = new XmlDocument();
            

            using (dbBigNutresaImagixEntities context = new dbBigNutresaImagixEntities())
            {
                
                var Test1 = context.NI_ConfigurationGroup.Where(C => C.ProgramId == programId).FirstOrDefault();
                
               doc.LoadXml(Test1.ContentProviderSettings);
            }


            return doc;
        }


    }
}
