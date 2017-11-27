using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : Component
{
    private static T _instance;
	public static T instance
	{
		get{
			if(_instance == null)
			{
                _instance = FindObjectOfType(typeof(T)) as T;
				if(_instance == null)
				{
					//創建 GameObject 用於掛載單例的 T 對象
                    GameObject obj = new GameObject();
                    obj.hideFlags = HideFlags.HideAndDontSave;
					//給 obj 掛載新的 T，因為AddComponent返回的是 Component，所以需要轉換回 T
                    _instance = (T)obj.AddComponent(typeof(T));
                }
            }
            return _instance;
        }
	}
	protected virtual void Awake()
	{
        DontDestroyOnLoad(this.gameObject);
		if(_instance == null)
		{
            _instance = this as T;
        }
		else
		{
			//當 Instance 非空的時候仍然調取了 Awake，這個時候要删除新生成的 gameObject
            Destroy(gameObject);
        }
    }
}
