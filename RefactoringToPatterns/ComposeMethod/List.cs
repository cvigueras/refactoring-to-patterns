namespace RefactoringToPatterns.ComposeMethod
{
    public class List
    {
        private readonly bool _readOnly;
        private int _size;
        private object[] _elements;

        public List(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new object[_size];
        }

        public void Add(object element)
        {
            if (_readOnly) return;

            if(GetNewSize() > _elements.Length)
            {
                var newElements = CreateNewElements();

                AssignNewElements(newElements);
            }

            InsertElement(element);
        }

        private void InsertElement(object element)
        {
            _elements[_size++] = element;
        }

        private void AssignNewElements(object[] newElements)
        {
            for (var i = 0; i < _size; i++)
                newElements[i] = _elements[i];

            _elements = newElements;
        }

        private object[] CreateNewElements()
        {
            return new object[_elements.Length + 10];
        }

        private int GetNewSize()
        {
            return _size + 1;
        }

        public object[] Elements()
        {
            return _elements;
        }
    }
}