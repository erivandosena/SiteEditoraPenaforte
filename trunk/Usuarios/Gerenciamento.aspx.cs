using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class Adm_Usuarios_Gerenciamento : System.Web.UI.Page
{
    string[] rolesArray;
    MembershipUserCollection users;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Permissões de acesso conforme role p/ a pagina gerencimanto.aspx
        if (!Roles.IsUserInRole("Administrador") == true)
        {
            Response.Redirect("/Adm/Default.aspx");
        }

        Msg.Text = "";
        if (!IsPostBack)
        {
            // Bind roles to ListBox.
            SelecionaRole();
            // Bind users to ListBox.
            SelecionaUser();
        }
    }

    private void SelecionaRole()
    {
        rolesArray = Roles.GetAllRoles();
        ListBoxRegra.DataSource = rolesArray;
        ListBoxRegra.DataBind();
    }
    private void SelecionaUser()
    {
        users = Membership.GetAllUsers();
        //Grid
        GridView1.DataSource = users;
        GridView1.DataBind();
        //List
        ListBoxUsuario.DataSource = users;
        ListBoxUsuario.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (GridView1.Rows[e.RowIndex].Cells[0].Text != "Admin")
        {
            string str = this.GridView1.Rows[e.RowIndex].Cells[0].Text;
            Membership.DeleteUser(str);
            LblMsg.Text = "Usuário excluído com sucesso.";
            SelecionaUser();
        }
        else
        {
            LblMsg.Text = "Você não pode <strong>auto-exclui-se</strong>!";
        }
    }

    protected void BtnExcluiRegra_Click(object sender, EventArgs e)
    {
        string delRole = "";

        if (ListBoxRegra.SelectedItem.Value == "Administrador")
        {
            Msg.Text = "Você não poderá incluir a regra <strong>" + ListBoxRegra.SelectedItem.Value + "</strong>";
        }
        else

            try
            {
                delRole = ListBoxRegra.SelectedItem.Value;
                Roles.DeleteRole(delRole);
                Msg.Text = "Regra <strong>" + Server.HtmlEncode(delRole) + "</strong> excluída.";
                // Re-bind roles to ListBox.
                SelecionaRole();
            }
            catch
            {
                Msg.Text = "Regra <strong>" + Server.HtmlEncode(delRole) + "</strong> <u>não</u> excluída.";
            }
    }

    protected void BtnCriaRegra_Click(object sender, EventArgs e)
    {
        string createRole = TextBoxRegra.Text;

        if (string.IsNullOrEmpty(createRole))
        {
            Msg.Text = "Por favor, informe um nome para a nova regra.";
            TextBoxRegra.Focus();
        }
        else

            try
            {

                if (Roles.RoleExists(createRole))
                {
                    Msg.Text = "Regra <strong>" + Server.HtmlEncode(createRole) + "</strong> já existe. Por favor, especifique um nome de regra diferente.";
                    TextBoxRegra.Text = string.Empty;
                    return;
                }

                Roles.CreateRole(createRole);
                Msg.Text = "Regra <strong>" + Server.HtmlEncode(createRole) + "</strong> criada.";
                TextBoxRegra.Text = string.Empty;
                // Re-bind roles.
                SelecionaRole();
            }
            catch (Exception ex)
            {
                Msg.Text = "Regra <strong>" + Server.HtmlEncode(createRole) + "</strong> <u>não</u> criada.";
                Response.Write(ex.ToString());
            }
    }

    protected void BtnAdicionaRegra_Click(object sender, EventArgs e)
    {
        // Verifique se um usuário e, pelo menos, um papel é selecionado.
        if (ListBoxUsuario.SelectedItem == null)
        {
            Msg.Text = "Por favor selecione um usuário.";
            return;
        }

        int[] role_indices = ListBoxRegra.GetSelectedIndices();

        if (role_indices.Length == 0)
        {
            Msg.Text = "Por favor, selecione uma ou mais regras.";
            return;
        }

        // 	Criar lista de funções a adicionar os usuários selecionados.
        string[] rolesList = new string[role_indices.Length];

        for (int i = 0; i < rolesList.Length; i++)
        {
            rolesList[i] = ListBoxRegra.Items[role_indices[i]].Value;
        }

        // Adicione os usuários para a função selecionada.
        try
        {
            Roles.AddUserToRoles(ListBoxUsuario.SelectedItem.Value, rolesList);
            Msg.Text = "Usuário adicionado à regra(s).";

            // Rebind roles to ListBox.
            SelecionaRegraUsuario();
        }
        catch (HttpException ex)
        {
            Msg.Text = ex.Message;
        }
    }

    protected void BtnRemoveRegra_Click(object sender, EventArgs e)
    {
        // Verifique se pelo menos um usuário e pelo menos um papel são selecionados.
        if (ListBoxUsuario.SelectedItem == null)
        {
            Msg.Text = "Por favor selecione um usuário.";
            return;
        }

        if (LabelUsuarioRegra.Text == "Admin" && ListBoxUsuarioRegra.SelectedItem.Value.Trim() == "Administrador")
        {
            Msg.Text = "A regra <strong>" + ListBoxUsuarioRegra.SelectedItem.Value + "</strong> do usuário <strong>" + LabelUsuarioRegra.Text + "</strong> não se deve excluír.";
            return;
        }

        int[] role_indices = ListBoxUsuarioRegra.GetSelectedIndices();

        if (role_indices.Length == 0)
        {
            Msg.Text = "Por favor, selecione uma ou mais regras.";
            return;
        }

        // Criar lista de papéis a ser remover o usuário selecionado.
        string[] rolesList = new string[role_indices.Length];

        for (int i = 0; i < rolesList.Length; i++)
        {
            rolesList[i] = ListBoxUsuarioRegra.Items[role_indices[i]].Value;
        }

        // Remova o usuário com os papéis selecionados.
        try
        {
            Roles.RemoveUserFromRoles(ListBoxUsuario.SelectedItem.Value, rolesList);
            Msg.Text = "Usuário removido da(s) regra(s).";

            // Rebind roles to ListBox.
            SelecionaRegraUsuario();
        }
        catch (HttpException ex)
        {
            Msg.Text = ex.Message;
        }
    }
    protected void ListBoxUsuario_SelectedIndexChanged(object sender, EventArgs e)
    {
        LabelUsuarioRegra.Text = ListBoxUsuario.SelectedItem.Value;
        SelecionaRegraUsuario();
    }

    private void SelecionaRegraUsuario()
    {
        // Bind users to ListBox.
        rolesArray = Roles.GetRolesForUser(ListBoxUsuario.SelectedItem.Value);
        ListBoxUsuarioRegra.DataSource = rolesArray;
        ListBoxUsuarioRegra.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        SelecionaUser();
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Button btnExclui = e.Row.Cells[2].Controls[0] as Button;
            btnExclui.OnClientClick = "if (confirm('Tem certeza que deseja incluir este usuário?') == false) return false;";
        }
    }
}
