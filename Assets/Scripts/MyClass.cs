// MyClass.cs
using System;
using UnityEngine;

namespace MyClass
{
    // 似非 Color クラス
    [Serializable]
    public class MyColor
    {
        // Params
        public int r;
        public int g;
        public int b;

        // 基底コンストラクタ
        public MyColor()
        {
            this.r = 255;
            this.g = 255;
            this.b = 255;
        }

        // 色を int で指定するコンストラクタ
        public MyColor(int r, int g, int b)
        {
            this.r = r % 256;
            this.g = g % 256;
            this.b = b % 256;
        }

        // 色を Vector3 で指定するコンストラクタ
        public MyColor(Vector3 color)
        {
            this.r = (int)color.x % 256;
            this.g = (int)color.y % 256;
            this.b = (int)color.z % 256;
        }

        // ランダムに色を作成(Getter)
        public static MyColor random
        {
            get { 
                return new MyColor(
                    UnityEngine.Random.Range(0, 255), 
                    UnityEngine.Random.Range(0, 255), 
                    UnityEngine.Random.Range(0, 255)
                ); 
            }
        }
    }

    // 似非 Object クラス
    [Serializable]
    public class MyObject
    {
        public MyColor color;

        // 基底コンストラクタ
        public MyObject()
        {
            this.color = new MyColor(0, 0, 0);
        }

        // 色を指定するコンストラクタ
        public MyObject(MyColor color)
        {
            this.color = color;
        }

        // ランダムな色を持つオブジェクトを作成(Getter)
        public static MyObject randomColorObject
        {
            get { 
                return new MyObject(MyColor.random); 
            }
        }

        // MyObject を文字列として返す
        public string GetInfoString()
        {
            return $"r: {color.r}\ng: {color.g}\nb: {color.b}";
        }
    }
}
