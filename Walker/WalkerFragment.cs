using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace Walker
{
    public abstract class WalkerFragment : Fragment, ViewPager.IOnPageChangeListener
    {
        protected abstract int PagePosition
        {
            get;
        }

        protected abstract WalkerLayout WalkerLayout
        {
            get;
        }

        public void OnPageScrollStateChanged(int state) { }

        public void OnPageSelected(int position) { }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {
            if (WalkerLayout != null)
            {
                int pagePosition = PagePosition;
                if (position >= pagePosition)
                {
                    WalkerLayout.Walk(1.0f - positionOffset, Direction.Right);
                }
                else if (position < pagePosition)
                {
                    WalkerLayout.Walk(positionOffset, Direction.Left);
                }
            }
        }

        public static T NewInstance<T>() where T : WalkerFragment, new()
        {
            Bundle args = new Bundle();
            var fragment = new T();
            fragment.Arguments = args;
            return fragment;
        }
    }
}
