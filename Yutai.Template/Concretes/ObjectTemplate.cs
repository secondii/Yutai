﻿using System;
using System.Collections.Generic;
using System.Xml;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common.Helpers;
using Yutai.Plugins.Template.Interfaces;
using Yutai.Shared;

namespace Yutai.Plugins.Template.Concretes
{
    public class ObjectTemplate : IObjectTemplate
    {
        private string _name;
      
        private List<IYTField> _fields;
        private string _geometryTypeName;
        private string _baseName;
        private string _aliasName;
        private string _datasetName;
        private esriGeometryType _geometryType;
        private esriFeatureType _featureType;
        private string _featureTypeName;
        private int _id=-1;


        public ObjectTemplate()
        {
            _fields = new List<IYTField>();
        }

        public ObjectTemplate(XmlNode node)
        {
            _fields = new List<IYTField>();
            ReadFromXml(node);
        }

        public ObjectTemplate(IRow pRow)
        {
            _id = pRow.OID;
            _name = FeatureHelper.GetRowValue(pRow, "TemplateName").ToString();
            _baseName = FeatureHelper.GetRowValue(pRow, "BaseName").ToString();
            _aliasName = FeatureHelper.GetRowValue(pRow, "AliasName").ToString();
            _datasetName = FeatureHelper.GetRowValue(pRow, "Dataset").ToString();
            _geometryTypeName = FeatureHelper.GetRowValue(pRow, "GeometryType").ToString();
            _geometryTypeName=string.IsNullOrEmpty(_geometryTypeName)?"Point":_geometryTypeName;
            
            _featureTypeName = FeatureHelper.GetRowValue(pRow, "FeatureType").ToString();
            _featureTypeName = string.IsNullOrEmpty(_featureTypeName) ? "Simple" : _featureTypeName;
           
            _geometryType = GeometryHelper.ConvertFromString(_geometryTypeName);
            _featureType = FeatureHelper.ConvertStringToFeatureType(_featureTypeName);
            _fields=new List<IYTField>();

        }

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string BaseName
        {
            get { return _baseName; }
            set { _baseName = value; }
        }

        public string AliasName
        {
            get { return _aliasName; }
            set { _aliasName = value; }
        }

        public string DatasetName
        {
            get { return _datasetName; }
            set { _datasetName = value; }
        }

        public esriFeatureType FeatureType
        {
            get { return _featureType; }
            set { _featureType = value; }
        }


        public string GeometryTypeName
        {
            get { return _geometryTypeName; }
            set { _geometryTypeName = value; }
        }

        public esriGeometryType GeometryType
        {
            get { return _geometryType; }
            set { _geometryType = value; }
        }

        public List<IYTField> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public void ReadFromXml(XmlNode xmlNode)
        {
            if (xmlNode.Attributes != null)
            {
                _name = xmlNode.Attributes["Name"].Value;
                _baseName = xmlNode.Attributes["BaseName"].Value;
                _aliasName = xmlNode.Attributes["AliasName"].Value;
                _datasetName = xmlNode.Attributes["Dataset"].Value;
                _geometryTypeName = xmlNode.Attributes["GeometryType"].Value;
                _geometryType = string.IsNullOrEmpty(_geometryTypeName)
                    ? esriGeometryType.esriGeometryPoint
                    : GeometryHelper.ConvertFromString(_geometryTypeName);
                _featureTypeName = xmlNode.Attributes["FeatureType"].Value;
                _featureType = string.IsNullOrEmpty(_featureTypeName)
                   ? esriFeatureType.esriFTSimple
                   : FeatureHelper.ConvertStringToFeatureType(_featureTypeName);
            }
            XmlNodeList nodeList =
                xmlNode.SelectNodes($"/ObjectTemplates/Template[@Name='{_name}']/Fields/Field");
            foreach (XmlNode node in nodeList)
            {
                IYTField field = new YTField(node);
                _fields.Add(field);
            }
        }
        public XmlNode ToXml(XmlDocument doc)
        {
            XmlNode templateNode = doc.CreateElement("Template");

            XmlAttribute nameAttribute = doc.CreateAttribute("Name");
            nameAttribute.Value = _name;
            templateNode.Attributes.Append(nameAttribute);

            nameAttribute = doc.CreateAttribute("AliasName");
            nameAttribute.Value = _aliasName;
            templateNode.Attributes.Append(nameAttribute);

            nameAttribute = doc.CreateAttribute("BaseName");
            nameAttribute.Value = _baseName;
            templateNode.Attributes.Append(nameAttribute);

            nameAttribute = doc.CreateAttribute("Dataset");
            nameAttribute.Value = _datasetName;
            templateNode.Attributes.Append(nameAttribute);

            nameAttribute = doc.CreateAttribute("FeatureType");
            nameAttribute.Value = FeatureHelper.ConvertTypeToSimpleString(_featureType);
            templateNode.Attributes.Append(nameAttribute);

            nameAttribute = doc.CreateAttribute("GeometryType");
            nameAttribute.Value = GeometryHelper.ConvertToString(_geometryType);
            templateNode.Attributes.Append(nameAttribute);

            XmlNode fieldsNode = doc.CreateElement("Fields");
            foreach (IYTField ytField in _fields)
            {
                fieldsNode.AppendChild(ytField.ToXml(doc));
            }
            templateNode.AppendChild(fieldsNode);
            return templateNode;
        }

        public void UpdateRow(IRow pRow )
        {
            pRow.Value[pRow.Fields.FindField("TemplateName")] = _name;
            pRow.Value[pRow.Fields.FindField("AliasName")] = _aliasName;
            pRow.Value[pRow.Fields.FindField("BaseName")] = _baseName;
            pRow.Value[pRow.Fields.FindField("Dataset")] = _datasetName;
            pRow.Value[pRow.Fields.FindField("FeatureType")] = FeatureHelper.ConvertTypeToSimpleString(_featureType);
            pRow.Value[pRow.Fields.FindField("GeometryType")] = GeometryHelper.ConvertToString(_geometryType);
            pRow.Store();
            _id = pRow.OID;
        }
    }
}