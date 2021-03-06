﻿using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using Yutai.ArcGIS.Common.Excel;
using Yutai.ArcGIS.Controls.Controls.Export;

namespace Yutai.ArcGIS.Controls.Controls
{
    public partial class frmAnalystTable : Form
    {
        private bool m_CanDo = false;
        private bool m_InEditing = false;
        private int m_MaxRecord = 2000;
        private ICursor m_pCursor = null;
        private DataTable m_pDataTable = new DataTable();
        private ITable m_pTable = null;
        private int m_RecordNum = 0;
        private string m_strGeometry = "";

        public frmAnalystTable()
        {
            this.InitializeComponent();
            this.dataGrid1.SetDataBinding(this.m_pDataTable, "");
            this.dataGrid1.ReadOnly = true;
            this.m_pDataTable.ColumnChanged += new DataColumnChangeEventHandler(this.m_pDataTable_ColumnChanged);
        }

        private void AddFilesInfo(IFields pFields)
        {
            for (int i = 0; i < pFields.FieldCount; i++)
            {
                IField field = pFields.get_Field(i);
                DataColumn column = new DataColumn(field.AliasName)
                {
                    Caption = field.AliasName
                };
                if (field.Type == esriFieldType.esriFieldTypeBlob)
                {
                    column.ReadOnly = true;
                }
                else if (field.Type == esriFieldType.esriFieldTypeGeometry)
                {
                    column.ReadOnly = true;
                }
                else
                {
                    column.ReadOnly = !field.Editable;
                }
                this.m_pDataTable.Columns.Add(column);
            }
        }

        private void AddRecord(bool bAll)
        {
            int num = 0;
            if (bAll)
            {
                num = this.m_RecordNum - this.m_pDataTable.Rows.Count;
            }
            else
            {
                num = ((this.m_RecordNum - this.m_pDataTable.Rows.Count) > this.m_MaxRecord)
                    ? this.m_MaxRecord
                    : this.m_RecordNum;
            }
            IFields fields = this.m_pCursor.Fields;
            int num2 = 0;
            IRow row = this.m_pCursor.NextRow();
            object[] values = new object[fields.FieldCount];
            while (row != null)
            {
                for (int i = 0; i < fields.FieldCount; i++)
                {
                    IField field = fields.get_Field(i);
                    if (field.Type == esriFieldType.esriFieldTypeGeometry)
                    {
                        values[i] = this.m_strGeometry;
                    }
                    else if (field.Type == esriFieldType.esriFieldTypeBlob)
                    {
                        values[i] = "二进制数据";
                    }
                    else
                    {
                        values[i] = row.get_Value(i);
                    }
                }
                this.m_pDataTable.Rows.Add(values);
                num2++;
                if (num2 > num)
                {
                    break;
                }
                row = this.m_pCursor.NextRow();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (this.m_RecordNum > this.m_pDataTable.Rows.Count)
            {
                this.AddRecord(true);
            }
            this.dataGrid1.CurrentRowIndex = this.m_pDataTable.Rows.Count - 1;
            this.txtIndex.Text = (this.dataGrid1.CurrentRowIndex + 1).ToString();
            this.btnLast.Enabled = true;
            this.btnFirstRecord.Enabled = true;
            this.btnEnd.Enabled = false;
            this.btnNext.Enabled = false;
        }

        private void btnExportGraphic_Click(object sender, EventArgs e)
        {
            new GraphicsWizard {DataSource = this.m_pTable}.ShowDialog();
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            YTExportExcel.ExportExcel(false, this.Text, this.dataGrid1.DataSource, this.Text);
        }

        private void btnFirstRecord_Click(object sender, EventArgs e)
        {
            this.dataGrid1.CurrentRowIndex = 0;
            this.txtIndex.Text = (this.dataGrid1.CurrentRowIndex + 1).ToString();
            this.btnLast.Enabled = false;
            this.btnFirstRecord.Enabled = false;
            this.btnNext.Enabled = true;
            this.btnEnd.Enabled = true;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.dataGrid1.CurrentRowIndex--;
            this.txtIndex.Text = (this.dataGrid1.CurrentRowIndex + 1).ToString();
            if (this.dataGrid1.CurrentRowIndex == 0)
            {
                this.btnLast.Enabled = false;
                this.btnFirstRecord.Enabled = false;
            }
            this.btnNext.Enabled = true;
            this.btnEnd.Enabled = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.dataGrid1.CurrentRowIndex++;
            this.txtIndex.Text = (this.dataGrid1.CurrentRowIndex + 1).ToString();
            this.btnLast.Enabled = true;
            this.btnFirstRecord.Enabled = true;
            if (this.dataGrid1.CurrentRowIndex == (this.m_pDataTable.Rows.Count - 1))
            {
                this.btnNext.Enabled = false;
                this.btnEnd.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            YTExportExcel.ExportExcel(true, this.Text, this.dataGrid1.DataSource, this.Text);
        }

        private void btnSaveEditing_Click(object sender, EventArgs e)
        {
        }

        private void btnStartEditing_Click(object sender, EventArgs e)
        {
            ((this.m_pTable as IDataset).Workspace as IWorkspaceEdit).StartEditing(true);
            this.dataGrid1.ReadOnly = false;
            this.btnStartEditing.Enabled = false;
            this.btnSaveEditing.Enabled = false;
            this.m_InEditing = true;
            this.btnStopEditing.Enabled = true;
        }

        private void btnStopEditing_Click(object sender, EventArgs e)
        {
        }

        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_pDataTable.Rows.Count != 1)
            {
                this.txtIndex.Text = (this.dataGrid1.CurrentRowIndex + 1).ToString();
                if (this.dataGrid1.CurrentRowIndex == (this.m_pDataTable.Rows.Count - 1))
                {
                    this.btnLast.Enabled = true;
                    this.btnFirstRecord.Enabled = true;
                    this.btnEnd.Enabled = false;
                    this.btnNext.Enabled = false;
                }
                else if (this.dataGrid1.CurrentRowIndex == 0)
                {
                    this.btnLast.Enabled = false;
                    this.btnFirstRecord.Enabled = false;
                    this.btnEnd.Enabled = true;
                    this.btnNext.Enabled = true;
                }
                else
                {
                    this.btnLast.Enabled = true;
                    this.btnFirstRecord.Enabled = true;
                    this.btnEnd.Enabled = true;
                    this.btnNext.Enabled = true;
                }
            }
        }

