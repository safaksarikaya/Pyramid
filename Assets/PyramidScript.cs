using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyramidScript : MonoBehaviour
{
  public Transform cubes;
  private void Start()
  {
    MakePyramid();
  }
  void MakePyramid()
  {
    bool doubleIndex = false, left = false;
    var totalLineCount = GetLineCount();
    var lineIndex = 0; var index = 0;
    float x = 0, z = 0;
    for (int i = 0; i < cubes.childCount; i++)
    {
      cubes.GetChild(i).localPosition = new Vector3(left ? -x : x, 0, z);
      if (lineIndex == index)
      {
        lineIndex++;
        index = 0;
        z--;
        doubleIndex = !doubleIndex;
        left = true;
        if (doubleIndex) x = .5f; else x = 0;
      }
      else
      {
        index++;
        if (index % 2 == 0)
        {
          if (!doubleIndex)
            left = !left;
          else
            x++;
        }
        else
        {
          if (!doubleIndex)
            x++;
          else
            left = !left;
        }
      }
    }
  }
  int GetLineCount()
  {
    int z = 0, line = 0, totalLine = 0;
    for (int i = 0; i < cubes.childCount; i++)
    {
      for (int j = 0; j < i; j++)
      {
        if ((j + 1) == i)
        {
          line += i;
          z++;
          if (line == cubes.childCount)
          {
            totalLine = z;
          }
        }
      }
    }
    return totalLine;
  }
}