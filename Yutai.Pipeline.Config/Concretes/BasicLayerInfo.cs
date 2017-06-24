﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using Yutai.Pipeline.Config.Helpers;
using Yutai.Pipeline.Config.Interfaces;

namespace Yutai.Pipeline.Config.Concretes
{
    public class BasicLayerInfo:IBasicLayerInfo
    {
        private string _name;
        private string _aliasName;
        private bool _visible;
        private enumPipelineDataType _dataType;
        private enumPipelineHeightType _heightType;
        private string _validateKeys;
        private List<IYTField> _fields;
        private string _templateName;
        private IFeatureClass _featureClass;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string AliasName
        {
            get { return _aliasName; }
            set { _aliasName = value; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public enumPipelineDataType DataType
        {
            get { return _dataType; }
            set { _dataType = value; }
        }

        public enumPipelineHeightType HeightType
        {
            get { return _heightType; }
            set { _heightType = value; }
        }

        public string ValidateKeys
        {
            get { return _validateKeys; }
            set { _validateKeys = value; }
        }

        public List<IYTField> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }

        public string TemplateName
        {
            get { return _templateName; }
            set { _templateName = value; }
        }
        public IFeatureClass FeatureClass
        {
            get { return _featureClass; }
            set { _featureClass = value; }
        }

        public IYTField GetField(string typeWord)
        {
            IYTField field = _fields.FirstOrDefault(c => c.TypeName == typeWord);
            return field;
        }

        public string GetFieldName(string typeWord)
        {
            IYTField field = _fields.FirstOrDefault(c => c.TypeName == typeWord);
            return field!=null? field.Name:typeWord;
        }

        public BasicLayerInfo(XmlNode node)
        {
            ReadFromXml(node);
        }

        public BasicLayerInfo(XmlNode node,IPipelineTemplate template)
        {
            _fields.AddRange(template.Fields);
           ReadFromXml(node);
        }


        public void LoadTemplate(IPipelineTemplate template)
        {
            _fields.AddRange(template.Fields);
            
        }

        public void ReadFromXml(XmlNode node)
        {
            if (node.Attributes != null)
            {
                _name = node.Attributes["Name"] == null ? "" : node.Attributes["Name"].Value;
                _aliasName = node.Attributes["AliasName"] == null ? "" : node.Attributes["AliasName"].Value;
                _visible = node.Attributes["Visible"] == null
                    ? true
                    : (node.Attributes["Visible"].Value.ToUpper().StartsWith("T") ? true : false);
                _dataType = node.Attributes["DataType"] == null ? enumPipelineDataType.Point : EnumHelper.ConvertDataTypeFromString(node.Attributes["DataType"].Value);
                _heightType = node.Attributes["HeightType"] == null ? enumPipelineHeightType.Top : EnumHelper.ConvertHeightTypeFromStr(node.Attributes["HeightType"].Value);
                _validateKeys = node.Attributes["ValidateKeys"] == null ? "" : node.Attributes["ValidateKeys"].Value;
                _templateName = node.Attributes["TemplateName"] == null ? "" : node.Attributes["TemplateName"].Value;
            }

            XmlNodeList fieldNodes = node.SelectNodes("Fields/Field");
            foreach (XmlNode fieldNode in fieldNodes)
            {
                IYTField field = new YTField(fieldNode);
                //需要检查已有的字段定义中有没有重名的
                IYTField findField = _fields.FirstOrDefault(c => c.Name == field.Name);
                if (findField != null)
                {
                    _fields.Remove(findField);
                }
                _fields.Add(field);
            }
        }

        public void ReadFromXml(XmlNode xml, IPipelineTemplate template)
        {
            _fields.AddRange(template.Fields);
            ReadFromXml(xml);
        }

        public XmlNode ToXml(XmlDocument doc)
        {
            XmlNode layerNode = doc.CreateElement("Layer");
            XmlAttribute nameAttribute = doc.CreateAttribute("Name");
            nameAttribute.Value = _name;
            XmlAttribute aliasNameAttribute = doc.CreateAttribute("AliasName");
            aliasNameAttribute.Value = _aliasName;
            XmlAttribute templateAttribute = doc.CreateAttribute("Template");
            templateAttribute.Value = _templateName;
            XmlAttribute visibleAttribute = doc.CreateAttribute("Visible");
            visibleAttribute.Value = _visible.ToString();
            XmlAttribute typeAttribute = doc.CreateAttribute("DataType");
            typeAttribute.Value = EnumHelper.ConvertDataTypeToString(_dataType);
            XmlAttribute heightAttribute = doc.CreateAttribute("HeightType");
            heightAttribute.Value = EnumHelper.ConvertHeightTypeToStr(_heightType);
            XmlAttribute validateKeysAttribute = doc.CreateAttribute("ValidateKeys");
            validateKeysAttribute.Value = _validateKeys;
            layerNode.Attributes.Append(nameAttribute);
            layerNode.Attributes.Append(aliasNameAttribute);
            layerNode.Attributes.Append(templateAttribute);
            layerNode.Attributes.Append(visibleAttribute);
            layerNode.Attributes.Append(typeAttribute);
            layerNode.Attributes.Append(heightAttribute);
            layerNode.Attributes.Append(validateKeysAttribute);

            XmlNode fieldsNode = doc.CreateElement("Fields");
            foreach (IYTField ytField in _fields)
            {
                XmlNode fieldNode = ytField.ToXml(doc);
                fieldsNode.AppendChild(fieldNode);
            }
            layerNode.AppendChild(fieldsNode);
            return layerNode;
        }

      
    }
}
