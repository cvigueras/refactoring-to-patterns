using System;
using System.Linq;
using System.Web;

namespace RefactoringToPatterns.ComposeMethod
{
    public class List
    {

        private readonly bool _readOnly;
        private int _size;
        private Object[] _elements;

        public List(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new Object[_size];
        }

        public void Add(Object element) {
            if(!_readOnly) {
                int newSize = _size + 1;

                if(newSize > _elements.Length) {
                    Object[] newElements = new Object[_elements.Length + 10];

                    for (int i = 0; i < _size; i++)
                        newElements[i] = _elements[i];

                    _elements = newElements;
                }

                _elements[_size++] = element;
            }
        }

        public object[] Elements()
        {
            return _elements;
        }

    }

}