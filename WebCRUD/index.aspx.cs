using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
namespace WebCRUD
{
    public partial class index : System.Web.UI.Page
    {
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                grdBind();
            }
            lblShow.Visible = false;
        }
        private void Clear()
        {
            txtCustomerName.Text = txtAge.Text = txtAdress.Text = txtEmail.Text = "";
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
                if (txtAdress.Text == "" || txtAge.Text == "" || txtCustomerName.Text == "" || txtEmail.Text == "")
                {
                    lblShow.Text = "Please fill all necessary DATA!";
                    lblShow.ForeColor = Color.Maroon;
                    lblShow.Visible = true;
                }

                else
                {
                    SqlConnection conn = new SqlConnection(DataSource.DS);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into Customer values('" + txtCustomerName.Text + "','" + txtAge.Text + "','" + txtAdress.Text + "','" + txtEmail.Text + "')", conn);
                    int t = cmd.ExecuteNonQuery();
                    if (t > 0)
                    {
                        lblShow.Text = "Successfully inserted!";
                        lblShow.Visible = true;
                        grdBind();
                    }
                    Clear();
                }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Clear();
        }
        protected void grdBind()
        {
            SqlConnection conn = new SqlConnection(DataSource.DS);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Customer", conn);
            SqlDataReader DR = cmd.ExecuteReader();
            if(DR.HasRows == true)
            {
                grdCustomer.DataSource = DR;
                grdCustomer.DataBind();
            }
        }

        protected void grdCustomer_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdCustomer.EditIndex = e.NewEditIndex;
            grdBind();
        }

        protected void grdCustomer_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int id = Convert.ToInt32(grdCustomer.DataKeys[e.RowIndex].Value.ToString());
            string name = ((TextBox)grdCustomer.Rows[e.RowIndex].Cells[1].Controls[0]).Text.ToString();
            string age = ((TextBox)grdCustomer.Rows[e.RowIndex].Cells[2].Controls[0]).Text.ToString();
            string adress = ((TextBox)grdCustomer.Rows[e.RowIndex].Cells[3].Controls[0]).Text.ToString();
            string email = ((TextBox)grdCustomer.Rows[e.RowIndex].Cells[4].Controls[0]).Text.ToString();

            SqlConnection conn = new SqlConnection(DataSource.DS);
            conn.Open();
            int t = CRUD.Update(id, name, age, adress, email);
            if(t > 0)
            {
                lblShow.Text = "Successfully updated!";
                lblShow.Visible = true;
                grdCustomer.EditIndex = -1;
                grdBind();
            }
        }

        protected void grdCustomer_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(grdCustomer.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection conn = new SqlConnection(DataSource.DS);
            conn.Open();
            int t = CRUD.Delete(id);
            if(t > 0)
            {
                lblShow.Text = "Successfully deleted!";
                lblShow.Visible = true;
                grdCustomer.EditIndex = -1;
                grdBind();
            }
        }

        protected void grdCustomer_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdCustomer.EditIndex = -1;
            grdBind();
        }
    }
}