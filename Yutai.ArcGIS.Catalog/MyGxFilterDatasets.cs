﻿using System.IO;
using ESRI.ArcGIS.Geodatabase;

namespace Yutai.ArcGIS.Catalog
{
    public class MyGxFilterDatasets : IGxObjectFilter
    {
        public bool CanChooseObject(IGxObject igxObject_0, ref MyDoubleClickResult myDoubleClickResult_0)
        {
            if (!(igxObject_0 is IGxDataset))
            {
                if (igxObject_0 is IGxVCTObject)
                {
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRChooseAndDismiss;
                    return true;
                }
                if (igxObject_0 is IGxLayer)
                {
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRChooseAndDismiss;
                    return true;
                }
                if (igxObject_0 is IGxObjectContainer)
                {
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRShowChildren;
                    return true;
                }
                if (igxObject_0 is IGxAGSMap)
                {
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRChooseAndDismiss;
                    return true;
                }
                return false;
            }
            switch ((igxObject_0 as IGxDataset).DatasetName.Type)
            {
                case esriDatasetType.esriDTContainer:
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRShowChildren;
                    break;

                case esriDatasetType.esriDTFeatureDataset:
                case esriDatasetType.esriDTCadDrawing:
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRChooseAndDismiss;
                    break;

                default:
                    myDoubleClickResult_0 = MyDoubleClickResult.myDCRChooseAndDismiss;
                    break;
            }
            return true;
        }

        public bool CanDisplayObject(IGxObject igxObject_0)
        {
            return (((igxObject_0 is IGxDataset) || (igxObject_0 is IGxLayer)) ||
                    ((igxObject_0 is IGxAGSMap) || (igxObject_0 is IGxObjectContainer)));
        }

        public bool CanSaveObject(IGxObject igxObject_0, string string_0, ref bool bool_0)
        {
            try
            {
                if ((igxObject_0 is IGxDiskConnection) || (igxObject_0 is IGxFolder))
                {
                    string path = (igxObject_0 as IGxFile).Path + @"\" + string_0;
                    bool_0 = File.Exists(path);
                    return true;
                }
                if (igxObject_0 is IGxDatabase)
                {
                    bool_0 =
                        ((igxObject_0 as IGxDatabase).Workspace as IWorkspace2).get_NameExists(
                            esriDatasetType.esriDTFeatureClass, string_0);
                    return true;
                }
                if ((igxObject_0 is IGxDataset) &&
                    ((igxObject_0 as IGxDataset).Type == esriDatasetType.esriDTFeatureDataset))
                {
                    bool_0 =
                        ((igxObject_0 as IGxDataset).Dataset.Workspace as IWorkspace2).get_NameExists(
                            esriDatasetType.esriDTFeatureClass, string_0);
                    return true;
                }
            }
            catch
            {
            }
            return false;
        }

        public string Description
        {
            get { return "数据集"; }
        }

        public string Name
        {
            get { return "Dataset"; }
        }
    }
}