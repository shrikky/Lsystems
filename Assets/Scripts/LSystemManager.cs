using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class LSystemManager : MonoBehaviour
{
    public struct State
    {
        public GameObject obj;
        public Vector3 position;
        public float dir;
    }

    public int maxDepth = 4;
    public string axiom = "0";
    private State state;
    public Stack<State> states = new Stack<State>();
    public State currentState;
    private Dictionary<char, string> rules = new Dictionary<char, string>();
    public GameObject preFab;
    public static LSystemManager getInstance;
    private int count;
    public float angle;

    void Awake()
    {
        getInstance = this;

        // Pythogoras tree

        rules.Add('1' , "11");
        rules.Add('0', "1[0]0");
       // angle = 45;

        // SierPinski triangle

        rules.Add('A', "+B-A-B+");
        rules.Add('B', "-A+B+A-");
       // angle = 60;

        rules.Add('X', " X+YF+");
        rules.Add('Y', "-FX−Y");


        for(int i =0;i<maxDepth;i++)
        axiom = Expand(axiom);

       StartCoroutine(DragonCurve(axiom));
    }
   
    string Expand(string input)
    {
        StringBuilder s = new StringBuilder();
        foreach (char c in input) {
            if (LSystemManager.getInstance.rules.ContainsKey(c)){
                s.Append(LSystemManager.getInstance.rules[c]);
            }
            else {
                s.Append(c);
            }
        }
        return s.ToString();
    }
    public IEnumerator PythagorasTree(string input)
    {
        GameObject go;
        currentState.obj = GameObject.Find("root");
        currentState.position = currentState.obj.transform.position;

        foreach (char c in input)
        {
            switch (c)
            {
                case '0':
                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position +  go.transform.up * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                    yield return null;
                    break;
                case '1':              
                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position +  go.transform.up * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                    yield return null;
                    break;
              
                case '[': // Push position and angle, Then rotate by 45

                    states.Push(currentState);
                    currentState.dir -= angle;
                    currentState.position = currentState.obj.transform.position;
                    yield return null;
                    break;
                case ']':

                    // Pop position and angle, turn right by 45
                    currentState = states.Pop();
                    currentState.dir += angle;
                    yield return null;
                    break;
                 
            }
        }

     //   Debug.Log(input);
        axiom = input;
    }

    public IEnumerator Sierpinski(string input)
    {
        GameObject go;
        currentState.obj = GameObject.Find("root");
        currentState.position = currentState.obj.transform.position;

        foreach (char c in input)
        {
            switch (c)
            {
                case 'A':
                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position + go.transform.forward * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                    yield return null;
                    break;

                case 'B':

                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position + go.transform.forward * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                    yield return null;
                    break;
                case '+': // Push position and angle, Then rotate by 45

                    states.Push(currentState);
                    currentState.dir -= angle;
                    currentState.position = currentState.obj.transform.position;
                    yield return null;
                    break;
                case '-':

                    // Pop position and angle, turn right by 45
                    states.Push(currentState);
                    currentState.dir += angle;
                    currentState.position = currentState.obj.transform.position;
                    yield return null;
                    break;

                default:
                    break;
            }
        }

      //  Debug.Log(input);
        axiom = input;
    }

    public IEnumerator DragonCurve(string input)
    {
        GameObject go;
        currentState.obj = GameObject.Find("root");
        currentState.position = currentState.obj.transform.position;

        foreach (char c in input)
        {
            switch (c)
            {
                case 'F':
                    go = Instantiate(preFab) as GameObject;
                    go.transform.SetParent(currentState.obj.transform);
                    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                    go.transform.position = currentState.position + go.transform.forward * 10f;
                    go.name = c.ToString() + count.ToString();
                    currentState.obj = go;
                    currentState.position = go.transform.position;
                    count++;
                   // yield return null;
                    break;

                //case 'X':

                //    go = Instantiate(preFab) as GameObject;
                //    go.transform.SetParent(currentState.obj.transform);
                //    go.transform.rotation = Quaternion.Euler(currentState.dir, 0, 0);
                //    go.transform.position = currentState.position + go.transform.forward * 10f;
                //    go.name = c.ToString() + count.ToString();
                //    currentState.obj = go;
                //    currentState.position = go.transform.position;
                //    count++;
                //    yield return null;
                //    break;
                case '+': // Push position and angle, Then rotate by 45

                    states.Push(currentState);
                    currentState.dir -= angle;
                    currentState.position = currentState.obj.transform.position;
                   // yield return null;
                    break;
                case '-':

                    // Pop position and angle, turn right by 45
                    states.Push(currentState);
                    currentState.dir += angle;
                    currentState.position = currentState.obj.transform.position;
                    yield return null;
                    break;

                default:
                    break;
            }
        }

       // Debug.Log(input);
        axiom = input;
    }
}
