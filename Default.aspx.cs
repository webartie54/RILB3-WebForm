using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplicationTDDijon2
{
    public partial class _Default : Page
    {
        public ModelProductsContainer Db { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.btn_traduction.Click += Btn_traduction_Click;
            this.GridView.Sorting += GridView_Sorting; 
            
            Db = new ModelProductsContainer();
            this.GridView.DataSource = Db.ProductSet.ToList();
            this.GridView.DataBind();


        }

        private void GridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            

            string sortBy = e.SortExpression;
            string way = e.SortDirection.ToString();

            if (Session["way"] != null)
                way = (Session["way"].ToString()=="Ascending")?"Descending":"Ascending";

            


            switch (sortBy)
            {

                case "Name":
                    break;

                case "Id":
                    break;

                default:
                    break;
            }




            var datasource = Db.ProductSet.OrderByDescending(a => a.Name);

            if (way == "Ascending")
            {
                datasource = Db.ProductSet.OrderBy(a => a.Name);
            }
            Session["way"] = way;


            this.GridView.DataSource = datasource.ToList();
            this.GridView.DataBind();


        }



        /*

            private void Btn_traduction_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
            */

        protected void btn_traduction_Click(object sender, EventArgs e)
        {
            lab_traduction.Text = "Le site est en français maintenant";

        }


    }
}