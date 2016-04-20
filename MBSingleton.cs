using UnityEngine;
	
public abstract class MBSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance = null;
	public static T Instance 
	{
		get 
		{
			if (_instance == null) 
			{
				_instance = FindObjectOfType<T> ();

				if (_instance == null) 
				{
					GameObject obj = new GameObject ("_DefaultSingleton");
					_instance = obj.AddComponent<T> ();
				}
			}

			return _instance;
		}
	}

	public static bool IsInstanceNull
	{
		get{return _instance == null;}
	}

	private bool _isPersistent = false;
	public bool IsPersistent
	{
		get {return _isPersistent;}
		set 
		{
			if(_isPersistent)
				return;

			if (value)
			{
				DontDestroyOnLoad (gameObject);
				_isPersistent = true;
			}
		}
	}

	protected virtual void Awake ()
	{
		if (_instance == null || _instance == this) 
		{
			_instance = this as T;
		}
		else 
		{
			Destroy (gameObject);
		}
	}
}
