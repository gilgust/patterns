using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Composite
{
    class ElementXML: IDocElement
    {
        private List<ElementXML> _children;
        private XmlNode _node;

        public ElementXML(XmlDocument parent)
        {
            _node = parent.CreateNode()
        }

        public void Draw()
        {
            Console.WriteLine();
        }

        public IDocElement Find(string nameElem)
        {
            return null;
        }

        public void AddElement(string nameElem, string Content)
        {
            throw new NotImplementedException();
        }
    }
}
