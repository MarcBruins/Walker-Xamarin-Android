using System;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Goka.Walker;

namespace Sample
{
	public class ThirdPageFragment : WalkerFragment
	{
		public int PAGE_POSITION = 2;

		private WalkerLayout _walkerLayout { get; set; }
		protected override WalkerLayout WalkerLayout { get { return _walkerLayout; } }

		protected override int PagePosition
		{
			get { return PAGE_POSITION; }
		}

		public static ThirdPageFragment newInstance()
		{
			Bundle args = new Bundle();
			ThirdPageFragment fragment = new ThirdPageFragment();
			fragment.Arguments = args;
			return fragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.third, container, false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
			_walkerLayout = (WalkerLayout)view.FindViewById(Resource.Id.walker);
			_walkerLayout.SetAnimationType(WalkerLayout.AnimationType.Custom);
			_walkerLayout.CustomAnimationListener = new CustomAnimation(_walkerLayout);
			_walkerLayout.Setup();
		}

		class CustomAnimation : Java.Lang.Object, WalkerLayout.ICustomAnimationListener
		{
			WalkerLayout _walkerLayout { get; set; }

			public CustomAnimation(WalkerLayout layout)
			{
				_walkerLayout = layout;
			}


			public void Animate(int index, float offset, WalkerLayout.Direction direction)
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


