using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Com.Goka.Walker;
using Android.Support.V7.App;
using Android.Graphics;

namespace Sample
{
	[Activity(Label = "Sample", MainLauncher = true, Icon = "@mipmap/icon",Theme = "@style/AppTheme")]
	public class MainActivity : AppCompatActivity, ViewPager.IOnPageChangeListener
	{
		private int currentPosition;
		private ImageView leftButton;
		private ImageView rightButton;
		private WalkerFragment[] fragments;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			fragments = new WalkerFragment[] {
				FirstPageFragment.newInstance(),
			 	SecondPageFragment.newInstance(),
				ThirdPageFragment.newInstance()
			};

			var viewPager = (Android.Support.V4.View.ViewPager)FindViewById(Resource.Id.view_pager);
			viewPager.Adapter = new MyAdapter(fragments,SupportFragmentManager);

			foreach (WalkerFragment fragment in fragments)
			{
				viewPager.AddOnPageChangeListener(fragment);
			}

			viewPager.AddOnPageChangeListener(this);

			currentPosition = 0;

			leftButton = (ImageView)FindViewById(Resource.Id.left);
			//leftButton.Visibility = Android.Views.ViewStates.Gone;
			rightButton = (ImageView)FindViewById(Resource.Id.right);

			leftButton.Click += (s,e) => 
			{
				viewPager.CurrentItem = currentPosition - 1;
			};

			rightButton.Click += (s, e) =>
			{
				viewPager.CurrentItem = currentPosition + 1;
			};
		}

		public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
		{
			
		}

		public void OnPageScrollStateChanged(int state)
		{
			
		}

		public void OnPageSelected(int position)
		{
			currentPosition = position;
		}

	}

	public class MyAdapter : FragmentStatePagerAdapter
	{
		private WalkerFragment[] fragments;

		public MyAdapter(WalkerFragment[] fragments, Android.Support.V4.App.FragmentManager supportFragmentManager) : base(supportFragmentManager)
		{
			this.fragments = fragments;	
		}

		public override int Count
		{
			get
			{
				return fragments.Length;
			}
		}

		public override Android.Support.V4.App.Fragment GetItem(int position)
		{
			return fragments[position];
		}
	}
}


