//using UnityEngine;
//using System;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;

//public class Fractal : MonoBehaviour
//{

//    public Mesh mesh;
//    public Material material;
//    private int depth;
//    public Vector3 direction;
//    public Quaternion rotation;
//    Fractal parentFractal;
//    public string axiom = "LSYG";
//    bool getParentPos;
//    public Vector3 statePosis;
//    // Use this for initialization

//    void Start()
//    {
//        gameObject.AddComponent<MeshFilter>().mesh = mesh;
//        gameObject.AddComponent<MeshRenderer>().material = material;
//        CreateChildren();
//    }
//    string Expand(string input)
//    {
//        StringBuilder s = new StringBuilder();
//        foreach (char c in input)
//        {
//            if (LSystemManager.getInstance.rules.ContainsKey(c))
//            {
//                s.Append(LSystemManager.getInstance.rules[c]);
//            }
//            else
//            {
//                s.Append(c);
//            }

//        }
//        return s.ToString();
//    }
  

//    void ApplyProperties(GameObject _parent, Vector3 direction, String rule, bool getParentPosition)
//    {
//        this.transform.parent = _parent.transform;
//        parentFractal = this.transform.parent.GetComponent<Fractal>();
//        mesh = parentFractal.mesh;
//        material = new Material(Shader.Find("Diffuse"));
//        depth = parentFractal.depth + 1;
//        transform.localScale = Vector3.one * LSystemManager.getInstance.childScale;
//       // transform.localPosition = direction *(0.5f + 0.5f* LSystemManager.getInstance.childScale);
//        //transform.Rotate(direction);
//        direction = parentFractal.transform.eulerAngles;
//        if (getParentPosition == true)
//        transform.localPosition = transform.parent.localPosition;
//        rule = Expand(rule);
//        ApplyProperties2(rule);

//    }

//    void ApplyProperties2(string input)
//    {
//         foreach (char c in input)
//        {
//            switch (c)
//            {
        
//                //case '+':
//                //    transform.localPosition = Vector3.forward * 1f;
//                //    break;
//                //case '-':
//                //    transform.localPosition -= direction * 0.5f;
//                //    break;
//                //case '>':
//                //    transform.localPosition += Vector3.forward;
//                //    break;
//                //case '<':
//                //    transform.localPosition = transform.parent.localPosition;                    
//                //    break;
//                //case ')':
//                //    direction = Vector3.left;  
//                //    break;
//                //case '(':
//                //    direction = Vector3.right;
//                //    break;     
//                //case '!':
//                //    material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1);
//                //    break;
//                //case '|':
//                //    break;

//                case '0':
//                    transform.localPosition = Vector3.forward;
//                    getParentPos = true;
//                    break;
//                case '1':
//                    transform.localPosition = Vector3.forward;
//                    break;
//                case '[':
//                    Quaternion target = Quaternion.Euler(45, 0, 0);
//                    transform.localRotation = target;
//                    break;
//                case ']':
//                    Quaternion target1 = Quaternion.Euler(-45, 0, 0);
//                    transform.localRotation = target1;
//                    break;

//                default:
//                    break;
//            }
//        }
           
//         Debug.Log(input);
//        axiom = input;
//    }
//    public void CreateChildren()
//    {

//        if (depth < LSystemManager.getInstance.maxDepth)
//        {
//            new GameObject("Fractal Child" + depth).AddComponent<Fractal>().ApplyProperties(this.gameObject, this.transform.eulerAngles, axiom, getParentPos);
//        }
//    }
//}
