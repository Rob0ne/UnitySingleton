public abstract class Singleton<T> where T : class, new()
{
	private static T _instance = null;
	public static T Instance 
	{
		get 
		{
			if (_instance == null) 
				_instance = new T();

			return _instance;
		}
	}

	public static bool IsInstanceNull
	{
		get{return _instance == null;}
	}
	
	public Singleton()
	{
		if (_instance == null) 
			_instance = this as T;
	}
}