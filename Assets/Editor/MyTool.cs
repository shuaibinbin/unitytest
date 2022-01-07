using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class MyTool
{

    [MenuItem("AssetsBundle/Build AssetBundles WebGL")]
    static void BuildAllAssetBundles()//进行打包
    {
        string dir = Application.dataPath+ "/AssetsBundle/";
        //判断该目录是否存在
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);//在工程下创建AssetBundles目录
        }
        //参数一为打包到哪个路径，参数二压缩选项  参数三 平台的目标
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.WebGL);
    }
    [MenuItem("AssetsBundle/Build AssetBundles Android")]
    static void BuildAllAssetBundlesAndroid()//进行打包
    {
        string dir = Application.dataPath + "/AssetsBundle/";
        //判断该目录是否存在
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);//在工程下创建AssetBundles目录
        }
        //参数一为打包到哪个路径，参数二压缩选项  参数三 平台的目标
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.Android);
    }
    [MenuItem("AssetsBundle/Build AssetBundles Win")]
    static void BuildAllAssetBundlesWin()//进行打包
    {
        string dir = Application.dataPath + "/AssetsBundle/";
        //判断该目录是否存在
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);//在工程下创建AssetBundles目录
        }
        //参数一为打包到哪个路径，参数二压缩选项  参数三 平台的目标
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    }
}
