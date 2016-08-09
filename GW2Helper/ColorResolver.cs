using System;
using System.Windows.Media;

namespace GW2Helper
{
    public class ColorResolver
    {
        private readonly Color _lotsOfTimeColor;
        private readonly Color _left30Color;
        private readonly Color _left15Color;
        private readonly Color _left5Color;
        private readonly Color _left2Color;
        private readonly Color _leftNowColor;

        public ColorResolver()
        {
            _lotsOfTimeColor = Color.FromRgb(0, 189, 0);
            _left30Color = Color.FromRgb(155, 189, 0);
            _left15Color = Color.FromRgb(189, 155, 0);
            _left5Color = Color.FromRgb(189, 95, 0);
            _left2Color = Color.FromRgb(189, 0, 0);
            _leftNowColor = Color.FromRgb(0, 189, 189);
        }

        public Color FromTimeSpan(TimeSpan timeRemaining)
        {
            var toMs = timeRemaining.TotalMilliseconds;

            if (toMs > 1800000)
            {
                return _lotsOfTimeColor;
            }
            if (toMs < 0)
            {
                return _leftNowColor;
            }
            if (toMs > 900000)
            {
                return _left30Color;
            }
            if (toMs > 300000)
            {
                return _left15Color;
            }
            if (toMs > 120000)
            {
                return _left5Color;
            }
            return _left2Color;
        }
    }
}