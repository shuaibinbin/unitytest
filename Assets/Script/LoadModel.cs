using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadModel : MonoBehaviour {

    public List<Button> button;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < button.Count; i++)
        {
            string te = button[i].GetComponentInChildren<Text>().text;
            te = te.Remove(0, 2);
            button[i].onClick.AddListener(() => ButtonOnClick(te));
        }
        
    }
   
	// Update is called once per frame
	void Update () {
       
    }
    void ButtonOnClick(string te)
    {
        StartCoroutine(Load(te));
    }

    Dictionary<string, AssetBundle> keyValuePairs = new Dictionary<string, AssetBundle>();

    IEnumerator Load(string str)
    {
        string path = Application.dataPath+"/AssetsBundle/";
#if UNITY_ANDROID&&!UNITY_EDITOR 
        path = "jar:file://" + Application.dataPath + "!/assets";
#elif UNITY_STANDALONE_WIN || UNITY_EDITOR 
        path = "file://" + Application.dataPath + "/AssetsBundle/";
#endif
        print(path+str);
        AssetBundle assetBundle;
        if (!keyValuePairs.ContainsKey(str))
        {
            WWW wwws = WWW.LoadFromCacheOrDownload(path + str, 3);
            yield return wwws;
            if (wwws.isDone)
            {
                
                assetBundle = wwws.assetBundle;
                keyValuePairs.Add(str, assetBundle);
                GameObject obj = assetBundle.LoadAsset<GameObject>(str);
                if (null != obj && !GameObject.Find(str))
                {
                    Instantiate(obj).name = str;
                }
                //Object[] obj = assetBundle.LoadAllAssets<GameObject>();//加载出来放入数组中
                //                                                       // 创建出来
                //foreach (Object o in obj)
                //{
                //    Instantiate(o);
                //}
            }
        }
        else
        {
            keyValuePairs.TryGetValue(str, out assetBundle);
            GameObject obj = assetBundle.LoadAsset<GameObject>(str);
            if (null != obj && !GameObject.Find(str))
            {
                Instantiate(obj).name = str;
            }
        }
    }
}
