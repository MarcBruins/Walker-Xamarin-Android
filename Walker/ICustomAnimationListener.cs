using System;
namespace Walker
{
    public interface ICustomAnimationListener
    {
        void Animate(int index, float offset, Direction direction);
    }
}
