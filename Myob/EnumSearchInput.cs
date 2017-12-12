using ExpressCraft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myob
{
    public class EnumSearchInput : SearchInput
    {
        public Type EnumType;
        public EnumSearchInput(Type enumType)
        {
            EnumType = enumType;
            DisplayMember = "Name";
            ValueMember = "Id";
        }        

        public override bool SearchOnLoad()
        {
            return true;
        }

        public override bool ClearOnOpen()
        {
            return true;
        }

        public void SetValue(long Id, string name)
        {
            EditValue = Id;
            Text = name;            
        }

        public override void OnRequestSearch(string searchValue, GridView grid)
        {
            try
            {
                grid.ClearView();
                grid.ColumnHeadersVisible = false;

                DataTable dt = new DataTable();

                searchValue = (searchValue + "").Replace('_', ' ');

                dt.AddColumn("Id", DataType.Long);
                dt.AddColumn("Name", DataType.String);

                var names = Enum.GetNames(EnumType);
                var values = Enum.GetValues(EnumType);

                var length = names.Length;

                dt.BeginDataUpdate();

                for (int i = 0; i < length; i++)
                {
                    bool match = true;
                    string name = (names[i] + "").Replace('_', ' ');

                    if (!string.IsNullOrWhiteSpace(searchValue))
                    {
                        if (!name.ToLower().StartsWith(searchValue.ToLower()))
                        {
                            match = false;
                        }
                    }

                    if (match)
                    {
                        dt.AddRow(values.GetValue(i), name);
                    }
                }

                dt.EndDataUpdate();

                grid.DataSource = dt;

                grid.Columns[0].Visible = false;

                grid.RenderGrid();
            }
            catch (Exception)
            {
                grid.ClearView();
            }

            base.OnRequestSearch(searchValue, grid);
        }

        public override float GetDropdownWidth()
        {
            return 300.0f;
        }
    }
}
