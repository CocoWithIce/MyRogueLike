namespace GamePattern.Memento
{
    public class Singleton<T> where T : new()
    {
        private T _instance;

        public T Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                else
                {
                    _instance = new T();
                    return _instance;
                }
            }
        }
    }
}