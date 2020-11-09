using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_insertion_sort : MonoBehaviour
{
    public Material[] mat;
    // the maximum number of cubes we want to sort
    public int NOC = 20;

    // maximum height of a cube is 10 
    public int Cube_H = 20;

    //array of GameObjects
    public GameObject[] Cubes;
    

    //this is the initializer for our cubes
    void init()
    {
        // initialzing the array with the number of cubes we want
        Cubes = new GameObject[NOC];
        for (int i = 0; i < NOC; i++)
        {

            int random_value = Random.Range(1, Cube_H + 1);
            //this is used to get a set of random values for sorting which ranges from 1 to the max cube height 
            // i used cube height + 1 because Random.Range doesn't include the upper limit in the set of values so if used only the height as upper limit i can never get a cube of max height.

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //the above line is used to create cubes using primitive mesh renderer.

            Renderer  cubeRenderer = cube.GetComponent<Renderer>();

            //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material = mat[0];

            //setting up the dimensions of the cube
            cube.transform.localScale = new Vector3(0.9f, random_value, 1);

            //setting up the position of each cube
            cube.transform.position = new Vector3(i, random_value / 2.0f, 0);

            //to reference the parent array Cubes
            cube.transform.parent = this.transform;

            Cubes[i] = cube;
            //LeanTween.color(Cubes[i], Color.white, 1);

        }

    }


    /*  
       void printer(int []list)
      {
          string s = "";
          for (int i = 0; i < list.Length; i++)
          {
              s = s + list[i].ToString(); 

          }

          Debug.Log(s);
      }
    */   Vector3 temp_position,st;
   IEnumerator  insertion_sort(GameObject[] list)
    {
        GameObject main, t1, t2,temp;
        Vector3 s1, s2, s3;

         for(int i=1;i<list.Length;i++)
        {
            main = list[i];
            s1 = list[i].transform.localPosition;

           int j = i - 1;

            while ( j >= 0 && (list[j].transform.localScale.y > main.transform.localScale.y ) )    
            {
                yield return new WaitForSeconds(1f);

                t1 = list[j];
                t2 = list[j + 1];
              
                temp = list[j];
                list[j] = list[j + 1];
                list[j + 1] = temp;
                s2 = list[j].transform.localPosition;
                s3 = list[j + 1].transform.localPosition;


                //list[j].transform.localPosition = new Vector3(s3.x,s2.y,s2.z);
                LeanTween.moveLocalX(list[j], s3.x, 1);
                LeanTween.moveLocalZ(list[j], -3, 0.5f).setLoopPingPong(1);
                LeanTween.color(list[j], Color.cyan, 1);
                yield return new WaitForSeconds(1f);

                //  list[j + 1].transform.localPosition = new Vector3(s2.x,s3.y,s3.z);
                LeanTween.moveLocalX(list[j + 1], s2.x, 1);
                LeanTween.moveLocalZ(list[j+1], 3, 0.5f).setLoopPingPong(1);

                LeanTween.color(list[j + 1], Color.yellow, 1);

                j = j - 1;

            }
            LeanTween.color(list[j+1],Color.yellow,1);
        }
    }


      void Start()
      {

        // int[] list = new int[] { 2, 3, 1, 4, 5 };

        //Debug.Log(" initial : ");

        //  printer(list);
        init();
        StartCoroutine(insertion_sort(Cubes));
      
        
      }

}
