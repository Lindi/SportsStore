<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SportsStore.WebUI.Models.ProductListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% foreach ( var product in Model.Products) { %>
        <% Html.RenderPartial("ProductSummary", product ); %>
    <% } %>

    <div class="pager">
        <%: Html.PageLinks(Model.PagingInfo, x => Url.Action("List", new { page = x })) %>
    </div>
</asp:Content>
