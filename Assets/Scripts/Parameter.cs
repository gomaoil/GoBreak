using UnityEngine;

public class Parameter : MonoBehaviour {
	[SerializeField]
    private PlayerParameter mPlayerParameter;
    public PlayerParameter Player { get { return mPlayerParameter; } }

    // シングルトン
    static private Parameter sInstance;
    static public Parameter Instance { get { return sInstance; } }

    // コンストラクタでシングルトンの代表的な処理
    public Parameter()
    {
        Debug.Assert(sInstance == null);
        if (sInstance == null)
        {
            sInstance = this;
        }
    }
}
