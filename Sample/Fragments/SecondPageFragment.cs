using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Walker;

namespace Sample
{
    public class SecondPageFragment : WalkerFragment
    {
        protected override int PagePosition => 1;

        private WalkerLayout _walkerLayout;
        protected override WalkerLayout WalkerLayout => _walkerLayout;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.second, container, false);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            _walkerLayout = (WalkerLayout)view.FindViewById(Resource.Id.walker);
            _walkerLayout.Speed = new PointF(1.0f, 0.0f);
            _walkerLayout.SpeedVariance = new PointF(1.2f, 0.0f);
            _walkerLayout.EnableAlphaAnimation = true;
            _walkerLayout.IgnoredViewTags = new List<string>() { "1", "2" };
            _walkerLayout.Setup();
        }
    }
}

