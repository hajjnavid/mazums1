﻿using Newtonsoft.Json;
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
using RestSharp.Extensions;

public partial class Sarp : System.Web.UI.Page
{
    Ado_Class con = new Ado_Class();
    protected void Page_Load(object sender, EventArgs e)
    {
        con.connect(Application["StrCon"].ToString());
        Ado_Class.strcon = Application["StrCon"].ToString();
        if (!Page.IsPostBack)
        {
            con.FillCheckBoxList(chk_req, "select id,value  from tbl_BulidReq");
            con.FillDropdownList(ddl_req, "select id,value from tbl_bastebandi");
            SqlDataAdapter ad = new SqlDataAdapter("select * from tbl_AutoPlaceCare", con.con());
            DataSet ds = new DataSet();
            ad.Fill(ds, "tbl_AutoPlaceCare");
            GridView1.DataSource = ds;
            GridView1.DataMember = "tbl_AutoPlaceCare";
            GridView1.DataBind();
        }
    }

    protected void btn_Click(object sender, EventArgs e)
    {

        try
        {
            con.open();
            con.cammand();
            for (int i = 0; i < chk_req.Items.Count; i++)
            {
                if (chk_req.Items[i].Selected)
                
                con.commandtext("Insert into tbl_AutoPlaceCare values (@0,@1)");
                con.setcommandInt(0, ddl_req.ID);
                con.setcommandInt(1, chk_req.Items[i].Text);
                con.addcommand();
                
            }
            con.close();
            string User = ddl_req.Text;
            pop.PopOnShow(User + " " + "به ثبت رسیده است");

        }
        catch (Exception ex)
        {
            pop.PopOnShow("Error" + ex.Message);
        }
       ;
    }




    protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "del")
        {
            int id = Convert.ToInt32(e.CommandArgument);
            con.open();
            con.cammand();
            con.commandtext("delete from tbl_AutoPlaceCare where id_b=@0");
            con.setcommandDecimal(0, id.ToString());
            con.addcommand();
            con.close();
            Response.Redirect("Sarp.aspx");

        }

    }







}
