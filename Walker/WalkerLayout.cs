
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Widget;

namespace Walker
{
    public class WalkerLayout : RelativeLayout
    {
        public static string TAG = nameof(WalkerLayout);

        public PointF Speed
        {
            get;
            set;
        } = new PointF(0, 0);

        public PointF SpeedVariance
        {
            get;
            set;
        } = new PointF(0, 0);

        public bool EnableAlphaAnimation = false;

        public AnimationType Animation
        {
            get;
            set;
        } = AnimationType.Linear;

        public PointF[] ChildSpeeds
        {
            get;
            set;
        }

        public List<string> IgnoredViewTags
        {
            get;
            set;
        } = new List<string>();

        public ICustomAnimationListener CustomAnimationListener
        {
            get;
            set;
        }

        public WalkerLayout(Context context) : base(context)
        {
        }

        public WalkerLayout(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public WalkerLayout(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {

        }

        public void Setup()
        {
            int count = ChildCount;
            ChildSpeeds = new PointF[count];
            for (int i = 0; (i < count); i++)
            {
                Speed.X = (Speed.X + SpeedVariance.X);
                Speed.Y = (Speed.Y + SpeedVariance.Y);
                ChildSpeeds[i] = Speed;
            }

        }

        public void Walk(float offset, Direction direction)
        {
            for (int i = 0; i < ChildSpeeds.Length; i++)
            {
                switch (Animation)
                {
                    case AnimationType.Linear:
                        animationLinear(i, offset, direction);
                        break;
                    case AnimationType.Zoom:
                        animationZoom(i, offset, direction);
                        break;
                    case AnimationType.Curve:
                        animationCurve(i, offset, direction);
                        break;
                    case AnimationType.InOut:
                        animationInOut(i, offset, direction);
                        break;
                    case AnimationType.Custom:
                        if ((this.CustomAnimationListener != null))
                        {
                            this.CustomAnimationListener.Animate(i, offset, direction);
                        }

                        break;
                }
                if (this.EnableAlphaAnimation)
                {
                    this.animationAlpha(i, offset, direction);
                }

            }

        }

        private void animationAlpha(int index, float offset, Direction direction)
        {
            var view = GetChildAt(index);
            var tag = (string)view.Tag;
            if (!this.IgnoredViewTags.Contains(tag))
            {
                view.Alpha = offset;
            }

        }

        private void animationCurve(int index, float offset, Direction direction)
        {
            if ((ChildSpeeds.Length <= 0))
            {
                return;
            }

            float dx = 0;
            float dy = ((1 - offset)
                        * 10);
            switch (direction)
            {
                case Direction.Left:
                    dx = ((1 - offset)
                                * 10);
                    dy = ((1 - offset)
                                * 10);
                    break;
                case Direction.Right:
                    dx = ((offset - 1)
                                * 10);
                    dy = ((offset - 1)
                                * 10);
                    break;
            }
            Translation(index, ((((float)(Math.Pow(dx, 3)))
                            - (dx * 25))
                                * ChildSpeeds[index].X), ((((float)(Math.Pow(dy, 3)))
                            - (dy * 20))
                            * ChildSpeeds[index].Y));
        }

        private void animationZoom(int index, float offset, Direction direction)
        {
            var scle = (1 - offset);
            Scale(index, (1 - scle), (1 - scle));
        }

        private void animationLinear(int index, float offset, Direction direction)
        {
            if ((ChildSpeeds.Length <= 0))
            {
                return;
            }

            float dx = 0;
            float dy = ((1 - offset)
                        * 100);
            switch (direction)
            {
                case Direction.Left:
                    dx = ((1 - offset)
                                * 100);
                    break;
                case Direction.Right:
                    dx = ((offset - 1)
                                * 100);
                    break;
            }
            this.Translation(index, (dx * ChildSpeeds[index].X), (dy * ChildSpeeds[index].Y));
        }

        private void animationInOut(int index, float offset, Direction direction)
        {
            if ((ChildSpeeds.Length <= 0))
            {
                return;
            }

            float dx = 0;
            float dy = (1 - offset);
            switch (direction)
            {
                case Direction.Left:
                    dx = (1 - offset);
                    break;
                case Direction.Right:
                    dx = (offset - 1);
                    break;
            }
            this.Translation(index, (dx
                            * (ChildSpeeds[index].X * 100)), (dy
                            * (ChildSpeeds[index].Y * 100)));
        }

        public void Scale(int index, float scaleX, float scaleY)
        {
            var view = GetChildAt(index);
            var tag = (string)view.Tag;
            if (!IgnoredViewTags.Contains(tag))
            {
                view.ScaleX = scaleX;
                view.ScaleY = scaleY;
            }
        }

        public void Translation(int index, float translationX, float translationY)
        {
            var view = GetChildAt(index);
            var tag = (string)view.Tag;
            if (!IgnoredViewTags.Contains(tag))
            {
                view.TranslationX = translationX;
                view.TranslationY = translationY;
            }
        }
    }
}