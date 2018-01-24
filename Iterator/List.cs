namespace Iterator
{
    class List: IContainer<ProcessAducation>
    {
        private readonly ProcessAducation[] _listAducations;

        public List(params ProcessAducation[] data)
        {
            _listAducations = new ProcessAducation[data.Length];
            data.CopyTo(_listAducations,0);
        }

        
        public IIterator<ProcessAducation> CreateIterator()
        {
            return new ForwardIterator(_listAducations);
        }

        private class ForwardIterator: IIterator<ProcessAducation>
        {
            private readonly ProcessAducation[] _sourceList;
            private int _position;

            public ForwardIterator(ProcessAducation[] list)
            {
                _sourceList = new ProcessAducation[list.Length];
                list.CopyTo(_sourceList, 0);
            }

            public void Reset()
            {
                _position = 0;
            }

            public void MoveNext()
            {
                _position++;
            }

            public bool IsDone
            {
                get { return _position > _sourceList.Length - 1; }
            }

            public ProcessAducation Current
            {
                get { return _sourceList[_position]; }
            }
        }
    }
}
