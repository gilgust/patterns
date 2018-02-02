using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace HTMLreader
{
    class MainPage_2: ICompanent
    {
        public HtmlDocument _root { get; set; }
        public List<Component> _listNodes; 

        public MainPage_2(string path)
        {
            _root = new HtmlDocument();
            _root.Load(path,Encoding.UTF8);
            _listNodes = new List<Component>();
            HtmlNodeCollection listNodes = _root.DocumentNode.SelectNodes("//div");


            foreach (var VARIABLE in listNodes)
            {
                _listNodes.Add(new Component(VARIABLE));
            }
            
        }

        public void Display()
        {
            if(_listNodes.Count != 0) { 
                foreach (var component in _listNodes)
                {
                    component.Display();
                }
            }
            else
            {
                var node = _root.DocumentNode.SelectSingleNode("//body");
                var content = node.WriteContentTo();
                content = Regex.Replace(content, "<.*?>", String.Empty);
                Console.WriteLine(content);
            }
        }
    }
}
