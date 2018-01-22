namespace Composite
{
    interface IDocElement
    { 
        void Draw();
        IDocElement Find(string nameElem);
        void AddElement(string nameElem, string Content);
    }
}
