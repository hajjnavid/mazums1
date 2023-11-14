using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class Buiild : System.Web.UI.Page
{
    Ado_Class con = new Ado_Class();


    protected void Page_Load(object sender, EventArgs e)
    {
        con.connect(Application["StrCon"].ToString());
        Ado_Class.strcon = Application["StrCon"].ToString();

        if (!Page.IsPostBack)
        {
            con.FillDropdownList(level_Id, "select id,value from tbl_levelID");
            SqlDataAdapter ad = new SqlDataAdapter("select * from tbl_NeedFlow ", con.con());
            DataSet ds = new DataSet();
            ad.Fill(ds, "tbl_NeedFlow");
            GridView1.DataSource = ds;
            GridView1.DataMember = "tbl_NeedFlow";
            GridView1.DataBind();
        }

    }

    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            con.open();
            con.cammand();
            con.commandtext("delete from tbl_NeedFlow where id=@0");
            con.setcommandDecimal(0, id.ToString());
            con.addcommand();
            con.close();
            Response.Redirect("Buiild.aspx");

        }

    }



    protected void btn_Click(object sender, EventArgs e)
    {


        try
        {
            con.connect(Application["StrCon"].ToString());
            con.open();
            con.cammand();
            con.commandtext("Insert into tbl_NeedFlow values (@0,@1,@2)");
            con.setcommandDecimal(0, "1");
            con.setcommandNvarChar(1, txt_date.Text);
            con.setcommandInt(2, level_Id.SelectedValue);

            con.addcommand();
            con.close();
            pop.PopOnShow("به ثبت رسیده است");



        }
        catch (Exception ex)
        {
            pop.PopOnShow("Error" + ex.Message);
        }
        ;

    }
}