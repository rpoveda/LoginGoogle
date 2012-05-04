using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ML;
using BL;

namespace UI
{
    public partial class Default : System.Web.UI.Page
    {

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            if (Session["dadosJson"] != null)
            {
                ltlRetorno.Text = Session["dadosJson"].ToString();
            }
            else if (Session["dadosObjeto"] != null)
            {
                var obj = (ObjGoogle) Session["dadosObjeto"];
                var montastring = "";
                montastring += "Id: " + obj.id;
                montastring += "<br/>Email: " + obj.email;
                montastring += "<br/>Name: " + obj.name;
                montastring += "<br/><img src='" + obj.picture + "'/>";
                ltlRetorno.Text = montastring;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["access_token"] != null)
                {
                    ArgsGoogle.AccessToke = Request.QueryString["access_token"];

                    if(Session["tipoRetorno"].ToString() == "json")
                    {
                        Session["dadosJson"] = AuthenticationGoogle.ReturnJson();
                    }
                    else if(Session["tipoRetorno"].ToString() == "objeto")
                    {
                        Session["dadosObjeto"] = AuthenticationGoogle.ReturnObject();
                    }
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void lbGoogle_OnClick(object sender, EventArgs e)
        {
            var url = ArgsGoogle.UrlAuthenticationComplete();
            Session["tipoRetorno"] = rbTipo.SelectedValue;
            Response.Redirect(url);
        }
    }
}