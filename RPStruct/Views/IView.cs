using System;

namespace RPStruct.Views;

internal interface IView
{
    public abstract void Update();

    public abstract void Draw();
}
