﻿using ESRI.ArcGIS.Geodatabase;

namespace Yutai.ArcGIS.Catalog
{
    public class MyGxFilterPGDBFeatureDatasets : IGxObjectFilter
    {
        public bool CanChooseObject(IGxObject igxObject_0, ref MyDoubleClickResult myDoubleClickResult_0)
        {
            if ((igxObject_0 is IGxDiskConnection) || (igxObject_0 is IGxFolder))
            {
                myDoubleClickResult_0 = MyDoubleClickResult.myDCRShowChildren;
                return true;
            }
            if (igxObject_0 is IGxDatabase)
            {
                myDoubleClickResult_0 = MyDoubleClickResult.myDCRShowChildren;
                return true;
            }
            if ((igxObject_0 is IGxDataset) &&
                ((igxObject_0 as IGxDataset).Type == esriDatasetType.esriDTFeatureDataset))
            {
                myDoubleClickResult_0 = MyDoubleClickResult.myDCRChooseAndDismiss;
                return true;
            }
            return false;
        }

        public bool CanDisplayObject(IGxObject igxObject_0)
        {
            if ((igxObject_0 is IGxDiskConnection) || (igxObject_0 is IGxFolder))
            {
                return true;
            }
            if (igxObject_0 is IGxDatabase)
            {
                if (!(igxObject_0 as IGxDatabase).IsRemoteDatabase)
                {
                    return true;
                }
            }
            else if ((igxObject_0 is IGxDataset) &&
                     ((igxObject_0 as IGxDataset).Type == esriDatasetType.esriDTFeatureDataset))
            {
                return true;
            }
            return false;
        }

        public bool CanSaveObject(IGxObject igxObject_0, string string_0, ref bool bool_0)
        {
            if (igxObject_0 is IGxDatabase)
            {
                bool_0 =
                    ((igxObject_0 as IGxDatabase).Workspace as IWorkspace2).get_NameExists(
                        esriDatasetType.esriDTFeatureDataset, string_0);
                return true;
            }
            return false;
        }

        public string Description
        {
            get { return "个人数据库要素集"; }
        }

        public string Name
        {
            get { return "个人数据库要素集"; }
        }
    }
}