        private void frmTable_Load(object sender, EventArgs e)
        {
            this.Init();
            this.m_CanDo = true;
        }

        private string GetShapeString(IFeatureClass pFeatClass)
        {
            if (pFeatClass == null)
            {
                return "";
            }
            string str = "";
            switch (pFeatClass.ShapeType)
            {
                case esriGeometryType.esriGeometryPoint:
                    str = "点";
                    break;

                case esriGeometryType.esriGeometryMultipoint:
                    str = "多点";
                    break;

                case esriGeometryType.esriGeometryPolyline:
                    str = "线";
                    break;

                case esriGeometryType.esriGeometryPolygon:
                    str = "多边形";
                    break;

                case esriGeometryType.esriGeometryMultiPatch:
                    str = "多面";
                    break;
            }
            int index = pFeatClass.Fields.FindField(pFeatClass.ShapeFieldName);
            IGeometryDef geometryDef = pFeatClass.Fields.get_Field(index).GeometryDef;
            str = str + " ";
            if (geometryDef.HasZ)
            {
                str = str + "Z";
            }
            if (geometryDef.HasM)
            {
                str = str + "M";
            }
            return str;
        }

        public void Init()
        {
            this.m_pDataTable.Rows.Clear();
            this.m_pDataTable.Columns.Clear();
            if (this.m_pTable != null)
            {
                this.m_strGeometry = this.GetShapeString(this.m_pTable as IFeatureClass);
                IQueryFilter queryFilter = null;
                System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
                this.m_RecordNum = this.m_pTable.RowCount(queryFilter);
                this.m_pCursor = this.m_pTable.Search(queryFilter, false);
                this.AddFilesInfo(this.m_pTable.Fields);
                this.AddRecord(false);
                System.Windows.Forms.Cursor.Current = Cursors.Default;
            }
            if ((this.m_pDataTable.Rows.Count == 0) || (this.m_pDataTable.Rows.Count == 1))
            {
                this.btnFirstRecord.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnEnd.Enabled = false;
                this.btnNext.Enabled = false;
                this.txtIndex.Enabled = false;
            }
            else
            {
                this.btnFirstRecord.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnEnd.Enabled = true;
                this.btnNext.Enabled = true;
                this.txtIndex.Enabled = true;
            }
            this.txtIndex.Text = (this.dataGrid1.CurrentRowIndex + 1).ToString();
            if (this.m_InEditing)
            {
                this.btnSaveEditing.Enabled = true;
                this.btnStopEditing.Enabled = true;
                this.btnStartEditing.Enabled = false;
                this.dataGrid1.ReadOnly = false;
            }
            else
            {
                this.btnSaveEditing.Enabled = false;
                this.btnStopEditing.Enabled = false;
                this.btnStartEditing.Enabled = true;
            }
        }

