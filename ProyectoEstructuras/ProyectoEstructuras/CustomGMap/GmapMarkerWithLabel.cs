using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System.Drawing;
using System.Runtime.Serialization;

namespace ProyectoEstructuras.CustomGMap

{
    public class GmapMarkerWithLabel : GMarkerGoogle, ISerializable
    {
        private readonly Font _font;
        private GMarkerGoogle _innerMarker;
        private readonly string _caption;

        public GmapMarkerWithLabel(PointLatLng p, string caption, GMarkerGoogleType type) : base(p, type)
        {
            _font = new Font("Arial", 11);
            _innerMarker = new GMarkerGoogle(p, type);

            _caption = caption;
        }
        protected GmapMarkerWithLabel(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        
        public override void Dispose()
        {
            if (_innerMarker != null)
            {
                _innerMarker.Dispose();
                _innerMarker = null;
            }

            base.Dispose();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);
            var stringSize = g.MeasureString(_caption, _font);
            var localPoint = new PointF(LocalPosition.X - stringSize.Width / 2, LocalPosition.Y + stringSize.Height);
            g.DrawString(_caption, _font, Brushes.Black, localPoint);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            GetObjectData(info, context);
        }
    }
}
