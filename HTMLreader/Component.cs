using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace HTMLreader
{
    class Component: ICompanent
    {
        private HtmlNode _htmlComponent;
        private List<MainPage_2> _htmlDocuments;

        public Component(HtmlNode node)
        {
            _htmlComponent = node;
            _htmlDocuments = new List<MainPage_2>();

            var listNods = _htmlComponent.ChildNodes;
            HtmlDocument doc;
            string path;
            foreach (var item in listNods)
            {
                if (item.Name == "a")
                {
                    path = item.Attributes["href"].Value;
                    _htmlDocuments.Add(new MainPage_2(path));
                }
            }
        }

        public void Display()
        {
            var content = _htmlComponent.WriteContentTo();
            content = Regex.Replace(content, "<.*?>", String.Empty);
            Console.WriteLine(content);

            foreach (var item in _htmlDocuments)
            {
                 item.Display();   
            }
        }
    }
}
