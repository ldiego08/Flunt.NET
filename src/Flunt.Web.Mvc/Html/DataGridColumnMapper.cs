using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Flunt.Web.Mvc.Html
{
    public class DataGridColumnMapper<TModel>
    {
        private readonly IList<DataGridColumnMap<TModel>> columns;

        public DataGridColumnMapper()
        {
            this.columns = Empty.ListOf<DataGridColumnMap<TModel>>();
        }
    }

    public class DataGridColumnMap<TModel>
    {
        private readonly Expression<Func<TModel, object>> propertySelector;

        public DataGridColumnMap(Expression<Func<TModel, object>> propertySelector)
        {
            this.propertySelector = propertySelector;
        }
    }
}
