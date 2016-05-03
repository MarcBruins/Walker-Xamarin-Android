using System;
using Android.App;
using Android.OS;
using Android.Views;
using Com.Goka.Walker;

namespace Sample
{
	public class FirstPageFragment : WalkerFragment
	{
		public int PAGE_POSITION = 0;

		private WalkerLayout _walkerLayout { get; set; }
		protected override WalkerLayout WalkerLayout { get {return _walkerLayout; } }

		protected override int PagePosition
		{
			get { return PAGE_POSITION; }
		}

		public static FirstPageFragment newInstance()
		{
			Bundle args = new Bundle();
			FirstPageFragment fragment = new FirstPageFragment();
			fragment.Arguments = args;
			return fragment;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.first, container, false);
		}

		public override void OnViewCreated(View view, Bundle savedInstanceState)
		{
			base.OnViewCreated(view, savedInstanceState);
		}
	}
}

