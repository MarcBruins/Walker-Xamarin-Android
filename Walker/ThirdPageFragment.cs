using Android.OS;
using Android.Views;
using Walker;

namespace Sample
{
    public class ThirdPageFragment : WalkerFragment
    {
        protected override int PagePosition => 2;

        private WalkerLayout _walkerLayout;
        protected override WalkerLayout WalkerLayout => _walkerLayout;

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            //    _walkerLayout = (WalkerLayout)view.FindViewById(Resource.);
            _walkerLayout.Animation = AnimationType.Custom;
            _walkerLayout.CustomAnimationListener = new CustomAnimation(_walkerLayout);
            _walkerLayout.Setup();
        }

        class CustomAnimation : Java.Lang.Object, ICustomAnimationListener
        {
            WalkerLayout _walkerLayout { get; set; }

            public CustomAnimation(WalkerLayout layout)
            {
                _walkerLayout = layout;
            }

            public void Animate(int index, float offset, Direction direction)
            {
                View child = _walkerLayout.GetChildAt(index);
                string tag = (string)child.Tag;
                switch (tag)
                {
                    case "1":
                        child.Rotation = ((180.0f) * (1.0f - offset));
                        break;
                    case "2":
                        child.TranslationX = (0.0f);
                        child.TranslationY = ((1.0f - offset) * 200);
                        break;
                }
            }

        }
    }
}


