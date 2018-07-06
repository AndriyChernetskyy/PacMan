using System.Collections.Generic;

namespace PacMan2._0.VisitorPattern
{
    public class ObjectStructure
    {
        public List<Element> elements = new List<Element>();
        public void Add(Element element) => elements.Add(element);
        public void Remove(Element element) => elements.Remove(element);

        public void Accept(Visitor visitor)
        {
            foreach (Element element in elements)
            {
                element.SomePosition = element.Accept(visitor);
                element.Symbol = "G";
            }
        }

    }
}
