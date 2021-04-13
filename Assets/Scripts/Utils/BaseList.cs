using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BaseList<Base>
{
    public List<Base> list;

    [ContextMenu("Add")]
    public void Add<Child>(Child child) where Child : Base
    {
        list.Add(child);
    }
}
