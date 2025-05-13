// MyClass.cs
using System;
using UnityEngine;

namespace MyClass
{
    // ���� Color �N���X
    [Serializable]
    public class MyColor
    {
        // Params
        public int r;
        public int g;
        public int b;

        // ���R���X�g���N�^
        public MyColor()
        {
            this.r = 255;
            this.g = 255;
            this.b = 255;
        }

        // �F�� int �Ŏw�肷��R���X�g���N�^
        public MyColor(int r, int g, int b)
        {
            this.r = r % 256;
            this.g = g % 256;
            this.b = b % 256;
        }

        // �F�� Vector3 �Ŏw�肷��R���X�g���N�^
        public MyColor(Vector3 color)
        {
            this.r = (int)color.x % 256;
            this.g = (int)color.y % 256;
            this.b = (int)color.z % 256;
        }

        // �����_���ɐF���쐬(Getter)
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

    // ���� Object �N���X
    [Serializable]
    public class MyObject
    {
        public MyColor color;

        // ���R���X�g���N�^
        public MyObject()
        {
            this.color = new MyColor(0, 0, 0);
        }

        // �F���w�肷��R���X�g���N�^
        public MyObject(MyColor color)
        {
            this.color = color;
        }

        // �����_���ȐF�����I�u�W�F�N�g���쐬(Getter)
        public static MyObject randomColorObject
        {
            get { 
                return new MyObject(MyColor.random); 
            }
        }

        // MyObject �𕶎���Ƃ��ĕԂ�
        public string GetInfoString()
        {
            return $"r: {color.r}\ng: {color.g}\nb: {color.b}";
        }
    }
}
