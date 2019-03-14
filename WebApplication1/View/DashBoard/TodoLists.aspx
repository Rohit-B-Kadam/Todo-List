<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoLists.aspx.cs" Inherits="WebApplication1.View.DashBoard.TodoLists" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style  type="text/css">
        .my-container
        {
            height: 500px;
        }

        .form-signin {
            max-width: 330px;
            padding: 15px;
            margin: 0 auto;
        }

            .form-signin .form-control {
                position: relative;
                height: auto;
                -webkit-box-sizing: border-box;
                -moz-box-sizing: border-box;
                box-sizing: border-box;
                padding: 10px;
                font-size: 16px;
            }

                .form-signin .form-control:focus {
                    z-index: 2;
                }
            .button-grp
            {
                display: flex;
                justify-content:space-around;
                padding:5px;
            }

            .item
            {
                padding-left:20px;
            }

            .header
            {
                display:flex;
                justify-content:center;
            }
    </style>

    <div>
        <div class="container">
            <div class="row">
                <!-- Left -->
                <div class="col-sm my-container">
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">My Tasks:</h5>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="grdTaskView" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="grdTaskView_SelectedIndexChanged" DataKeyNames="TaskId" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField>
                                    <HeaderTemplate >
                                          Select
                                    </HeaderTemplate>
                                    <ItemTemplate >
                                         <asp:CheckBox ID="chk" runat="server" OnCheckedChanged="CheckBox2_CheckedChanged" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:BoundField DataField="TaskId" HeaderText="TaskId" SortExpression="TaskId"  
                                        InsertVisible="False" ReadOnly="True" HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" 
                                        ItemStyle-Width="500px"  HeaderStyle-HorizontalAlign="Center"
                                        ItemStyle-CssClass="item" HeaderStyle-CssClass="header"/>
                                </Columns>
                                <FooterStyle BackColor="#CCCC99" />
                                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                                <RowStyle BackColor="#F7F7DE" />
                                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                                <SortedAscendingHeaderStyle BackColor="#848384" />
                                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                                <SortedDescendingHeaderStyle BackColor="#575357" />
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [TaskId], [Title] FROM [Task] WHERE ([UserId] = @UserId) ORDER BY [Priority] DESC">
                                <SelectParameters>
                                    <asp:SessionParameter DefaultValue="1" Name="UserId" SessionField="UserId" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </div>
                        <div class="card-footer">
                            <div class="button-grp">
                                <asp:Button ID="BtnComplete" CssClass="btn btn-success" runat="server" Text="Complete" Width="120px" OnClick="BtnComplete_Click" />
                            </div>
                            <div class="alert alert-success" role="alert">
                                <asp:Label ID="LblShowStatus" runat="server"></asp:Label>  
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Right -->
                <div class="col-sm my-container" >
                    <div class="card">
                        <div class="card-header">
                            <h5 class="card-title">Create New Task</h5>
                        </div>
                        <div class="card-body">
                            <div class="container">

        <form class="form-signin" id="form1" >
                <div class="form-group">
                <label for="TxtTitle">Title:</label>
                <asp:TextBox ID="TxtTitle" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
               
            </div>
            <div class="form-group">
                <label for="DDPrioritySelected">Priority:</label>
                <asp:DropDownList id="DDPrioritySelected"
                    AutoPostBack="True"
                    runat="server">
                    
                    <asp:ListItem Value="0"> Low </asp:ListItem>
                    <asp:ListItem Selected="True" Value="1"> Normal </asp:ListItem>
                    <asp:ListItem Value="2"> High </asp:ListItem>

               </asp:DropDownList>
            </div>
            <div class="form-group">
                <asp:Button ID="AddTask" runat="server" OnClick="AddTask_Click"
                    CssClass="btn btn-lg btn-success btn-block" Text="Add Task"/>
            </div>
            <div class="alert alert-success" role="alert">
                <asp:Label ID="lblSuccess" runat="server" Text=""></asp:Label>
            </div>
        </form>
    </div>    
                                                 
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
