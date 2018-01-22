using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Composite
{
    class DocXML:IDocElement
    {
        private XmlDocument xDoc;
        public string NameElement { get; set; }
        public string ContentElement { get; set; }

        public DocXML()
        {

        }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public IDocElement Find(string nameElem)
        {
            throw new NotImplementedException();
        }

        public void AddElement(string nameElem, string Content)
        {
            throw new NotImplementedException();
        }
    }
}