        private void m_pDataTable_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (this.m_InEditing)
            {
                try
                {
                    IRow row;
                    int num;
                    object[] itemArray = e.Row.ItemArray;
                    IWorkspaceEdit workspace = (this.m_pTable as IDataset).Workspace as IWorkspaceEdit;
                    if (itemArray[0] is DBNull)
                    {
                        if (!(this.m_pTable is IFeatureClass))
                        {
                            workspace.StartEditOperation();
                            row = this.m_pTable.CreateRow();
                            num = row.Fields.FindFieldByAliasName(e.Column.ColumnName);
                            if (num != -1)
                            {
                                row.set_Value(num, e.ProposedValue);
                            }
                            workspace.StopEditOperation();
                            e.Row[this.m_pTable.OIDFieldName] = row.OID;
                        }
                    }
                    else
                    {
                        int num2 = Convert.ToInt32(itemArray[0]);
                        IQueryFilter queryFilter = new QueryFilterClass
                        {
                            WhereClause = this.m_pTable.OIDFieldName + " = " + num2.ToString()
                        };
                        ICursor o = this.m_pTable.Search(queryFilter, false);
                        row = o.NextRow();
                        if (row != null)
                        {
                            workspace.StartEditOperation();
                            num = row.Fields.FindFieldByAliasName(e.Column.ColumnName);
                            if (num != -1)
                            {
                                row.set_Value(num, e.ProposedValue);
                            }
                            row.Store();
                            workspace.StopEditOperation();
                        }
                        ComReleaser.ReleaseCOMObject(o);
                    }
                    this.btnSaveEditing.Enabled = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            }
        }

        private void txtIndex_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int num = Convert.ToInt32(this.txtIndex.Text);
                    if (num <= 0)
                    {
                        num = 1;
                    }
                    if (num >= this.m_pDataTable.Rows.Count)
                    {
                        num = this.m_pDataTable.Rows.Count - 1;
                    }
                    this.txtIndex.Text = num.ToString();
                    this.dataGrid1.CurrentRowIndex = num - 1;
                    if (this.dataGrid1.CurrentRowIndex == (this.m_pDataTable.Rows.Count - 1))
                    {
                        this.btnLast.Enabled = true;
                        this.btnFirstRecord.Enabled = true;
                        this.btnEnd.Enabled = false;
                        this.btnNext.Enabled = false;
                    }
                    else if (this.dataGrid1.CurrentRowIndex == 0)
                    {
                        this.btnLast.Enabled = false;
                        this.btnFirstRecord.Enabled = false;
                        this.btnEnd.Enabled = true;
                        this.btnNext.Enabled = true;
                    }
                    else
                    {
                        this.btnLast.Enabled = true;
                        this.btnFirstRecord.Enabled = true;
                        this.btnEnd.Enabled = true;
                        this.btnNext.Enabled = true;
                    }
                }
                catch
                {
                    MessageBox.Show("输入数据格式错误!");
                }
            }
        }

        public ITable Table
        {
            set
            {
                this.m_pTable = value;
                this.m_InEditing = ((this.m_pTable as IDataset).Workspace as IWorkspaceEdit).IsBeingEdited();
                if (this.m_CanDo)
                {
                    this.Init();
                }
            }
        }
    }
}