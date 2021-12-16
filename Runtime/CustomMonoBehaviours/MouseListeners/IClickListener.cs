using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace U.Gears.MouseListeners
{
    public interface IClickListener
    {
        bool isInside { get; }
        bool isHold { get; }
        Vector2 currentMousePoss { get; }
        Vector2 lastClickPoss { get; }
        bool isClick { get; }
        UnityEvent OnClick { get; }
        UnityEvent OnHold { get; }
    }

}
