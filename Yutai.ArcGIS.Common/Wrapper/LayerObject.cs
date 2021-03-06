using ESRI.ArcGIS.Carto;

namespace Yutai.ArcGIS.Common.Wrapper
{
    public class LayerObject
    {
        private ILayer ilayer_0 = null;

        public ILayer Layer
        {
            get { return this.ilayer_0; }
            set { this.ilayer_0 = null; }
        }

        public LayerObject(ILayer ilayer_1)
        {
            this.ilayer_0 = ilayer_1;
        }

        public override string ToString()
        {
            return this.ilayer_0.Name;
        }
    }
}